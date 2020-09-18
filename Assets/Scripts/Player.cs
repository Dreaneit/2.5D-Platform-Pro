using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 playerVelocity;
    private float yVelocity;
    private bool canDoubleJump;
    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = 9.81f;

    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontalAxis, verticalAxis, 0);
        playerVelocity = direction * playerSpeed;

        if (characterController.isGrounded)
        {
            canDoubleJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
            }
        }
        else
        {
            if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                canDoubleJump = false;
                yVelocity += jumpHeight;
            }
            yVelocity -= gravityValue;
        }

        playerVelocity.y = yVelocity;

        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
