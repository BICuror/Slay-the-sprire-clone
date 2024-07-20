using UnityEngine;
using System;

public sealed class TurnManager : MonoBehaviour
{
    public Action RoundStarted;
    public Action PlayerTurnEnded;
    public Action EnemyTurnStarted;
    public Action BattleEnded;
    
    public void StartBattle()
    {
        StartRound();
    }

    private void StartRound()
    {   
        RoundStarted.Invoke();
    }

    public void EndPlayerTurn()
    {
        PlayerTurnEnded.Invoke();
        StartEnemyTurn();
    }

    private void StartEnemyTurn()
    {
        EnemyTurnStarted.Invoke();

        EndEnemyTurn();
    }

    public void EndEnemyTurn()
    {
        StartRound();
    }

    public void EndBattle()
    {
        PlayerTurnEnded.Invoke();
        BattleEnded.Invoke();
    }
}