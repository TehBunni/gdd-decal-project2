using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class C4Task : MonoBehaviour
{


    #region Private Variables
    private string m_password;
    #endregion

    #region Public Variables
    // UI Buttons linked in the Inspector: TBD
    public TextMeshProUGUI m_keypad_input;
    //m_Button1 = new Button();

    #endregion




    #region Initialization
    // Start is called before the first frame update

    private void Awake()
    {
        m_password = "1914";
        Cursor.lockState = CursorLockMode.None;

    }
    
    private void OnEnable()
    {
        m_keypad_input.text = string.Empty;

    }

    #endregion


    #region Task Methods
    public void MakePasswordString(int button_name) {
    // C4 can only take 4 digits 
        if ((m_keypad_input.text.Length) < 4)
        {
            //Quick UI explanation if you click 1 and then 2 to for password 12_ _ 
            //****
            //***1
            //**12
            m_keypad_input.text += button_name; 
        }
        // C4 has 4 digits
        else {
        //check to see if password is right
            if (Password())
            {
                //task is completed
                //TO DO: In between switching scenes there should be a 'you did it!'
                // Delete prefab
                m_keypad_input.text = "Correct!";
                //yield return new WaitForSeconds(3);
                //GameObject c4 = .GetComponent<GameObject>();
                //SceneManager.LoadScene("Classroom");
            }
            //Reset global array if 4 digits and then add the new digit
            else
            {
                m_keypad_input.text = "Try again.";
                //1234 
                m_keypad_input.text = string.Empty; // FLAG for error
                //****
                m_keypad_input.text += button_name;
                //***1
            }
        }

    }

    private bool Password() {
        return m_keypad_input.text == m_password;

    }
    #endregion



}
