using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // 계산 관련
    public enum _calculate
    {
        plus,
        minus,
        muliple,
        division
    }


    // 색상 관련
    public Renderer BlockRender { get; private set; } // 블럭색상 설정
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
        //    Debug.Log("똑같은색");
        //}
        //else
        //{
        //    Debug.Log("다른색");
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
                Debug.Log("같은 색깔");

            }
            else
            {
                Destroy(other.gameObject);
            }
        }
        //ball.gameObject
    }
}
