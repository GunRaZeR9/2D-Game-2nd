using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{   
    #region Restart_Incap_Fields
    public GameObject gameOverPanel;
    #endregion

    #region Restart_Loop
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null){
            gameOverPanel.SetActive(true);
        
        }
    }
    #endregion
    
    #region Restart_Function
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
}
