using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        Debug.Log("I'm single. - " + gameObject.name);
    }
}
