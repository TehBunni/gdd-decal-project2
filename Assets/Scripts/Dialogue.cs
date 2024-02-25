using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("TextMeshProUGUI component in dialogue gameObject")]
    private TextMeshProUGUI textComponent;

    [SerializeField]
    [Tooltip("Dialogue lines")]
    private string[] lines;

    [SerializeField]
    [Tooltip("Speed of text typing animation (1-100)")]
    private float textSpeed;
    #endregion

    #region Private Variables
    // Keeps track of the current dialogue line
    private int index;
    #endregion

    #region Initialization
    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }
    #endregion

    #region Main Updates
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    // Typing animation
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed / 100);
        }
    }

    // Move on to the next dialogue line
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

            // Incremenet task number
            if (index == lines.Length - 1)
            {
                gameManager.Singleton.IncrementCount();
                Debug.Log("Current count: " + gameManager.Singleton.TasksCompleted);
            }

            // Incremenet task number after chemical explosion
            if (index == 3 && lines[3] == "[Mr. Rocks]: You clearly weren’t… step away from the lab station.")
            {
                gameManager.Singleton.IncrementCount();
                Debug.Log("Current count: " + gameManager.Singleton.TasksCompleted);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    #endregion
}
