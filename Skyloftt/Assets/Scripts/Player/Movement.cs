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
   
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {

        if (!joystick) return;

        Vector3 move = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        move *= Time.deltaTime * Speed;
        _agent.Move(move);
        _agent.SetDestination(transform.position + move);
        if (move == Vector3.zero)
        {
            animCtrl.SetBool("IsWalking", false);
        }
        else
        {
            animCtrl.SetBool("IsWalking", true);
            animCtrl.SetFloat("SpeedValue", _agent.velocity.magnitude * AnimationSpeed * Time.deltaTime);
            Vector3 lookDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 30 * Time.deltaTime);
        }
    }

}
