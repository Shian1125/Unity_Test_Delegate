using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CoroutineCallback : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LoadImage();
		/*
			result:

			loading...
			this is callback: download complete!!  ya~
		
		 */
	}
	
    //Coroutine callback simple, url: https://photo.lovingfamily.com.tw/photo/images/170427_%E6%96%B0%E5%93%8185%E6%8A%98_%E6%8F%92%E7%95%AB%E5%AE%B6_1000.jpg
    void LoadImage()
    {
        string url = "https://photo.lovingfamily.com.tw/photo/images/170427_%E6%96%B0%E5%93%8185%E6%8A%98_%E6%8F%92%E7%95%AB%E5%AE%B6_1000.jpg";
        StartCoroutine(GetImageFromURL(url, (string str, string str2) =>
        {
            Debug.Log("this is callback: " + str + str2);
        }
        ));
    }

	IEnumerator GetImageFromURL(string url, Action<string, string> CallBack)
    {
        WWW www = new WWW(url);
        Debug.Log("loading...");
        yield return www;
        if (CallBack != null && string.IsNullOrEmpty(www.error))
			CallBack("download complete!! ", " ya~");      //下載完後執行callback
    }
}
