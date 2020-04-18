using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	public GameObject playerInstance;

	public int numLives = 4;

	float respawnTimer;

	// Use this for initialization
	void Start () {
		SpawnPlayer();
	}

	public void SpawnPlayer() {
		numLives--;
		respawnTimer = 1;
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
	}

    void NextScene()
    {
        SceneManager.LoadScene("_MENU_SCENE_");
    }

    // Update is called once per frame
    void Update () {
		if(playerInstance == null && numLives > 0) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0) {
				SpawnPlayer();
			}
		}
	}

	void OnGUI() {
		if(numLives > 0 || playerInstance!= null) {
			GUI.Label( new Rect(5, 0, 100, 50), "Lives Left: " + numLives);
		}
		else {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 150, 100), "GAME OVER");
            GUI.Label(new Rect(Screen.width / 2 - 67, Screen.height / 2 + 50, 300, 100), "press Enter to return");
            if (Input.GetKey(KeyCode.Return))
            {
                NextScene();
            }
        }
	}
}
