using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaitingBehaviour : MonoBehaviour
{
    public float waitingTime;

    public Image[] images;
    public Button[] buttons;

    private float t;
    // Use this for initialization
    void Start()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        for (int i = 0; i < images.Length; i++)
        {
            images[i].fillAmount = t / waitingTime;
        }

        if (t >= waitingTime)
        {
            t = 0f;
            enabled = false;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = true;
            }
        }
    }
    public void Enable()
    {
        enabled = true;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }
}
