using System;
using UnityEngine;

namespace TDRPG.GameObjects
{
    public class DeathEffect : MonoBehaviour
    {
        private void OnEnable()
        {
            Destroy(gameObject,1f);
        }
    }    
}

