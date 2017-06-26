using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public int code;
    public Text text;

    private Dictionary<string, string> values;
    public class JsonData
    {
        public Dictionary<string, string> values;
        public JsonData(int code, string nick, string id)
        {
            values = new Dictionary<string, string>();
            values.Add("empower_type", code.ToString());
            values.Add("nickname", nick);
            values.Add("mobile_id", id);
        }
    }
    public class JsonResponse
    {
        public bool send_empower;
    }

    private string deviceName;

    private Button button;

    UnityWebRequest request;

    AsyncOperation operation;

    private JsonData SerJson;

    private string json;

    private string url;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { SendPacket(); });
        deviceName = SystemInfo.deviceUniqueIdentifier;
        url = "http://taiga.aiv01.it/mobile/match/send-empower/";
        values = new Dictionary<string, string>();
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (operation != null && operation.isDone)
        {
            if (request.isError)
                Debug.Log(request.error);
            else
            {
                JsonResponse response = JsonUtility.FromJson<JsonResponse>(request.downloadHandler.text);
            }
        }

    }
    private JsonData CreateJson(int code, string nickname, string id)
    {
        SerJson = new JsonData(code, nickname, id);
        return SerJson;
    }

    public void SendPacket()
    {
        //json = JsonConvert.SerializeObject(CreateJson(code, text.text, deviceName));
        Send();
       // Debug.Log(json);
    }

    private void Send()
    {
        values.Clear();
        values.Add("empower_type", code.ToString());
        values.Add("nickname", text.text);
        values.Add("mobile_id", deviceName);

        request = UnityWebRequest.Post(url,values);
        operation = request.Send();

        Debug.Log("Sended");
    }
}


