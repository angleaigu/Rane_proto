using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class player_moveset : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float Movementspeed;
    [SerializeField] private float Jumpheight;

    [Header("GroundCheck")]
    [SerializeField] Transform Ground_Check_Position;
    [SerializeField] float Ground_Check_Radius;
    [SerializeField] LayerMask Ground_Check_Layer;

    private Player_manager _player_manager;
    private InputAction _Move, _Jump;
    private Vector2 Input_Direction;

    private bool _IsGrounded;


    //[SerializeField] int CoinNumber =0;


    void Awake()
    {
        _player_manager = new Player_manager();
        _Move = _player_manager.Player.Move;
        _Jump = _player_manager.Player.Jump;

    }

    private void OnEnable()
    {

        _rigidbody2D = this.GetComponent<Rigidbody2D>();

        _Move.Enable();
        _Jump.Enable();

        _Jump.performed += On_Jump;
        _Jump.canceled += Cancel_Jump;
        _Move.performed += On_Move;

        Ground_Check_Position = transform.Find("Overlap_Jump").GetComponent<Transform>();

    }

   

    private void OnDisable()
    {

        _Move.Disable();
        _Jump.Disable();

        _Jump.performed -= On_Jump;
        _Move.performed -= On_Move;


    }

    private void FixedUpdate()
    {

        Movement_Update();
        Ground_detection();


    }

    private void OnDrawGizmos()
    {
        

        if (_IsGrounded) {

            Gizmos.color = Color.green;

        } else {

            Gizmos.color = Color.red;

        }



        Gizmos.DrawWireSphere(Ground_Check_Position.position, Ground_Check_Radius);
    }

    private void Movement_Update()
    {

        Input_Direction = _Move.ReadValue<Vector2>();
        Vector2 Player_Velocity = _rigidbody2D.velocity;
        Player_Velocity.x = ((Movementspeed * Time.deltaTime) * Input_Direction.x);
        _rigidbody2D.velocity = Player_Velocity;

    }

    private void On_Move(InputAction.CallbackContext context)
    {
        Debug.Log("ça marche <3");
    }

    private void On_Jump(InputAction.CallbackContext context)
    {
        Debug.Log("il saute :)");

        if (_IsGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, (Jumpheight * Time.deltaTime));
        } 
            
    }

    private void Cancel_Jump(InputAction.CallbackContext context)
    {
        if (_rigidbody2D.velocity.y > 0.01)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, (_rigidbody2D.velocity.y*0.5f));
        }
    }

    private void Ground_detection()
    {
        Collider2D[] Ground_detection = Physics2D.OverlapCircleAll(Ground_Check_Position.position, Ground_Check_Radius, Ground_Check_Layer);

        _IsGrounded = false;
        
        foreach (var Object in Ground_detection) { 
        
            Debug.Log( Object.name);    

            if ( Object.tag == "Ground_World")
            {
                _IsGrounded = true;
            }

        }



    }

 


}
