using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    // float RotationX;
    // float RotationY;
    // public float sensitivity;
    // Vector3 offset;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //hides and locks the cursor in the middle
        // offset = transform.position - player.transform.position; //shown in the tutorial
    }

    void LateUpdate()
    {
        // RotationX += Input.GetAxis("Mouse X") * sensitivity; // adding the fpp style to the game
        // RotationY += Input.GetAxis("Mouse Y") * sensitivity; // adding the fpp style to the game
        // transform.localRotation = Quaternion.Euler(45-RotationY,RotationX,0); // adding the fpp style to the game
        // transform.position = player.transform.position + offset; // shown in the tutorial
        transform.LookAt(player.transform.position);
    }
}
