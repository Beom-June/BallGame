using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    public float RotateSpeed;

    void Update()
    {
        // 매개변수 기준으로 회전시킴.
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime, Space.World);
    }
}
