using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    // Use this for initialization

    void Start ()
    {
        GameContoller.Instance.NumEnemies++;
    }

    void OnDestroy()
    {
        GameContoller.Instance.NumEnemies--;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Destroy(gameObject);
        }    
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            EnemyGroupController.Instance.ChangeDir();
        }
    }
}
