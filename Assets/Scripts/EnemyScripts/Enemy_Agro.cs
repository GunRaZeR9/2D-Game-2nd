using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Agro : MonoBehaviour
{   
    
    #region agent_details
    
    [SerializeField] Animator animator;
    [SerializeField] private EnemyData data;

    #endregion

    #region COMPUTED_FIELDS

    [SerializeField] private Transform target;
    private float minimiumDistance = 1;
    private bool facingRight;
    Vector2 lastPosition;


    #endregion

    #region INIT
    void Start() {
        target =  FindObjectOfType<PlayerControls>().transform;
        lastPosition=transform.position;
    }
    #endregion

    #region AI_LOOP
    void FixedUpdate(){

        if(target==null)
        return;

        //state checking
        animator.SetFloat("movementSpeed", (Vector2.Distance(transform.position,lastPosition)/Time.fixedDeltaTime));
        lastPosition=transform.position;
        //end state checking

        //aggression check
        if(Vector2.Distance(target.position , transform.position) <= data.agroRange)
        {
            
            FollowPlayer();
        }
        //end aggression check

        //facing check
        if(facingRight == true && target.position.x - transform.position.x > 0 )
        {
            Flip();
        }else if(facingRight == false && target.position.x - transform.position.x < 0 )
        {
            Flip();
        }
        //end facing check
    }
    #endregion

    #region AI_BEHAVIOUR
    public void FollowPlayer(){
        if(Vector2.Distance(transform.position,target.position) > minimiumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,target.position,data.speed*Time.fixedDeltaTime);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;  
    }
    #endregion

}
