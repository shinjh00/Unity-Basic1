using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTransform : MonoBehaviour
{
    /************************************************************************
	 * 트랜스폼 (Transform)
	 * 
	 * 게임오브젝트의 위치, 회전, 크기를 저장하는 컴포넌트
	 * 게임오브젝트의 부모-자식 상태를 저장하는 컴포넌트
	 * 게임오브젝트는 반드시 하나의 트랜스폼 컴포넌트를 가지고 있으며 추가 & 제거할 수 없음
	 ************************************************************************/

    /* 트랜스폼 접근 */

    public Transform thisTransform;

    private void TransformReference()
    {
        thisTransform = transform;  // 자기 자신에 대한 트랜스폼을 이동시켜 주고 싶다 할 때
    }


    /* 트랜스폼 이동 */

    float moveSpeed = 3;
    float rotateSpeed = 90;

    // Translate : 트랜스폼의 이동 함수
    private void Translate()
    {
        // position을 이용한 이동
        transform.position += new Vector3(1, 0, 0);     // Global 기준

        // Translate를 이용한 이동
        transform.Translate(1, 0, 0, Space.Self);       // Local 기준 (Default)
        transform.Translate(1, 0, 0, Space.World);      // Global 기준
        transform.Translate(1, 0, 0, Camera.main.transform);  // 다른 대상을 기준으로 이동

        // 백터를 이용한 이동
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // x,y,z를 이용한 이동
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }


    /* 트랜스폼 회전 */

    // Rotate : 트랜스폼의 회전 함수
    private void Rotate()
    {
        // Global 기준
        transform.Rotate(Vector3.up, 30, Space.World);
        // Local 기준
        transform.Rotate(Vector3.up, 30, Space.Self);
        // 특정 위치를 기준으로 회전
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 30);
        // 특정 위치를 바라보며 회전
        transform.LookAt(new Vector3(0, 0, 0));

        // 축을 이용한 회전 (축을 기준으로 시계방향으로 회전)
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        // 오일러를 이용한 회전
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        // x,y,z를 이용한 회전
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }


    /* 트랜스폼 축 */

    public Transform sphere;
    public Transform cube;

    private void Axis()
    {
        sphere.position = transform.position + 3 * Vector3.forward;  // Global 기준 3만큼 앞에
        cube.position = transform.position + 3 * transform.forward;  // 

        // 트랜스폼의 x축
        Vector3 right = transform.right;
        // 트랜스폼의 y축
        Vector3 up = transform.up;
        // 트랜스폼의 z축
        Vector3 forward = transform.forward;  // 포탄 같은거 날릴 때 물체 앞을 기준으로 날리려면

        // 앞방향을 오른쪽으로 수동(고정) 설정할 수 있음
        transform.forward = Vector3.right;
    }


    /* 트랜스폼 부모-자식 상태 */

    // 트랜스폼은 부모 트랜스폼을 가질 수 있음
    // 부모 트랜스폼이 있는 경우 부모 트랜스폼의 위치, 회전, 크기 변경이 같이 적용됨
    // 이를 이용하여 계층적 구조를 정의하는데 유용함 (ex. 팔이 이동하면, 손가락도 같이 이동함)
    // 하이어라키 창 상에서 드래그 & 드롭을 통해 부모-자식 상태를 변경할 수 있음
    // 자식의 위치는 월드 기준이 아니라 부모를 기준으로 함 ( 부모: (1, 1) / 자식: (2, 2) 일 때 자식은 월드 기준으로는 (3, 3)임 )
    private void TransformParent()
    {
        GameObject newGameObject = new GameObject() { name = "NewGameObject" };

        // 부모 지정
        transform.parent = newGameObject.transform;

        // 부모를 기준으로한 트랜스폼
        // transform.localPosition	: 부모트랜스폼이 있는 경우 부모를 기준으로 한 위치
        // transform.localRotation	: 부모트랜스폼이 있는 경우 부모를 기준으로 한 회전
        // transform.localScale		: 부모트랜스폼이 있는 경우 부모를 기준으로 한 크기

        // 부모 해제
        transform.parent = null;  // 다시 월드를 기준으로 하게 됨

        // (부모 해제 후 다시) 월드를 기준으로한 트랜스폼
        // transform.localPosition == transform.position	: 부모트랜스폼이 없는 경우 월드를 기준으로 한 위치
        // transform.localRotation == transform.rotation	: 부모트랜스폼이 없는 경우 월드를 기준으로 한 회전
        // transform.localScale								: 부모트랜스폼이 없는 경우 월드를 기준으로 한 크기
    }


    /* Quarternion & Euler */

    // 오일러 각 (EulerAngle) : 1. (X, Y, Z) 세 개의 축을 기준으로 회전하기에 직관적이고 조작이 쉬움
    //                         2. 오일러 각을 계산하는데 드는 비용이 큼
    //                         3. 짐벌락 현상이 발생하여 회전이 겹치는 축이 생길 수 있음
    // 쿼터니언 (Quaternion) : 1. (X, Y, Z, W) 네 개의 수로 이루어지며 하나의 벡터(x, y, z)와 하나의 스칼라(w, roll)를 의미
    //                        2. 각 성분에 직접 접근 및 수정을 하지 않음
    //                        3. 세 축을 동시에 회전시키기에 짐벌락 현상이 발생하지 않음
    //                        4. 벡터가 위치(position)+방향(direction) 이듯이, 쿼터니언은 방향(orientation)+회전(rotation) 임
    // 짐벌락 (Gimbal Lock) : 같은 방향으로 오브젝트의 두 회전 축이 겹치는 현상

    // 보통의 경우 쿼터니언 -> 오일러각도 -> 연산진행 -> 결과오일러각도 -> 결과쿼터니언 과 같이 연산의 결과 쿼터니언을 사용함
    private void Rotation()
    {
        // 트랜스폼의 회전값
        // EulerAngle -> Quaternion
        transform.rotation = Quaternion.identity;

        // Quaternion -> EulerAngle
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

}
