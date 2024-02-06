using UnityEngine;

public class UnityMessageEvent : MonoBehaviour
{
    private void Awake()
    {
        // 스크립트가 씬에 포함되었을 때(존재할 때) 1회 호출
        // 스크립트 비활성화 시에도 호출

        // 역할 : 스크립트가 필요로 하는 초기화 작업 진행 (게임상황과 무관)
        // ex) 데이터 초기화, 컴포넌트 연결
        Debug.Log($"{gameObject.name} Awake");
    }

    private void OnEnable()
    {
        // 스크립트가 활성화될 때마다 호출

        // 역할 : 스크립트가 활성화 되었을 때 작업 진행
        Debug.Log($"{gameObject.name} OnEnable");
    }

    private void Start()
    {
        // 스크립트가 씬에 처음으로 Update 하기 직전에 1회 호출
        // 스크립트가 비활성화 시 호출되지 않음

        // 역할 : 스크립트가 필요로 하는 초기화 작업 진행 (게임상황에 영향)
        // ex) 몬스터의 플레이어 타겟선정
        Debug.Log($"{gameObject.name} Start");
    }

    private void FixedUpdate()
    {
        // 유니티의 물리설정 단위시간마다 호출 (기본 1초에 50번)
        // Update와 다르게 프레임당 연산과 단위시간이 일정
        // 단, 게임로직 등 연산이 많은 작업을 FixedUpdate에 구현하지 않아야 함
        // Project Settings - Time - Fixed Timestep에서 설정 가능

        // 역할 : 성능과 프레임 드랍에 영향을 받지 않아야 하는 작업
        // ex) 물리적 처리
        Debug.Log($"{gameObject.name} FixedUpdate");
    }

    private void Update()
    {
        // 게임의 프레임마다 호출

        // 역할 : 핵심 게임 로직 구현
        Debug.Log($"{gameObject.name} Update");
    }

    private void LateUpdate()
    {
        // 씬의 모든 게임오브젝트의 Update가 진행된 후 호출

        // 역할 : 게임 진행 결과가 필요한 후처리 기능 구현
        // ex) 플레이어의 위치가 결정된 후에 카메라의 위치 설정
        Debug.Log($"{gameObject.name} LateUpdate");
    }

    private void OnDisable()
    {
        // 스크립트가 비활성화될 때마다 호출

        // 역할 : 스크립트가 비활성화 되었을 때 작업 진행
        Debug.Log($"{gameObject.name} OnDisable");
    }

    private void OnDestroy()
    {
        // 스크립트가 삭제되었을 경우 호출

        // 역할 : 스크립트의 마무리 진행
        Debug.Log($"{gameObject.name} OnDestory");
    }
}
