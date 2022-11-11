using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    #region enemy_encapsulation_fields
    [SerializeField] private Animator animator;
    
    [SerializeField] private EnemyData data;
    
    #endregion

    #region outside_general_communication
    public GameObject getDeadPrefab(){return data.dead_prefab;}
    #endregion

    #region COMPUTED_FIELDS
    private float currentHealth;
    public HealthBarScript healthBar;
    

    #endregion
    void ArmourPower(){
        if(data.armourPoints >= 0 ){
        
      }
    }
    
    #region INIT
    void Start()
    {   
        
        currentHealth = data.maxHealth;
        healthBar.setMaxHealth(data.maxHealth);
        ArmourPower();
    }
    #endregion

     #region EXTERNAL_STATE_MANIPULATION_FUNCTIONS
    public void TakeDamage(float damage){
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
         if(currentHealth <= 0){
            Die();
        }
        animator.SetTrigger("Hurt");
    }
    
    #endregion

    #region INTERNAL_STATE_MANIPULATION
       private void Die(){
        Debug.Log("Enemy died!");
        animator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
    }
    #endregion
    
    
}