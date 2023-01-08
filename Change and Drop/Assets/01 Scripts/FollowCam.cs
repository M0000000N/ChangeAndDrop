using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] BallPool Target;
    [SerializeField] Camera camera;
    private Transform transform;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = new Vector3(-7, 0, 30);
       // transform = Target.ballPoolList[0].gameObject.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // camera.transform.position = transform.position + distance;
    }
}
