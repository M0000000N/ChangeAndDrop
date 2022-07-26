using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
namespace SBPScripts
{
    public class ProceduralIKHandler : MonoBehaviour
    {
        BicycleController bicycleController;
        PlayerAnimController playerAnimController;

        public GameObject hipIKTarget, chestIKTarget, headIKTarget;

        private PlayerInput _input; // 플레이어의 입력
        private Animator _animator; // 애니메이터 컴포넌트

        public Vector3 hipOffset, chestOffset, headOffset;
        float initialChestRotationX, initialHipRotationX;
        public float hipVerticalOscillation;

        float xCycleAngle, initialHipVerticalOscillation;

        private static class AnimID
        {
            public static readonly int Idle = Animator.StringToHash("Idle");
            public static readonly int IdleToStart = Animator.StringToHash("IdleToStart");
            public static readonly int OnBike = Animator.StringToHash("OnBike");
            public static readonly int OffBike = Animator.StringToHash("OffBike");
            public static readonly int OnBikeFlipped = Animator.StringToHash("OnBikeFlipped");
        }
        private void Awake()
        {
            bicycleController = transform.root.GetComponent<BicycleController>();
            playerAnimController = transform.GetComponent<PlayerAnimController>();
            _input = GetComponent<PlayerInput>();
            _animator = GetComponent<Animator>();

            // hipIKTarget = playerAnimController.hipIK.GetComponent<MultiParentConstraint>().data.sourceObjects[0].transform.gameObject;
            // chestIKTarget = playerAnimController.chestIK.GetComponent<TwoBoneIKConstraint>().data.target.gameObject;
            // headIKTarget = playerAnimController.headIK.GetComponent<MultiAimConstraint>().data.sourceObjects[0].transform.gameObject;


            hipOffset = hipIKTarget.transform.localPosition;
            chestOffset = chestIKTarget.transform.localPosition;
            headOffset = headIKTarget.transform.localPosition;
            initialHipVerticalOscillation = hipVerticalOscillation;
            initialChestRotationX = chestIKTarget.transform.eulerAngles.x;
            initialHipRotationX = hipIKTarget.transform.eulerAngles.x;
        }
        private void Update()
        {
            //chestIKTarget.transform.localPosition = 
            //if (_input.CanFire)
            //{
            //    _gun.Fire();
            //}
            //if (_input.CanReload && _gun.Reload())
            //{
            //    _animator.SetTrigger(AnimID.Reload);
            //}
            UpdateUI();
        }
        // 탄약 UI 갱신
        private void UpdateUI()
        {
            //if (_gun != null && UIManager.instance != null)
            //{
            //    // UI 매니저의 탄약 텍스트에 탄창의 탄약과 남은 전체 탄약을 표시
            //    //UIManager.instance.UpdateAmmoText(gun.AmmoInMagazine, gun.RemainAmmoCount);
            //}
        }

        // 애니메이터의 IK 갱신
        private void OnAnimatorIK(int layerIndex)
        {
            //_animator.SetIKTransformAndWeight(AvatarIKGoal.LeftHand, LeftHendIKTarget);
            //_animator.SetIKTransformAndWeight(AvatarIKGoal.LeftHand, LeftHendIKTarget);
            //_animator.SetIKTransformAndWeight(AvatarIKGoal.LeftHand, LeftHendIKTarget);
            //_animator.SetIKTransformAndWeight(AvatarIKGoal.RightHand, RightHandIKTarget);
            //_animator.SetIKTransformAndWeight(AvatarIKGoal.LeftFoot, LeftFootIKTarget);
            //_animator.SetIKTransformAndWeight(AvatarIKGoal.RightFoot, RightFootIKTarget);
        }
    }
}