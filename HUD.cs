using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System;

using static StorybrewCommon.Assets;

namespace StorybrewScripts
{
    public class HUD : StoryboardObjectGenerator
    {
        StoryboardLayer l;
        OsbSprite Disc;

        public override void Generate() {
		    l = GetLayer("HUD");

            DiscPlayer();
            SpoilerWarning();
            NotificationIcon();
        }

        void DiscPlayer() {
            var circle = l.CreateSprite(HUD_CIRCLE, OsbOrigin.Centre, new Vector2(-10, 404));
            circle.Scale(-1000, .6);
            circle.Fade(-1000, 100, 0, 1);
            circle.Fade(AudioDuration - 1500, AudioDuration - 1000, 1, 0);

            var disc = l.CreateSprite(HUD_DISC, OsbOrigin.Centre, new Vector2(-10, 404));
            disc.Scale(-1000, .6);
            disc.Rotate(-1000, AudioDuration, 0, 200);
            disc.Fade(-1000, 100, 0, 1);
            disc.Fade(AudioDuration - 1500, AudioDuration - 1000, 1, 0);

            var line = l.CreateSprite(HUD_LINE, OsbOrigin.CentreLeft, new Vector2(-8, 381));
            line.ScaleVec(OsbEasing.OutSine, -500, 2000, 0, 2, 16, 2);
            line.Fade(-500, 0, 0, .8);
            line.ScaleVec(AudioDuration - 3500, AudioDuration - 1800, 16, 2, 0, 2);
            line.Fade(AudioDuration - 2500, AudioDuration - 1800, .8, 0);

            // Pass to SpoilerWarning()
            Disc = disc;
        }

        void SpoilerWarning() {
            var spoiler = l.CreateSprite(HUD_SPOILER, OsbOrigin.Centre, new Vector2(-10, 404));

            Action<int, int> spoilerShow = (start, end) => {
                spoiler.Fade(OsbEasing.Out, start + 500, start + 1500, 0, 1);
                Disc.Fade(OsbEasing.Out, start, start + 1000, 1, .3);

                spoiler.Fade(end, end + 1000, 1, 0);
                Disc.Fade(end + 500, end + 1500, .3, 1);
            };

            Action<int, Color4> spoilerColor = (time, color) =>
                spoiler.Color(OsbEasing.Out, time, time + 1000, spoiler.ColorAt(time), color);

            spoiler.Scale(72093, .5);
            spoiler.Color(72093, Color4.Red);
            spoilerShow(72093, 95394);
            spoilerColor(76754, Color4.White);

            spoilerShow(146657, 151317);

            spoilerShow(206657, 244521);
            spoilerColor(220055, Color4.Red);
            spoilerColor(234035, Color4.White);

            spoiler.Color(248016, Color4.Red);
            spoilerShow(248016, 263161);
            spoilerColor(260249, Color4.Black);
        }

        void NotificationIcon() {
            // This style of sprite initializing makes it looks like
            // the style of registering items in Minecraft modding...
            var abydos    = l.CreateSprite(LOGO_ABYDOS, OsbOrigin.Centre, new Vector2(-10, 0));
            var millenium = l.CreateSprite(LOGO_MILLENIUM, OsbOrigin.Centre, new Vector2(-10, 0));
            var gehenna   = l.CreateSprite(LOGO_GEHENNA, OsbOrigin.Centre, new Vector2(-10, 0));
            var trinity   = l.CreateSprite(LOGO_TRINITY, OsbOrigin.Centre, new Vector2(-10, 0));
            var arius     = l.CreateSprite(LOGO_ARIUS, OsbOrigin.Centre, new Vector2(-10, 0));

            Action<OsbSprite, int, int> iconShow = (sprite, start, end) => {
                if (sprite.ScaleAt(start).X != .45) sprite.Scale(start, .45);
                sprite.MoveY(OsbEasing.OutCirc, start - 100, start + 300, 340, 355);
                sprite.Fade(start - 100, start + 200, 0, .9);
                sprite.Fade(end - 100, end + 200, .9, 0);
            };

            Action<OsbSprite, int> iconMoveUp = (sprite, time) => {
                var ypos = sprite.PositionAt(time).Y;
                sprite.MoveY(OsbEasing.OutCubic, time - 100, time + 500, ypos, ypos - 40);
            };

            Action<OsbSprite, int> iconMoveDown = (sprite, time) => {
                var ypos = sprite.PositionAt(time).Y;
                sprite.MoveY(OsbEasing.OutCubic, time - 100, time + 500, ypos, ypos + 40);
            };

            Action<OsbSprite, int> iconMoveDownSlow = (sprite, time) => {
                var ypos = sprite.PositionAt(time).Y;
                sprite.MoveY(OsbEasing.InOutCubic, time - 100, time + 1000, ypos, ypos + 40);
            };

            iconShow(abydos, 15006, 17336);
            iconShow(abydos, 21996, 53453);
            iconShow(abydos, 56948, 94229);

            iconShow(millenium, 95394, 128016);
            iconShow(gehenna, 131511, 145492);
            iconShow(millenium, 145492, 150152);

            iconShow(trinity, 169958, 206074);
            iconShow(trinity, 207239, 215394);
            iconShow(gehenna, 215394, 218598);
            iconShow(trinity, 216268, 217725);
            iconMoveUp(gehenna, 216268);
            iconMoveDown(gehenna, 217725);
            iconShow(trinity, 218598, 224132);
            iconShow(gehenna, 220055, 222385);
            iconMoveUp(trinity, 220055);
            iconMoveDownSlow(trinity, 222385);

            iconShow(arius, 224715, 227045);
            iconShow(trinity, 227045, 227919);
            iconShow(arius, 227919, 229375);
            iconShow(trinity, 229375, 230249);
            iconShow(gehenna, 230249, 231705);
            iconShow(arius, 231705, 234035);

            iconShow(trinity, 234035, 243356);
            iconShow(gehenna, 238695, 243356);
            iconMoveUp(trinity, 238695);

            iconShow(abydos, 243356, 245686);
            iconShow(trinity, 245686, 259666);
            iconShow(arius, 255006, 261996);
            iconMoveUp(trinity, 255006);

            iconShow(abydos, 264326, 271317);
        }
    }
}
