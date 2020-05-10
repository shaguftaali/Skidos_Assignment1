using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelScreen : MonoBehaviour
{
    UIObjectPool objectPool;

    [SerializeField]
    Transform content;

    [SerializeField]
    TMP_Text headingText;

    [SerializeField]
    GameObject optionScreen;

    public void SetDataOnScreen(Operation operation)
    {
        int index = 0;
        if (null == objectPool) { objectPool = UIObjectPool.Instance; }
        objectPool.Clear();
        foreach(Level lev in operation.level)
        {
            SetLevelUI(lev,index);
            index++;
        }
        headingText.text = operation.name;
        gameObject.SetActive(true);
        
    }

    void SetLevelUI(Level level,int index)
    {
        TMP_Dropdown subTopic = objectPool.PullSubTopicUI();
        LevelUI levUI = objectPool.PullLevelUI();
        levUI.SetData(level,subTopic,index);
        levUI.transform.SetParent(content);
        subTopic.transform.SetParent(content);
        subTopic.gameObject.SetActive(false);       
        
    }

    public void OnBackBtnClick()
    {
        objectPool.Clear();
        gameObject.SetActive(false);
        optionScreen.SetActive(true);
    }


}
