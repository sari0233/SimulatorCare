using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public int rayLength = 10;
    public float delay = 0.1f;
    bool aboutToTeleport = false;
    Vector3 teleportPos = new Vector3();

    public Material tMat;

    public GameObject pointer;
    public GameObject player;

    private void Update()
    {
        RaycastHit hit;

        // Check for input from either the left or right primary trigger button
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch) || OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength * 10))
            {
                if (hit.collider.gameObject.tag == "Island")
                {
                    aboutToTeleport = true;
                    teleportPos = hit.point;

                    GameObject myLine = new GameObject();
                    myLine.transform.position = transform.position;

                    pointer.transform.position = hit.point;
                }
                else
                {
                    aboutToTeleport = false;
                    Vector3 v1 = transform.position;
                    v1 = transform.TransformPoint(Vector3.forward * rayLength);

                    GameObject myLine = new GameObject();
                    myLine.transform.position = transform.position;
                    myLine.AddComponent<LineRenderer>();

                    LineRenderer lr = myLine.GetComponent<LineRenderer>();

                    lr.startColor = new Color(0.2f, 0, 1);
                    lr.endColor = Color.red;
                    lr.startWidth = 0.01f;
                    lr.endWidth = 0.01f;
                    lr.SetPosition(0, transform.position);
                    lr.SetPosition(1, v1);
                    GameObject.Destroy(myLine, delay);
                }
            }
        }

        // Check for input release from either the left or right primary trigger button
        if ((OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch) || OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch)) && aboutToTeleport)
        {
            aboutToTeleport = false;
            player.transform.position = teleportPos;
        }
    }
}
