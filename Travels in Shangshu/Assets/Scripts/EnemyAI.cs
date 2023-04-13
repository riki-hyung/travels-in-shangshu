using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Enemy enemySelf; // This is the enemy's 'self'
    public Player target;
    
    EnemyAIState currentState;
    public EnemyAIAlert alertState{get; private set;}
    public EnemyAIHostile hostileState{get; private set;}
    public EnemyAIIdle idleState{get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        alertState = new EnemyAIAlert(this);
        hostileState = new EnemyAIHostile(this);
        idleState = new EnemyAIIdle(this);
        currentState = idleState;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.UpdateStateBase();
    }

    public void ChangeState(EnemyAIState newState)
    {
        currentState = newState;
        currentState.BeginStateBase();
    }

    public Player GetTarget()
    {
        if(Vector3.Distance(transform.position, target.transform.position) < 5)
        {
            return target;
        } else {
            return null;
        }
    }
}
