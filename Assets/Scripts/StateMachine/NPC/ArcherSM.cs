using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSM : TroopSMBase
{
   public ArcherSM()
    {
        attackRange = 3;
        troopCharge = new TroopChargeEnemy(this);
        troopFollow = new TroopFollowState(this);
        troopGoTo = new TroopGoToSpotState(this);
        troopDefending = new TroopDefendingState(this);
        currentState = troopFollow;
    }
}
