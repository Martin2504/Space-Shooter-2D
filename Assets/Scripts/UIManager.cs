using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The UIManager is responsible to updating all things relavent to the UI. 
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    // Referene to the lives image
    [SerializeField]
    private Image _LivesImg;

    // Referene to the lives sprites
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        

        if ( _gameManager == null )
        {
            Debug.LogError("The Game Manager is NULL.");
        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int livesLeft)
    {
        _LivesImg.sprite = _liveSprites[livesLeft];     // change the sprite in the image.

        if (livesLeft == 0)
        {
            GameOverSequence();
        }   
    }

    public void GameOverSequence()  // Game over method.
    {
        _gameManager.GameOver();
        StartCoroutine(flicker());
        _restartText.gameObject.SetActive(true);
    }

    IEnumerator flicker()   // Game over flicker.
    {
        while (true)
        {
            _gameOverText.gameObject.SetActive(true);   // Display Game Over text.
            yield return new WaitForSeconds(0.2f);
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
        }


    }

    

}
