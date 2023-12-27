using UnityEngine;

public class MinigameManager
{
    public static MinigameManager Instance = null;

    public Minigame CurrentGame { get; private set; } = null;
    public bool IsPlaying { get; private set; } = false;

	public void LoadMinigame(Minigame minigame)
    {
        CurrentGame = GameObject.Instantiate(minigame);
        // CurrentGame.RegisterUsers(userList);
    }

    public void StartGame()
    {
        if(CurrentGame == null)
            return;

        IsPlaying = true;
        CurrentGame.StartGame();
    }

    public void CloseGame()
    {
        if(CurrentGame == null)
            return;

        CurrentGame.CloseGame();
        IsPlaying = false;

        GameObject.Destroy(CurrentGame);
    }
}
