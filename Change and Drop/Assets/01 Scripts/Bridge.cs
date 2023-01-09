using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bridge : MonoBehaviour
{
    [SerializeField] int CalculateNum; // 통과 갯수
    [SerializeField] TextMeshProUGUI blockText;
    [SerializeField] ParticleSystem particleObject;

    private int TriggerNum = 0; // 충돌한 수
    private Animator bridgeAnim;
    private bool isPlay;

    void Start()
    {
        bridgeAnim = GetComponent<Animator>();
        blockText.text = CalculateNum.ToString();
    }

    void Update()
    {
        if (TriggerNum >1 && TriggerNum < CalculateNum)
        {
            bridgeAnim.SetFloat("Blend",(float)TriggerNum/CalculateNum);
            blockText.text = (CalculateNum - TriggerNum).ToString();
        }
        if (TriggerNum == CalculateNum && !isPlay)
        {
            isPlay = true;
            blockText.text = string.Empty;
            particleObject.Play();
            for (int i = 1; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
            TriggerNum = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            TriggerNum++;
        }
    }
}
