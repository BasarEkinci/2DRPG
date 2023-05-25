using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDRPG.Abstracts
{
    public abstract class SingeltonThisObject<T> : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected void SingeltonThisGameObject(T entity)
        {
            if (Instance == null)
                Instance = entity;
            else
                Destroy(gameObject);
        }
    }    
}


