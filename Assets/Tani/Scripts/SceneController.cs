using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneController : SingletonMonoBehavior<SceneController>
{

    Stack<string> sceneHistroy = new Stack<string>();


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// LoadScene��sceneName���̃V�[����ǂݍ���
    /// </summary>
    /// <param name="sceneName"></param>
    public void SimpleLoadScene(string sceneName)
    {
        sceneHistroy.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// LoadScene�łЂƂO�̃V�[�������[�h����
    /// </summary>
    public void SimpleLoadPreviousScene()
    {
        if(sceneHistroy.Count == 0)
        {
            Debug.LogWarning("previous scene is none");
            return;
        }
        SceneManager.LoadScene(sceneHistroy.Pop());
    }

    /// <summary>
    /// LoadScene�őJ�� + data�̎󂯓n��
    /// </summary>
    public void LoadSceneWithData<T>(string sceneName,T data)
    {
        sceneHistroy.Push(SceneManager.GetActiveScene().name);

        void SendDataToNextScene(Scene scene,LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= SendDataToNextScene;
            foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                IDataReceivable<T>[] datas
                = root.GetComponentsInChildren<IDataReceivable<T>>();
                foreach (var receivalbe in datas)
                {
                    receivalbe.Initiailize(data);
                }
            }
        }
        SceneManager.sceneLoaded += SendDataToNextScene;
        SceneManager.LoadScene(sceneName);
        
    }

    /// <summary>
    /// �J�ڎ��ɓo�^���ꂽ�֐���sceneLoaded�Ŏ��s
    /// </summary>
    public IEnumerator LoadSceneWithFuncs(string sceneName,
        IEnumerable<UnityAction<Scene, LoadSceneMode>> funcList)
    {

        sceneHistroy.Push(SceneManager.GetActiveScene().name);
        foreach (var func in funcList)
        {
            SceneManager.sceneLoaded += func;
        }

        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        yield return asyncLoad;

        foreach (var func in funcList)
        {
            SceneManager.sceneLoaded -= func;
        }
    }


    public AsyncOperation LoadSceneAsyncAndPauseMove(string sceneName)
    {
       
        var loadAsync = SceneManager.LoadSceneAsync(sceneName);
        loadAsync.allowSceneActivation = false;
        loadAsync.completed += _ => sceneHistroy.Push(sceneName);
        return loadAsync;
    }

    


    /// <summary>
    /// ��A�N�e�B�u�܂�T�^�̃R���|�[�l���g���V�[������{��
    /// </summary>
    public static T GetComponentInSceneRootObjects<T>() where T : MonoBehaviour
     {
        foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            T t = root.GetComponentInChildren<T>();
            if (t)
            {
                return t;
            }
        }
        return null;
     }
    public static IEnumerable<T> GetComponentsInSceneRootObjects<T>() where T : MonoBehaviour
    {
        foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            T t = root.GetComponentInChildren<T>();
            if (t)
            {
                yield return t;
            }
        }
        
    }

    public static Scene GetCurrentScene()
    {
        return SceneManager.GetActiveScene();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }


}

public interface IDataReceivable<Augument>
{
    public abstract void Initiailize(Augument arg);

}
