using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressableSceneTable : ScriptableObject
{
    private List<SceneIndexData> sceneTable;

    public string GetScenePathAtIndex( int index )
    {
        if ( index < 0 || index >= sceneTable.Count ) return "";

        SceneIndexData data = sceneTable[ index ];
        return data.scenePath;
    }

    public int GetSceneIndexByName( string name )
    {
        int index = sceneTable.FindIndex( x => x.sceneName == name );
        return index;
    }

    public int GetSceneCount()
    {
        return sceneTable.Count;
    }

#if UNITY_EDITOR
    public void ClearTable()
    {
        if ( sceneTable == null )
        {
            sceneTable = new List<SceneIndexData>();
            return;
        }

        sceneTable.Clear();
    }

    public void AppendScene( string sceneName, string scenePath, string addressableKey )
    {
        if ( sceneTable == null )
        {
            sceneTable = new List<SceneIndexData>();
        }

        SceneIndexData data = new SceneIndexData( sceneName, scenePath, addressableKey );
        sceneTable.Add( data );
    }
#endif

}

[Serializable]
public class SceneIndexData
{
    public string sceneName;
    public string scenePath;
    public string addressableKey;

    public SceneIndexData( string sceneName, string scenePath, string addressableKey )
    {
        this.sceneName = sceneName;
        this.scenePath = scenePath;
        this.addressableKey = addressableKey;
    }
}