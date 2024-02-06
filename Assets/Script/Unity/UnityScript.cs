using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityScript : MonoBehaviour
{
    // <��ũ��Ʈ ����ȭ ���>
    // �ν����� â���� ������Ʈ�� �ɹ����� ���� Ȯ���ϰų� �����ϴ� ���
    // ������Ʈ�� ������ �����͸� Ȯ���ϰų� ����
    // ������Ʈ�� �������� �����͸� �巡�� �� ��� ������� ����

    /* �ν�����â ����ȭ�� ������ �ڷ��� */

    [Header("C# Type")]
    public bool boolValue;
    public int intValue;
    public float floatValue;
    public string stringValue;
    // �� �� �⺻ �ڷ���

    // �⺻ �ڷ����� �����ڷᱸ��
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
    // Ŭ����, ������Ƽ �Ǵ� �Լ� ���� ����Ͽ� Ư���� ������ ��Ÿ�� �� �ִ� ��Ŀ
    // �ҽ� ���� ���� X, Inspectorâ���� ����ó�� ��Ÿ�� ����� ������ִ� ����

    [Space(100)]  // ����

    [Header("Unity Attribute")]

    [SerializeField]  // private ���������� �����Ϳ��� ���̰�
    private int privateValue;
    [HideInInspector]  // public ���������� �����Ϳ��� ������ �ʰ�
    public int publicValue;

    [Range(0, 10)]  // �ּҰ�, �ִ밪 ����
    public float rangeValue;

    [TextArea(3, 5)]  // �ּҶ���, �ִ���� ����
    public string textField;
}
