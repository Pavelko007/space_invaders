using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;

	
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            OnEnemyContact();
        }

        if (other.gameObject.CompareTag("EnemyShot"))
        {
            OnPlayerHit();
        }
    }

    private void OnPlayerHit()
    {
        Destroy(gameObject);
        GameContoller.Instance.OnPlayerHit();
    }

    private void OnEnemyContact()
    {
        Destroy(gameObject);
        GameContoller.Instance.GameOver(false);
    }
}
