using UnityEngine;
using Zenject;

public sealed class EntryPoint : MonoBehaviour
{
    [Inject] private EncounterManager _encounterManager;
    [SerializeField] private PlayerDataSetter _playerDataSetter;

    private void Start()
    {
        _playerDataSetter.SetPlayerData();

        _encounterManager.StartRun();
    }
}
