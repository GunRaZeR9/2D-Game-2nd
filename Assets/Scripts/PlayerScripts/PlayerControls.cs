using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControls : MonoBehaviour {
    #region player_encapsulation_fields

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerData data;
    
    [SerializeField]private HealthBarScript healthBar;

    #endregion

    #region outside_general_communication
    public GameObject getDeadPrefab(){return data.dead_prefab;}
    #endregion

    #region computed_fields
    private Vector2 moveDirection;
    private bool isMoving;
    private bool facingRight ;
    
    
    private float currentHealth;
    #endregion

    #region INIT
    void Start() {
      rb = GetComponent<Rigidbody2D>();  
      currentHealth = data.maxHealth;
    healthBar.setMaxHealth(data.maxHealth);
    }
    #endregion

    #region Player_LOOP
    void Update() {
        
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") !=0 ){
            isMoving=true;
        }
        else{
            isMoving=false;
        }
        
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        animator.SetBool("isMoving",isMoving);
        
        if(facingRight == true && moveDirection.x > 0 )
        {
            Flip();
        }else if(facingRight == false && moveDirection.x < 0 )
        {
            Flip();
        }
       
        
    }
    void FixedUpdate() {
        rb.MovePosition(rb.position + moveDirection * data.moveSpeed *Time.fixedDeltaTime);
    

    }
    #endregion

    #region Player_Behaviour
   void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;  
        }
    #endregion
    
    #region EXTERNAL_STATE_MANIPULATION_FUNCTIONS
    public void TakeDamage(float damage){
        currentHealth -= damage;
        Debug.Log("Viata mea " + currentHealth);
        animator.SetTrigger("Hurt");
        healthBar.setHealth(currentHealth);
        
         if(currentHealth <= 0){
            Die();
        }
        
    }

    #endregion

    #region INTERNAL_STATE_MANIPULATION
       private void Die(){
        Debug.Log("Player died!");
        animator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled=false;
    }
    #endregion
        
   
}

