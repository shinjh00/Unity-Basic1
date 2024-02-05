using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankTurretController : MonoBehaviour
{
    public Transform turretTransform;
    public float headSpeed;

    Vector2 headDir;

    private void Update()
    {
        Rotate();
    }


    private void OnMoveTurret(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        headDir.x = inputDir.x;
        headDir.y = inputDir.y;
    }

    private void Rotate()
    {

        transform.Rotate(Vector3.up, headDir.x * headSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, headDir.y * headSpeed * Time.deltaTime, Space.Self);
    }
}
