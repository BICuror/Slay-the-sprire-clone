using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "EntityData")]

public class EntityData : ScriptableObject 
{
    [SerializeField] private Deck _deck;
    [SerializeField] private int _maxHealth;

    public Deck Deck => _deck;
    public int MaxHealth => _maxHealth;
}