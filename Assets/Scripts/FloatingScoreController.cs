using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingScoreController : MonoBehaviour
{
    public Text scoreText;

    void Awake()
    {
        Invoke("Destroy", 1.5f);
    }

    public void SetScore(int score)
    {
        scoreText.text = string.Format("+{0}", score);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
