using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIHostile : EnemyAIState
{
    public EnemyAIHostile(EnemyAI enemyAI): base(enemyAI){}

    public override void BeginState()
    {
        enemyAI.enemySelf.speed = 7f;
    }

    public override void UpdateState()
    {
        if(enemyAI.GetTarget() != null)
        {
            enemyAI.enemySelf.moveToward(enemyAI.GetTarget().transform.position);
        } else {
            enemyAI.ChangeState(enemyAI.idleState);
        }
    }
}
