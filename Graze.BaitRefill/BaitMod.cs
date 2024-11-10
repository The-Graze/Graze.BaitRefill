using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace Graze.BaitRefill;

public class BaitMod : IScriptMod {
    public bool ShouldRun(string path) => path == "res://Scenes/HUD/BaitButton/bait_showcase.gd";

    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens) {
        var waiter = new MultiTokenWaiter([

        ], allowPartialMatch: true);

        // loop through all tokens in the script
        foreach (var token in tokens) {
            if (waiter.Check(token)) {

            } else {

                yield return token;
            }
        }
    }
}
