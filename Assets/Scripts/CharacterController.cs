using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float movementSpeed = 8f;
    private float movement;
    private Animator animator;

    private float JumpForce = 12f;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Dialogue.didDialogueStart == false)
        {

            movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

            

            if (!Mathf.Approximately(0, movement))
            {
                transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            }

            if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidBody.velocity.y) < 0.001f)
            {
                //animator.SetBool("IsJumping", false);
                rigidBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }

            
        }

        animator.SetFloat("Speed", Mathf.Abs(movement));

    }
}
