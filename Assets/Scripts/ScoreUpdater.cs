using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    public float scoreForKill;
    public GameObject floatingScore;

    // Update is called once per frame
    public void UpdateScore ()
	{
	    GameContoller.Instance.AddScore(scoreForKill);
	    GameObject gameObject = Instantiate(floatingScore, transform.position, Quaternion.identity);
        gameObject.GetComponent<FloatingScoreController>().SetScore((int) scoreForKill);
	    gameObject.transform.position = transform.position;
	}
}
