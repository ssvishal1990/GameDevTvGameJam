using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squaring : MonoBehaviour
{
    [SerializeField] float squareLen = 2f;

    protected Vector2 startingPoint;

    private void Awake()
    {
        startingPoint = new Vector2(transform.position.x, transform.position.y);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoRight();
    }

    protected void GoRight()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(startingPoint.x + squareLen, transform.position.y), 1f);
        // float targetX = startingPoint.x + squareLen;
        // float tempX = startingPoint.x;
        // while(tempX < targetX)
        // {
        //     Debug.Log("Inside goRight()");
        //     tempX += Time.deltaTime * movefactor;
        //     transform.position = new Vector2(tempX, transform.position.y);
        // }
        // goDown();
    }

    private void goDown()
    {
        float targetY = transform.position.y - squareLen;
        float tempY = startingPoint.y;
        while(tempY > targetY)
        {
            tempY -= Time.deltaTime;
            transform.position = new Vector2(transform.position.x,
                                             tempY);
        }
        goLeft();
    }

    private void goLeft()
    {
        float targetX = transform.position.x - squareLen;
        float tempX = transform.position.x;
        while(tempX > targetX)
        {
            tempX -= Time.deltaTime;
            transform.position = new Vector2(tempX, transform.position.y);
        }
        goUp();
        
    }

    private void goUp()
    {
        float targetY = transform.position.y + squareLen;
        float tempY = transform.position.y;
        while(tempY < targetY)
        {
            tempY += Time.deltaTime;
            transform.position = new Vector2(transform.position.x,
                                             tempY);
        }
    }
}
