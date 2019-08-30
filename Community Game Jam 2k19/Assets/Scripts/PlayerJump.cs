using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    //private Vector2 playerMove;
    private Rigidbody2D rb;
    public PlayerObject player;
    Animator jumpAnimator;
    [SerializeField]
    private float jumpHeight = 5f;
    public bool isJumping = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !player.isStopped)
        {
          //  if(rb.velocity.y >= 0)
          //  {
             //   Debug.Log("Jump");
           //     rb.velocity += Vector2.up * 10f * Physics2D.gravity.y; //Time.deltaTime;// * Time.fixedDeltaTime; //
                rb.AddForce(Vector2.up * Time.fixedDeltaTime * jumpHeight, ForceMode2D.Impulse);
                isJumping = true;
          //  }
        }
        if (player.isStopped)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
    
    }
}
