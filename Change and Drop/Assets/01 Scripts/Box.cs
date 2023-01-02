using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int CalculateNum; // ���� ����
    [SerializeField]
    enum Color
    {
        PUPLE,
        YELLOW,
    }
    private Color color;
    private int TriggerNum = 0;
    private Rigidbody _boxRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _boxRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerNum == CalculateNum)
        {
            _boxRigidbody.useGravity = true;
        }
    }
}
