# Clear Morning Storyboard

Storyboard for my beatmap Yui Ogura - Clear Morning

Code are messed up in some places and I'm too lazy to clean it.

- There are some comments in the scripts to note what that particular code does.
- [Spectrum.cs](Spectrum.cs) is modified from storybrew's stock spectrum script.
- Storyboard resource paths are stored in [Assets.cs](scriptslibrary/Assets.cs) to make code cleaner and easier to manage.
- In the scripts, sometimes I use `Action<>` delegate instead of functions also to make it easier to look and manage.
- The actual lyrics are stored in [text file](assetlibrary/lyric.txt), dashes are used as 1/4 beat delay.
Any line not starting with number are ignored.

---

Feel free to take any part of the code in this project.

Idk what you're gonna do with it either you gonna use it in your own project,
just want to take a look, or use it to learn how to storyboard because some
people learn faster by examples than by tutorial/guide.

Credit not needed but I appreciate it if you do c:

---

[Storybrew](https://github.com/Damnae/storybrew) needed to open the project file.

Beatmap: [Yui Ogura - Clear Morning](https://osu.ppy.sh/beatmapsets/1644119)

Custom font used for lyrics: [KFHimaji](https://www.kfstudio.net/font/kfhimaji/)