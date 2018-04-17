using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform playerSpawnPos;

    public Text timerText;

	void Start ()
	{
	    Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);

	    StartCoroutine(Countdown());
	}

    IEnumerator Countdown()
    {
        float timeToStart = 3;
        while (timeToStart > 0)
        {
            timeToStart -= Time.deltaTime;
            timerText.text = ((int)Mathf.Ceil(timeToStart)).ToString();
            yield return new WaitForEndOfFrame();
        }
        timerText.gameObject.SetActive(false);
        yield return null;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
