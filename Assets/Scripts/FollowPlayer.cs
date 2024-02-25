using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Player transform component")]
    private Transform player;
    #endregion

    #region Main Updates
    void Update () {
        // Move camera vertically alongside the player
        transform.position = new Vector3(0, player.transform.position.y, -5);
    }
    #endregion
}
