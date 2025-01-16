using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;



public class TouchDetect : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{

    public CinemachineFreeLook free_camera;
    Vector2 screen;
    public float rotate_speed;
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"{screen.x-eventData.position.x}");
        free_camera.m_XAxis.Value += (screen.x - eventData.position.x)*rotate_speed;
        screen = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"{eventData.position}");
        screen = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        free_camera = FindObjectOfType<CinemachineFreeLook>();
    }


   

   
}
