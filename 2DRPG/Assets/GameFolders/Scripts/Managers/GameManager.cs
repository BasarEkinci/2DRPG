using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDRPG.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }
    }
}


