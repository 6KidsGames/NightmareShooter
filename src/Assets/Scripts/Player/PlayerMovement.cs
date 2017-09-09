using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;
    private int floorMask;
    private float camRayLength = 100f;

    public void Awake()
    {
        // Get the mask from the Floor quad
        floorMask = LayerMask.GetMask("Floor");

        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        Move(horiz, vert);
        Turn();
        Animate(horiz, vert);
    }

    private void Move(float horiz, float vert)
    {
        movement.Set(horiz, 0.0f, vert);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    private void Turn()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    private void Animate(float horiz, float vert)
    {
        bool isWalking = horiz != 0f || vert != 0f;  // Are we moving in either direction?
        anim.SetBool("IsWalking", isWalking);
    }
}
