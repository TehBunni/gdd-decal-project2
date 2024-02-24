using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private Transform player;
    #endregion

    #region Main Updates
    void Update () {
        // transform.position = player.transform.position + new Vector3(0, 0, -5);
        transform.position = new Vector3(0, player.transform.position.y, -5);
    }
    #endregion
}
