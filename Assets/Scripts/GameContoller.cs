using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameContoller : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform playerSpawnPos;

    public Text timerText;
    private bool isGamePlaying = false;
    private PlayerController playerController;
    public static GameContoller Instance;
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
        Instance = this;
        EnemyGroupController.enabled = false;
        playerController = Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity).GetComponent<PlayerController>();
        playerController.enabled = false;
        GameOverPanel.SetActive(false);
        EnemyGroupController.transform.position = EnemyGroupSpawn.position;

        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 6; col++)
            {
                float space = .25f;
                float enemySize = .5f;
                Vector3 position = Vector3.right * (enemySize + space)*col + Vector3.down * (enemySize + space)*row;
                GameObject enemyToSpawn = NormalEnemy;
                if((1 == row || 3 == row) && (0 == col || 5 == col))
                {
                    enemyToSpawn = ShootingEnemy;
                }
                var enemy = Instantiate(enemyToSpawn, position, Quaternion.identity);
                enemy.transform.SetParent(EnemyGroupController.transform, false);
            }
        }
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
        EnemyGroupController.enabled = true;
        isGamePlaying = true;
        playerController.enabled = true;
        InvokeRepeating("SpawnMothership", 0, 4);
        //todo activate enemies and spawner
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
