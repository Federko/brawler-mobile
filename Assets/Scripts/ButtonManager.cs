using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ButtonManager : MonoBehaviour
{
    public int code;
    public Text text;
    public class JsonData
    {
        public int code;
        public string nickname;
        public string id;
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
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private JsonData CreateJson(int code, string nickname, string id)
    {
        SerJson = new JsonData();
        this.SerJson.code = code;
        this.SerJson.nickname = nickname;
        this.SerJson.id = id;
        return SerJson;
    }

    public void SendPacket()
    {    
                json = JsonConvert.SerializeObject(CreateJson(code, text.text, deviceName));
                Send(json);
                Debug.Log(json);
    }

    private void Send(string json)
    {  
        request = UnityWebRequest.Post(url, json);
        operation = request.Send();

        Debug.Log("Sended");
    }
}


