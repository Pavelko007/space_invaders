using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameContoller : Singleton<GameContoller>
{
    protected GameContoller(){}

    public GameObject playerPrefab;

    public Transform playerSpawnPos;

    public Text timerText;
    public bool isGamePlaying = false;
    private PlayerController playerController;
    public GameObject GameOverPanel;
    public Text GameOverText;

    public Transform EnemyGroupSpawn;
    public GameObject NormalEnemy;
    public GameObject ShootingEnemy;
    public EnemyGroupController EnemyGroupController;

    public int NumEnemies
    {
        get { return numEnemies; }
        set
        {
            numEnemies = value;

            if (numEnemies == 0)
            {
                GameOver(true);
            }
        }
    }

    void Awake()
    {
        
    }

    void Start ()
    {
        StartGame();
    }

    private void StartGame()
    {
        EnemyGroupController.enabled = false;
        SpawnPlayer();
        GameOverPanel.SetActive(false);
        EnemyGroupController.transform.position = EnemyGroupSpawn.position;

        //if(EnemyGroupController)
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 6; col++)
            {
                float space = .25f;
                float enemySize = .5f;
                Vector3 position = Vector3.right * (enemySize + space) * col + Vector3.down * (enemySize + space) * row;
                GameObject enemy;
                if ((1 == row || 3 == row) && (0 == col || 5 == col))
                {
                    enemy = Instantiate(ShootingEnemy, position, Quaternion.identity);
                }
                else
                {
                    enemy = Instantiate(NormalEnemy, position, Quaternion.identity);
                }


                enemy.transform.SetParent(EnemyGroupController.transform, false);
            }
        }
        StartCoroutine(Countdown());
    }

    private void CleanUp()
    {
        onGameRestarted.Invoke();
        score = 0;

        if(playerController)Destroy(playerController.gameObject);

        foreach (Transform child in EnemyGroupController.transform)
        {
            Destroy(child.gameObject);
        }
        //while (EnemyGroupController.transform.childCount > 0)
        //{
        //    Destroy(EnemyGroupController.transform.GetChild(0).gameObject);
        //}
    }

    private void SpawnPlayer()
    {
        playerController = Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity)
            .GetComponent<PlayerController>();
        playerController.enabled = false;
    }

    IEnumerator Countdown()
    {
        timerText.gameObject.SetActive(true);
        float timeToStart = 3;
        while (timeToStart > 0)
        {
            timeToStart -= Time.deltaTime;
            timerText.text = ((int)Mathf.Ceil(timeToStart)).ToString();
            yield return new WaitForEndOfFrame();
        }

        timerText.gameObject.SetActive(false);

        ResumeGame();
        yield return null;
    }

    private void ResumeGame()
    {
        EnemyGroupController.enabled = true;
        isGamePlaying = true;
        playerController.enabled = true;
        InvokeRepeating("SpawnMothership", 0, 4);
        onGameResume.Invoke();
        //todo activate enemies and spawner
    }

    public UnityEvent onGamePause;
    public UnityEvent onGameResume;
    public UnityEvent onGameRestarted;

    private void PauseGame()
    {
        onGamePause.Invoke();
        playerController.enabled = false;
        onGamePause.Invoke();
        isGamePlaying = false;
        EnemyGroupController.enabled = false;
        CancelInvoke("SpawnMothership");
    }

    public void OnPlayerHit()
    {
        PauseGame();
        SpawnPlayer();
        StartCoroutine(Countdown());
    }

    public GameObject Mothership;

    public Transform MothershipSpawnLeft;

    public Transform MothershipSpawnRight;

    private float score = 0;

    void SpawnMothership()
    {
        if (Random.value < .4f)
        {
            Vector3 startPos;
            Vector3 targetPos;
            if (Random.value < 0.5f)
            {
                startPos = MothershipSpawnLeft.position;
                targetPos = MothershipSpawnRight.position;
            }
            else
            {
                startPos = MothershipSpawnRight.position;
                targetPos = MothershipSpawnLeft.position;
            }

            var mothership = Instantiate(Mothership, startPos, Quaternion.identity).GetComponent<MothershipController>();
            mothership.SetTarget(targetPos);

        }
    }

    // Update is called once per frame


    void Update () {
	    if (Input.GetKeyDown(KeyCode.P))
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

        PauseGame();
    }

    public void Restart()
    {
        CleanUp();
        StartGame();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void AddScore(float scoreForKill)
    {
        Score += scoreForKill;
    }

    public Text ScoreText;

    private int numEnemies;

    public float Score
    {
        get { return score; }
        set
        {
            score = value;
            ScoreText.text = string.Format("Score: {0}", score);
            Debug.Log("score is " + score);
        }
    }
}
