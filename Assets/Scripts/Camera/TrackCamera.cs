using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameDevTvGameJam
{
    public class TrackCamera : MonoBehaviour
    {
        [SerializeField] float distanceToBoundary;
        [SerializeField] LayerMask layerMask;

        protected float distanceToLeft;
        protected float distanceToRight;

        public Vector2 collidingPointLeft;
        public  Vector2 collidingPointRight;

        private void Awake()
        {
            initiazlizeRayCast();
        }

        protected void initiazlizeRayCast()
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distanceToBoundary, layerMask);
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, distanceToBoundary, layerMask);
            float distanceToLeft = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hitLeft.point);
            float distanceToRight = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), hitRight.point);
            Debug.DrawLine(transform.position, hitLeft.point, Color.red);
            Debug.DrawLine(transform.position, hitRight.point, Color.green);

            this.distanceToLeft = distanceToLeft;
            this.distanceToRight = distanceToRight;
            this.collidingPointLeft = hitLeft.point;
            this.collidingPointRight = hitRight.point;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Debug.DrawLine(transform.position, collidingPointLeft, Color.red);
            Debug.DrawLine(transform.position, collidingPointRight, Color.green);
        }

        public float getDistToLeft(){
            return this.distanceToLeft;
        }
        public float getDistToRight(){
            return this.distanceToRight;
        }
    }
}

