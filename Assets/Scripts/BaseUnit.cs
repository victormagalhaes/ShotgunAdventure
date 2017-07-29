using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public float speed = 5;
    public float jumpSpeed = 12;
    public float raycastDistance = 0.1f;
    public float raycastOffsetX = 0.4f;

    protected Rigidbody2D rb;
    protected SpriteRenderer rend;
    protected Animator anim;
    protected AudioSource audioSource;

    // Tip: if we put this, visual studio will warn us in children
    protected void Start()
    {
        // Get the reference to the rigidbody component in my Game Object
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    protected void Move(float direction)
    {
        // Check if Bario is running to left or right then flip sprite
        if (direction > 0)
        {
            rend.flipX = false;
        }
        else if (direction < 0)
        {
            rend.flipX = true;
        }

        // Sets the velocity and make the velocity on y the same then apply to rigidbody
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        //Set Animation moveSpeed value to direction
        anim.SetFloat("moveSpeed", Mathf.Abs(direction));
    }

    protected bool IsGrounded(float offsetX)
    {
        // Bario's pivot point and offset in X
        Vector2 origin = transform.position;
        origin.x += offsetX;

        // Create raycast to towards down direction 
        Debug.DrawRay(origin, Vector3.down * raycastDistance);

        // Return true or false if in origin towards down there is collision in raycastDistance
        RaycastHit2D hitInfo = Physics2D.Raycast(origin, Vector2.down, raycastDistance);

        // when im jumping or not hitting a collider...
        if (hitInfo.collider == null)
        {
            transform.SetParent(null);
            return false;
        }

        // if im raycasting a platform...
        if (hitInfo.collider.GetComponent<MovingPlatform>() != null)
        {
            // Parent unity to moving platform
            transform.SetParent(hitInfo.transform);
        }
        else
        {
            transform.SetParent(null);
        }

        return hitInfo;
    }
}
