using UnityEngine;

[CreateAssetMenu(fileName = "AddShield", menuName = "Effects/AddShield")]

public class AddShield : Effect 
{
    public override void ApplyEffect(BattleEntity battleEntity, int charge)
    {
        battleEntity.ShieldModel.AddShiled(charge);
    }
}

