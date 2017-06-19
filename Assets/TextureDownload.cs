using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureDownload : MonoBehaviour {

    public string urlPng;
  
    private Image image;
    private Sprite sprite;

  
	// Update is called once per frame
	void Update () {
       
    }

    IEnumerator Start()
    {  
        WWW www = new WWW(gameObject.name);
        yield return www;
     
        if(www.texture != null)
        {        
            sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0 ,0));  
             GetComponent<Image>().overrideSprite = sprite;            
        }     
    }
}
