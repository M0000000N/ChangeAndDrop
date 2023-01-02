using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] Camera camera;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = new Vector3(-7, 0, 30);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camera.transform.position = Target.position + distance;
    }
}
