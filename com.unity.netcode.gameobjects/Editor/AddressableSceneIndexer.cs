
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEngine.SceneManagement;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;


public static class AddressableSceneIndexer
{
    private static readonly string IndexTablePath = "Assets/Game/Data";

	[MenuItem("Game Scripts/Addressables/Build Addressable Scene Indexer")]
    private static void BuildSceneIndexer()
    {
        var settings = AddressableAssetSettingsDefaultObject.Settings;
        
        int lastSlashIdx = IndexTablePath.LastIndexOf( "/" );
        string indexTableParentFolder = IndexTablePath.Substring( 0, lastSlashIdx );
        string indexTableFolder = IndexTablePath.Substring( lastSlashIdx + 1 );

        if ( Directory.Exists( IndexTablePath ) == false )
        {
            AssetDatabase.CreateFolder( indexTableParentFolder, indexTableFolder );
        }

        string tablePath = IndexTablePath + "/SceneIndexTable.asset";

        AddressableSceneTable table = AssetDatabase.LoadAssetAtPath<AddressableSceneTable>( tablePath );
        if ( table == null )
        {
            table = ScriptableObject.CreateInstance<AddressableSceneTable>();
            AssetDatabase.CreateAsset( table, tablePath );
        }

        table.ClearTable();

        AddressableAssetGroup defaultGroup = settings.DefaultGroup;

        List<AddressableAssetEntry> sceneEntries = new List<AddressableAssetEntry>();
        defaultGroup.GatherAllAssets( sceneEntries, includeSelf: true, recurseAll: true, includeSubObjects: false, IsSceneAddressable );

        foreach ( var sceneEntry in sceneEntries )
        {
            SceneAsset sceneData = sceneEntry.MainAsset as SceneAsset;

            string sceneName = sceneData.name;
            string scenePath = sceneEntry.AssetPath;
            string addressableKey = sceneEntry.address;

            table.AppendScene( sceneName, scenePath, addressableKey );
        }
    }

    private static bool IsSceneAddressable( AddressableAssetEntry entry )
    {
        return entry.IsScene;
    }
}
