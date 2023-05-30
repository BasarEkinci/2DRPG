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

        private void Awake()
        {
            SingeltonThisGameObject(this);
            audioSource = GetComponentsInChildren<AudioSource>();
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


