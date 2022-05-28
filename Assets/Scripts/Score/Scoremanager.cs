using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreField;

    int currentScore;
    bool powerUpEnabled;

    int scoreMultiplier;

    void Start()
    {
        scoreMultiplier = 1;
        currentScore = 0 * scoreMultiplier;
        scoreField.text = currentScore.ToString();
    }

    public void enablePowerUp()
    {
        powerUpEnabled = true;
        scoreMultiplier = 2;
    }

    
    public void disablePowerUp()
    {
        powerUpEnabled = false;
        scoreMultiplier = 1;
    }

    public bool getIfPowerUpAlreadyEnabled()
    {
        return powerUpEnabled;
    }

    public void updateScore(int updateByValue){
        currentScore += updateByValue * scoreMultiplier;
    }
    void Update()
    {
        scoreField.text = currentScore.ToString();
        Debug.Log(currentScore);
    }
}
