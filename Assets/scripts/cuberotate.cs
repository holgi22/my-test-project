using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuberotate : MonoBehaviour
{
    public float speed = 0f;
    public bool ForwardX = false;
    public bool ForwardY = false;
    public bool ForwardZ = false;
    public bool ReverseX = false;
    public bool ReverseY = false;
    public bool ReverseZ = false;
    public float Geschwindigkeit = 0f;
    public Vector3 Richtung = new Vector3(0, 0, 0);
    float degrees = 90;
    public enum State { Rotating, StopRotating, WalkingAway, ComeBack };
    public State state = State.StopRotating;

    void Update()
    {
        switch (state)
        {
            case State.Rotating:
                if (Input.GetKey(KeyCode.N))
                {
                    Rotating();
                }
                break;

            case State.StopRotating:
                if (Input.GetKey(KeyCode.R))
                {
                    StopRotating();
                }
                break;

            case State.WalkingAway:
                if (Input.GetKey(KeyCode.L))
                {
                    WalkingAway();
                }
                break;

            case State.ComeBack:
                if (Input.GetKey(KeyCode.G))
                {
                    ComeBack();
                }
                break;

        }

        this.transform.position += Richtung * Geschwindigkeit * Time.deltaTime;

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
    private void Rotating()
    {
        ForwardX = false;
        ForwardY = false;
        // ForwardZ = false;
        speed = 0f; ;
        Vector3 to = new Vector3(0, 90, 0);
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
    }

    private void StopRotating()
    {
        // ForwardX = true;
        ForwardY = true;
        // ForwardZ = true;
        speed = 20f;
    }

    private void WalkingAway()
    {
        Geschwindigkeit = 10f;
        Richtung = new Vector3(0f, 0f, 1f);
        this.transform.position += Richtung * Geschwindigkeit * Time.deltaTime;
    }

    private void ComeBack()
    {
        Geschwindigkeit = 0f;
        Richtung = new Vector3(0f, 90f, 0f);
        this.transform.position = new Vector3(0, 0, 0);
    }


}
