using UnityEngine;

public class InfiniteLoop_DANGER : MonoBehaviour
{
    int x = 0;

    void Start()
    {
        Infinite();
    }

    void Infinite()
    {
        while (x < 10)
        {
            Debug.Log("Still looping!");
        }
    }
}

