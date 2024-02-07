using UnityEngine;

public class UnityTransform : MonoBehaviour
{
    /* 트랜스폼 접근 */

    public Transform thisTransform;

    private void TransformReference()
    {
        thisTransform = transform;  // 자기 자신에 대한 트랜스폼을 적용시킴
    }


    /* 트랜스폼 이동 */

    public float moveSpeed = 3;
    public float rotateSpeed = 90;

    // Translate : 트랜스폼의 이동 함수
    private void Translate()
    {
        // position을 이용한 이동
        transform.position += new Vector3(1, 0, 0);     // Global 기준

        // Translate를 이용한 이동
        transform.Translate(1, 0, 0, Space.Self);       // Local 기준 (Default)
        transform.Translate(1, 0, 0, Space.World);      // Global 기준
        transform.Translate(1, 0, 0, Camera.main.transform);  // 다른 대상을 기준으로 이동
    }


    /* 트랜스폼 회전 */

    // Rotate : 트랜스폼의 회전 함수
    private void Rotate()
    {
        // Local 기준
        transform.Rotate(Vector3.up, 30, Space.Self);
        // Global 기준
        transform.Rotate(Vector3.up, 30, Space.World);
        // 특정 위치를 기준으로 회전
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 30);
        // 특정 위치를 바라보며 회전
        transform.LookAt(new Vector3(0, 0, 0));
    }


    /* 트랜스폼 축 */

    public Transform sphere;
    public Transform cube;

    private void Axis()
    {
        sphere.position = transform.position + 3 * Vector3.forward;  // Global 기준 3만큼 앞에 위치
        cube.position = transform.position + 3 * transform.forward;  // Local 기준 3만큼 앞에 위치

        // 트랜스폼의 x축
        Vector3 right = transform.right;
        // 트랜스폼의 y축
        Vector3 up = transform.up;
        // 트랜스폼의 z축
        Vector3 forward = transform.forward;  // 포탄 같은거 날릴 때 물체 앞을 기준으로 날리려면

        // 오브젝트의 앞방향을 오른쪽으로 수동(고정) 설정할 수 있음
        transform.forward = Vector3.right;
    }


    /* 트랜스폼 부모-자식 상태 */

    private void TransformParent()
    {
        GameObject newGameObject = new GameObject() { name = "NewGameObject" };

        // 부모 지정
        transform.parent = newGameObject.transform;

        // 부모를 기준으로 한 트랜스폼
        // transform.localPosition	: 부모트랜스폼이 있는 경우 부모를 기준으로 한 위치
        // transform.localRotation	: 부모트랜스폼이 있는 경우 부모를 기준으로 한 회전
        // transform.localScale		: 부모트랜스폼이 있는 경우 부모를 기준으로 한 크기

        // 부모 해제
        transform.parent = null;  // 다시 월드를 기준으로 하게 됨

        // (부모 해제 후 다시) 월드를 기준으로 한 트랜스폼
        // transform.localPosition == transform.position	: 부모트랜스폼이 없는 경우 월드를 기준으로 한 위치
        // transform.localRotation == transform.rotation	: 부모트랜스폼이 없는 경우 월드를 기준으로 한 회전
        // transform.localScale								: 부모트랜스폼이 없는 경우 월드를 기준으로 한 크기
    }


    /* Quarternion & Euler */

    private void Rotation()
    {
        // 트랜스폼의 회전값은 오일러각 표현이 아닌 쿼터니언을 사용함

        // 1. rotation을 쿼터니언으로 받고 오일러 각으로 변환
        Quaternion rotation = transform.rotation;
        Vector3 euler = rotation.eulerAngles;

        // 2. 오일러 각을 변경(회전)
        euler += new Vector3(10, 10, 10);

        // 3. 변경된 오일러 각을 다시 쿼터니언으로 변환
        Quaternion afterRotation = Quaternion.Euler(euler);


        // Quaternion -> EulerAngle
        //Vector3 euler = transform.rotation.eulerAngles;

        // EulerAngle -> Quaternion
        //transform.rotation = Quaternion.Euler(0, 90, 0);
    }
}
