using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int CalculateNum; // ���� ����
    private int TriggerNum = 0;
    private Rigidbody boxRigidbody;

    void Start()
    {
        boxRigidbody = GetComponent<Rigidbody>();
        boxRigidbody.useGravity = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            TriggerNum++;
        }
        if (TriggerNum >= CalculateNum)
        {
            boxRigidbody.useGravity = true;
        }
    }
}
