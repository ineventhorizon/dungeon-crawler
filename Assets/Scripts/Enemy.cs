using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;
    float currentHealh;
    void Start()
    {
        currentHealh = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage)
    {
        currentHealh -= damage;

        if(currentHealh <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Enemy died");
        GetComponent<Collider>().enabled = false;
        Destroy(this.GetComponent<MeshRenderer>());
        this.enabled = false;

    }
}
