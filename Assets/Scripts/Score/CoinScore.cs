using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    // Start is called before the first frame update
    Scoremanager scoremanager;
    int coinPoints = 10;
    [SerializeField] float rotaionIncreement = 2f;
    [SerializeField] float detectPlayerRadius = 2f;
    [SerializeField] float coinMoveTowardsPlayerSpeed = 20f;

    CircleCollider2D circleCollider2D;
    UtilitiesManager utilitiesManager;


    private void Awake()
    {
        scoremanager = FindObjectOfType<Scoremanager>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        utilitiesManager = FindObjectOfType<UtilitiesManager>();
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
        if(utilitiesManager.getCoinPullStatus()) detectAndMoveTowardsPlayer();
    }

    /// <summary>
    /// Calculate the coin spin.
    /// </summary>
    private void coinSpin(){
        Quaternion rotation =  transform.rotation;
        Vector3 eulerValuesOfRotation = rotation.eulerAngles;
        // rotation.y += spinSpeed;

        eulerValuesOfRotation.y += rotaionIncreement;
        if(eulerValuesOfRotation.y >= 180) eulerValuesOfRotation.y = 0;
        rotation.eulerAngles = eulerValuesOfRotation;
        transform.rotation = rotation; 

    }

    /// <summary>
    /// Detect player if coin pull power up active
    /// </summary>
    /// <returns></returns>
    private void detectAndMoveTowardsPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectPlayerRadius);
        foreach(Collider2D hit in hits)
        {
            if(hit.gameObject.tag == "Player")
            {
                MoveTowardsPlayer(hit);
            }
        }
    }

    /// <summary>
    /// Move towards player if collider within range
    /// </summary>
    /// <param name="hit">Collider of the detecte</param>
    private void MoveTowardsPlayer(Collider2D hit)
    {
        Vector2 direction = (transform.position - hit.gameObject.transform.position) * -1;
        Vector2 moveValue = direction * Time.deltaTime * coinMoveTowardsPlayerSpeed;

        Vector3 newPosition = new Vector3(transform.position.x + moveValue.x,
                            transform.position.y + moveValue.y,
                            transform.position.z);
        transform.position = newPosition;
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(transform.position, detectPlayerRadius);
    // }
}
