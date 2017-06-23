using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class TextureDownload : MonoBehaviour
{

    private Image image;
    private Sprite sprite;

    void Start()
    {
        StartCoroutine(GetTexture());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetTexture()
    {
        if (gameObject.name == "")
            yield break;
        UnityWebRequest www = UnityWebRequest.GetTexture("http://" + gameObject.name);
        yield return www.Send();

        if (www.isError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            sprite = CreateSprite(myTexture);
            GetComponent<Image>().overrideSprite = sprite;
        }
    }
    private Sprite CreateSprite(Texture2D texture)
    {
        if (texture == null)
            return null;

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}
