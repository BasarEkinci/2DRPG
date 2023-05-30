using System;
using System.Collections;
using System.Collections.Generic;
using TDRPG.Abstracts;
using UnityEngine;
using UnityEngine.Audio;

namespace TDRPG.Managers
{
    public class SoundManager : SingeltonThisObject<SoundManager>
    {
        [SerializeField] AudioMixer musicMixer;
        [SerializeField] AudioMixer effectMixer;

        private AudioSource[] audioSource;
        private float effectVolume;
        private float musicVolume;
        
        private void Awake()
        {
            SingeltonThisGameObject(this);
            audioSource = GetComponentsInChildren<AudioSource>();
        }

        public void SetMusicVolume()
        {
            musicMixer.SetFloat("MusicVolume",musicVolume);
        }

        public void SetEffectVolume()
        {
            effectMixer.SetFloat("EffectVolume", effectVolume);
        }
        
        
        private void Start()
        {
            PlaySound(5);
        }

        private void Update()
        {
            SetEffectVolume();
            SetMusicVolume();
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


