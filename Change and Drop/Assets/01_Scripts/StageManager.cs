using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // 공 생성 관련
    public GameObject BallPrefeb;
    public Transform StartPosition;
    private int _currentBallCount;

    // 컵 관련
    public GameObject CupPrefeb;
    public float rotationSpeed = 50;

    // 게임 시작
    public static bool isStart = false;
    void Start()
    {
        _currentBallCount = Random.Range(10,20);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !isStart)
        {
            CupPrefeb.transform.position += new Vector3(0.03f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isStart)
        {
            CupPrefeb.transform.position -= new Vector3(0.03f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isStart)
        {
            BallSpawn(_currentBallCount);
        }
    }
    void BallSpawn(int n)
    {
        isStart = true;
        //Quaternion newRotation = Quaternion.Euler(90f, 0f, 0f);
        //CupPrefeb.transform.rotation = Quaternion.Slerp(CupPrefeb.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        while (CupPrefeb.transform.rotation != Quaternion.Euler(90, 0, 0))
        {
            //Quaternion newRotation = Quaternion.Euler(90f, 0f, 0f);
            //CupPrefeb.transform.rotation = Quaternion.Slerp(CupPrefeb.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
            CupPrefeb.transform.Rotate(0.1f * Time.deltaTime, 0.0f, 0.0f);
            CupPrefeb.transform.Rotate(new Vector3(1, 0, 0), Time.deltaTime * rotationSpeed);
        }
        if (isStart)
        {
            for (int i = 0; i < _currentBallCount; i++)
            {
                Instantiate(BallPrefeb, StartPosition.position, StartPosition.rotation);
            }
            Debug.Log($"공{_currentBallCount}개 생성");
        }
    }
    public int sum(int count)
    {
        int _sum = count;
        return _sum;
    }

    void spawn()
    {
       // GameObject ball = Instantiate(ball);
    }
    
}
