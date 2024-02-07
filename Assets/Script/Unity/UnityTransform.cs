using UnityEngine;

public class UnityTransform : MonoBehaviour
{
    /* Ʈ������ ���� */

    public Transform thisTransform;

    private void TransformReference()
    {
        thisTransform = transform;  // �ڱ� �ڽſ� ���� Ʈ�������� �����Ŵ
    }


    /* Ʈ������ �̵� */

    public float moveSpeed = 3;
    public float rotateSpeed = 90;

    // Translate : Ʈ�������� �̵� �Լ�
    private void Translate()
    {
        // position�� �̿��� �̵�
        transform.position += new Vector3(1, 0, 0);     // Global ����

        // Translate�� �̿��� �̵�
        transform.Translate(1, 0, 0, Space.Self);       // Local ���� (Default)
        transform.Translate(1, 0, 0, Space.World);      // Global ����
        transform.Translate(1, 0, 0, Camera.main.transform);  // �ٸ� ����� �������� �̵�
    }


    /* Ʈ������ ȸ�� */

    // Rotate : Ʈ�������� ȸ�� �Լ�
    private void Rotate()
    {
        // Local ����
        transform.Rotate(Vector3.up, 30, Space.Self);
        // Global ����
        transform.Rotate(Vector3.up, 30, Space.World);
        // Ư�� ��ġ�� �������� ȸ��
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 30);
        // Ư�� ��ġ�� �ٶ󺸸� ȸ��
        transform.LookAt(new Vector3(0, 0, 0));
    }


    /* Ʈ������ �� */

    public Transform sphere;
    public Transform cube;

    private void Axis()
    {
        sphere.position = transform.position + 3 * Vector3.forward;  // Global ���� 3��ŭ �տ� ��ġ
        cube.position = transform.position + 3 * transform.forward;  // Local ���� 3��ŭ �տ� ��ġ

        // Ʈ�������� x��
        Vector3 right = transform.right;
        // Ʈ�������� y��
        Vector3 up = transform.up;
        // Ʈ�������� z��
        Vector3 forward = transform.forward;  // ��ź ������ ���� �� ��ü ���� �������� ��������

        // ������Ʈ�� �չ����� ���������� ����(����) ������ �� ����
        transform.forward = Vector3.right;
    }


    /* Ʈ������ �θ�-�ڽ� ���� */

    private void TransformParent()
    {
        GameObject newGameObject = new GameObject() { name = "NewGameObject" };

        // �θ� ����
        transform.parent = newGameObject.transform;

        // �θ� �������� �� Ʈ������
        // transform.localPosition	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ��ġ
        // transform.localRotation	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ȸ��
        // transform.localScale		: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ũ��

        // �θ� ����
        transform.parent = null;  // �ٽ� ���带 �������� �ϰ� ��

        // (�θ� ���� �� �ٽ�) ���带 �������� �� Ʈ������
        // transform.localPosition == transform.position	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ��ġ
        // transform.localRotation == transform.rotation	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ȸ��
        // transform.localScale								: �θ�Ʈ�������� ���� ��� ���带 �������� �� ũ��
    }


    /* Quarternion & Euler */

    private void Rotation()
    {
        // Ʈ�������� ȸ������ ���Ϸ��� ǥ���� �ƴ� ���ʹϾ��� �����

        // 1. rotation�� ���ʹϾ����� �ް� ���Ϸ� ������ ��ȯ
        Quaternion rotation = transform.rotation;
        Vector3 euler = rotation.eulerAngles;

        // 2. ���Ϸ� ���� ����(ȸ��)
        euler += new Vector3(10, 10, 10);

        // 3. ����� ���Ϸ� ���� �ٽ� ���ʹϾ����� ��ȯ
        Quaternion afterRotation = Quaternion.Euler(euler);


        // Quaternion -> EulerAngle
        //Vector3 euler = transform.rotation.eulerAngles;

        // EulerAngle -> Quaternion
        //transform.rotation = Quaternion.Euler(0, 90, 0);
    }
}
