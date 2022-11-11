using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControls : MonoBehaviour
{
    #region agent_details

    [SerializeField] Animator animator;
    [SerializeField] private BossData data;

    #endregion

    #region COMPUTED_FIELDS

    [SerializeField] private Transform target;
    private float minimiumDistance = 1;
    private bool facingRight;
    Vector2 lastPosition;
    private float currentHealth;
    public HealthBarScript healthBar;
    private bool isEnraged = false;

    #endregion

    #region outside_general_communication
    public GameObject getDeadPrefab() { return data.dead_prefab; }
    #endregion
    #region  Init
    void Start()
    {
        target = FindObjectOfType<PlayerControls>().transform;
        lastPosition = transform.position;
        currentHealth = data.maxHealth;
        healthBar.setMaxHealth(data.maxHealth);
    }
    #endregion

    #region AI_LOOP
    void FixedUpdate()
    {

        if (target == null)
            return;

        //state checking
        animator.SetFloat("movementSpeed", (Vector2.Distance(transform.position, lastPosition) / Time.fixedDeltaTime));
        lastPosition = transform.position;
        //end state checking

        //aggression check
        if (Vector2.Distance(target.position, transform.position) <= data.agroRange)
        {

            FollowPlayer();
        }
        //end aggression check

        //facing check
        if (facingRight == true && target.position.x - transform.position.x > 1)
        {
            Flip();
        }
        else if (facingRight == false && target.position.x - transform.position.x < -1)
        {
            Flip();
        }
        //end facing check
        if (currentHealth < 500)
        {
            animator.SetBool("isEnraged", true);

            Debug.Log("BossIsEnraged");
        }
    }
    #endregion

    #region AI_BEHAVIOUR
    public void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, target.position) > minimiumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, data.speed * Time.fixedDeltaTime);
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


    #region EXTERNAL_STATE_MANIPULATION_FUNCTIONS
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        animator.SetTrigger("Hurt");
    }



    #endregion

    #region INTERNAL_STATE_MANIPULATION
    private void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
    }
    #endregion
}
