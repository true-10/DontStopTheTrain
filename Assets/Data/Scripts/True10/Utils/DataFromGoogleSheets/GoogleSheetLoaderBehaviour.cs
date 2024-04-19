using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class GoogleSheetLoaderBehaviour : MonoBehaviour
{
 //   [SerializeField] private StaticDataSO staticData;
 /*
    private string URL;

    public void LoadFromSheet()
    {
        URL = staticData.URL;
        StartCoroutine(LoadDataCoroutine());
    }

    protected IEnumerator LoadDataCoroutine()
    {
        if (string.IsNullOrEmpty(URL))
        {
           // debugString = "string.IsNullOrEmpty(URL) == true";
            Debug.Log($"GoogleSheetLoader: LoadData() ERROR: string.IsNullOrEmpty(URL) == true");
        }
        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest();
        if (www.isHttpError || www.isNetworkError)
        {
            //debugString = www.error;
            Debug.Log($"GoogleSheetLoader: LoadData() ERROR: {www.error}");
        }
        else
        {
            string json = www.downloadHandler.text;
            // debugString = json;
            Debug.Log($"GoogleSheetLoader: LoadData() success: {json}");
            staticData.jsonNode = JSON.Parse(json);
        }
    }*/
}
