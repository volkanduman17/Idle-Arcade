using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMovement : MonoBehaviour
{
    public VariableJoystick joystick;    
    public float Speed = 5f;
    public float RotationSpeed = 10f;
    
    void Update()
    {
        if (joystick == null)
            return;

        Vector2 direction = joystick.Direction;

        Vector3 movementVector = new Vector3(direction.x, direction.y, Time.deltaTime * 2f);

        movementVector = movementVector * Time.deltaTime * Speed;

        transform.position += movementVector;
        //movementCache += movementVector;

        if (movementVector.magnitude != 0)
        {
            //transform.forward = movementVector;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * RotationSpeed);
           // transform.Rotate(Vector3.up, -joystick.Horizontal * Time.deltaTime * RotationSpeed);
        }

       
    }
    
}
