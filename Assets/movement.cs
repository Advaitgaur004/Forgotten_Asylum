using UnityEngine;
using UnityEngine.XR.Management;

public class movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float backwardDistance = 1f;
    private bool isJumping = false;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }
}
