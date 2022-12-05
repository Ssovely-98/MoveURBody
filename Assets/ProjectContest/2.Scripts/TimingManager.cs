using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>(); //생성된 노트를 담을 리스트

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null; //판정범위
    Vector2[] timingBoxes = null; //판정범위 최대값(x), 최소값(y)

    EffectManager theEffect;
    ScoreManager theScoreManager;
    PlayerHealth thePlayerHealth;

    private void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlayerHealth = FindObjectOfType<PlayerHealth>();
        //타이밍 박스 설정
        timingBoxes = new Vector2[timingRect.Length];

        for(int i=0; i<timingRect.Length;i++)
        {
            timingBoxes[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2, Center.localPosition.x + timingRect[i].rect.width / 2); // 최소값: 중심-(이미지의 너비/2) , 최대값: 중심+(이미지의 너비/2)
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
                    //노트 제거
                    boxNoteList[i].GetComponent<NoteCtrl>().HideNote();
                    boxNoteList.RemoveAt(i);

                    //이펙트 연출
                    if (x<timingBoxes.Length-1)
                        theEffect.NoteHitEffect();
                    theEffect.JudgementEffect(x);

                    //점수 증가
                    theScoreManager.IncreaseScore(x);

                    //데미지
                    thePlayerHealth.TakeDamage(x);
                    return;
                }

            }
        }
        theEffect.JudgementEffect(4);
        thePlayerHealth.TakeDamage(4);
    }
}
