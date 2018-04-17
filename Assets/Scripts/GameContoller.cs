using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform playerSpawnPos;

    public Text timerText;
    private bool isGamePlaying = false;
    private PlayerController playerController;
    public static GameContoller Instance;
    public GameObject GameOverPanel;

    void Awake()
    {
        Instance = this;
        playerController = Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity).GetComponent<PlayerController>();
        playerController.enabled = false;
        GameOverPanel.SetActive(false);
    }

    public Text GameOverText;

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
	    if (Input.GetKeyDown(KeyCode.K))
	    {
	        Destroy(playerController.gameObject);
            GameOver(false);

	    }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameOver(true);
        }
    }

    public void GameOver(bool hasWon = false)
    {
        GameOverPanel.SetActive(true);
        if (hasWon)
        {
            GameOverText.text = "You win";
        }
        else
        {
            GameOverText.text = "You lost";
        }
        
        isGamePlaying = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
