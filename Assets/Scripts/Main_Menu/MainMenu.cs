using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Responsible for launching the game 
public class MainMenu : MonoBehaviour
{
    public void LoadSinglePlayerGame()
    {
        // Load the sinlge player game scene
        SceneManager.LoadScene("Single_Player");  // Main game scene 
    }

    public void LoadCoOpGame()
    {
        // Load the Co Op game scene
        SceneManager.LoadScene("Co-Op_Game");  
    }
}
