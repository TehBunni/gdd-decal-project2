using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTask : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private GameObject taskObject;

    [SerializeField]
    private GameObject mainCamera;
    #endregion

    #region Main Updates
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 spawnPosition = mainCamera.transform.position;
            spawnPosition.z = 0;
            Instantiate(taskObject, spawnPosition, Quaternion.identity);
            // SceneManager.LoadScene (sceneName:"DoorTaskScene");
        }
    }
    #endregion
}
