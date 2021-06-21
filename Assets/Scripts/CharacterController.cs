using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour {
    // Public editable values for the speed and force values of the player
    public float moveSpeed;
    public float jumpForce;

    // Reference to the RigidBody2D on this GameObject
    private Rigidbody2D rb;
    // Booleans for action handling
    private bool moveLeft;
    private bool moveRight;
    private bool isGrounded;

    // When this object is enables, get a reference to it's Rigidbody2D element
    void OnEnable() {
        rb = this.GetComponent<Rigidbody2D>();
    }

    #region Input Action Listeners

    public void JumpAction(InputAction.CallbackContext obj) {
        if (obj.phase == InputActionPhase.Performed)
            Jump();
    }

    public void MoveRightAction(InputAction.CallbackContext obj) {
        if (obj.phase == InputActionPhase.Performed)
            moveRight = true;
        else if (obj.phase == InputActionPhase.Canceled)
            moveRight = false;
    }

    public void MoveLeftAction(InputAction.CallbackContext obj) {
        if (obj.phase == InputActionPhase.Performed)
            moveLeft = true;
        else if (obj.phase == InputActionPhase.Canceled)
            moveLeft = false;
    }

    #endregion

    #region Input Action Executers

    private void Jump() {
        if (isGrounded)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void MoveLeft() {
        transform.position += new Vector3(-1f, 0, 0) * moveSpeed * Time.deltaTime;
    }

    public void MoveRight() {
        transform.position += new Vector3(1f, 0, 0) * moveSpeed * Time.deltaTime;
    }

    #endregion

    // Update function ensures the movement is handled every grame rather than only on a key press
    private void Update() {
        if (moveLeft)
            MoveLeft();
        if (moveRight)
            MoveRight();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
