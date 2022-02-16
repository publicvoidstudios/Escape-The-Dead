# Escape The Dead
 Escape The Dead by Vladislav Pak (Public Void Studios). A zombie shooter mobile game.
 
 Escape The Dead is a mobile game which brings you to a zombie post apocalypse, where you are a soldier left alone in a never ending city, whith only purpose: get out of this city alive.
 
**Features in this project:**
 
 **World:**
 - Chunk based procedural level generation (see SingleChunk.cs & SingleChunkRandomizer.cs)
 - Every generated chunk has it's own random look generation system. Buildings get random meshes when instantiating, random props spawn at pre set positions with random offset, what makes every chunk feel a little different. Middle part of a chunk has several variants. One of the variants has a randomly generated garden.
 - Game has 2 modes: Day mode (Standard) and Night mode (Nightmare)
 - Nightmare mode means almost no environment and directional lights, and player gets flashlight, or can use nightvision.
 
 **Enemies:**
 - Enemies use UnityEngine.AI for realtime movement and navigation (NavMesh)
 - Enemies spawn at pre set positions with a chance of spawning or not.
 - Enemies have 2 different types of behaviour based on animations.
 - 50 variants of enemies meshes.

 **Player:**
 - Shooting made using raycasts.
 - Shooting includes particle system which instantiates impact effects depending on hit object.
 - Local player's progress is saved using JSON save system.
 - Player movement is managed automatically using Unity Engine's AI (Navigation).
 - Camera and camera rotation is managed by Cinemachine.
 - New Unity's Input System is used for camera controls.
 - Player has access to 10 weapons and 4 gear items, each weapon has it's own stats, each gear item has it's own purpose.

 **UI:**
 - UI is adapting to Player's current state, depending on which weapon is equipped, and which items were bought.
 - UI was made to be simple to understand and use, in a minimalistic design.

 **Google integration:**
 - Player have a choice to use Google Play Games
 - Play Games Achievements are present
 - Play Games Leaderboards are present
 - Play Games provide Cloud Saves system

 **In App Purchasing:**
 - This project has in app purchases, Player can buy weapons and gear for money, however there is a possibility to buy every item present in game without paying real money.

 **Advertisement:**
 - This project uses Unity's ADs
 - Player always have a choice - whether to watch ADs or not. (Only rewarded ADs used).

 **Choises that need explanation:**
 - This project is made using Standard Unity's built in pipeline. I understand that URP could bring many cool features, such as Post Processing and simple way to create Shaders (Shader Graph), but I chose Standard Pipeline. Reason for this is that HDRP is definitely made not for mobile devices, and URP does not support OpenGL ES 2.0, which is still used by many devices.

**Please note:** this project is for reference only, any use which can be considered as commercial is prohibited!
