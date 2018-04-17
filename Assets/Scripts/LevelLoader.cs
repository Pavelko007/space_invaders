using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	// Update is called once per frame
    public void LoadLevel() {
		SceneManager.LoadScene("main");
	}
}
