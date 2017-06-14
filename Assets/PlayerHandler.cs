using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour {
    public GameObject playerPrefab;
    List<GameObject> players;

	// Use this for initialization
	void Start () {
        players = new List<GameObject>();
        IstantiatePlayer(playerPrefab);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
            IstantiatePlayer(playerPrefab);
	}
    void IstantiatePlayer(GameObject playerPrefab)
    {
        GameObject player = GameObject.Instantiate<GameObject>(playerPrefab);
        player.GetComponent<LayoutElement>().preferredHeight = Screen.height * 0.15f;
        player.GetComponent<LayoutElement>().preferredWidth = Screen.width;
        player.transform.SetParent(transform);
        players.Add(player);
    }
}
