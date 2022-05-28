using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    // Start is called before the first frame update
    Scoremanager scoremanager;
    int coinPoints = 10;
    public float spinSpeed = 5f;

    private void Awake()
    {
        scoremanager = FindObjectOfType<Scoremanager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            scoremanager.updateScore(coinPoints);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        coinSpin();
    }

    private void coinSpin(){
        Quaternion rotation =  transform.rotation;
        rotation.y += spinSpeed;
        if(rotation.y >= 180) rotation.y = 0;
        transform.rotation = rotation;
    }
}
