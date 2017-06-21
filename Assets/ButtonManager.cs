using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ButtonManager : MonoBehaviour
{
    public class JsonData
    {
        public int buttonId;
        public string nickName;
        public string deviceId;
    }

    enum Code : byte { Zero = 0, First = 1, Second = 2, Third = 3 };

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
    private JsonData InstantiateJson(int id, string nickName, string deviceName)
    {
        SerJson = new JsonData();
        SerJson.buttonId = id;
        SerJson.nickName = nickName;
        SerJson.deviceId = deviceName;
        return SerJson;
    }

    public void SendPacket()
    {
        switch (button.name)
        {
            case "Button":
                json = JsonConvert.SerializeObject(InstantiateJson(0, button.transform.GetComponentInParent<Text>().text, deviceName));
                Send(json);
                Debug.Log("Sending: Code " + "0 " + "-  " + button.transform.GetComponentInParent<Text>().text + " " + deviceName);
                break;
            case "Button (1)":
                json = JsonConvert.SerializeObject(InstantiateJson(1, button.transform.GetComponentInParent<Text>().text, deviceName));
                Send(json);
                Debug.Log("Sending: Code " + "1 " + "- " + button.transform.GetComponentInParent<Text>().text + " " + deviceName);
                break;
            case "Button (2)":
                json = JsonConvert.SerializeObject(InstantiateJson(2, button.transform.GetComponentInParent<Text>().text, deviceName));
                Send(json);
                Debug.Log("Sending: Code " + "2 " + "- " + button.transform.GetComponentInParent<Text>().text + " " + deviceName);
                break;
            case "Button (3)":
                json = JsonConvert.SerializeObject(InstantiateJson(3, button.transform.GetComponentInParent<Text>().text, deviceName));
                Send(json);
                Debug.Log("Sending: Code " + "3 " + "- " + button.transform.GetComponentInParent<Text>().text + " " + deviceName);
                break;
        }
    }

    private void Send(string json)
    {
        string formData = json;
        request = UnityWebRequest.Post(url, formData);
        operation = request.Send();

        Debug.Log("Sended");
    }
}


