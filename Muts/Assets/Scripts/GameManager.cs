using UnityEngine;
namespace SBPScripts
{
    // ������ ���� ���� ���θ� �����ϴ� ���� �Ŵ���
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
}