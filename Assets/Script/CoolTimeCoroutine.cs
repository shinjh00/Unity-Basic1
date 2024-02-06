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
            // 점프했으면 false 만들고 쿨타임 기다렸다가 끝나면 다시 true로 만들어주기
        }
    }

    IEnumerator JumpCoolTimeRoutine()
    {
        isJumpable = false;

        yield return new WaitForSeconds(jumpCoolTime);

        isJumpable = true;
    }
}
