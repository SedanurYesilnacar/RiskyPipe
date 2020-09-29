using RiskyPipe3D;
using System;
using UnityEngine;

public class FileManager
{
    public static FileManager Instance { get; private set; } = new FileManager();
    private FileManager() { }
    private void SetHandle(PlayerView playerView)
    {
        playerView.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged(PlayerView p)
    {
        SavePlayer(p);
    }

    public void SavePlayer(PlayerView playerView)
    {
        Player p = new Player();
        p.highScore = playerView.HighScore;
        p.level = playerView.Level;
        p.totalCoin = playerView.TotalCoin;
        PlayerPrefs.SetString("Player", JsonUtility.ToJson(p));
    }

    public PlayerView GetPlayer()
    {
        PlayerView pView = null;
        if (PlayerPrefs.HasKey("Player"))
        {
            pView = new PlayerView(JsonUtility.FromJson<Player>(PlayerPrefs.GetString("Player")));
            SetHandle(pView);
            return pView;
        }
        pView = new PlayerView(new Player() { highScore = 0, level = 1, totalCoin = 0 });
        SetHandle(pView);
        return pView;
    }
}
