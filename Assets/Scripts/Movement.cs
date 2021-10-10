using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator animator;

    int isWalkingHash;// = false;
    int isRunningHash;// = false;

    PlayerInput playerInput;

    Vector2 currentMovement;

    bool movementPressed;
    bool runPressed;

    //// Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
    }

    //    playerInput.PlayerControls.Movement.performed += ctx =>
    //    {
    //        Debug.Log(currentMovement + " current movement");
    //        currentMovement = ctx.ReadValue<Vector2>();
    //        movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
    //    };
    //    playerInput.PlayerControls.Run.performed += ctx =>
    //        runPressed = ctx.ReadValueAsButton();
    //}

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    //private void OnEnable() => playerInput.PlayerControls.Enable();

    //private void OnDisable() => playerInput.PlayerControls.Disable();

    //// Update is called once per frame
    //void Update()
    //{
    //    HandleMovement();
    //    HandleRotation();
    //}

    public void HandleMovement()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        if (movementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (!movementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        //Both movement or iswalking is true and isRunning is false. set running to true
        if ((movementPressed && isWalking) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        //Either move or iswalking is false and isRunning is true. set running to false
        if ((!movementPressed || !isWalking) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    public void HandleRotation()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x, 0, currentPosition.y);
        Vector3 positionToLookAt = currentPosition + newPosition;

        transform.LookAt(positionToLookAt);
    }
}
