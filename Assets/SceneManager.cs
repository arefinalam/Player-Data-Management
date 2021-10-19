using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    private PlayerDataController playerDataController;

    [Header("Player List")]
    public Text searchBoxText;
    public GameObject playerPrefsObject;
    public GameObject playerListContent;

    [Header("New Player")]
    public GameObject newPlayerPanel;
    public Text nameText;
    public Text ageText;
    public Dropdown type;
    // Start is called before the first frame update
    void Start()
    {
        playerDataController = GetComponent<PlayerDataController>();
        newPlayerPanel.SetActive(false);
        LoadPlayer();
       
    }

    void LoadPlayer()
    {
        foreach (Transform child in playerListContent.transform)
        {
            Destroy(child.gameObject);
        }
        List<Player> players = playerDataController.GetAllPlayers();
        foreach (Player player in players)
        {
            GameObject playerObject = Instantiate(playerPrefsObject, this.transform);
            playerObject.transform.GetChild(0).GetComponent<Text>().text = player.name;
            playerObject.transform.GetChild(1).GetComponent<Text>().text = player.age.ToString();
            playerObject.transform.GetChild(2).GetComponent<Text>().text = player.type;
            playerObject.transform.parent = playerListContent.transform;
            playerObject.transform.localScale = Vector3.one;
        }
    }


    public void LoadNewPlayerPanel()
    {
        newPlayerPanel.SetActive(true);
    }

    public void HideNewPlayerPanel()
    {
        newPlayerPanel.SetActive(false);
    }


    public void AddNewPlayer()
    {
        Player player = new Player();
        player.name = nameText.text.ToString();
        player.age = Int32.Parse(ageText.text.ToString());
        int dropDownIndex = type.value;
        player.type = type.options[dropDownIndex].text.ToString();
        playerDataController.AddNewPlayer(player);

        LoadPlayer();
        newPlayerPanel.SetActive(false);
    }


    public void SearchPlayerDynamically()
    {
        Invoke("Searching", 0.25f);
        
    }

    void Searching()
    {
        Debug.Log(searchBoxText.text.ToString());
        foreach (Transform child in playerListContent.transform)
        {
            Destroy(child.gameObject); 
        }
        List<Player> players = playerDataController.GetPlayersByName(searchBoxText.text.ToString());
        foreach (Player player in players)
        {
            GameObject playerObject = Instantiate(playerPrefsObject, this.transform);
            playerObject.transform.GetChild(0).GetComponent<Text>().text = player.name;
            playerObject.transform.GetChild(1).GetComponent<Text>().text = player.age.ToString();
            playerObject.transform.GetChild(2).GetComponent<Text>().text = player.type;
            playerObject.transform.parent = playerListContent.transform;
            playerObject.transform.localScale = Vector3.one;
        }
    }

}
