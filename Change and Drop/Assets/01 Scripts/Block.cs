using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Block : MonoBehaviour
{
    // 색상 관련
    public Renderer BlockRender { get; private set; } // 블럭색상 설정
    public int CalculateNum; // 곱할 숫자
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
            // 중돌객체의 색상
            MeshRenderer TriggerMesh = other.gameObject.GetComponent<MeshRenderer>();

            // 충돌색상과 블럭색상이 같을 때
            if (TriggerMesh.material.name == BlockRender.material.name)
            {
                Destroy(other.gameObject);

                for (int i = 0; i < CalculateNum; i++)
                {
                    Debug.Log("스폰");
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
