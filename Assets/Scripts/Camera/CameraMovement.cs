using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameDevTvGameJam
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] Transform playerPosition;
        [SerializeField] float offSetWithRespectToPlayerX;
        [SerializeField] float minFixedDistanceFromBoundary;

        [SerializeField] Character character;

        TrackCamera trackCamera;

        private void Awake()
        {
            trackCamera = GetComponent<TrackCamera>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            MoveCameraForX();        
        }

        private void MoveCameraForX()
        {
            // if(!character.checkIfCharacterLookingLeft() && trackCamera.getDistToRight() < maxAllowedDistanceFromBoundary){
            //     transform.position = new Vector3(playerPosition.position.x + offSetWithRespectToPlayerX, 
            //                                 transform.position.y, transform.position.z);
            // }else if(character.checkIfCharacterLookingLeft() && trackCamera.getDistToLeft() < maxAllowedDistanceFromBoundary)
            // {

            // } 
            
            // if(playerPosition.localScale.x > 0 && trackCamera.getDistToRight() > minFixedDistanceFromBoundary)
            // {
            //     transform.position = new Vector3(playerPosition.position.x + offSetWithRespectToPlayerX, 
            //                     transform.position.y, transform.position.z);
            // }else if(playerPosition.localScale.x < 0 && trackCamera.getDistToLeft() > minFixedDistanceFromBoundary)
            // {
            //     transform.position = new Vector3(playerPosition.position.x + offSetWithRespectToPlayerX, 
            //                     transform.position.y, transform.position.z);
            // }
            // float x = Mathf.Clamp(playerPosition.position.x, trackCamera.collidingPointLeft.x, trackCamera.collidingPointRight.x);
            transform.position = new Vector3(playerPosition.position.x,
                                                playerPosition.position.y, transform.position.z);
        }
    }    
}

