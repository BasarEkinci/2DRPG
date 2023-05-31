using System;
using System.Collections;
using System.Collections.Generic;
using TDRPG.Abstracts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDRPG.Managers
{
    public class GameManager : SingeltonThisObject<GameManager>
    {
        private void Awake()
        {
            SingeltonThisGameObject(this);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}


