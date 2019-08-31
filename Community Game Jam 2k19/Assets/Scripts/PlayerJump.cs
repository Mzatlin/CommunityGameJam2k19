using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    //private Vector2 playerMove;
    private Rigidbody2D rb;
    [SerializeField]
    Animator jumpAnimation;
    public PlayerObject player;
    bool isgrounded = true;
    Animator jumpAnimator;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    private float jumpHeight = 4f;
    public bool isJumping = false;
    Ray2D ray;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (!isgrounded)
        {
            Debug.DrawLine(transform.position, -transform.up);
            if (Physics2D.Raycast(transform.position, -transform.up, 1.5f, LayerMask.GetMask("Floor")))
            {
                isgrounded = true;
                isJumping = false;
               // jumpAnimation.SetBool("IsJumping", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !player.isStopped && isgrounded)
        {
          //  if(rb.velocity.y >= 0)
          //  {
             //   Debug.Log("Jump");
           //     rb.velocity += Vector2.up * 10f * Physics2D.gravity.y; //Time.deltaTime;// * Time.fixedDeltaTime; //
                rb.AddForce(Vector2.up *Time.fixedDeltaTime * jumpHeight, ForceMode2D.Impulse);
                isJumping = true;
                isgrounded = false;
             //   jumpAnimation.SetBool("IsJumping", true);
          //  }
        }
        if (player.isStopped)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
    
    }
}
