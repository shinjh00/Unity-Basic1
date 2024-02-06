using System.Collections;
using UnityEngine;

public class CoolTimeCoroutine : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float jumpCoolTime;
    [SerializeField] float jumpPower;

    private bool isJumpable;

    private void Update()
    {
        if (isJumpable && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            StartCoroutine(JumpCoolTimeRoutine());
            // ���������� false ����� ��Ÿ�� ��ٷȴٰ� ������ �ٽ� true�� ������ֱ�
        }
    }

    IEnumerator JumpCoolTimeRoutine()
    {
        isJumpable = false;

        yield return new WaitForSeconds(jumpCoolTime);

        isJumpable = true;
    }
}
