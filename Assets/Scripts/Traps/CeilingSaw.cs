using UnityEngine;
using System.Collections;

public class CeilingSaw : MonoBehaviour
{

    [SerializeField] private float _ceilingSawRotationSpeed = 50f;
    [SerializeField] private float _ceilingSawRotationAngle;
    private Quaternion originalRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        StartCoroutine(RotateCeilingSawEnumerator());
    }

    IEnumerator RotateCeilingSawEnumerator()
    {
        originalRotation = transform.localRotation;
        targetRotation = originalRotation * Quaternion.Euler(0f, 0f, _ceilingSawRotationAngle);
        var wait = new WaitForSeconds(2f);
        while (true)
        {
            while (Quaternion.Angle(transform.localRotation, targetRotation) > 0.1f)
            {
                transform.localRotation = Quaternion.RotateTowards(
                    transform.localRotation,
                    targetRotation,
                    _ceilingSawRotationSpeed * Time.deltaTime
                );
                yield return null;
            }

            yield return wait;

            while (Quaternion.Angle(transform.localRotation, originalRotation) > 0.1f)
            {
                transform.localRotation = Quaternion.RotateTowards(
                    transform.localRotation,
                    originalRotation,
                    _ceilingSawRotationSpeed * Time.deltaTime
                );
                yield return null;
            }

            yield return wait;
        }
    }

}