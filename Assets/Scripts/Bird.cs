    using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle") ||
            other.collider.transform.root.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
            //Debug.Log("GAME OVER");
        }
    }
    public void EnablePhysics()
    {
        rb.simulated = true;
    }
    void Update()
    {
        if (GameManager.Instance.currentState == GameManager.GameState.Playing)
        {
             if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                rb.linearVelocity = Vector2.up * jumpForce;
            }
        }
       
    }
}
