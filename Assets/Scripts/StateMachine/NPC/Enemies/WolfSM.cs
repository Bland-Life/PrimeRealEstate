
public class WolfSM : EnemySMBase
{
    public WolfSM() {
        //enemyIdle = new WolfIdleState(this);
        enemyChase = new EnemyChaseState(this);
        enemyIdle = new EnemyIdleState(this);
        enemyReturn = new EnemyReturnHome(this);

        currentState = enemyIdle;
    }
}
