using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    private void Awake()
    {
        //�eSystem�̃C�j�V����
        DontDestroyOnLoad(gameObject);


        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {
    }
}