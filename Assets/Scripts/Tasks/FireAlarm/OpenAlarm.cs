using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAlarm : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Open Alarm Sprite")]
    private Sprite openAlarmSprite;

    [SerializeField]
    [Tooltip("Array of wire prefabs")]
    private GameObject[] alarmWires;

    [SerializeField]
    [Tooltip("Dialogue that spawns after the task is completed")]
    private GameObject nextDialogue;

    private AudioSource source;
    public AudioClip clip;
    #endregion

    #region Private Variables
    // this Alarm's spriteRenderer
    private SpriteRenderer spriteRenderer;

    // Is the alarm open?
    private bool alarmOpen;

    // Main Camera gameObject
    private GameObject mainCamera;

    // Tracks task completion
    private bool completed;

    // Tracks how many wires need to be cut before task completion
    private int wireCount;

    // Player gameObject
    private GameObject player;

    // Canvas gameObject
    private GameObject canvas;

    private int clickCount;
    #endregion

    #region Initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        alarmOpen = false;
        mainCamera = GameObject.Find("Main Camera");
        completed = false;
        wireCount = 0;
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
        source = GameObject.Find("gameManager").GetComponent<AudioSource>();
        clickCount = 0;
    }
    #endregion

    #region Main Updates
    private void OnMouseOver()
    {
        // Open alarm box
        if (Input.GetKeyDown(KeyCode.Mouse0) && !alarmOpen)
        {
            spriteRenderer.sprite = openAlarmSprite;
            alarmOpen = true;
            source.PlayOneShot(clip);
            // Instantiate all wires
            foreach (GameObject wire in alarmWires)
            {
                Vector3 spawnPosition = wire.gameObject.transform.position + gameObject.transform.position;
                spawnPosition.z = 0;
                GameObject instantiatedWire = Instantiate(wire, spawnPosition, Quaternion.identity);
                instantiatedWire.transform.parent = transform;
            }
            player.gameObject.GetComponent<BoxCollider2D>().enabled = false; // Turn off player BoxCollider2D
        }
    }

    public void IncrementWireCount()
    {
        wireCount++;
        if (wireCount == 3)
        {
            completed = true;
        }
    }

    private void Update()
    {
        if (completed)
        {
            // Increment task number
            gameManager.Singleton.IncrementCount();
            Debug.Log("Current count: " + gameManager.Singleton.TasksCompleted);

            player.gameObject.GetComponent<BoxCollider2D>().enabled = true; // re-enable player BoxCollider2D
            player.GetComponent<PlayerMovement>().ToggleMove(); // Unfreeze the player

            Instantiate(nextDialogue, canvas.transform); // Instantiate next dialogue

            Destroy(transform.parent.gameObject); // Destroy task
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && alarmOpen) {
            clickCount++;
        }

        if (clickCount > 10) {
            completed = true;
        }

        Debug.Log(clickCount);
    }
    #endregion
}
