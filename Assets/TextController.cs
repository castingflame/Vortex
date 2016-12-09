using UnityEngine;
using UnityEngine.UI;		//brings in the unity engine interface
using System.Collections;
using System;

public class TextController : MonoBehaviour
{

    public Text story;
    public Text discoveries;
    public Text incarnations;
    public Text discovery_total;

    private int life = 0;
    private int places = 0;
    private int totalPlaces = 0;
    private bool dead = false;                   //death flag
    private bool[] locationList = new bool[46];   //create a boolean array to hold a list of locations


    private enum States
    {
        begin,cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1,   //create an enumerated list

        corridor_0, door_0, window, climb, sneeze, ceiling_hole, pick_nose, fall,
        door_1, guard_0, fight, joke,
        door_2, female_guard, kiss_guard, male_guard, cloak_sneak,
        cell_1, love, tunnel_0, tunnel_1, tunnel_2, tunnel_3, tunnel_4, tunnel_5, antechamber, mirror_1,

        lycan_den, lycan_talk, challenge, mirror_2, mirror_touch, mirror_fight,
        lycan_fight_0, lycan_fight_1, lycan_run_1, lycan_battle,
        lycan_run_0,
        death,freedom

     



    };


    private States myState;  //assign var to list

   
    // Use this for initialization
    void Start()
    {
        discoveries.text = "0";                           //reset the on-screen 'discoveries' 

        totalPlaces = locationList.Length;                //how mant total locations are there?
        discovery_total.text = totalPlaces.ToString();    //display the total on the screen  

        myState = States.begin;                           //set myState to the begin .

        LifeCounter();  //update life counter   
        
        } //void Start() - end



    void Update()
    {
        
        if (myState == States.begin) { begin(); }
        else if (myState == States.cell) { cell(); }                        //location 0 
        else if (myState == States.mirror) { mirror(); }                    //location 1
        else if (myState == States.sheets_0) { sheet_0(); }                 //location 2   
        else if (myState == States.lock_0) { lock_0(); }                    //location 3   
        else if (myState == States.cell_mirror) { cell_mirror(); }          //location 4
        else if (myState == States.sheets_1) { sheet_1(); }                 //location 5
        else if (myState == States.lock_1) { lock_1(); }                    //location 6
        else if (myState == States.corridor_0) { corridor_0(); }            //location 7

        else if (myState == States.door_0) { door_0(); }                    //location 8
        else if (myState == States.ceiling_hole) { ceiling_hole(); }        //location 9
        else if (myState == States.window) { window(); }                    //location 10
        else if (myState == States.climb) { climb(); }                      //location 11
        else if (myState == States.sneeze) { sneeze(); }                    //location 12
        else if (myState == States.pick_nose) { pick_nose(); }              //location 13
        else if (myState == States.fall) { fall(); }                        //location 14
        
        else if (myState == States.door_1) { door_1(); }                    //location 15
        else if (myState == States.guard_0) { guard_0(); }                  //location 16
        else if (myState == States.fight) { fight(); }                      //location 17
        else if (myState == States.joke) { joke(); }                        //location 18

        else if (myState == States.door_2) { door_2(); }                    //location 19
        else if (myState == States.female_guard) { female_guard(); }        //location 20
        else if (myState == States.cloak_sneak) { cloak_sneak(); }          //location 21
        else if (myState == States.kiss_guard) { kiss_guard(); }            //location 22
        else if (myState == States.male_guard) { male_guard(); }            //location 23

        else if (myState == States.cell_1) { cell_1(); }                    //location 24
        else if (myState == States.love) { love(); }                        //location 25
        else if (myState == States.tunnel_0) { tunnel_0(); }                //location 26
        else if (myState == States.tunnel_1) { tunnel_1(); }                //location 27
        else if (myState == States.tunnel_2) { tunnel_2(); }                //location 28
        else if (myState == States.tunnel_3) { tunnel_3(); }                //location 29
        else if (myState == States.tunnel_4) { tunnel_4(); }                //location 30
        else if (myState == States.tunnel_5) { tunnel_5(); }                //location 31
        else if (myState == States.antechamber) { antechamber(); }          //location 32


        else if (myState == States.lycan_den) { lycan_den(); }              //location 33
        else if (myState == States.lycan_talk) { lycan_talk(); }            //location 34
        else if (myState == States.challenge) { challenge(); }              //location 35
        else if (myState == States.mirror_2) { mirror_2(); }                //location 36
        else if (myState == States.mirror_fight) { mirror_fight(); }        //location 37
        else if (myState == States.mirror_touch) { mirror_touch(); }        //location 38
        else if (myState == States.lycan_fight_0) { lycan_fight_0(); }      //location 39
        else if (myState == States.lycan_fight_1) { lycan_fight_1(); }      //location 40
        else if (myState == States.lycan_run_1) { lycan_run_1(); }          //location 41
        else if (myState == States.lycan_run_0) { lycan_run_0(); }          //location 42
        else if (myState == States.lycan_battle) { lycan_battle(); }        //location 43

        else if (myState == States.death) { death(); }                      //location 44
        else if (myState == States.freedom) { freedom(); }                  //location 45


        }   //void Update() - end





    void begin()
    {
        story.text = "\n" +
            "                                                           Welcome \n" +
            "                                                                  to \n\n" +

            "                                                       V  O  R  T  E  X" + "\n\n\n\n" +
            "                                        Press B to Begin your adventure";

        if (Input.GetKeyDown(KeyCode.B)) { myState = States.cell; }


        } //begin - end

    



