using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class changeScene : MonoBehaviour {
    public Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(loadLevel);
    }
	void loadLevel()
    {
        SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
