using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePlane : MonoBehaviour
{
    public GameObject character;
    public GameObject aircraft;
    public GameObject propeller;
    public bool rotatepp=false;

    public GameObject airplaneCanvas;

    private void Start()
    {
        aircraft.GetComponent<planeMovement>().enabled=false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Player")
        {
            character.transform.parent = aircraft.transform;
            character.transform.localPosition = new Vector3(0, 0, 0);
            character.transform.localRotation = Quaternion.identity;
            character.SetActive(false);
            aircraft.GetComponent<planeMovement>().enabled = true;
            rotatepp = true;
        }

        if (other.transform.tag == "pist")
        {
            character.transform.parent = (null);
            character.transform.localRotation = Quaternion.identity;
            character.transform.localPosition = new Vector3(274,0,210);
           // character.transform.localPosition = propeller.transform.position;

            character.SetActive(true);
            aircraft.GetComponent<planeMovement>().enabled = false;
            rotatepp = false;
            airplaneCanvas.SetActive(false);
        }

    }




    private void Update()
    {
        propellerRotate();
    }

    public void propellerRotate()
    {
        if (rotatepp==true)
        {
            propeller.transform.Rotate(Vector3.forward, Time.deltaTime * 1000);
        }
    }
}
