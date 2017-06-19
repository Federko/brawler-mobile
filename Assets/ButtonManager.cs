using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonManager : MonoBehaviour {

    enum Code : byte { Zero = 0, First = 1, Second = 2, Third = 3};

    private string deviceName;

    private Button button;

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
            Debug.Log("Code " + "0 " + "-  " + button.transform.parent.Find("NamePlayer").GetComponent<Text>().text
                       + " " + SystemInfo.deviceUniqueIdentifier); 
        }
        else if(button.name == "Button (1)")
        {
            Debug.Log("Code " + "1 " + "- " + button.transform.parent.Find("NamePlayer").GetComponent<Text>().text
                      + " " + SystemInfo.deviceUniqueIdentifier);
        }
        else if(button.name == "Button (2)")
        {
            Debug.Log("Code " + "2 " + "- " + button.transform.parent.Find("NamePlayer").GetComponent<Text>().text
                     + " " + SystemInfo.deviceUniqueIdentifier);
        }
        else if(button.name == "Button (3)")
        {
            Debug.Log("Code " + "3 " + "- " + button.transform.parent.Find("NamePlayer").GetComponent<Text>().text
                     + " " + SystemInfo.deviceUniqueIdentifier);
        }     
    }
}
