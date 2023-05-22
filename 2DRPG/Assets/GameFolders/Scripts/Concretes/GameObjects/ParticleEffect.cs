using UnityEngine;

namespace TDRPG.GameObjects
{
    public class ParticleEffect : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject,1f);
        }
    }    
}


