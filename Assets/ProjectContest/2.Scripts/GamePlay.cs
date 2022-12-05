using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public float noteSpeed = 400;

    void Start()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
