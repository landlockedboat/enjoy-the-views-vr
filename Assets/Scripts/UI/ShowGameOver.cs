using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShowGameOver : MonoBehaviour {

    [SerializeField]
    GameObject gameOverText;
    bool gameOver = false;
	
	void Start () {
        GameMaster.Instance.RegisterOnGameOverCallback(GameOver);
        InputHandler.Instance.RegisterOnFireCallback(ReloadScene);
	}

    void GameOver()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    void ReloadScene()
    {
        if (!gameOver)
        {
            return;
        }
        SceneManager.LoadScene(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
