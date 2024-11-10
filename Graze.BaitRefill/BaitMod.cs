using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;

namespace Graze.BaitRefill;

public class BaitMod : IScriptMod {
    public bool ShouldRun(string path) => path == "res://Scenes/HUD/BaitButton/bait_showcase.gd";

    string selectedBait;

    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens) {
        var waiter = new MultiTokenWaiter([
            t => t is IdentifierToken {Name: "bait_selected"}
        ], allowPartialMatch: true);

        // loop through all tokens in the script
        foreach (var token in tokens) {
            if (waiter.Check(token)) {
                yield return token;
                if (token.AssociatedData.HasValue)
                {
                    selectedBait = token.AssociatedData.Value.ToString();
                }
            } else {

                yield return token;
            }
        }
    }
}
