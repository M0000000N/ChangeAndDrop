using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : StageManager
{
    //public Transform StageManager;
    // Start is called before the first frame update
    void Start()
    {
        //Ball = GetComponent<Ball>();
        //StageManager = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
           // CupTransform.position.x -= 0.1f;
        }
    }
}
