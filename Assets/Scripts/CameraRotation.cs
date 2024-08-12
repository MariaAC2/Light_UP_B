using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed  * Time.deltaTime, 0);   
    }
}
