using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockRotation : MonoBehaviour
{
    #region Private Variables
    private bool completed;

    private float zAngle;
    #endregion

    #region Initialization
    private void Start()
    {
        completed = false;
        // Debug.Log(transform.rotation.eulerAngles.z);
    }
    #endregion

    #region Main Updates
    private void Update()
    {
        zAngle = transform.rotation.eulerAngles.z;
        // Debug.Log(zAngle);
        if (zAngle <= 270 && zAngle >= 250)
        {
            completed = true;
        }
        if (zAngle >= 35 && zAngle <= 180)
        {
            Debug.Log("wrong way idiot");
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (completed)
        {
            // SceneManager.LoadScene (sceneName:"PlayerMovementTesting");
            gameManager.Singleton.IncrementCount();
            Debug.Log("Current count: " + gameManager.Singleton.TasksCompleted);
            Destroy(transform.parent.gameObject);
        }
    }
    #endregion

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !completed)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            wp.z = 0;

            Vector2 direction = new Vector2(wp.x - transform.position.x, wp.y - transform.position.y);
            transform.up = direction;
        }
    }
}
