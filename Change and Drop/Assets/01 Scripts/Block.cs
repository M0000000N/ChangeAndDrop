using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Block : MonoBehaviour
{
    // ���� ����
    [Header("���")]
    public int CalculateNum; // ���� ����
    [SerializeField] TextMeshProUGUI blockText;

    [Header("����")]
    public int materialIndex; // 0:���, 1: ����
    [SerializeField] Renderer blockRender;// ������ ����

    
    private void Start()
    {
        if(blockRender.material.name.Equals("Yellow (Instance)"))
        {
            materialIndex = 0;
        }
        else if(blockRender.material.name.Equals("Purple (Instance)"))
        {
            materialIndex = 1;
        }
        blockText.text = "X " + CalculateNum.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Ball ball = other.GetComponent<Ball>();
            if (ball.materialIndex == materialIndex)
            {
                for (int i = 0; i < CalculateNum; i++)
                {
                   ball.Instantiate(other.transform);
                }
                ball.destroy();
            }
            else
            {
                ball.destroy();
            }
        }
    }
}
