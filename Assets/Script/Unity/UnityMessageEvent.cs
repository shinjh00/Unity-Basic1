using UnityEngine;

public class UnityMessageEvent : MonoBehaviour
{
    private void Awake()
    {
        // ��ũ��Ʈ�� ���� ���ԵǾ��� ��(������ ��) 1ȸ ȣ��
        // ��ũ��Ʈ ��Ȱ��ȭ �ÿ��� ȣ��

        // ���� : ��ũ��Ʈ�� �ʿ�� �ϴ� �ʱ�ȭ �۾� ���� (���ӻ�Ȳ�� ����)
        // ex) ������ �ʱ�ȭ, ������Ʈ ����
        Debug.Log($"{gameObject.name} Awake");
    }

    private void OnEnable()
    {
        // ��ũ��Ʈ�� Ȱ��ȭ�� ������ ȣ��

        // ���� : ��ũ��Ʈ�� Ȱ��ȭ �Ǿ��� �� �۾� ����
        Debug.Log($"{gameObject.name} OnEnable");
    }

    private void Start()
    {
        // ��ũ��Ʈ�� ���� ó������ Update �ϱ� ������ 1ȸ ȣ��
        // ��ũ��Ʈ�� ��Ȱ��ȭ �� ȣ����� ����

        // ���� : ��ũ��Ʈ�� �ʿ�� �ϴ� �ʱ�ȭ �۾� ���� (���ӻ�Ȳ�� ����)
        // ex) ������ �÷��̾� Ÿ�ټ���
        Debug.Log($"{gameObject.name} Start");
    }

    private void FixedUpdate()
    {
        // ����Ƽ�� �������� �����ð����� ȣ�� (�⺻ 1�ʿ� 50��)
        // Update�� �ٸ��� �����Ӵ� ����� �����ð��� ����
        // ��, ���ӷ��� �� ������ ���� �۾��� FixedUpdate�� �������� �ʾƾ� ��
        // Project Settings - Time - Fixed Timestep���� ���� ����

        // ���� : ���ɰ� ������ ����� ������ ���� �ʾƾ� �ϴ� �۾�
        // ex) ������ ó��
        Debug.Log($"{gameObject.name} FixedUpdate");
    }

    private void Update()
    {
        // ������ �����Ӹ��� ȣ��

        // ���� : �ٽ� ���� ���� ����
        Debug.Log($"{gameObject.name} Update");
    }

    private void LateUpdate()
    {
        // ���� ��� ���ӿ�����Ʈ�� Update�� ����� �� ȣ��

        // ���� : ���� ���� ����� �ʿ��� ��ó�� ��� ����
        // ex) �÷��̾��� ��ġ�� ������ �Ŀ� ī�޶��� ��ġ ����
        Debug.Log($"{gameObject.name} LateUpdate");
    }

    private void OnDisable()
    {
        // ��ũ��Ʈ�� ��Ȱ��ȭ�� ������ ȣ��

        // ���� : ��ũ��Ʈ�� ��Ȱ��ȭ �Ǿ��� �� �۾� ����
        Debug.Log($"{gameObject.name} OnDisable");
    }

    private void OnDestroy()
    {
        // ��ũ��Ʈ�� �����Ǿ��� ��� ȣ��

        // ���� : ��ũ��Ʈ�� ������ ����
        Debug.Log($"{gameObject.name} OnDestory");
    }
}
