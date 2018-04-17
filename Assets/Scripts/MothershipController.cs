using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipController : MonoBehaviour
{
    private Vector3 targetPos;

    void Start()
    {
        GameContoller.Instance.NumEnemies++;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (!GameContoller.Instance.isGamePlaying) return;

	    transform.position = Vector3.MoveTowards(transform.position, targetPos, 2 * Time.deltaTime);

	    if (transform.position == targetPos)
	    {
	        Destroy(gameObject);
	    }

	    if (Input.GetKeyDown(KeyCode.K))
	    {
	        Destroy(gameObject);
	    }
    }

    void OnDestroy()
    {
        GameContoller.Instance.NumEnemies--;
    }

    public void SetTarget(Vector3 targetPos)
    {
        this.targetPos = targetPos;
    }
}
