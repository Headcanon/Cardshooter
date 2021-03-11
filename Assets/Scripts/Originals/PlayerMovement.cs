using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;

    public float gravity = -9.81f;

    private GM gm;
    private CharacterController cc;

    private Vector3 velocity;

    // Start is called before the first frame update
    //void Start()
    //{
    //    gm = FindObjectOfType<GM>();
    //    cc = GetComponent<CharacterController>();
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if(gm.estado == Estado.ANDAR)
    //    {
    //        MoveCharacter();
    //    }
    //}

    private void MoveCharacter()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        cc.Move(movement * speed * Time.deltaTime);

        if(cc.isGrounded)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);
    }

    //private void OnDestroy()
    //{
    //    gm.SwitchToLose();


    //}
}
