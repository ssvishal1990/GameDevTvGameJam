using UnityEngine;

namespace gameDevTvGameJam
{
    public class floating : Abilities
    {
        [SerializeField] int maxNudge;
        [SerializeField] [Range(0, 1)] float timeBeforeStartFloating;
        [SerializeField] float reduceDecreementBy = 0.01f;

        protected float maxUp;
        protected float maxDown;
        protected float timeLeft;

        public int currentNumberOfNudges;

        protected bool checkIfNeedToGoDown;

        FloatyMovement floatyMovement;

        private void Awake()
        {
            floatyMovement = GetComponent<FloatyMovement>();
            timeLeft = timeBeforeStartFloating;
            checkIfNeedToGoDown = true;
        }

        void Update()
        {
            characterFloating();

        }

        protected override void initialization()
        {
            base.initialization();
        }

        protected virtual void characterFloating()
        {
            if (!floatyMovement.isIdle)
            {
                timeLeft = timeBeforeStartFloating;
                currentNumberOfNudges = maxNudge;
                return;
            }
            timeLeft -= Time.deltaTime ;
            if (timeLeft > 0) return;

            if (currentNumberOfNudges <= 0)
            {
                checkIfNeedToGoDown = false;
            }
            else if (currentNumberOfNudges >= maxNudge)
            {
                checkIfNeedToGoDown = true;
            }

            if (checkIfNeedToGoDown)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime * reduceDecreementBy), transform.position.z);
                currentNumberOfNudges--;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime * reduceDecreementBy), transform.position.z);
                currentNumberOfNudges++;
            }

        }


    }
}