using System.Collections;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
    IEnumerator SubRoutine()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("코루틴 1초");
        }
    }


    /* 코루틴 진행 */
    // 반복가능한 작업을 StartCorouine을 통해 실행
    private Coroutine routine;
    private void CoroutineStart()
    {
        routine = StartCoroutine(SubRoutine());
    }


    /* 코루틴 종료 */
    // StopCoroutine을 통해 진행 중인 코루틴 종료
    // StopAllCoroutine을 통해 진행 중인 모든 코루틴 종료
    // 반복가능한 작업이 모두 완료되었을 경우 자동 종료
    // 코루틴을 진행시킨 스크립트가 비활성화된 경우 자동 종료
    private void CoroutineStop()
    {
        StopCoroutine(routine);     // 지정한 코루틴 종료
        StopAllCoroutines();        // 모든 코루틴 종료

        // StopCoroutine(SubRoutine());  - 이렇게 쓰는거 아님!!
        // 루틴을 멈추는거지 서브루틴 함수를 멈추는게 아님
    }


    /* 코루틴 시간 지연 */
    // 코루틴은 시간 지연을 정의하여 반복가능한 작업의 진행 타이밍을 지정할 수 있음
    IEnumerator CoroutineWait()
    {
        yield return new WaitForSeconds(1);     // n초간 시간지연
        yield return null;                      // 시간지연 없음

        yield return new WaitForEndOfFrame();   // 프레임 끝날때까지 지연
        yield return new WaitForFixedUpdate();  // FixedUpdate 끝날때까지 지연
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));  // 괄호안의 내용이 true일때까지 지연 (키 누를때까지 지연)
    }
}
