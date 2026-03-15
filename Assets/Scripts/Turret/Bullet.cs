using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;


    private void Start()
    {
        StartCoroutine(LifetimeEnumerator());
    }
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    IEnumerator LifetimeEnumerator()
    {
        yield return new WaitForSeconds(3.0f);

        Destroy(gameObject);
    }
}
