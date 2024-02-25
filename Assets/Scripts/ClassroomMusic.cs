using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomMusic : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public AudioClip snore;
    public AudioClip stress;
    private bool nowStress;
    private bool nowExplode;
    public AudioClip explode;
    void Start()
    {
        nowStress = false;
        nowExplode = false;
        source.clip = clip;
        source.Play();
        source.PlayOneShot(snore);
    }

    void Update()
    {
        if (gameManager.Singleton.TasksCompleted == 3 && !nowStress) {
            nowStress = true;
            source.Stop();
            source.volume = 0.5f;
            source.clip = stress;
            source.Play();
        }

        if (gameManager.Singleton.TasksCompleted == 11 && !nowExplode)
        {
            nowExplode = true;
            source.Stop();
            source.volume = 0.5f;
            source.clip = explode;
            source.Play();
        }
    }
}
