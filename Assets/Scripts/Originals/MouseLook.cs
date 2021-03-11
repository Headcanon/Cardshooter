using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    private GM gm;
    private Transform playerBody;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GM>();
        playerBody = transform.parent.transform;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (gm.estado == Estado.MIRAR)
    //    {
    //        Mirar();
    //    }
    //}

    private void Mirar()
    {
        // Pega inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculo do input Y
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        // Rotacionar
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up, mouseX);
    }
}
