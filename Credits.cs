using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Subtitles;
using System;

using static StorybrewCommon.Assets;

namespace StorybrewScripts
{
    public class Credits : StoryboardObjectGenerator
    {
        public override void Generate() {
		    var font = LoadFont(FOLDER_ETC, new FontDescription() {
                FontPath = "Bahnschrift",
                FontSize = 20,
                Color    = Color4.White
            });

            Action<string, bool> drawText = (text, gd) => {
                var t = (gd ? GetLayer(LAYER_CREDIT2) : GetLayer(LAYER_CREDIT))
                    .CreateSprite(font.GetTexture(text).Path, OsbOrigin.Centre, new Vector2(320, gd ? 370 : 350));
                t.Scale(271317 + OFFSET, .5);
                t.Fade(271317, 272191, 0, 1);
                t.Fade(275394, 277142, 1, 0);
            };

            drawText("Mapset and Storyboard by Apis035", false);

            switch (Beatmap.Name) {
                case "AF's Hard":           drawText("Guest Difficulty by Affirmation", true); break;
                case "Hakku's Insane":      drawText("Guest Difficulty by Hakku", true);       break;
                case "Kaguya_Sama's Extra": drawText("Guest Difficulty by Kaguya_Sama", true); break;
            }

            var ba = GetLayer(LAYER_CREDIT).CreateSprite(LOGO_BA);
            ba.Scale(OsbEasing.Out, 271317, 277142, .4, .5);
            ba.Fade(271317, 272191, 0, 1);
            ba.Fade(275394, 277142, 1, 0);
        }
    }
}
