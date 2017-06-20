using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContentBehaviour : MonoBehaviour
{
    public GameObject panelPrefab;
    private RectTransform rectTransform;

    // Use this for initialization
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            AddMatch();
    }

    public void AddMatch()
    {
        GameObject panelMatch = GameObject.Instantiate<GameObject>(panelPrefab);
        panelMatch.transform.SetParent(transform);
        panelMatch.transform.localScale = Vector3.one;
        if (transform.childCount % 2 != 0)
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectTransform.sizeDelta.y + 220f);
    }
    public void ChangeScene()
    {
       SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }
}
