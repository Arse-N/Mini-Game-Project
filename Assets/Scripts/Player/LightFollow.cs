using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 playerPosition;
    private Vector3 lightPosition;

    void LateUpdate()
    {
        playerPosition = _playerTransform.position;
        lightPosition = transform.position;
        lightPosition.z = playerPosition.z;
        lightPosition.y = playerPosition.y + 7f;
        lightPosition.x = playerPosition.x;
        transform.position = lightPosition;
    }
}