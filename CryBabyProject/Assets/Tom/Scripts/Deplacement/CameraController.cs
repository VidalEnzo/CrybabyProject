using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    Transform player;
    //[SerializeField]
    //Transform playerView;

    float xAxisClamp = 0;

    [SerializeField]
    float mouseSensitivity = 5f;


    private void Update()
    {

        //Cache le curseur de la souris 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        RotateCamera();
  
    }

    void RotateCamera()
    {
        // Récupère les axes de rotation de la caméra 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xAxisClamp -= mouseY;
        xAxisClamp = Mathf.Clamp(xAxisClamp, -90f, 90f);

        // Ordonne la rotation 
        transform.localRotation = Quaternion.Euler(xAxisClamp, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
  
    }
}
