using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YachtMovement : MonoBehaviour
{
    public VariableJoystick joystick;
    //public Animator animCtrl;

    public float Speed = 5f;
    public float RotationSpeed = 10f;

    public bool isActive = false;

    //public float AnimationSpeed;
    public Vector3 movementCache = Vector3.zero;
    public void ActivateBoat()
    {
        isActive = true;
    }
    void FixedUpdate()
    {

        if (joystick == null || !isActive)
            return;


        Vector2 direction = joystick.Direction;

        Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

        movementVector = movementVector * Time.deltaTime * Speed;

        transform.position += movementVector;
        //movementCache += movementVector;

        if (movementVector.magnitude != 0)
        {
            //transform.forward = movementVector;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * RotationSpeed);
        }

        //bool isWalking = direction != Vector2.zero;
       // bool isWalking = direction.magnitude > 0;

        //animCtrl.SetBool("IsWalking", isWalking);

        //animCtrl.SetFloat("SpeedValue", direction.magnitude);
    }
}
