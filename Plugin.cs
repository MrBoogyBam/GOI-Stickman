using UnityEngine;
using UnityEngine.SceneManagement;
using BepInEx;
using System.Collections.Generic;
using System;

namespace Stickman
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private GameObject player;

        private GameObject stickman;

        private void Awake()
        {
            SceneManager.sceneLoaded += SceneLoaded;
        }

        private void Update()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if(SceneManager.GetActiveScene().name == "Mian")
            {
                player.transform.position = stickman.transform.Find("Chest").position;
            }
        }

        private void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(scene.name == "Mian")
            {
                player = GameObject.Find("Player");

                player.GetComponent<Collider2D>().enabled = false;
                player.GetComponent<Rigidbody2D>().isKinematic = true;

                foreach(Collider2D col in player.GetComponentsInChildren<Collider2D>())
                {
                    col.enabled = false;
                }

                foreach(Rigidbody2D rb in player.GetComponentsInChildren<Rigidbody2D>())
                {
                    rb.isKinematic = true;
                }

                foreach(Renderer renderer in player.GetComponentsInChildren<Renderer>())
                {
                    renderer.enabled = false;
                }

                GameObject.Find("Cursor").SetActive(false);

                stickman = new GameObject("Stickman");

                stickman.transform.position = new Vector3(GameObject.Find("Player").transform.position.x + 4, GameObject.Find("Player").transform.position.y + 3, GameObject.Find("Player").transform.position.z);

                GameObject head = new GameObject("Head");
                GameObject chest = new GameObject("Chest");
                GameObject torso = new GameObject("Torso");
                GameObject armUpperRight = new GameObject("Arm_UR");
                GameObject elbowRight = new GameObject("Elbow_R");
                GameObject armLowerRight = new GameObject("Arm_LR");
                GameObject handRight = new GameObject("Hand_R");
                GameObject armUpperLeft = new GameObject("Arm_UL");
                GameObject elbowLeft = new GameObject("Elbow_R");
                GameObject armLowerLeft = new GameObject("Arm_LL");
                GameObject handLeft = new GameObject("Hand_L");
                GameObject legUpperRight = new GameObject("Leg_UR");
                GameObject kneeRight = new GameObject("Knee_R");
                GameObject legLowerRight = new GameObject("Leg_LR");
                GameObject footRight = new GameObject("Foot_R");
                GameObject legUpperLeft = new GameObject("Leg_UL");
                GameObject kneeLeft = new GameObject("Knee_L");
                GameObject legLowerLeft = new GameObject("Leg_LL");
                GameObject footLeft = new GameObject("Foot_L");

                SpriteRenderer headRenderer = head.AddComponent<SpriteRenderer>();
                SpriteRenderer chestRenderer = chest.AddComponent<SpriteRenderer>();
                SpriteRenderer torsoRenderer = torso.AddComponent<SpriteRenderer>();
                SpriteRenderer armURRenderer = armUpperRight.AddComponent<SpriteRenderer>();
                SpriteRenderer elbowRRenderer = elbowRight.AddComponent<SpriteRenderer>();
                SpriteRenderer armLRRenderer = armLowerRight.AddComponent<SpriteRenderer>();
                SpriteRenderer handRRenderer = handRight.AddComponent<SpriteRenderer>();
                SpriteRenderer armULRenderer = armUpperLeft.AddComponent<SpriteRenderer>();
                SpriteRenderer elbowLRenderer = elbowLeft.AddComponent<SpriteRenderer>();
                SpriteRenderer armLLRenderer = armLowerLeft.AddComponent<SpriteRenderer>();
                SpriteRenderer handLRenderer = handLeft.AddComponent<SpriteRenderer>();
                SpriteRenderer legURRenderer = legUpperRight.AddComponent<SpriteRenderer>();
                SpriteRenderer kneeRRenderer = kneeRight.AddComponent<SpriteRenderer>();
                SpriteRenderer legLRRenderer = legLowerRight.AddComponent<SpriteRenderer>();
                SpriteRenderer footRRenderer = footRight.AddComponent<SpriteRenderer>();
                SpriteRenderer legULRenderer = legUpperLeft.AddComponent<SpriteRenderer>();
                SpriteRenderer kneeLRenderer = kneeLeft.AddComponent<SpriteRenderer>();
                SpriteRenderer legLLRenderer = legLowerLeft.AddComponent<SpriteRenderer>();
                SpriteRenderer footLRenderer = footLeft.AddComponent<SpriteRenderer>();

                headRenderer.sprite = Circle(50);
                chestRenderer.sprite = Box(100, 100);
                torsoRenderer.sprite = Box(100, 100);
                armURRenderer.sprite = Box(100, 100);
                elbowRRenderer.sprite = Circle(50);
                armLRRenderer.sprite = Box(100, 100);
                handRRenderer.sprite = Circle(50);
                armULRenderer.sprite = Box(100, 100);
                elbowLRenderer.sprite = Circle(50);
                armLLRenderer.sprite = Box(100, 100);
                handLRenderer.sprite = Circle(50);
                legURRenderer.sprite = Box(100, 100);
                kneeRRenderer.sprite = Circle(50);
                legLRRenderer.sprite = Box(100, 100);
                footRRenderer.sprite = Circle(50);
                legULRenderer.sprite = Box(100, 100);
                kneeLRenderer.sprite = Circle(50);
                legLLRenderer.sprite = Box(100, 100);
                footLRenderer.sprite = Circle(50);

                foreach(Transform part in stickman.GetComponentsInChildren<Transform>())
                {
                    part.parent = stickman.transform;
                }

                head.transform.localScale = Vector2.one * 0.6f;
                chest.transform.localScale = new Vector2(0.12f, 0.5f);
                torso.transform.localScale = new Vector2(0.12f, 0.5f);
                armUpperRight.transform.localScale = new Vector2(0.12f, 0.45f);
                elbowRight.transform.localScale = Vector2.one * 0.12f;
                armLowerRight.transform.localScale = new Vector2(0.12f, 0.45f);
                handRight.transform.localScale = Vector2.one * 0.14f;
                armUpperLeft.transform.localScale = new Vector2(0.12f, 0.45f);
                elbowLeft.transform.localScale = Vector2.one * 0.12f;
                armLowerLeft.transform.localScale = new Vector2(0.12f, 0.45f);
                handLeft.transform.localScale = Vector2.one * 0.14f;
                legUpperRight.transform.localScale = new Vector2(0.12f, 0.48f);
                kneeRight.transform.localScale = Vector2.one * 0.12f;
                legLowerRight.transform.localScale = new Vector2(0.12f, 0.48f);
                footRight.transform.localScale = Vector2.one * 0.12f;
                legUpperLeft.transform.localScale = new Vector2(0.12f, 0.48f);
                kneeLeft.transform.localScale = Vector2.one * 0.12f;
                legLowerLeft.transform.localScale = new Vector2(0.12f, 0.48f);
                footLeft.transform.localScale = Vector2.one * 0.12f;

                head.transform.localPosition = new Vector2(0, chestRenderer.bounds.extents.y + headRenderer.bounds.extents.y - 0.01f);
                chest.transform.localPosition = Vector2.zero;
                torso.transform.localPosition = new Vector2(0, -chestRenderer.bounds.extents.y - torsoRenderer.bounds.extents.y + 0.01f);
                armUpperRight.transform.localPosition = new Vector2(0, chestRenderer.bounds.extents.y - armURRenderer.bounds.extents.y);
                elbowRight.transform.localPosition = new Vector2(0, -armURRenderer.bounds.extents.y);
                armLowerRight.transform.localPosition = new Vector2(0, -armURRenderer.bounds.extents.y - armLRRenderer.bounds.extents.y);
                handRight.transform.localPosition = new Vector2(0, -armURRenderer.bounds.extents.y - armULRenderer.bounds.extents.y * 2);
                armUpperLeft.transform.localPosition = new Vector2(0, chestRenderer.bounds.extents.y - armULRenderer.bounds.extents.y);
                elbowLeft.transform.localPosition = new Vector2(0, -armULRenderer.bounds.extents.y);
                armLowerLeft.transform.localPosition = new Vector2(0, -armULRenderer.bounds.extents.y - armLLRenderer.bounds.extents.y);
                handLeft.transform.localPosition = new Vector2(0, -armULRenderer.bounds.extents.y - armLLRenderer.bounds.extents.y * 2);
                legUpperRight.transform.localPosition = new Vector2(0, -torsoRenderer.bounds.extents.y * 3 - legURRenderer.bounds.extents.y + 0.01f);
                kneeRight.transform.localPosition = new Vector2(0, -chestRenderer.bounds.extents.y - torsoRenderer.bounds.extents.y * 2 - legURRenderer.bounds.extents.y * 2);
                legLowerRight.transform.localPosition = new Vector2(0, -chestRenderer.bounds.extents.y - torsoRenderer.bounds.extents.y * 2 - legURRenderer.bounds.extents.y * 2 - legLRRenderer.bounds.extents.y);
                footRight.transform.localPosition = new Vector2(0, -chestRenderer.bounds.extents.y - torsoRenderer.bounds.extents.y * 2 - legURRenderer.bounds.extents.y * 2 - legLRRenderer.bounds.extents.y * 2);
                legUpperLeft.transform.localPosition = new Vector2(0, -torsoRenderer.bounds.extents.y * 3 - legULRenderer.bounds.extents.y + 0.01f);
                kneeLeft.transform.localPosition = new Vector2(0, -chestRenderer.bounds.extents.y - torsoRenderer.bounds.extents.y * 2 - legULRenderer.bounds.extents.y * 2);
                legLowerLeft.transform.localPosition = new Vector2(0, -chestRenderer.bounds.extents.y - torsoRenderer.bounds.extents.y * 2 - legULRenderer.bounds.extents.y * 2 - legLLRenderer.bounds.extents.y);
                footLeft.transform.localPosition = new Vector2(0, -chestRenderer.bounds.extents.y - torsoRenderer.bounds.extents.y * 2 - legULRenderer.bounds.extents.y * 2 - legLLRenderer.bounds.extents.y * 2);

                head.AddComponent<CircleCollider2D>();
                chest.AddComponent<BoxCollider2D>();
                torso.AddComponent<BoxCollider2D>();
                armUpperRight.AddComponent<BoxCollider2D>();
                elbowRight.AddComponent<CircleCollider2D>();
                armLowerRight.AddComponent<BoxCollider2D>();
                handRight.AddComponent<CircleCollider2D>();
                armUpperLeft.AddComponent<BoxCollider2D>();
                elbowLeft.AddComponent<CircleCollider2D>();
                armLowerLeft.AddComponent<BoxCollider2D>();
                handLeft.AddComponent<CircleCollider2D>();
                legUpperRight.AddComponent<BoxCollider2D>();
                kneeRight.AddComponent<CircleCollider2D>();
                legLowerRight.AddComponent<BoxCollider2D>();
                footRight.AddComponent<CircleCollider2D>();
                legUpperLeft.AddComponent<BoxCollider2D>();
                kneeLeft.AddComponent<CircleCollider2D>();
                legLowerLeft.AddComponent<BoxCollider2D>();
                footLeft.AddComponent<CircleCollider2D>();

                Collider2D[] colliders = stickman.GetComponentsInChildren<Collider2D>();
                PhysicsMaterial2D frictionMat = new PhysicsMaterial2D();

                frictionMat.friction = 0.04f;
                frictionMat.bounciness = 0;

                for (int i = 0; i < colliders.Length; i++)
                {
                    for (int j = i + 1; j < colliders.Length; j++)
                    {
                        Physics2D.IgnoreCollision(colliders[i], colliders[j]);
                    }

                    colliders[i].sharedMaterial = frictionMat;
                }

                Rigidbody2D headRb = head.AddComponent<Rigidbody2D>();
                Rigidbody2D chestRb = chest.AddComponent<Rigidbody2D>();
                Rigidbody2D torsoRb = torso.AddComponent<Rigidbody2D>();
                Rigidbody2D armURRb = armUpperRight.AddComponent<Rigidbody2D>();
                Rigidbody2D elbowRRb = elbowRight.AddComponent<Rigidbody2D>();
                Rigidbody2D armLRRb = armLowerRight.AddComponent<Rigidbody2D>();
                Rigidbody2D handRRb = handRight.AddComponent<Rigidbody2D>();
                Rigidbody2D armULRb = armUpperLeft.AddComponent<Rigidbody2D>();
                Rigidbody2D elbowLRb = elbowLeft.AddComponent<Rigidbody2D>();
                Rigidbody2D armLLRb = armLowerLeft.AddComponent<Rigidbody2D>();
                Rigidbody2D handLRb = handLeft.AddComponent<Rigidbody2D>();
                Rigidbody2D legURRb = legUpperRight.AddComponent<Rigidbody2D>();
                Rigidbody2D kneeRRb = kneeRight.AddComponent<Rigidbody2D>();
                Rigidbody2D legLRRb = legLowerRight.AddComponent<Rigidbody2D>();
                Rigidbody2D footRRb = footRight.AddComponent<Rigidbody2D>();
                Rigidbody2D legULRb = legUpperLeft.AddComponent<Rigidbody2D>();
                Rigidbody2D kneeLRb = kneeLeft.AddComponent<Rigidbody2D>();
                Rigidbody2D legLLRb = legLowerLeft.AddComponent<Rigidbody2D>();
                Rigidbody2D footLRb = footLeft.AddComponent<Rigidbody2D>();

                Rigidbody2D[] rigidbodies = stickman.GetComponentsInChildren<Rigidbody2D>();

                foreach(Rigidbody2D rb in rigidbodies)
                {
                    rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                    rb.mass = 10;
                }

                HingeJoint2D headJoint = head.AddComponent<HingeJoint2D>();
                HingeJoint2D torsoJoint = torso.AddComponent<HingeJoint2D>();
                HingeJoint2D armURJoint = armUpperRight.AddComponent<HingeJoint2D>();
                FixedJoint2D elbowRJoint = elbowRight.AddComponent<FixedJoint2D>();
                HingeJoint2D armLRJoint = armLowerRight.AddComponent<HingeJoint2D>();
                FixedJoint2D handRJoint = handRight.AddComponent<FixedJoint2D>();
                HingeJoint2D armULJoint = armUpperLeft.AddComponent<HingeJoint2D>();
                FixedJoint2D elbowLJoint = elbowLeft.AddComponent<FixedJoint2D>();
                HingeJoint2D armLLJoint = armLowerLeft.AddComponent<HingeJoint2D>();
                FixedJoint2D handLJoint = handLeft.AddComponent<FixedJoint2D>();
                HingeJoint2D legURJoint = legUpperRight.AddComponent<HingeJoint2D>();
                FixedJoint2D kneeRJoint = kneeRight.AddComponent<FixedJoint2D>();
                HingeJoint2D legLRJoint = legLowerRight.AddComponent<HingeJoint2D>();
                FixedJoint2D footRJoint = footRight.AddComponent<FixedJoint2D>();
                HingeJoint2D legULJoint = legUpperLeft.AddComponent<HingeJoint2D>();
                FixedJoint2D kneeLJoint = kneeLeft.AddComponent<FixedJoint2D>();
                HingeJoint2D legLLJoint = legLowerLeft.AddComponent<HingeJoint2D>();
                FixedJoint2D footLJoint = footLeft.AddComponent<FixedJoint2D>();

                headJoint.connectedBody = chestRb;
                headJoint.anchor = new Vector2(0, -head.transform.localScale.y);
                headJoint.autoConfigureConnectedAnchor = false;
                headJoint.useLimits = true;
                torsoJoint.connectedBody = chestRb;
                torsoJoint.anchor = new Vector2(0, torso.transform.localScale.y);
                torsoJoint.autoConfigureConnectedAnchor = false;
                torsoJoint.useLimits = true;
                armURJoint.connectedBody = chestRb;
                armURJoint.anchor = new Vector2(0, armUpperRight.transform.localScale.y);
                armURJoint.autoConfigureConnectedAnchor = false;
                elbowRJoint.connectedBody = armURRb;
                elbowRJoint.autoConfigureConnectedAnchor = false;
                armLRJoint.connectedBody = elbowRRb;
                armLRJoint.anchor = new Vector2(0, armLowerRight.transform.localScale.y);
                armLRJoint.autoConfigureConnectedAnchor = false;
                handRJoint.connectedBody = armLRRb;
                handRJoint.autoConfigureConnectedAnchor = false;
                armULJoint.connectedBody = chestRb;
                armULJoint.anchor = new Vector2(0, armUpperLeft.transform.localScale.y);
                armULJoint.autoConfigureConnectedAnchor = false;
                elbowLJoint.connectedBody = armULRb;
                elbowLJoint.autoConfigureConnectedAnchor = false;
                armLLJoint.connectedBody = elbowLRb;
                armLLJoint.anchor = new Vector2(0, armLowerLeft.transform.localScale.y);
                armLLJoint.autoConfigureConnectedAnchor = false;
                handLJoint.connectedBody = armLLRb;
                handLJoint.autoConfigureConnectedAnchor = false;
                legURJoint.connectedBody = torsoRb;
                legURJoint.anchor = new Vector2(0, legUpperRight.transform.localScale.y);
                legURJoint.autoConfigureConnectedAnchor = false;
                kneeRJoint.connectedBody = legURRb;
                kneeRJoint.autoConfigureConnectedAnchor = false;
                legLRJoint.connectedBody = kneeRRb;
                legLRJoint.anchor = new Vector2(0, legLowerRight.transform.localScale.y);
                legLRJoint.autoConfigureConnectedAnchor = false;
                footRJoint.connectedBody = legLRRb;
                footRJoint.autoConfigureConnectedAnchor = false;
                legULJoint.connectedBody = torsoRb;
                legULJoint.anchor = new Vector2(0, legUpperLeft.transform.localScale.y);
                legULJoint.autoConfigureConnectedAnchor = false;
                kneeLJoint.connectedBody = legULRb;
                kneeLJoint.autoConfigureConnectedAnchor = false;
                legLLJoint.connectedBody = kneeLRb;
                legLLJoint.anchor = new Vector2(0, legLowerLeft.transform.localScale.y);
                legLLJoint.autoConfigureConnectedAnchor = false;
                footLJoint.connectedBody = legLLRb;
                footLJoint.autoConfigureConnectedAnchor = false;

                JointAngleLimits2D headLimits = headJoint.limits;
                JointAngleLimits2D torsoLimits = torsoJoint.limits;
                JointAngleLimits2D legURLimits = legURJoint.limits;
                JointAngleLimits2D legLRLimits = legLRJoint.limits;
                JointAngleLimits2D legULLimits = legULJoint.limits;
                JointAngleLimits2D legLLLimits = legLLJoint.limits;

                headLimits.min = -15f;
                headLimits.max = 15f;
                torsoLimits.min = -20;
                torsoLimits.max = 20;
                legURLimits.min = -40;
                legURLimits.max = 40;
                legLRLimits.min = -20;
                legLRLimits.max = 20;
                legULLimits.min = -40;
                legULLimits.max = 40;
                legLLLimits.min = -20;
                legLLLimits.max = 20;

                headJoint.limits = headLimits;
                torsoJoint.limits = torsoLimits;
                legURJoint.limits = legURLimits;
                legLRJoint.limits = legLRLimits;
                legULJoint.limits = legULLimits;
                legLLJoint.limits = legLLLimits;

                stickman.layer = LayerMask.NameToLayer("Player");

                foreach(Transform child in stickman.GetComponentsInChildren<Transform>())
                {
                    child.gameObject.layer = LayerMask.NameToLayer("Player");
                }

                stickman.AddComponent<Balance>();
                stickman.AddComponent<PlayerMovement>();
                stickman.AddComponent<Arms>();
                handRight.AddComponent<Hands>();
                handLeft.AddComponent<Hands>();

                GameObject.Find("Main Camera").GetComponent<CameraControl>().player = chest;
            }
        }

        private Sprite Circle(int radius)
        {
            Texture2D tex = new Texture2D(radius * 2, radius * 2, TextureFormat.ARGB32, false);

            for (int y = 0; y < tex.height; y++)
            {
                for (int x = 0; x < tex.width; x++)
                {
                    float distanceFromCenter = Vector2.Distance(new Vector2(x, y), new Vector2(tex.width / 2, tex.height / 2));
                    if (distanceFromCenter <= radius)
                    {
                        tex.SetPixel(x, y, Color.white);
                    }
                    else
                    {
                        tex.SetPixel(x, y, Color.clear);
                    }
                }
            }

            tex.Apply();

            return Sprite.Create(tex, new Rect(0, 0, radius * 2, radius * 2), new Vector2(0.5f, 0.5f));
        }

        private Sprite Box(int width, int height)
        {
            Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false);

            for(int y = 0; y < tex.height; y++)
            {
                for(int x = 0; x < tex.width; x++)
                {
                    tex.SetPixel(x, y, Color.white);
                }
            }

            tex.Apply();

            return Sprite.Create(tex, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
        }
    }
}
