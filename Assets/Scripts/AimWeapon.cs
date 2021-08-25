using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        GetMousePos();
    }


    public void GetMousePos()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 180f, -angle);
    }


}
