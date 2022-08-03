using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // ���� ����
    public Renderer BlockRender { get; private set; } // ������ ����

    public int CalculateNum; // ���� ����
    public int TriggerNum; // �ε��� ����
    ParticleSystem m_System;


    void Start()
    {
        BlockRender = gameObject.GetComponent<MeshRenderer>();
        m_System = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if(TriggerNum >= CalculateNum)
        {
            gameObject.SetActive(false);
            ParticleSystem.pla

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" || gameObject.CompareTag("Block"))
        {
            Transform TriggerTransform = other.gameObject.GetComponent<Transform>();
            // �ߵ���ü�� ����
            MeshRenderer TriggerMesh = other.gameObject.GetComponent<MeshRenderer>();

            // �浹����� �������� ���� ��
            if (TriggerMesh.material.name == BlockRender.material.name)
            {
                Destroy(other.gameObject);

                for (int i = 0; i < CalculateNum; i++)
                {
                    Debug.Log("����");
                    Spawn(1f, TriggerTransform);
                }
            }
            else
            {
                Destroy(other.gameObject);
                GameManager.Instance.CurrentBallCount--;
            }
        }
        else if (other.tag == "Ball" || gameObject.CompareTag("Bridge"))
        {
            TriggerNum++;
        }
    }

    public void Spawn(float delayTime, Transform TriggerTransform)
    {
        Instantiate(GameManager.Instance.BallPrefeb, TriggerTransform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
        GameManager.Instance.CurrentBallCount++;
    }
}
