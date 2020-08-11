using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class click : MonoBehaviour/*, IPointerDownHandler*/
{
    //private void OnMouseDown()
    //{
    //    Debug.Log("오브젝트 누럿다");
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("오브젝트 눌렀다");
    //}
    public void OnPointerDownEvent(BaseEventData eventData)
    {
        Debug.Log("오브젝트 눌렀다");
    }
}
