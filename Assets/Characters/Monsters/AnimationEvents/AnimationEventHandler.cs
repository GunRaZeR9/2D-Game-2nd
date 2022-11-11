using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    #region DEATH_HANDLING_ANIM
    public void SpawnDeadPrefab(){
        if(transform.tag=="Enemy")
            Instantiate(GetComponent<Enemy>().getDeadPrefab(),transform.position,Quaternion.identity);
        if(transform.tag=="Player")
            Instantiate(GetComponent<PlayerControls>().getDeadPrefab(),transform.position,Quaternion.identity);
         if(transform.tag=="Boss")
            Instantiate(GetComponent<BossControls>().getDeadPrefab(),transform.position,Quaternion.identity);
        
    }
    public void DestroyCurrent(){
        Destroy(gameObject);
    }
    #endregion
    

}
