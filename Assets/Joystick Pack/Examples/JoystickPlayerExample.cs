using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    [SerializeField] float speed;
    public DynamicJoystick variableJoystick;

    Rigidbody rb;

    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            PlayerMovement();
            animator.SetBool("running", true);
        }
        else
        {
            //to stop the player 
            rb.velocity = Vector3.zero;
            animator.SetBool("running", false);
        }
    }

    void PlayerMovement()
    {
        //PlayerMove
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.velocity = direction * speed * Time.fixedDeltaTime;
        //Player Rotation
        transform.localRotation = Quaternion.LookRotation(direction * 5f); 
    }
}