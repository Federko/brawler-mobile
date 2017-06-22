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
    // Use this for initialization
    void Start()
    {

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

        //request = UnityWebRequest.Post(url, message);
        //op = request.Send();
    }
    public void OpenWindow()
    {
        gameObject.SetActive(true);
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
    public void ManageWindow()
    {
        if (gameObject.activeInHierarchy)
            CloseWindow();
        else
            OpenWindow();
    }
}
