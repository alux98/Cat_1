using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject cameraRotator;

    [Header ( "Physical Parameters" )]
    [SerializeField] private float movementSpeed;

    [Header ( "Camera Parameters" )]
    [SerializeField] private float cameraRotationSpeed;
    [SerializeField] private float zoomStrength;
    [Range( 0.0f, 1.0f )]
    [SerializeField] private float zoomYZRatio;

    private Vector2 turn;
    private bool takeActions = false;

    void Update()
    {
        bool isCatMoves = Input.GetKey(KeyCode.W);

        if ( Input.GetKeyDown ( KeyCode.Escape ) )
        {
            takeActions = !takeActions;
        }

        if ( takeActions )
        {
            RotateCamera ();
            ZoomCamera ();
            Run ( isCatMoves );
        }
    }

    private void Run (bool run)
    {
        AnimateRun ( run );

        if ( run )
        {
            MoveForward ();
            Rotate ();
        }
    }

    private void MoveForward ()
    {
        transform.position = transform.position + transform.forward * movementSpeed * Time.deltaTime;
    }

    private void AnimateRun ( bool run )
    {

        if ( run )
        {
            animator.SetBool ( "Run", true );
        }
        else
        {
            animator.SetBool ( "Run", false );
        }
    }

    private void Rotate ()
    {
        transform.rotation = Quaternion.Euler ( 0, cameraRotator.transform.rotation.eulerAngles.y, 0 );
    }

    // --------------
    // Camera Methods
    // --------------

    private void RotateCamera ()
    {
        turn.x += Input.GetAxis ( "Mouse X" );
        turn.y += Input.GetAxis ( "Mouse Y" );

        cameraRotator.transform.rotation = Quaternion.Euler ( -turn.y * cameraRotationSpeed, turn.x * cameraRotationSpeed, 0 );
    }

    private void ZoomCamera ()
    {
        if ( Input.GetAxisRaw("Mouse ScrollWheel") > 0 )
        {
            Camera.main.transform.Translate ( 0, - zoomStrength * zoomYZRatio, zoomStrength );
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 )
        {
            Camera.main.transform.Translate ( 0, zoomStrength * zoomYZRatio, - zoomStrength );
        }
    }
}
