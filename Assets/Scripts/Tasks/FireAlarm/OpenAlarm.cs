using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAlarm : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private Sprite openAlarmSprite;

    [SerializeField]
    private GameObject[] alarmWires;
    #endregion

    #region Private Variables
    private SpriteRenderer spriteRenderer;

    private bool alarmOpen;

    // private GameObject mainCamera;
    #endregion

    #region Initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        alarmOpen = false;
    }
    #endregion

    #region Main Updates
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !alarmOpen)
        {
            spriteRenderer.sprite = openAlarmSprite;
            alarmOpen = true;
            foreach (GameObject wire in alarmWires)
            {
                Instantiate(wire);
            }
        }
    }
    #endregion
}
