using System.Collections;
using UnityEngine;

public class Arms : MonoBehaviour
{
    private Rigidbody2D[] rightArms;

    private Rigidbody2D[] leftArms;

    [SerializeField]
    private float rotationForce = 70f;

    public bool isReachingRight;

    public bool isReachingLeft;

    private void Start()
    {
        rightArms = new Rigidbody2D[2];
        leftArms = new Rigidbody2D[2];

        rightArms[0] = transform.Find("Arm_UR").GetComponent<Rigidbody2D>();
        rightArms[1] = transform.Find("Arm_LR").GetComponent<Rigidbody2D>();
        leftArms[0] = transform.Find("Arm_UL").GetComponent<Rigidbody2D>();
        leftArms[1] = transform.Find("Arm_LL").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isReachingRight = Input.GetMouseButton(1);
        isReachingLeft = Input.GetMouseButton(0);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(isReachingRight)
        {
            foreach(Rigidbody2D arm in rightArms)
            {
                Vector2 difference = mousePos - (Vector2)arm.transform.position;
                float desiredRotation = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;

                arm.MoveRotation(Mathf.LerpAngle(arm.rotation, desiredRotation, rotationForce * Time.deltaTime));
            }
        }
        
        if(isReachingLeft)
        {
            foreach (Rigidbody2D arm in leftArms)
            {
                Vector2 difference = mousePos - (Vector2)arm.transform.position;
                float desiredRotation = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;

                arm.MoveRotation(Mathf.LerpAngle(arm.rotation, desiredRotation, rotationForce * Time.deltaTime));
            }
        }
    }
}
