using UnityEngine;
using System.Collections;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Vector3 playerPosition;
    private Vector3 playerScale;
    private bool isJumping = false;
    private bool isShiftPressed = false;
    private bool isCTRLPressed = false;

    void Update()
    {
        playerPosition = transform.position;
        playerScale = transform.localScale;

        if (Input.GetKey(KeyCode.W))
            playerPosition.z += Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.S))
            playerPosition.z -= Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.A))
            playerPosition.x -= Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.D))
            playerPosition.x += Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCTRLPressed)
        {
            playerScale.y = 1.0f;
            playerPosition.y = 0.5f;
            isShiftPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerScale.y = 2.0f;
            playerPosition.y = 1.0f;
            isShiftPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            StartCoroutine(Jump(transform.position));

        if (Input.GetKeyDown(KeyCode.LeftControl) && !isShiftPressed)
        {
            speed = 6f;
            isCTRLPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = 3f;
            isCTRLPressed = false;
        }


        transform.position = playerPosition;
        transform.localScale = playerScale;
    }

    private IEnumerator Jump(Vector3 position)
    {
        isJumping = true;
        float t = 0.0f;
        Vector3 temp = position;
        Vector3 height = position;
        height.y += 1.5f;

        while (t <= 1.0f)
        {
            transform.position = Vector3.Lerp(temp, height, t);
            t += Time.deltaTime * 3f;
            yield return null;
        }

        isJumping = false;
    }

}
