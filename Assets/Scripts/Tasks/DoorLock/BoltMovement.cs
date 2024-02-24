using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMovement : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private GameObject m_lock;

    private float currentValue;
    #endregion

    #region Initialization
    private void Start()
    {
        // currentValue = m_lock.transform.rotation.eulerAngles.z;
    }
    #endregion

    #region Main Updates
    private void Update()
    {
        currentValue = m_lock.transform.rotation.eulerAngles.z;
        transform.position = new Vector3(0.85f - ((currentValue - 270) / 100), 0, 0);
    }
    #endregion
}
