using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] bodyPoints;

    void Update()
    {
        string data = udpReceive.data;

        print(data);
        string[] points = data.Split(',');
        print(points[0]);

        for (int i = 0; i <= 32; i++)
        {
            float x = float.Parse(points[0 + (i * 3)]) / 10;
            float y = float.Parse(points[1 + (i * 3)]) / 10;
            float z = float.Parse(points[2 + (i * 3)]) / 10;

            bodyPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
    }
}
