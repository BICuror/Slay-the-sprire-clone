using UnityEngine;
using Zenject;

public sealed class EncounterManager : MonoBehaviour
{
    [Inject] private TeamsContainer _teamsContainer;
    [Inject] private TurnManager _turnManager;
    [SerializeField] private EnemyCardPlayer _enemyCardPlayer;
    [SerializeField] private EnemyData[] _enemyData;
    [SerializeField] private EnemySpriteApplyer _enemySpriteApplyer;
    private int _currentEncounterIndex;

    public void StartRun()
    {
        _teamsContainer.EnemyTeam.Self.HealthModel.Died += EndEncounter;
        _teamsContainer.PlayerTeam.Self.HealthModel.Died += Lose;

        StartEncounter();
    }

    private void StartEncounter()
    {
        SetEnemyData();
        _turnManager.StartBattle();
    }

    private void SetEnemyData()
    {
        EnemyData enemyData = _enemyData[_currentEncounterIndex];

        _teamsContainer.EnemyTeam.Self.HealthModel.SetMaxHealth(enemyData.MaxHealth);
        _enemyCardPlayer.SetDeck(enemyData.Deck);
        _enemySpriteApplyer.ApplySprite(enemyData.Sprite);
    }

    private void EndEncounter()
    {
        _currentEncounterIndex++;
        
        if (_enemyData.Length > _currentEncounterIndex)
        {
            _turnManager.EndBattle();
            StartEncounter();
        }
        else
        {
            Win();
        }
    }

    private void Win() => Debug.Log("You won!");
    private void Lose() => Debug.Log("You lost :(");
}
