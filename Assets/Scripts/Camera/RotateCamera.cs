using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCamera : MonoBehaviour
{
    bool drag = false;
    private static readonly float sensitivity = 60.0f;
	
	void Update ()
    {
        if(drag)
        {
            if(Input.GetMouseButton(0))
            {
                Vector3 rotation = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
                rotation *= sensitivity * Time.deltaTime;
                transform.Rotate(rotation);
            }
            else
            {
                drag = false;
                Cursor.lockState = CursorLockMode.None;
            }
        } else if(!EventSystem.current.IsPointerOverGameObject())
        {
            if(Input.GetMouseButtonDown(0))
            {
                drag = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
	}
}
