using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    Transform player;
    [SerializeField]
    Transform playerView;

    float xAxisClamp = 0;

    [SerializeField]
    float mouseSensitivity = 20f;


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
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotationX = mouseX * mouseSensitivity;
        float rotationY = mouseY * mouseSensitivity;

        xAxisClamp -= rotationY;

        Vector3 rotationPlayerView = playerView.transform.rotation.eulerAngles;
        Vector3 rotationPlayer = player.transform.rotation.eulerAngles;

        // rotation haut et bas (axe Y)
        rotationPlayer.x -= rotationY;
        // On ne veut pas de rotation sur l'axe Z
        rotationPlayerView.z = 0;
        // rotation sur l'axe X 
        rotationPlayer.y += rotationX;



        // Bloque la caméra sur l'axe Y au angle 90 et 270
        if(xAxisClamp > 90)
        {
            xAxisClamp = 90;
            rotationPlayerView.x = 90;
        }
        else if(xAxisClamp < -90)
        {
            xAxisClamp = -90;
            rotationPlayerView.x = 270;
        }

        // Ordonne la rotation 
        playerView.rotation = Quaternion.Euler(rotationPlayerView);
        player.rotation = Quaternion.Euler(rotationPlayer);
  
    }
}
