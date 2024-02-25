using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Dialogue that spawns after the task is completed")]
    private GameObject nextDialogue;

    private AudioSource source;
    public AudioClip clip;
    #endregion

    #region Private Variables
    // Task completed?
    private bool completed;

    // Current rotation angle of the lock
    private float zAngle;

    // Player gameObject
    private GameObject player;

    // Canvas gameObject
    private GameObject canvas;
    #endregion

    #region Initialization
    private void Start()
    {
        completed = false;
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
        source = GameObject.Find("gameManager").GetComponent<AudioSource>();
    }
    #endregion

    #region Main Updates
    private void Update()
    {
        zAngle = transform.rotation.eulerAngles.z;

        // User corretly spun the lock to lock the door
        if (zAngle <= 270 && zAngle >= 250)
        {
            completed = true;
        }

        // User spun the lock the wrong way
        if (zAngle >= 35 && zAngle <= 180)
        {
            Debug.Log("wrong way idiot");
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Triggers when task is completed
        if (completed)
        {
            source.PlayOneShot(clip);

            // Increment current task number
            gameManager.Singleton.IncrementCount();
            Debug.Log("Current count: " + gameManager.Singleton.TasksCompleted);

            player.GetComponent<PlayerMovement>().ToggleMove(); // Unfreeze the Player movement
            
            Instantiate(nextDialogue, canvas.transform); // Instantiate next dialogue

            Destroy(transform.parent.parent.gameObject); // Destroy gameObject
        }
    }
    #endregion

    private void OnMouseOver()
    {
        // Lock rotation calculations
        if (Input.GetKey(KeyCode.Mouse0) && !completed)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            wp.z = 0;

            Vector2 direction = new Vector2(wp.x - transform.position.x, wp.y - transform.position.y);
            transform.up = direction;
        }
    }
}
