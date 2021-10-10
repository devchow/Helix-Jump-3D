using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 150f;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");

            transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        }
    }
}
