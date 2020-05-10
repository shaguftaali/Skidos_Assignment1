using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    //public Text text;
    //string URL = "http://j41rw.mocklab.io/v1/demo/math/data";
    // Start is called before the first frame update

    private static DataManager instance = null;
    public JsonData data = new JsonData();
    public bool isDataLoaded;

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        LoadDataFromJson();
        DontDestroyOnLoad(this.gameObject);
    }
    


    void LoadDataFromJson()
    {
        string filePath = "JSON_Data/Data";
        TextAsset textAsset = Resources.Load<TextAsset>(filePath);
        if (null==textAsset)
        {
            Debug.LogError("cant load data");
        }
        isDataLoaded = true;
        ProcessData(textAsset.text);
    }

    void ProcessData(string jsonString)
    {
        JSONNode node = JSON.Parse(jsonString);     
        data.addtion = ProcessOperationData(node["Addition"], "Addition",OperationType.Addition);
        data.geometry = ProcessOperationData(node["Geometry"], "Geometry",OperationType.Geometry);
        data.mix = ProcessOperationData(node["Mixed Operations"], "Mixed Operations",OperationType.MixedOperations);
        data.numberSense = ProcessOperationData(node["Number sense"], "Number sense", OperationType.NumberSnese);
        data.subtraction = ProcessOperationData(node["Subtraction"], "Subtraction", OperationType.Subtraction);
    }



    Operation ProcessOperationData(JSONNode node,string name, OperationType operationType)
    {
        Operation operation = new Operation();
        operation.name = name;
        operation.operationType = operationType;
        operation.level = new Level[node.Count];
        for (int i = 0; i < node.Count; i++)
        {
          operation.level[i] = new Level();
          operation.level[i].subTopics = ProcessSubTopicData(node[i].AsArray);
        }
        return operation;
    }

   
    SubTopics[] ProcessSubTopicData(JSONArray arr)
    {
        SubTopics[] subTopics = new SubTopics[arr.Count];
        for (int i = 0; i < arr.Count; i++)
        {
            subTopics[i] = new SubTopics();
            subTopics[i].id = arr[i]["subtopic_id"].Value;
            subTopics[i].name = arr[i]["subtopic_name"].Value;
        }
        return subTopics;
    }
}


