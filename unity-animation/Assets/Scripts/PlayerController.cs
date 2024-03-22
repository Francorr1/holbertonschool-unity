using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public CharacterController player;
    private UnityEngine.Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float playerJump = 1.0f;
    public float gravity = -9.81f;
    private Camera playerCamera;
    public Transform playerPos;
    public Transform playerModel;
    public UnityEngine.Vector3 StartPos;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = player.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        UnityEngine.Vector3 forward = playerCamera.transform.forward;
        UnityEngine.Vector3 right = playerCamera.transform.right;
        
        UnityEngine.Vector3 moveInput = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        UnityEngine.Vector3 move = (forward * moveInput.z + right * moveInput.x).normalized;

        player.Move(move * Time.deltaTime * playerSpeed);

        if (move != UnityEngine.Vector3.zero)
        {
            UnityEngine.Quaternion lookRotation = UnityEngine.Quaternion.LookRotation(new UnityEngine.Vector3(forward.x, 0f, forward.z));
            transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, lookRotation, UnityEngine.Time.deltaTime * playerSpeed);

            animator.SetBool("isRunning", true);
        }

        else
        {
            animator.SetBool("isRunning", false);
        }

        if (move != UnityEngine.Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg + playerCamera.transform.eulerAngles.y;
            playerModel.rotation = UnityEngine.Quaternion.Euler(0f, targetAngle, 0f);
        }
        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = playerJump;
        }

        playerVelocity.y -= gravity * Time.deltaTime;
        player.Move(playerVelocity * Time.deltaTime);
        
        if (playerPos.position.y < (-25))
        {
            playerPos.position = StartPos;
        }
    }
}
