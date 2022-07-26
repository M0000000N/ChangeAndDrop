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

        // 속도
        bool sprint;
        public float topSpeed, currentTopSpeed, pickUpSpeed, relaxedSpeed, reversingSpeed;

        // public WayPointSystem wayPointSystem;

        //이건 숨길것임
        public Rigidbody Rigidbody, FWheelRb, RWheelRb;
        float xQuat, zQuat;

        // 크랭크
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
            // 자전거의 최대속도
            Rigidbody = GetComponent<Rigidbody>();
            Rigidbody.maxAngularVelocity = Mathf.Infinity; // 최대속도?
            FWheelRb = fPhysicsWheel.GetComponent<Rigidbody>();
            FWheelRb.maxAngularVelocity = Mathf.Infinity;
            RWheelRb = rPhysicsWheel.GetComponent<Rigidbody>();
            RWheelRb.maxAngularVelocity = Mathf.Infinity;
            currentTopSpeed = topSpeed;


            // 핸들 초기값
            initialHandlesRotation = BicyclePrefebs.handles.transform.localRotation;

        }

        private void FixedUpdate()
        {
            fPhysicsWheel.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + steerAngle.Evaluate(Rigidbody.velocity.magnitude), 0);

            float currentSpeed = Rigidbody.velocity.magnitude;

            // 빠르게 달릴 때
            if (!sprint)
                currentTopSpeed = Mathf.Lerp(currentTopSpeed, topSpeed * relaxedSpeed, Time.deltaTime);
            else
                currentTopSpeed = Mathf.Lerp(currentTopSpeed, topSpeed, Time.deltaTime);

            // 현재속도가 최대 앞으로 가는 속도보다 작고, 가속도가 양수면 앞으로 힘을 가한다.
            if (currentSpeed < currentTopSpeed && rawCustomAccelerationAxis > 0)
                Rigidbody.AddForce(transform.forward * accelerationCurve.Evaluate(customAccelerationAxis));
            // 현재속도가 최대 뒤로 가는 속도보다 작고, 가속도가 음수면 뒤으로 힘을 가한다.
            if (currentSpeed < reversingSpeed && rawCustomAccelerationAxis < 0)
                Rigidbody.AddForce(-transform.forward * accelerationCurve.Evaluate(customAccelerationAxis) * 0.5f);

            // 방향전환
            if (transform.InverseTransformDirection(Rigidbody.velocity).z < 0)
                isReversing = true;
            else
                isReversing = false;

            //이거 뭔자 확인 필요
            if (stuntMode)
                Rigidbody.centerOfMass = GetComponent<BoxCollider>().center;
            else
                Rigidbody.centerOfMass = Vector3.zero;

            // 앞바퀴, x, z축 왜 필요한지 파악 필요
            xQuat = Mathf.Sin(Mathf.Deg2Rad * (transform.rotation.eulerAngles.y));
            zQuat = Mathf.Cos(Mathf.Deg2Rad * (transform.rotation.eulerAngles.y));
            BicyclePrefebs.visualFWheel.transform.rotation = Quaternion.Euler(xQuat * (/*customSteerAxis **/ -axisAngle),
                0,
                zQuat * (/*customSteerAxis **/ -axisAngle));

            BicyclePrefebs.visualFWheel.transform.GetChild(0).transform.localRotation = BicyclePrefebs.RWheel.transform.rotation;

            // 페달축
            crankCurrentQuat = BicyclePrefebs.RWheel.transform.rotation.eulerAngles.x;


            // 마찰처리
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