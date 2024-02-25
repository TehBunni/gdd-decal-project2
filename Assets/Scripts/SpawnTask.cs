using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTask : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Task object that need to be spawned in")]
    private GameObject taskObject;

    [SerializeField]
    [Tooltip("Main Camera gameObject")]
    private GameObject mainCamera;

    [SerializeField]
    [Tooltip("Task Number determined by next task (gameManager Singleton)")]
    private int taskNumber;

    [SerializeField]
    [Tooltip("Dialogue that spawns during the task")]
    private GameObject nextDialogue;

    [SerializeField]
    [Tooltip("C4 gameObject that is in the Canvas")]
    private GameObject c4;
    #endregion

    #region Private Variables
    // Player gameObject
    private GameObject player;

    // Canvas gameObject
    private GameObject canvas;
    #endregion

    #region Initialization
    private void Start()
    {
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
    }
    #endregion

    #region Main Updates
    void OnMouseOver()
    {
        // Activate button if current task is ready
        if (Input.GetKeyDown(KeyCode.Mouse0) && gameManager.Singleton.TasksCompleted == taskNumber)
        {
            if (taskObject == null)
            {
                // Spawn C4
                c4.SetActive(true);
            }
            else
            {
                // Spawn other tasks
                Vector3 spawnPosition = mainCamera.transform.position;
                spawnPosition.z = 0;
                Instantiate(taskObject, spawnPosition, Quaternion.identity);
            }

            player.GetComponent<PlayerMovement>().ToggleMove(); // Freeze the player

            // Increment task number
            gameManager.Singleton.IncrementCount();
            Debug.Log("Current count: " + gameManager.Singleton.TasksCompleted);

            // Spawn task dialogue if not null
            if (nextDialogue != null)
            {
                Instantiate(nextDialogue, canvas.transform);
            }
        }
    }
    #endregion
}
