using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Karakterin hareket hızı
    public float moveSpeed = 10f;
    private Rigidbody rb;
    
    // Bu karakterin şu an kontrol edilip edilmediğini tutar
    public bool isControlled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Sadece bu karakter kontrol ediliyorsa hareket et
        if (isControlled)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
            rb.AddForce(movement * moveSpeed);

            if (rb.linearVelocity.magnitude > moveSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * moveSpeed;
            }
        }
        else
        {
            // Kontrol edilmiyorsa hareketini sıfırla
            rb.linearVelocity = Vector3.zero;
        }
    }
}