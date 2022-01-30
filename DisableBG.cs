using StorybrewCommon.Scripting;

namespace StorybrewScripts
{
    public class DisableBG : StoryboardObjectGenerator
    {
        public override void Generate() {
		    GetLayer("Disable BG").CreateSprite(Beatmap.BackgroundPath).Fade(0,0);
        }
    }
}
