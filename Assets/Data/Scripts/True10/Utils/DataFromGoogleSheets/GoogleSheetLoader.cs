using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEditor;

namespace True10.Utils
{ 

    public class GoogleSheetLoader : ScriptableObject
    {
        #region fields
        [Header("GoogleSheetLoader: URL")]
        [SerializeField] private string url;
        public string URL => url;
        #endregion

        #region fields
        public string debugString;
        public JSONNode jsonNode;
        #endregion


        [ContextMenu("Load Data From Sheet")]
        public void LoadFromSheet()
        {
            // LoadData();
             //StartCoroutine(LoadData());
        //     EditorUtility.SetDirty(this);
        }
      /*  protected IEnumerator LoadDataCoroutine()
        {
            if (string.IsNullOrEmpty(URL))
            {
                debugString = "string.IsNullOrEmpty(URL) == true";
                Debug.Log($"GoogleSheetLoader: LoadData() ERROR: string.IsNullOrEmpty(URL) == true");
            }
            UnityWebRequest www = UnityWebRequest.Get(URL);

            yield return www.SendWebRequest();
            if (www.isHttpError || www.isNetworkError)
            {
                debugString = www.error;
                Debug.Log($"GoogleSheetLoader: LoadData() ERROR: {www.error}");
            }
            else
            {
                string json = www.downloadHandler.text;
                debugString = json;
                jsonNode = JSON.Parse(json);
            }
        }*/
    }
}