using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour 
{

    public float movementSpeed = 10.0f;
    public float mouseSensitivity = 5.0f;
    public float upDownRange = 60.0f;
    public float jumpSpeed = 5.0f;

    private float horizontalRotation = 0;
    private float verticalRotation = 0;
    private float verticalVelocity = 0;

    CharacterController characterController;
    
    void Start () 
    {
//        Screen.lockCursor = true;
        characterController = GetComponent<CharacterController>();
        
	}       
	
    
	void Update () 
    {   
        
        //Rotation
        horizontalRotation = Input.GetAxis( "Mouse X" ) * mouseSensitivity;
        transform.Rotate( 0, horizontalRotation, 0 );

        verticalRotation -= Input.GetAxis( "Mouse Y" ) * mouseSensitivity;
        verticalRotation = Mathf.Clamp( verticalRotation, -upDownRange, upDownRange );
        Camera.main.transform.localRotation = Quaternion.Euler( verticalRotation, 0, 0 );

        

        //Movement
        float forwardSpeed = Input.GetAxis( "Vertical" ) * movementSpeed;
        float sideSpeed = Input.GetAxis( "Horizontal" ) * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if( characterController.isGrounded && Input.GetButton( "Jump" ) )
        {
            verticalVelocity = jumpSpeed;

        }


        Vector3 speed = new Vector3( sideSpeed, verticalVelocity, forwardSpeed );
        speed = transform.rotation * speed;
        characterController.Move( speed * Time.deltaTime );

       
	}
}
