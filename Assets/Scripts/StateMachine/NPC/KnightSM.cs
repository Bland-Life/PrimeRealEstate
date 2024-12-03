
public class KnightSM : TroopSMBase
{
    public KnightSM()
    {
        attackRange = 0;
        troopCharge = new TroopChargeEnemy(this);
        troopFollow = new TroopFollowState(this);
        troopGoTo = new TroopGoToSpotState(this);
        troopDefending = new TroopDefendingState(this);
        currentState = troopFollow;
    }
}
