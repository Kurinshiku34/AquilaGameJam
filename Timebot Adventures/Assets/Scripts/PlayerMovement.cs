using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _playerSpeed = 1f;
    public float jumpSpeed = 5f;
    bool isGrounded;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(x * _playerSpeed, _rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            _rb.velocity += Vector3.up * jumpSpeed;
        }
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            _rb.velocity += Vector3.up * jumpSpeed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }                
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.R))
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
        }        
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}