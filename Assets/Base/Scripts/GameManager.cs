using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool _gamerOver = false;
    void Update()
    {
        if (_gamerOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }

    private void EndGame()
    {
        _gamerOver = true;
        Debug.Log("Game Over");
    }
}
