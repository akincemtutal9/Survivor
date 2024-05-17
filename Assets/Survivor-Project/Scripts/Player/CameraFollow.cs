using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;
    private void LateUpdate()
    {
        FollowPlayer();
    }
    private void FollowPlayer() {         
        transform.position = transformToFollow.position;
    }
}
