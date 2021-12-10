using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float playerDamage = 20;
    public float damageMult = 0.002f;
    private int comboStep;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = AnimatorControl.Instance.animator;
        comboStep = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if (comboStep > 3) comboStep = 1;
        string atk = "Attack" + comboStep.ToString();
        Debug.Log(atk);
        animator.Play(atk);
        comboStep++;


        Collider[] hitEnemies = Physics.OverlapSphere(attackpoint.position, attackRange, enemyLayers);


        if (hitEnemies.Length != 0)
        {
            foreach (Collider enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                playerDamage += damageMult * playerDamage * comboStep;
                enemy.GetComponent<Enemy>().takeDamage((playerDamage));
            }

        }
        else
        {
            Debug.Log("No enemy in range");
        }



    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(attackpoint.position, attackRange);
    }
}
