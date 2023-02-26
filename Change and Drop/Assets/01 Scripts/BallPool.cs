using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : SingletonBehaviour<BallPool>
{
    public Queue<GameObject> ballPoolList;
    public int materialIndex = 0; // 0:³ë¶û, 1: º¸¶ó
    [SerializeField] GameObject ballPrefeb;

    private int firstSpawn = 5;
    private int firstInstantiate = 100;
    public Transform StartPosition;

    void Start()
    {
        Initioalize();
    }
    private void Initioalize()
    {
        ballPoolList = new Queue<GameObject>();

        for (int i = 0; i < firstInstantiate; i++)
        {
            GameObject ball = Instantiate(ballPrefeb);
            ball.transform.position = StartPosition.position;
            if (i < firstSpawn)
            {
                ball.SetActive(true);
            }
            else
            {
                ball.SetActive(false);
            }
            ballPoolList.Enqueue(ball);
            ball.transform.SetParent(this.transform);
        }
    }
    public void More()
    {
        for (int i = 0; i < firstInstantiate; i++)
        {
            GameObject ball = Instantiate(ballPrefeb);
            ball.transform.position = StartPosition.position;
            ball.SetActive(false);
            ballPoolList.Enqueue(ball);
            ball.transform.SetParent(this.transform);
        }
    }
}