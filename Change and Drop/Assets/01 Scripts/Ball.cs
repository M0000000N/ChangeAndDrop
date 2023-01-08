using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ������
    public float MAX_SPEED = 3f;
    public int materialIndex = 0; // 0:���, 1: ����
    [SerializeField] Material[] materials; 

    private Renderer ballColor;
    private TrailRenderer trailColor;
    private Rigidbody rigidbody;

    private void Awake()
    {
        ballColor = GetComponent<MeshRenderer>();
        trailColor = GetComponent<TrailRenderer>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // �ִ� �ӵ� ����
    private void FixedUpdate()
    {
        float currentSpeed = rigidbody.velocity.magnitude;
        if (currentSpeed >= MAX_SPEED)
        {
            rigidbody.velocity *= MAX_SPEED / currentSpeed;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // Ŭ���ϸ� �� ���� ����
        {
            changeColor(ballColor);
        }        
    }

    void changeColor(Renderer _currentColor)
    {
        ++materialIndex;
        materialIndex %= 2;
        _currentColor.material = materials[materialIndex];
        trailColor.material = _currentColor.material;
    }
}
