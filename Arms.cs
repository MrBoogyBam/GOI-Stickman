using System.Collections;
using UnityEngine;

public class Arms : MonoBehaviour
{
    private Hand rightHand;

    private Hand leftHand;

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

        foreach(Hand hand in GetComponentsInChildren<Hand>())
        {
            if(hand.name == "Hand_R")
            {
                rightHand = hand;
            }
            else
            {
                leftHand = hand;
            }
        }

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
            if(Input.GetKey(KeyCode.LeftShift) && rightHand.isGrabbingRight)
            {
                foreach (Rigidbody2D arm in rightArms)
                {
                    Vector2 difference = mousePos - (Vector2)arm.transform.position;
                    float desiredRotation = Mathf.Atan2(-difference.x, difference.y) * Mathf.Rad2Deg;

                    arm.MoveRotation(Mathf.LerpAngle(arm.rotation, desiredRotation, rotationForce * Time.deltaTime));
                }
            }
            else
            {
                foreach (Rigidbody2D arm in rightArms)
                {
                    Vector2 difference = mousePos - (Vector2)arm.transform.position;
                    float desiredRotation = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;

                    arm.MoveRotation(Mathf.LerpAngle(arm.rotation, desiredRotation, rotationForce * Time.deltaTime));
                }
            }
        }
        
        if(isReachingLeft)
        {
            if(Input.GetKey(KeyCode.LeftShift) && leftHand.isGrabbingLeft)
            {
                foreach (Rigidbody2D arm in leftArms)
                {
                    Vector2 difference = mousePos - (Vector2)arm.transform.position;
                    float desiredRotation = Mathf.Atan2(-difference.x, difference.y) * Mathf.Rad2Deg;

                    arm.MoveRotation(Mathf.LerpAngle(arm.rotation, desiredRotation, rotationForce * Time.deltaTime));
                }
            }
            else
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
}
