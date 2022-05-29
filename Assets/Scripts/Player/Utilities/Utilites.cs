using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using gameDevTvGameJam;

public class Utilites : Abilities
{

    [SerializeField] float coinPullTimeLimit = 10f;
    [SerializeField] float enemyEaterTimeLimit = 10f;


    protected float currentCoinPullTime;
    protected float currentEnemyEatTime;
    protected Color originalColor;

    protected Color[] switchingColors;
    protected int currentSwitchColorIndex;
    protected  float enemyDetectRadius = 1f;

    private void Awake()
    {
        if(bodySpriteRenderer == null) bodySpriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = bodySpriteRenderer.color;
        currentCoinPullTime = coinPullTimeLimit;
        currentEnemyEatTime = enemyEaterTimeLimit;
        switchingColors = new Color[4];
        switchingColors[0] = Color.red;
        switchingColors[1] = Color.blue;
        switchingColors[2] = Color.green;
        switchingColors[3] = Color.yellow;
        currentSwitchColorIndex = 0;
    }

    private void Update()
    {
        if(utilitiesManager.getCoinPullStatus()) disableCoinPull();
        if(utilitiesManager.getEnemyEaterStatus())
        {
            EatEnemiesForm();
            detectAndDestroyEnemy();
            disableEnemyEater();
            
        } 
    }

    private void disableEnemyEater()
    {
        if(currentEnemyEatTime > 0f)
        {
            currentEnemyEatTime -= Time.deltaTime;
        }
        else
        {
            utilitiesManager.deativateEnemyEater();
            currentEnemyEatTime = enemyEaterTimeLimit;
            bodySpriteRenderer.color = originalColor;
            bodyCollider.isTrigger = false;
        }
    }

    private void disableCoinPull()
    {
        if(currentCoinPullTime > 0f)
        {
            currentCoinPullTime -= Time.deltaTime;
        } 
        else
        {
            utilitiesManager.deactivateCoinPull();
            currentCoinPullTime = coinPullTimeLimit;
        }
    }

    public void activateCoinPull(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            if(scoremanager == null) scoremanager = FindObjectOfType<Scoremanager>();
            if(utilitiesManager == null) utilitiesManager = GetComponent<UtilitiesManager>();
            int x = scoremanager.getCurrentScore();
            if(x >= 200) 
            {
                utilitiesManager.activateCoinPull();
                scoremanager.updateScore(-1 * 200);
            }

        }
    }

    public void activateEnemyDestroyer(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(scoremanager == null) scoremanager = FindObjectOfType<Scoremanager>();
            if(utilitiesManager == null) utilitiesManager = GetComponent<UtilitiesManager>();
            int x = scoremanager.getCurrentScore();
            if(x >= 1000)
            {
                utilitiesManager.activateEnemyEater();
                scoremanager.updateScore(-1 * 1000);
            }
        }
    }

    private void EatEnemiesForm()
    {
        bodySpriteRenderer.color =  switchingColors[currentSwitchColorIndex++];
        currentSwitchColorIndex %= 4;
    }

    protected void detectAndDestroyEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, enemyDetectRadius);
        foreach(Collider2D hit in hits)
        {
            if(hit.gameObject.tag == "Enemy")
            {
                Destroy(hit.gameObject);
            }
        }
    }

}
