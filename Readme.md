## Synopsis

Tetwis is a mobile game that is similar to Tetris, but includes physics calculations. It is built using Unity and so it can be distributed to multiple platforms, such as iOS, Android, PC, etc, but this project includes the Android build. 

Made by:
Jonathan Zelaya, Allen Tung, Fahad Mohammad, Prit Modi from Rutgers University

## Code Example

`void start()`      -  Called when the script is first created

`void Update()`     -  Called every frame, useful to update many variables and calculate various physics aspects.

`void LateUpdate()` -  Called after all Update functions have been called. This is useful to order script execution. Camera movement
                     is usually controlled in this method.
                     
Every other method is a user defined method and runs when called in the functions above.

## Motivation

This project is based off the game "Tricky Towers" which is for PS4 and Steam. We wanted to create a Tetris game for the mobile platform that also included physics calculations. This was also a good way to get a good introduction into game development for the Android and iOS platform.

## Installation

This project includes the .apk file for installing on Android devices. Alternatively, you can clone the entire project and then use Unity to open it. This will allow you to 1) play the game in Unity, 2) make adjustments and see real time changes. From here you could also build and run on other platforms, such as iOS.

## API Reference

https://docs.unity3d.com/ScriptReference/

## Tests

The best way to test a game is to play it, so play it.

## Contributors

To contributors: if you would like to make a contribution to this project, you can contact us to see a list of current problems our game has. For example, we need a way to reduce the effect of blocks touching to create a more Tetris feel. Feel free to contact us for more explanation or for other problems.

## License

Copyright 2016 Jonathan Zelaya

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
   
     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

Just give us credit and you can do whatever (except make money from it). 
