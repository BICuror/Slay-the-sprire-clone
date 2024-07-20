using UnityEngine;
using Model;

[RequireComponent(typeof(HealthModel))]
[RequireComponent(typeof(ShieldModel))]

public sealed class BattleEntity : MonoBehaviour
{
    private HealthModel _healthModel;
    private ShieldModel _shieldModel;

    public HealthModel HealthModel => _healthModel;
    public ShieldModel ShieldModel => _shieldModel; 

    private void Awake()
    {
        _healthModel = GetComponent<HealthModel>();
        _shieldModel = GetComponent<ShieldModel>();
    }
}
