using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Deck", menuName = "Deck")]

public class Deck : ScriptableObject 
{
    [SerializeField] private List<CardData> _cards;

    public List<CardData> Cards => _cards;
}
