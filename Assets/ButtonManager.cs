using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class ButtonManager : MonoBehaviour {

    enum Code : byte { Zero = 0, First = 1, Second = 2, Third = 3};

    private string deviceName;

    private Button button;

    UnityWebRequest request;

    AsyncOperation operation;

    private string url;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => { SendPacket(); });       
    }

    // Use this for initialization
    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {

    }


    public void SendPacket()
    {      
        if(button.name == "Button")
        {
            //Send(0, namePlayerText, SystemInfo.deviceUniqueIdentifier);
            Debug.Log("Sending: Code " + "0 " + "-  " + button.transform.parent.Find("NamePlayer").GetComponent<Text>().text + " " + SystemInfo.deviceUniqueIdentifier);     
        }
        else if(button.name == "Button (1)")
        {
            //Send(1, namePlayerText, SystemInfo.deviceUniqueIdentifier);
            Debug.Log("Sending: Code " + "1 " + "- " + button.transform.parent.Find("NamePlayer").GetComponent<Text>().text + " " + SystemInfo.deviceUniqueIdentifier);
        }
        else if(button.name == "Button (2)")
        {
            //Send(2, namePlayerText, SystemInfo.deviceUniqueIdentifier);
            Debug.Log("Sending: Code " + "2 " + "- " + button.transform.parent.Find("NamePlayer").GetComponent<Text>().text + " " + SystemInfo.deviceUniqueIdentifier);
        }
        else if(button.name == "Button (3)")
        {
            //Send(3, namePlayerText, SystemInfo.deviceUniqueIdentifier);
            Debug.Log("Sending: Code " + "3 " + "- " + button.transform.parent.Find("NamePlayer").GetComponent<Text>().text + " " + SystemInfo.deviceUniqueIdentifier);
        }     
    }

    private void Send(byte code, string nickname, string Id)
    {
        float[] array = new float[code + nickname.Length + Id.Length];
      
        byte[] packet = new byte[array.Length * sizeof(float)];
        Buffer.BlockCopy(array, 0, packet, 0, array.Length);
        string formData = BitConverter.ToString(packet);
        request = UnityWebRequest.Post(url + code + "?nickname=" + nickname + "?mobile_id=" + SystemInfo.deviceUniqueIdentifier, formData);
        UploadHandlerRaw upHandler = new UploadHandlerRaw(packet);
        upHandler.contentType = "Application/octet-stream";
        request.uploadHandler = upHandler;
        operation = request.Send();

        Debug.Log("Sended");
    }
}
