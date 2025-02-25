using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraDragMove : MonoBehaviour
{
    // Button Input Vars
    public float panSpeed = 4000f;
    public float scrollSpeed = 2000f;
    public float minY = 50f;
    public float maxY = 4000f;
    public float mouseSpeed = 0.2f;
    public float minX = -6000f;
    public float maxX = 6000f;
    public float minZ = -11400f;
    public float maxZ = 1900f;

    // Mouse Input Vars
    private Vector3 dragOrigin;
    private Vector3 cameraDragOrigin;
    private Vector3 currentPosition;

    void Update()
    {
        ButtonInputs();
        MouseInputs();
        ZoomCamera();
    }

    // Take x and z inputs and translate based on camera rotation
    private void MoveCamera(float xInput, float zInput)
    {
        float zMove = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180) * zInput - Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180) * xInput;
        float xMove = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180) * zInput + Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180) * xInput;

        transform.position = transform.position + new Vector3(xMove, 0, zMove);
    }
    Vector3 lastMousePosition;

    // Get mouse drag inputs

    void MouseInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = (Input.mousePosition - lastMousePosition) / mouseSpeed;

            MoveCamera(delta.x, delta.y);

            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
        }

    }

    // get keyboard inputs
    void ButtonInputs()
    {
        float inputZ = 0f;
        float inputX = 0f;

        if (Input.GetKey("w"))
        {
            inputZ += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            inputZ -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            inputX += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            inputX -= panSpeed * Time.deltaTime;
        }

        MoveCamera(inputX, inputZ);
    }

    // zoom via scrollwheel
    void ZoomCamera()
    {
        Vector3 pos = transform.position;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime * 300f;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);  
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;
    }

}

