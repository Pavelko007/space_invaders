using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
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
