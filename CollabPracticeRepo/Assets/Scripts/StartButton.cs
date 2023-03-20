using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    public GameObject Option_1;
    public GameObject Option_2;
    public GameObject Option_3;
    public GameObject Option_4;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void startButtonClicked()
    {
        Option_1.SetActive(true);
        Option_2.SetActive(true);
        Option_3.SetActive(true);
        Option_4.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
