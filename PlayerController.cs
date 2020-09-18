using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public ParticleSystem jumpPS;
    public ParticleSystem deathPS;
    public int color = 100;
    public Text ColorUI;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float forceJump = 3f;
    [SerializeField] private int countExtraJump = 1;
    [SerializeField] private float checkRadius = 0.3f;
    [SerializeField] private float moveInput;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    public Rigidbody2D rigidbody;
    public bool facingRight = true;
    private bool isGrounded;
    private int extraJumps;

    private void Start()
    {
        extraJumps = countExtraJump;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        IsGrounded();
        ColorUI.text = color.ToString();


    }
    private void FixedUpdate()
    {
        Die();
        Jump();
    }
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void IsGrounded()
    {
        
        if (isGrounded == true)
        {
            extraJumps = countExtraJump;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
        {

            TakeDMG(10);
            CreateDust();
            rigidbody.velocity = Vector2.up * forceJump;
            extraJumps--;

        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded == true)
        {
            rigidbody.velocity = Vector2.up * forceJump;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, -180f, 0f);
    }
    public void TakeDMG(int dmg)
    {
        if (color < 0)
        {
            color = 0;
        }
        color -=  dmg;
    }
    void CreateDust()
    {
        jumpPS.Play();
    }
    public void Die()
    {
        if(color == 0)
        {
            Destroy(gameObject);
            CreateDeath();
        }
    }
    public void CreateDeath()
    {
        ParticleSystem dps = Instantiate(deathPS);
        dps.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

   

}