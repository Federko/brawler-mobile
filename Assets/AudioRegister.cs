using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;

public class AudioRegister : MonoBehaviour
{
    public AudioSource audio;

    private AudioClip clip;
    private Button button;
    ColorBlock defaultColors;
    ColorBlock pressedColors;

    string[] microphones;

    private float t;

    UnityWebRequest request;
    AsyncOperation operation;

    private string url;
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

        url = "http://taiga.aiv01.it/mobile/match/audio/";
    }

    public class JsonResponse
    {
        public bool mobile_upload_audio;
    }

    // Update is called once per frame
    void Update()
    {
        if(operation!=null && operation.isDone)
        {
            JsonResponse response = JsonUtility.FromJson<JsonResponse>(request.downloadHandler.text);

            if (response.mobile_upload_audio)
                Debug.Log("Uploaded");
            else
            Debug.Log("upload failed");
        }
    }
    private void StartRegisterAudio()
    {
        t = 0f;
        clip = Microphone.Start(microphones[0], false, 3, 22050);
        button.colors = pressedColors;
    }
    private void RegisterAudio()
    {
        t += Time.deltaTime;
    }
    private void StopRegisterAudio()
    {
        Microphone.End(microphones[0]);
        button.colors = defaultColors;
        float[] array = new float[clip.channels * clip.samples];
        audio.clip = clip;
        if (clip.GetData(array, 0))
        {
            byte[] rawAudio = new byte[array.Length * sizeof(float)];
            Buffer.BlockCopy(array, 0, rawAudio, 0, array.Length);
            string formData = BitConverter.ToString(rawAudio);
            request = UnityWebRequest.Post(url+"?mobile_id=" + SystemInfo.deviceUniqueIdentifier, formData);
            UploadHandlerRaw upHandler = new UploadHandlerRaw(rawAudio);
            upHandler.contentType = "Application/octet-stream";
            request.uploadHandler = upHandler;
            operation = request.Send();
            return;
        }
        Debug.Log("ERROR! IMPOSSIBLE GET RAW AUDIO");
        
    }
    public void HandleAudio()
    {
        if (Microphone.IsRecording(microphones[0]))
            StopRegisterAudio();
        else
            StartRegisterAudio();
    }
}
