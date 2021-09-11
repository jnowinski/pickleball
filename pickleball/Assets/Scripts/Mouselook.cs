using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    public float sensitivity;
    public Transform player;
    private float camRotate = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        camRotate -= mouseY;
        camRotate = Mathf.Clamp(camRotate, -90f, 90f);
        transform.localRotation = Quaternion.Euler(camRotate, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

        
    }
}
