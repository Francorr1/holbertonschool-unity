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
    public UnityEngine.Vector3 StartPos;

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

        forward.Normalize();
        right.Normalize();
        
        UnityEngine.Vector3 moveInput = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        UnityEngine.Vector3 move = (forward * moveInput.z + right * moveInput.x).normalized;

        player.Move(move * Time.deltaTime * playerSpeed);

        if (move != UnityEngine.Vector3.zero)
        {
            gameObject.transform.forward = move;
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
