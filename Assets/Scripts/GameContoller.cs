using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform playerSpawnPos;

    public Text timerText;
    private bool isGamePlaying = false;
    private PlayerController playerController;

    void Awake()
    {
        playerController = Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity).GetComponent<PlayerController>();
        playerController.enabled = false;
    }

    void Start ()
    {
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

        StartGame();
        yield return null;
    }

    private void StartGame()
    {
        isGamePlaying = true;
        playerController.enabled = true;
        //todo activate enemies and spawner
    }

    // Update is called once per frame
	void Update () {
		
	}
}
