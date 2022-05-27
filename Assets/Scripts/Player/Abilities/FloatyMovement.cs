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
        bool sprintTriggerd;

        [SerializeField] float sprintCoolDown = 3f;
        [SerializeField] float forceMagnitude = 3f;
        GameDevTvGameJam movementInputAction;

        protected Vector2 moveValue;
        protected Vector2 playerDirection;
        public  float currentSprintCoolDown;

        private void Awake()
        {
            // initialization();
            movementInputAction = new GameDevTvGameJam();
            playerDirection = new Vector2(1,0);
            currentSprintCoolDown = sprintCoolDown;
            sprintTriggerd  = false;
        }

        protected override void initialization()
        {
            base.initialization();
        }

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
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
            
            if(context.started || context.canceled || sprintTriggerd)
            {
                Debug.Log("Inside if  ++ " + sprintTriggerd);
                return;
            }
            Debug.Log("triggering sprint");
            GetComponent<Rigidbody2D>().AddForce(playerDirection * forceMagnitude, ForceMode2D.Impulse);
            sprintTriggerd = true;
            currentSprintCoolDown = sprintCoolDown;
        }

        protected virtual void checkSprintCoolDown(){
            if(!sprintTriggerd){
                return;
            }else
            {
                currentSprintCoolDown -= Time.deltaTime;
                if(currentSprintCoolDown <= 0) sprintTriggerd = false;
            }

        }

        
    }
}