using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // 공관련
    public float MAX_SPEED = 3f;
    public int materialIndex = 0; // 0:노랑, 1: 보라
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

    // 최대 속도 조절
    private void FixedUpdate()
    {
        float currentSpeed = rigidbody.velocity.magnitude;
        if (currentSpeed >= MAX_SPEED)
        {
            rigidbody.velocity *= MAX_SPEED / currentSpeed;
        }
        if(Input.GetKeyDown(KeyCode.Space)) // 클릭하면 공 색상 변경
        {
            changeColor(ballColor);
        }        
    }

    private void changeColor(Renderer _currentColor)
    {
        ++materialIndex;
        materialIndex %= 2;
        _currentColor.material = materials[materialIndex];
        trailColor.material = _currentColor.material;
    }
    public void Instantiate(Transform _transform)
    {
        if (BallPool.Instance.ballPoolList.Count <=0)
        {
            BallPool.Instance.More();
        }
        GameObject ball = BallPool.Instance.ballPoolList.Dequeue();
        ball.GetComponent<MeshRenderer>().material = materials[materialIndex];
        ball.transform.position = _transform.position + new Vector3(0, -1f, 0);
        ball.SetActive(true);
    }
    public void destroy()
    {
        BallPool.Instance.ballPoolList.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
}
