using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public int CalculateNum; // ���� ����

    private int TriggerNum = 0; // �ε��� ����
    public ParticleSystem particleObject;
    public GameObject BridgeComponent;
    private Animator bridgeAnim;

    void Start()
    {
        particleObject = GetComponentInChildren<ParticleSystem>();
        bridgeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerNum >1 && TriggerNum < CalculateNum)
        {
            bridgeAnim.SetFloat("Blend",(float)TriggerNum/CalculateNum);
        }
        if (TriggerNum == CalculateNum)
        {
            particleObject.Play();
            // BridgeComponent.SetActive(false);
            for (int i = 1; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" || gameObject.CompareTag("Bridge"))
        {
            TriggerNum++;
        }
    }
}
