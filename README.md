# HW4
Homework 4 Repository for CSC 476

Always forgetting to start these until half way through development.

Thought it would be fun to jump on an opportunity to make a more original idea into a project. While there are some things I definitely wish I did better,
overall I can't complain too much about how the project turned out. 

Decided to stick with the no textures on the playable characters and npcs because by the time I finished with everything else, I felt there was something charming
about the lack of design.

Had some fun playing around with audio for this game, adding audio for every scene, and adding audio for damage taken for both enemies and the playable character.
The soundtrack consists of classic tracks from some of the best classic video games known, and I took the liberty of including a track from one of my personal 
classic favorites, Shining Force. Other featured game soundtracks included true classics like Legend of Zelda Ocarina of Time, Donkey Kong Country 2, Super Mario Brother, and Final Fantasy 7.

I added a sensitivity slider so that players could at least somewhat change up the feel of the game. Considered adding sensitivity slider in the pause menu,
but opted against it after implementing a "continue" option for playthroughs.

"New Game" and "Continue" options, cause life happens.

Two End screen variations, one for successfully killing 7 zombies, one for unsuccessfully killing 7 zombies.

Originally I had practically nothing on the UI, really wanted to go for a barebones feel (hence the playable character having no texture added), but after having
some people play the game I decided a health bar and compass would be cool additions that dont ruin the game. Compass was because people said the forest was a bit 
annoying to traverse, which I got so a compass is a non-invasive way to assist that. Then the compass wasn't easy enough to read, so I made a new "better" one
with outlined NESW letters. 
The health bar was an interesting addition, because it easily revealed that players were sometimes able to take 6 hits instead of the intended 5 from zombies.
I just adjusted the lower limit, because the float was calculating out to something like 2.35345436E-8. x < .1 instead of x <= 0.

The forest maze has a limited render distance, partly for performance, and partly because it makes the whole area feel a bit more spooky/confusing. I know that was a
complaint from my testers, but come on thats sorta the point.

The combat was a point of grief from my playtesters, which is understandable because originally I just had it set up so that a player had to run at an enemy and time the
animation in order to hit enemies. To help alleviate some of that stress I decided to make the animation more of a poking motion (or at least as best as I could) while having
playable character stand completely still.

If I had more time I would have liked to add a third area where the player could get a shield, but I would have liked to do that using a platforming-type
environment, and due to the way I calculated movement, jumping was very difficult for me to figure out. Makes me bummed out that I couldn't put more effort
into this project earlier due to conflicts with other classes.

Generally I asked my playtesters how long their playthrough took, average time was probably between 15-20 minutes, which I think is a good time for such a short level.
The cutscene was a big hit, along with the NPC interactions, so I added some throwback "discovery" music from Legend of Zelda when discovering the sword,
and added some alternative audio tracks for the NPCs once the player had the sword.

Having the linear but open feeling storyline also seemed like a decent choice based on feedback. Like I said earlier, with more time I probably would have 
added a platform level as an opportunity for different playthrough experiences. 

Set enemy objects up so that they just chill until the player comes within a certain range. Kind of used "zombies" as a clutch to just have them walk at the player
for damage.

One playtester said I should add healthbars for the zombies, but I'm really not a fan of that. I'm more of an oldschool guy in the sense that sometimes you just gotta
outlive the enemies. Marathons don't get any easier knowing you're on mile 16 out of 26, so I just let it rock and gave a hint through NPC communication.

Can't think of the rest, should've kept this updated better during the project.
