using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleStatus : MonoBehaviour
{
    public bool onBike = true;
    public bool dislodged;
    public float impactThreshold;
    public GameObject ragdollPrefab;
    [HideInInspector]
    public GameObject instantiatedRagdoll;
    bool prevOnBike, prevDislodged;
    public GameObject inactiveColliders;
    BicycleController bicycleController;
    Rigidbody rb;

    private void Start()
    {
        bicycleController = GetComponent<BicycleController>();
        rb = GetComponent<Rigidbody>();
        if (onBike)
            StartCoroutine(BikeStand(1));
        else
            StartCoroutine(BikeStand(0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > impactThreshold && ragdollPrefab != null)
            dislodged = true;
        else
            dislodged = false;

    }
    IEnumerator BikeStand(int instruction)
    {
        if(instruction == 1)
        {
            float t = 0f;
            while (t <=1)
            {
                t += Time.deltaTime * 3;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0), t);
                yield return null;
            }
            bicycleController.enabled = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
