using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    public float scoreForKill;
	
	// Update is called once per frame
    public void UpdateScore ()
	{
	    GameContoller.Instance.AddScore(scoreForKill);
	}
}
