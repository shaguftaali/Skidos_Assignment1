using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    TMP_Dropdown subTopic;

    Level level;
    bool enable;
    

    public void SetData(Level level, TMP_Dropdown subTopic,int levelIndex)
    {
        this.level = level;
        this.subTopic= subTopic;
        text.text = "Level"+levelIndex;
        SetSubtopic();
    }

    void SetSubtopic()
    {
        subTopic.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (SubTopics sub in level.subTopics)
        {           
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = sub.name;
            options.Add(option);
        }
        subTopic.AddOptions(options);
    }



    public void OnLevelBtnClicked()
    {
        enable = !enable;        
        subTopic.gameObject.SetActive(enable);
    }

    
    
}
