using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpDelay;
    [SerializeField] private bool canJump;

    private void Start()
    {
        canJump = true;
    }
    public void Jumper(Rigidbody2D body, bool isGrounded)
    {
        if (isGrounded && canJump)
        {
            StartCoroutine(JumpDelayTimer());
            body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    private IEnumerator JumpDelayTimer()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpDelay);
        canJump = true;
    }
}
