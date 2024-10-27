using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningScene : MonoBehaviour
{
    [SerializeField] Button map1;
    [SerializeField] Button map2;
    [SerializeField] string sceneMap1 = "Map1";
    [SerializeField] string sceneMap2 = "Map2";
    public GameStateChannel gameStateChannel;
    [SerializeField] StateSo inGameState;


    void Start()
    {
        gameStateChannel = FindObjectOfType<Beacon>().gameStateChannel;
        map1.onClick.AddListener(() => LoadMap(sceneMap1));
        map2.onClick.AddListener(() => LoadMap(sceneMap2));


    }

    public void LoadMap(string mapScene)
    {
        gameStateChannel.StateEntered(inGameState);
        SceneManager.LoadScene(mapScene);
  
    }

   
}
