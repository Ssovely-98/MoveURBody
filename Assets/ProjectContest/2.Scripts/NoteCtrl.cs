using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCtrl : MonoBehaviour
{
    public float noteSpeed = 400.0f;

    UnityEngine.UI.Image noteImage;

    void Start()
    {
        //if(noteImage==null)
        noteImage = GetComponent<UnityEngine.UI.Image>();

        //noteImage.enabled = true;
    }


    private void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }

    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
} 
