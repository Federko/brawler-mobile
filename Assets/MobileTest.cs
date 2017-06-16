using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;


public class MobileTest : MonoBehaviour
{
    UnityWebRequest Request;
    AsyncOperation asyncOp;

    public static string DeviceUniqueIdentifier;
  
    private string json { get; set; }
    public GameObject barPrefab;
    private Dictionary<string, string> DesJson;
    private List<GameObject> barPrefabs;

    private List<Text> texts;
    private List<string> nicknames;

    //Mobile_Name
    //Mobile_ID

    // Use this for initialization
    void Start()
    {
        DeviceUniqueIdentifier = SystemInfo.deviceName; 
          
        Request = UnityWebRequest.Get("http://taiga.aiv01.it/mobile/match/participants/");
        asyncOp = Request.Send();

        barPrefabs = new List<GameObject>();
        texts = new List<Text>();
        nicknames = new List<string>();
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
        }

        foreach (string username in DesJson.Keys)
            nicknames.Add(username);

        int t = 0;
        foreach(Text text in texts)
        {
            if (t >= texts.Count)
                return;

            t++;
            text.text = nicknames[t - 1];                                
        }
    }
}       

  

