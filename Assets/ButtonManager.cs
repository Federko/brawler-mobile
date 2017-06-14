using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    private byte[] Action;

    private byte[] packet;

    private string deviceName;


	// Use this for initialization
	void Start () {
        Action = new byte[] { 0, 1, 2, 3 };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
