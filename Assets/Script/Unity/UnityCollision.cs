using UnityEngine;

public class UnityCollision : MonoBehaviour
{
    /************************************************************************
	 * �浹ü
	 * 
	 * ������ �浹�� ���� ���ӿ�����Ʈ�� ����� ����
	 * ���ӿ�����Ʈ�� ǥ���� �޽ÿ� �Ȱ��� �ʿ�� ����
	 * �浹ü�� �浹��Ȳ�� ���� ��� ����Ƽ �浹 �޽����� �޾� ��Ȳ�� Ȯ��
	 ************************************************************************/

    /* ����Ƽ �浹 �޽��� */

    // �浹�� �������� ��
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter");
    }
    // �浹���� ��
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay");
    }
    // �浹�� Ż������ ��
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit");
    }


    /************************************************************************
	 * Ʈ���� �浹ü (��ħ)
	 * 
	 * �ϳ��� �浹ü�� �浹�� ����Ű�� �ʰ� �ٸ� �浹ü�� ������ ���� ���� ����
	 * Ʈ���Ű� ��ħ��Ȳ�� ���� ��� ����Ƽ Ʈ���� �޽����� �޾� ��Ȳ�� Ȯ��
	 ************************************************************************/

    // <����Ƽ Ʈ���� �޽���>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }

    // <���̾��� �浹 ����>
    // ���ӿ�����Ʈ�� ���̾ Ȱ���Ͽ� �浹ü���� �浹���� ���θ� ���� ����
    // edit -> ProjectSettings -> Physics ���� ���� ����

    // <�浹ü ����>
    // (1) ���� �浹ü (Static Collider)
    // Rigidbody�� ���� �浹ü, �ܺο� ���� �������� ����
    // ����� �������� �ʴ� ����, ������ҿ� �ַ� ���

    // (2) ������ٵ� �浹ü (Rigidbody Collider)
    // Rigidbody�� �ִ� �浹ü, �ܺο� ���� �޾� ������
    // �浹�� �� ������ ������ ����ϴ� ���� �� ���� ���� ���Ǵ� �浹ü�� ���

    // (3) Ű�׸�ƽ �浹ü (Kinematic Collider)
    // Kinematic : �������
    // Kinematic Rigidbody�� �ִ� �浹ü, �ܺ��� ���� �������� ����
    // ���������� �ܺ� ��ݿ��� �и��� �ʴ� ��ü(�о�� ��ֹ�, �̴��̹� ��)�� �� ���
    // kinematic ���¸� Ȱ��ȭ/��Ȱ��ȭ �Ͽ� ������ ���θ� ������ ��� ���


    // <�浹ü ��ȣ�ۿ� ��Ʈ����>
    // ���ǻ� �����浹ü(SC), ������ٵ��浹ü(RC), Ű�׸�ƽ�浹ü(KC)�� ǥ��
    // ���ǻ� ����Ʈ����(ST), ������ٵ�Ʈ����(RT), Ű�׸�ƽƮ����(KT)�� ǥ��

    // �浹�� �浹 �޽����� ����
    //		SC	RC	KC
    // SC		 O	
    // RC	 O	 O	 O
    // KC		 O	

    // �浹�� Ʈ���� �޽����� ����
    //		SC	RC	KC	ST	RT	KT
    // SC					 O	 O
    // RC				 O	 O	 O
    // KC				 O	 O	 O
    // ST		 O	 O		 O	 O
    // RT	 O	 O	 O	 O	 O	 O
    // KT	 O	 O	 O	 O	 O	 O
}
