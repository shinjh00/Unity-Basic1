using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    public Rigidbody rigid;
    public Transform headTransform;
    public Transform firePoint;
    //public GameObject bulletPrefab;
    public Bullet bulletPrefab;

    public float movePower;
    public float rotateSpeed;
    public float bulletForce;
    public float maxSpeed;

    Vector3 moveDir;
    Vector3 headDir;

    //public CinemachineVirtualCamera normalCamera;
    //public CinemachineVirtualCamera zoomCamera;

    //public Animator animator;

    // 옵저버 - 이벤트
    public UnityEvent OnFiring;
    public UnityEvent OnFired;

    private void Update()
    {
        Rotate();
        //Head();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 forceDir = transform.forward * moveDir.z;
        rigid.AddForce(forceDir * movePower, ForceMode.Force);

        if (rigid.velocity.magnitude > maxSpeed)
        {
            rigid.velocity = rigid.velocity.normalized * maxSpeed;
        }

        //transform.Translate(0, 0, moveDir.z * moveSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
        if (moveDir.z < 0)
        {
            moveDir.x *= -1;
        }
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * rotateSpeed * Time.deltaTime);
    }

    //public Rigidbody rigidBody;

    private void OnFire(InputValue value)
    {
        Fire();
    }

    private void Fire()
    {
        OnFiring.Invoke();

        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.force = bulletForce;

        //animator.SetTrigger("Fire");

        // 싱글톤
        Manager.Data.AddFireCount();    // 데이터 매니저에서
        Manager.Game.GamePause();       // 게임 매니저에서

        OnFired.Invoke();
    }

    private void Head()
    {
    }

    /*
    private void OnHead()
    {
        Vector2 inputDir = InputValue.Get<Vector2>();
        headDir.x = inputDir.x;
        headDir.y = inputDir.y;
    }


    private void OnZoom(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Zoom on");
            zoomCamera.Priority = 50;
        }
        else
        {
            Debug.Log("Zoom off");
            zoomCamera.Priority = 1;
        }
    }*/
}
