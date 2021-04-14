using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    bool isPaused = false;

    private GameObject closestTotem;
    private GameObject pushableRock;
    private GameObject closestInteractive;
    private bool isPushing = false;
    public bool isMoveable = true;
    public bool cameraLock = false;

    private Animator playerAnimator;
    private Rigidbody RB;

    private readonly int MovementXHash = Animator.StringToHash("MovementX");
    private readonly int MovementZHash = Animator.StringToHash("MovementZ");
    private readonly int IsRunningHash = Animator.StringToHash("IsRunning");
    private readonly int IsJumpingHash = Animator.StringToHash("IsJumping");

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StoneTabletHUD.SetActive(false);
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().pauseCanvas.SetActive(false);

        playerAnimator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody>();

        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().pauseCanvas.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pushableRock != null)
            {
                //pushableRock.transform.SetParent(transform);
                pushableRock.GetComponent<MeshCollider>().isTrigger = true;
                isPushing = true;
            }
            else if (closestTotem != null)
            {
                closestTotem.GetComponent<TotemBehaviour>().Activate();
            }
            else if (closestInteractive != null)
            {
                closestInteractive.GetComponent<BlockedButtonBehaviour>().Activate(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Cursor.visible = true;
                cameraLock = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                GameObject.FindWithTag("GameManager").GetComponent<GameManager>().pauseCanvas.SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (pushableRock != null)
            {
                pushableRock.GetComponent<MeshCollider>().isTrigger = false;
                pushableRock.transform.parent = null;
                pushableRock = null;
                isPushing = false;
            }
        }

        if (isMoveable)
            MovementInputs();

        if (isPushing)
        {
            pushableRock.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        }
    }
    public void Unpause()
    {
        cameraLock = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().pauseCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
       
        
    }

    void MovementInputs()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        
        if (isRunning && !(moveDirection == Vector3.zero))
        {
            playerAnimator.SetBool("isRunning", true);
            playerAnimator.SetBool("isWalking", false);
        }
        else if (moveDirection == Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isRunning", false);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetBool("isWalking", true);
        }


        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove && !cameraLock)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Totem")
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SetInteractionText("Press (E) to activate"); //Should probably change this to switch with keybinding switch
            closestTotem = other.gameObject;
        }
        else if (other.gameObject.tag == "Interactable")
        {
            closestInteractive = other.gameObject;
        }


        if (other.gameObject.tag == "PushableObject")
        {
            pushableRock = other.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Totem")
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SetInteractionText("");
            closestTotem = null;
        }
        else if (other.gameObject.tag == "Interactable")
        {
            closestInteractive = null;
        }



        if (other.gameObject.tag == "PushableObject" && !isPushing)
        {
            if (pushableRock != null)
            {
                pushableRock.GetComponent<MeshCollider>().isTrigger = false;
                pushableRock = null;
            }
        }
        else if (other.gameObject.tag == "PushableObject" && isPushing)
        {
            pushableRock.transform.position = gameObject.transform.position;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }

    private void OnCollisionExit(Collision other)
    {
        
    }
}
