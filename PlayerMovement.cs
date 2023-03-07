using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Balance balance;

    private Rigidbody2D rightLeg;

    private Rigidbody2D leftLeg;

    private Rigidbody2D chest;

    private Rigidbody2D torso;

    [SerializeField]
    private float speed = 700f;

    [SerializeField]
    private float steppingForce = 100;

    [SerializeField]
    private float jumpForce = 1200;

    [SerializeField]
    private float duration = 0.5f;

    [SerializeField]
    private float balanceForce = 65;

    [HideInInspector]
    public float rotationAngle;

    [SerializeField]
    private float maxRotationAngle = 70;

    private float originalBalanceForce;

    private float headBalanceForce = 750;

    private float direction;

    [HideInInspector]
    public bool isRunning;

    private void Start()
    {
        balance = GetComponent<Balance>();
        chest = transform.Find("Chest").GetComponent<Rigidbody2D>();
        torso = transform.Find("Torso").GetComponent<Rigidbody2D>();
        rightLeg = transform.Find("Leg_LR").GetComponent<Rigidbody2D>();
        leftLeg = transform.Find("Leg_LL").GetComponent<Rigidbody2D>();
        originalBalanceForce = balance.balanceForce;

        Animation anim = gameObject.AddComponent<Animation>();
        AnimationClip clip = new AnimationClip();

        clip.legacy = true;

        Keyframe[] keys = new Keyframe[3];

        keys[0] = new Keyframe(0, maxRotationAngle);
        keys[1] = new Keyframe(duration / 2, -maxRotationAngle);
        keys[2] = new Keyframe(duration, maxRotationAngle);

        AnimationCurve curve = new AnimationCurve(keys);

        clip.SetCurve("", typeof(PlayerMovement), "rotationAngle", curve);
        clip.wrapMode = WrapMode.Loop;

        anim.AddClip(clip, "Walking");
        anim.Play("Walking");
    }

    private void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        isRunning = direction != 0;

        if (Input.GetKeyDown(KeyCode.Space) && !balance.isCrouching && balance.isGrounded)
        {
            foreach (Rigidbody2D rb in GetComponentsInChildren<Rigidbody2D>())
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }

            leftLeg.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rightLeg.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if(balance.isGrounded && isRunning)
        {
            torso.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, torso.velocity.y);
            balance.balanceForce = headBalanceForce + originalBalanceForce;

            chest.MoveRotation(Mathf.LerpAngle(chest.rotation, 0, balanceForce * Time.fixedDeltaTime));
            torso.MoveRotation(Mathf.LerpAngle(torso.rotation, 0, balanceForce * Time.fixedDeltaTime));
            leftLeg.MoveRotation(Mathf.LerpAngle(leftLeg.rotation, rotationAngle, steppingForce * Time.fixedDeltaTime));
            rightLeg.MoveRotation(Mathf.LerpAngle(rightLeg.rotation, -rotationAngle, steppingForce * Time.fixedDeltaTime));
        }
        else
        {
            balance.balanceForce = originalBalanceForce;
        }
    }
}
