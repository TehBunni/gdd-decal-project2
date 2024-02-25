using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalTask : MonoBehaviour
{
    #region Private Variables
    // Player gameObject
    private GameObject player;
    #endregion
    
    #region Initialization
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    #endregion

    #region Main Updates
    private void Update()
    {
        // Check if task in completed
        if (gameManager.Singleton.TasksCompleted == 3)
        {
            player.GetComponent<PlayerMovement>().ToggleMove(); // Unfreeze the Player
            Destroy(gameObject); // Destroy the task
        }
    }
    #endregion
}
