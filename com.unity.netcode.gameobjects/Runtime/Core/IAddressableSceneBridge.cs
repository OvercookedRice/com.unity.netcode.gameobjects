public interface IAddressableSceneBridge
{
    public string GetScenePathAtIndex( int index );
    public int GetSceneIndexByName( string name );
    public int GetSceneIndexByPath( string path );
    public int GetSceneIndexByNameOrPath( string nameOrPath );
    public int GetSceneCount();
}
