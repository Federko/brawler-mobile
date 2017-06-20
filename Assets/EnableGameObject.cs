using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObject : MonoBehaviour
{
    public GameObject target;

    public void Enable()
    {
        if (target.activeInHierarchy)
            target.SetActive(false);
        else
            target.SetActive(true);
    }
}
