using UnityEngine;

public class Hands : MonoBehaviour
{
    private Arms arms;

    private Transform handRight;

    private Transform handLeft;

    private HingeJoint2D climbJoint;

    private FixedJoint2D grabJoint;

    private bool canGrabRight = true;

    private bool canGrabLeft = true;

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

                canGrabRight = true;
            }
            else
            {
                foreach (Collider2D col in transform.parent.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(col, grabJoint.connectedBody.GetComponent<Collider2D>(), false);
                }

                grabJoint.connectedBody = null;
                grabJoint.enabled = false;

                canGrabRight = true;
            }
        }

        if (!arms.isReachingLeft && transform == handLeft && (climbJoint.enabled || grabJoint.enabled))
        {
            if(climbJoint.enabled)
            {
                climbJoint.enabled = false;

                canGrabLeft = true;
            }
            else
            {
                foreach (Collider2D col in transform.parent.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(col, grabJoint.connectedBody.GetComponent<Collider2D>(), false);
                }

                grabJoint.connectedBody = null;
                grabJoint.enabled = false;

                canGrabLeft = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.transform == handRight && arms.isReachingRight && canGrabRight)
        {
            if(collision.rigidbody)
            {
                grabJoint.enabled = true;
                grabJoint.connectedBody = collision.rigidbody;

                foreach(Collider2D col in transform.parent.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(col, grabJoint.connectedBody.GetComponent<Collider2D>());
                }

                canGrabRight = false;
            }
            else
            {
                climbJoint.enabled = true;

                canGrabRight = false;
            }
        }

        if (collision.otherCollider.transform == handLeft && arms.isReachingLeft && canGrabLeft)
        {
            if (collision.rigidbody)
            {
                grabJoint.enabled = true;
                grabJoint.connectedBody = collision.rigidbody;

                foreach (Collider2D col in transform.parent.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(col, grabJoint.connectedBody.GetComponent<Collider2D>());
                }

                canGrabLeft = false;
            }
            else
            {
                climbJoint.enabled = true;

                canGrabLeft = false;
            }
        }
    }
}

