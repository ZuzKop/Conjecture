using UnityEngine;
using System.Collections;

public class FPSCamera : MonoBehaviour
{
    public float Xsensitivity;
    private float rotationX = 0f;

    private float velocidade = 80f;

    public AudioSource movementSound;
    private bool mouseMovement;
    private bool keyboardMovement;
    private float turn;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        turn = 0f;
    }

    void FixedUpdate()
    {
        
        Debug.Log(HasMouseMoved() || keyboardMovement);
        if ((HasMouseMoved() || keyboardMovement) && (rotationX != 95 && rotationX != -95))
        {

            if (turn < 0.43f)
                turn += 0.15f;
            else turn = 0.43f;

        }
        else
        {

            if (turn > 0)
                turn -= 0.1f;
            else turn = 0;

        }

        movementSound.volume = 1f * turn;
        
    }

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * Xsensitivity;
        //Debug.Log(Input.GetAxis("Mouse X"));

        keyboardMovement = false;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rotationX += velocidade * Time.deltaTime;
            Debug.Log('D');

            keyboardMovement = true;

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rotationX -= velocidade * Time.deltaTime;
            Debug.Log('A');

            keyboardMovement = true;

        }

        rotationX = Mathf.Clamp(rotationX, -95, 95);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationX, transform.localEulerAngles.z);

    }

    bool HasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }

}