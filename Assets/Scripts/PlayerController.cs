using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public Animator Animator;
    private bool OnMove;

    public Vector2 InputMovement;

    public void onMovement(InputAction.CallbackContext Value)
    {
        InputMovement = Value.ReadValue<Vector2>();
        OnMove = true;
    }
    public void Update()
    {
        if (OnMove)
        {
            Animator.SetFloat("Speed", Mathf.Abs(InputMovement.x * Time.deltaTime * MoveSpeed));

            transform.position += new Vector3(InputMovement.x, InputMovement.y, 0) * Time.deltaTime * MoveSpeed;
        }
    }
}
