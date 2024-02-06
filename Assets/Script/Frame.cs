using UnityEngine;

public class Frame : MonoBehaviour
{
    [SerializeField] Transform transform;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        Application.targetFrameRate = 60;
        //Application.targetFrameRate = 10;
        // 고정 프레임 설정으로 테스트
        // 1초에 1프레임 1Update 수행되기 때문에 컴퓨터 성능(프레임)에 따라 속도, 이동거리가 달라질 수 있음
        // 이를 방지하기 위해 사용하는 것이 단위시간(DeltaTime)
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            //pos.x -= moveSpeed;  // 이렇게 하면 프레임에 따라 출력이 달라짐
            pos.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //pos.x += moveSpeed;
            pos.x += moveSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
