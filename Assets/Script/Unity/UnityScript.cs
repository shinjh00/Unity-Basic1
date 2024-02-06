using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityScript : MonoBehaviour
{
    // <스크립트 직렬화 기능>
    // 인스펙터 창에서 컴포넌트의 맴버변수 값을 확인하거나 변경하는 기능
    // 컴포넌트의 값형식 데이터를 확인하거나 변경
    // 컴포넌트의 참조형식 데이터를 드래그 앤 드랍 방식으로 연결

    /* 인스펙터창 직렬화가 가능한 자료형 */

    [Header("C# Type")]
    public bool boolValue;
    public int intValue;
    public float floatValue;
    public string stringValue;
    // 그 외 기본 자료형

    // 기본 자료형의 선형자료구조
    public int[] array;
    public List<int> list;

    [Header("Unity Type")]
    public Vector3 vector3;
    public Vector3Int vector3Int;
    public Color color;
    public LayerMask layerMask;
    public AnimationCurve curve;
    public Gradient gradient;

    [Header("Unity GameObject")]
    public GameObject GameObj;

    [Header("Unity Component")]
    public new Transform transform;
    public new Rigidbody rigidbody;
    public new Collider collider;

    [Header("Unity Event")]
    public UnityEvent<int> OnEvent;


    // <Attribute>
    // 클래스, 프로퍼티 또는 함수 위에 명시하여 특별한 동작을 나타낼 수 있는 마커
    // 소스 상의 영향 X, Inspector창에서 제목처럼 나타나 기능을 명시해주는 역할

    [Space(100)]  // 간격

    [Header("Unity Attribute")]

    [SerializeField]  // private 변수이지만 에디터에서 보이게
    private int privateValue;
    [HideInInspector]  // public 변수이지만 에디터에서 보이지 않게
    public int publicValue;

    [Range(0, 10)]  // 최소값, 최대값 설정
    public float rangeValue;

    [TextArea(3, 5)]  // 최소라인, 최대라인 설정
    public string textField;
}
