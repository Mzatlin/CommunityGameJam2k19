using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public float playerMove;
    public PlayerObject player;
    public Animator playerAnimator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector3 playerScale;
    private bool isFlipped;
    [SerializeField]
    private float playerSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMove = Input.GetAxis("Horizontal") * playerSpeed;
        playerAnimator.SetFloat("Speed", Mathf.Abs(playerMove));
        if (!isFlipped && playerMove > 0 && !player.isStopped)
        {
            FlipSprite();
        }
        else if (isFlipped && playerMove < 0 && !player.isStopped)
        {
            FlipSprite();
        }
        if (player.isStopped)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(playerMove, rb.velocity.y);
        }



    }
    void FlipSprite()
    {
        playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
        isFlipped = !isFlipped;
    }
}
