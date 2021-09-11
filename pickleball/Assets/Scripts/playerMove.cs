using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    public float dashForce;

    float horizontal;
    float vertical;
    bool dash;

    public float dashCooldown = 1.5f;

    public float dragFactor = 6f;

    Vector3 moveDir;

    public Rigidbody rb;
 
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
        rb.drag = dragFactor;
    }

    void InputHandler()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        dash = Input.GetButtonDown("Dash");
        moveDir = transform.forward * vertical + transform.right * horizontal;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        checkDash();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDir.normalized * moveSpeed, ForceMode.Acceleration);
    }

    void checkDash()
    {
        if (dash && moveDir != Vector3.zero && Time.time > dashCooldown)
        {
            rb.AddForce(moveDir * dashForce, ForceMode.Impulse);
            dashCooldown = Time.time + dashCooldown;
        }
    }
}