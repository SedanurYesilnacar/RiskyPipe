using RiskyPipe3D;
using System;
using UnityEngine;
using RiskyPipe3D.Scripts.Managers;

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
        PlayerData p = new PlayerData();
        p.highScore = playerView.HighScore;
        p.level = playerView.Level;
        p.totalCoin = playerView.TotalCoin;
        p.defaultSpeed = playerView.DefaultSpeed;
        PlayerPrefs.SetString("Player", JsonUtility.ToJson(p));
    }

    public PlayerView GetPlayer()
    {
        PlayerView pView = null;
        if (PlayerPrefs.HasKey("Player"))
        {
            pView = new PlayerView(JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("Player")));
        }
        else
        {
            PlayerData player = new PlayerData() { highScore = 0, level = 1, totalCoin = 0, defaultSpeed = 4 };
            pView = new PlayerView(player);
            SavePlayer(pView);
        }
        EventManager.Instance.PlayerGott(pView);
        SetHandle(pView);
        return pView;
    }
}
