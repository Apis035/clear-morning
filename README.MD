# Clear Morning Storyboard

Storyboard for beatmap [Yui Ogura - Clear Morning](https://osu.ppy.sh/beatmapsets/1644119)

Codes are messed up in some places and have inconsistent formatting styles.

- There are some comments in the scripts to note what that particular code does.
- [Spectrum.cs](Spectrum.cs) is modified from storybrew's stock spectrum script.
- Storyboard resource paths are stored in [Assets.cs](scriptslibrary/Assets.cs) to make code cleaner and easier to manage.
- Sometimes I use `Action<>` delegate instead of methods to make it easier to find because it is placed closer to where the code is going to be used.
- The lyrics are stored in [text file](assetlibrary/lyric.txt). Dashes are used as 1/4 beat delay, any line not starting with number are ignored. This makes it easier to do the lyric timing as you can see any changes immediately by pressing `ctrl + s`.

---

Feel free to take any part of the code in this project.

Idk what you're gonna do with it either you gonna use it in your own project,
just want to take a look, or use it to learn how to storyboard because some
people learn faster by examples than by tutorial/guide.

Credit not needed but I appreciate it if you do c:

---

[Storybrew](https://github.com/Damnae/storybrew) needed to open this project.

Beatmap: [Yui Ogura - Clear Morning](https://osu.ppy.sh/beatmapsets/1644119)

Custom font used for lyrics: [KFHimaji](https://www.kfstudio.net/font/kfhimaji/)