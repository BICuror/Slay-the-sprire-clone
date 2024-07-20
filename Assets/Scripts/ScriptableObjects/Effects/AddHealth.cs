using UnityEngine;

[CreateAssetMenu(fileName = "AddHealth", menuName = "Effects/AddHealth")]

public class AddHealth : Effect 
{
    public override void ApplyEffect(BattleEntity battleEntity, int charge)
    {
        battleEntity.HealthModel.Heal(charge);
    }
}
