using System.Collections;
using System.Collections.Generic;
using System.IO;
//using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleDocsRequestTsvImport : MonoBehaviour
{
 //   public static string RequestUrl = "https://script.google.com/macros/s/AKfycbwrvguetRH2hS27Z1XFquf-nJQqPO0NMKKPa56B08cdRoiufDs/exec";
    public static string RequestUrl = "https://spreadsheets.google.com/feeds/list/1njBbgmaHcCD4zANvKNu9eNl7mLixd056I9r6Pjxjndg/od6/public/values?alt=json";

    //[MenuItem("True10/Google Docs Load")]
    static void Do()
    {
      //  EditorCoroutineUtility.StartCoroutineOwnerless(MainAction());
    }
    /*
    static IEnumerator MainAction()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(RequestUrl))
        {
            webRequest.timeout = 30;
            webRequest.SendWebRequest();


            Debug.LogWarning("Делаем запрос:");

            while (!webRequest.isDone)
            {
                yield return null;
            }


            if (webRequest.isNetworkError)
            {
                EditorUtility.DisplayDialog("Загрузка языков", "Ошибка:" + webRequest.error, "ой");
                yield break;
            }

            string result = webRequest.downloadHandler.text;

            var data = SimpleJSON.JSON.Parse(result);


            foreach (var langitems in data.Linq)
            {
                File.WriteAllText(Application.dataPath + "/Data/Resources/localization/" + langitems.Key, langitems.Value.ToString(1));
            }

            EditorUtility.DisplayDialog("Загрузка языков", "Успех", "ок");
        }
    }*/
}
