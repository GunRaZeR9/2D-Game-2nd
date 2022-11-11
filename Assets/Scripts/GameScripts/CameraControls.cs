using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    #region Camera_Encapsulation_Fields
       [SerializeField] private Transform target;
       [SerializeField] private Transform resetTarget;
    
    #endregion

    #region Camera_Loop
    void Update()
    {

        if(target!=null)
            transform.position = new Vector2(target.transform.position.x,target.transform.position.y);
        
    }
    
    #endregion
}
