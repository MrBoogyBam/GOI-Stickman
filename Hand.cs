using UnityEngine;

public class Hand : MonoBehaviour
{
    private Arms arms;

    private Transform handRight;

    private Transform handLeft;

    private HingeJoint2D climbJoint;

    private FixedJoint2D grabJoint;

    public bool isGrabbingRight = false;

    public bool isGrabbingLeft = false;

    private void Start()
    {
        arms = transform.parent.GetComponent<Arms>();
        handRight = transform.parent.Find("Hand_R").GetComponent<Transform>();
        handLeft = transform.parent.Find("Hand_L").GetComponent<Transform>();
        climbJoint = gameObject.AddComponent<HingeJoint2D>();
        grabJoint = gameObject.AddComponent<FixedJoint2D>();

        climbJoint.enabled = false;
        grabJoint.enabled = false;
    }

    private void Update()
    {
        if (!arms.isReachingRight && transform == handRight && (climbJoint.enabled || grabJoint.enabled))
        {
            if(climbJoint.enabled)
            {
                climbJoint.enabled = false;

                isGrabbingRight = false;
            }
            else
            {
                foreach (Collider2D col in transform.parent.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(col, grabJoint.connectedBody.GetComponent<Collider2D>(), false);
                }

                grabJoint.connectedBody = null;
                grabJoint.enabled = false;

                isGrabbingRight = false;
            }
        }

        if (!arms.isReachingLeft && transform == handLeft && (climbJoint.enabled || grabJoint.enabled))
        {
            if(climbJoint.enabled)
            {
                climbJoint.enabled = false;

                isGrabbingLeft = false;
            }
            else
            {
                foreach (Collider2D col in transform.parent.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(col, grabJoint.connectedBody.GetComponent<Collider2D>(), false);
                }

                grabJoint.connectedBody = null;
                grabJoint.enabled = false;

                isGrabbingLeft = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.transform == handRight && arms.isReachingRight && !isGrabbingRight)
        {
            if(collision.rigidbody)
            {
                grabJoint.enabled = true;
                grabJoint.connectedBody = collision.rigidbody;

                foreach(Collider2D col in transform.parent.GetComponentsInChildren<Collider2D>())
                {
                    if(!col.GetComponent<Hand>())
                    {
                        Physics2D.IgnoreCollision(col, grabJoint.connectedBody.GetComponent<Collider2D>());
                    }
                }

                isGrabbingRight = true;
            }
            else
            {
                climbJoint.enabled = true;

                isGrabbingRight = true;
            }
        }

        if (collision.otherCollider.transform == handLeft && arms.isReachingLeft && !isGrabbingLeft)
        {
            if (collision.rigidbody)
            {
                grabJoint.enabled = true;
                grabJoint.connectedBody = collision.rigidbody;

                foreach (Collider2D col in transform.parent.GetComponentsInChildren<Collider2D>())
                {
                    if(!col.GetComponent<Hand>())
                    {
                        Physics2D.IgnoreCollision(col, grabJoint.connectedBody.GetComponent<Collider2D>());
                    }
                }

                isGrabbingLeft = true;
            }
            else
            {
                climbJoint.enabled = true;

                isGrabbingLeft = true;
            }
        }
    }
}

