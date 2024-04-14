using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public Animator playerAnimator;
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;
    private float yValue;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        yValue = transform.position.y;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move != Vector3.zero)
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
            gameObject.transform.forward = move;
            if (!playerAnimator.GetBool("PlayerIsMoving")) playerAnimator.SetBool("PlayerIsMoving", true);
        }
        else{
            if (playerAnimator.GetBool("PlayerIsMoving")) playerAnimator.SetBool("PlayerIsMoving", false);
        }
        
    }
}