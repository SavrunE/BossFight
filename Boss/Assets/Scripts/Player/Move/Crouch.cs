using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Crouch : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField] private float croucherGravitiScale;
    [Range(0.3f, 0.9f)]
    [SerializeField] private float multuiplierYScale;
    private float defaultYScale;

    private float newYScale;

    private void Start()
    {
        defaultYScale = transform.localScale.y;
        newYScale = defaultYScale * multuiplierYScale;
    }
    public void Croucher(Rigidbody2D body, bool isGrounded)
    {
        body.gravityScale *= croucherGravitiScale;
        ChangeTransformY();
    }

    public void ChangeTransformY()
    {
        transform.localScale = new Vector3(transform.localScale.x, newYScale, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, transform.position.y - defaultYScale / 2f, transform.position.z);
    }
    public void ReturnTransform()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + defaultYScale / 2f - newYScale / 2f, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, defaultYScale, transform.localScale.z);
    }
}
