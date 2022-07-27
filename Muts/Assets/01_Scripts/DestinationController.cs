using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SBPScripts
{
    public class DestinationController : BicycleStatus
    {
        //public AudioClip DeathClip;
        //public AudioClip HitClip;
        //public AudioClip YeahClip;

        private Slider _destSlider;
        private AudioSource playerAudioPlayer;
        //private Animator _animator; // 플레이어의 애니메이터

        public BicycleController _bicycleCon; // 플레이어 움직임 컴포넌트


        void Start()
        {
            _bicycleCon = GetComponent<BicycleController>(); // 플레이어 움직임 컴포넌트
            _destSlider= GetComponent<Slider>();
            playerAudioPlayer = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        private void OnTriggerEnter(Collider other)
        { 
        
            _destSlider.value = 0;
            playerAudioPlayer.Play();
            GameManager.Instance.AddScore(1);
            Debug.Log("트리거했지롱");

        }
    }
}