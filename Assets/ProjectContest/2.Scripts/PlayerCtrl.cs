using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed = 8.0f;
    public float turnSpeed = 100.0f;

    // Start is called before the first frame update
    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetBool("IsWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        // 회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r);

        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        if (v >= 0.1f) // 전진
        {
            anim.SetBool("IsWalking", true);
        }
        else if (v <= -0.1f) // 후진
        {
            anim.SetBool("IsWalking", true);
        }
        else if (h >= 0.1f) // 오른쪽
        {
            anim.SetBool("IsWalking", true);
        }
        else if (h <= -0.1f) // 왼쪽
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }
}
