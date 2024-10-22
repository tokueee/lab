using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("TitelScene");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーのタグを確認
        if (other.CompareTag("Player"))
        {
            // シーンを移動
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
