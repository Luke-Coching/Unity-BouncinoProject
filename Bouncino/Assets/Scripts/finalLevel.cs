using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalLevel : MonoBehaviour
{
   public int sceneNum;
   public bool bossDefeated = false;

   private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && bossDefeated == true){
            SceneManager.LoadScene(sceneNum, LoadSceneMode.Single);
        }
    }  
}
