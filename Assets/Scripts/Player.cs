using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] LayerMask torchTriggerLayer;
    Vector2 movement;
    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D playerCollider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        movement = new Vector2(x, y);

       animator.SetFloat("moveX", movement.x);
       animator.SetFloat("moveY", movement.y);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((torchTriggerLayer.value & (1 << collision.transform.gameObject.layer)) > 0)
        {
            collision.GetComponent<FlameTrigger>().ActivateFlame();
        }
    }
}
