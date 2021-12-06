using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    int currentHealh;
    void Start()
    {
        currentHealh = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        currentHealh -= damage;

        if(currentHealh == 0)
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
