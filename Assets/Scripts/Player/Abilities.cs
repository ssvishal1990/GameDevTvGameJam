using System.Collections;
using UnityEngine;

namespace gameDevTvGameJam
{
    // This clase will extend character class
    // Later on all classes will be extending this

    // 4 abilities to create first ::
    //0) Grid based camera similar to puzzle game
    //1) floaty movement 
    //2) 8 directional aiming
    //4) Dash
    //5) zip line
    //6) Possible use of tilemap ?

    public class Abilities : Character
    {
        protected Character character;

        protected override void initialization()
        {
            base.initialization();
            character = GetComponent<Character>();
        }
    }
}