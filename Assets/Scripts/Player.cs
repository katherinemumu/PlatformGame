using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    [SerializeField] private Transform groundCheckTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal") * 2;
        rigidBodyComponent.velocity = new Vector3(Input.GetAxis("Horizontal") * 2, rigidBodyComponent.velocity.y, 0);
    }

    // FixedUpdate is called once every physics update
    private void FixedUpdate() {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1) {
            return;
        }

        if(jumpKeyWasPressed) {
            rigidBodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        rigidBodyComponent.velocity = new Vector3(Input.GetAxis("Horizontal") * 2, rigidBodyComponent.velocity.y, 0);
    }
}