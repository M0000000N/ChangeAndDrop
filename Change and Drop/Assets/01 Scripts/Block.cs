using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Block : MonoBehaviour
{
    // 색상 관련
    [Header("계산")]
    public int CalculateNum; // 곱할 숫자
    [SerializeField] TextMeshProUGUI blockText;

    [Header("재질")]
    public int materialIndex; // 0:노랑, 1: 보라
    [SerializeField] Renderer blockRender;// 블럭색상 설정

    
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
