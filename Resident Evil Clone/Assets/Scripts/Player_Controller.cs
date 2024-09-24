using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UI = UnityEngine.UIElements;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float mouseSensity = 60f;
    [SerializeField] float verticalLookLimit;
    [SerializeField] Transform FpsCamera;
    [SerializeField] private Transform firePoint;

    private bool isGrounded = true;
    private float xRotation;
    private Rigidbody rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        Move();
        LookAround();
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot();
        }
    }
    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);

        FpsCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    private void Move()
    {
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");

        Vector3 move = transform.right * movex + transform.forward * movez;
        move.Normalize();
        Vector3 moveVelocity = move * moveSpeed;

        moveVelocity.y = rb.velocity.y;

        rb.velocity = moveVelocity;
    }
    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    //private void Shoot()
    //{
    //   RaycastHit hit;
    //   if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 100))
    //    {
    //       Debug.DrawRay(firePoint.position, firePoint.forward * hit.distance, Color.red, 2f);
    //        if (hit.transform.CompareTag("Zombie"))
    //        {
    //          hit.transform.GetComponent<Zombie>().TakeDamage(1);
    //}
    //    }
    //}
}
