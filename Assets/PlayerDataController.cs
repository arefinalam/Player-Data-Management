using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
public class PlayerDataController : MonoBehaviour
{
    private void Start()
    {
     
       
    }

    public List<Player> GetAllPlayers()
    {

        string Data;
        if (PlayerPrefs.GetString("player") != "")
        {
            Data = PlayerPrefs.GetString("player");
        }
        else
        {
            TextAsset file = Resources.Load("player") as TextAsset;
            Data = file.text;
        }

       
        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(Data.ToString());
        
        return players;
    }

    public List<Player> GetPlayersByName(string nameKeyword)
    {

        List<Player> players = GetAllPlayers();
        List<Player> searchPlayer = new List<Player>();
        foreach(Player player in players)
        {
            
            if (player.name.ToLower().Contains(nameKeyword.ToLower()))
            {
                searchPlayer.Add(player);
            }
        }
        Debug.Log("contain:"+JsonConvert.SerializeObject(searchPlayer));
        return searchPlayer;
    }


    public void AddNewPlayer(Player player)
    {
        List<Player> players = GetAllPlayers();
        Debug.Log(players);
        if (players.Count==0 || players == null)
        {
           
            players = new List<Player>();
        }
        players.Add(player);

        PlayerPrefs.SetString("player", JsonConvert.SerializeObject(players));
        Debug.Log("New Player added:"+JsonConvert.SerializeObject(player));
    }
}
