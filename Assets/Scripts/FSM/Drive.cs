using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float Speed = 10f;
    public float RotSpeed = 100f;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * RotSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}
