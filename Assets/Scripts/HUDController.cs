using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    #region Editor Variables
    //[SerializeField]
    //[Tooltip("How many tasks out of 4 have been completed")]
    //private RectTransform m_Tasks;
    #endregion

    #region Private Variables
    private int p_TasksCompleted;
    #endregion

    #region Public Variables
    public Image[] HUDTasks;
    public Sprite taskNotDone;
    public Sprite taskDone;
    #endregion

    #region Initialization
    private void Awake()
    {
        p_TasksCompleted = 0;

    }
    #endregion


    #region Update Health Bar
    public void Update()
    {
        if (p_TasksCompleted > 4) {
            p_TasksCompleted = 4;
        }
        for (int i = 0; i < HUDTasks.Length; i++) {
            if (i > p_TasksCompleted)
            {
                HUDTasks[i].sprite = taskNotDone;
            }
            else {
                HUDTasks[i].sprite = taskDone;
            }
            if (i < 5)
            {
                HUDTasks[i].enabled = true;
            }
            else {
                HUDTasks[i].enabled = false;
            }
        }
    }
    #endregion
}