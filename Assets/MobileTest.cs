﻿using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.EventSystems;
using System;

public class MobileTest : MonoBehaviour
{
    UnityWebRequest Request;
    AsyncOperation asyncOp;
  
    private string json { get; set; }
    public GameObject barPrefab;
    private Dictionary<string, string> DesJson;
    private List<GameObject> barPrefabs;

    private List<Text> texts;
    private List<string> nicknames;
    private List<string> urls;
    private List<Image> images;

    // Use this for initialization
    void Start()
    {                
        Request = UnityWebRequest.Get("http://taiga.aiv01.it/mobile/match/participants/");
        asyncOp = Request.Send();

        barPrefabs = new List<GameObject>();
        texts = new List<Text>();
        nicknames = new List<string>();
        urls = new List<string>();
        images = new List<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (asyncOp != null && asyncOp.isDone)
        {         
            if (Request.responseCode == 200)
            {             
                json = Encoding.UTF8.GetString(Request.downloadHandler.data);
                DesJson = (Dictionary<string,string>)JsonConvert.DeserializeObject(json, typeof(Dictionary<string,string>));

                if (DesJson.Count == 0)
                {
                    Debug.Log("No Players Connected");
                    return;
                }                         
            }
            BarPrefabMethods();
        }        
    }

    private void BarPrefabMethods()
    {
        InstatiatePrefabForEachPlayer();

        foreach (string username in DesJson.Keys)
            nicknames.Add(username);
        foreach (string url in DesJson.Values)
            urls.Add(url);

        //For each prefab text print player name
        int t = 0;
        foreach(Text text in texts)
        {
            if (t >= texts.Count)
                return;

            t++;
            text.text = nicknames[t - 1];                                
        }
  
        //For each prefab image print player photo
        int b = 0;
        foreach(Image image in images)
        {
            if (b >= urls.Count)
                return;

            b++;
            image.name = urls[b - 1];
        }
    }
    private void InstatiatePrefabForEachPlayer()
    {
        for (int i = 0; i < DesJson.Count; i++)
        {
            for (int j = 0; j < barPrefabs.Count; j++)
            {
                if (j >= i)
                    return;
            }

            GameObject bar = Instantiate(barPrefab, GameObject.Find("Canvas").transform);
            bar.name = "Bar" + i;
            barPrefabs.Add(bar);

            foreach (GameObject prefab in barPrefabs)
            {
                prefab.transform.localPosition += new Vector3(0, 50, 0);
            }
        }

        foreach (GameObject prefab in barPrefabs)
        {
            Text NamePlayer = prefab.transform.Find("NamePlayer").GetComponent<Text>();
            texts.Add(NamePlayer);

            Image image = prefab.transform.Find("Image").GetComponent<Image>();
            images.Add(image);
        }
    }
}       

  

