using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    private Dictionary<ulong, MinigameUser> users;

	public abstract void StartGame();
    public abstract void CloseGame();

    public void RegisterUser(NetworkObject user)
    {
        if(users.ContainsKey(user.NetworkObjectId) == false)
            users.Add(user.NetworkObjectId, new MinigameUser(user));
    }

    public void RegisterUsers(List<NetworkObject> users) => users.ForEach(RegisterUser);

    public Dictionary<ulong, MinigameUser> GetUserList() => users;

    public MinigameUser GetUser(ulong id)
    {
        if(users.ContainsKey(id) == false)
            return null;

        return users[id];
    }
}
