using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MooveMeh : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Jump = "Jump";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform cameraTransform; // Камера персонажа
    [SerializeField] private float cameraSensitivity = 2f;
    [SerializeField] private float minCameraAngle = -45f;
    [SerializeField] private float maxCameraAngle = 45f;

    private Animator _animator;
    private Rigidbody m_rb;
    private float _currentrotationY;
    private float _horizontal;
    private float _vertical;
    private Vector3 _direction;
    private bool IsGround;
    private float _cameraRotationX;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsGround", IsGround);
        IsGround = true;
    }

    private void FixedUpdate()
    {
        _horizontal = Input.GetAxis(Horizontal);
        _vertical = Input.GetAxis(Vertical);

        RotateCamera();
        moovePlayer();
        GetAnim();
        GetJump();
        AttakPos();
    }

    public void GetJump()
    {
        if (Input.GetButton(Jump) && IsGround)
        {
            _animator.SetTrigger(Jump);
            m_rb.AddForce(Vector3.up * _jumpForse, ForceMode.Impulse);
            IsGround = false;
        }
    }

    private void moovePlayer()
    {
        _currentrotationY += _horizontal * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, _currentrotationY, 0);

        _direction = transform.forward * _vertical * _speed;
        _direction.y = m_rb.velocity.y;
        m_rb.velocity = _direction;
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity;

        _currentrotationY += mouseX;
        _cameraRotationX -= mouseY;

        _cameraRotationX = Mathf.Clamp(_cameraRotationX, minCameraAngle, maxCameraAngle);

        // Вращение персонажа в горизонтальной плоскости
        transform.rotation = Quaternion.Euler(0, _currentrotationY, 0);

        // Вращение камеры вверх/вниз
        cameraTransform.localRotation = Quaternion.Euler(_cameraRotationX, 0, 0);
    }

    private void GetAnim()
    {
        _animator.SetFloat("Speed", Mathf.Abs(_vertical));
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGround = true;
    }

    private void AttakPos()
    {
        if (Input.GetButton("Fire1"))
        {
            _animator.SetBool("Attack", true);
        }
        else
        {
            _animator.SetBool("Attack", false);
        }
    }

    public void Dead()
    {
        _animator.SetTrigger("Dead");
    }
}