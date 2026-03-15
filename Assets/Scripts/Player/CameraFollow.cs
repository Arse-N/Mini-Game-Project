using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 playerPosition;
    private Vector3 cameraPosition;

    void LateUpdate()
    {
        playerPosition = _playerTransform.position;
        cameraPosition = transform.position;
        cameraPosition.z = playerPosition.z - 7f;
        cameraPosition.y = playerPosition.y + 3f;
        cameraPosition.x = playerPosition.x;
        transform.position = cameraPosition;
    }
}