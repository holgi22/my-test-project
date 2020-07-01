using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuberotate : MonoBehaviour
{
    
    
    
    
    //Rotational Speed
    public float speed = 0f;

    //Forward Direction
    public bool ForwardX = false;
    public bool ForwardY = false;
    public bool ForwardZ = false;

    //Reverse Direction
    public bool ReverseX = false;
    public bool ReverseY = false;
    public bool ReverseZ = false;


    public float Geschwindigkeit = 0f;
    public Vector3 Richtung = new Vector3 (0, 0, 0);
    float degrees = 90;





    void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            ForwardX = false;
            ForwardY = false;
            // ForwardZ = false;
            speed = 0f; ;
            Vector3 to = new Vector3(0, 90, 0);
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
           
        }

        if (Input.GetKey(KeyCode.R))
        {
            // ForwardX = true;
            ForwardY = true;
            // ForwardZ = true;
            speed = 20f;
        }

        if (Input.GetKey(KeyCode.G))
        {
            Geschwindigkeit = 0f;
            Richtung = new Vector3(0f, 90f, 0f);
            this.transform.position = new Vector3(0, 0, 0);
        }


        if (Input.GetKey(KeyCode.L))
        {
            Geschwindigkeit = 10f;
            Richtung = new Vector3(0f, 0f, 1f);
            this.transform.position += Richtung * Geschwindigkeit * Time.deltaTime;
        }

        this.transform.position += Richtung * Geschwindigkeit * Time.deltaTime;

        //Forward Direction
        if (ForwardX == true)
        {
            // transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ForwardY == true)
        {
            transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
        }
        if (ForwardZ == true)
        {
            // transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
        }
        //Reverse Direction
        if (ReverseX == true)
        {
            transform.Rotate(-Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ReverseY == true)
        {
            transform.Rotate(0, -Time.deltaTime * speed, 0, Space.Self);
        }
        if (ReverseZ == true)
        {
            transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);
        }

    }
}
