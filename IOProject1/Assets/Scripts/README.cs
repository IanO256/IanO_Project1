/*The main mechanic I was attempting to recreate in a way was the morality mechanic from something like KOTOR. 
 * The mechanic itself is simple. (I probably made it a little a more difficult than it had to be however I was attempting to us ray tracing)
 * You make a bad decision your morality is evil. You make a good decision your morality is heroic. (eg. Jedi vs Sith: KOTOR) 
 * 
 * I used an interactable interface. The way I used it was essentially to see if the raycasting is interacting with a character that can be
 * interacted with and not a brick wall or something. You can find it in the IInteractable interface script, UIPlayerInteractions Script 
 * (within the InteractWithCharacter(), and Character scripts. Delta time was used to have a more fixed movement speed for the player to move  
 * around in, it is found withing the Player Script. I did not use much awake vs start methods however awake is called to make sure the morality 
 * is set to zero at the beginning of the game, in the UIPlayerInteractions Script. While the start function is found in the Player Script to 
 * ensure the abstract inputs such as move are properly created. 
 * 
 * 
 * I mean I would have been cool to have the player grow demon horns if evil or an angel halo if good. Or a way to change the player color from
 * grey (neutral) to blue (good) or red (evil). But that was just not going to happen. There are already a couple of problems I have for this. 
 * For one for whatever reason you pretty much have to hold down on the click button rather than just clicking it once to interact with the NPC. 
 * However if the mouse is held down while the player is talking to the NPC the morality will go either up or down. (positive = good, negative = bad)
 * 
 */