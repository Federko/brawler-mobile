using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioRegister : MonoBehaviour
{
    public AudioSource audio;

    private AudioClip clip;
    private Button button;
    ColorBlock defaultColors;
    ColorBlock pressedColors;

    string[] microphones;
    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        defaultColors = button.colors;
        pressedColors = ColorBlock.defaultColorBlock;
        pressedColors.normalColor = defaultColors.pressedColor;
        pressedColors.highlightedColor = defaultColors.pressedColor;
        pressedColors.pressedColor = defaultColors.normalColor;

        microphones = Microphone.devices;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void RegisterAudio()
    {
        clip = Microphone.Start(microphones[0], false, 10, 44100);
        button.colors = pressedColors;      
    }
    private void StopRegisterAudio()
    {
        Microphone.End(microphones[0]);
        button.colors = defaultColors;
        audio.clip = clip;
    }
    public void HandleAudio()
    {
        if (Microphone.IsRecording(microphones[0]))
            StopRegisterAudio();
        else
            RegisterAudio();
    }
}
