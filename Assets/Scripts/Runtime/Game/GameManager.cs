using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peebo.Runtime.Game
{
    /// <summary>
    /// Game states to manage:
    /// - Explore mode: player clicks around environment to find tasks / minigames
    /// - Minigame mode: goal is to complete minigame before returning to explore mode
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

    public abstract class GameState
    {
        public virtual IEnumerator Start()
        {
            yield break;
        }
    }
}
