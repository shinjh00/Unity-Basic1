using UnityEngine;

public class PracticeFrame : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;

    [SerializeField] float movePower;
    [SerializeField] float jumpCoolTime;
    [SerializeField] float jumpPower;

    private void Update()
    {
        // WSAD�� ������ (transform �̿�)

        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.z += movePower * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.z -= movePower * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= movePower * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += movePower * Time.deltaTime;
        }

        transform.position = pos;


        // Space�� ���� & ���� ��Ÿ��

        jumpCoolTime += Time.deltaTime;

        if (jumpCoolTime >= 2f && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpCoolTime = 0f;
        }
    }
}
