using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionZone : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim;
    private void Start()
    {
        audioSource.mute = false;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            anim.SetBool("IsIn", true);
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            anim.SetBool("IsIn", false);
            audioSource.Stop();
        }
    }

}
