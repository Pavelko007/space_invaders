using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShotController : MonoBehaviour {

    public string KillableTag = "Enemy";
    public Vector3 moveDir = Vector3.up;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.Translate(moveDir * 10*Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(KillableTag))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
