using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class palanca : MonoBehaviour
{
    void Update()
    {
        this.GetComponent<Renderer>().material.color = new Color(this.GetComponent<LinearDrive>().linearMapping.value, 0, 0);
    }
}

