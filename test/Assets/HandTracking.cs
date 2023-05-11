using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    public GameObject[] cubes;
    private Color color1 = new Color(255f/255f, 0f/255f, 0f/255f);
    private Color color2 = new Color(0f/255f, 0f/255f, 255f/255f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        string[] points = data.Split(',');

        for(int i = 0; i<21; i++){
            //(x1),y1,z1,(x2),y2,z2.....
            float x = 8-float.Parse(points[i*3]) / 100;
            float y = float.Parse(points[i*3+1]) / 100 - 3;
            float z = float.Parse(points[i*3+2]) / 100;
            
            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }

        if(float.Parse(points[13]) < float.Parse(points[16])){
            cubes[0].GetComponent<Renderer>().material.color = color2;
        }else{
            cubes[0].GetComponent<Renderer>().material.color = color1;
        }
        if(float.Parse(points[25]) < float.Parse(points[22])){
            cubes[1].GetComponent<Renderer>().material.color = color2;
        }else{
            cubes[1].GetComponent<Renderer>().material.color = color1;
        }
        if(float.Parse(points[37]) < float.Parse(points[34])){
            cubes[2].GetComponent<Renderer>().material.color = color2;
        }else{
            cubes[2].GetComponent<Renderer>().material.color = color1;
        }
        if(float.Parse(points[49]) < float.Parse(points[46])){
            cubes[3].GetComponent<Renderer>().material.color = color2;
        }else{
            cubes[3].GetComponent<Renderer>().material.color = color1;
        }
        if(float.Parse(points[61]) < float.Parse(points[58])){
            cubes[4].GetComponent<Renderer>().material.color = color2;
        }else{
            cubes[4].GetComponent<Renderer>().material.color = color1;
        }
    }
}
