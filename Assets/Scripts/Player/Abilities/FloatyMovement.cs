using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace gameDevTvGameJam
{
    public class FloatyMovement : Abilities
    {
        [SerializeField]  float playerSpeed = 1f;

        public bool isIdle;
        public bool sprintTriggerd;

        [SerializeField] float sprintCoolDown = 3f;
        [SerializeField] int sprintSpeedIncreaseFactor = 2;
        [SerializeField] float sprintDuration = 2;
        GameDevTvGameJam movementInputAction;

        protected Vector2 moveValue;
        protected Vector2 playerDirection;
        private float currentSprintCoolDown;

        private float currentTimer = 0;
        private float tempSpeed;

        private void Awake()
        {
            // initialization();
            movementInputAction = new GameDevTvGameJam();
            playerDirection = new Vector2(1,0);
            currentSprintCoolDown = 0f;
            sprintTriggerd  = false;
            tempSpeed = playerSpeed;
        }

        protected override void initialization()
        {
            base.initialization();
        }


        void Update()
        {
            checkIfMoving();
            checkSprintCoolDown();
        }

        protected virtual void FixedUpdate()
        {
            Move();
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
            try
            {
                movementInputAction.Player.Enable();
            }catch(NullReferenceException e)
            {
                Debug.Log("Printing stack trace + \n" + e.StackTrace);
                return;
            }
            
            playerDirection = movementInputAction.Player.Move.ReadValue<Vector2>();

            
            moveValue = playerDirection *Time.deltaTime * playerSpeed;
            Debug.Log("Player speed while moving ---> " + playerSpeed);


            // transform.position = new Vector3(   transform.position.x  + moveValue.x,
            //                                     transform.position.y + moveValue.y, 
            //                                     transform.position.z);

            Vector3 newPosition = new Vector3(   transform.position.x  + moveValue.x,
                                                transform.position.y + moveValue.y, 
                                                transform.position.z);
            body.MovePosition(newPosition);

            if (playerDirection.x < 0 && !isLookingLeft)
            {
                flip();
            }else if (playerDirection.x > 0 && isLookingLeft)
            {
                flip();
            }
        }

        public void sprintPressed(InputAction.CallbackContext context)
        {
            
            if(context.started || context.canceled || sprintTriggerd || currentSprintCoolDown > 0)
            {
                Debug.Log("Inside if  ++ " + sprintTriggerd);
                return;
            }
            if(!sprintTriggerd){
                sprintTriggerd = true;
                 applySprint();
            }
            currentSprintCoolDown = sprintCoolDown;
        }

        void applySprint(){
            currentTimer += Time.deltaTime;
            tempSpeed = playerSpeed;
            if(currentTimer < sprintDuration)
            {
                playerSpeed = sprintSpeedIncreaseFactor * tempSpeed;
            }
            else
            {
                currentTimer = 0;
                playerSpeed = tempSpeed;
            }
        }

        protected virtual void checkSprintCoolDown(){
            if(!sprintTriggerd){
                return;
            }else
            {
                currentSprintCoolDown -= Time.deltaTime;
                if(currentSprintCoolDown <= 0)
                {
                    sprintTriggerd = false;
                    playerSpeed = tempSpeed;
                } 
            }

        }

        
    }
}