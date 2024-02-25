using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWire : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Cut wire sprite")]
    private Sprite cutWireSprite;
    #endregion

    #region Private Variables
    // this wire's spriteRenderer
    private SpriteRenderer spriteRenderer;

    // Alarm Box gameObject
    private GameObject alarmBox;

    // Tracks if the wire is cut
    private bool cut;
    #endregion

    #region Initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        alarmBox = GameObject.Find("AlarmBox");
        cut = false;
    }
    #endregion

    #region Main Updates
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !cut)
        {
            cut = true;
            spriteRenderer.sprite = cutWireSprite;
            alarmBox.GetComponent<OpenAlarm>().IncrementWireCount();
        }
    }
    #endregion
}
