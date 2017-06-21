using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class AudioRegister : MonoBehaviour
{
    public Image recordBar;
    public Image maxRecordBar;

    public int maxTime;

    private AudioClip clip;
    private Button button;
    private ColorBlock defaultColors;
    private ColorBlock pressedColors;

    string[] microphones;

    private float t;
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
        if (Microphone.IsRecording(microphones[0]))
        {
            t += Time.deltaTime;
            recordBar.fillAmount = t / maxTime;
            if (t >= maxTime)
            {
                StopRegisterAudio();
                t = 0f;
            }
        }
    }
    private void StartRegisterAudio()
    {
        t = 0f;
        clip = Microphone.Start(microphones[0], false, maxTime, 22050);
        button.colors = pressedColors;
        recordBar.gameObject.SetActive(true);
        maxRecordBar.gameObject.SetActive(true);
    }
    private void StopRegisterAudio()
    {
        if (Microphone.IsRecording(microphones[0]))
            Microphone.End(microphones[0]);

        button.colors = defaultColors;
        GetComponent<SendAudio>().SetAudioClip(clip);
    }
    public void HandleAudio()
    {
        if (Microphone.IsRecording(microphones[0]))
            StopRegisterAudio();
        else
            StartRegisterAudio();
    }
    public void DisableBar()
    {
        recordBar.fillAmount = 0f;
        recordBar.gameObject.SetActive(false);
        maxRecordBar.gameObject.SetActive(false);
        button.colors = defaultColors;
    }
}
