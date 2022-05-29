using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameDevTvGameJam
{

    enum LookDirection {
        LEFT,
        RIGHT
    };
    // Purpose of this script is to have an initilization of all components
    // These components then can be referred by extending classes for
    // Easy access
    public class Character : MonoBehaviour
    {
        protected CircleCollider2D bodyCollider;
        protected Rigidbody2D body;
        protected UtilitiesManager utilitiesManager;
        protected SpriteRenderer bodySpriteRenderer;
        protected Scoremanager scoremanager;
        protected bool isLookingLeft;

        protected Utilites utilites;
        

        protected virtual void Start()
        {
            initialization();
        }

        protected virtual void initialization()
        {
            bodyCollider = GetComponent<CircleCollider2D>();    
            body = GetComponent<Rigidbody2D>();
            utilitiesManager = GetComponent<UtilitiesManager>();
            bodySpriteRenderer = GetComponent<SpriteRenderer>();
            utilites = GetComponent<Utilites>();
            if(!utilites.enabled) utilites.enabled = true;
            scoremanager = FindObjectOfType<Scoremanager>();
            isLookingLeft = false;
        }

        protected virtual void flip()
        {
            isLookingLeft = !isLookingLeft;
            transform.localScale = new Vector3(-1 * transform.localScale.x,
                                                    transform.localScale.y,
                                                    transform.localScale.z);
        }

        public bool  checkIfCharacterLookingLeft()
        {
            return isLookingLeft;
        }

    }
}