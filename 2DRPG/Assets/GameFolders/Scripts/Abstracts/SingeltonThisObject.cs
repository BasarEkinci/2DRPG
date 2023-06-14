using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDRPG.Abstracts
{
    public abstract class SingeltonThisObject<T> : MonoBehaviour
    {
        public static T Instance { get; private set; }

        public void SingeltonThisGameObject(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
            }
        }
    }    
}


