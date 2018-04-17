using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipController : MonoBehaviour
{
    private Vector3 targetPos;

    void Start()
    {
        GameContoller.Instance.NumMotherships++;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = Vector3.MoveTowards(transform.position, targetPos, 2 * Time.deltaTime);
	    if (transform.position == targetPos)
	    {
	        Destroy(gameObject);
	    }
	}

    void OnDestroy()
    {
        GameContoller.Instance.NumMotherships--;
    }

    public void SetTarget(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }
}
