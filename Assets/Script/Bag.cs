using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bag : MonoBehaviour, IDragHandler
{
    Transform ptransform;
    private bool is_ondrag = false;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        ptransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("MD");
            is_ondrag= true;
            offset = ptransform.position - Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            is_ondrag = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(is_ondrag) 
        {
            ptransform.position = Input.mousePosition + offset;
        }
    }
}
