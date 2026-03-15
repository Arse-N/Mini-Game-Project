using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class FloorSaw : MonoBehaviour
{

    [SerializeField] private float _floorSawRotationSpeed = 100f;
    [SerializeField] private float moveSpeed = 0.5f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private float targetPositionY = -10;
    private float t;

    private void Start()
    {
        StartCoroutine(RotateFloorSawEnumerator());
        StartCoroutine(MoveFloorSawEnumerator());
    }

    private IEnumerator MoveFloorSawEnumerator()
    {
        var wait = new WaitForSeconds(2f);
        originalPosition = transform.position;
        targetPosition = originalPosition + new Vector3(0, targetPositionY, 0);
        while (true)
        {
            t = 0f;
            while (t <= 1.0f)
            {
                transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
                t += Time.deltaTime * moveSpeed;
                yield return null;
            }
            yield return wait;
            t = 0f;
            while (t <= 1.0f)
            {
                transform.position = Vector3.Lerp(targetPosition, originalPosition, t);
                t += Time.deltaTime * moveSpeed;
                yield return null;
            }
            yield return wait;
        }
    }

    IEnumerator RotateFloorSawEnumerator()
    {
        while (true)
        {
            transform.Rotate(0f, 0f, _floorSawRotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
