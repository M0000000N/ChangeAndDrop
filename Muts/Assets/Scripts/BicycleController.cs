using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace SBPScripts
{
    //namespace SBPScripts
    //{
    [Serializable]
    public class BicyclePrefebs
    {
        public GameObject handles, visualFWheel, RWheel, crankl, Pedal, rPedal;
    }
    [Serializable]
    public class WheelFriction
    {
        public PhysicMaterial fPhysicMaterial, rPhysicMaterial;
        public Vector2 fFriction, rFriction;
    }
    [System.Serializable]

    public class BicycleController : MonoBehaviour
    {
        public BicyclePrefebs BicyclePrefebs;
        public GameObject fPhysicsWheel, rPhysicsWheel;
        public WheelFriction wheelFrictionSettings;

        public AnimationCurve accelerationCurve;
        public AnimationCurve steerAngle;
        public float axisAngle;
        public AnimationCurve leanCurve;

        // �ӵ�
        bool sprint;
        public float topSpeed, currentTopSpeed, pickUpSpeed, relaxedSpeed, reversingSpeed;

        // public WayPointSystem wayPointSystem;

        //�̰� �������
        public Rigidbody Rigidbody, FWheelRb, RWheelRb;
        float xQuat, zQuat;

        // ũ��ũ
        public float crankSpeed, crankCurrentQuat, crankLastQuat, restingCrank;


        Quaternion initialHandlesRotation;
        public float customAccelerationAxis, rawCustomAccelerationAxis;
        public bool isReversing, stuntMode;

        private void Awake()
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }

        private void Start()
        {
            // �������� �ִ�ӵ�
            Rigidbody = GetComponent<Rigidbody>();
            Rigidbody.maxAngularVelocity = Mathf.Infinity; // �ִ�ӵ�?
            FWheelRb = fPhysicsWheel.GetComponent<Rigidbody>();
            FWheelRb.maxAngularVelocity = Mathf.Infinity;
            RWheelRb = rPhysicsWheel.GetComponent<Rigidbody>();
            RWheelRb.maxAngularVelocity = Mathf.Infinity;
            currentTopSpeed = topSpeed;


            // �ڵ� �ʱⰪ
            initialHandlesRotation = BicyclePrefebs.handles.transform.localRotation;

        }

        private void FixedUpdate()
        {
            fPhysicsWheel.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + steerAngle.Evaluate(Rigidbody.velocity.magnitude), 0);

            float currentSpeed = Rigidbody.velocity.magnitude;

            // ������ �޸� ��
            if (!sprint)
                currentTopSpeed = Mathf.Lerp(currentTopSpeed, topSpeed * relaxedSpeed, Time.deltaTime);
            else
                currentTopSpeed = Mathf.Lerp(currentTopSpeed, topSpeed, Time.deltaTime);

            // ����ӵ��� �ִ� ������ ���� �ӵ����� �۰�, ���ӵ��� ����� ������ ���� ���Ѵ�.
            if (currentSpeed < currentTopSpeed && rawCustomAccelerationAxis > 0)
                Rigidbody.AddForce(transform.forward * accelerationCurve.Evaluate(customAccelerationAxis));
            // ����ӵ��� �ִ� �ڷ� ���� �ӵ����� �۰�, ���ӵ��� ������ ������ ���� ���Ѵ�.
            if (currentSpeed < reversingSpeed && rawCustomAccelerationAxis < 0)
                Rigidbody.AddForce(-transform.forward * accelerationCurve.Evaluate(customAccelerationAxis) * 0.5f);

            // ������ȯ
            if (transform.InverseTransformDirection(Rigidbody.velocity).z < 0)
                isReversing = true;
            else
                isReversing = false;

            //�̰� ���� Ȯ�� �ʿ�
            if (stuntMode)
                Rigidbody.centerOfMass = GetComponent<BoxCollider>().center;
            else
                Rigidbody.centerOfMass = Vector3.zero;

            // �չ���, x, z�� �� �ʿ����� �ľ� �ʿ�
            xQuat = Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.y));
            zQuat = Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.y));
            BicyclePrefebs.visualFWheel.transform.rotation = Quaternion.Euler(xQuat * (/*customSteerAxis **/ -axisAngle),
                0,
                zQuat * (/*customSteerAxis **/ -axisAngle));

            BicyclePrefebs.visualFWheel.transform.GetChild(0).transform.localRotation = BicyclePrefebs.RWheel.transform.rotation;

            // �����
            crankCurrentQuat = BicyclePrefebs.RWheel.transform.rotation.eulerAngles.x;


            // ����ó��
            wheelFrictionSettings.fPhysicMaterial.staticFriction = wheelFrictionSettings.fFriction.x;
            wheelFrictionSettings.fPhysicMaterial.dynamicFriction = wheelFrictionSettings.fFriction.y;
            wheelFrictionSettings.rPhysicMaterial.staticFriction = wheelFrictionSettings.rFriction.x;
            wheelFrictionSettings.rPhysicMaterial.dynamicFriction = wheelFrictionSettings.rFriction.y;
        }

        private void Update()
        {
            float xInput = Input.GetAxis("Horizontal");
            float zInput = Input.GetAxis("Vertical");

            float xSpeed = xInput * currentTopSpeed;
            float zSpeed = zInput * currentTopSpeed;

            Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

            Rigidbody.velocity = newVelocity;

        }
    }
}

//}