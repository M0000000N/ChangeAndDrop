using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    // 공 생성 관련
    public GameObject BallPrefeb;
    public Transform StartPosition;
    public int CurrentBallCount;

    // 컵 관련
    public GameObject CupPrefeb;
    public float rotationSpeed;

    // 게임 시작
    public static bool isStart;

    public void Initialized()
    {
        isStart = false;
        rotationSpeed = 50;
    }
    void Start()
    {
        Initialized();
        CurrentBallCount = Random.Range(1, 2);
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
            BallSpawn(CurrentBallCount);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Initialized();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void BallSpawn(int n)
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
            for (int i = 0; i < CurrentBallCount; i++)
            {
                Instantiate(BallPrefeb, StartPosition.position, StartPosition.rotation);
            }
        }
    }
 
}
