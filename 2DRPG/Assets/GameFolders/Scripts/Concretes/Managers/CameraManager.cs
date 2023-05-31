using TDRPG.Abstracts;
using UnityEngine;

namespace TDRPG.Managers
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Transform roomTransform;
        [SerializeField] private Transform activeRoomTransform;

        [Range(-10, 10)] 
        [SerializeField] float minModX,maxModX,minModY,maxModY;
        private void Awake()
        {
            
        }

        private void LateUpdate()
        {
            CameraMovement();
        }

        private void CameraMovement()
        {

            //Setting Bounds
            var minPosX = activeRoomTransform.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
            var minPosY = activeRoomTransform.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
            var maxPosX = activeRoomTransform.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;
            var maxPosY = activeRoomTransform.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
            
            var clampedPosX = Mathf.Clamp(playerTransform.position.x, minPosX, maxPosX);
            var clampedPosY = Mathf.Clamp(playerTransform.position.x, minPosY, maxPosY);

            Vector3 clampedPos = new Vector3(clampedPosX,clampedPosY,-10);
            Vector3 smoothPos = Vector3.Lerp(transform.position, clampedPos, 3f * Time.deltaTime);
            transform.position = smoothPos;
        }
    }    
}


