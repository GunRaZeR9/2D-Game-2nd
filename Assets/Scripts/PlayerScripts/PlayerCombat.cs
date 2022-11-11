using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    #region Attack_Encapsulation_Fields  
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform BlockPoint;
    [SerializeField] private PlayerData data;
    [SerializeField] private EnemyData Skeletondata;
    [SerializeField] private EnemyData Goblindata;
    
    #endregion

    #region Computed_Fields
    public LayerMask enemyLayers;

    private float slashDamage;
    private float heavyDamage;
    public HealthBarScript healthBar;
  
    
 
    #endregion

    #region Attack_LOOP
    void Update()
    {
      Attack_Damage();
      

      if(Input.GetMouseButton(0)){

        Attack();
      }else 
      if(Input.GetKeyDown(KeyCode.Q)){
        SlashAttack();
      }else
      if(Input.GetKeyDown(KeyCode.E)){
        HeavyAttack();
      }else
      if(Input.GetKeyDown(KeyCode.Space)){
        Block();
      }
      
    }
    #endregion

    #region Attack_Behaviour
    void Attack_Damage(){
      if (data.damage > 0){
        slashDamage = data.damage * 0.5f;
        heavyDamage = data.damage * 2.0f;
      }
    }

    

    void Start() {
      Debug.Log("Start");
      
      
      
    }    
    void  Block(){

      
      
      animator.SetTrigger("Block");
      
      
    }

    void SlashAttack()
    {
        animator.SetTrigger("SlashAttack");

        
        Collider2D[]hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,data.attackRange,enemyLayers);
    
        foreach(Collider2D enemy in  hitEnemies){
            try{
              enemy.GetComponent<Enemy>().TakeDamage(slashDamage);
            }catch(NullReferenceException){

            }
            try{
              enemy.GetComponent<BossControls>().TakeDamage(slashDamage);
            }catch(NullReferenceException){
              
            }
        }
    }

    void HeavyAttack()
    {
        animator.SetTrigger("HeavyAttack");

        
        Collider2D[]hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,data.attackRange,enemyLayers);
        foreach(Collider2D enemy in  hitEnemies){
            try{
              enemy.GetComponent<Enemy>().TakeDamage(heavyDamage);
            }catch(NullReferenceException){

            }
            try{
              enemy.GetComponent<BossControls>().TakeDamage(heavyDamage);
            }catch(NullReferenceException){
              
            }
        }

    }
    void Attack()
    {   
        animator.SetTrigger("Attack");

        
        Collider2D[]hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,data.attackRange,enemyLayers);

        foreach(Collider2D enemy in  hitEnemies){
            try{
              enemy.GetComponent<Enemy>().TakeDamage(data.damage);
            }catch(NullReferenceException){

            }
            try{
              enemy.GetComponent<BossControls>().TakeDamage(data.damage);
            }catch(NullReferenceException){

            }
        }
    }

    

    
    #endregion
    #region Block_Behaviour
    void blockPower(){

      if(data.armour >= 0 ){
        
        for(int i=0 ; i <= data.armour ; i = i+10){
          Skeletondata.damage -= 5;
          Goblindata.damage -= 5;
        }
        Debug.Log(Skeletondata.damage);
        Debug.Log(Goblindata.damage);
        
      }
    }
    #endregion


}
