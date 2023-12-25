using UnityEngine;

public class MinigameUser<T> where T : MonoBehaviour
{
    public T Player { get; private set; }
    public int Score { get; private set; }

    public MinigameUser(T player)
    {
        this.Player = player;
    }
}
