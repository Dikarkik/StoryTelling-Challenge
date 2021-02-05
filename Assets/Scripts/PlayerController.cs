using UnityEngine;

/// <summary>
/// Handle user input so the player can move left, right, forward, backward, and diagonally using the WASD keys.
/// The player jump when the Space button is pressed.
/// </summary>
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    // movement
    private float playerSpeed = 6f;
    private Vector3 moveDirection;
    private Vector3 cameraForward = new Vector3(0,0,0);
    private Vector3 cameraRight = new Vector3(0, 0, 0);


    // jump
    private Vector3 playerGravity;
    private float gravityValue = -12.81f;
    private float jumpHeight = 1.0f;

	void Start() => controller = GetComponent<CharacterController>();

	void Update()
    {
        // movement
        cameraForward = Camera.main.transform.forward;
        cameraRight = Camera.main.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;

        moveDirection = Vector3.Normalize((Input.GetAxis("Vertical") * cameraForward) +
                                          (Input.GetAxis("Horizontal") * cameraRight));

        // jump
        if(!controller.isGrounded)
        {
            playerGravity.y += gravityValue * Time.deltaTime;
        }
        else if(Input.GetButtonDown("Jump"))
	    {
            playerGravity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
		}

        // movement (Unexpected behavior if place this line below 'jump' line)
        controller.Move(moveDirection * Time.deltaTime * playerSpeed);
		// jump
		controller.Move(playerGravity * Time.deltaTime);

        // fall
        if(transform.position.y < -20)
        {
            transform.position = new Vector3(0, 30, 0);
            playerGravity.y = gravityValue;
        }
    }
}
