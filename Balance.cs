using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    private BodyParts[] bodyParts = new BodyParts[6];

    private PlayerMovement playerMovement;

    // private Arms arms;

    private Transform head;

    private Transform[] feet = new Transform[2];

    [SerializeField]
    private LayerMask whatIsGround;

    private Rigidbody2D headRb;

    public float balanceForce = 3000;

    public bool isGrounded;

    public bool isCrouching;

    private void Start()
    {
        head = GameObject.Find("Head").GetComponent<Transform>();
        headRb = head.GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        // arms = GetComponent<Arms>();

        whatIsGround |= (1 << LayerMask.NameToLayer("Player"));

        bodyParts[0] = new BodyParts();
        bodyParts[1] = new BodyParts();
        bodyParts[2] = new BodyParts();
        bodyParts[3] = new BodyParts();
        bodyParts[4] = new BodyParts();
        bodyParts[5] = new BodyParts();

        bodyParts[0].bodyPart = transform.Find("Chest").GetComponent<Rigidbody2D>();
        bodyParts[1].bodyPart = transform.Find("Torso").GetComponent<Rigidbody2D>();
        bodyParts[2].bodyPart = transform.Find("Leg_UR").GetComponent<Rigidbody2D>();
        bodyParts[3].bodyPart = transform.Find("Leg_UL").GetComponent<Rigidbody2D>();
        bodyParts[4].bodyPart = transform.Find("Leg_LR").GetComponent<Rigidbody2D>();
        bodyParts[5].bodyPart = transform.Find("Leg_LL").GetComponent<Rigidbody2D>();

        bodyParts[2].rotationAngle = 12;
        bodyParts[3].rotationAngle = -12;
        bodyParts[4].rotationAngle = 12;
        bodyParts[5].rotationAngle = -12;

        feet[0] = GameObject.Find("Foot_R").GetComponent<Transform>();
        feet[1] = GameObject.Find("Foot_L").GetComponent<Transform>();
    }

    private void Update()
    {
        isCrouching = Input.GetKey(KeyCode.LeftControl);

        foreach (Transform foot in feet)
        {
            RaycastHit2D hit = Physics2D.Raycast(foot.position, Vector2.down, 0.8f, ~whatIsGround);

            isGrounded = hit == true;
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded && !isCrouching)
        {
            headRb.AddForce(Vector2.up * balanceForce);

            if (!playerMovement.isRunning)
            {
                foreach (BodyParts part in bodyParts)
                {
                    part.bodyPart.MoveRotation(Mathf.LerpAngle(part.bodyPart.rotation, part.rotationAngle, part.rotationForce * Time.fixedDeltaTime));
                }
            }
        }
    }
}

public class BodyParts
{
    public Rigidbody2D bodyPart;
    public float rotationForce = 45;
    public float rotationAngle = 0;
}
