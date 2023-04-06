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

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int livesLeft)
    {
        _LivesImg.sprite = _liveSprites[livesLeft];     // change the sprite in the image.
    }


}