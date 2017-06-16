using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
    private AudioSource audio;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayAudio()
    {
        if(audio.clip!=null)
        {
            audio.Play();
        }
    }
}
