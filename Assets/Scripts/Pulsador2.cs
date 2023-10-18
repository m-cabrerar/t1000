using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pulsador2 : MonoBehaviour
{
    public MovimientoPortalPulsadores controlMov;
    public float distAMoverY = 0.1f;
    private void OnTriggerStay(Collider other)
    {
        Vector3 posicionActual = transform.position;
        posicionActual.y = 0.15f;
        transform.position = posicionActual;
        controlMov.setPulsador2(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        Vector3 posicionActual = transform.position;
        posicionActual.y = 0.25f;
        transform.position = posicionActual;
        controlMov.setPulsador2(false);
    }
}
