using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMScript : MonoBehaviour
{
    public AudioSource BGM;
    private string scene;
    private GameObject[] music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        scene = currentScene.name;
        music = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if(music.Length > 1){
            Destroy(music[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        scene = currentScene.name;
        DontDestroyOnLoad(BGM);

        if(scene.Equals("Title_Screen") || scene.Equals("Level_Select_Screen")){
            BGM.mute = true;
      } else {
            BGM.mute = false;
      }
    }
}
