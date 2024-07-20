using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardData")]

public sealed class CardData : ScriptableObject 
{
    [Header("MainInfo")]
    [Range(0, 10)] [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    
    [Header("Effects")]
    [SerializeField] private CardEffect[] _effectsToApplyToSelf;
    [SerializeField] private CardEffect[] _effectsToApplyToEnemy;

    public int Price => _price;
    public Sprite Icon => _icon;
    public string Name => _name;
    public string Description => _description;

    public CardEffect[] EffectsToApplyToSelf => _effectsToApplyToSelf; 
    public CardEffect[] EffectsToApplyToEnemy => _effectsToApplyToEnemy;
}

[System.Serializable] public struct CardEffect
{
    [SerializeField] private Effect _effect;
    [SerializeField] private int _charges;

    public Effect Effect => _effect;
    public int Charges => _charges;
}
