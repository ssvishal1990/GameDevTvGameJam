using System.Collections;
using UnityEngine;

namespace gameDevTvGameJam
{
    public class DirectionAiming : Abilities
    {
        [SerializeField] float overlapCircleRadius = 5.0f;



        // Update is called once per frame
        void Update()
        {
            setOverLappingGameObjects();
        }

        protected virtual void setOverLappingGameObjects()
        {
            int numberOfEnemiesDetected = 0;
            Collider2D[] hits = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y),
                                                            overlapCircleRadius);

            foreach (Collider2D itemCollider in hits)
            {
                if (itemCollider.gameObject.tag == "Enemy")
                {
                    numberOfEnemiesDetected++;
                    Debug.Log(itemCollider.gameObject.name);
                }
            }

            Debug.Log("numberOfEnemiesDetected = " +numberOfEnemiesDetected);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, overlapCircleRadius);
        }
    }
}