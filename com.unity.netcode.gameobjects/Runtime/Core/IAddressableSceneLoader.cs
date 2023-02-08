using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

public interface IAddressableSceneLoader
{
    public AsyncOperationHandle LoadSceneAsync( string sceneName, LoadSceneMode loadSceneMode );
    public AsyncOperationHandle UnloadSceneAsync( string sceneName, LoadSceneMode loadSceneMode );
}
