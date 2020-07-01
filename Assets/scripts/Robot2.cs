using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot2 : MonoBehaviour
{
    RobotState currentState;
    public Text txt;
    private void Start()
    {
        SwitchState(new WorkState());
        
        txt.text = "State : " + "WorkState";
    }

    public void SwitchState(RobotState state)
    {
        currentState?.OnStateExit();
        currentState = state;
        currentState.robot = this;
        currentState.OnStateEnter();
        txt.text = "State : " + currentState.GetType().ToString();
    }

    
    

    private void Update()
    {
        currentState.OnUpdate();
        
    }
}


public class RobotState
{
    public Robot2 robot;

    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateExit()
    {

    }

    public virtual void OnUpdate()
    {

    }
}

public class SleepState : RobotState
{
    float delivered;
    float timer;
    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            delivered = delivered +1;
        }
        if (delivered > 5f)
        {
            delivered = 0;
            robot.SwitchState(new WorkState());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            delivered = 0;
            robot.SwitchState(new WorkState());
        }
    }
}

public class WorkState : RobotState
{
    float timer;
    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 10f)
        {
            robot.SwitchState(new SleepState());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            robot.SwitchState(new SleepState());
        }

    }
}






