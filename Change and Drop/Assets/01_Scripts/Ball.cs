using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // 공관련
    [SerializeField] Material[] materials; 
    public Renderer BallRender { get; private set; } // 공색상 설정
    private int materialIndex = 0;

    public float MAX_SPEED = 3f;
    private Rigidbody _rigidbody;
    private TrailRenderer _trailRenderer;

    // 스테이지 메니저
    public StageManager StageManager;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StageManager = GetComponent<StageManager>();
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

    private void OnEnable()
    {
        if (StageManager.isStart)
        {
            //_trailRenderer.isVisible;
        }
    }

    void Start()
    {
        BallRender = gameObject.GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // 클릭하면 공 색상 변경
        {
            changeColor(BallRender);
        }        
    }

    void changeColor(Renderer currentColor)
    {
        ++materialIndex;
        materialIndex %= 2;

        currentColor.material = materials[materialIndex];
        Debug.Log($"{currentColor.material} 입니다");
    }
}
