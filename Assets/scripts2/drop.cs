using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public Material highMat;
    private Material ownMat;

    void Start()
    {
        ownMat = this.GetComponent<Renderer>().material;
    }
    private void OnTriggerEnter(Collider other)
    {
        drag dragObj = other.GetComponent<drag>();
        if (dragObj != null)
        {
            this.GetComponent<Renderer>().material = highMat;
            dragObj.currentDropSlot = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        drag dragObj = other.GetComponent<drag>();
        if (dragObj != null)
        {
            this.GetComponent<Renderer>().material = ownMat;
            dragObj.currentDropSlot = null;
        }
    }
}
