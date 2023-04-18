using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver; 

    public void Update()
    {
        // If R key pressed, restart current scene. 
        if (Input.GetKeyDown(KeyCode.R)  && _isGameOver == true)
        {
            SceneManager.LoadScene(1);  // Current game scene is 0.
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    
}
