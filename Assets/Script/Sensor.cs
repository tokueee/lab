using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sensor : MonoBehaviour
{
    public GameObject enemy;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Ç†ÇΩÇ¡ÇΩ");
            //ÉVÅ[Éìçƒì«Ç›çûÇ›
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("GameOverScene");
        }
    }

}