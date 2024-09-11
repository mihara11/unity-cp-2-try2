using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementspeed;
    [SerializeField] private float jumpforce;
    [SerializeField] private LayerMask GroundLayerMask;
    [Space]
    

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        


    }

    private void Move(float movementspeed)
    {
        rb.AddForce(new Vector2(movementspeed, 0 )); 
    }
    private void Jump() =>

        rb.AddForce(new Vector2(0, jumpforce),
            ForceMode2D.Impulse);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMaskUtil.LayerMaskContainsLayer(GroundLayerMask,
            collision.gameObject.layer))
        {
            Debug.Log("isGrounded");
        }
    }



}
