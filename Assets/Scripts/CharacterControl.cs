using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float moveSpeed = 5f;
    private Vector2 direction, postureDirection;
    
    //reference to input actions
    public CharacterAction characterAction;

    GameObject bag;

    private void Awake() {
        characterAction = new CharacterAction();
    }

    private void OnEnable() {
        characterAction.Enable();
        characterAction.OnGround.Move.performed += OnMovePerformed;
        characterAction.OnGround.Move.canceled += OnMoveCanceled;
        characterAction.OnGround.UseTools.performed += OnUseTool;
    }

    private void OnDisable() {
        characterAction.Disable();
        characterAction.OnGround.Move.performed -= OnMovePerformed;
        characterAction.OnGround.Move.canceled -= OnMoveCanceled;
        characterAction.OnGround.UseTools.performed -= OnUseTool;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        bag = GameObject.FindWithTag("Bag");
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = direction * moveSpeed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        animator.SetBool("IsMoving", true);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        postureDirection = direction;
        direction = Vector2.zero;
        animator.SetBool("IsMoving", false);
        animator.SetFloat("PostureHorizontal", postureDirection.x);
        animator.SetFloat("PostureVertical", postureDirection.y);
    }

    private void OnUseTool(InputAction.CallbackContext context)
    {
        Debug.Log("Use Tool by F or click: "+context.ReadValueAsButton());
    }

    public void OnUseTool(int keyid)
    {
        Debug.Log("Use Tool by keyboard number: "+keyid);
    }

}