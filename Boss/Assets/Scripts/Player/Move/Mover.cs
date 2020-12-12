using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    public bool LookOnLeft = false;

    [SerializeField] private float moveSpeed;
    [SerializeField] Transform groundCheker;

    private float defaultGravityScale;

    private Rigidbody2D body;
    private Crouch crouch;
    private Jump jump;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        crouch = GetComponent<Crouch>();
        jump = GetComponent<Jump>();

        defaultGravityScale = body.gravityScale;
    }
    private void FixedUpdate()
    {
        CheckHorizontalInput();
        
    }
    private void Update()
    {
        CheckVerticalInput();
    }
    private void CheckHorizontalInput()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            Move();
        }
    }
    private void CheckVerticalInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump.Jumper(body, CheckGround());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            crouch.Croucher(body, CheckGround());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            ReturnToDefaultSettings();
        }
    }
    private void ReturnToDefaultSettings()
    {
        ReturnGravity();
        crouch.ReturnTransformY();
    }
    private bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheker.position, 0.2f);
        return colliders.Length > 1;
    }
    public void ReturnGravity()
    {
        body.gravityScale = defaultGravityScale;
    }
    private void Move()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime, body.velocity.y);
        if (LookOnLeft == true && body.velocity.x > 0)
            Flip();
        else if (LookOnLeft == false && body.velocity.x < 0)
            Flip();
    }
    private void Flip()
    {
        LookOnLeft = !LookOnLeft;
    }
}
