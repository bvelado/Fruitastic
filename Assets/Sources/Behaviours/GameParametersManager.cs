using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParametersManager : MonoBehaviour {

    private static GameParametersManager instance;
    public static GameParametersManager Instance {
        get {
            if (instance == null)
                instance = new GameObject("Game Parameters").AddComponent<GameParametersManager>();

            return instance;
        }
    }

    private GameParametersData parameters;
    public GameParametersData Parameters {
        get {
            if (parameters == null)
                parameters = Resources.Load<GameParametersData>("GameParameters");
            return parameters;
        }
    }
}
