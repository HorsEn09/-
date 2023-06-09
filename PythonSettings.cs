using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class PythonSettings : MonoBehaviour
{
    private string python_path;
    // Start is called before the first frame update
    void Start()
    {
        python_path = Application.dataPath + "/Python/BodyRecognition.py";
        //Debug.Log(python_path);
        PythonRunner.RunFile(python_path);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(python_path);   
    }
}
