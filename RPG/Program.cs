using System;

namespace RPG;

//Original game project was monolith in 383 lines of code.(Apr 2026)
//So i decided to rewrite project in better structure.(End of Apr-May 2026)
//I am learning c#, so code is not really well, but better than the old one
//You can check the old one in my github page. 
//https://github.com/mabex1
// Old version: https://github.com/mabex1/RPG-Monolith
// New version: https://github.com/mabex1/RPG-Refactored
// Also, game fully in russian. English version is not planned. It's just a stupid console rpg. Keep that in mind.
class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        game.Play();
    }
}
