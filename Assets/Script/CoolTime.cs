using UnityEngine;

public class CoolTime : MonoBehaviour
{
    [SerializeField] Rigidbody rigid;
    [SerializeField] float jumpCoolTime;
    [SerializeField] float jumpPower;

    private void Update()
    {
        jumpCoolTime += Time.deltaTime;

        if (jumpCoolTime >= 3f && Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            // ForceMode.Force : Áö±×½Ã ¹Ì´Â Èû
            // ForceMode.Force : ÇÑ ¹ø Åö Ä¡´Â Èû

            jumpCoolTime = 0f;
        }
    }
}
