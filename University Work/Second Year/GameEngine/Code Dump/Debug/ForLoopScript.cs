using UnityEngine;
using System.Collections;

public class ForLoopScript : MonoBehaviour {

    // start for loop 
    public void ExecuteLoop()
    {
        int x = 0;

        for (int i = 0; i < 10; i++)
        {
            x += i;
        }
    }

}
