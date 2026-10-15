Week 3 UI 
Score - TextMeshPro text at the top left of the screen as the information provided by it is only to be glanced at and doesn't need to be focused on all the time, tells the player how many points they've earned by defeating enemies
Pause button - Button located toward the top right of the screen as the player only needs to be looking at it when they are thinking about pressing it and so it shouldn't block any game content, allows the player to pause the game mid-session
Movement controls - On-screen stick located towards the bottom left of the screen to allow for easy thumb access on the player's side of the screen without blocking any enemies, allows the rocket to move in all directions
Shooting controls - Button located towards the bottom right of the screen but not too far right as to not block incoming enemy spawns, allows the player to fire a bullet
Restart controls - Button located toward the top right of the screen as the player only needs to be looking at it when they are thinking about pressing it and so it shouldn't block any game content, allows the player to restart the game at any time
Pause menu - Lists resume button and restart button located in the middle of the screen for easy access but only active when the game is paused, performs the listed action when tapped
Health - Heart icons located towards the top right so it can quickly be glanced at without blocking active gameplay, displays remaining health

<img width="1284" height="664" alt="image" src="https://github.com/user-attachments/assets/3b55d6d2-38c4-418d-b0ec-a226bfbe5b93" />
(UI as currently is during gameplay on a 16:9 phone)

<img width="1083" height="540" alt="image" src="https://github.com/user-attachments/assets/009411ef-21c9-482d-8c81-4a59288a6a73" />
(UI as currently is while paused on a 16:9 phone)

<img width="1638" height="1023" alt="image" src="https://github.com/user-attachments/assets/099d7fe0-69f5-4cc1-8aa7-0f548e42fe6f" />
(UI as currently is during gameplay on a 4:3 tablet)

<img width="1605" height="997" alt="image" src="https://github.com/user-attachments/assets/8e3ea22b-0196-46d4-a723-8bbfc7019772" />
(UI as currently is while paused on a 4:3 tablet)

Problem 1: Misaligned buttons - On the 4:3 display, all the gameplay buttons are too close to the middle of the screen, this can require the player to play with an uncomfortable grip to be able to reach the necessary actions. Another problem caused by this is that the buttons actively block the game view making it possible that the player will miss alien spawns.

Problem 2: Button sizes - On a 16:9 display, all the on-screen buttons are too large and cover up too much of the screen in comparison to the player rocket and the aliens which can make actual gameplay hard to see. Another problem is that the pause UI is too tiny, especially considering nothing of note is displayed on screen other than the pause menu when the game is paused.

Solutions: These problems can be solved by making the gameplay controls smaller so that they don't take up as much of the screen space while also anchoring them closer to the edges of the screen so that they're out of the way of the actual gameplay. The pause screen UI should also be sized up to make it easier to read on smaller devices.

<img width="903" height="993" alt="image" src="https://github.com/user-attachments/assets/915106ad-4ce9-4388-9b87-a2634978d4cc" />
(Canvas scaler controls before)

FInal canvas scaler settings for UI:

Scale with screen size - Keeps all the buttons the same relative size regardless of screen resolution

Reference resolution - 1920x1080 - my game is in landscape mode so this resolution makes sense over 1080x1920

Screen Match Mode - Match Width or Height (0.5) - This match setting with this specific value is the only one that, when tested with various different devices in the simulator, kept the controls in an area where they were positioned well enough that they were close enough to the edges of the screen that they didn't interfere with gameplay but also didn't go outside the safe area on any of the displays.
