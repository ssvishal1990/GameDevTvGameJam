using System.Collections;
using UnityEngine;

namespace gameDevTvGameJam
{
    // This clase will extend character class
    // Later on all classes will be extending this

    // 4 abilities to create first :: 1) floaty movement 2) 8 directional aiming 3) grappling hook 4)Dash
    public class Abilities : Character
    {
        Character character;

        protected override void initialization()
        {
            base.initialization();
            character = GetComponent<Character>();
        }
    }
}