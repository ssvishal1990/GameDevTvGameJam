using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circling : MonoBehaviour
{
    // [SerializeField] Transform center;

    [SerializeField] float raidus = 2f, angularSpeed = 2f;

    float posX, posY, angle = 0f; 

    Transform center;

    private void Awake()
    {
        center = this.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plotPerimeter();
    }

    void plotPerimeter()
    {
        Vector2 centerVector = new Vector2(center.position.x, center.position.y);
        Vector2 radiusPoint = new Vector2(centerVector.x + raidus, centerVector.y +raidus);

        posX = center.position.x + Mathf.Cos(angle) * raidus;
        posY = center.position.y + Mathf.Sin(angle) * raidus;
        
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if(angle >= 360f) 
        {
            angle = 0f;
        }
        
    }

}
