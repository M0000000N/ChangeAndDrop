using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    // �� ���� ����
    public GameObject BallPrefeb;
    public Transform StartPosition;
    public int CurrentBallCount;

    // �� ����
    [SerializeField] Cup[] cups;

    // ���� ����
    public static bool isStart;
    private int round;
    public void Initialized()
    {
        isStart = false;
        CurrentBallCount = Random.Range(1, 2);
        BallSpawn(CurrentBallCount);
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
    public void BallSpawn(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Instantiate(BallPrefeb, StartPosition.position, StartPosition.rotation);
        }
    }
}
