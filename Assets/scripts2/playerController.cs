using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class playerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 entrada;
    public float speed = 1.0f;

    void Update()
    {
        Vector3 direction = this.GetComponent<Player>().hmdTransform.TransformDirection(new Vector3(entrada.axis.x, 0, entrada.axis.y));
        transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
    }
}
