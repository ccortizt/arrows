using UnityEngine;
using System.Collections;

public class BombSizeController : MonoBehaviour {

    void Update()
    {
        gameObject.transform.localScale += new Vector3(0.005f,0.005f,0.005f);
    }
}
