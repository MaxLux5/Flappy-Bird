using UnityEngine;

public class AddPoint : MonoBehaviour
{
    [SerializeField] private ScoreDisplay _scoreDisplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _scoreDisplay.increaseScore();
    }
}
