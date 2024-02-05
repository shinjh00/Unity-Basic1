using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rigidbody rigid;

    public float movePower;
    public float jumpPower;

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // GetKey : �ش� Ű�� ������ ���� true�� �ݺ������� ��ȯ
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(Vector3.forward * movePower);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector3.back * movePower);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector3.left * movePower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector3.right * movePower);
        }
    }

    void Jump()
    {
        // GetKeyDown : �ش� Ű�� ������ �� �� �� true�� ��ȯ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpPower);
        }
    }

}
