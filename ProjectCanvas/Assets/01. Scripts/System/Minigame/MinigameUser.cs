using Unity.Netcode;
using UnityEngine;

public class MinigameUser
{
    public NetworkObject Player { get; private set; }
    public int Score { get; private set; }

    public MinigameUser(NetworkObject player)
    {
        this.Player = player;
    }
}
