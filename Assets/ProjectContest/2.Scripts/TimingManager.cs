using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>(); //������ ��Ʈ�� ���� ����Ʈ

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null; //��������
    Vector2[] timingBoxes = null; //�������� �ִ밪(x), �ּҰ�(y)

    EffectManager theEffect;
    ScoreManager theScoreManager;
    PlayerHealth thePlayerHealth;

    private void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlayerHealth = FindObjectOfType<PlayerHealth>();
        //Ÿ�̹� �ڽ� ����
        timingBoxes = new Vector2[timingRect.Length];

        for(int i=0; i<timingRect.Length;i++)
        {
            timingBoxes[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2, Center.localPosition.x + timingRect[i].rect.width / 2); // �ּҰ�: �߽�-(�̹����� �ʺ�/2) , �ִ밪: �߽�+(�̹����� �ʺ�/2)
        }
    }

    public void CheckTiming()
    {
        for(int i=0;i<boxNoteList.Count;i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;

            for(int x=0;x<timingBoxes.Length;x++)
            {
                if(timingBoxes[x].x<=t_notePosX && t_notePosX<=timingBoxes[x].y)
                {
                    //��Ʈ ����
                    boxNoteList[i].GetComponent<NoteCtrl>().HideNote();
                    boxNoteList.RemoveAt(i);

                    //����Ʈ ����
                    if (x<timingBoxes.Length-1)
                        theEffect.NoteHitEffect();
                    theEffect.JudgementEffect(x);

                    //���� ����
                    theScoreManager.IncreaseScore(x);

                    //������
                    thePlayerHealth.TakeDamage(x);
                    return;
                }

            }
        }
        theEffect.JudgementEffect(4);
        thePlayerHealth.TakeDamage(4);
    }
}
