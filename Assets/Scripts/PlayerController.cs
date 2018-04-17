using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        Instantiate(shot, shotSpawn.position, Quaternion.identity);
	    }

	    var hor = Input.GetAxis("Horizontal");
	    if (hor != 0)
	    {
	        Vector3 dir = Vector3.zero;
	        if (hor > 0)
	        {
	            dir = Vector3.right;
	        }
            else if (hor < 0)
	        {
	            dir = Vector3.left;
	        }

            transform.Translate(dir*10*Time.deltaTime);
	    }
	}


}
