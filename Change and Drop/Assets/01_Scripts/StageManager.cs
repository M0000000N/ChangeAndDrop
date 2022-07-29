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
        //CupPrefeb = GetComponent<GameObject>();
        // 공 랜덤생성
        _currentBallCount = Random.Range(3, 8);
       
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !isStart)
        {
            CupPrefeb.transform.position += new Vector3(0.01f, 0, 0);
            Debug.Log($"왼쪽으로간다");

        }
        if (Input.GetKey(KeyCode.RightArrow) && !isStart)
        {
            CupPrefeb.transform.position -= new Vector3(0.01f, 0, 0);
            Debug.Log($"오른쪽으로간다");

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isStart)
        {
            BallSpawn(_currentBallCount);

        }
        //if (BlockColor.material == _ball.CurrentBallColor)
        //{
        //    Debug.Log("똑같은색");
        //}
        //else
        //{
        //    Debug.Log("다른색");
        //}
    }
    void BallSpawn(int n)
    {
        isStart = true;
            Quaternion newRotation = Quaternion.Euler(90, 0, 0);
            CupPrefeb.transform.rotation = Quaternion.Slerp(CupPrefeb.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        
        while (CupPrefeb.transform.rotation != Quaternion.Euler(90, 0, 0))
        {
            //CupPrefeb.transform.Rotate(0.1f * Time.deltaTime, 0.0f, 0.0f);
            //CupPrefeb.transform.Rotate(new Vector3(1, 0, 0), Time.deltaTime * rotationSpeed);
        }
        Debug.Log($"돈다");

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
