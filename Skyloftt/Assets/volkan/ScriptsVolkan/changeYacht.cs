using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeYacht : MonoBehaviour
{
    public GameObject character;
    public GameObject yacht;
    public GameObject tPose;
    public GameObject mainCam;
    public GameObject secondCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("girdin");
           // yacht.transform.parent = character.transform;
           // character.transform.localPosition = new Vector3(0, 0, 0);
            character.transform.localRotation = Quaternion.identity;
            character.SetActive(false);

            yacht.transform.position = character.transform.position;
            yacht.GetComponentInParent<botTest>().ActivateBoat();
            mainCam.SetActive(false);
            secondCam.SetActive(true);

        }
    }
}
