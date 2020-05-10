using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIObjectPool : MonoBehaviour
{
    public LevelUI levelUIPrefab;
    //public SubtopicUI subTopicPrefab;
    public TMP_Dropdown subTopicPrefab;



    private List<LevelUI> activeLevelUIPool;
    private List<LevelUI> inactiveLevelUIPool;

    private List<TMP_Dropdown> activeSubTopicUIPool;
    private List<TMP_Dropdown> inactiveSubTopicUIPool;

    private static UIObjectPool instance = null;

    // Game Instance Singleton
    public static UIObjectPool Instance
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
        activeLevelUIPool = new List<LevelUI>();
        inactiveLevelUIPool = new List<LevelUI>();

        inactiveSubTopicUIPool = new List<TMP_Dropdown>();
        activeSubTopicUIPool = new List<TMP_Dropdown>();

        DontDestroyOnLoad(this.gameObject);
    }

    public LevelUI PullLevelUI()
    {
        LevelUI levelUI;
        if (inactiveLevelUIPool.Count > 0)
        {
            levelUI= inactiveLevelUIPool[0];
            levelUI.gameObject.SetActive(true);
            inactiveLevelUIPool.RemoveAt(0);
            activeLevelUIPool.Add(levelUI);
            return levelUI;
        }
        levelUI= (LevelUI)Instantiate(levelUIPrefab);
        levelUI.gameObject.SetActive(true);
        activeLevelUIPool.Add(levelUI);
        return levelUI;
    }

    public void PushLevelUI(LevelUI levelUI)
    {
        levelUI.gameObject.SetActive(false);
        activeLevelUIPool.Remove(levelUI);
        inactiveLevelUIPool.Add(levelUI);
    }


    public TMP_Dropdown PullSubTopicUI()
    {
        TMP_Dropdown subtopicUI;
        //Debug.Log("count in pool : "+inactiveLevelUIPool)
        if (inactiveLevelUIPool.Count > 0)
        {
            subtopicUI = inactiveSubTopicUIPool[0];
            subtopicUI.gameObject.SetActive(true);
            inactiveSubTopicUIPool.RemoveAt(0);
            activeSubTopicUIPool.Add(subtopicUI);
            return subtopicUI;
        }
        subtopicUI = (TMP_Dropdown)Instantiate(subTopicPrefab);
        subtopicUI.gameObject.SetActive(true);
        activeSubTopicUIPool.Add(subtopicUI);
        return subtopicUI;
    }

    public void PushSubTopicUI(TMP_Dropdown subtopic)
    {
        subtopic.gameObject.SetActive(false);
        activeSubTopicUIPool.Remove(subtopic);
        inactiveSubTopicUIPool.Add(subtopic);
    }

    public void Clear()
    {
        foreach (TMP_Dropdown sub in activeSubTopicUIPool)
        {
            sub.gameObject.SetActive(false);
            inactiveSubTopicUIPool.Add(sub);
        }
        activeSubTopicUIPool.Clear();

        foreach (LevelUI lev in activeLevelUIPool)
        {
            lev.gameObject.SetActive(false);
            inactiveLevelUIPool.Add(lev);
        }
        activeLevelUIPool.Clear();
    }
}
