using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data")]
public class PlayerData : ScriptableObject
{
    public float moveSpeed;
    public float maxHealth ;

    public float attackRange;
    public float blockRange;
    
    public float armour;
    public  int damage;
    public GameObject dead_prefab;
}
