using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotationSpeedMult;

    private Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool mouse2 = Input.GetKey(KeyCode.Mouse2);
        
        if ( mouse2 )
        {
            // Rotate();
        }

        // Rotate ();
    }

    private void Rotate ()
    {
        turn.x += Input.GetAxis ( "Mouse X" );
        turn.y += Input.GetAxis ( "Mouse Y" );

        transform.localRotation = Quaternion.Euler ( -turn.y * rotationSpeedMult, turn.x * rotationSpeedMult, 0 );
    }
}
