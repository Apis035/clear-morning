using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using System;
using System.IO;

using static StorybrewCommon.Assets;

namespace StorybrewScripts
{
    public class Lyrics : StoryboardObjectGenerator
    {
        public override void Generate() {
            var l        = GetLayer(LAYER_LYRIC);
            var beat     = (int)Beatmap.GetTimingPointAt(0).BeatDuration;
		    var path     = $"{ProjectPath}/assetlibrary/lyric.txt";
            var position = new Vector2(20, 390);

            AddDependency(path);

            var font = LoadFont(FOLDER_FONT, new FontDescription() {
                FontPath  = "assetlibrary/KFhimaji.otf",
                FontSize  = 46,
                Color     = Color4.White
                }
            );

            var stars   = new OsbSpritePool(l, HUD_STAR, OsbOrigin.Centre);

            foreach (var line in File.ReadAllLines(path)) {
                var arg = line.Split(new[] {' '}, 2);
                int o; if (!String.IsNullOrEmpty(arg[0]) & int.TryParse(arg[0], out o)) {
                    var startTime    = int.Parse(arg[0]) + OFFSET;
                    var endTime      = startTime;
                    var text         = arg[1];
                    var width        = 0f;
                    var starDelay    = 0;
                    var fadeInDelay  = 0;
                    var fadeOutDelay = 0;
                    var letterX      = 0f;

                    foreach (var letter in text) {
                        if (letter == '-') endTime += beat/4;
                        if (letter != '-') width   += font.GetTexture(letter.ToString()).BaseWidth * .5f;
                    }

                    // Stars
                    for (var i=0; i<width; i+=15) {
                        var random    = Random(-200, 100);
                        var StartTime = startTime + random;
                        var EndTime   = endTime + random;
                        var startDir  = Random(Math.PI*4);
                        var endDir    = startDir + Random(-Math.PI, Math.PI);
                        var startPos  = new Vector2(position.X + i + Random(-8, 8), position.Y + 15 + Random(-16, 16));
                        var endPos    = new Vector2(
                            startPos.X + (float)Math.Sin(Random(Math.PI*2)) * 10,
                            startPos.Y + (float)Math.Cos(Random(Math.PI*2)) * 10
                        );

                        var s = stars.Get(StartTime + starDelay, EndTime + starDelay + 500);

                            if (!s.AdditiveAt(StartTime + starDelay))
                                s.Additive(StartTime + starDelay);
                            if (s.ScaleAt(StartTime + starDelay).X != .5f)
                                s.Scale(StartTime + starDelay, .5f);

                            s.Move  (StartTime + starDelay, EndTime  + starDelay + 500, startPos, endPos);
                            s.Rotate(StartTime + starDelay, EndTime  + starDelay + 500, startDir, endDir);
                            s.Fade  (StartTime + starDelay, StartTime+ starDelay + 300, 0, .4f);
                            s.Fade  (EndTime   + starDelay, EndTime  + starDelay + 500, .4f, 0);

                        starDelay += 100;
                    }

                    // Texts
                    foreach (var letter in text) {
                        var texture = font.GetTexture(letter.ToString());

                        if (!texture.IsEmpty & letter != '-') {
                            var distance = (endTime - startTime) / beat / 2;
                            var startDir = 0;
                            var endDir   = startDir + Random(-Math.PI/24, Math.PI/24);
                            var startPos = new Vector2(position.X + letterX, position.Y) + texture.OffsetFor(OsbOrigin.Centre) * .5f;
                            var endPos   = new Vector2(
                                startPos.X + (float)Math.Sin(Random(Math.PI)) * distance,
                                startPos.Y + (float)Math.Cos(Random(Math.PI)) * (distance + 1) /* More vertical movement */
                            );

                            var s = l.CreateSprite(texture.Path, OsbOrigin.Centre, startPos);
                                s.Scale (startTime + fadeInDelay - 200, .5f);
                                s.Move  (startTime + fadeInDelay - 200, endTime  + fadeInDelay, startPos, endPos);
                                s.Fade  (startTime + fadeInDelay - 200, startTime+ fadeInDelay, 0, .9);
                                s.Fade  (endTime   + fadeOutDelay- 200, endTime  + fadeOutDelay, .9, 0);
                                s.Rotate(OsbEasing.OutElasticHalf, startTime + fadeInDelay - 200, startTime + fadeInDelay + 2000, startDir, endDir);
                        }

                        fadeOutDelay += 5;

                        if (letter != '-') letterX     += texture.BaseWidth * .5f;
                        if (letter == '-') fadeInDelay += beat/4;
                    }
                }
            }
        }
    }
}
