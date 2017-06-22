using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendAudio : MonoBehaviour
{
    private UnityWebRequest request;
    private AsyncOperation operation;

    private AudioClip clip;

    private string url;
    // Use this for initialization
    void Start()
    {
        url = "http://taiga.aiv01.it/mobile/match/audio/";
    }

    // Update is called once per frame
    void Update()
    {
        if (operation != null && operation.isDone)
        {
            JsonResponse response = JsonUtility.FromJson<JsonResponse>(request.downloadHandler.text);

            if (response.mobile_upload_audio)
                Debug.Log("Uploaded");
            else
                Debug.Log("upload failed");
        }
    }
    public void SendAudioToServer()
    {
        if (clip == null)
        {
            Debug.Log("Nothing to send!");
            return;
        }

        float[] array = new float[clip.channels * clip.samples];
        if (clip.GetData(array, 0))
        {
            byte[] rawAudio = new byte[array.Length * sizeof(float)];
            Buffer.BlockCopy(array, 0, rawAudio, 0, array.Length);
            string formData = BitConverter.ToString(rawAudio);
            Debug.Log(formData);
            request = UnityWebRequest.Post(url + "?mobile_id=" + SystemInfo.deviceUniqueIdentifier, formData);
            UploadHandlerRaw upHandler = new UploadHandlerRaw(rawAudio);
            upHandler.contentType = "application/octet-stream";
            request.uploadHandler = upHandler;
            operation = request.Send();
            clip = null;
            return;
        }
        Debug.Log("ERROR! IMPOSSIBLE GET RAW AUDIO");
    }
    public class JsonResponse
    {
        public bool mobile_upload_audio;
    }
    public void SetAudioClip(AudioClip clip)
    {
        this.clip = clip;
    }
}
