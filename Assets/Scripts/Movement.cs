using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public static float moveSpeed = 5f;
    [SerializeField] public static float rotationSpeed = 25f;
    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }
    void Move()
    {

        transform.position = transform.position + transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

    }
    void Rotate()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
