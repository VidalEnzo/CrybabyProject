using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController character;

    float moveSpeed = 5;
    float gravity = 6;

    Vector3 move;

    private void Start()
    {
        // Récupère le component Character Controller de l'inspector 
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        // Récupère les axes de déplacements 
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Ordonne le déplacements 
        if(character.isGrounded)
        {
            move = new Vector3(moveX, 0, moveZ);
            move = transform.TransformDirection(move);
            move *= moveSpeed;
        }

        // Active la gravité
        move.y -= gravity;

        // Permet un mouvement fluide et uniforme 
        character.Move(move * Time.deltaTime);
    }
}
