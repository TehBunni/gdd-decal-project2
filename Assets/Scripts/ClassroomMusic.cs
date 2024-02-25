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
    void Start()
    {
        nowStress = false;
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
    }
}
