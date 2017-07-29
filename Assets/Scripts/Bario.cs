using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bario : BaseUnit
{
    public KeyCode jumpKey = KeyCode.Space;
    public AudioClip dieSound;
    public AudioClip coinSound;
    
    private bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            // Gets the horizontal inputs (-1 to 1) and move on X
            float horizontalInput = Input.GetAxis("Horizontal");
            Move(horizontalInput);

            // Check if Bario is grounded in both raycasts
            bool isGrounded = IsGrounded(raycastOffsetX) || IsGrounded(-raycastOffsetX);

            // Set animation if Bario is grounded then jump
            anim.SetBool("isJumping", !isGrounded);

            if (Input.GetKeyDown(jumpKey) && isGrounded)
            {
                Jump();
            }

            // Death zone
            if (transform.position.y < -30)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isDead = true;

        // plays death animation in Bario
        anim.SetBool("isDead", true);

        //unpair the camera
        Camera.main.transform.SetParent(null);

        // disable the collider so Bario can fall when he's dead
        GetComponent<Collider2D>().enabled = false;

        // Bario jumps when he dies
        rb.velocity = new Vector2(0, jumpSpeed * 1.5f);

        // unparent Bario. Dettach to everything that can affect Bario's transform 
        transform.SetParent(null);

        audioSource.PlayOneShot(dieSound);

        --ScoreManager.lives;
        StartCoroutine(DoReloadScene());
    }

    private void Jump()
    {
        // Sets the velocity and make the velocity on x the same then apply to rigidbody
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    // collider belongs to a gameobject
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the object that Bario is touching has a Coin component
        // if (other.GetComponent<Coin>() != null)
        //{
        //    CollectCoin(other.gameObject);
        // }
    }

    // Collisions are events
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BadDude>() != null)
        {
            Die();
        }
    }

    IEnumerator DoReloadScene()
    {
        yield return new WaitForSeconds(3);
        // Reload the same scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
