using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIAlert : EnemyAIState
{
    public EnemyAIAlert(EnemyAI enemyAI): base(enemyAI){}

    Vector3 moveVec;

    public override void BeginState()
    {
        MoveRandom();
    }

    public override void UpdateState()
    {
        if(timer > 1.5f)
        {
            timer = 0;
            MoveRandom();
        }

        enemyAI.enemySelf.Move(moveVec);

        if(enemyAI.GetTarget() != null)
        {
            enemyAI.enemySelf.moveToward(enemyAI.GetTarget().transform.position);
        }
    }

    public void MoveRandom()
    {
        moveVec = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0));
    }
}
