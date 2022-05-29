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

    private void Awake()
    {
        int noOfScoreManagers =  FindObjectsOfType<Scoremanager>().Length;
        if(noOfScoreManagers > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
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
    
    /// <summary>
    /// Updates the current score. 
    /// </summary>
    /// <param name="updateByValue">Value to be updated by.</param>
    public void updateScore(int updateByValue){
        currentScore += updateByValue * scoreMultiplier;
    }
    void Update()
    {
        scoreField.text = currentScore.ToString();
    }

    public int getCurrentScore()
    {
        return currentScore;
    }
}
