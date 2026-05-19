using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movespeed = 1f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private MovementControl playerControls;
    private Animator myAnimator;
    private SpriteRenderer sprite;
    private void Awake()
    {
        playerControls = new MovementControl();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    void Start()
    {

    }

    void Update()
    {
        PlayerInput();
        PlayerFacingDirection();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        Debug.Log(movement.x);
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (movespeed * Time.fixedDeltaTime));
    }
   private void PlayerFacingDirection()
   {
      Vector3 mousePos = Input.mousePosition;
      Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

      if(mousePos.x < playerScreenPoint.x)
      {
        sprite.flipX = true;
      }
      else
      {
        sprite.flipX = false;
      }
   }
}
