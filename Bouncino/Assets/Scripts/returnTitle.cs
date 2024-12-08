using UnityEngine;
using UnityEngine.SceneManagement;
public class returnTitle : MonoBehaviour
{
    public int titleScreen;
    public GameObject returnToTitle;
    private GameObject[] multipleReturns;

    void Start(){
        multipleReturns = GameObject.FindGameObjectsWithTag("toTitleScreen");
        if(multipleReturns.Length > 1){
            Destroy(multipleReturns[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(returnToTitle);
        
        if(Input.GetKeyDown(KeyCode.H)){
            SceneManager.LoadScene(titleScreen, LoadSceneMode.Single);
        }
    }
}
