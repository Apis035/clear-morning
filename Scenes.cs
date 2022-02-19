using System.IO;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System.Collections.Generic;

using static StorybrewCommon.Assets;

namespace StorybrewScripts
{
    public class Scenes : StoryboardObjectGenerator
    {
        OsbSprite s;
        StoryboardLayer l;
        float scale;

        public override void Generate() {
            l = GetLayer(LAYER_SCENE);

            var cg = new List<Scene>();

            // Load images into cg[] array and display the list in log
            // Adding/deleting any images in \scene\ folder will mess up the whole code
            int i = 0;
            foreach (var scene in Directory.GetFiles($"{MapsetPath}/{FOLDER_SCENE}")) {
                cg.Add(LoadScene($"{FOLDER_SCENE}/" + Path.GetFileName(scene))); 
                Log($"CS[{i}]: {cg[i].Path}");
                i++;
            }

            // Intro 1
            scale = 1.02f;
            MoveX(1026, 2482, 5, -5, cg[47]);
            MoveX(2482, 3356, 3, -3, cg[48]);
            MoveX(3356, 4812, 6, -6, cg[46]);
            MoveX(4812, 5686, 2, -2, cg[49]);
            MoveX(5686, 7142, -5, 5, cg[22]);
            MoveX(7142, 8016, -3, 3, cg[23]);
            Scale(8016, 9181, 1.04, 1, cg[17]);
            Scale(9181, 10346, 1, 1.1, cg[51]);

            // Intro 2
            MoveY(OsbEasing.OutCirc, 10346, 12676, 280, -220, cg[50])
                .Fade(10346 + OFFSET, 1);
            MoveX(12676, 13550, 6, -6, cg[18]);
            MoveX(13550, 15006, 8, -8, cg[19]);

            scale = 1.15f;
            MoveX(OsbEasing.OutSine, 15006, 17336, 55, -55, cg[52]);

            scale = 1.02f;
            MoveX(17336, 19666, -5, 5, cg[20]);
            MoveX(17336, 19666, -5, 5, cg[21])
                .Fade(17919 + OFFSET, 18501 + OFFSET, 0, 1);

            // Verse
            scale = 1.03f;
            MoveX(21996, 28987, -15, 15, cg[53])
                .Fade(21996 + OFFSET, 23744 + OFFSET, 0, 1);
            MoveX(28987, 38307, 15, -15, cg[54])
                .Fade(OsbEasing.OutExpo, 37725 + OFFSET, 38307 + OFFSET, 1, 0);

            // Prechorus
            MoveX(38307, 47627, -15, 15, cg[57])
                .Fade(38307 + OFFSET, 40055 + OFFSET, 0, 1);

            scale = 1.02f;
            MoveX(OsbEasing.OutSine, 47627, 49958, 8, -8, cg[56]);
            MoveX(OsbEasing.OutSine, 49958, 53453, -10, 10, cg[55])
                .Fade(OsbEasing.OutExpo, 52288 + OFFSET, 53453 + OFFSET, 1, 0);

            // Chorus
            Scale(OsbEasing.Out, 56948, 66268, 1.5, 1, cg[0]);

            scale = 1;
            MoveY(OsbEasing.InOutSine, 66268, 74424, -60, 40, cg[1]);
            Scale(74424, 74715, 1.05, 1, cg[3]);
            MoveY(74715, 74860, 10, 20, cg[2]);
            MoveY(74860, 75006, 20, 30, cg[4]);
            Scale(OsbEasing.Out, 75006, 75589, 1.08, 1, cg[8]);
            MoveY(OsbEasing.InOutSine, 75589, 84909, -60, 40, cg[5]);
            MoveY(OsbEasing.InOutSine, 84909, 94229, -60, 60, cg[6]);
            MoveY(OsbEasing.InOutSine, 84909, 94229, -60, 60, cg[7])
                .Fade(91026 + OFFSET, 91608 + OFFSET, 0, 1);

            // Verse
            scale = 1.02f;
            MoveX(95394, 98890, -10, 10, cg[67])
                .Fade(95394 + OFFSET, 97142 + OFFSET, 0, 1);
            MoveX(98890, 103550, -10, 12, cg[68]);
            Scale(OsbEasing.OutSine, 103550, 105880, 1.05, 1, cg[75]);

            scale = 1.04f;
            MoveX(105880, 112870, -25, 5, cg[74])
                .Fade(109958 + OFFSET, 109959 + OFFSET, 1, 0);

            scale = 1.048f; /* the frame has different zoom */
            s = MoveX(105880, 112870, -5, 25, cg[76]);
            s.Fade(108792 + OFFSET, 109958 + OFFSET, 0, 1);
            s.Fade(OsbEasing.OutExpo, 112288 + OFFSET, 112870 + OFFSET, 1, 0);

            // Prechorus
            scale = 1.02f;
            MoveX(112870, 118404, 10, -10, cg[77])
                .Fade(112870 + OFFSET, 114618 + OFFSET, 0, 1);
            Scale(117239, 122191, 1, 1.07, cg[78])
                .Fade(117239 + OFFSET, 118404 + OFFSET, 0, 1);
            MoveX(OsbEasing.OutSine, 122191, 124521, -5, 5, cg[69]);
            MoveX(OsbEasing.OutSine, 124521, 128016, 8, -8, cg[70])
                .Fade(OsbEasing.OutExpo, 126851 + OFFSET, 128016 + OFFSET, 1, 0);

            s = MoveY(129181, 130637, -10, 10, cg[9]);
            s.Fade(129181 + OFFSET, 130346 + OFFSET, 0, .8);
            s.Fade(OsbEasing.OutCubic, 130346 + OFFSET, 130637 + OFFSET, .8, 0);

            // Chorus
            MoveY(OsbEasing.OutSine, 131511, 133841, -40, 20, cg[10]);
            MoveX(OsbEasing.OutSine, 133841, 136171, -10, 10, cg[11]);
            MoveX(OsbEasing.OutSine, 136171, 138501, 10, -10, cg[63]);
            MoveX(138501, 140831, -10, 10, cg[65]);
            MoveX(140831, 143161, 10, -10, cg[64]);
            MoveX(143161, 145492, -10, 10, cg[66]);

            scale = 1;
            MoveY(OsbEasing.OutSine, 145492, 147822, -60, -20, cg[16]);
            Scale(OsbEasing.OutSine, 147822, 148987, 1.05, 1, cg[12]);

            scale = 1.01f;
            MoveX(148987, 149278, 3, -3, cg[13]);
            MoveX(149278, 149569, -3, 3, cg[14]);
            Scale(OsbEasing.Out, 149569, 150152, 1.3, 1.1, cg[15]);

            scale = 1;
            MoveY(OsbEasing.InOutSine, 150152, 159472, 280, -280, cg[91]);

            scale = 1.04f;
            MoveX(OsbEasing.InOutSine, 159472, 164132, -20, 20, cg[92]);
            Scale(164132, 168792, 1, 1.05, cg[93]);

            // Bridge
            scale = 1.02f;
            MoveX(169958, 173453, -10, 10, cg[79])
                .Fade(169958 + OFFSET, 171705 + OFFSET, 0, 1);
            MoveX(173453, 178113, -10, 10, cg[80]);
            MoveY(OsbEasing.OutSine, 178113, 180443, -10, 10, cg[26]);
            MoveX(OsbEasing.OutSine, 180443, 182773, -10, 10, cg[27]);
            Scale(182773, 187433, 1.2, 1, cg[28]);

            // Chorus solo
            MoveX(187433, 189763, 10, -10, cg[58]);
            MoveX(189763, 192093, -10, 10, cg[60]);
            MoveX(192093, 194424, -10, 10, cg[61]);
            MoveX(194424, 196754, -10, 10, cg[39]);
            MoveX(196754, 199084, 10, -10, cg[59]);
            MoveX(199084, 201414, -10, 10, cg[62]);
            MoveX(201414, 203744, 10, -10, cg[40]);
            Scale(OsbEasing.OutSine, 203744, 206074, 1.05, 1, cg[38]);

            // Prechorus
            Scale(207239, 210734, 1.1, 1, cg[24])
                .Fade(207239 + OFFSET, 208987 + OFFSET, 0, 1);
            Scale(OsbEasing.OutSine, 210734, 215394, 1, 1.1, cg[25]);
            MoveX(215394, 216268, -3, 3, cg[29]);
            MoveY(216268, 217725, -8, 8, cg[81]);
            MoveX(217725, 218598, 4, -4, cg[82]);
            MoveX(218598, 220055, -5, 5, cg[83]);
            Scale(OsbEasing.OutSine, 220055, 222385, 1, 1.1, cg[84])
                .Fade(220637 + OFFSET, 222385 + OFFSET, 1, 0);

            s = Scale(222385, 224132, 1, 1.1, cg[85]);
            s.Move(222385 + OFFSET, 224132 + OFFSET, 320, 240, 300, 260);
            s.Fade(222385 + OFFSET, 223550 + OFFSET, 0, 1);
            s.Fade(OsbEasing.OutCubic, 223550 + OFFSET, 224132 + OFFSET, 1, 0);

            // Chorus transition
            MoveY(224715, 225589, 3, -3, cg[30]);
            Scale(225589, 227045, 1.03, 1, cg[86]);
            MoveX(227045, 227919, 5, -5, cg[43]);
            MoveY(227919, 229375, -6, 6, cg[90]);
            Scale(229375, 230249, 1.03, 1, cg[44]);
            Scale(230249, 231705, 1.03, 1, cg[87]);

            scale = 1.04f;
            MoveX(OsbEasing.OutSine, 231705, 234035, -15, 15, cg[89]);

            // Chorus
            Scale(OsbEasing.Out, 234035, 238695, 1.3, 1, cg[35]);
            MoveX(OsbEasing.OutSine, 238695, 243356, -20, 20, cg[36]);

            scale = 1.02f;
            MoveX(243356, 245686, -10, 10, cg[88]);
            MoveX(245686, 248016, -10, 10, cg[37]);

            scale = 1;
            MoveY(248016, 250346, -20, -60, cg[42]);
            Scale(OsbEasing.Out, 250346, 252676, 1.1, 1, cg[41]);

            scale = 1.02f;
            MoveX(252676, 255006, -10, 10, cg[31]);

            scale = 1.04f;
            MoveX(255006, 260249, -20, 20, cg[32]);
            Scale(259666, 261996, 1, 1.03, cg[33])
                .Fade(259666 + OFFSET, 260249 + OFFSET, 0, 1);
            Scale(259666, 261996, 1, 1.03, cg[34])
                .Fade(OsbEasing.OutExpo, 261414 + OFFSET, 261705 + OFFSET, 0, 1);

            // Outro
            scale = 1.02f;
            MoveX(261996, 264326, -5, 5, cg[71]);
            MoveX(264326, 266657, -5, 5, cg[72]);

            scale = 1;
            MoveY(OsbEasing.InOutSine, 266657, 275394, -330, 330, cg[73])
                .Fade(271317 + OFFSET, 275394 + OFFSET, 1, 0);
        }

