using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Block : MonoBehaviour
{
    // ���� ����
    public Renderer BlockRender { get; private set; } // ������ ����
    public int CalculateNum; // ���� ����
    private TextMeshPro blockText;

    private void Awake()
    {
        blockText = GetComponentInChildren<TextMeshPro>();
    }
    void Start()
    {
        BlockRender = gameObject.GetComponentInChildren<MeshRenderer>();
        blockText.text = "X" + CalculateNum;
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
    }

    public void Spawn(float delayTime, Transform TriggerTransform)
    {
        Instantiate(GameManager.Instance.BallPrefeb, TriggerTransform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
        GameManager.Instance.CurrentBallCount++;
    }
}
