using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : Element
{
    private CharacterController cc;
    private Vector3 velocity;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (app.model.estado == Estado.ANDAR)
        {
            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        cc.Move(movement * app.model.playerData.moveSpeed * Time.deltaTime);

        if (cc.isGrounded)
        {
            velocity.y = -2f;
        }

        velocity.y += app.model.playerData.gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);
    }
}
