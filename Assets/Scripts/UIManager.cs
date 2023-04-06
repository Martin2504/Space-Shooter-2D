using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The UIManager is responsible to updating all things relavent to the UI. 
public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }
}
