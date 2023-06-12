using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using DG.Tweening;
using UnityEngine.AI;

public class PlayerMovement : MonoSingleton<PlayerMovement>
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    private Rigidbody rb;
    private Collider col;

    private bool move = false;
    private NavMeshAgent navMeshAgent;

    private PlayerAnimator animator;
    private bool gameStart = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        animator = GetComponentInChildren<PlayerAnimator>();
    }
    public void Update()
    {
        if (!gameStart)
            return;
        JoystickMovement();
    }
    public void JoystickMovement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        if (horizontal != 0 || vertical != 0)
            animator.SetRunAnim();
        else if (horizontal == 0 && vertical == 0)
            animator.SetIdleAnim();

        Vector3 addedPos = Helper.Help(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        transform.position += addedPos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        if (direction == Vector3.zero)
            return;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }
    public void StartHandlePlayer()
    {
        LeanTouch.OnFingerDown += HandlePlayer;
    }
    public void StartGame()
    {
        StartHandlePlayer();
        gameStart = true;
    }
    public void StopHandlePlayer()
    {
        LeanTouch.OnFingerDown -= HandlePlayer;
    }
    private void HandlePlayer(LeanFinger obj)
    {
        joystick.gameObject.SetActive(true);
        joystick.test = true;
    }
}
