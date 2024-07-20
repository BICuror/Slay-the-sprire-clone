using UnityEngine.UI;
using UnityEngine;

public sealed class EnemySpriteApplyer : MonoBehaviour
{
    [SerializeField] private Image _enemyImage; 

    public void ApplySprite(Sprite sptire)
    {
        _enemyImage.sprite = sptire;
    }
}