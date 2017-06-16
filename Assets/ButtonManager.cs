using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    enum Code : byte { Zero = 0, First = 1, Second = 2, Third = 3};

    private string deviceName;

    private int buttonClicked;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Button0()
    {
        buttonClicked = (int)Code.Zero;
        Debug.Log("Button " + buttonClicked + "NamePlayer " + GameObject.Find("Bar0").transform.Find("NamePlayer").GetComponent<Text>().text);
    }

    public void Button1()
    {
        buttonClicked = (int)Code.First;
        Debug.Log("Button " + buttonClicked + "NamePlayer " + GameObject.Find("Bar1").transform.Find("NamePlayer").GetComponent<Text>().text);
    }
}
