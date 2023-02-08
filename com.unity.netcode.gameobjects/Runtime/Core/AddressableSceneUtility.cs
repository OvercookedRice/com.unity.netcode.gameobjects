using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

public static partial class AddressableSceneUtility
{
    private static IAddressableSceneBridge addressableBridge;
    private static IAddressableSceneLoader sceneLoaderBridge;

    static partial void RetrieveSceneIndexTable();
    static partial void CreateSceneLoaderBridge();

    public static int GetIndexBySceneName( string name )
    {
        if ( addressableBridge == null )
        {
            RetrieveSceneIndexTable();
        }

        if ( addressableBridge == null )
        {
            Debug.LogWarning( "Warning: Cannot find any Addressable Scene Bridge!" );
            return -1;
        }

        return addressableBridge.GetSceneIndexByName( name );
    }

    public static int GetIndexByScenePath( string path )
    {
        if ( addressableBridge == null )
        {
            RetrieveSceneIndexTable();
        }

        if ( addressableBridge == null )
        {
            Debug.LogWarning( "Warning: Cannot find any Addressable Scene Bridge!" );
            return -1;
        }

        return addressableBridge.GetSceneIndexByPath( name );
    }

    public static int GetIndexBySceneNameOrPath( string nameOrPath )
    {
        if ( addressableBridge == null )
        {
            RetrieveSceneIndexTable();
        }

        if ( addressableBridge == null )
        {
            Debug.LogWarning( "Warning: Cannot find any Addressable Scene Bridge!" );
            return -1;
        }

        return addressableBridge.GetSceneIndexByNameOrPath( nameOrPath );
    }

    public static string GetPathByIndex( int index )
    {
        if ( addressableBridge == null )
        {
            RetrieveSceneIndexTable();
        }

        if ( addressableBridge == null )
        {
            Debug.LogWarning( "Warning: Cannot find any Addressable Scene Bridge!" );
            return "";
        }

        return addressableBridge.GetScenePathAtIndex( index );
    }

    public static int GetAddressableSceneCount()
    {
        if ( addressableBridge == null )
        {
            RetrieveSceneIndexTable();
        }

        if ( addressableBridge == null )
        {
            Debug.LogWarning( "Warning: Cannot find any Addressable Scene Bridge!" );
            return 0;
        }

        return addressableBridge.GetSceneCount();
    }

    public static AsyncOperationHandle LoadSceneAsync( string sceneName, LoadSceneMode loadSceneMode )
    {
        if ( sceneLoaderBridge == null )
        {
            CreateSceneLoaderBridge();
        }

        return sceneLoaderBridge.LoadSceneAsync( sceneName, loadSceneMode );
    }

    public static AsyncOperationHandle UnloadSceneAsync( string sceneName, LoadSceneMode loadSceneMode )
    {
        if ( sceneLoaderBridge == null )
        {
            CreateSceneLoaderBridge();
        }

        return sceneLoaderBridge.UnloadSceneAsync( sceneName, loadSceneMode );
    }
}
