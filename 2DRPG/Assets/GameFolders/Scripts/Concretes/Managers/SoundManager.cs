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

            masterSlider.value = PlayerPrefs.GetFloat("MusicVolume",1f);
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
            effectSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1f);
        }
        public void SetMusicVolume()
        {
            DataManager.Instance.SetMusicData(musicSlider.value);
            musicMixer.SetFloat("MusicVolume",PlayerPrefs.GetFloat("MusicVolume"));
        }
        public void SetEffectVolume()
        {
            DataManager.Instance.SetEffectData(effectSlider.value);
            effectMixer.SetFloat("EffectVolume",PlayerPrefs.GetFloat("EffectVolume"));
        }

        public void SetMasterVolume()
        {
            DataManager.Instance.SetMasterVolumeData(masterSlider.value);
            AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume");
        }
        public void PlaySound(int index)
        {
            if(!audioSource[index].isPlaying)
                audioSource[index].Play();
        }
    }    
}


