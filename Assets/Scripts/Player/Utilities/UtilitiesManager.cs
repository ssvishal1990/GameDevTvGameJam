using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UtilitiesManager : MonoBehaviour
{
    [SerializeField] protected bool coinpull;
    [SerializeField] protected  bool enemyEater;
    
    public void activateCoinPull()
    {
        coinpull = true;
    }

    public void deactivateCoinPull()
    {
        coinpull = false;
    }

    public bool getCoinPullStatus(){
        return coinpull;
    }

    public void activateEnemyEater()
    {
        enemyEater = true;
    }

    public void deativateEnemyEater()
    {
        enemyEater = false;
    }

    public bool getEnemyEaterStatus()
    {
        return enemyEater;
    }


}
