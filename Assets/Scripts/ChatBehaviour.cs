using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChatBehaviour : MonoBehaviour
{
    public InputField inputField;
    private UnityWebRequest request;
    private AsyncOperation op;
    private string url;
    private Dictionary<string, string> data;
    // Use this for initialization
    void Start()
    {
        url = "http://taiga.aiv01.it/mobile/match/send-message/";
        data = new Dictionary<string, string>();
    }
    void Update()
    {
        if (op != null && op.isDone)
        {
            CloseWindow();
        }
    }
    public void SendMessage()
    {
        string message = inputField.text;
        inputField.text = null;
        SetData(SystemInfo.deviceUniqueIdentifier, SystemInfo.deviceName, message);
        request = UnityWebRequest.Post(url, data);
        op = request.Send();
    }
    public void OpenWindow()
    {
        gameObject.SetActive(true);
    }
    public void CloseWindow()
    {
        request = null;
        op = null;
        gameObject.SetActive(false);
    }
    public void ManageWindow()
    {
        if (gameObject.activeInHierarchy)
            CloseWindow();
        else
            OpenWindow();
    }
    private void SetData(string id,string nickname,string text)
    {
        data.Clear();
        data.Add("mobile_id", id);
        data.Add("mobile_name", nickname);
        data.Add("text", text);

    }
}
