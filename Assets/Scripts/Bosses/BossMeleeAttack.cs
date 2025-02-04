using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint => transform.Find("MeleeAttackPoint");
    public LayerMask enemyLayers;

    public int attackDamage = 5;
    public float attackRangeNormal = 1f;
    public Rigidbody2D rb;
   
    [SerializeField]
    internal GameEvent AttackSwing;

    public float cooldown = 0.3f;

    public void Boss_Melee_Attack()
    {

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeNormal, enemyLayers);
        AttackSwing.Raise();
        // Damage enemies (loop over all enemies in collider array)
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerData>().TakeDamage(attackDamage, this.gameObject);
            Debug.Log("Player damaged by melee attack!");
        }
    }


}
