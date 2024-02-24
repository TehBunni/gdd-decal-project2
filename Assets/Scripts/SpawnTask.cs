using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTask : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private GameObject taskObject;
    #endregion

    #region Main Updates
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(taskObject);
            // SceneManager.LoadScene (sceneName:"DoorTaskScene");
        }
    }
    #endregion
}
