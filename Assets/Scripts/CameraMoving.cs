using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    public Transform target;


    private void LateUpdate()
    {
        var mouse_x = Input.GetAxis("Mouse X");
        var mouse_y = -Input.GetAxis("Mouse Y");
        
        if (Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.LeftAlt))
        {
            transform.Translate(Vector3.left * (mouse_x * 30f) * Time.deltaTime);
            transform.Translate(Vector3.up * (mouse_y * 30f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftAlt))
        {
            transform.RotateAround(target.transform.position, Vector3.up, mouse_x * 5);
            transform.RotateAround(target.transform.position, transform.right, mouse_y * 5);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Translate(Vector3.forward * 0.5f);


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Translate(Vector3.forward * -0.5f);


    }

}
