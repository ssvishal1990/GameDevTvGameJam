using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    Scoremanager scoremanager;

    [SerializeField] TextMeshProUGUI finalScoreTextField;

    private void Awake()
    {
        scoremanager = FindObjectOfType<Scoremanager>();
        if(scoremanager != null)
        {
            finalScoreTextField.text = scoremanager.getCurrentScore().ToString();
            Destroy(scoremanager.gameObject);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
}
