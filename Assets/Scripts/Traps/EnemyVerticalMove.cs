using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVerticalMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f, rayCastCheckLength = 2f;
    [SerializeField] LayerMask layer;


    Vector2 Direction;

    Rigidbody2D rb;
    private void Awake()
    {
    
        rb = GetComponent<Rigidbody2D>();
        Direction = new Vector2(0,1);
    }
    void Update()
    {
        move();
        checkAndChange();
    }

    void move(){
        Vector2 moveValue = Direction * Time.deltaTime * moveSpeed;

        Vector3 newPosition = new Vector3(transform.position.x + moveValue.x,
                                        transform.position.y + moveValue.y,
                                        transform.position.z);

        rb.MovePosition(newPosition);
    }

    void checkAndChange()
    {
        RaycastHit2D hit;
        if(Direction.y == 1)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, rayCastCheckLength, layer);
        }else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.down, rayCastCheckLength, layer);
        }

        if(hit)
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
            Direction.y *= -1;
        }
    }
}
