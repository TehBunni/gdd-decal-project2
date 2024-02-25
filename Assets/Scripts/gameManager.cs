using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class gameManager : MonoBehaviour
{
    private static gameManager _Singleton;

    public static gameManager Singleton
    {
        get
        {
            return _Singleton;
        }
    }

    public AudioSource source;
    // public AudioClip clip;
    public AudioClip click;

    private void Awake()
    {
        _Singleton = this;
    }

    private void Start() {
        // source.PlayOneShot(clip);
    }

    private int tasksCompleted;

    public int TasksCompleted => tasksCompleted;

    // Increment the count
    public void IncrementCount()
    {
        tasksCompleted++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            source.PlayOneShot(click);
        }
    }
}