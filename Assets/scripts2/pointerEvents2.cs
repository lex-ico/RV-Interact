using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;
using Valve.VR.InteractionSystem;
/// <summary>
/// Motores Multiplataforma II
///  Este fichero se tiene que copiar dentro de Assets, en la carpeta que se haya destinado a los scripts
///  Sirve para que el puntero l�ser pueda hacer click sobre la UI
///  Tambi�n hace que el l�ser aparezca oculto y que se muestre al pulsar un bot�n
///  Tambi�n hace que un objeto panel pueda mostrase/ocultarse al mostrar el puntero
///  Se asigna a la mano sobre la que va a salir el puntero l�ser, por ejemplo en la mano derecha, Player/SteamVRObjects/RightHand
///  En el editor hay que asignar la variable p�blica activaLaser a la acci�n del mando que sirva para activar/desactivar el puntero, por ejemplo, actions/default/in/GrabGrip
/// </summary>
public class pointerEvents2 : MonoBehaviour
{
    public SteamVR_Action_Boolean activaLaser;
    public GameObject panel;
    public SteamVR_Action_Boolean pulsaR2;
    private GameObject other;
    private bool bDragging;
    private drag dragObj;
    private float distRay;



    void Awake()
    {
        this.GetComponent<SteamVR_LaserPointer>().PointerClick += PointerClick;
        this.GetComponent<SteamVR_LaserPointer>().PointerIn += PointerInside;
        this.GetComponent<SteamVR_LaserPointer>().PointerOut += PointerOutside;
        this.GetComponent<SteamVR_LaserPointer>().enabled = false;
        if (panel != null)
        {
            panel.SetActive(false);
        }
        
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        UIElement uie = e.target.GetComponent<UIElement>();
        if (uie != null)
        {
            uie.onHandClick.Invoke(this.GetComponent<Hand>());
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        InteractableHoverEvents ihe = e.target.GetComponent<InteractableHoverEvents>();
        if (ihe != null)
        {
            ihe.onHandHoverBegin.Invoke();
        }
        other = e.target.gameObject;
    }
    public void PointerOutside(object sender, PointerEventArgs e)
    {
        InteractableHoverEvents ihe = e.target.GetComponent<InteractableHoverEvents>();
        if (ihe != null)
        {
            ihe.onHandHoverEnd.Invoke();
        }
        other = null;
    }

    private void Update()
    {
        if (activaLaser[this.GetComponent<Hand>().handType].stateDown)
        {
            this.GetComponent<SteamVR_LaserPointer>().enabled = !this.GetComponent<SteamVR_LaserPointer>().enabled;
            GameObject go = this.GetComponent<SteamVR_LaserPointer>().holder;
            if (go != null)
            {
                go.SetActive(this.GetComponent<SteamVR_LaserPointer>().enabled);
            }
            if (panel != null)
            {
                panel.SetActive(!panel.activeSelf);
            }
        

        }
        if (pulsaR2[this.GetComponent<Hand>().handType].stateDown)
        {
            if (other != null)
            {
                dragObj = other.GetComponent<drag>();
                if (dragObj != null)
                {
                    bDragging = true;
                    distRay = Vector3.Distance(transform.position, other.transform.position);
                    dragObj.turnoffGravity();
                }
            }
        }
        if (pulsaR2[this.GetComponent<Hand>().handType].stateUp)
        {
            bDragging = false;
            if (dragObj != null)
            {
                dragObj.turnonGravity();
                dragObj.onDrop();
            }
        }
        if (bDragging)
        {
            if (dragObj != null)
            {
                dragObj.transform.position = transform.position + transform.forward * distRay;
            }
        }

    }

}
