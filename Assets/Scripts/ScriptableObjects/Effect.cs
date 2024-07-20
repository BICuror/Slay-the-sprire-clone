using UnityEngine;

public abstract class Effect : ScriptableObject 
{
    public abstract void ApplyEffect(BattleEntity battleEntity, int charge);
}
