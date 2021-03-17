# Jean-Poul Leth-Møller - Flow 2 Handin - Tower defence game
___

In our group we have made a tower defence game with a medieval theme. We have made use of Prefabs + parenting, UI, Animations, Animator & IK, Game and level design and finally ragdoll effects from flow 2.

My part in this project was to make a health bar for our enemies while having the health bar follow the main camera view and having the health of an enemy go down when taken damage. On top of that I had to make a ragdoll effect on the enemy when he died and make him despawn after a few seconds. All this is added to an additional zombie enemy as well.

**Software**: Unity and Visual studio code.

**Stage**: Medieval - level 1

**Work planner**: https://trello.com/b/kZXVMsHW/keen-games

**Stage rules**: Place towers and kill the enemies before they reach the end of the stage.

**Component**: <br/>

•	*Animator* - for having the zombie have animations <br/>
•	*Collider* (Box) so the enemy does not fall through the ground<br/>
•	*Camera* view from above <br/>
•	*Canvas* to display the health bar and have a UI for the health bar<br/>
•	*Prefabs* for reusing similar parts and not having mergin problems also the *enemy* zombie can be found under the folder Prefabs<br/>
•	*Rigidbody* for physics<br/>
•	*Scripts* to make components more dynamic (written in C#)<br/>
1.	Billboard - for the camera<br/>
2.	Healthbar - for the health bar<br/>
3.	Playerhealth - for the player to interact with the health bar<br/>
4.	Ragdollhandler - for making the ragdoll effect to to live<br/>

• *Slider* to make the health bar go down<br/>
• *UI* to make images for the health bar<br/>

**Scenes**: main scene for the project is called *level 1* under the folder scenes.

**Thoughts**: I had to make my own NPC (enemy) since I was not given the NPC (enemy) in prober time so had to make my own to address the ragdoll effect. Beside that we could have use a bit more time to add the finishing touches such as a point system but that will have to be another time. It turns out it takes a lot of time to make a game. Other than that we made a really cool game and had fun making it. 
Side not to you Jesper, we could use a step by step list for the subjects you go through during the classes since some of them are hard to remember.

**Made by**: Jean-Poul Leth-Møller<br/>
HIGH FIVE!
