using TDRPG.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDRPG.UIs
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] GameObject settingsPanel;
        [SerializeField] GameObject menuButtonsPanel;

        private void Start()
        {
            settingsPanel.SetActive(false);
            menuButtonsPanel.SetActive(true);
            Time.timeScale = 1;
        }

        public void CloseSettingsButton()
        {
            if(settingsPanel.activeSelf)
                settingsPanel.SetActive(false);
            
            if(!menuButtonsPanel.activeSelf)
                menuButtonsPanel.SetActive(true);
        }

        public void SetttingsButton()
        {
            if(!settingsPanel.activeSelf)
                settingsPanel.SetActive(true);
            
            if(menuButtonsPanel.activeSelf)
                menuButtonsPanel.SetActive(false);
        }

        public void CreditsButton()
        {
            
        }

        public void QuitButton()
        {
            Application.Quit();
        }

        public void StartButton()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }    
}


