using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    private void Awake()
    {
        //各Systemのイニシャル
        DontDestroyOnLoad(gameObject);


        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {
    }
}