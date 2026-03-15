using UnityEngine;
using System.Collections;

public class TurretMovement : MonoBehaviour
{

    [SerializeField] private float _turretRotationSpeed = 20f;
    [Space]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPointTransform;
    private Quaternion originalRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        StartCoroutine(RotateTurretEnumerator());
        StartCoroutine(ShootEnumerator());
    }

    IEnumerator RotateTurretEnumerator()
    {
        originalRotation = transform.localRotation;
        targetRotation = originalRotation * Quaternion.Euler(0f, 60f, 0f);

        while (true)
        {
            while (Quaternion.Angle(transform.localRotation, targetRotation) > 0.1f)
            {
                transform.localRotation = Quaternion.RotateTowards(
                    transform.localRotation,
                    targetRotation,
                    _turretRotationSpeed * Time.deltaTime
                );
                yield return null;
            }

            yield return new WaitForSeconds(1f);

            while (Quaternion.Angle(transform.localRotation, originalRotation) > 0.1f)
            {
                transform.localRotation = Quaternion.RotateTowards(
                    transform.localRotation,
                    originalRotation,
                    _turretRotationSpeed * Time.deltaTime
                );
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator ShootEnumerator()
    {
        var wait = new WaitForSeconds(1.5f);

        while (true)
        {
            yield return wait;

            var instantiatedBullet = Instantiate(_bulletPrefab);
            instantiatedBullet.transform.position = _shootPointTransform.position;
            instantiatedBullet.transform.rotation = _shootPointTransform.rotation;
        }
    }
}
