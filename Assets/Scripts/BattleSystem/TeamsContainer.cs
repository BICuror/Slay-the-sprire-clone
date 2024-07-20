using UnityEngine;
using System;

public sealed class TeamsContainer : MonoBehaviour
{
    [SerializeField] private Team _playerTeam;
    [SerializeField] private Team _enemyTeam;

    public Team PlayerTeam => _playerTeam;
    public Team EnemyTeam => _enemyTeam;
}

[Serializable] public struct Team
{
    [SerializeField] private BattleEntity _self;
    [SerializeField] private BattleEntity _enemy;  

    public BattleEntity Self => _self;
    public BattleEntity Enemy => _enemy;
}
