using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    public Animator animator;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        MoventUbdate();
        JampUbdate();

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attak");
        }
    }

    private void JampUbdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = 0;
            _fallVelocity -= jumpForce;

            animator.SetTrigger("jamp");
        }
    }

    private void MoventUbdate()
    {
        _moveVector = Vector3.zero;
        var ranDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            ranDirection = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
    _moveVector += transform.right;
            ranDirection = 3;
        }

        if (Input.GetKey(KeyCode.S))
        {
    _moveVector -= transform.forward;
            ranDirection = 2;
        }

        if (Input.GetKey(KeyCode.A))
        {
    _moveVector -= transform.right;
            ranDirection = 4;
        }

        animator.SetInteger("run direction", ranDirection);
    }
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedUnscaledDeltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }


        }
}
