using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private GameObject explosion;
    #endregion

    #region Private Variables
    private bool isDragging = false;
    private Vector3 offset;
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
			Instantiate(explosion);
            Destroy(other.gameObject);
            Destroy(gameObject);
		}
	}
    #endregion
}
