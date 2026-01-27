

Open with Screen. 

1.) New Game
2.) Continue
3.) Exit
4.) Information



With new game, load character creation.

Name:
Age: 
Gender:

SCENE: INTRO
Hello there! Welcome to the world of POKEMON! My name is Professor Nobody. 
This world is inhabited by creatures called POKEMON! For some people, POKEMON are pets. Others use them for fights. Myself...
Well, I can't legally say. 

{Name}! Your very own POKEMON legend is about to unfold! A world of dreams and adventures with POKEMON awaits! Let's go!

PLAYER GET MADE WITH basic STATS and with tag NOPOKE

SCENE: IN BEDROOM

You wake up in your bedroom, today is the day to meetup with Prof Nobody to pick your first POKEMON.
What do you do?

1.) Get out of bed
2.) Sleep In

(if there's a if value set in the dialog go with @TRUE|Message Here|)

if 1
You jump out of the bed ready for your first day as a POKEMON TRAINER. (If Age is > 18 Add (Now is a better than later.)) Your room consist of the bed you were in, a PC, and a door leading down to the stairs. 
What do you do?

if 2)
You sleep in another 2 hours. You get out of bed slowly, you're late for your first day as a POKEMON TRAINER. Your room consist of the bed you were in, a PC, and a door leading down to the stairs. 
What do you do?

1.) Go to the PC and check it out.
2.) Go down the stairs.
3.) Make a big jump down the stairs.   -- This will just tell the user they died by breaking their neck, give them a game over sign.

If 1) 
You boot up your PC. 
What do you do?

1.)Check Email    --> Nobody emails you. You have no friends.
2.) Play Minesweeper -> Opens up Minesweeper mini game in directory.
if(user.Age > 18)
{
3.)Surf Pornhub -> You pervert, make sure to clean your browser history.  -> Get tag PORNADDICT
}
4.)Leave Computer -> Go back to room

Downstairs is quiet, your Mom sits at the table sipping coffee. 
1.) Talk to your Mom. -> Get tagged that talk to mom
2.) Leave the house. 
3.) Get yourself a cup of coffee.  -> If age >= 18 you get some coffee. If not mom stops you and says "You're too young for coffee".


if(On Time and under 18)

"Oh my little {gender} is finally growing up on going on {gender} POKEMON adventure." your Mom says. 

if(Late Under 18)
"Oh dear, you are running late. Better hurry over to Prof Nobody." your Mom says. 

if(over 18)
"It's about time you left the house. (If marked that watch porn add -> If you didn't waste so much time watching porn, maybe you got have became a Pokemon Master by now. )
Better get your butt over to Prof Nobody."  says your Mom

1.) Kiss your mom goodbye. "Love you Mom, bye".
2.) "Love you Mom, bye."
3.) "Bye."
4.) Just leave the house.
5.) "Fuck off Mom."

You are outside in your small home town of CLOQUET. 
To the NORTH is the exit out of the town. 
To the WEST is the graveyard. 
To the EAST is Prof Nobody's Lab.
To the SOUTH is a giant lake, the only other way out of town. 
Which Way:

IF NORTH: and NO POKEMON
You adventure out of town without a POKEMON partner. A pack of HOUNDOURs surround you. 
What do you do?
1.)Fight them myself.   
2.)Run back to CLOQUET
3.)Curl up into a fetal position and cry. 

    IF 1: 
      You attemp to fight these fire Pokemon yourself. (Rolling 1d20)
      (Roll a 1d20, if 20 player succeeds, else player fails)
        Succeeds: You defended yourself from a pack of HOUNDOURs. They all ran off, but one eventually came back carrying a POKEBALL. 
        Congrats! You caught a HOUNDDOUR.

        Fail: You unfortunately get roasted by the HOUNDOURs. With 3rd degree burns and chunk of flesh and intestines ripped out. 
        You succumb to your injuries, everything goes black. -> GAME OVER

    IF 2: 
        You escape the pack of HOUNDOUR and made it back to the safety of CLOQUET. - > Go back to previous scene. 

    IF 3: 
        You go into a fetal position and start crying. The HOUNDOURs don't care. You end up soiling yourself. The Houndour backs off. You head back into town to clean yourself up at your house. You exit your house nice and clean. -> Go back to Previous Scene

