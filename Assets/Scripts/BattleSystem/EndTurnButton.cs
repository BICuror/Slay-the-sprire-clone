using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(EndTurnButton))]

public sealed class EndTurnButton : MonoBehaviour
{
    [SerializeField] private TurnManager _turnManager;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(_turnManager.EndPlayerTurn);
    }
}
