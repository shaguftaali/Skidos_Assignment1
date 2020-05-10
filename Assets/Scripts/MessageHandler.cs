using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageHandler : MonoBehaviour
{
  
    private static MessageHandler instance;

    // Game Instance Singleton
    public static MessageHandler Instance
    {
        get
        {
            return instance;
        }
    }

   

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;     
        DontDestroyOnLoad(this.gameObject);
    }

  

    // Update is called once per frame
    public bool SendData(string data)
    {      
        bool fail = false;
        string bunleId = "com.shag.Shagufta_Skidos_Assignment2";
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageManager=null;
        if (currentActivity!=null)
        {
            packageManager = currentActivity.Call<AndroidJavaObject>("getPackageManager");
        }

        AndroidJavaObject launchIntent = null;

        try
        {
            launchIntent = packageManager.Call<AndroidJavaObject>("getLaunchIntentForPackage", bunleId);
        }
        catch(System.Exception e)
        {
            fail = true;
        }      
        if (!fail)
        {
            string stringToSend = data;//"NewText : "+count;
            launchIntent.Call<AndroidJavaObject>("putExtra", "arg1", stringToSend);
            currentActivity.Call("startActivity", launchIntent);


            unityPlayer.Dispose();
            currentActivity.Dispose();
            packageManager.Dispose();
            launchIntent.Dispose();
        }

        return !fail;
       
    }

}
