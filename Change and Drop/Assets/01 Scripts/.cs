using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // ��� ����
    public enum _calculate
    {
        plus,
        minus,
        muliple,
        division
    }


    // ���� ����
    public Renderer BlockRender { get; private set; } // ������ ����
    private Renderer _ballRender;
    

    public _calculate Calculate;
    public int CalculateNum;

    void Start()
    {
        BlockRender = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (BlockRender.material == _ball.CurrentBallColor)
        //{
        //    Debug.Log("�Ȱ�����");
        //}
        //else
        //{
        //    Debug.Log("�ٸ���");
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            MeshRenderer ballMaterial = other.gameObject.GetComponent<MeshRenderer>();
            // gameObject.materal = other.gameObject.
            if (ballMaterial.material.name == BlockRender.material.name)
            {
                Debug.Log("���� ����");

            }
            else
            {
                Destroy(other.gameObject);
            }
        }
        //ball.gameObject
    }
}
