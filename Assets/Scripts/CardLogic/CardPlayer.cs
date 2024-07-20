using UnityEngine;
using Model;

public sealed class CardPlayer : MonoBehaviour
{
    [SerializeField] private EnergyCounterModel _energyCounterModel;

    public bool IsPossibleToPlayCard(CardData cardData)
    {
        return _energyCounterModel.HasEnoughEnergy(cardData.Price);
    }

    public void PlayCardWithEnergy(CardData cardData, Team playedEntityTeam)
    {
        _energyCounterModel.SpendEnergy(cardData.Price);
        PlayCard(cardData, playedEntityTeam);        
    }

    public void PlayCard(CardData cardData, Team playedEntityTeam)
    {
        ApplyEffects(playedEntityTeam.Self, cardData.EffectsToApplyToSelf);
        ApplyEffects(playedEntityTeam.Enemy, cardData.EffectsToApplyToEnemy);
    }

    private void ApplyEffects(BattleEntity battleEntity, CardEffect[] cardEffects)
    {
        foreach (CardEffect cardEffect in cardEffects)
        {
            cardEffect.Effect.ApplyEffect(battleEntity, cardEffect.Charges);
        }
    }
}
