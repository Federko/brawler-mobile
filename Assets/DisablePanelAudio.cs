using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisablePanelAudio : MonoBehaviour {
    public Image recordBar;
    public Image maxRecordBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DisableWindow()
    {
        recordBar.fillAmount = 0f;
        recordBar.gameObject.SetActive(false);
        maxRecordBar.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
