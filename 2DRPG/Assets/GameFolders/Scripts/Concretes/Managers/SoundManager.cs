using System;
using System.Collections;
using System.Collections.Generic;
using TDRPG.Abstracts;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace TDRPG.Managers
{
    public class SoundManager : SingeltonThisObject<SoundManager>
    {
        [SerializeField] AudioMixer musicMixer;
        [SerializeField] AudioMixer effectMixer;

        [SerializeField] Slider musicSlider;
        [SerializeField] Slider effectSlider;
        [SerializeField] Slider masterSlider;

        
        private AudioSource[] audioSource;

        private void Awake()
        {
            SingeltonThisGameObject(this);
            audioSource = GetComponentsInChildren<AudioSource>();
        }
        
        private void Start()
        {
            PlaySound(5);
        }

        private void Update()
        {
            SetEffectVolume();
            SetMusicVolume();
            SetMasterVolume();
        }

        private void SetMusicVolume()
        {
            musicMixer.SetFloat("MusicVolume",musicSlider.value);
        }
        private void SetEffectVolume()
        {
            effectMixer.SetFloat("EffectVolume",effectSlider.value);
        }

        public void SetMasterVolume()
        {
            AudioListener.volume = masterSlider.value;
        }
        public void PlaySound(int index)
        {
            if(!audioSource[index].isPlaying)
                audioSource[index].Play();
        }
        public void StopSound(int index)
        {
            if(audioSource[index].isPlaying)
                audioSource[index].Stop();
        }
    }    
}


