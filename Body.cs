using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Body : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] bodyPoints;

    public Text number;

    public int counter;

    private int flag;

    public AudioClip fiveTimes;
    public AudioClip tenTimes;

    private AudioSource source;

    private void Start()
    {
        flag = 0;
        counter = 0;
        number.text = "0";
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        string data = udpReceive.data;

        if (data != "")
        {
            string[] points = data.Split(',');
            bodyPoints[0].transform.localPosition = new Vector3(0, 0, 0);
            for (int i = 1; i <= 32; i++)
            {
                float x = (float.Parse(points[0 + (i * 3)]) / 10) - (float.Parse(points[0]) / 10);
                float y = (float.Parse(points[1 + (i * 3)]) / 10) - (float.Parse(points[1]) / 10);
                float z = (float.Parse(points[2 + (i * 3)]) / 10) - (float.Parse(points[2]) / 10);

                bodyPoints[i].transform.localPosition = new Vector3(x, y, z);
            }
        }

        if (RegularController.mode == 1)
        {
            Mode1();
        }
        else if (RegularController.mode == 2)
        {
            Mode2();
        }
        else if (RegularController.mode == 3)
        {
            Mode3();
        }
    }

    private void Mode1()
    {
        Vector3 d1 = bodyPoints[24].transform.localPosition - bodyPoints[26].transform.localPosition;
        Vector3 d2 = bodyPoints[28].transform.localPosition - bodyPoints[26].transform.localPosition;
        float angleL = Vector3.Angle(d1, d2);
        d1 = bodyPoints[23].transform.localPosition - bodyPoints[25].transform.localPosition;
        d2 = bodyPoints[27].transform.localPosition - bodyPoints[25].transform.localPosition;
        float angleR = Vector3.Angle(d1, d2);
        Debug.Log(angleL);
        if (flag == 0 && angleL < 90 && angleR < 90)
        {
            flag = 1;
            counter += 1;
            number.text = counter.ToString();
            if (counter % 5 == 0 && counter % 10 != 0)
            {
                source.PlayOneShot(fiveTimes);
            }
            if (counter % 10 == 0)
            {
                source.PlayOneShot(tenTimes);
            }
            if (counter == RegularController.number)
            {
                Debug.Log("您已完成目标次数!");
            }
        }
        if (flag == 1 && angleL > 170 && angleR > 170)
        {
            flag = 0;
        }
    }

    private void Mode2()
    {
        Vector3 d1 = bodyPoints[12].transform.localPosition - bodyPoints[14].transform.localPosition;
        Vector3 d2 = bodyPoints[16].transform.localPosition - bodyPoints[14].transform.localPosition;
        float angleL = Vector3.Angle(d1, d2);
        d1 = bodyPoints[11].transform.localPosition - bodyPoints[13].transform.localPosition;
        d2 = bodyPoints[15].transform.localPosition - bodyPoints[13].transform.localPosition;
        float angleR = Vector3.Angle(d1, d2);
        if (flag == 1 && angleL < 100 && angleR < 100)
        {
            flag = 0;
        }

        d1 = bodyPoints[14].transform.localPosition - bodyPoints[12].transform.localPosition;
        d2 = bodyPoints[11].transform.localPosition - bodyPoints[12].transform.localPosition;
        float sholderAngleL = Vector3.Angle(d1, d2);
        d1 = bodyPoints[13].transform.localPosition - bodyPoints[11].transform.localPosition;
        d2 = bodyPoints[12].transform.localPosition - bodyPoints[11].transform.localPosition;
        float sholderAngleR = Vector3.Angle(d1, d2);
        if (flag == 0 && angleL > 170 && angleR > 170 && sholderAngleL < 100 && sholderAngleR < 100)
        {
            flag = 1;
            counter += 1;
            number.text = counter.ToString();
            if (counter % 5 == 0 && counter % 10 != 0)
            {
                source.PlayOneShot(fiveTimes);
            }
            if (counter % 10 == 0)
            {
                source.PlayOneShot(tenTimes);
            }
            if (counter == RegularController.number)
            {
                Debug.Log("您已完成目标次数!");
            }
        }
    }

    private void Mode3()
    {
        Vector3 d1 = bodyPoints[12].transform.localPosition - bodyPoints[14].transform.localPosition;
        Vector3 d2 = bodyPoints[16].transform.localPosition - bodyPoints[14].transform.localPosition;
        float angleL = Vector3.Angle(d1, d2);
        d1 = bodyPoints[11].transform.localPosition - bodyPoints[13].transform.localPosition;
        d2 = bodyPoints[15].transform.localPosition - bodyPoints[13].transform.localPosition;
        float angleR = Vector3.Angle(d1, d2);
        if (flag == 1 && angleL > 100 && angleR > 100)
        {
            flag = 0;
        }

        float elbowPosL = bodyPoints[13].transform.localPosition.y;
        float elbowPosR = bodyPoints[14].transform.localPosition.y;
        if (flag == 0 && angleL < 90 && angleR < 90 && elbowPosL < bodyPoints[11].transform.localPosition.y &&
        elbowPosL < bodyPoints[23].transform.localPosition.y && elbowPosR < bodyPoints[12].transform.localPosition.y &&
        elbowPosR < bodyPoints[24].transform.localPosition.y)
        {
            flag = 1;
            counter += 1;
            number.text = counter.ToString();
            if (counter % 5 == 0 && counter % 10 != 0)
            {
                source.PlayOneShot(fiveTimes);
            }
            if (counter % 10 == 0)
            {
                source.PlayOneShot(tenTimes);
            }
            if (counter == RegularController.number)
            {
                Debug.Log("您已完成目标次数!");
            }
        }

    }
}
