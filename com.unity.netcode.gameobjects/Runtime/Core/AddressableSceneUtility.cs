using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
    public static class AddressableSceneUtility
    {
        private static List<SceneData> sceneDataList;

#region Initializing Data
        private class SceneData
        {
            public string sceneName;
            public string scenePath;

            public SceneData( string sceneName, string scenePath )
            {
                this.sceneName = sceneName;
                this.scenePath = scenePath;
            }
        }

        public static void InitializeSceneDataList()
        {
            if ( sceneDataList == null )
            {
                sceneDataList = new List<SceneData>();
            }

            sceneDataList.Clear();
        }

        public static void AppendData( string sceneName, string scenePath )
        {
            sceneDataList.Add( new SceneData( sceneName, scenePath ) );
        }

#endregion

        public static int GetIndexBySceneName( string name )
        {
            return sceneDataList.FindIndex( x => x.sceneName == name );
        }

        public static int GetIndexByScenePath( string path )
        {
            return sceneDataList.FindIndex( x => x.scenePath == path );
        }

        public static int GetIndexBySceneNameOrPath( string nameOrPath )
        {
            return sceneDataList.FindIndex( x => x.sceneName == nameOrPath || x.scenePath == nameOrPath );
        }

        public static string GetPathByIndex( int index )
        {
            if ( index < 0 || index >= sceneDataList.Count ) return "";
            return sceneDataList[ index ].scenePath;
        }

        public static int GetAddressableSceneCount()
        {
            return sceneDataList.Count;
        }
    }
}
