using System.Collections;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
    IEnumerator SubRoutine()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("�ڷ�ƾ 1��");
        }
    }


    /* �ڷ�ƾ ���� */
    // �ݺ������� �۾��� StartCorouine�� ���� ����
    private Coroutine routine;
    private void CoroutineStart()
    {
        routine = StartCoroutine(SubRoutine());
    }


    /* �ڷ�ƾ ���� */
    // StopCoroutine�� ���� ���� ���� �ڷ�ƾ ����
    // StopAllCoroutine�� ���� ���� ���� ��� �ڷ�ƾ ����
    // �ݺ������� �۾��� ��� �Ϸ�Ǿ��� ��� �ڵ� ����
    // �ڷ�ƾ�� �����Ų ��ũ��Ʈ�� ��Ȱ��ȭ�� ��� �ڵ� ����
    private void CoroutineStop()
    {
        StopCoroutine(routine);     // ������ �ڷ�ƾ ����
        StopAllCoroutines();        // ��� �ڷ�ƾ ����

        // StopCoroutine(SubRoutine());  - �̷��� ���°� �ƴ�!!
        // ��ƾ�� ���ߴ°��� �����ƾ �Լ��� ���ߴ°� �ƴ�
    }


    /* �ڷ�ƾ �ð� ���� */
    // �ڷ�ƾ�� �ð� ������ �����Ͽ� �ݺ������� �۾��� ���� Ÿ�̹��� ������ �� ����
    IEnumerator CoroutineWait()
    {
        yield return new WaitForSeconds(1);     // n�ʰ� �ð�����
        yield return null;                      // �ð����� ����

        yield return new WaitForEndOfFrame();   // ������ ���������� ����
        yield return new WaitForFixedUpdate();  // FixedUpdate ���������� ����
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));  // ��ȣ���� ������ true�϶����� ���� (Ű ���������� ����)
    }
}
