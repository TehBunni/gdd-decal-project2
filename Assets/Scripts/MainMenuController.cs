using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    #region Editor Variables
    //[SerializeField]
    //[Tooltip("Text component with the HS")]
    //private Text m_HighScore;
    #endregion

    #region Private Variables
    private string m_DefaultHighScoreText;
    #endregion

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

    #region Play Button Methods
    public void PlayClassroom()
    {
        SceneManager.LoadScene("Classroom");
    }
    #endregion

    #region Menu Button Methods
    public void PlayMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    #endregion

    #region Credits Button Methods
    public void PlayCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    #endregion



    #region General Application Button Methods
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    /**
    #region High Score Methods
    private void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("HS"))
        {
            m_HighScore.text = m_DefaultHighScoreText.Replace("%S", PlayerPrefs.GetInt("HS").ToString());
        }
        else
        {
            PlayerPrefs.SetInt("HS", 0);
            m_HighScore.text = m_DefaultHighScoreText.Replace("%S", "0");
        }
    }
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HS", 0);
        UpdateHighScore();
    }
    */

    //#endregion
}
