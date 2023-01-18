using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public VariableJoystick joystick;
    public Animator animCtrl;

    public float Speed = 5f;
    public float RotationSpeed = 10f;

    NavMeshAgent _agent;

    public float AnimationSpeed;
    public Vector3 movementCache = Vector3.zero;
    //void FixedUpdate()
    //{

    //    if (joystick == null)
    //        return;

    //    if (animCtrl == null)
    //        return;

    //    Vector2 direction = joystick.Direction;

    //    Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

    //    movementVector = movementVector * Time.deltaTime * Speed;

    //    transform.position += movementVector;
    //    //movementCache += movementVector;

    //    if (movementVector.magnitude != 0)
    //    {
    //        //transform.forward = movementVector;
    //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * RotationSpeed);
    //    }

    //    //bool isWalking = direction != Vector2.zero;
    //    bool isWalking = direction.magnitude > 0;

    //    animCtrl.SetBool("IsWalking", isWalking);

    //    animCtrl.SetFloat("SpeedValue", direction.magnitude);
    //}
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {

        //if (joystick == null)
        //    return;

        //if (animCtrl == null)
        //    return;

        //Vector2 direction = joystick.Direction;

        //Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

        //movementVector = movementVector * Time.deltaTime * Speed;

        //transform.position += movementVector;
        ////movementCache += movementVector;

        //if (movementVector.magnitude != 0)
        //{
        //    //transform.forward = movementVector;
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * RotationSpeed);
        //}

        ////bool isWalking = direction != Vector2.zero;
        //bool isWalking = direction.magnitude > 0;

        //animCtrl.SetBool("IsWalking", isWalking);

        //animCtrl.SetFloat("SpeedValue", direction.magnitude);

        //
        if (!joystick) return;

        Vector3 move = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        move *= Time.deltaTime * Speed;
        _agent.Move(move);
        _agent.SetDestination(transform.position + move);
        if (move == Vector3.zero)
        {

            animCtrl.SetBool("IsWalking", false);

            Debug.Log("as");
        }
        else
        {
            Debug.Log("skjd");
            animCtrl.SetBool("IsWalking", true);
            animCtrl.SetFloat("SpeedValue", _agent.velocity.magnitude * AnimationSpeed * Time.deltaTime);
            Vector3 lookDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 30 * Time.deltaTime);
        }
    }



    //private void FixedUpdate()
    //{
    //    if (movementCache != Vector3.zero)
    //    {
    //        transform.position += movementCache;
    //        movementCache = Vector3.zero;
    //    }

    //}

}
