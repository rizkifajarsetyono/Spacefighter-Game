using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{ 
    public GameObject playerPrefab;
    GameObject playerInstance;



    // Use this for initialization
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    void NextScene()
    {
        SceneManager.LoadScene("_SCENE_");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            NextScene();
        }
    }

    void OnGUI()
    {
        if (playerInstance != null)
        {
            GUI.Label(new Rect(Screen.width / 2 - 70, Screen.height / 2 + 60, 300, 100), "press Enter to play");
        }
    }
}
