using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    [SerializeField] GameManager gameManager;
    [SerializeField] DataManager dataManager;

    public static Manager GetInstance() { return instance; }
    public static GameManager Game { get { return instance.gameManager; } }
    public static DataManager Data { get { return instance.dataManager; } }

    private void Awake()
    {
        if (instance != null)  // �ν��Ͻ��� ������
        {
            Debug.LogWarning("SingleTon already exist");  // ��� ����
            Destroy(this);  // �����

            return;
        }

        instance = this;

        // ���ο� ���� �ε��� �� �� ������Ʈ��ŭ�� ������ �ʴ´�.??
        DontDestroyOnLoad(this);
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
