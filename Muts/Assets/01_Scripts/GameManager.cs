using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    private int score = 0; // ���� ���� ����
    public bool IsGameover { get; private set; } // ���� ���� ����

    // ������ �߰��ϰ� UI ����
    public void AddScore(int newScore)
    {
        // ���� ������ �ƴ� ���¿����� ���� ���� ����
        if (!IsGameover)
        {
            // ���� �߰�
            score += newScore;
            // ���� UI �ؽ�Ʈ ����
            //UIManager.instance.UpdateScoreText(score);
        }
    }

    // ���� ���� ó��
    public void EndGame()
    {
        // ���� ���� ���¸� ������ ����
        IsGameover = true;
        // ���� ���� UI�� Ȱ��ȭ
        //UIManager.instance.SetActiveGameoverUI(true);
    }
}
