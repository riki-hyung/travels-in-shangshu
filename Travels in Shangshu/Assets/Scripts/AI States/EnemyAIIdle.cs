using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIIdle : EnemyAIState
{
    public EnemyAIIdle(EnemyAI enemyAI): base(enemyAI){}

    public override void BeginState()
    {
        enemyAI.enemySelf.speed = 3f;
    }

    public override void UpdateState()
    {
        if(enemyAI.GetTarget() != null)
        {
            enemyAI.enemySelf.moveToward(enemyAI.GetTarget().transform.position);
        } else {
            enemyAI.ChangeState(enemyAI.alertState);
        }
    }
}
