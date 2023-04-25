using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APICaller : MonoBehaviour
{
    public string rapidApiKey = "1a4afb2dc0msh8e27f4f50730a7ap1f3a25jsn1200099eeb6a";
    public string apiUrl = "https://mobile-legends-character-api.p.rapidapi.com/api/characters/list";

    // Start is called before the first frame update
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        request.SetRequestHeader("x-rapidapi-host", "mobile-legends-character-api.p.rapidapi.com");
        request.SetRequestHeader("x-rapidapi-key", rapidApiKey);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            yield break;
        }

        string responseJSON = request.downloadHandler.text;
        SimpleJSON.JSONNode results = SimpleJSON.JSONNode.Parse(responseJSON);
        Debug.Log(results);
    }
}
