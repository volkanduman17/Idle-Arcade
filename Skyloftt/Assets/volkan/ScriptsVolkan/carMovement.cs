using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    
    public GameObject acilacakCar;
    public GameObject character;

    //public float carSpeed = 40f;

    public bool isDriving = false;
    public bool carptiMi = false;
    


    private void Start()
    {
        isDriving = false;
        StartCoroutine(bekleme());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="garageCar")
        {
            if (isDriving==false)
            {
                carptiMi = true;
                acilacakCar.SetActive(true);
                character.SetActive(false);
                gameObject.GetComponent<Movement>().Speed = 40f;
                gameObject.GetComponent<Stash>().maxCollectableCount = 10;
                StartCoroutine(bekleme());

            }

            if (isDriving==true)
            {   
                acilacakCar.SetActive(false);
                character.SetActive(true);
                gameObject.GetComponent<Stash>().maxCollectableCount = 5;

                gameObject.GetComponent<Movement>().Speed = 35f;
                isDriving = false;
                

            }
        }
    }

    IEnumerator bekleme()
    {
        if (carptiMi==true)
        {
            yield return new WaitForSeconds(1);
            isDriving = true;
            


        }

    }
}