        /********************
         * Helper functions *
         ********************/

        OsbSprite Scale(int startTime, int endTime, double startScale, double endScale, Scene scene) {
            return Scale(OsbEasing.None, startTime, endTime, startScale, endScale, scene);
        }

        OsbSprite Scale(OsbEasing easing, int startTime, int endTime, double startScale, double endScale, Scene scene) {
            s = l.CreateSprite(scene.Path);
            s.Scale(easing, startTime + OFFSET, endTime + OFFSET, scene.ScaleX * startScale, scene.ScaleX * endScale);
            return s;
        }

        OsbSprite MoveX(int startTime, int endTime, int startX, int endX, Scene scene) {
            return MoveX(OsbEasing.None, startTime, endTime, startX, endX, scene);
        }

        OsbSprite MoveX(OsbEasing easing, int startTime, int endTime, int startX, int endX, Scene scene) {
            s = l.CreateSprite(scene.Path);
            s.Scale(startTime + OFFSET, scene.ScaleX * scale);
            s.MoveX(easing, startTime + OFFSET, endTime + OFFSET, 320 + startX, 320 + endX);
            return s;
        }

        OsbSprite MoveY(int startTime, int endTime, int startY, int endY, Scene scene) {
            return MoveY(OsbEasing.None, startTime, endTime, startY, endY, scene);
        }

        OsbSprite MoveY(OsbEasing easing, int startTime, int endTime, int startY, int endY, Scene scene) {
            s = l.CreateSprite(scene.Path);
            s.Scale(startTime + OFFSET, scene.ScaleX * scale);
            s.MoveY(easing, startTime + OFFSET, endTime + OFFSET, 240 + startY, 240 + endY);
            return s;
        }

        struct Scene {
            public string Path;
            public int    Width;
            public int    Height;
            public float  ScaleX;
            public float  ScaleY;
        }

        // Could have set this as constructor in Scene struct,
        // but I don't know how to access GetMapsetBitmap() from there...
        Scene LoadScene(string path) {
            Scene i  = new Scene();
            i.Path   = path;
            i.Width  = GetMapsetBitmap(path).Width;
            i.Height = GetMapsetBitmap(path).Height;
            i.ScaleX = 854.0f / i.Width;
            i.ScaleY = 480.0f / i.Height;
            return i;
        }
    }
}