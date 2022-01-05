using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookAt : MonoBehaviour
{
    public Transform PlayerCamera;
    private void FixedUpdate()
    {
        transform.LookAt(PlayerCamera.position);
    }
}
