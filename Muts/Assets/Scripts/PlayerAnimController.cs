using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;
namespace SBPScripts
{
    public class PlayerAnimController : MonoBehaviour
    {
        BicycleController bicycleController;
        Animator anim;
        PlayerInput input;
        string clipInfoCurrent, clipInfoLast;

        public float speed;
        public GameObject hipIK, chestIK, leftFootIK, leftFootIdleIK, headIK;
        public BicycleStatus bicycleStatus;
        Rig rig;

        bool onOffBike;

        public GameObject cyclist;
        public GameObject externalCharacter;


        float waitTime, prevLocalPosX;

        private float leftFootIKWeight;
        private float chestIKWeight;
        private float hipIKIKWeight;
        private float headIKIKWeight;


        void Start()
        {
            bicycleController = FindObjectOfType<BicycleController>();
            anim = GetComponent<Animator>();
            input = GetComponent<PlayerInput>();
            bicycleStatus = FindObjectOfType<BicycleStatus>();

            rig = hipIK.transform.parent.gameObject.GetComponent<Rig>();

            if (bicycleStatus != null)
                onOffBike = bicycleStatus.onBike;
            if (cyclist != null)
              //  cyclist.SetActive(bicycleStatus.onBike);
            if (externalCharacter != null)
                externalCharacter.SetActive(!bicycleStatus.onBike);

            leftFootIKWeight = leftFootIK.GetComponent<TwoBoneIKConstraint>().weight;
            leftFootIKWeight = 0;
            chestIKWeight = chestIK.GetComponent<TwoBoneIKConstraint>().weight;
            chestIKWeight = 0;
            hipIKIKWeight = hipIK.GetComponent<MultiParentConstraint>().weight;
            hipIKIKWeight = 0;
            headIKIKWeight = headIK.GetComponent<MultiAimConstraint>().weight;
            headIKIKWeight = 0;

            transform.position = hipIK.transform.position;

            //if (cyclist != null)
            //    cyclist.SetActive(bicycleStatus.onBike);
        }

        void update()
        {
            if (cyclist != null)
            {
                if (input.Return && bicycleController.transform.InverseTransformDirection(bicycleController.Rigidbody.velocity).z <= 0.1f)
                {
                    bicycleStatus.onBike = !bicycleStatus.onBike;
                    if (bicycleStatus.onBike)
                    {
                        if (prevLocalPosX < 0)
                            anim.Play("OnBike");
                        else
                            anim.Play("OnBikeFlipped");
                    }
                    else
                    {
                        anim.Play("OffBike");
                    }
                }
            }
            waitTime -= Time.deltaTime;
            waitTime = Mathf.Clamp(waitTime, 0, 1.5f);


            //speed = bicycleController.transform.InverseTransformDirection(bicycleController.rb.velocity).z;
            anim.SetFloat("Speed", speed);

            // 자전거 상태 유효할 때
            if (bicycleStatus != null)
            {
                if (bicycleStatus.onBike && !bicycleStatus.dislodged)// 자전거에 타고 있고 가만히 있을 때
                {
                    clipInfoCurrent = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name; // 현재 클립 이름
                    if (clipInfoCurrent == "IdleToStart")// 막 시작하려할 때
                        leftFootIKWeight = 1;
                    leftFootIdleIK.GetComponent<TwoBoneIKConstraint>().weight = 0;
                    if (clipInfoCurrent == "Idle")
                        leftFootIKWeight = 0;
                    leftFootIdleIK.GetComponent<TwoBoneIKConstraint>().weight = 1;
                }
                else // 죽었을 때
                {
                    cyclist.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        cyclist.SetActive(true);
                        bicycleStatus.dislodged = false;
                    }
                }
            }

        }
    }
}