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

    private void Awake()
    {
        _Singleton = this;
    }

    private int tasksCompleted;

    public int TasksCompleted => tasksCompleted;

    // Increment the count
    public void IncrementCount()
    {
        tasksCompleted++;
    }
}