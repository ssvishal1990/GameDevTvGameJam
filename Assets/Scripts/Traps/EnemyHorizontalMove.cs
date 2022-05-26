using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float rayCastCheckLength = 2f;
    
    
    Rigidbody2D rb;
    [SerializeField] LayerMask layerMask;
    Vector2 initialStart;
    Vector2 newPosition;

    Vector2 initalDirection;
    private void Awake()
    {
        initalDirection = new Vector2(1,0);
        initialStart = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        checkAndChangeDirection();
        Move();
    }

    private void Move()
    {
        Vector2 moveValue = initalDirection * Time.deltaTime * moveSpeed;
        newPosition = new Vector2(transform.position.x + moveValue.x, transform.position.y + moveValue.y); 
        rb.MovePosition(newPosition);
    }

    protected void checkAndChangeDirection()
    {
        RaycastHit2D hit;
        if(initalDirection.x == 1)
        {
             hit = Physics2D.Raycast(transform.position, Vector2.right, rayCastCheckLength, layerMask);
            
        }else{
             hit = Physics2D.Raycast(transform.position, Vector2.left, rayCastCheckLength, layerMask);
            
        }

        if( hit)
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
            initalDirection.x *= -1;
        }
        
    }
}
