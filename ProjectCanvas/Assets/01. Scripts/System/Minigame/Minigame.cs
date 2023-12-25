using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame<T> : MonoBehaviour where T : MonoBehaviour
{
    private Dictionary<ulong, MinigameUser<T>> users;

	public abstract void StartGame();
    public abstract void StopGame();

    public void RegisterUser(ulong id, T user)
    {
        if(users.ContainsKey(id) == false)
            users.Add(id, new MinigameUser<T>(user));
    }

    public Dictionary<ulong, MinigameUser<T>> GetUserList() => users;

    public MinigameUser<T> GetUser(ulong id)
    {
        if(users.ContainsKey(id) == false)
            return null;

        return users[id];
    }
}
