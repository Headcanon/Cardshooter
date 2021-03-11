using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook1 : Element
{
    private float mouseSensitivity;
    private Transform playerBody;
    private Model model;
    private float xRotation = 0f;

    private void Start()
    {
        // Da um get no começo pra não ter que ficar procurando todo frame
        model = app.model;
        mouseSensitivity = model.playerData.mouseSensitivity;
        playerBody = model.playerData.playerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (model.estado == Estado.MIRAR)
        {
            Mirar();
        }
    }

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
