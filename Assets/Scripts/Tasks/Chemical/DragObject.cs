using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Explosion gameObject")]
    private GameObject explosion;

    [SerializeField]
    [Tooltip("Broken Beaker gameObject")]
    private GameObject brokenBeaker;

    [SerializeField]
    [Tooltip("Dialogue that spawns after the task is completed")]
    private GameObject nextDialogue;

    private AudioSource source;
    public AudioClip clipExplosion;
    #endregion

    #region Private Variables
    // Tracks if the gameObject is being dragged
    private bool isDragging = false;
    
    // Tracks the offset of the mouse click on the gameObject
    private Vector3 offset;

    // Canvas gameObject
    private GameObject canvas;
    #endregion

    #region Initialization
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        source = GameObject.Find("gameManager").GetComponent<AudioSource>();
    }
    #endregion

    #region Main Updates
    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.CompareTag("Water") && !isDragging)
		{
			// Instantiate(explosion, transform.parent.gameObject.transform); // Instantiate explosion
            
             // Instantiate broken beaker
            Vector3 spawnPosition = brokenBeaker.gameObject.transform.position + transform.parent.gameObject.transform.position;
            spawnPosition.z = 0;
            GameObject newBeaker = Instantiate(brokenBeaker, spawnPosition, Quaternion.identity);
            newBeaker.transform.parent = transform.parent.gameObject.transform;
            // Instantiate(brokenBeaker, transform.parent.gameObject.transform);

            source.PlayOneShot(clipExplosion);

            Destroy(other.gameObject); // destory beaker
            Destroy(gameObject); // destroy sodium

            Instantiate(nextDialogue, canvas.transform); // Spawn reaction dialogue
		}
	}
    #endregion
}
