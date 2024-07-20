using UnityEngine;

[CreateAssetMenu(fileName = "DealDamage", menuName = "Effects/DealDamage")]

public class DealDamage : Effect 
{
    public override void ApplyEffect(BattleEntity battleEntity, int charge)
    {
        battleEntity.HealthModel.TakeDamage(charge);
    }
}

