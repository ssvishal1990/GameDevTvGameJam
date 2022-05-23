using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameDevTvGameJam
{
    // Purpose of this script is to have an initilization of all components
    // These components then can be referred by extending classes for
    // Easy access
    public class Character : MonoBehaviour
    {
        protected CircleCollider2D bodyCollider;
        protected Rigidbody2D body;

        protected bool isLookingLeft;
        

        private void Start()
        {
            initialization();
        }

        protected virtual void initialization()
        {
            bodyCollider = GetComponent<CircleCollider2D>();    
            body = GetComponent<Rigidbody2D>();
            isLookingLeft = false;
        }

        protected virtual void flip()
        {
            isLookingLeft = !isLookingLeft;
            transform.localScale = new Vector3(-1 * transform.localScale.x,
                                                    transform.localScale.y,
                                                    transform.localScale.z);
        }

    }
}