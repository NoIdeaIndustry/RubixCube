<div align="center">

# RubiksCube
</div>

**RubiksCube is Unity project made for learning in a fun way how to use quaternions during mathematics classes.**<br/>

## Building
## Create an executable
```sh
$ Unity > File > Build Settings > Build
```
## Run
```sh
$ Unity > File > Build And Run
```

# Usage
Right Click + Swipe (in any direction) will make the whole cube rotate depending on your movement.<br/>
Left Click + Swipe (in any direction) will make the selected face of the cube rotate depending on your movement.<br/>
Make sure to hold the click while doing the swipe and then let go.<br/>

You can edit the cube size by directly changing it using the inspector or in the code itself (beyon 100 rows/columns it's meaningless, it won't run at all).<br/>

# Features
```
Resolve button will resolve the cube based on the current setup.

Shuffle button will shuffle according to the slider.

Cube size can be changed between 2 and 10 rows/columns, for more refer to the code itself.

Reset will obviously reset the cube to it's normal aspect, completed.

Undo will get to the last-1 movement made on the cube, a rollback it is.

Redo will simply do the last step you made once more.
```

# Multiple Previews
![](Showcase/cube.png?raw=true "3x3 Cube")
![](Showcase/cube10.png?raw=true "10x10 Cube")

# Settings Previews
![](Showcase/cubeActions.png?raw=true "Resolve or Shuffle cube")
![](Showcase/cubeRestart.png?raw=true "Reset, undo, roll back progress")
![](Showcase/cubeShuffle.png?raw=true "Shuffle the cube between 10 and 50 times")
![](Showcase/cubeSize.png?raw=true "Cube size between 2x2 and 10x10")

# Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.<br/>
Please make sure to update tests as appropriate.<br/>