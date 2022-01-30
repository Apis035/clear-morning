/*
 * Modifications from storybrew's stock spectrum script:
 * - Changed spectrum bar spacing calculation to be simpler
 * - Added PowerScale variable to make the spectrum more reactive to louder sound
 * - Spectrum only draw 1/3 part of the total spectrum because higher frequencies doesn't
 *   react really much with the song
 * - Cleaned some unnecessary code
 */

using OpenTK;
using StorybrewCommon.Animations;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System;

using static StorybrewCommon.Assets;

namespace StorybrewScripts
{
    public class Spectrum : StoryboardObjectGenerator
    {
        [Configurable] public Vector2 Position    = new Vector2(20, 380);
        [Configurable] public float   Spacing     = 2;
        [Configurable] public int     BeatDivisor = 8;
        [Configurable] public int     BarCount    = 60;
        [Configurable] public int     Height      = 16;
        [Configurable] public float   ScaleX      = 0.3f;
        [Configurable] public float   MinHeight   = 0.1f;
        [Configurable] public int     LogScale    = 200;
        [Configurable] public double  PowerScale  = 1.5;
        [Configurable] public double  Tolerance   = 0.2;

        public override void Generate() {
            var bitmap  = GetMapsetBitmap(HUD_BAR);
            var layer   = GetLayer(LAYER_SPECTRUM);
            var endTime = 274812;
            var opacity = 0.9f;
            var delay   = 0;

            // Initialize spectrum keyframes
            var heightKeyframes = new KeyframedValue<float>[BarCount];

            for (var i=0; i<BarCount; i++)
                heightKeyframes[i] = new KeyframedValue<float>(null);

            // Get spectrum data
            var timestep = (int)Beatmap.GetTimingPointAt(0).BeatDuration / BeatDivisor;

            for (var time = 0; time < endTime; time += timestep) {
                var fft = GetFft(time + (timestep * 0.2), BarCount * 3, null, OsbEasing.InExpo);

                for (var i = 0; i < BarCount; i++) {
                    var height = (float)Math.Pow((float)Math.Log(1 + fft[i] * LogScale), PowerScale) * Height / bitmap.Height;

                    if (height < MinHeight) height = MinHeight;
                    heightKeyframes[i].Add(time, height);
                }
            }

            // Draw bars
            for (var i=0; i<BarCount; i++) {
                var keyframes = heightKeyframes[i];
                keyframes.Simplify1dKeyframes(Tolerance, h => h);

                var s = layer.CreateSprite(HUD_BAR, OsbOrigin.BottomCentre, new Vector2(Position.X + i * Spacing, Position.Y));
                s.CommandSplitThreshold = 600;

                s.Fade(-500 + delay, delay, 0, opacity);
                s.Fade(endTime + delay - 500, endTime + delay, opacity, 0);
                delay += 30;

                var hasScale = false;
                keyframes.ForEachPair(
                    (start, end) => {
                        hasScale = true;
                        s.ScaleVec(start.Time, end.Time, ScaleX, start.Value, ScaleX, end.Value);
                    },
                    MinHeight, r => (float)Math.Round(r, 1)
                );

                if (hasScale) s.ScaleVec(0, ScaleX, MinHeight);
            }
        }
    }
}