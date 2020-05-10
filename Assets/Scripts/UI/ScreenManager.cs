using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ScreenType
{
    MainScreen,
    DataStoreScreen,
    DataScreen
}

public class ScreenManager : MonoBehaviour
{
    [SerializeField]
    GameObject mainScreen;

    [SerializeField]
    GameObject dataStoreScreen;

    [SerializeField]
    GameObject dataScreen;

    [SerializeField]
    TMP_InputField keyInput;

    [SerializeField]
    TMP_InputField valueInput;

    [SerializeField]
    TMP_Text msgText;

    private static ScreenManager instance = null;
   
   
    public static ScreenManager Instance
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

        DontDestroyOnLoad(this.gameObject);
    }

    //public void OnUIBtnClicked(ScreenType screen,string btnName)
    //{
    //    switch (screen)
    //    {
    //        case ScreenType.MainScreen:
    //            OnMainScreenBtnClicked(btnName);
    //            break;
    //    }
    //}

    public void OnUIBtnClicked( string btnName)
    {
        if (btnName == "FetchBtn")
        {
            if (DataManager.Instance.isDataLoaded)
            {
                mainScreen.SetActive(false);
                dataScreen.SetActive(true);
            }
        }
        else if (btnName == "DataSendBtn")
        {
            mainScreen.SetActive(false);
            dataStoreScreen.SetActive(true);
        }
       
        else if (btnName == "SaveData")
        {
            string qt = "\"";
            string key = qt + "key" + qt + ":" + qt + keyInput.text + qt;
            string value = qt + "value" + qt + ":" + qt + valueInput.text + qt;
            string msg = "{" + key + "," + value + "}";
            Debug.Log(msg);
            bool sent=MessageHandler.Instance.SendData(msg);
            msgText.text = "Msg Send : " + sent;
        }
        else if (btnName == "SaveDataBackBtn")
        {
            mainScreen.SetActive(true);
            dataStoreScreen.SetActive(false);
        }
        else if(btnName== "OperationBcakBtn")
        {
            dataScreen.SetActive(false);
            mainScreen.SetActive(true);
        }
    }

    
}
