using UnityEngine;
using UnityEngine.InputSystem; // 👈 for the new Input System

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        // Apply gravity
        direction += Vector3.down * gravity * Time.deltaTime;

        // Grounded check
        if (character.isGrounded)
        {
            direction = Vector3.down;

            // New Input System: check if space key is pressed
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Debug.Log("Jump pressed");
                direction = Vector3.up * jumpForce;
            }
        }

        // Move the character
        character.Move(direction * Time.deltaTime);
    }
}
