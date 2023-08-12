using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject howto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        howto.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(2);
    }

    public void CloseHowToPlay()
    {
        howto.SetActive(false);
    }
}
