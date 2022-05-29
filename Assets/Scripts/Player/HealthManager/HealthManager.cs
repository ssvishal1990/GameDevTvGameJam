using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lifeValueField;
    [SerializeField] protected float enemyDetectRadius = 2f;
    [SerializeField] protected float lifeReduceOnDamageValue = 5f;
    protected float maxLife = 100;
    protected float currentLifeValue;

    protected bool HealthRegenStarted;

    protected float lifeRegenStartCoolDown = 3f;
    

    void Start()
    {
        HealthRegenStarted = false;
        lifeValueField.text = maxLife.ToString();
        currentLifeValue = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        lifeValueField.text = ((int)currentLifeValue).ToString();
        willReceiveDamage();
        regenerateHealth();
        checkIfPlayerIsDead();

    }

    protected void willReceiveDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, enemyDetectRadius);
        foreach(Collider2D hit in hits)
        {
            if(hit.gameObject.tag == "Enemy")
            {
                Debug.Log("Detected Enemy");
                currentLifeValue -=   lifeReduceOnDamageValue * Time.deltaTime;
            }
        } 
    }
    protected bool checkIfTouchingEnemy()
    {
        if(GetComponent<CircleCollider2D>().IsTouchingLayers(LayerMask.GetMask("Enemy"))){
            lifeRegenStartCoolDown = 3f;
            return true;
        }else 
        {
            return false;
        }
    }
    protected void regenerateHealth()
    {
        if(currentLifeValue <= maxLife)
        {
            if(!HealthRegenStarted && !checkIfTouchingEnemy())
            {
                lifeRegenStartCoolDown -= Time.deltaTime;
            }else
            {
                currentLifeValue += Time.deltaTime * lifeReduceOnDamageValue/2;
            }

            if(lifeRegenStartCoolDown < 0 )
            {
                HealthRegenStarted = true;
            }            
        }else
        {
            HealthRegenStarted = false;
            lifeRegenStartCoolDown = 3f;
        }
    }

    protected void checkIfPlayerIsDead()
    {
        if(currentLifeValue < 0 )
        {
            Destroy(gameObject);
            SceneManager.LoadScene(4);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyDetectRadius);
    }
}
