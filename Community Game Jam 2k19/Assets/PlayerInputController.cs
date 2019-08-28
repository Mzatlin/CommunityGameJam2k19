using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public float playerMove;
    public Animator playerAnimator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
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
        FlipSprite(playerMove);
        playerAnimator.SetFloat("Speed", Mathf.Abs(playerMove));
        rb.velocity = new Vector2(playerMove, rb.velocity.y);

    }
    void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
