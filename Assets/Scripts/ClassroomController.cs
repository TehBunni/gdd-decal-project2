using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClassroomController : MonoBehaviour
{

    #region Initialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        
        //m_DefaultHighScoreText = m_HighScore.text;
    }
    public void Start()
    {
        //   UpdateHighScore();
    }
    #endregion

   
    #region Task Button Methods
    public void C4Task()
    {
        SceneManager.LoadScene("C4Task");
    }
    public void LockingDoorTask()
    {
        SceneManager.LoadScene("LockingDoorTask");
    }
    public void ChemicalTableTask()
    {
        SceneManager.LoadScene("ChemicalTableTask");
    }
    public void FireAlarmTask()
    {
        SceneManager.LoadScene("FireAlarmTask");
    }
    #endregion



   
}
