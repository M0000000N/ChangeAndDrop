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
        CalculateNum = Random.Range(2, 7);
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
}
