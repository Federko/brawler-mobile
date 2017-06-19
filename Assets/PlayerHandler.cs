using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public GameObject playerPrefab;
    public Text PlayersNumber;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            IstantiatePlayer(playerPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            IstantiatePlayer(playerPrefab);
    }
    void IstantiatePlayer(GameObject playerPrefab)
    {
        GameObject player = GameObject.Instantiate<GameObject>(playerPrefab);
        player.transform.SetParent(transform);
        player.transform.localScale = Vector3.one;
        PlayersNumber.text = "Players:\n" + transform.childCount + "/8";
    }
}
