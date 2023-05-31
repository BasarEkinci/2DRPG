using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDRPG.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;

        private bool isPaused;
        private void Start()
        {
            if(pauseMenu.activeSelf)
                pauseMenu.SetActive(false);
            isPaused = false;
        }

        private void Update()
        {
            Pause();
        }

        private void Pause()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            {
                Time.timeScale = 0;
                if(!pauseMenu.activeSelf)
                    pauseMenu.SetActive(true);

                isPaused = true;
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
            {
                Time.timeScale = 1;
                if(pauseMenu.activeSelf)
                    pauseMenu.SetActive(false);
                isPaused = false;
            }
        }
    }    
}


