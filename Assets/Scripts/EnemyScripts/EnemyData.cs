using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/Data")]
public class EnemyData : ScriptableObject
{
    
     public float maxHealth;
     public float armourPoints;
     public float attackRange ;
     public float speed;
     public float agroRange;
     public float damage;
    public GameObject dead_prefab;
}
