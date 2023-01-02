using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // ������
    [SerializeField] Material[] materials; 
    public Renderer BallRender { get; private set; } // ������ ����
    private int materialIndex = 0;

    public float MAX_SPEED = 3f;
    private Rigidbody _rigidbody;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void FixedUpdate()
    {
        float currentSpeed = _rigidbody.velocity.magnitude;
        if (currentSpeed >= MAX_SPEED)
        {
            _rigidbody.velocity *= MAX_SPEED / currentSpeed;
        }
    }
    void Start()
    {
        BallRender = gameObject.GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // Ŭ���ϸ� �� ���� ����
        {
            changeColor(BallRender);
        }        
    }

    void changeColor(Renderer currentColor)
    {
        ++materialIndex;
        materialIndex %= 2;

        currentColor.material = materials[materialIndex];
        _trailRenderer.material = currentColor.material;
        Debug.Log($"{currentColor.material}");
    }
}