    void cell()
    {

        if (dead) { LifeCounter(); dead = false; }      //reset the dead flag

        locationList[0] = true;                         //set flag as located
        LocationCounter();                              //update the screen

        story.text = "You are standing in a cold dark prison cell. You have been staring at the rough stone walls " +
            "longer than you care to remember. Slightly bored with your entertainment options you wish to escape.\n\n " +
            "Glancing around your cell you see a bed, a mirror, an iron barred door, an empty bowl and a small annoying bug " +
            "that refuses to be eaten." + "\n \n" +
            "Press B to investigate the Bed, M to look at the Mirror or D to investigate the Door.";


       
        
        
       // if (Input.GetKeyDown(KeyCode.B)) { myState = States.death; }

        if (Input.GetKeyDown(KeyCode.B)) { myState = States.sheets_0; }
        else if (Input.GetKeyDown(KeyCode.D)) { myState = States.lock_0; }
        else if (Input.GetKeyDown(KeyCode.M)) { myState = States.mirror; }

       

        } //cell - end


    void sheet_0()
    {
        locationList[1] = true;         //set flag as located
        LocationCounter();              //update the screen

        story.text = "You sit on your bed. You see sheets covered in bodily fluids and skank. " +
            "You are unsure if you created the awful cursed mess or a previous occupant did. You scratch your head. " +
            "Looking around you see nothing more of interest.\n\n" +
            "Press R to Rise and look back around cell.";


        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }

    }   // void sheet_0 - end


    void lock_0()
    {

        locationList[2] = true;         //set flag as located
        LocationCounter();              //update the screen

        story.text = "You study the door and attempt to open it. It is fastened tight with a heavy lock " +
            "made from unobtainium. You have no chance of forcing the lock open. " + 
            "Your heart sinks. You scratch your head, pick your nose " +
            "and fart. You feel slightly better.\n\n" +
            "Press C to look back around the Cell";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.cell; }

    }   // void lock_0 - end


    void mirror()
    {
        
        locationList[3] = true;         //set flag as located
        LocationCounter();              //update the screen
        

        story.text = "You look into the grimy mirror. " +
            "Something seems slightly off. You stare for a while transfixed. " + "\n" +
            "There appears to be a strange shimmering around your reflection. " +
            "Your brow furrows in confusion. " + 
            "Knocking you off your feet with surprise, " +
            "your reflection winks back at you. Still startled you get back on your feet.\n \n " +
            "Press C to look back around the Cell or M to touch the Mirror.";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.cell; }
        else if (Input.GetKeyDown(KeyCode.M)) { myState = States.cell_mirror; }

    }   // void mirror - end

    void cell_mirror()
    {

        locationList[4] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "You are once again knocked to the floor. " +
            "Your head hurts and you tremble with adrenaline. " +
            "Stench fills your orcish nostrils and your underwear feels " +
            "wet, warm and squishy. Your own aromatic odour forces you " +
            "back to your feet. Things look different somehow. " +
            "You gather yourself, get back to your feet and gingerly look back " +
            "into the mirror. You see an empty cell. " +
            "You do not see yourself.\n\n" +
             "Press B to view the Bed or press L to view the door Lock";

        if (Input.GetKeyDown(KeyCode.B)) { myState = States.sheets_1; }
        else if (Input.GetKeyDown(KeyCode.L)) { myState = States.lock_1; }

    }   // void cell_mirror - end


    void sheet_1()
    {

        locationList[5] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "You see crisp clean white bed sheets. They look inviting " +
            "but you are a stinking mess. Your brain strains in confusion.\n \n" +
            "C to view your Cell";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.cell_mirror; }

    }   // void sheet_1 - end


    void lock_1()
    {

        locationList[6] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "The lock seems to be made from spagetti and meatballs. " +
            "Keeping a hand on your meatballs you unwind the spagetti and feed your face " +
            "with this tasty treat. \n\n" + "Midway through your second chomp a metallic clank echoes " +
            "around the cell. The door swings open. Above you the air shimmers black.\n\n" +
            "Press W to Walk through the door or press J to Jump upwards";


        if (Input.GetKeyDown(KeyCode.W)) { myState = States.corridor_0; }
        else if (Input.GetKeyDown(KeyCode.J)) { myState = States.death; }

    }   // void lock_1 - end



    void corridor_0()
    {

        locationList[7] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "A passageway stretches away from you with doors on either side. " +
            "Each door has been crudely marked with a symbol." + "\n\n" +
            "After a few moments your ace intellect and powers of deduction breaks the code." +
          
            "\n\n" +
            "Press R to enter the Rock door, P to enter the Paper door or S to enter the Scissors door";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.door_0; }
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.door_1; }
        else if (Input.GetKeyDown(KeyCode.S)) { myState = States.door_2; }


    }   // void corridor_0 - end



    void door_0()
    {

        locationList[8] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Abound with stale urine and mature faecies this place seems to be a literal dumping ground. " +
             "You gag so hard your stomach relieves itself of its recently acquired meatballs and spagetti. " + 
             "Nice . . . , you think dryly. " + 
             "Wiping your mouth on your sleve you bravely open your eyes again. " + "\n\n" +
             "Your watery eyes focus on a window at the far side of the comfort stop. " +
             "With tunnel vision you wade though the digested vittles and try to open the window. " +
             "You force it open. Life replenishing fresh air rushes in making you light headed. " + "\n\n" +


            "Press W to look out of the Window, press P to return to the Passageway";

        if (Input.GetKeyDown(KeyCode.W)) { myState = States.window; }
        else if (Input.GetKeyDown(KeyCode.P)) { myState = States.corridor_0; }


    }// void door_0 - end


    void window()
    {

        locationList[9] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "As you lean out of the window vertigo buckles your legs. Your grip tightens. " +
            "The building, carved out from a section of a mountain, stretches hundreds of floors below you. You see no way down. " + 
            "Above, almost close enough to touch, the building penetrates cloud. " + 
            "Just above your open window a sturdy pipe flows vertically up the building. " + 
            "Tracing its path, a few floors up, you see the pipe passes another open window." + 
            "You look down again and feel a strange compulsion to jump" + "\n\n" +

            
            "Press C to Climb the pipe, press J to Jump";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.climb; }
          else if (Input.GetKeyDown(KeyCode.J)) { myState = States.fall; }
          


    }// window() - end



    void climb()
    {

        locationList[10] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "You raise your orcen bulk to the pipe with the grace of freestyling baby elephant. " + 
           "'Undur Kurv!' (loosely translated as 'Fat Whore'), its cold out here, you complain. " + 
           "As you feed the pipe hand over hand the bracing cold air pinballs in your nostrils. " +  
           "Each step up the pipe only intensifies the itching in your cavernous bogie bank. " +  
           "Your concentration wavers." + "\n\n" +
            
           "Press P to Pick your nose, press I to Ignore the Itching and continue climbing";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.pick_nose; }
        else if (Input.GetKeyDown(KeyCode.I)) { myState = States.sneeze; }


    }//cimb() - end



    void sneeze()
    {

        locationList[11] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "You carry on climbing fighting the temptation to scratch your itching nostrils. " +
            "You single mindedly power your way towards the open window. As you reach to grasp the " + 
            "recessed frame your toes curl and you involuntarily draw a lung filling capacity of breath. " + 
            "Gritting your teeth and clenching your jaw, you begins to tremble and quiver. " + "\n\n" +
            "Time slows to a crawl as your body ejects the contents of its nostrils propelling you from the pipe." +
            "\n\n" +
            "Press O to Open your eyes";

        if (Input.GetKeyDown(KeyCode.O)) { myState = States.fall; }


    }//sneeze() - end





    void pick_nose()
    {

        locationList[12] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Anchoring yourself with your knees you thrust a ham-fisted finger at your snout. " + 
            "Frenzied pickin' 'n' flickin', clears your trunk of its excess baggage and the fizzing in " +
            "your muzzle calms. You are Zen, at one with the world, lord and master of bogiekind. " + "\n" +
            "You carry on scaling the pipe. Cautiously you manouvre your sylph-like frame through the open window." + 
            "" + "\n\n" +
            "You survey your surroundings as you catch your breath. The area appears to be a very long and thin junk room. " + 
            "Random items have been lovingly launched into large heaps from a door at the far side of the room." + "\n\n" +

            "Press W to Walk in the direction of the door ";

        if (Input.GetKeyDown(KeyCode.W)) { myState = States.ceiling_hole; }
     

    }//pick_nose() - end




    void fall()
    {

        locationList[13] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Frigid damp air rushes past you as you plummet. Self preservation lay waste to shocked confusion " +
            "as you struggle to metamorphose into a soaring eagle. " +
            "Your thrashing calms as you concede your inability to miraculously sprout wings. " + "\n\n" +
            "Your whole life does not flash before your eyes, however, the ground does." + "\n\n" +

            "Morgoth stands, arms outstretched, beckoning you home to the deep caves of the blue mountain." +  "\n\n" +
            
            "Press C to Continue";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.death; }


    }//fall() - end






    void ceiling_hole()
    {

        locationList[14] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Detritus under foot pitches you into a groggy meander. " +
            "As your face becomes more acquainted with the contents of the floor, the now familiar aroma of the prison " + 
            "toilet grows stronger. You continue to move forward crawling and climbing around obstacles in your path. "  +
            "Mountainous junk gives way to scattered old papers, breaking the ankle-twisting drudgery. " +
            "Directly behind you, shimmering in an obsidian light, the air crackles and pops. " +  
            "Bounding toward the door your feet break through the rotten floor. " + 
            "Your body sways as you hang by your fingers from the hole in the floor. "+
            "The shimmering light is upon you." + "\n\n" +          
            "Press R to Release your grip or E to be Engulfed by the light";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.door_0; }
        else if (Input.GetKeyDown(KeyCode.E)) { myState = States.cell; }


    }//ceiling_hole() - end





    void door_1()
    {

        locationList[15] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "The iron-studded wooden door thuds ominously shut behind you. " +
            "Echoes resonate around the pitch black room. You feel an uneasy presence." + "\n\n" +
            "Press W to Walk deeper into the room , press P to return to the Passageway";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.corridor_0; }
        else if (Input.GetKeyDown(KeyCode.W)) { myState = States.guard_0; }


    }//door_1() - end



    void guard_0()
    {

        locationList[16] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Arms outstretched you zombie forward into the darkness. Small lights flicker in the distant corner. " +
            "Spellbound you home in. As you approach, the flickering slows to rest, illuminating the cavern. " +
            "Your body recoils. A shudder rattles your spine. You are unable to look away. " +
            "You crane your neck tracking the lights as they levitate perfectly paralell. " + 
            "A slow guttural voice speaks from behind the now brightening eyes. " +
            "'Is it playtime already Orc?' Motionless with fear you answer, 'Errrr'. " + "\n" +
            "Behind the eyes a staccato voice responds, 'For eaons I fought alongside your Orc forefathers. " +
            "Their bravery earns you a choice. " +
            "CHOOSE NOW OR DIE ORC!'" + "\n\n" +

            "Press F to Fight, Press J to tell a Joke";
            

        if (Input.GetKeyDown(KeyCode.F)) { myState = States.fight; }
        else if (Input.GetKeyDown(KeyCode.J)) { myState = States.joke; }


    }//guard_0() - end



    void fight()
    {

        locationList[17] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "The death threat bulldozes your anger instantly boiling fear away. " + 
            "'Swobu' ('As you command') you mutter through gritted teeth. " +
            "Bellowing your clans battle cry you plow forward 'Lok-Tar Ogar! ('Victory or death'). " +
            "As you launch, pin pointed pupils dilate in the creatures eyes. The black-holed eyes drill your mind. Its mental " + 
            "gravity well accelerates you to an uncontrollable drag. " +
            "'Grombolar' ('Bowels of the giant'), you curse thrashing in random directions. " +
            "As you rag doll you way onward under the corruptors control a whisper trickles from your bleeding lips. " +
            "'A tome of jokes may be of use right now. '" +
            "A whip-cracking limb breaks the sound barrier as the corruptor pummels you repeatedly. Your vision dims as you relax." +
            "" + "\n\n" +
             
             "Press C to Continue";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.death; }


    }//fight() - end




    void joke()
    {

        locationList[18] = true;         //set flag as located
        LocationCounter();               //update the screen


        story.text = "You tell your joke.     " +
            "Two young orcling brothers decide it's time they grew up. 'I say we should start swearing now', says one of the orclings. " +
            "'Indeed bruv', the younger brother replies. " + "At breakfast mother orc asks, 'What would you like to eat?' " +
            "Without hesitation the older orcling says, 'Squashed toad on toast, bitch!'. " +
            "Furious, she backhands him, sending him flying. " +
            "'And what would you like?' she asks turning to the younger orcling. " +
            "'I don't know but it won't be the feckin' squashed toad on toast!'       " + 
            "Booming machine-gun laughter punches your guts as the eyes shimmer. " + 
            "The avalanche of laughter calms and you hear the disjointed words for the last time. " +
            "'Wise Orc, your life is your own.' A portal appears before you." +  "\n\n" +
            
            "Press P to enter the Portal";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.corridor_0; }


    }//joke() - end






    void door_2()
    {

        locationList[19] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Lush decorative fabrics adorn the floor and walls. Ornately carved heavy oak furniture " +
            "sits planted in position. " +
            "A scent of sweet pine, suspended in a cloud of steam, drifts towards you from an adjacent doorway. " +
            "A female guards uniform lays in stepping stones mapping a route to the bathroom. " +
            "A tuneful hum echoes from the same direction. Footsteps accompany the ditty, now increasing in volume, " +
            "as it closes toward the bathroom doorway. " +
            "A stride away a large wardrobe stands ajar." +

            "\n\n" +
            
            "Press H to Hide in the wardrobe, Press P to return to the Passageway ";

        if (Input.GetKeyDown(KeyCode.H)) { myState = States.female_guard; }
        else if (Input.GetKeyDown(KeyCode.P)) { myState = States.corridor_0; }



    }//door_2() - end





    void female_guard()
    {

        locationList[20] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "You peer through the cracked open wardrobe door. " +
            "A female orc, drying her hair, wanders naked into the room still humming. " + 
            "Your legs buckle and your heart palpitates forcing you to steady yourself. " +
            "'Tru Ob Zan' ('Brain of Elf ') you chastise yourself. " +
            "The female, catlike, stops in her tracks ceasing the hum. " +
            "Your eyes dart around the wardrobes contents for cover. " +
            "A full sized cloak,  pulsating in a familiar shimmer, lays in a bundle at the rear of the wardrobe." +
            "The female, still naked, turns on her heels and marches upon the wardrobe. " +
            "You are torn between lust and self preservation." +

            "\n\n" +
                        
            "Press G to Gird your loins, press C to Cower under the cloak.";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.cloak_sneak; }
        else if (Input.GetKeyDown(KeyCode.G)) { myState = States.kiss_guard; }


    }//female_guard() - end





    void cloak_sneak()
    {

        locationList[21] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "You clamber for cover under the cloak. 'Zelinors snout, what happened to " +
            "the infamous orc chieftain? Clan Lord of Lords, Harbinger of Death, Crusher of Hearts, " +
            "Breeder Prolific. More like Wetter of Pants, cowering like a pointy-eared berry munching elf!', "  +
            "you think frustrated, in more ways than one. " +
            "The female, breaths away, whispers in an ancient tongue. The cloak constricts in a crushing silhouette. " +
            "You hear the wardrobe doors burst open. Another command spews you from the wardrobe to land in a heap " + 
            "at the feet of the female orc. You look up. 'You know, it would have saved a lot of time if you just kissed me " +
            "Orclord, but I do appreciate the sport all the same.' she chuckles winking." + 
 
            "\n\n" +
            "Press R to Rise . . . to the occasion";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.kiss_guard; }
        

    }//cloak_sneak() - end





    void kiss_guard()
    {

        locationList[22] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Passion brutely bursts forward in a violent embrace." +
            "'You hide as silently as a marauding cave troll' she gasps between kisses, " +
            "'and I could smell you from the bathroom'. " + "'I am Lucricia' she says checking her passion grudgingly. " +
            "'Lucricia?' You focus. 'Shaman Lucricia of Kazim-Var?'. 'The same' she responds. 'I was sent here over a year ago by my clan " +
            "to play my part in your freedom. It was I who enchanted the mirror in your cell transporting you through dimensions and " +
            "bending reality. I have been undercover as a guard. There is something else I need to tell you. " +
            "After your exile, clan after clan fell to Necropolis. In absentia we were bonded to strengthen my powers. " + 
            "Consider this your honeymoon husband'." +


             "\n\n" +
            "Press G to Gulp";

        if (Input.GetKeyDown(KeyCode.G)) { myState = States.male_guard; }

       
    }//female_guard() - end




 

    void male_guard()
    {

        locationList[23] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "'Dragon got your tongue?' she quips playfully trying to hide her girlish guile. " +
            "'As I've been incarcerated, I think the clan business can wait', you bark leading Lucricia to the bathroom. " +
            "As you stand still fully dressed in the steaming water, she whispers, 'Throm'ka' (a warm greeting). " +
            "You counter cheekily with 'Gol'kosh' ('By my axe'). " +
            "You both errupt in childish laughter, a sensation long forgotten. " + "\n\n" +
            "As you embrace a hammering pounds the oak door. 'Mirdautas vras' ('It's a good day to kill') she remarks coldly. " +
            "'Not today', you counter, 'Follow my plan'.\n " + 
            "She opens the heavy oak door. The troop of guards drag your wet trussed slab of meat away." + 
             
            "\n\n" +
            
            "Press C to Continue";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.cell_1; }
     

    }//male_guard() - end




    void cell_1()
    {

        locationList[24] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "The foul smelling skank-rot would be a dead giveaway to even the dumbest of orcs that they were underground. " + 
            "Daydreaming you wondered if the inquisitors placed bottles of 'Harpies Purse' close by as part of the torture regime. " +
            "Procured by the cartload, in such concentrations, it was as lethal as Griffins talons. " +
            "As you roll over in your cells bed you realise that the smell was actually emanating from your plate of food. " +
            "Someone had seen fit to give you an extra 'portion' on the side. Buoyant mood in toe, your hunger abruptly turns tail and runs. " +
            "Your mind resumes its focus on Lucricia refusing to fall for mental diversions. " +
            "As though tumbling from your brain a voice quips 'Not hungry my husband?' " +
            "Dressed in uniform Lucricia opens the cell door." +
            "\n\n" +
            "Press E to Exit the prison cell";

        if (Input.GetKeyDown(KeyCode.E)) { myState = States.love; }


    }//cell_1() - end

    



    void love()
    {

        locationList[25] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "'Now we follow MY plan', she says steely-eyed while handing you a bundle of guards clothes. " +
            "'Amal shufar, at rrug' ('Where there's a whip, there's a way') you reply grinning broadly. " +
            "'Playtime is over Husband' she snaps, adding '... for now' to cushion the blow. " +
            "Scolded you quickly dress, loosly buckling your feet into the tight fitting sandals. " +
            "'You will have to continue your escape through the tunnel alone. I still have clan business to finish. " +
            "If my plan plays true I will see you again before the day is out', she says as if reading from a script. " +
            "Confident in your newly acquired wife you nod respectfully slowly and reply with 'Garrosh' ('Warrior Heart'). " +
            "'Go!', she screams through gritted teeth. Smiling you answer 'Yes dear. On my way.'" +
            
            "\n\n" +
            
            "Press T to Turn and burn into the tunnel";

        if (Input.GetKeyDown(KeyCode.T)) { myState = States.tunnel_0; }

    }//love() - end



    void tunnel_0()
    {

        locationList[26] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "As you enter the narrow crawl space you see, suspended above the entrance, " +
            "large rock boulders trussed up with wooden planks. Under a pile of smaller loose rocks you find a long " +
            "coil of rope acting as a trigger to the rock trap. So this is what Lucricia has been doing on her " +
            "days off, you think smirking. You carefully extend the rope deeper into the tunnel. Without doubting " +
            "Lucricia's explanation of things, after all it was so far-fetched it had to be true, you yank the rope. " +
            "Head splitting noise and clouds of grit peppered air engulf you. " +
            "When the dust settles enough to see you survey the way forward." + "\n\n" +
            "The tunnel forks left and right. " + "\n\n" +
                
            "Press L to take the Left fork, Press R to take the Right fork.";

        if (Input.GetKeyDown(KeyCode.L)) { myState = States.tunnel_1; }
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.tunnel_5; }

    
    }//tunnel_0() - end





    void tunnel_1()
    {

        locationList[27] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "As your eyes adjust to your surroundings you notice areas of the tunnel glowing. " +
            "Lights, scattered like jewels in the heavens, grow dimmer as you walk onward. " +
            "More of the Shaman's magic, you wonder, or just a natural phenomenon? " +
            "Either way the glow proves useful while it lasts. As the lights become sparse, navigation slows. " +
            "Stationary, concentrating your vision, you just about make out an exit. You continue on. " +
            "In the ground to the side of you a tunnel dives deeper. Directly forward a passageway veers sharp right. " +
              
            "\n\n" +
            
            "Press T to enter the Tunnel, Press P to take the Passageway.";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.tunnel_4; }
        else if (Input.GetKeyDown(KeyCode.T)) { myState = States.tunnel_2; }
        

    }//tunne_1() - end



    void tunnel_2()
    {

        locationList[28] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Reinforced leather of your uniform cushions your ample rear " +
            "from the scree of the incline as you slide feet first into the dark. " +
            "Parental warnings to 'look before you leap' had never curbed your tendency to literally " +
            "jump both feet forward, time after time. " +
            "Life was too short to worry about consequence. Even though this philosophy had " +
            "led to your recent incarceration, you were true to your nature. You lived life on your own terms. \n" +
            "As the tunnel levels out your slide comes to an abrupt end. " +
            "A short distance from your entry slide there is a hole in the floor. You look through the hole and see a room." +

            "\n\n" +
            "Press S to Scramble back up the scree or D to Drop through the hole in the floor. ";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.tunnel_1; }
        else if (Input.GetKeyDown(KeyCode.D)) { myState = States.antechamber; }
        
    }// tunnel_2 - end


    void antechamber(){

        locationList[29] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "You enter an antechamber. A few small symbols are carved into the walls. " +
                "An arms length away a ladder climbs a vertical shaft. " +
                "Above your head, too far to reach, there is a hole in the ceeling. " +
                "At the end of the antechamber a large stone tablet, covered from top to bottom with symbols, disguises an exit." + "\n\n" +


                "Press L to climb the Ladder or H to take the Hidden exit. ";

            if (Input.GetKeyDown(KeyCode.L)) { myState = States.tunnel_3; }
            else if (Input.GetKeyDown(KeyCode.H)) { myState = States.lycan_den; }


        }//antechamber() - end


    
    void tunnel_3(){

        locationList[30] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Your area, no more than 5 cave trolls square, is lined with planks and beams. " +
            "Your wooden box appears to be little more than a junction to connect tunnels. " +
            "In the centre of the room a ladder descends a vertical shaft into darkness. Reaching between your toes " +
            "you pluck out a few stones and drop them down the shaft. The stones, rattling the ladder, thud reassuringly " +
            "as they reach their unseen destination. " +
                     
             
            "\n\n" +
            
            "Press D to Descend the ladder, Press F to return through the Framed doorway.";

        if (Input.GetKeyDown(KeyCode.D)) { myState = States.antechamber; }
        else if (Input.GetKeyDown(KeyCode.F)) { myState = States.tunnel_4; }




    }//tunne_3() - end


    void tunnel_4()
    {

        locationList[31] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Wide and flat the area is densely covered with organic moss. " +
            "Devoid of colour the translucent plant life covers the ground. The ethereal " +
            "carpet cushions you as you walk, respite to your aching limbs. " +
            "Life sustaining mountain water seeps through crevices wandering the rock walls . " +
            "You stop to quench your thirst. Feeling slightly more orclike you consider your options. " + "\n" +
            "On the western wall you see a faint glowing tunnel opening. Straight ahead, " +
            "where the plant life ends, a framed doorway is visible. " +            
            
            "\n\n" +
            
            "Press W to take the Western tunnel, D to take the framed Doorway or F to squeeze back through the Fissure .";

        if (Input.GetKeyDown(KeyCode.W)) { myState = States.tunnel_1; }
        else if (Input.GetKeyDown(KeyCode.F)) { myState = States.tunnel_5; }
        else if (Input.GetKeyDown(KeyCode.D)) { myState = States.tunnel_3; }



    }//tunne_4() - end



    void tunnel_5()
    {

        locationList[32] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Entering the area you involuntarily head-butt a stalactite covered ceiling. " +
            "'Grombolar' ('Bowels of the giant') you curse bleeding profusely. " +
            "You stumble forward like a drunken ping-feng crossbreed. As your sandal is punctured by a stalagmite " +
            ",sneakily hiding in plain sight, you add 'Dae'mon' ('Twisted soul demon'), to the barrage of expletives. " +
            "You hold station attempting to outfox your inanimate surroundings. 'This is worse than the time I fell off a " +
            "cliff into a herd of rutting Hippogriffs', you think feeling sorry for yourself. 'On reflection, maybe not', " +
            "you correct yourself, remembering the embarassing details. Moving tentatively your bleeding reduces to a trickle. " +
            "The tunnel narrows to a vertical fissure. " +
            
            "\n\n" +
            "Press S to Suck in your gut and squeeze through the fissure.";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.tunnel_4; }
    

    }//tunne_5() - end





    void lycan_den(){

        locationList[33] = true;         //set flag as located
        LocationCounter();              //update the screen

        story.text = "An uneasy feeling gathers momentum as you struggle to recollect the symbols, " +
            "your gut tells you, you have seen before. " +
            "You zig-zag for quite a distance but make little progress. " +
            "Small twigs, dried leaves and linen rags lay in carefully arranged piles. \n" +
            "Recollection returns like a haymaker to the head. \nThe 'symbols' are a warning and the 'piles' are beds. " +
            "Now wide-eyed and dangerous a single phrase escapes your mouth, 'Wor'gol' ('Wolf Home'). " +
            "Looking up from the nests you realise you were only half correct. " +
            "Towering before you stands Ulfred, Master of the Lycanthrope." + "\n\n" +

            "Press R to turn tail and Run, Press I to gain the Initiative and attack, " +
            "Press T to Talk to Ulfred like the sensible orc you are. ";
            
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.lycan_run_0; }
        else if (Input.GetKeyDown(KeyCode.I)) { myState = States.lycan_fight_0; }
        else if (Input.GetKeyDown(KeyCode.T)) { myState = States.lycan_talk; }


    }//lycan_den() - end




    void lycan_talk(){

        locationList[34] = true;         //set flag as located
        LocationCounter();              //update the screen

        story.text = "Convincing yourself that discretion is the better part of valour, more accurately " +
            "realising you have no chance to outrun a werewolf, you bravely remain frozen where you stand. " +
            "Like a cat watching a bird, the lycan seems to be more entertained than unnerved. " +
            "'Dranosh' ('Heart of Draenor'), 'What type of thing looks upon a fully grown Orc Warlord as a play thing', " +
            "you wonder while you still had the chance. A grudging admiration replaces your shock and fear. " + "\n" +
            "'You have one word to save your putrid green hide.', whispers the lycan like a kettle coming to the boil. " +
            "Snarling and dribbling he adds, 'My cubs are a razor paw away.' Without a second thought you pluck a stick " +
            "from the lycans bed at your feet. Waving the stick at arms length you say 'errr .... Fetch?' " +           
            "\n\n" +
            
            "Press H to Hold your breath while pulling your cutest face.";

        if (Input.GetKeyDown(KeyCode.H)) { myState = States.challenge; }
 
       
    }//lycan_talk() - end

  


    void challenge()
    {

        locationList[35] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "'THAT'S TWO WORDS!' Ulfred blasts, close enough that you smell his last meal. " +
            "Dragging the ice studded words Ulfred adds 'Try again ... Orc'. This time you try the direct approach," +
            "'My Wife sent me?'. The lycanthrope rotates about his hips winding up for the strike. " +
            "As your situation becomes slightly less favourable you add 'Lucricia, Lucricia sent me ... My wife is Lucricia, " +
            "WE ARE MARRIED AND EVERYTHING!' Stopping midswing the werewolf mocks, 'You? You ... are the Great Clanchief? " +
            "Not much to look at are you? I imagined something, um, taller?'. Feeling like you had already pushed your luck you bite your tongue. " + 
            "'Okay Lord of Orclords, face a fear or fight the pack?', Ulfred demands smiling from fluffy ear to fluffy ear. \n\n " +
            "Press F to face a fear, Press P to fight the Pack";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.lycan_fight_0; }
        else if (Input.GetKeyDown(KeyCode.F)) { myState = States.mirror_2; }




    }//lycan_decline() - end


    void mirror_2()
    {

        locationList[36] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "'So you are brighter than you look', concedes the werewolf. " +
            "Now calm, Ulfred points a massive-knuckled extended finger. 'That way', he says. " +
            "Leaving you standing he adds, 'Come'." +
            "You follow Ulfred deeper into the werewolfs lair passing lycanthrope of all ages and sizes. " +
            "The wolfpack is ten fold larger than you had imagined. " +
            "Taking three steps for a single one of Ulfreds you struggle to keep pace. " +
            "As you walk you notice fewer families. Much larger battle worn warriors gather in groups watching your every move. " +
            "Your final turn leads you to another large stone tablet. With a mixture of chanting and howling Ulfred moves " +
            "the tablet to reveal a shrine room. On the far stone wall, surrounded by a whirling black vortex, is a familiar looking mirror. " +
            "Ulfred pushes you in, sealing the entrance." +
            "\n\n" +
            "Press A to Approach the mirror.";

        if (Input.GetKeyDown(KeyCode.A)) { myState = States.mirror_touch; }
     



    }//mirror_2() - end



    void mirror_touch()
    {

        locationList[37] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "The rhythmic pulse of the vortex pushes and pulls the all too familiar " +
            "shimmering light in and out of the shrine room. The walls are daubed with paintings. " +
            "Images, new and ancient, tell a tale of places and creatues known to you. " +
            "Remembering that Lucricia used her shaman magic on the mirror in your cell to help you escape, " +
            "you cautiously approach the mirror at the centre of the spinning vortex. " +
            "Tendrils reach out from the spinning mass grabbing your arms and legs pulling you toward the mirror. " +
            "Instinctively you resist the force pulling upon you. When your brain catches up, you ask yourself " +
            "one simple question. Fight or Submit? " +
            "" +
            "\n\n" +
            "Press F to Fight the grasp of the vortex or Press S to Submit to the mirror.";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.freedom; }
        else if (Input.GetKeyDown(KeyCode.F)) { myState = States.mirror_fight; }


    }//mirror_touch() - end



    void mirror_fight()
    {

        locationList[38] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "With a stiff back and braced legs you fight against the vortex. "  +
            "Pulling against the tendrils in a reclined tug of war you lose and gain ground in equal measure. " +
            "As the strength-sapping struggle continues, your feet slide forward on the sandy floor. \n" +
            "The boundless energy of the vortex relentlessly pulls upon you. Losing more ground " +
            "you realise that you are no longer being pulled toward the mirror but into its surrounding vortex. " +
            "As your body loses the fight, your mind attempts to compensate. Now, mind fully focused, you understand that " +
            "the vortex is not surrounding the mirror. The mirror is suspended inside the vortex and is using its energy.  " +
            "'Lucricia's gateway', you sigh as you are pulled headlong into the swirling mass." +
                    
            "\n\n" +
            
            "Press S to Sigh and go vortex surfing.";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.cell; }


    }//mirror_fight() - end




    void lycan_fight_0()
    {

        locationList[39] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Bouldered fists strike in unison uppercutting Ulfreds enormous jaw." +
            "Your signature move, know as Tanfuksham (Almighty) by your Warband, rocks the enormous lycanthrope " +
            "backward slightly off balance. Thinking the time for words has passed you follow "  +
            "your surprise strike with Bashkaum (Alliance), the two footed flying stomp. Your attempt to topple " +
            "Ulfred succeeds but with a slightly negative outcome. You lay horizontal, staring at the pretty ceiling on top of the lycan. " +
            "A deafening howl pummels your eardrums as you ward off the flailing limbs of your assailant. " +
            "In response to their master the wolfpack howls in a terrifying crescendo. They are close." +
            "\n\n" +
            "Press F to try and Flee the pack, Press C to continue fighting Ulfred.";

        if (Input.GetKeyDown(KeyCode.C)) { myState = States.lycan_fight_1; }
        else if (Input.GetKeyDown(KeyCode.F)) { myState = States.lycan_run_1; }

    }//lycan_fight_0() - end




    void lycan_fight_1()
    {

        locationList[40] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Ulfred backhands you, open-pawed, to the left temple. Your head jerks back violently. " +
            "As your head rebounds you take a blow to the right temple. You are launched in a lazy sweeping arc into the tunnel wall. " +
            "In child-like defiance you growl at each other as you both rise. " +
            "A tidal wave of howls bounce all around you as the pack makes its last few turns. " +
            "Your bloody battle resumes. The wolfpack pours into the tunnel. With a defiant snarl Ulfred keeps his subordinates at bay. " +
            "This, you realise, is his fight. \n" +
            "Blinding white light fills the tunnel as a silent explosion floors its inhabitants. Through the dust a familar voice echoes," +
            "'Hello boys!' Clutching a mirror to her breast Lucricia bathes you both in shimmering obsidian light. " +
            "Your life is no longer your own." +
            "\n\n" +
            "Press A to Accept your fate.";

        if (Input.GetKeyDown(KeyCode.A)) { myState = States.freedom; }

    }//lycan_fight_1() - end






    void lycan_run_0()
    {

        locationList[41] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "The sight of the werewolf towering over you, remains burned to the back of your minds eye, " +
            "as you attempt to break the orc speed record. 'Rutting Chimeras he got close! Why didn't I hear him? " +
            "For the love of Grumosh, It's not like he was easy to miss!', you chastise in a barrage of self-scolding. " +
            "Daring not to look behind, you continue to drive your significant bulk forward. " +
            "In powerful loping strides, using the floor, wall and ceiling as launchpads, Ulfred pushes the tunnel behind him. \n " +
            "As you move through random passages, tunnels and rooms you lose all sense of direction. " +
            "Darting into a stone room you realise it's a dead end. A cold chill " +
            "rattles your spine as you turn to retrace your steps . Your enemy is upon you. " +
            "" +
            "\n\n" +
            "Press P to Pray for mercy or Press B to Barricade the door.";

        if (Input.GetKeyDown(KeyCode.P)) { myState = States.death; }
        else if (Input.GetKeyDown(KeyCode.B)) { myState = States.lycan_battle; }

    }//lycan_run_0() - end






    void lycan_run_1()
    {

        locationList[42] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Rolling from Ulfred you pivot around your arm and push a fisted thumb deep into the werewolf's eye socket. " +
            "The little voice of experience inside your head says tersely, 'RUN!' " +
            "Throwing behind you rocks, wood and anything else you can get your hands on, you run from Ulfred as he howls in agony. " +
            "Checking over your shoulder as you make your first turn you see the wolfpack swarm on their masters position. " +
            "\n" +
            "Using your 'Thumb of Destruction' you gain a tunnels seperation from the lycanthrope. " +
            "The all encompassing howl of the pack elevates your heart rate, pumping precious adrenaline around your exhausted body. " +
            
            "As you enter a stone prison cell you realise you are trapped. The bounding exodus of the pack is upon you." +
            "\n\n" +
            "Press B to Barricade the door or Press G to morph into a god.";

        if (Input.GetKeyDown(KeyCode.B)) { myState = States.lycan_battle; }
        else if (Input.GetKeyDown(KeyCode.G)) { myState = States.death; }

    }//lycan_run_1() - end





    void lycan_battle()
    {

        locationList[43] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Time slows as you barricade the heavy oak door. " +
            "Granite rock slabs, used as anchors for iron chains, get repurposed as doorstops. " +
            "A poor defense but they will serve to buy you time. " +
            "Your barricade shudders, mimicing your own terror, as the arsenal of the werewolves pound it. " +
            "Massive leg as leverage, you rip the remaining rusty chains from the walls. " +
            "You wind chain around each hand, leaving enough free to use as a lash. " +
            "In a violent percussive explosion your barricade is breached. The lycan pour into the cell like swarming ants " +
            "surrounding you on all sides. A blood-curdling howl silences the pack as Ulfred lowers his head to clear " +
            "the doorway. The Alpha stands before you. " +
            "'You will not see out this day, Orcling' he whispers, eyes glistening and teeth bared. " +
            "The lycanthrope attack." +
            "\n\n"+
            "Press S to Swing your iron lashes or F to stand accepting Fate.";

        if (Input.GetKeyDown(KeyCode.S)) { myState = States.death; }
        else if (Input.GetKeyDown(KeyCode.F)) { myState = States.death; }

    }//lycan_battle() - end

    


    void freedom()
    {

        locationList[44] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "Warm summer sun and green mountain pasture greet you as you wake. " +
            "This green and pleasant land seems oddly perverse after your recent adventuring. " +
            "You take a few moments to adjust. \n" +
            "Did I actually make it out to freedom?, you ask yourself out loud. " +
            "Somewhere behind you a voice replies, 'Make it out?, Yes.' " +
            "Now get your stinking lazy hide out of the dirt. We have clans to unite, Necropolis to defeat and orclings " +
            "to make. Does THAT answer your question about freedom husband?' " +
            "\n\n" +
            "THE END \n" +
            "-----------\n" +
            "Press R to Replay your adventure.\n" +
            "Note: New locations will increase your DISCOVERY counter!";

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }

    }//friendly_smell() - end


    void death()
    {

        locationList[45] = true;         //set flag as located
        LocationCounter();              //update the screen


        story.text = "\n\n" +
            
                    "              Y O U   H A V E   S U C C E S S F U L L Y   E S C A P E D \n" + 
                    "                           Y O U R   I N C A R C E R A T I O N ! \n\n" +
                    "                  U N F O R T U N A T E L Y   Y O U   A R E   D E A D.\n " +
                    "                 -------------------------------------------------" +
                    "\n\n" +
                    "                                Press R to Replay your adventure. \n\n" +
                    "\n\n" +

                    "Note: New locations will still increase the DISCOVERY counter!";

        dead = true;

        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }

    }//death() - end





    void LifeCounter() {

        life++;                                //increment life total
        incarnations.text = life.ToString();   //update the on-screen 'incarnations' counter
        }



    void LocationCounter(){
        
           places = 0;                                  //counter for discovered places
           int loop = 0;                                //loop counter
           int listLength = locationList.Length - 1;    //location total from array

            while (loop <= listLength)                  //loop through the array
               {                                   

                if (locationList[loop] == true)         //place discovered?     
                   {
                   places++;                            //increment counter if place discovered
                  
                    }       
                   loop++;                              //increment loop

                   }//while -end
                    
           discoveries.text = places.ToString();        //update the on-screen 'discoveries' counter
        
        }
        
    } //void Update() - end

//GitHub Test