using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CharacterController2D characterController2D;
    public Vector2 offset;
    public float angle;
    private void Awake()
    {
        mainCamera = Camera.main;
        characterController2D = GetComponentInParent<CharacterController2D>();
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

        offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

       angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 180f, -angle);

        
        if (angle > 90 || angle < -90)
        {
            transform.localRotation = Quaternion.Euler(180, 180, angle);
            characterController2D.FlipRight();
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 180, -angle);
            characterController2D.FlipLeft();
        }

        
    }

    




}
