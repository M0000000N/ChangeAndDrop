using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Block : MonoBehaviour
{
    // ���� ����
    public int CalculateNum; // ���� ����
    public Renderer BlockRender { get; private set; } // ������ ����
    [SerializeField] TextMeshProUGUI blockText;

    void Start()
    {
        BlockRender = gameObject.GetComponent<MeshRenderer>();
        blockText.text = "X " + CalculateNum.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Transform TriggerTransform = other.transform;
            MeshRenderer TriggerMesh = other.gameObject.GetComponent<MeshRenderer>();

            if (TriggerMesh.material.name == BlockRender.material.name)
            {
                Destroy(other.gameObject);

                for (int i = 0; i < CalculateNum; i++)
                {
                    Spawn(TriggerTransform);
                }
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
    public void Spawn(Transform TriggerTransform)
    {
        Instantiate(GameManager.Instance.BallPrefeb, TriggerTransform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
    }
}
