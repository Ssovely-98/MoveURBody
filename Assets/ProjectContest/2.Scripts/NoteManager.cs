using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;
    [SerializeField] GameObject goNote = null;

    EffectManager theEffectManager;
    TimingManager theTimingManager;

    private void Start()
    {
        theEffectManager = FindObjectOfType<EffectManager>();
        theTimingManager = GetComponent<TimingManager>();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime>=60d/bpm) //60/Bpm = 1 beat 등장시간
        {
            //GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
            //t_note.transform.position = tfNoteAppear.position;
            //t_note.SetActive(true);
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            if(collision.GetComponent<NoteCtrl>().GetNoteFlag())
                theEffectManager.JudgementEffect(4);

            theTimingManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);

            //ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            //collision.gameObject.SetActive(false);

        }
    }
}
