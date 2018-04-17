using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform playerSpawnPos;

	void Start ()
	{
	    Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
