using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;

public class MobileTest : MonoBehaviour
{
    private class IpifyResponse
    {
        public List<string> participants;
        public string error;
    }

    UnityWebRequest Request;
    AsyncOperation asyncOp;
    public static string DeviceUniqueIdentifier;
    public Text text;
    // Use this for initialization
    void Start()
    {
        DeviceUniqueIdentifier = SystemInfo.deviceName;
        text = GetComponentInChildren<Text>();
        Request = UnityWebRequest.Get("http://taiga.aiv01.it/mobile/match/participants/");
        asyncOp = Request.Send();
    }

    // Update is called once per frame
    void Update()
    {
        if (asyncOp != null && asyncOp.isDone)
        {
            if (Request.responseCode == 200)
            {
                text.text = DeviceUniqueIdentifier +"\n";
                //    text.text = name +"\n";
                //    Debug.Log("Message sent with" + Request.responseCode);
                //    string rawJson = Encoding.UTF8.GetString(Request.downloadHandler.data);
                //    IpifyResponse response = JsonUtility.FromJson<IpifyResponse>(rawJson);
                //    Debug.Log(rawJson);
                //    if (response.error != "")
                //    {
                //        text.text = response.error;
                //    }
                //    if (response.participants != null)
                //    {
                //        foreach (string participant in response.participants)
                //        {

                //            text.text += participant + "\n";
                //        }

                //    }
                //    asyncOp = null;
            }
            //else
            //{
            //    GetComponent<Text>().text = "ERRORE" + Request.responseCode.ToString();
            //}
        }
    }
}
