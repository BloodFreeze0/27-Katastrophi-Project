using UnityEngine;

public class SpriteTiedToPhysics : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(rb.position.x, rb.position.y, transform.position.z);
    }
}
