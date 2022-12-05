using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCtrl : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            anim1.SetBool("IsOpen", true);
            anim2.SetBool("IsOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            anim1.SetBool("IsOpen", false);
            anim2.SetBool("IsOpen", false);
        }
    }
}
