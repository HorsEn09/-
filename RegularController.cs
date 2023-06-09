using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegularController : MonoBehaviour
{
    public InputField inputNumber;
    public Text notice;
    public static int mode;
    public static int number;

    public void onClick1()
    {
        mode = 1;
        if (inputNumber.text != "")
        {
            number = int.Parse(inputNumber.text);
            SceneManager.LoadScene(6);
        }
        else
        {
            notice.text = "*请输入数量";
        }
    }

    public void onClick2()
    {
        mode = 2;
        if (inputNumber.text != "")
        {
            number = int.Parse(inputNumber.text);
            SceneManager.LoadScene(6);
        }
        else
        {
            notice.text = "*请输入数量";
        }
    }

    public void onClick3()
    {
        mode = 3;
        if (inputNumber.text != "")
        {
            number = int.Parse(inputNumber.text);
            SceneManager.LoadScene(6);
        }
        else
        {
            notice.text = "*请输入数量";
        }
    }
}
