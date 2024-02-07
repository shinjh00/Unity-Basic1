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
        if (instance != null)  // 인스턴스가 있으면
        {
            Debug.LogWarning("SingleTon already exist");  // 경고 띄우고
            Destroy(this);  // 지우기

            return;
        }

        instance = this;

        // 새로운 씬을 로딩할 때 이 오브젝트만큼은 지우지 않는다.??
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
