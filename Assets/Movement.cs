using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float jumpHeight = 5.0f, initialSpeed = 2.0f, currentTime = 0;
    Rigidbody2D rb;
    public LayerMask groundLayer, obstacle;
    public Animator anim;
    public BoxCollider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("Dinosaur").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        rb.position += Vector2.right * (initialSpeed * (0.75f + (2*currentTime + 1)/(currentTime + 4))) * Time.deltaTime;
        Jump();
        Duck();
        IsTouchingObstacle();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsTouchingGround())
        {
            rb.velocity += (Vector2.up * jumpHeight);
        }

        if (IsTouchingGround()) anim.SetBool("isJumping", false);
        if (!IsTouchingGround()) anim.SetBool("isJumping", true);
    }

    void Duck()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isDucking", true);

            hitbox.size = new Vector2(0.44f, 0.35f);
            hitbox.offset = new Vector2(0, -0.06f);
        }

        else 
        {
            anim.SetBool("isDucking", false);
            hitbox.size = new Vector2(0.44f, 0.47f);
            hitbox.offset = Vector2.zero;
        }
    }

    bool IsTouchingGround()
    {
        if (rb.IsTouchingLayers(groundLayer))
        {
            return true;
        }

        else return false;
    }

    void IsTouchingObstacle()
    {
        if (rb.IsTouchingLayers(obstacle))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
