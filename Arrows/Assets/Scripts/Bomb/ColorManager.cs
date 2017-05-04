using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour {

    private Material mat;
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        //LightIncrementRate = 100;
    }

    void Update()
    {
        mat.color += Color.red / 1f * Time.deltaTime;

    }
}
