using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipController : MonoBehaviour
{
    private Vector3 targetPos;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = Vector3.MoveTowards(transform.position, targetPos, 4 * Time.deltaTime);
	}

    public void SetTarget(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }
}
