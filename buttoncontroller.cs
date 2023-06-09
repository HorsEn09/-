using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttoncontroller : MonoBehaviour
{
    public void jump_warmup()
    {
        SceneManager.LoadScene(0);
    }
    public void jump_regular()
    {
        SceneManager.LoadScene(1);
    }
    public void jump_aerobics()
    {
        SceneManager.LoadScene(2);
    }
    public void jump_exercise()
    {
        SceneManager.LoadScene(4);
    }
    public void Quit_robbort()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene(3);
    }
    public void yogqa_class()
    {
        SceneManager.LoadScene(5);
    }
}
