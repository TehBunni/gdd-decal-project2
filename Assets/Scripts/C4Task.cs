using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class C4Task : MonoBehaviour
{
    //record the characters of the buttons that the user clicks
    //reset after 4 guesses at the code
    //button click -> code registers it and records it in a global array
    //check the order of the global array 
    //there are eleven different buttons -> 0-9, enter
    #region Editor Variables
    [SerializeField]
    [Tooltip("Put c4 GameObject here")]
    private GameObject c4; 
    #endregion

    #region Global Variables
    public static class Globals {
        public static List<string> m_password_array = new List<string>();
    }
    #endregion

    #region Private Variables
    private string m_password;
    #endregion

    #region Public Variables
    // UI Buttons linked in the Inspector: TBD
    public Button m_Button1, m_Button2, m_Button3, m_Button4, m_Button5, m_Button6, m_Button7, m_Button8, m_Button9;
    //m_Button1 = new Button();

    #endregion


    #region Initialization
    // Start is called before the first frame update
    private void Awake()
    {
        m_password = "1914";
        Cursor.lockState = CursorLockMode.None;
        //m_Button1 = c4.AddComponent<Button>();
        m_Button1 = c4.GetComponent<Button>();
        m_Button2 = c4.GetComponent<Button>();
        m_Button3 = c4.GetComponent<Button>();
        m_Button4 = c4.GetComponent<Button>();
        m_Button5 = c4.GetComponent<Button>();
        m_Button6 = c4.GetComponent<Button>();
        m_Button7 = c4.GetComponent<Button>();
        m_Button8 = c4.GetComponent<Button>();
        m_Button9 = c4.GetComponent<Button>();

    }
    void Start()
    {
        // Listens for the click of any of the buttons in scene
        

        Debug.Log(m_Button1);
        //m_Button1.GetComponent<Button>().onClick.AddListener(() => Execute(jumps[intIndex]));

        m_Button1.onClick.AddListener(delegate { MakePasswordString("1"); });
        m_Button2.onClick.AddListener(delegate { MakePasswordString("2"); });
        m_Button3.onClick.AddListener(delegate { MakePasswordString("3"); });
        m_Button4.onClick.AddListener(delegate { MakePasswordString("4"); });
        m_Button5.onClick.AddListener(delegate { MakePasswordString("5"); });
        m_Button6.onClick.AddListener(delegate { MakePasswordString("6"); });
        m_Button7.onClick.AddListener(delegate { MakePasswordString("7"); });
        m_Button8.onClick.AddListener(delegate { MakePasswordString("8"); });
        m_Button9.onClick.AddListener(delegate { MakePasswordString("9"); });
               
    }
    #endregion

    #region Update Methods
    // Update is called once per frame
    void Update()
    {

    //string password_input = Input.get;


    }
    #endregion

    #region Task Methods
    public void MakePasswordString(string button_name) {
    // C4 can only take 4 digits 
        if ((Globals.m_password_array.Count) < 4)
        {
            //Quick UI explanation if you click 1 and then 2 to for password 12_ _ 
            //****
            //***1
            //**12
            Globals.m_password_array.Add(button_name);
        }
        // C4 has 4 digits
        else {
        //check to see if password is right
            if (Password())
            {
                //task is completed
                //TO DO: In between switching scenes there should be a 'you did it!' 
                SceneManager.LoadScene("ClassroomScene");
            }
            //Reset global array if 4 digits and then add the new digit
            else
            {
                //1234 
                Globals.m_password_array = new List<string>();
                //****
                Globals.m_password_array.Add(button_name);
                //***1
            }
        }

    }

    private bool Password() {
    //string combinedString = string.Join(",", Globals.m_password_array.ToArray());
        List<string> passwordToString = new List<string> {m_password};
        Debug.Log(passwordToString);
        for (int i = 0; i < 5; i++) {
            if (passwordToString[i] != Globals.m_password_array[i]) {
                return false;
                }
        }
        return true;

    }
    #endregion


//SceneManager.LoadScene("C4Task");

}
