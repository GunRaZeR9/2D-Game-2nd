using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    #region SerializedFields
    [SerializeField] private Animator animator;
    [SerializeField] private Transform target;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private BossData data;
    [SerializeField] private PlayerData playerdata;

    
    #endregion
    
    #region Computed_Fields
    public LayerMask enemyLayers;
    private float minimiumDistance = 1.5f;
    public bool isTakingDamage = false;

    
    #endregion


    #region Attack_Loop
    void FixedUpdate() {
        if(target!=null){
        if(Vector2.Distance(transform.position, target.position) <= minimiumDistance){
            animator.SetBool("Attack",true);
            isTakingDamage = true;
        }else{
            animator.SetBool("Attack",false);
        }
        }
        
    }
    #endregion
    
    #region Attack_Behaviour
    public void Attack()
    {   
        Collider2D[]hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,data.attackRange,enemyLayers);

        foreach(Collider2D enemy in  hitEnemies){
            
            enemy.GetComponent<PlayerControls>().TakeDamage(data.damage);
            
            
                
        }
    }

    

    void OnDrawGizmosSelected() {
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position,data.attackRange);
    }
    #endregion

    
    
}