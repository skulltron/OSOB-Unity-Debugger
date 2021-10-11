using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed, JumpingPower;

    public Animator Animator;
    public Rigidbody2D RigidBody;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private bool IsFacingRight;

    private float Horizontal;

    private void Awake()
    {
        IsFacingRight = true;
    }

    public void onMovement(InputAction.CallbackContext Value)
    {
        Horizontal = Value.ReadValue<Vector2>().x;
    }

    public void onJump(InputAction.CallbackContext Value)
    {   
        Debug.Log("Loncat");
        if (IsGrounded())
        {
            RigidBody.velocity = new Vector2(RigidBody.velocity.x, JumpingPower);
        }
    }

    public void onAttack(InputAction.CallbackContext Value)
    {
        Debug.Log("Nyerang");
        Animator.SetTrigger("Attack");
    }

    public void Update()
    {
        var velocity = RigidBody.velocity;

        RigidBody.velocity = new Vector2(Horizontal * MoveSpeed, RigidBody.velocity.y);

        if(!IsFacingRight && Horizontal > 0f)
        {
            Flip();
        }
        else if (IsFacingRight && Horizontal < 0f)
        {
            Flip();
        }

        //animasi loncat jatuh
        else if (!IsGrounded() && RigidBody.velocity.y > 0){
            Animator.SetTrigger("Jumping");
        }
        else if(!IsGrounded() && RigidBody.velocity.y < -2)
        {
            Animator.SetTrigger("Falling");
        }

        Animator.SetFloat("Speed", Mathf.Abs(Horizontal * Time.deltaTime * MoveSpeed));

        transform.position += new Vector3(Horizontal, 0, 0) * Time.deltaTime * MoveSpeed;
        //Debug.Log(transform.rotation);

        //transform.Rotate(0, 180, 0 ,Space.Self);
        //transform.rotation = Quaternion.Angle(transform.rotation, Angle);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }

    private void Flip()
    {
        IsFacingRight        = !IsFacingRight;
        Vector3 LocalScale   = transform.localScale;
        LocalScale.x        *= -1f;
        transform.localScale = LocalScale;
    }
}
