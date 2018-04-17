using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shot;

    public Transform shotSpawn;

	// Use this for initialization
	void Start () {
	    if (GameContoller.Instance.isGamePlaying)
	    {
	        StartShooting();
	    }
        GameContoller.Instance.onGamePause.AddListener(() =>
        {
            CancelInvoke("Shoot");
        });
        GameContoller.Instance.onGameResume.AddListener(() =>
        {
            StartShooting();
        });
	}

    private void StartShooting()
    {
        InvokeRepeating("Shoot", 0, 2);
    }

    // Update is called once per frame
	void Shoot()
    {
        Instantiate(shot, shotSpawn.position, Quaternion.identity);
    }
}