IF WEST
You adventure to the WEST, toward the creepy graveyard where your DAD is buried. No one goes here anymore due to the HAUNTERs that haunt the place. 
What do you do?
1.) Go back. -> Go back to previous scene
2.) Visit DAD's grave.

    IF 2: 
    (Roll 1d20)
        IF x >= 6
        You visit your DAD's grave. You sure miss him. It was good to visit before you start your adventure. You head back to the front of your house. 
        -> Go back to previous scene

        IF x < 6 
        Before you can get to your DAD's grave, you encounter a pack of HAUNTERs.
        What do you do?
        1.) Fight them
        2.) Run -> Previous scene

            IF 1: Turns out the HAUNTERs don't want to fight. They seem very passive. 
            1.) Continue to DAD's grave. -> Go to DAD GRAVE scene.
            2.) I still wanna fight them. 

                IF 2: Don't be a dick, just go to your DAD's grave. 
                1.) Ok -> Go to DAD's Grave Scene.
                2.) NO! 

                    IF 2: Really? You're going to be like this. Making me get all meta and stuff.
                    1.) Nah I'm just goofing, I'll go. -> Go to DADs Grave Scene
                    2.) Yes, I'm going to be a dick like this. 

                        IF 2: Fine, a HAUNTER opens up their mouth and swallows you whole. You are now in hell. 
                            GAME OVER


IF SOUTH and NO WATER POKEMON
    You get to the giant lake SOUTH of town. Without a WATER POKEMON you won't be able to travel this way. 
    1.) I'll go back. -> Go back to prevous scene
    2.) I'll swim it myself. 

        IF 2:
            You start swimming in the cold lake. A SHARPEDO starts charging you. 
            1.)Punch it. 
            2.)Swim back. -> Back to previous scene

                IF 1: Role 2d20, 
                    IF both come back as 20
                    You punch the SHARPEDO in the nose so hard, it burst the SHARPEDO head wide open. Good job, you killed a POKEMON with your fist. 
                    ELSE
                    You try to punch the SHARPEDO, but it went right into the jaws of the shark POKEMON. SHARPEDO rips your arm off, you bleed to death in the lake. -> GAME OVER
            
IF EAST
    You enter PROF NOBODY's lab. Several scientists are experimenting on a VAPOREON. PROF NOBODY greets you. 
    "{NAME}! Welcome to my lab."
    IF(Late):
    "You're late and all the good POKEMON have been chosen already. But I got a few left for you."
        ROLL 1D4

        1: Weedle, Unown, Chatot
        2. Caterpie, Rattata, Huskroc (Custom Pokemon)
        3. Magikarp, Weedle, Pidgey
        4. Caterpie, Weedle, Wurmple
    ELSE:
    "You're the first one here, so you get the pick of the top tier."
        ROLE 1D20

        1: Charmander, Squirtle, Bulbasaur
        2: Pikachu, Eevee, Meowth
        3: Charmander, Squirtle, Bulbasaur
        4: Cyndaquil, Totodile, Chikorita
        5: Torchic, Mudkip, Treecko
        6: Cyndaquil, Totodile, Chikorita
        7: Charmander, Squirtle, Bulbasaur
        8: Wurmple, Eevee, Pikachu
        9: Charmander, Squirtle, Bulbasaur
        10: Cyndaquil, Totodile, Chikorita
        11: Pikachu, Eevee, Meowth
        12: Charamnder, Squirtle, Bulbasaur
        13: Torchic, Mudkip, Treecko
        14: Cyndaquil, Totodile, Chikorita
        15: Charmander, Suirtle, Bulbasaur
        16: Torchic, Mudkip, Treecko
        17: Eevee, Meowth, Geodude
        18: Magikarp, Machop, Abra
        19: Flareon, Vaporeon, Jolteon
        20: Mew, Celebi, Genesect

After Player makes choice:

"Good choice, wanna do a battle to test it out?" says PROF NOBODY. 
1.) Sure -> Enter battle scene
2.) No, -> Go to Next dialog






