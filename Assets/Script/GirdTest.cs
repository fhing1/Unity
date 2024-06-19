using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirdTest : MonoBehaviour
{
    Gird gird;
    // Start is called before the first frame update
    void Start()
    {
        gird = new Gird(10, 5, 10);
        gird.ShowGird();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Vector3 mouseposit = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(gird.getValue(mouseposit) == 1)
            {
                gird.setValue(mouseposit, 0);
            }
            else if(gird.getValue(mouseposit)!= -1)
            {
                gird.setValue(mouseposit, 1);
            }   
        }
    }
}
