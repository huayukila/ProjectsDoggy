using UnityEngine;

public class EnemyStand : State
{
    float waitTime = 2.5f;
    float timer = 0f;
    float rotationSpeed = 10f;
    public override void CameraUpdate()
    {
    }

    public override void LogicUpdate()
    {
        _stateMachine.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        timer += Time.deltaTime;

        if(timer >= waitTime)
        {
            _stateMachine.ChangeStateTo("EnemyWalk");
        }
    }

    public override void OnEnter()
    {
        Debug.Log("EnemyStand");
        timer = 0f;
    }

    public override void OnExit()
    {
        
    }

    public override void PhysicUpdate()
    {
        
    }
}
