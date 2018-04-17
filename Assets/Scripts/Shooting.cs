using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shot;

    public Transform shotSpawn;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Shoot", 0, 2);
	}
	
	// Update is called once per frame
	void Shoot()
    {
        Instantiate(shot, shotSpawn.position, Quaternion.identity);
    }
}
