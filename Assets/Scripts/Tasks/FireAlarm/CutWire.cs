using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWire : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private Sprite cutWireSprite;
    #endregion

    #region Private Variables
    private SpriteRenderer spriteRenderer;
    #endregion

    #region Initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion

    #region Main Updates
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            spriteRenderer.sprite = cutWireSprite;
        }
    }
    #endregion
}
