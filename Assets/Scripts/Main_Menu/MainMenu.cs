using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Responsible for launching the game 
public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        // Load the game scene
        SceneManager.LoadScene(1);  // Main game scene 
    }
}
