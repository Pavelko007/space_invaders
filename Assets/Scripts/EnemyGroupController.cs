using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class EnemyGroupController : MonoBehaviour {
    private float speed = 4;
    private float lastChangeDirTime;

    public static EnemyGroupController Instance;

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
	void Start () {
	    lastChangeDirTime = Time.time;
    }

    public void ChangeDir()
    {
        if((Time.time - lastChangeDirTime) < 0.1f ) return;
        lastChangeDirTime = Time.time;
        speed = -speed;
        speed *= 1.1f;
        transform.Translate(Vector3.down*.25f);
    }

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right*speed*Time.deltaTime);
	}
}
