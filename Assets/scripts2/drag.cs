using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    public drop currentDropSlot;
    public Transform  offset;
    public void onDrop()
    {
        if (currentDropSlot != null)
        {
            turnoffGravity();
            Vector3 globalOffset = Vector3.zero;
            if (offset != null)
            {
                globalOffset = (transform.position - offset.position);
            }
            transform.position = currentDropSlot.transform.position + globalOffset;
            transform.rotation = currentDropSlot.transform.rotation; 
            currentDropSlot.gameObject.SetActive(false);
        }
    }
    public void turnoffGravity()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void turnonGravity()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
    }

}

