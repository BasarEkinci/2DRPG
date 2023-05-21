using System;
using System.Collections;
using System.Collections.Generic;
using TDRPG.Abstracts;
using UnityEngine;

namespace TDRPG.Managers
{
    public class GameManager : SingeltonThisObject<GameManager>
    {
        private void Awake()
        {
            SingeltonThisGameObject(this);
        }
    }
}


