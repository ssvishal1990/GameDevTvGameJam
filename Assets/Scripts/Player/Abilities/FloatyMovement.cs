using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace gameDevTvGameJam
{
    public class FloatyMovement : Abilities
    {
        [SerializeField] float playerSpeed = 1f;

        public bool isIdle;
        GameDevTvGameJam movementInputAction;

        protected Vector2 moveValue;

        private void Awake()
        {
            movementInputAction = new GameDevTvGameJam();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            checkIfMoving();
            Move();
        }

        protected virtual void FixedUpdate()
        {

        }

        private void checkIfMoving()
        {
            if (moveValue != Vector2.zero)
            {
                isIdle = false;
            }else
            {
                isIdle = true;
            }
        }

        private void Move()
        {
            movementInputAction.Player.Enable();
            Vector2 playerDirection = movementInputAction.Player.Move.ReadValue<Vector2>();

            
            moveValue = playerDirection *Time.deltaTime * playerSpeed;


            Debug.Log(moveValue);
            transform.position = new Vector3(   transform.position.x  + moveValue.x,
                                                transform.position.y + moveValue.y, 
                                                transform.position.z);

            if (playerDirection.x < 0 && !isLookingLeft)
            {
                flip();
            }else if (playerDirection.x > 0 && isLookingLeft)
            {
                flip();
            }
        }

        
    }
}