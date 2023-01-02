using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup: MonoBehaviour
{
    public float rotationSpeed = 50;
    private bool isOn;
    public void OnEnable()
    {
        isOn = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(isOn)
        {
            moveInput();
        }
    }
    private void moveInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(0.03f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position -= new Vector3(0.03f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            while (transform.rotation != Quaternion.Euler(90, 0, 0))
            {
                transform.Rotate(0.1f * Time.deltaTime, 0.0f, 0.0f);
                transform.Rotate(new Vector3(1, 0, 0), Time.deltaTime * rotationSpeed);
            }
            gameObject.SetActive(false);
        }
    }
}
