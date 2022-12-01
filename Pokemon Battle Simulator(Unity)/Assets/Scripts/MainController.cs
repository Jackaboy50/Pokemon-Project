using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public class MainController : MonoBehaviour
{
    [SerializeField] private Canvas StartCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(StartCanvas, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject.Find("StartCanvas(Clone)").name = "StartCanvas";
    }
}
