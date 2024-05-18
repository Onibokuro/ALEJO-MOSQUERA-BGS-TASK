using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(100.0f, 100.0f); 
    private new Rigidbody2D rigidbody2D; 
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);
    [SerializeField] private Animator[] animators;

    void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Animate();
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
    }

    private void Animate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            foreach(Animator animator in animators)
            {
                animator.SetFloat("x", Input.GetAxis("Horizontal"));
                animator.SetFloat("y", Input.GetAxis("Vertical"));
            }
            
        }
    }
}
