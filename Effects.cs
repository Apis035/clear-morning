using OpenTK;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System;

using static StorybrewCommon.Assets;

namespace StorybrewScripts
{
    public class Effects : StoryboardObjectGenerator
    {
        OsbSprite s;

        public override void Generate() {
            // Vignette
            s = GetLayer(LAYER_VIGNETTE).CreateSprite(HUD_VIGNETTE, OsbOrigin.Centre, new Vector2(320, 220));
            s.Scale(-1000, SCALE * 1.1);
            s.Fade(277142, 1);

            // Flash
            s = GetLayer(LAYER_FLASH).CreateSprite(PIXEL);

            Action<OsbEasing, int, int, float, float> Flash = (easing, startTime, endTime, startValue, endValue)
                => s.Fade(easing, startTime + OFFSET, endTime + OFFSET, startValue, endValue);

            // Intro 1
            s.ScaleVec(-1000, 854, 480);
            Flash(OsbEasing.None, -1000, 0, 0, 1);
            Flash(OsbEasing.None, 1026, 2191, 1, 0);

            // Intro 2
            Flash(OsbEasing.OutExpo, 9763, 10346, 0, 1);
            Flash(OsbEasing.OutExpo, 10346, 12676, 1, 0);

            // Verse
            Flash(OsbEasing.InExpo, 18501, 19666, 0, 1);
            Flash(OsbEasing.Out, 19666, 21996, 1, 0);

            Flash(OsbEasing.OutExpo, 28404, 28987, 0, 1);
            Flash(OsbEasing.OutExpo, 28987, 31317, 1, 0);

            // Prechorus
            Flash(OsbEasing.None, 54618, 55783, 0, .8f);
            Flash(OsbEasing.OutExpo, 55783, 56365, .8f, 0);

            // Chorus
            Flash(OsbEasing.None, 56365 , 56948, 0, .2f);
            Flash(OsbEasing.Out, 56948, 59278, 1, 0);
            Flash(OsbEasing.OutExpo, 65686, 66268, 0, 1);
            Flash(OsbEasing.OutExpo, 66268, 67433, 1, 0);
            Flash(OsbEasing.OutExpo, 75006, 75589, 0, 1);
            Flash(OsbEasing.None, 75589, 77919, 1, 0);
            Flash(OsbEasing.OutExpo, 84326, 84909, 0, 1);
            Flash(OsbEasing.OutExpo, 84909, 86074, 1, 0);

            // Verse
            Flash(OsbEasing.OutExpo, 93647, 94229, 0, 1);
            Flash(OsbEasing.Out, 94229, 95394, 1, 0);
            Flash(OsbEasing.OutExpo, 102967, 103550, 0, 1);
            Flash(OsbEasing.OutExpo, 103550, 104715, 1, 0);
            Flash(OsbEasing.None, 130928, 131511, 0, .2f);
            Flash(OsbEasing.Out, 131511, 133841, 1, 0);

            // Chorus
            Flash(OsbEasing.OutExpo, 140249, 140831, 0, 1);
            Flash(OsbEasing.OutExpo, 140831, 141414, 1, 0);
            Flash(OsbEasing.OutExpo, 149569, 150152, 0, 1);
            Flash(OsbEasing.None, 150152, 152482, 1, 0);

            // Bridge
            Flash(OsbEasing.OutExpo, 168210, 168792, 0, 1);
            Flash(OsbEasing.Out, 168792, 169958, 1, 0);

            // Chorus solo
            Flash(OsbEasing.OutExpo, 186851, 187433, 0, 1);
            Flash(OsbEasing.None, 187433, 189763, 1, 0);
            Flash(OsbEasing.OutExpo, 196171, 196754, 0, 1);
            Flash(OsbEasing.OutExpo, 196754, 197919, 1, 0);

            // Prechorus
            Flash(OsbEasing.OutExpo, 205492, 206074, 0, 1);
            Flash(OsbEasing.OutExpo, 206074, 208404, 1, 0);

            // Chorus transition
            Flash(OsbEasing.OutExpo, 233453, 234035, 0, 1);
            Flash(OsbEasing.OutExpo, 234035, 236365, 1, 0);

            // Chorus
            Flash(OsbEasing.OutExpo, 242773, 243356, 0, 1);
            Flash(OsbEasing.OutExpo, 243356, 244521, 1, 0);
            Flash(OsbEasing.OutExpo, 252093, 252676, 0, 1);
            Flash(OsbEasing.OutExpo, 252676, 253841, 1, 0);
            Flash(OsbEasing.InExpo, 261414, 261996, 0, .5f);
            s.Fade(261996 + OFFSET, 1);
            Flash(OsbEasing.None, 262579, 264326, 1, 0);
        }
    }
}
