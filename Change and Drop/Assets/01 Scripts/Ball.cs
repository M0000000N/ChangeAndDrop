using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // 공관련
    public float MAX_SPEED = 3f;
    [SerializeField] Material[] materials; 

    private Renderer ballColor;
    private static TrailRenderer trailColor;
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
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // 클릭하면 공 색상 변경
        {
            changeColor(ballColor);
        }                
    }

    private void changeColor(Renderer _currentColor)
    {
        ++BallPool.Instance.materialIndex;
        BallPool.Instance.materialIndex %= 2;
        _currentColor.material = materials[BallPool.Instance.materialIndex];
        trailColor.material = _currentColor.material;
    }
    public void Instantiate(Transform _transform)
    {
        if (BallPool.Instance.ballPoolList.Count <=0)
        {
            BallPool.Instance.More();
        }
        GameObject ball = BallPool.Instance.ballPoolList.Dequeue();
        ball.GetComponent<MeshRenderer>().material = materials[BallPool.Instance.materialIndex];
        ball.transform.position = transform.position + new Vector3(0, -1f, 0);
        ball.SetActive(true);
    }
    public void destroy()
    {
        BallPool.Instance.ballPoolList.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Block"))
        {
            destroy();
            Block block = other.GetComponent<Block>();
            if(block.materialIndex == BallPool.Instance.materialIndex)
            {
                for (int i = 0; i < block.CalculateNum; i++)
                {
                    Instantiate(block.transform);
                }
            }
        }
        else if(other.tag.Equals("Bridge"))
        {
            other.GetComponent<Bridge>().TriggerBall();
        }
    }
}
