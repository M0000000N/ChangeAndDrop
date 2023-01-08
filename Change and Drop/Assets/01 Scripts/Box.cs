using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int CalculateNum; // ���� ����
    private int TriggerNum = 0;
    private Rigidbody _boxRigidbody;

    void Start()
    {
        _boxRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (TriggerNum == CalculateNum)
        {
            _boxRigidbody.useGravity = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            TriggerNum++;
        }
    }
}
