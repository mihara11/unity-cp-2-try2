using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementspeed;
    [SerializeField] private float jumpforce;
    [Space]
    [SerializeField] private LayerMask GroundLayerMask;
    [Space]
    [SerializeField] private Color accentColor;
    [SerializeField] private Color defaultColor;

    

    private Rigidbody2D rb;
    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();

        //if (TryGetComponent<Rigidbody2D>(out var rb))
        {
            //this.rb = rb;
        }
 
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            Move(horizontalInput * movementspeed);

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        


    }

    private void Move(float movementspeed)
    {
        rb.AddForce(new Vector2(movementspeed, 0 )); 
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
    }

       

    private void OnCollisionEnter2D(Collision2D collision)
    {
       SetGrounded(collision, true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       SetGrounded(collision, false);
    }

    private void SetGrounded(Collision2D collision, bool isGrounded)
    {
        if (LayerMaskUtil.LayerMaskContainsLayer(GroundLayerMask,
            collision.gameObject.layer))
        {
            this.isGrounded = isGrounded;
            ColorTile(collision.gameObject.GetComponent<SpriteRenderer>());
        }
    }

    private void ColorTile(SpriteRenderer spriteRenderer)
    {
        if(spriteRenderer.color == defaultColor)
        {
            spriteRenderer.color = accentColor;
        }
        else
        {
            spriteRenderer.color = defaultColor;
        }

        //spriteRenderer.color = spriteRenderer.color == defaultcolor ?? accentColor : defaultColor;
    }


}
