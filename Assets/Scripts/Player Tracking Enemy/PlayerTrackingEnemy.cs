using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrackingEnemy : MonoBehaviour
{
    [SerializeField] float enemySenseRange = 3;
    [SerializeField] float moveSpeed = 2f;
    CapsuleCollider2D bodyCollider;
    Rigidbody2D rb;
    
    [SerializeField] bool currentDirectionHorizontal = false;
    [SerializeField] LayerMask flipOnTouchinglayer;
    [SerializeField] float tempMoveSpeed = 15f;
    Vector2 initialDirection;

    Vector2[] arrayOfDirections;
    int currentDirection;
    private void Awake()
    {
        bodyCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        if(currentDirectionHorizontal) initialDirection = new Vector2(0,1);
        arrayOfDirections = new Vector2[4];
        arrayOfDirections[0] = Vector2.right;
        arrayOfDirections[1] = Vector2.up;
        arrayOfDirections[2] = Vector2.left;
        arrayOfDirections[3] = Vector2.down;
        currentDirection = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        searchForPlayer();
    }
    protected void searchForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position,  enemySenseRange);
        if(hits.Length != 0)
        {
            foreach(Collider2D hit in hits)
            {
                if(hit.gameObject.tag == "Player")
                {
                    moveTowardsPlayer(hit);
                    return;
                }
            }
            Move();
        }else
        {
            Move();
        }
        
    }

    protected void Move()
    {

            float rayCastCheckLength = 3f;
            Vector2 moveValue = arrayOfDirections[currentDirection] * Time.deltaTime * tempMoveSpeed;
            Vector2 newPosition = new Vector2(transform.position.x + moveValue.x, transform.position.y + moveValue.y); 
            rb.MovePosition(newPosition);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, arrayOfDirections[currentDirection], rayCastCheckLength, flipOnTouchinglayer);
            if(hit){
                currentDirection++;
                if(currentDirection == 4) currentDirection = 0;
            }

    }

    private void moveTowardsPlayer(Collider2D hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            Vector2 direction = (transform.position - hit.gameObject.transform.position)*-1;
            Vector2 moveValue = direction * Time.deltaTime * moveSpeed;
            
            Vector3 newPosition = new Vector3(transform.position.x + moveValue.x,
                                transform.position.y + moveValue.y,
                                transform.position.z) ;

            // Debug.Log(hit.gameObject.name);
            // Debug.Log(newPosition);
            Debug.DrawLine(transform.position, newPosition, Color.green, Mathf.Infinity);
            rb.MovePosition(newPosition);
            // transform.position =hit.gameObject.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemySenseRange);
    }
}
