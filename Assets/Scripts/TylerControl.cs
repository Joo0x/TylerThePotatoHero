using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TylerControl : MonoBehaviour
{
    #region Vars
    private Vector3 MoveInputs;
    private Vector3 LookInputs;
    private Rigidbody _rigidbody;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 3f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private bool InvertedMouseY = true;
    [SerializeField] private float health = 10;
    #endregion

    public static event Action JumpHappend;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //Check Ground
        isGrounded = Physics.Linecast(transform.position, groundCheck.position, groundLayer);
        Debug.DrawLine(transform.position,groundCheck.position,Color.red);
        //Move
        _rigidbody.AddRelativeForce(MoveInputs , ForceMode.Force);
        //Fall Speed increase
        if(!isGrounded)
            _rigidbody.AddForce(Physics.gravity * 1.5f, ForceMode.Acceleration);
    }

    private void LateUpdate()
    {
        //Rotate
        _rigidbody.rotation = Quaternion.Euler(0f,_rigidbody.rotation.eulerAngles.y +(LookInputs.x * rotateSpeed),0f);
    }

    void OnMove(InputValue input)
    {
        Debug.Log("Tyler Body Force ");
        MoveInputs = new Vector3(input.Get<Vector2>().x * moveSpeed * _rigidbody.mass , 0f,input.Get<Vector2>().y * moveSpeed * _rigidbody.mass);
    }
    
    void OnJump(InputValue input)
    {
        if (!isGrounded) return;
        Debug.Log("Tyler Jump Strike");
        JumpHappend ?.Invoke();
        _rigidbody.AddForce(Vector3.up * jumpHeight * _rigidbody.mass, ForceMode.Impulse);
        
    }

    void OnLook(InputValue input)
    {
        LookInputs = new Vector3(input.Get<Vector2>().x , input.Get<Vector2>().y,0f);
        Vector3 previousLook = LookInputs;
        LookInputs = new Vector3(input.Get<Vector2>().x, (InvertedMouseY ? -input.Get<Vector2>().y : input.Get<Vector2>().y), 0f);
    }

    public void damage(float dmg)
    {
        health -= dmg;
    }

    public float tylerHP()
    {
        return health;
    }
}
