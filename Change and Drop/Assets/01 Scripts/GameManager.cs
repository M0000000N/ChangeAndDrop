using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    // 공 생성 관련
    public GameObject BallPrefeb;
    public Transform StartPosition;

    // 컵 관련
    [SerializeField] Cup[] cups;

    // 게임 시작
    public static bool isStart;
    public int round { get; set; }
    public void Initialized()
    {
        round = 0;
        isStart = false;
    }
    private void Awake()
    {
        Initialized();
    }
    void Start()
    {
        cups[round].gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Initialized();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
