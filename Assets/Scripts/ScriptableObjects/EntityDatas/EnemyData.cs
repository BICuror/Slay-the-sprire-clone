using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData")]

public class EnemyData : EntityData 
{
    [SerializeField] private Sprite _sprite;

    public Sprite Sprite => _sprite;
}