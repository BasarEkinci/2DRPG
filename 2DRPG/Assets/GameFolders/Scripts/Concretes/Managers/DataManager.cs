using System;
using TDRPG.Abstracts;
using UnityEngine;

namespace TDRPG.Managers
{
    public class DataManager : SingeltonThisObject<DataManager>
    {
        private void Awake()
        {
            SingeltonThisGameObject(this);
            if(Instance != null)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        public void SetMusicData(float value)
        {
            PlayerPrefs.SetFloat("MusicVolume",value);
        }

        public void SetEffectData(float value)
        {
            PlayerPrefs.SetFloat("EffectVolume",value);
        }

        public void SetMasterVolumeData(float value)
        {
            PlayerPrefs.SetFloat("MasterVolume",value);
        }
    }    
}


