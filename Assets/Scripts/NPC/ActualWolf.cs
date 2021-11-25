using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualWolf : WolfMove
{
    public override void Start()
    {
        base.Start();
        walkSpeed = 5 + difficulty;
        runSpeed = 4 * difficulty+1;
    }

    public override void Update()
    {
        base.Update();
        FaceTarget();
    }    

    public void BiteAttack()
    {
        int critChance = Random.Range(0, 21);
        float critDamage = 0;
        if (critChance >= 20 - difficulty)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }
        player.GetComponent<PlayerHandler>().DamagePlayer(baseDamage * difficulty + critDamage);
    }
}
