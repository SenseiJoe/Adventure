using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using SHORT = System.Int16;
using USHORT = System.UInt16;
using LONG = System.Int64;
using ULONG = System.UInt64;


namespace AdventureCS
{
    partial class TheAdventure
    {

#if false
        private Dictionary<short,string> vTable = new Dictionary<short, string>();
#else
        private Dictionary<string,short> vTable = new Dictionary<string,short>();
#endif

        void InitVocabTable()
        {
            vTable.Add("\"spelunker today\"", MAGAZINE + VOCAB_OBJECT);
            vTable.Add("?", 51 + VOCAB_MSG);
            vTable.Add("above", 29);
            vTable.Add("abra", 50 + VOCAB_MSG);
            vTable.Add("abracadabra", 50 + VOCAB_MSG);
            vTable.Add("across", 42);
            vTable.Add("ascend", 29);
            vTable.Add("attack", KILL + VOCAB_VERB);
            vTable.Add("awkward", 26);
            vTable.Add("axe", AXE + VOCAB_OBJECT);
            vTable.Add("back", 8);
            vTable.Add("barren", 40);
            vTable.Add("bars", SILVER + VOCAB_OBJECT);
            vTable.Add("batteries", BATTERIES + VOCAB_OBJECT);
            vTable.Add("battery", BATTERIES + VOCAB_OBJECT);
            vTable.Add("beans", PLANT + VOCAB_OBJECT);
            vTable.Add("bear", BEAR + VOCAB_OBJECT);
            vTable.Add("bed", 16);
            vTable.Add("bedquilt", 70);
            vTable.Add("bird", BIRD + VOCAB_OBJECT);
            vTable.Add("blast", BLAST + VOCAB_VERB);
            vTable.Add("blowup", BLAST + VOCAB_VERB);
            vTable.Add("bottle", BOTTLE + VOCAB_OBJECT);
            vTable.Add("box", CHEST + VOCAB_OBJECT);
            vTable.Add("break", BREAK + VOCAB_VERB);
            vTable.Add("brief", BRIEF + VOCAB_VERB);
            vTable.Add("broken", 54);
            vTable.Add("building", 12);
            vTable.Add("cage", CAGE + VOCAB_OBJECT);
            vTable.Add("calm", CALM + VOCAB_VERB);
            vTable.Add("canyon", 25);
            vTable.Add("capture", TAKE + VOCAB_VERB);
            vTable.Add("carpet", CARPET + VOCAB_OBJECT);
            vTable.Add("carry", TAKE + VOCAB_VERB);
            vTable.Add("catch", TAKE + VOCAB_VERB);
            vTable.Add("cave", 67);
            vTable.Add("cavern", 73);
            vTable.Add("chain", CHAIN + VOCAB_OBJECT);
            vTable.Add("chant", SAY + VOCAB_VERB);
            vTable.Add("chasm", CHASM + VOCAB_OBJECT);
            vTable.Add("chest", CHEST + VOCAB_OBJECT);
            vTable.Add("clam", CLAM + VOCAB_OBJECT);
            vTable.Add("climb", 56);
            vTable.Add("close", LOCK + VOCAB_VERB);
            vTable.Add("cobbl", 18);
            vTable.Add("cobblestone", 18);
            vTable.Add("coins", COINS + VOCAB_OBJECT);
            vTable.Add("continue", WALK + VOCAB_VERB);
            vTable.Add("crack", 33);
            vTable.Add("crap", 79 + VOCAB_MSG);
            vTable.Add("crawl", 17);
            vTable.Add("cross", 69);
            vTable.Add("d", 30);
            vTable.Add("damn", 79 + VOCAB_MSG);
            vTable.Add("damnit", 79 + VOCAB_MSG);
            vTable.Add("dark", 22);
            vTable.Add("debris", 51);
            vTable.Add("depression", 63);
            vTable.Add("descend", 30);
            vTable.Add("describe", 57);
            vTable.Add("detonate", BLAST + VOCAB_VERB);
            vTable.Add("devour", EAT + VOCAB_VERB);
            vTable.Add("diamonds", DIAMONDS + VOCAB_OBJECT);
            vTable.Add("dig", 66 + VOCAB_MSG);
            vTable.Add("discard", DROP + VOCAB_VERB);
            vTable.Add("disturb", WAKE + VOCAB_VERB);
            vTable.Add("dome", 35);
            vTable.Add("door", DOOR + VOCAB_OBJECT);
            vTable.Add("down", 30);
            vTable.Add("downstream", 4);
            vTable.Add("downward", 30);
            vTable.Add("dragon", DRAGON + VOCAB_OBJECT);
            vTable.Add("drawing", DRAWING + VOCAB_OBJECT);
            vTable.Add("drink", DRINK + VOCAB_VERB);
            vTable.Add("drop", DROP + VOCAB_VERB);
            vTable.Add("dump", DROP + VOCAB_VERB);
            vTable.Add("dwarf", DWARF + VOCAB_OBJECT);
            vTable.Add("dwarves", DWARF + VOCAB_OBJECT);
            vTable.Add("e", 43);
            vTable.Add("east", 43);
            vTable.Add("eat", EAT + VOCAB_VERB);
            vTable.Add("egg", EGGS + VOCAB_OBJECT);
            vTable.Add("eggs", EGGS + VOCAB_OBJECT);
            vTable.Add("emerald", EMERALD + VOCAB_OBJECT);
            vTable.Add("enter", 3);
            vTable.Add("entrance", 64);
            vTable.Add("examine", 57);
            vTable.Add("excavate", 66 + VOCAB_MSG);
            vTable.Add("exit", 11);
            vTable.Add("explore", WALK + VOCAB_VERB);
            vTable.Add("extinguish", OFF + VOCAB_VERB);
            vTable.Add("fee", FOO + VOCAB_VERB);
            /*  vTable.Add( "fee"			  ,       1 + VOCAB_MSG		        );		*/
            vTable.Add("feed", FEED + VOCAB_VERB);
            vTable.Add("fie", FOO + VOCAB_VERB);
            /*  vTable.Add( "fie"			  ,       2 + VOCAB_MSG		        );		*/
            vTable.Add("fight", KILL + VOCAB_VERB);
            vTable.Add("figure", FIGURE + VOCAB_OBJECT);
            vTable.Add("fill", FILL + VOCAB_VERB);
            vTable.Add("find", FIND + VOCAB_VERB);
            vTable.Add("fissure", FISSURE + VOCAB_OBJECT);
            vTable.Add("floor", 58);
            vTable.Add("foe", FOO + VOCAB_VERB);
            /*  vTable.Add( "foe"			  ,       3 + VOCAB_MSG		        );		*/
            vTable.Add("follow", WALK + VOCAB_VERB);
            vTable.Add("foo", FOO + VOCAB_VERB);
            /*  vTable.Add( "foo"			  ,       4 + VOCAB_MSG		        );		*/
            vTable.Add("food", FOOD + VOCAB_OBJECT);
            vTable.Add("forest", 6);
            vTable.Add("fork", 77);
            vTable.Add("forward", 7);
            vTable.Add("free", DROP + VOCAB_VERB);
            vTable.Add("fuck", 79 + VOCAB_MSG);
            vTable.Add("fum", FOO + VOCAB_VERB);
            /*  vTable.Add( "fum"			  ,       5 + VOCAB_MSG		        );		*/
            vTable.Add("get", TAKE + VOCAB_VERB);
            vTable.Add("geyser", VOLCANO + VOCAB_OBJECT);
            vTable.Add("giant", 27);
            vTable.Add("go", WALK + VOCAB_VERB);
            vTable.Add("gold", NUGGET + VOCAB_OBJECT);
            vTable.Add("goto", WALK + VOCAB_VERB);
            vTable.Add("grate", GRATE + VOCAB_OBJECT);
            vTable.Add("gully", 13);
            vTable.Add("h2o", WATER + VOCAB_OBJECT);
            vTable.Add("hall", 38);
            vTable.Add("headlamp", LAMP + VOCAB_OBJECT);
            vTable.Add("help", 51 + VOCAB_MSG);
            vTable.Add("hill", 2);
            vTable.Add("hit", KILL + VOCAB_VERB);
            vTable.Add("hocus", 50 + VOCAB_MSG);
            vTable.Add("hole", 52);
            vTable.Add("hours", HOURS + VOCAB_VERB);
            vTable.Add("house", 12);
            vTable.Add("i", INVENTORY + VOCAB_VERB);
            vTable.Add("ignite", BLAST + VOCAB_VERB);
            vTable.Add("in", 19);
            vTable.Add("info", 142 + VOCAB_MSG);
            vTable.Add("information", 142 + VOCAB_MSG);
            vTable.Add("inside", 19);
            vTable.Add("inven", INVENTORY + VOCAB_VERB);
            vTable.Add("inventory", INVENTORY + VOCAB_VERB);
            vTable.Add("inward", 19);
            vTable.Add("issue", MAGAZINE + VOCAB_OBJECT);
            vTable.Add("jar", BOTTLE + VOCAB_OBJECT);
            vTable.Add("jewel", JEWELS + VOCAB_OBJECT);
            vTable.Add("jewelry", JEWELS + VOCAB_OBJECT);
            vTable.Add("jewels", JEWELS + VOCAB_OBJECT);
            vTable.Add("jump", 39);
            vTable.Add("keep", TAKE + VOCAB_VERB);
            vTable.Add("key", KEYS + VOCAB_OBJECT);
            vTable.Add("keys", KEYS + VOCAB_OBJECT);
            vTable.Add("kill", KILL + VOCAB_VERB);
            vTable.Add("knife", KNIFE + VOCAB_OBJECT);
            vTable.Add("knives", KNIFE + VOCAB_OBJECT);
            vTable.Add("l", 57);
            vTable.Add("lamp", LAMP + VOCAB_OBJECT);
            vTable.Add("lantern", LAMP + VOCAB_OBJECT);
            vTable.Add("left", 36);
            vTable.Add("leave", 11);
            vTable.Add("light", ON + VOCAB_VERB);
            vTable.Add("lock", LOCK + VOCAB_VERB);
            vTable.Add("log", LOG + VOCAB_VERB);
            vTable.Add("look", 57);
            vTable.Add("lost", 68 + VOCAB_MSG);
            vTable.Add("low", 24);
            vTable.Add("machine", VEND + VOCAB_OBJECT);
            vTable.Add("magazine", MAGAZINE + VOCAB_OBJECT);
            vTable.Add("main", 76);
            vTable.Add("message", MESSAGE + VOCAB_OBJECT);
            vTable.Add("ming", VASE + VOCAB_OBJECT);
            vTable.Add("mirror", MIRROR + VOCAB_OBJECT);
            vTable.Add("mist", 69 + VOCAB_MSG);
            vTable.Add("moss", CARPET + VOCAB_OBJECT);
            vTable.Add("mumble", SAY + VOCAB_VERB);
            vTable.Add("n", 45);
            vTable.Add("ne", 47);
            vTable.Add("nest", EGGS + VOCAB_OBJECT);
            vTable.Add("north", 45);
            vTable.Add("nothing", NOTHING + VOCAB_VERB);
            vTable.Add("nowhere", 21);
            vTable.Add("nugget", NUGGET + VOCAB_OBJECT);
            vTable.Add("null", 21);
            vTable.Add("nw", 50);
            vTable.Add("off", OFF + VOCAB_VERB);
            vTable.Add("office", 76);
            vTable.Add("oil", OIL + VOCAB_OBJECT);
            vTable.Add("on", ON + VOCAB_VERB);
            vTable.Add("onward", 7);
            vTable.Add("open", OPEN + VOCAB_VERB);
            vTable.Add("opensesame", 50 + VOCAB_MSG);
            vTable.Add("oriental", 72);
            vTable.Add("out", 11);
            vTable.Add("outdoors", 32);
            vTable.Add("outside", 11);
            vTable.Add("over", 41);
            vTable.Add("oyster", OYSTER + VOCAB_OBJECT);
            vTable.Add("passage", 23);
            vTable.Add("pause", SUSPEND + VOCAB_VERB);
            vTable.Add("pearl", PEARL + VOCAB_OBJECT);
            vTable.Add("persian", RUG + VOCAB_OBJECT);
            vTable.Add("peruse", READ + VOCAB_VERB);
            vTable.Add("pillow", PILLOW + VOCAB_OBJECT);
            vTable.Add("pirate", PIRATE + VOCAB_OBJECT);
            vTable.Add("pit", 31);
            vTable.Add("placate", CALM + VOCAB_VERB);
            vTable.Add("plant", PLANT + VOCAB_OBJECT);
            /*                vTable.Add( "plant"		      ,   PLANT2 + VOCAB_OBJECT	    );      */
            vTable.Add("platinum", PYRAMID + VOCAB_OBJECT);
            vTable.Add("plover", 71);
            vTable.Add("plugh", 65);
            vTable.Add("pocus", 50 + VOCAB_MSG);
            vTable.Add("pottery", VASE + VOCAB_OBJECT);
            vTable.Add("pour", POUR + VOCAB_VERB);
            vTable.Add("proceed", WALK + VOCAB_VERB);
            vTable.Add("pyramid", PYRAMID + VOCAB_OBJECT);
            vTable.Add("quit", QUIT + VOCAB_VERB);
            vTable.Add("rations", FOOD + VOCAB_OBJECT);
            vTable.Add("read", READ + VOCAB_VERB);
            vTable.Add("release", DROP + VOCAB_VERB);
            vTable.Add("reservoir", 75);
            vTable.Add("restore", RESTORE + VOCAB_VERB);
            vTable.Add("retreat", 8);
            vTable.Add("return", 8);
            vTable.Add("right", 37);
            vTable.Add("road", 2);
            vTable.Add("rock", 15);
            vTable.Add("rod", ROD + VOCAB_OBJECT);
            /*  vTable.Add( "rod"			  ,       ROD2 + VOCAB_OBJECT	        );  */
            vTable.Add("room", 59);
            vTable.Add("rub", RUB + VOCAB_VERB);
            vTable.Add("rug", RUG + VOCAB_OBJECT);
            vTable.Add("run", WALK + VOCAB_VERB);
            vTable.Add("s", 46);
            vTable.Add("save", SAVE + VOCAB_VERB);
            vTable.Add("say", SAY + VOCAB_VERB);
            vTable.Add("score", SCORE + VOCAB_VERB);
            vTable.Add("se", 48);
            vTable.Add("secret", 66);
            vTable.Add("sesame", 50 + VOCAB_MSG);
            vTable.Add("shadow", FIGURE + VOCAB_OBJECT);
            vTable.Add("shake", WAVE + VOCAB_VERB);
            vTable.Add("shard", VASE + VOCAB_OBJECT);
            vTable.Add("shatter", BREAK + VOCAB_VERB);
            vTable.Add("shazam", 50 + VOCAB_MSG);
            vTable.Add("shell", 74);
            vTable.Add("shit", 79 + VOCAB_MSG);
            vTable.Add("silver", SILVER + VOCAB_OBJECT);
            vTable.Add("sing", SAY + VOCAB_VERB);
            vTable.Add("slab", 61);
            vTable.Add("slit", 60);
            vTable.Add("smash", BREAK + VOCAB_VERB);
            vTable.Add("snake", SNAKE + VOCAB_OBJECT);
            vTable.Add("south", 46);
            vTable.Add("spelunker", MAGAZINE + VOCAB_OBJECT);
            vTable.Add("spice", SPICES + VOCAB_OBJECT);
            vTable.Add("spices", SPICES + VOCAB_OBJECT);
            vTable.Add("stairs", 10);
            vTable.Add("stalactite", STALACTITE + VOCAB_OBJECT);
            vTable.Add("steal", TAKE + VOCAB_VERB);
            vTable.Add("steps", 34);
            /*                vTable.Add( "steps"		      ,   STEPS + VOCAB_OBJECT	    );      */
            vTable.Add("stop", 139 + VOCAB_MSG);
            vTable.Add("stream", 14);
            vTable.Add("strike", KILL + VOCAB_VERB);
            vTable.Add("surface", 20);
            vTable.Add("suspend", SUSPEND + VOCAB_VERB);
            vTable.Add("sw", 49);
            vTable.Add("swim", 147 + VOCAB_MSG);
            vTable.Add("swing", WAVE + VOCAB_VERB);
            vTable.Add("tablet", TABLET + VOCAB_OBJECT);
            vTable.Add("take", TAKE + VOCAB_VERB);
            vTable.Add("tame", CALM + VOCAB_VERB);
            vTable.Add("throw", THROW + VOCAB_VERB);
            vTable.Add("toss", THROW + VOCAB_VERB);
            vTable.Add("tote", TAKE + VOCAB_VERB);
            vTable.Add("touch", 57);
            vTable.Add("travel", WALK + VOCAB_VERB);
            vTable.Add("treasure", CHEST + VOCAB_OBJECT);
            vTable.Add("tree", 64 + VOCAB_MSG);
            vTable.Add("trees", 64 + VOCAB_MSG);
            vTable.Add("trident", TRIDENT + VOCAB_OBJECT);
            vTable.Add("troll", TROLL + VOCAB_OBJECT);
            /*                vTable.Add( "troll"		      ,   TROLL2 + VOCAB_OBJECT	    );  */
            vTable.Add("tunnel", 23);
            vTable.Add("turn", WALK + VOCAB_VERB);
            vTable.Add("u", 29);
            vTable.Add("unlight", OFF + VOCAB_VERB);
            vTable.Add("unlock", OPEN + VOCAB_VERB);
            vTable.Add("up", 29);
            vTable.Add("upstream", 4);
            vTable.Add("upward", 29);
            vTable.Add("utter", SAY + VOCAB_VERB);
            vTable.Add("valley", 9);
            vTable.Add("vase", VASE + VOCAB_OBJECT);
            vTable.Add("velvet", PILLOW + VOCAB_OBJECT);
            vTable.Add("vending", VEND + VOCAB_OBJECT);
            vTable.Add("verbose", VERBOSE + VOCAB_VERB);
            vTable.Add("view", 28);
            vTable.Add("volcano", VOLCANO + VOCAB_OBJECT);
            vTable.Add("w", 44);
            vTable.Add("wake", WAKE + VOCAB_VERB);
            vTable.Add("walk", WALK + VOCAB_VERB);
            vTable.Add("wall", 53);
            vTable.Add("water", WATER + VOCAB_OBJECT);
            vTable.Add("wave", WAVE + VOCAB_VERB);
            vTable.Add("west", 44);
            vTable.Add("xyzzy", 62);
            vTable.Add("y2", 55);

            nVocabCount = vTable.Count;
        }

        string[] pObjDesc = 
        {
        /*  Object 1  */
        "Set of keys./There are some keys on the ground here.",

        /*  Object 2  */
        "Brass lantern/There is a shiny brass lamp nearby./There is a lamp shining nearby.",

        /*  Object 3  */
        "*Grate/The grate is locked./The grate is open.",

        /*  Object 4  */
        "Wicker cage/There is a small wicker cage discarded nearby.",

        /*  Object 5  */
        "Black rod/A three foot black rod with a rusty star on an end lies nearby.",

        /*  Object 6  */
        "Black rod/A three foot black rod with a rusty mark on an end lies nearby.",

        /*  Object 7  */
        "*Steps/Rough stone steps lead down the pit./Rough stone steps lead up the dome.",

        /*  Object 8  */
        "Little bird in cage/A cheerful little bird is sitting here singing./There is a little bird in the cage.",

        /*  Object 9  */
        "*Rusty door/The way north is barred by a massive, rusty, iron door./The way north leads through a massive, rusty, iron door.",

        /*  Object 10  */
        "Velvet pillow/A small velvet pillow lies on the floor.",

        /*  Object 11  */
        "*Snake/A huge green fierce snake bars the way!",

        /*  Object 12  */
        "*Fissure//A crystal bridge now spans the fissure./The crystal bridge has vanished!",

        /*  Object 13  */
        "*Stone tablet/A massive stone tablet imbedded in the wall reads:\"Congratulations on bringing light into the dark-room!\"",

        /*  Object 14  */
        "Giant clam >Grunt!</There is an enormous clam here with its shell tightly closed.",

        /*  Object 15  */
        "Giant oyster >Groan!</There is an enormous oyster here with its shell tightly closed./Interesting.  There seems to be something written on the underside of the\noyster.",

        /*  Object 16  */
        "\"Spelunker Today\"/There are a few recent issues of \"Spelunker Today\" magazine here.",

        /*  Object 17  */
        "",

        /*  Object 18  */
        "",

        /*  Object 19  */
        "Tasty food/There is tasty food here.",

        /*  Object 20  */
        "Small bottle/There is a bottle of water here./There is an empty bottle here./There is a bottle of oil here.",

        /*  Object 21  */
        "Water in the bottle.",

        /*  Object 22  */
        "Oil in the bottle",

        /*  Object 23  */
        "*Mirror",

        /*  Object 24  */
        "*Plant/There is a tiny little plant in the pit, murmuring \"Water, Water, ...\"/The plant spurts into furious growth for a few seconds./There is a 12-foot-tall beanstalk stretching up out of the pit, bellowing\n\"Water!! Water!!\"/The plant grows explosively, almost filling the bottom of the pit./There is a gigantic beanstalk stretching all the way up to the hole./You've over-watered the plant!  It's shriveling up! It's, It's...",

        /*  Object 25  */
        "*Phony plant//The top of a 12-foot-tall beanstalk is poking up out of the west pit./There is a huge beanstalk growing out of the west pit up to the hole.",

        /*  Object 26  */
        "*Stalactite",

        /*  Object 27  */
        "*Shadowy figure/The shadowy figure seems to be trying to attract your attention.",

        /*  Object 28  */
        "Dwarf's axe/There is a little axe here./There is a little axe lying beside the bear.",

        /*  Object 29  */
        "*Cave drawings",

        /*  Object 30  */
        "*Pirate",

        /*  Object 31  */
        "*Dragon/A huge green fierce dragon bars the way!/Congratulations!  You have just vanquished a dragon with your bare hands!\n(Unbelievable, Isn't it?)/The body of a huge green dead dragon is lying off to one side.",

        /*  Object 32  */
        "*Chasm/A rickety wooden bridge extends across the chasm, vanishing into the mist.\nA sign posted on the bridge reads:\n                  \"Stop!  Pay Troll!\"/The wreckage of a bridge (and a dead bear) can be seen at the bottom of the\nchasm.",

        /*  Object 33  */
        "*Troll/A burly troll stands by the bridge and insists you throw him a treasure\nbefore you may cross./The troll steps out from beneath the bridge and blocks your way.",

        /*  Object 34  */
        "*Phony troll/The troll is nowhere to be seen.",

        /*  Object 35  */
        "/There is a ferocious cave bear eyeing you from the far end of the room!/There is a gentle cave bear sitting placidly in one corner./There is a contented-looking bear wandering about nearby.",

        /*  Object 36  */
        "*Message in second maze/There is a message scrawled in the dust in a flowery script, reading:\n           \"This is not the maze where the\"           \"pirate leaves his treasure chest\"",

        /*  Object 37  */
        "*Volcano and,or Geyser",

        /*  Object 38  */
        "*Vending machine"+
        "/There is a massive vending machine here.  The instructions on it read:\n"+
        "\n"+
        "     \"Drop coins here to receive fresh batteries.\"",

        /*  Object 39  */
        "Batteries"+
        "/There are fresh batteries here."+
        "/Some worn-out batteries have been discarded nearby.",

        /*  Object 40  */
        "*Carpet and,or moss",

        /*  Object 41  */
        "",

        /*  Object 42  */
        "",

        /*  Object 43  */
        "",

        /*  Object 44  */
        "",

        /*  Object 45  */
        "",

        /*  Object 46  */
        "",

        /*  Object 47  */
        "",

        /*  Object 48  */
        "",

        /*  Object 49  */
        "",

        /*  Object 50  */
        "Large gold nugget"+
        "/There is a large sparkling nugget of gold here!",


        /*  Object 51  */
        "Several diamonds"+
        "/There are diamonds here!",

        /*  Object 52  */
        "Bars of silver"+
        "/There are bars of silver here!",

        /*  Object 53  */
        "Precious jewelry"+
        "/There is precious jewelry here!",

        /*  Object 54  */
        "Rare coins"+
        "/There are many coins here!",

        /*  Object 55  */
        "Treasure chest"+
        "/The pirate's treasure chest is here!",

        /*  Object 56  */
        "Golden eggs"+
        "/There is a large nest here, full of golden eggs!"+
        "/The nest of golden eggs has vanished!"+
        "/Done!",

        /*  Object 57  */
        "Jeweled trident"+
        "/There is a jewel-encrusted trident here!",

        /*  Object 58  */
        "Ming vase"+
        "/There is a delicate, precious, ming vase here!"+
        "/The vase is now resting, delicately, on a velvet pillow."+
        "/The floor is littered with worthless shards of pottery."+
        "/The ming vase drops with a delicate crash.",

        /*  Object 59  */
        "Egg-sized emerald"+
        "/There is an emerald here the size of a plover's egg!",

        /*  Object 60  */
        "Platinum pyramid"+
        "/There is a platinum pyramid here, 8 inches on a side!",

        /*  Object 61  */
        "Glistening pearl"+
        "/Off to one side lies a glistening pearl!",

        /*  Object 62  */
        "Persian rug"+
        "/There is a persian rug spread out on the floor!"+
        "/The dragon is sprawled out on a persian rug!!",

        /*  Object 63  */
        "Rare spices"+
        "/There are rare spices here!",

        /*  Object 64  */
        "Golden chain"+
        "/There is a golden chain lying in a heap on the floor!"+
        "/The bear is locked to the wall with a golden chain!"+
        "/There is a golden chain locked to the wall!",

        };


        string[] pLongRmDesc = 
        {
        /*  Room 1  */
        "You are standing at the end of a road before a small brick building.  Around\n"+
        "you is a forest.  A small stream flows out of the building and down a gully.",

        /*  Room 2  */
        "You have walked up a hill, still in the forest.  The road slopes back down\n"+
        "the other side of the hill.  There is a building in the distance.",

        /*  Room 3  */
        "You are inside a building, a well house for a large spring.",

        /*  Room 4  */
        "You are in a valley in the forest beside a stream tumbling along a rocky\n"+
        "bed.",

        /*  Room 5  */
        "You are in open forest, with a deep valley to one side.",

        /*  Room 6  */
        "You are in open forest near both a valley and a road.",

        /*  Room 7  */
        "At your feet all the water of the stream splashes into a 2-inch slit in the\n"+
        "rock.  Downstream the streambed is bare rock.",

        /*  Room 8  */
        "You are in a 20-foot depression floored with bare dirt.  Set into the dirt\n"+
        "is a strong steel grate mounted in concrete.  A dry streambed leads into the\n"+
        "depression.",

        /*  Room 9  */
        "You are in a small chamber beneath a 3x3 steel grate to the surface.  A low\n"+
        "crawl over cobbles leads inward to the West.",

        /* Room 10 */
        "You are crawling over cobbles in a low passage.  There is a dim light at the\n"+
        "east end of the passage.",

        /*  Room 11  */
        "You are in a debris room filled with stuff washed in from the surface.  A\n"+
        "low wide passage with cobbles becomes plugged with mud and debris here, but\n"+
        "an awkward canyon leads upward and west.  A note on the wall says:\n"+
        "                          Magic Word \"XYZZY\"",

        /*  Room 12  */
        "You are in an awkward sloping east/west canyon.",

        /*  Room 13  */
        "You are in a splendid chamber thirty feet high.  The walls are frozen rivers\n"+
        "of orange stone.  An awkward canyon and a good passage exit from east and\n"+
        "west sides of the chamber.",

        /*  Room 14  */
        "At your feet is a small pit breathing traces of white mist.  An east passage\n"+
        "ends here except for a small crack leading on.",

        /*  Room 15  */
        "You are at one end of a vast hall stretching forward out of sight to the\n"+
        "west.  There are openings to either side.  Nearby, a wide stone staircase\n"+
        "leads downward.  The hall is filled with wisps of white mist swaying to and\n"+
        "fro almost as if alive.  A cold wind blows up the staircase.  There is a\n"+
        "passage at the top of a dome behind you.",

        /*  Room 16  */
        "The crack is far too small for you to follow.",

        /*  Room 17  */
        "You are on the east bank of a fissure slicing clear across the hall.  The\n"+
        "mist is quite thick here, and the fissure is too wide to jump.",

        /*  Room 18  */
        "This is a low room with a crude note on the wall.  The note says:\n"+
        "       You won't get it up the steps.",

        /*  Room 19  */
        "You are in the hall of the mountain king, with passages off in all\n"+
        "directions.",

        /*  Room 20  */
        "You are at the bottom of the pit with a broken neck.",

        /*  Room 21  */
        "You didn't make it.",

        /*  Room 22  */
        "The dome is unclimbable.",

        /*  Room 23  */
        "You are at the west end of the twopit room.  There is a large hole in the\n"+
        "wall above the pit at this end of the room.",

        /*  Room 24  */
        "You are that the bottom of the eastern pit in the twopit room.  There is a\n"+
        "small pool of oil in one corner of the pit.",

        /*  Room 25  */
        "You are at the bottom of the western pit in the towpit room.  There is a\n"+
        "large hole in the wall about 25 feet above you.",

        /*  Room 26  */
        "You clamber up the plant and scurry through the hole at the top.",

        /*  Room 27  */
        "You are on the west side of the fissure in the hall of mists.",

        /*  Room 28  */
        "You are in a low N/S passage at a hole in the floor.  The hole goes down to\n"+
        "an E/W passage.",

        /*  Room 29  */
        "You are in the south side chamber.",

        /*  Room 30  */
        "You are in the west side chamber of the hall of the mountain king.  A\n"+
        "passage continues west and up here.",

        /*  Room 31  */
        ">$<",

        /*  Room 32  */
        "You can't get by the snake.",

        /*  Room 33  */
        "You are in a large room, with a passage to the south, a passage to the west,\n"+
        "and a wall of broken rock to the east.  There is a large \"Y2\" on a rock in\n"+
        "the room's center.",

        /*  Room 34  */
        "You are in a jumble of rock, with cracks everywhere.",

        /*  Room 35  */
        "You're at a low window overlooking a huge pit, which extends up out of\n"+
        "sight.  A floor is indistinctly visible over 50 feet below.  Traces of white\n"+
        "mist cover the floor of the pit, becoming thicker to the right.  Marks in\n"+
        "the dust around the window would seem to indicate that someone has been here\n"+
        "recently.  Directly across the pit from you and 25 feet away there is a\n"+
        "similar window looking into a lighted room.  A shadowy figure can be seen\n"+
        "there peering back at you.",

        /*  Room 36  */
        "You are in a dirty broken passage.  To the east is a crawl.  To the west is\n"+
        "a large passage.  Above you is another passage.",

        /*  Room 37  */
        "You are on the brink of a small clean climbable pit.  A crawl leads west.",

        /*  Room 38  */
        "You are in the bottom of a small pit with a little stream, which enters and\n"+
        "exits through tiny slits.",

        /*  Room 39  */
        "You are in a large room full of dusty rocks.  There is a big hole in the\n"+
        "floor.  There are cracks everywhere, and a passage leading east.",

        /*  Room 40  */
        "You have crawled through a very low wide passage parallel to and north of\n"+
        "the hall of mists.",

        /*  Room 41  */
        "You are at the west end of hall of mists.  A low wide crawl continues west\n"+
        "and another goes north.  To the south is a little passage 6 feet off the\n"+
        "floor.",

        /*  Room 42  */
        "You are in a maze of twisty little passages, all alike.",

        /*  Room 43  */
        "@42",

        /*  Room 44  */
        "@42",

        /*  Room 45  */
        "@42",

        /*  Room 46  */
        "Dead end.",

        /*  Room 47  */
        "@46",

        /*  Room 48  */
        "@46",

        /*  Room 49  */
        "@42",

        /*  Room 50  */
        "@42",

        /*  Room 51  */
        "@42",

        /*  Room 52  */
        "@42",

        /*  Room 53  */
        "@42",

        /*  Room 54  */
        "@46",

        /*  Room 55  */
        "@42",

        /*  Room 56  */
        "@46",

        /*  Room 57  */
        "You are on the brink of a thirty foot pit with a massive orange column down\n"+
        "one wall.  You could climb down here but you could not get back up.  The\n"+
        "maze continues at this level.",

        /*  Room 58  */
        "@46",

        /*  Room 59  */
        "You have crawled through a very low wide passage paralled to and north of\n"+
        "the hall of mists.",

        /*  Room 60  */
        "You are at the east end of a very long hall apparently without side\n"+
        "chambers.  To the east a low wide crawl slants up.  To the north a round two\n"+
        "foot hole slants down.",

        /*  Room 61  */
        "You are at the west end of a very long featureless hall.  The hall joins up\n"+
        "with a narrow north/south passage.",

        /*  Room 62  */
        "You are at a crossover of a high N/S passage and a low E/W one.",

        /*  Room 63  */
        "@46",

        /*  Room 64  */
        "You are at a complex junction.  A low hands and knees passage from the north\n"+
        "joins a higher crawl from the east to make a walking passage going west.\n"+
        "There is also a large room above.  The air is damp here.",

        /*  Room 65  */
        "You are in bedquilt, a long east/west passage with holes everywhere.  To\n"+
        "explore at random select north, south, up or down.",

        /*  Room 66  */
        "You are in a room whose walls resemble swiss cheese. Obvious passages go\n"+
        "west, east, ne, and nw.  Part of the room is occupied by a large bedrock\n"+
        "block.",

        /*  Room 67  */
        "You are at the east end of the twopit room.  The floor here is littered with\n"+
        "thin rock slabs, which make it easy to descend the pits.  There is a path\n"+
        "here bypassing the pits to connect passages from east and west.  There are\n"+
        "holes all over, but the only bit one is on the wall directly over the west\n"+
        "pit where you can't get at it.",

        /*  Room 68  */
        "You are in a large low circular chamber whose floor is an immense slab\n"+
        "fallen from the ceiling (slab room). East and west there once were large\n"+
        "passages, but they are now filled with boulders.  Low small passages go\n"+
        "north and south, and the south one quickly bends west around the boulders.",

        /*  Room 69  */
        "You are in a secret N/S canyon above a large room.",

        /*  Room 70  */
        "You are in a secret N/S canyon above a sizable passage.",

        /*  Room 71  */
        "You are in a secret canyon at a junction of three canyons, bearing north,\n"+
        "south and se.  The north one is as tall as the other two combined.",

        /*  Room 72  */
        "You are in a large low room.  Crawls lead north, se, and sw.",

        /*  Room 73  */
        "Dead end crawl.",

        /*  Room 74  */
        "You are in a secret canyon which here runs E/W.  It crosses over a very\n"+
        "tight canyon 15 feet below.  If you go down you may not be able to get back\n"+
        "up.",

        /*  Room 75  */
        "You are at a wide place in a very tight N/S canyon.",

        /*  Room 76  */
        "The canyon here becomes too tight to go further south.",

        /*  Room 77  */
        "You are in a tall E/W canyon.  A low tight crawl goes 3 feet north and seems\n"+
        "to open up.",

        /*  Room 78  */
        "The canyon runs into a mass of boulders -- dead end.",

        /*  Room 79  */
        "The stream flows out through a pair of 1 foot diameter sewer pipes.  It\n"+
        "would be advisable to use the exit.",

        /*  Room 80  */
        "@42",

        /*  Room 81  */
        "@46",

        /*  Room 82  */
        "@46",

        /*  Room 83  */
        "@42",

        /*  Room 84  */
        "@42",

        /*  Room 85  */
        "@46",

        /*  Room 86  */
        "@46",

        /*  Room 87  */
        "@42",

        /*  Room 88  */
        "You are in a long, narrow corridor stretching out of sight to the west.  At\n"+
        "the eastern end is a hole through which you can see a profusion of leaves,\n",

        /*  Room 89  */
        "There is nothing here to climb.  Use \"up\" or \"out\" to leave\n",
        "the pit.",

        /*  Room 90  */
        "You have climbed up the plant and out of the pit.",

        /*  Room 91  */
        "You are at the top of a steep incline above a large room. You could climb\n"+
        "down here, but you would not be able to climb up.  There is a passage\n"+
        "leading back to the north.",

        /*  Room 92  */
        "You are in the giant room.  The ceiling is too high up for your lamp to show\n"+
        "it.  Cavernous passages lead east, north, and south.  On the west wall is\n"+
        "scrawled the inscription:\n"+
        "              \"Fee Fie Foe Foo\"       {sic}",

        /*  Room 93  */
        "The passage here is blocked by a recent cave-in.",

        /*  Room 94  */
        "You are at one end of an immense north/south passage.",

        /*  Room 95  */
        "You are in a magnificent cavern with a rushing stream, which cascades over a\n"+
        "sparkling waterfall into a roaring whirlpool which disappears through a hole\n"+
        "in the floor.  Passages exit to the south and west.",

        /*  Room 96  */
        "You are in the soft room.  The walls are covered with heavy curtains, the\n"+
        "floor with a thick pile carpet. Moss covers the ceiling.",

        /*  Room 97  */
        "This is the oriental room.  Ancient oriental cave drawings cover the walls.\n"+
        "A gently sloping passage leads upward to the north, another passage leads se,\n"+
        "and a hands and knees crawl leads west.",

        /*  Room 98  */
        "You are following a wide path around the outer edge of a large cavern.  Far\n"+
        "below, through a heavy white mist, strange splashing noises can be heard.\n"+
        "The mist rises up through a fissure in the ceiling.  The path exits to the\n"+
        "south and west.",

        /*  Room 99  */
        "You are in an alcove.  A small nw path seems to widen after a short\n"+
        "distance.  An extremely tight tunnel leads east.  It looks like a very tight\n"+
        "squeeze.  An eerie light can be seen at the other end.",

        /*  Room 100  */
        "You're in a small chamber lit by an eerie green light.  An extremely narrow\n"+
        "tunnel exits to the west.  A dark corridor leads ne.",

        /*  Room 101  */
        "You're in the dark-room.  A corridor leading south is the only exit.",

        /*  Room 102  */
        "You are in an arched hall.  A coral passage once continued up and east from\n"+
        "here, but is now blocked by debris.  The air smells of sea water.",

        /*  Room 103  */
        "You're in a large room carved out of sedimentary rock.  The floor and walls\n"+
        "are littered with bits of shells imbedded in the stone.  A shallow passage\n"+
        "proceeds downward, and a somewhat steeper one leads up.  A low hands and\n"+
        "knees passage enters from the south.",

        /*  Room 104  */
        "You are in a long sloping corridor with ragged sharp walls.",

        /*  Room 105  */
        "You are in a cul-de-sac about eight feet across.",

        /*  Room 106  */
        "You are in an anteroom leading to a large passage to the east.  Small\n"+
        "passages go west and up.  The remnants of recent digging are evident.  A\n"+
        "sign in midair here says:\n"+
        "            \"Cave under construction beyond this point.\"\n"+
        "                   \"Proceed at your own risk.\"\n"+
        "                  \"Witt construction company\"",

        /*  Room 107  */
        "You are in a maze of twisty little passages, all different.",

        /*  Room 108  */
        "You are at Witt's end.  Passages lead off in ALL directions.",

        /*  Room 109  */
        "You are in a north/south canyon about 25 feet across.  The floor is covered\n"+
        "by white mist seeping in from the north. The walls extend upward for well\n"+
        "over 100 feet.  Suspended from some unseen point far above you, an enormous\n"+
        "two-sided mirror is hanging paralled to and midway between the canyon walls.\n"+
        "(The mirror is obviously provided for the use of the dwarves, who as you\n"+
        "know, are extremely vain.)  A small window can be seen in either wall, some\n"+
        "fifty feet up.",

        /*  Room 110  */
        "You're at a low window overlooking a huge pit, which extends up out of\n"+
        "sight.  A floor is indistinctly visible over 50 feet below.  Traces of white\n"+
        "mist cover the floor of the pit, becoming thicker to the left.  Marks in the\n"+
        "dust around the window would seem to indicate that someone has been here\n"+
        "recently.  Directly across the pit from you and 25 feet away there is a\n"+
        "similar window looking into a lighted room.  A shadowy figure can be seen\n"+
        "there peering back at you.",

        /*  Room 111  */
        "A large stalactite extends from the roof and almost reaches the floor below.\n"+
        "You could climb down it, and jump from it to the floor, but having done so\n"+
        "you would be unable to reach it to climb back up.",

        /*  Room 112  */
        "You are in a little maze of twisting passages, all different.",

        /*  Room 113  */
        "You are at the edge of a large underground reservoir.  An opaque cloud of\n"+
        "white mist fills the room and rises rapidly upward.  The lake is fed by a\n"+
        "stream which tumbles out of a hole in the wall about 10 feet overhead and\n"+
        "splashes noisily into the water somewhere within the mist. The only passage\n"+
        "goes back toward the south.",

        /*  Room 114  */
        "@46",

        /*  Room 115  */
        "@141,142",

        /*  Room 116  */
        "@143,144",

        /*  Room 117  */
        "You are on one side of a large deep chasm.  A heavy white mist rising up\n"+
        "from below obscures all view of the far side.  A sw path leads away from the\n"+
        "chasm into a winding corridor.",

        /*  Room 118  */
        "You are in a long winding corridor sloping out of sight in both directions.",

        /*  Room 119  */
        "You are in a secret canyon which exits to the north and east.",

        /*  Room 120  */
        "You are in a secret canyon which exits to the north and east.",

        /*  Room 121  */
        "You are in a secret canyon which exits to the north and east.",

        /*  Room 122  */
        "You are on the far side of the chasm.  A ne path leads away from the chasm\n"+
        "on this side.",

        /*  Room 123  */
        "You're in a long east/west corridor.  A faint rumbling noise can be heard in\n"+
        "the distance.",

        /*  Room 124  */
        "The path forks here.  The left fork leads northeast.  A dull rumbling seems\n"+
        "to get louder in that direction.  The right fork leads southeast down a\n"+
        "gentle slope.  The main corridor enters from the west.",

        /*  Room 125  */
        "The walls are quite warm here.  From the north can be heard a steady roar,\n"+
        "so loud that the entire cave seems to be trembling.  Another passage leads\n"+
        "south, and a low crawl goes east.",

        /*  Room 126  */
        "@145,146,147",

        /*  Room 127  */
        "You are in a small chamber filled with large boulders.  The walls are very\n"+
        "warm, causing the air in the room to be almost stifling from the heat.  The\n"+
        "only exit is a crawl heading west, through which is coming a low rumbling.",

        /*  Room 128  */
        "You are walking along a gently sloping north/south passage lined with oddly\n"+
        "shaped limestone formations.",

        /*  Room 129  */
        "You are standing at the entrance to a large, barren room.  A sign posted\n"+
        "above the entrance reads:\n"+
        "               \"Caution!  Bear in room!\"",

        /*  Room 130  */
        "You are inside a barren room.  The center of the room is completely empty\n"+
        "except for some dust.  Marks in the dust lead away toward the far end of the\n"+
        "room.  The only exit is the way you came in.",

        /*  Room 131  */
        "You are in a maze of twisting little passages, all different.",

        /*  Room 132  */
        "You are in a little maze of twisty passages, all different.",

        /*  Room 133  */
        "You are in a twisting maze of little passages, all different.",

        /*  Room 134  */
        "You are in a twisting little maze of passages, all different.",

        /*  Room 135  */
        "You are in a twisty little maze of passages, all different.",

        /*  Room 136  */
        "You are in a twisty maze of little passages, all different.",

        /*  Room 137  */
        "You are in a little twisty maze of passages, all different.",

        /*  Room 138  */
        "You are in a maze of little twisting passages, all different.",

        /*  Room 139  */
        "You are in a maze of little twisty passages, all different.",

        /*  Room 140  */
        "@46",

        /*  Extra 141  */
        "You are at the northeast end of an immense room, even larger than the giant\n"+
        "room.  It appears to be a repository for the \"adventure\" program.  Massive\n"+
        "torches far overhead bathe the room with smoky yellow light.  Scattered\n"+
        "about you can be seen a pile of bottles (all of them empty), a nursery of\n"+
        "young beanstalks murmuring quietly, a bed of oysters, a bundle of black rods\n"+
        "with rusty stars on their ends, and a collection of brass lanterns.  Off to",

        /*  Extra 142  */
        "one side a great many Dwarves are sleeping on the floor, snoring loudly.  A\n"+
        "sign nearby reads:\n"+
        "\n"+
        "                  \"Do NOT disturb the Dwarves!\"\n"+
        "\n"+
        "An immense mirror is hanging against one wall, and stretches to the other\n"+
        "end of the room, where various other sundry objects can be glimpsed dimly in\n"+
        "the distance.",

        /*  Extra 143  */
        "You are at the southwest end of the repository.  To one side is a pit full\n"+
        "of fierce green snakes.  On the other side is a row of small wicker cages,\n"+
        "each of which contains a little sulking bird.  In one corner is a bundle of\n"+
        "black rods with rusty marks on their ends.  A large number of velvet pillows\n"+
        "are scattered about on the floor.  A vast mirror stretches off to the",

        /*  Extra 144  */
        "northeast.  At your feet is a large steel grate, next to which is a sign\n"+
        "which reads:\n"+
        "                \"Treasure vault.  Keys in main office.\"",

        /*  Extra 145  */
        "You are on the edge of a breath-taking view.  Far below you is an active\n"+
        "volcano, from which great gouts of molten lava come surging out, cascading\n"+
        "back down into the depths.  The glowing rock fills the farthest reaches of\n"+
        "the cavern with a blood-red glare, giving everything an eerie, macabre\n"+
        "appearance.  The air is filled with flickering sparks of ash and a heavy\n"+
        "smell of brimstone.  The walls are hot to the touch, and the thundering of",

        /*  Extra  146	*/
        "the volcano drowns out all other sounds.  Embedded in the jagged roof far\n"+
        "overhead are myriad formations composed of pure white alabaster, which\n"+
        "scatter their murky light into sinister apparitions upon the walls.  To one\n"+
        "side is a deep gorge, filled with a bizarre chaos of tortured rock which\n"+
        "seems to have been crafted by the Devil Himself.  An immense river of fire\n"+
        "crashes out from the depths of the volcano, burns its way through the gorge,",

        /*  Extra  147	*/
        "and plummets into a bottomless pit far off to your left.  To the right, an\n"+
        "immense geyser of blistering steam erupts continuously from a barren island\n"+
        "in the center of a sulfurous lake, which bubbles ominously. The far right\n"+
        "wall is aflame with an incandescence of its own, which lends an additional\n"+
        "infernal splendor to the already hellish scene.  A dark, foreboding passage\n"+
        "exits to the south.",

        };


        string[] pShortRmDesc = 
        {
        /*  Room 1  */
        "You're at end of road again.",

        /*  Room 2  */
        "You're at hill in road.",

        /*  Room 3  */
        "You're inside building.",

        /*  Room 4  */
        "You're in valley.",

        /*  Room 5  */
        "You're in forest.",

        /*  Room 6  */
        "You're in forest.",

        /*  Room 7  */
        "You're at slit in streambed.",

        /*  Room 8  */
        "You're outside grate.",

        /*  Room 9  */
        "You're below the grate.",

        /*  Room 10  */
        "You're in cobble crawl.",

        /*  Room 11  */
        "You're in debris room.",

        /*  Room 12  */
        "You are in an awkward sloping east/west canyon.",

        /*  Room 13  */
        "You're in bird chamber.",

        /*  Room 14  */
        "You're at top of small pit.",

        /*  Room 15  */
        "You're in hall of mists.",

        /*  Room 16  */
        "The crack is far too small for you to follow.",

        /*  Room 17  */
        "You're on east bank of fissure.",

        /*  Room 18  */
        "You're in nugget of gold room.",

        /*  Room 19  */
        "You're in hall of mt. king.",

        /*  Room 20  */
        "You are the the bottom of the pit with a broken neck.",

        /*  Room 21  */
        "You didn't make it.",

        /*  Room 22  */
        "The dome is unclimbable.",

        /*  Room 23  */
        "You're at west end of twopit room.",

        /*  Room 24  */
        "You're in east pit.",

        /*  Room 25  */
        "You're in west pit.",

        /*  Room 26  */
        "You clamber up the plant and scurry through the hole at the top.",

        /*  Room 27  */
        "You are on the west side of the fissure in the hall of mists.",

        /*  Room 28  */
        "You are in a low N/S passage at a hole in the floor.  The hole goes down to\n"+
        "an E/W passage.",

        /*  Room 29  */
        "You are in the south side chamber.",

        /*  Room 30  */
        "You are in the west side chamber of the hall of the mountain king.  A\n"+
        "passage continues west and up here.",

        /*  Room 31  */
        ">$<",

        /*  Room 32  */
        "You can't get by the snake.",

        /*  Room 33  */
        "You're at \"Y2\".",

        /*  Room 34  */
        "You are in a jumble of rock, with cracks everywhere.",

        /*  Room 35  */
        "You're at window on pit.",

        /*  Room 36  */
        "You're in dirty passage.",

        /*  Room 37  */
        "You are on the brink of a small clean climbable pit.  A crawl leads west.",

        /*  Room 38  */
        "You are in the bottom of a small pit with a little stream, which enters and\n"+
        "exits through tiny slits.",

        /*  Room 39  */
        "You're in dusty rock room.",

        /*  Room 40  */
        "You have crawled through a very low wide passage parallel to and north of\n"+
        "the hall of mists.",

        /*  Room 41  */
        "You're at west end of hall of mists.",

        /*  Room 42  */
        "You are in a maze of twisty little passages, all alike.",

        /*  Room 43  */
        "@42",

        /*  Room 44  */
        "@42",

        /*  Room 45  */
        "@42",

        /*  Room 46  */
        "Dead end.",

        /*  Room 47  */
        "@46",

        /*  Room 48  */
        "@46",

        /*  Room 49  */
        "@42",

        /*  Room 50  */
        "@42",

        /*  Room 51  */
        "@42",

        /*  Room 52  */
        "@42",

        /*  Room 53  */
        "@42",

        /*  Room 54  */
        "@46",

        /*  Room 55  */
        "@42",

        /*  Room 56  */
        "@46",

        /*  Room 57  */
        "You're at brink of pit.",

        /*  Room 58  */
        "@46",

        /*  Room 59  */
        "You have crawled through a very low wide passage paralled to and north of\n"+
        "the hall of mists.",

        /*  Room 60  */
        "You're at east end of long hall.",

        /*  Room 61  */
        "You're at west end of long hall.",

        /*  Room 62  */
        "You are at a crossover of a high N/S passage and a low E/W one.",

        /*  Room 63  */
        "@46",

        /*  Room 64  */
        "You're at complex junction.",

        /*  Room 65  */
        "You are in bedquilt, a long east/west passage with holes everywhere.  To\n"+
        "explore at random select north, south, up or down.",

        /*  Room 66  */
        "You're in swiss cheese room.",

        /*  Room 67  */
        "You're at east end of twopit room.",

        /*  Room 68  */
        "You're in slab room.",

        /*  Room 69  */
        "You are in a secret N/S canyon above a large room.",

        /*  Room 70  */
        "You are in a secret N/S canyon above a sizable passage.",

        /*  Room 71  */
        "You're at junction of three secret canyons.",

        /*  Room 72  */
        "You are in a large low room.  Crawls lead north, se, and sw.",

        /*  Room 73  */
        "Dead end crawl.",

        /*  Room 74  */
        "You're at secret E/W canyon above tight canyon.",

        /*  Room 75  */
        "You are at a wide place in a very tight N/S canyon.",

        /*  Room 76  */
        "The canyon here becomes too tight to go further south.",

        /*  Room 77  */
        "You are in a tall E/W canyon.  A low tight crawl goes 3 feet north and seems\n"+
        "to open up.",

        /*  Room 78  */
        "The canyon runs into a mass of boulders -- dead end.",

        /*  Room 79  */
        "The stream flows out through a pair of 1 foot diameter sewer pipes.  It\n"+
        "would be advisable to use the exit.",

        /*  Room 80  */
        "@42",

        /*  Room 81  */
        "@46",

        /*  Room 82  */
        "@46",

        /*  Room 83  */
        "@42",

        /*  Room 84  */
        "@42",

        /*  Room 85  */
        "@46",

        /*  Room 86  */
        "@46",

        /*  Room 87  */
        "@42",

        /*  Room 88  */
        "You're in narrow corridor.",

        /*  Room 89  */
        "There is nothing here to climb.  Use \"up\" or \"out\" to leave the pit.",

        /*  Room 90  */
        "You have climbed up the plant and out of the pit.",

        /*  Room 91  */
        "You're at steep incline above large room.",

        /*  Room 92  */
        "You're in giant room.",

        /*  Room 93  */
        "The passage here is blocked by a recent cave-in.",

        /*  Room 94  */
        "You are at one end of an immense north/south passage.",

        /*  Room 95  */
        "You're in cavern with waterfall.",

        /*  Room 96  */
        "You're in soft room.",

        /*  Room 97  */
        "You're in oriental room.",

        /*  Room 98  */
        "You're in misty cavern.",

        /*  Room 99  */
        "You're in alcove.",

        /*  Room 100  */
        "You're in plover room.",

        /*  Room 101  */
        "You're in dark-room.",

        /*  Room 102  */
        "You're in arched hall.",

        /*  Room 103  */
        "You're in shell room.",

        /*  Room 104  */
        "You are in a long sloping corridor with ragged sharp walls.",

        /*  Room 105  */
        "You are in a cul-de-sac about eight feet across.",

        /*  Room 106  */
        "You're in anteroom.",

        /*  Room 107  */
        "You are in a maze of twisty little passages, all different.",

        /*  Room 108  */
        "You're at Witt's end.",

        /*  Room 109  */
        "You're in mirror canyon.",

        /*  Room 110  */
        "You're at window on pit.",

        /*  Room 111  */
        "You're at top of stalactite.",

        /*  Room 112  */
        "You are in a little maze of twisting passages, all different.",

        /*  Room 113  */
        "You're at reservoir.",

        /*  Room 114  */
        "@46",

        /*  Room 115  */
        "You're at ne end of repository.",

        /*  Room 116  */
        "You're at sw end of repository.",

        /*  Room 117  */
        "You're on sw side of chasm.",

        /*  Room 118  */
        "You're in sloping corridor.",

        /*  Room 119  */
        "You are in a secret canyon which exits to the north and east.",

        /*  Room 120  */
        "@119",

        /*  Room 121  */
        "@119",

        /*  Room 122  */
        "You're on ne side of chasm.",

        /*  Room 123  */
        "You're in corridor.",

        /*  Room 124  */
        "You're at fork in path.",

        /*  Room 125  */
        "You're at junction with warm walls.",

        /*  Room 126  */
        "You're at breath-taking view.",

        /*  Room 127  */
        "You're in chamber of boulders.",

        /*  Room 128  */
        "You're in limestone passage.",

        /*  Room 129  */
        "You're in front of barren room.",

        /*  Room 130  */
        "You're in barren room.",

        /*  Room 131  */
        "You are in a maze of twisting little passages, all different.",

        /*  Room 132  */
        "You are in a little maze of twisty passages, all different.",

        /*  Room 133  */
        "You are in a twisting maze of little passages, all different.",

        /*  Room 134  */
        "You are in a twisting little maze of passages, all different.",

        /*  Room 135  */
        "You are in a twisty little maze of passages, all different.",

        /*  Room 136  */
        "You are in a twisty maze of little passages, all different.",

        /*  Room 137  */
        "You are in a little twisty maze of passages, all different.",

        /*  Room 138  */
        "You are in a maze of little twisting passages, all different.",

        /*  Room 139  */
        "You are in a maze of little twisty passages, all different.",

        /*  Room 140  */
        "@46",

        };


       string[] pTextMsg = 
        {
        /*  Msg 1  */
        "@202,203,204",

        /*  Msg 2  */
        "A little dwarf with a big knife blocks your way.",

        /*  Msg 3  */
        "A little dwarf just walked around a corner, saw you, threw a little axe at\n"+
        "you which missed, cursed, and ran away.",

        /*  Msg 4  */
        "There is a threatening little dwarf in the room with you!",

        /*  Msg 5  */
        "One sharp, nasty knife is thrown at you!",

        /*  Msg 6  */
        "None of them hit you!",

        /*  Msg 7  */
        "One of them gets you!",

        /*  Msg 8  */
        "A hollow voice says \"Plugh\".",

        /*  Msg 9  */
        "There is no way to go that direction.",

        /*  Msg 10  */
        "I am unsure how you are facing.  Use compass points or nearby objects.",

        /*  Msg 11  */
        "I don't know in from out here.  Use compass points or name something in the\n"+
        "general direction you want to go.",

        /*  Msg 12  */
        "I don't know how to apply that word here.",

        /*  Msg 13  */
        "I don't understand that!",

        /*  Msg 14  */
        "I'm game.  Would you care to explain how?",

        /*  Msg 15  */
        "Sorry, but I am not allowed to give more detail.  I will repeat the long\n"+
        "description of your location.\n",

        /*  Msg 16  */
        "It is now pitch dark.  If you proceed you will likely fall into a pit.",

        /*  Msg 17  */
        "If you prefer, simply type W rather than West.",

        /*  Msg 18  */
        "Are you trying to catch the bird?",

        /*  Msg 19  */
        "The bird is frightened right now and you cannot catch it no matter what you\n"+
        "try.  Perhaps you might try later.",

        /*  Msg 20  */
        "Are you trying to somehow deal with the snake?",

        /*  Msg 21  */
        "You can't kill the snake, or drive it away, or avoid it, or anything like\n"+
        "that.  There is a way to get by, but you don't have the necessary resources\n"+
        "right now.",

        /*  Msg 22  */
        "Do you really want to quit now?",

        /*  Msg 23  */
        "You fell into a pit and broke every bone in your body!",

        /*  Msg 24  */
        "You are already carrying it!",

        /*  Msg 25  */
        "You can't be serious!",

        /*  Msg 26  */
        "The bird was unafraid when you entered, but as you approach it becomes\n"+
        "disturbed and you cannot catch it.",

        /*  Msg 27  */
        "You can catch the bird, but you cannot carry it.",

        /*  Msg 28  */
        "There is nothing here with a lock!",

        /*  Msg 29  */
        "You aren't carrying it!",

        /*  Msg 30  */
        "The little bird attacks the green snake, and in an astounding flurry drives\n"+
        "the snake away.",

        /*  Msg 31  */
        "You have no keys!",

        /*  Msg 32  */
        "It has no lock.",

        /*  Msg 33  */
        "I don't know how to lock or unlock such a thing.",

        /*  Msg 34  */
        "It was already locked.",

        /*  Msg 35  */
        "The grate is now locked.",

        /*  Msg 36  */
        "The grate is now unlocked.",

        /*  Msg 37  */
        "It was already unlocked.",

        /*  Msg 38  */
        "You have no source of light.",

        /*  Msg 39  */
        "Your lamp is now on.",

        /*  Msg 40  */
        "Your lamp is now off.",

        /*  Msg 41  */
        "There is no way to get past the bear to unlock the chain, which is probably\n"+
        "just as well.",

        /*  Msg 42  */
        "Nothing happens.",

        /*  Msg 43  */
        "Where?",

        /*  Msg 44  */
        "There is nothing here to attack.",

        /*  Msg 45  */
        "The little bird is now dead.  Its body disappears.",

        /*  Msg 46  */
        "Attacking the snake both doesn't work and is very dangerous.",

        /*  Msg 47  */
        "You killed a little dwarf.",

        /*  Msg 48  */
        "You attack a little dwarf, but he dodges out of the way.",

        /*  Msg 49  */
        "With what? Your bare hands?",

        /*  Msg 50  */
        "Good try, but that is an old worn-out magic word.",

        /*  Msg 51  */
        "@205,206,207",

        /*  Msg 52  */
        "It misses!",

        /*  Msg 53  */
        "It gets you!",

        /*  Msg 54  */
        "OK\n",

        /*  Msg 55  */
        "You can't unlock the keys.",

        /*  Msg 56  */
        "You have crawled around in some little holes and wound up back in the main\n"+
        "passage.",

        /*  Msg 57  */
        "I don't know where the cave is, but hereabouts no stream can run on the\n"+
        "surface for very long.  I would try the stream.",

        /*  Msg 58  */
        "I need more detailed instructions to do that.",

        /*  Msg 59  */
        "I can only tell you what you see as you move about and manipulate things.  I\n"+
        "cannot tell you where remote things are.",

        /*  Msg 60  */
        "I don't know that word.",

        /*  Msg 61  */
        "What?",

        /*  Msg 62  */
        "Are you trying to get into the cave?",

        /*  Msg 63  */
        "The grate is very solid and has a hardened steel lock.  You cannot enter\n"+
        "without a key, and there are no keys nearby. I would recommend looking\n"+
        "elsewhere for the keys.",

        /*  Msg 64  */
        "The trees of the forest are large hardwood oak and maple, with an occasional\n"+
        "grove of pine or spruce.  There is quite a bit of undergrowth, largely birch\n"+
        "and ash saplings plus nondescript bushes of various sorts.  This time of\n"+
        "year visibility is quite restricted by all the leaves, but travel is quite\n"+
        "easy if you detour around the spruce and berry bushes.",

        /*  Msg 65  */
        "Welcome to adventure!!  Would you like instructions?",

        /*  Msg 66  */
        "Digging without a shovel is quite impractical.  Even with a shovel progress\n"+
        "is unlikely.",

        /*  Msg 67  */
        "Blasting requires dynamite.",

        /*  Msg 68  */
        "I'm as confused as you are.",

        /*  Msg 69  */
        "Mist is a white vapor, usually water.  Seen from time to time in caverns.\n"+
        "It can be found anywhere but is frequently a sign of a deep pit leading down\n"+
        "to water.",

        /*  Msg 70  */
        "Your feet are now wet.",

        /*  Msg 71  */
        "I think I just lost my appetite.",

        /*  Msg 72  */
        "Thank you.  It was delicious!",

        /*  Msg 73  */
        "You have taken a drink from the stream.  The water tastes strongly of\n"+
        "minerals, but is not unpleasant.  It is extremely cold.",

        /*  Msg 74  */
        "The bottle of water is now empty.",

        /*  Msg 75  */
        "Rubbing the electric lamp is not particularly rewarding. Anyway, nothing\n"+
        "exciting happens.",

        /*  Msg 76  */
        "Peculiar.  Nothing unexpected happens.",

        /*  Msg 77  */
        "Your bottle is empty and the ground is wet.",

        /*  Msg 78  */
        "You can't pour that.",

        /*  Msg 79  */
        "Watch it!",

        /*  Msg 80  */
        "Which way?",

        /*  Msg 81  */
        "Oh dear, you seem to have gotten yourself killed.  I might be able to help\n"+
        "you out, but I've never really done this before.  Do you want me to try to\n"+
        "reincarnate you?",

        /*  Msg 82  */
        "All right.  But don't blame me if something goes wr......\n"+
        "                    --- POOF !! ---\n"+
        "You are engulfed in a cloud of orange smoke.  Coughing and gasping, you\n"+
        "emerge from the smoke and find...",

        /*  Msg 83  */
        "You clumsy oaf, you've done it again!  I don't know how long I can keep this\n"+
        "up.  Do you want me to try reincarnating you again?",

        /*  Msg 84  */
        "Okay, now where did i put my orange smoke? ... > POOF! <\n"+
        "Everything disappears in a dense cloud of orange smoke.",

        /*  Msg 85  */
        "Now you've really done it!  I'm out of orange smoke!  You don't expect me to\n"+
        "do a decent reincarnation without any orange smoke, do you?",

        /*  Msg 86  */
        "Okay, If you're so smart, do it yourself!  I'm leaving!",

        /*  Msg 87  */
        "",

        /*  Msg 88  */
        "",

        /*  Msg 89  */
        "",

        /*  Msg 90  */
        "",

        /*  Msg 91  */
        "Sorry, but I no longer seem to remember how it was you got here.",

        /*  Msg 92  */
        "You can't carry anything more.  You'll have to drop something first.",

        /*  Msg 93  */
        "You can't go through a locked steel grate!",

        /*  Msg 94  */
        "I believe what you want is right here with you.",

        /*  Msg 95  */
        "You don't fit through a two-inch slit!",

        /*  Msg 96  */
        "I respectfully suggest you go across the bridge instead of jumping.",

        /*  Msg 97  */
        "There is no way across the fissure.",

        /*  Msg 98  */
        "You're not carrying anything.",

        /*  Msg 99  */
        "You are currently holding the following:",

        /*  Msg 100  */
        "It's not hungry (It's merely pinin' for the Fjords).  Besides you have no\n"+
        "bird seed.",

        /*  Msg 101  */
        "The snake has now devoured your bird.",

        /*  Msg 102  */
        "There's nothing here it wants to eat (Except perhaps you).",

        /*  Msg 103  */
        "You fool, Dwarves eat only coal!  Now you've made him REALLY mad !!",

        /*  Msg 104  */
        "You have nothing in which to carry it.",

        /*  Msg 105  */
        "Your bottle is already full.",

        /*  Msg 106  */
        "There is nothing here with which to fill the bottle.",

        /*  Msg 107  */
        "Your bottle is now full of water.",

        /*  Msg 108  */
        "Your bottle is now full of oil.",

        /*  Msg 109  */
        "You can't fill that.",

        /*  Msg 110  */
        "Don't be ridiculous!",

        /*  Msg 111  */
        "The door is extremely rusty and refuses to open.",

        /*  Msg 112  */
        "The plant indignantly shakes the oil off its leaves and asks: \"Water?\".",

        /*  Msg 113  */
        "The hinges are quite thoroughly rusted now and won't budge.",

        /*  Msg 114  */
        "The oil has freed up the hinges so that the door will now move, although it\n"+
        "requires some effort.",

        /*  Msg 115  */
        "The plant has exceptionally deep roots and cannot be pulled free.",

        /*  Msg 116  */
        "The Dwarves' knives vanish as they strike the walls of the cave.",

        /*  Msg 117  */
        "Something you're carrying won't fit through the tunnel with you.  You'd best\n"+
        "take inventory and drop something.",

        /*  Msg 118  */
        "You can't fit this five-foot clam through that little passage!",

        /*  Msg 119  */
        "You can't fit this five foot oyster through that little passage!",

        /*  Msg 120  */
        "I advise you to put down the clam before opening it. >STRAIN!<",

        /*  Msg 121  */
        "I advise you to put down the oyster before opening it. >WRENCH!<",

        /*  Msg 122  */
        "You don't have anything strong enough to open the clam.",

        /*  Msg 123  */
        "You don't have anything strong enough to open the oyster.",

        /*  Msg 124  */
        "A glistening pearl falls out of the clam and rolls away. Goodness, this must\n"+
        "really be an oyster.  (I never was very good at identifying bivalves.)\n"+
        "Whatever it is, it has now snapped shut again.",

        /*  Msg 125  */
        "The oyster creaks open, revealing nothing but oyster inside. It promptly\n"+
        "snaps shut again.",

        /*  Msg 126  */
        "You have crawled around in some little holes and found your way blocked by a\n"+
        "recent cave-in.  You are now back in the main passage.",

        /*  Msg 127  */
        "There are faint rustling noises from the darkness behind you.",

        /*  Msg 128  */
        "Out from the shadows behind you pounces a bearded pirate! \"Har, har\" he\n"+
        "chortles, \"I'll just take all this booty and hide it away with me chest deep\n"+
        "in the maze!\".  He snatches your treasure and vanishes into the gloom.",

        /*  Msg 129  */
        "A sepulchral voice reverberating through the cave says: \"Cave closing soon.\n"+
        "All adventurers exit immediately through main office.\"",

        /*  Msg 130  */
        "A mysterious recorded voice groans into life and announces: \"This exit is\n"+
        "closed.  Please leave via main office.\"",

        /*  Msg 131  */
        "It looks as though you're dead.  Well, seeing as how it's so close to\n"+
        "closing time anyway, I think we'll just call it a day.",

        /*  Msg 132  */
        "The sepulchral voice entones, \"The cave is now closed.\"  As the echoes fade,\n"+
        "there is a blinding flash of light (and a small puff of orange smoke). . . .\n"+
        "As your eyes refocus you look around and find...",

        /*  Msg 133  */
        "There is a loud explosion, and a twenty-foot hole appears in the far wall,\n"+
        "burying the Dwarves in the rubble.  You march through the hole and find\n"+
        "yourself in the main office, where a cheering band of friendly elves carry\n"+
        "the conquering adventurer off into the sunset.",

        /*  Msg 134  */
        "There is a loud explosion, and a twenty-foot hole appears in the far wall,\n"+
        "burying the snakes in the rubble.  A river of molten lava pours in through\n"+
        "the hole, destroying everything in its path, including you!!",

        /*  Msg 135  */
        "There is a loud explosion, and you are suddenly splashed across the walls of\n"+
        "the room.",

        /*  Msg 136  */
        "The resulting ruckus has awakened the Dwarves.  There are now several\n"+
        "threatening little Dwarves in the room with you! Most of them throw knives\n"+
        "at you!  All of them get you!",

        /*  Msg 137  */
        "Oh, leave the poor unhappy bird alone.",

        /*  Msg 138  */
        "I daresay whatever you want is around here somewhere.",

        /*  Msg 139  */
        "I don't know the word \"stop\".   Use \"quit\" if you want to give up.",

        /*  Msg 140  */
        "You can't get there from here.",

        /*  Msg 141  */
        "You are being followed by a very large, tame bear.",

        /*  Msg 142  */
        "@208,209,210",

        /*  Msg 143  */
        "Do you indeed wish to quit now?",

        /*  Msg 144  */
        "There is nothing here with which to fill the vase.",

        /*  Msg 145  */
        "The sudden change in temperature has delicately shattered the vase.",

        /*  Msg 146  */
        "It is beyond your power to do that.",

        /*  Msg 147  */
        "I don't know how.",

        /*  Msg 148  */
        "It is too far up for you to reach.",

        /*  Msg 149  */
        "You killed a little Dwarf.  The body vanished in a cloud of greasy black\n"+
        "smoke.",

        /*  Msg 150  */
        "The shell is very strong and impervious to attack.",

        /*  Msg 151  */
        "What's the matter, can't you read?  Now you'd best start over.",

        /*  Msg 152  */
        "The axe bounces harmlessly off the dragon's thick scales.",

        /*  Msg 153  */
        "The dragon looks rather nasty.  You'd best not try to get by.",

        /*  Msg 154  */
        "The little bird attacks the green dragon, and in an astounding flurry gets\n"+
        "burnt to a cinder.  The ashes blow away.",

        /*  Msg 155  */
        "On what?",

        /*  Msg 156  */
        "Okay, from now on I'll only describe a place in full the first time you come\n"+
        "to it.  To get the full description say \"look\".",

        /*  Msg 157  */
        "Trolls are close relatives with the rocks and have skin as tough as that of\n"+
        "a rhinoceros.  The troll fends off your blows effortlessly.",

        /*  Msg 158  */
        "The troll deftly catches the axe, examines it carefully, and tosses it back,\n"+
        "declaring, \"Good workmanship, but it's not valuable enough.\".",

        /*  Msg 159  */
        "The troll catches your treasure and scurries away out of sight.",

        /*  Msg 160  */
        "The troll refuses to let you cross.",

        /*  Msg 161  */
        "There is no longer any way across the chasm.",

        /*  Msg 162  */
        "Just as you reach the other side, the bridge buckles beneath the weight of\n"+
        "the bear, which was still following you around. You scrabble desperately for\n"+
        "support, but as the bridge collapses you stumble back and fall into the\n"+
        "chasm.",

        /*  Msg 163  */
        "The bear lumbers toward the troll, who lets out a startled shriek and\n"+
        "scurries away.  The bear soon gives up pursuit and wanders back.",

        /*  Msg 164  */
        "The axe misses and lands near the bear where you can't get at it.",

        /*  Msg 165  */
        "With what?  Your bare hands?  Agains HIS bear hands??",

        /*  Msg 166  */
        "The bear is confused;  he only wants to be your friend.",

        /*  Msg 167  */
        "For crying out loud, the poor thing is already dead!",

        /*  Msg 168  */
        "The bear eagerly wolfs down your food, after which he seems to calm down\n"+
        "considerably, and even becomes rather friendly.",

        /*  Msg 169  */
        "The bear is still chained to the wall.",

        /*  Msg 170  */
        "The chain is still locked.",

        /*  Msg 171  */
        "The chain is now unlocked.",

        /*  Msg 172  */
        "The chain is now locked.",

        /*  Msg 173  */
        "There is nothing here to which the chain can be locked.",

        /*  Msg 174  */
        "There is nothing here to eat.",

        /*  Msg 175  */
        "Do you want the hint?",

        /*  Msg 176  */
        "Do you need help getting out of the maze?",

        /*  Msg 177  */
        "You can make the passages look less alike by dropping things.",

        /*  Msg 178  */
        "Are you trying to explore beyond the plover room?",

        /*  Msg 179  */
        "There is a way to explore that region without having to worry about falling\n"+
        "into a pit.  None of the objects available is immediately useful in\n"+
        "discovering the secret.",

        /*  Msg 180  */
        "Do you need help getting out of here?",

        /*  Msg 181  */
        "Don't go west.",

        /*  Msg 182  */
        "Gluttony is not one of the Troll's vices.  Avarice, however, is.",

        /*  Msg 183  */
        "Your lamp is getting dim.. You'd best start wrapping this up, unless you can\n"+
        "find some fresh batteries.  I seem to recall there's a vending machine in\n"+
        "the maze.  Bring some coins with you.",

        /*  Msg 184  */
        "Your lamp has run out of power.",

        /*  Msg 185  */
        "There's not much point in wandering around out here, and you can't explore\n"+
        "the cave without a lamp.  So let's just call it a day.",

        /*  Msg 186  */
        "There are faint rustling noises from the darkness behind you. As you turn\n"+
        "toward them, the beam of your lamp falls across a bearded pirate.  He is\n"+
        "carrying a large chest.  \"Shiver me timbers!\"  he cries, \"I've been spotted!\n"+
        "I'd best hide meself off to the maze and hide me chest!\".  With that, he\n"+
        "vanished into the gloom.",

        /*  Msg 187  */
        "Your lamp is getting dim.  You'd best go back for those batteries.",

        /*  Msg 188  */
        "Your lamp is getting dim.. I'm taking the liberty of replacing the\n"+
        "batteries.",

        /*  Msg 189  */
        "Your lamp is getting dim, and you're out of spare batteries. You'd best\n"+
        "start wrapping this up.",

        /*  Msg 190  */
        "I'm afraid the magazine is written in Dwarvish.",

        /*  Msg 191  */
        "\"This is not the maze where the pirate leaves his treasure chest.\"",

        /*  Msg 192  */
        "Hmm, this looks like a clue, which means it'll cost you 10 points to read\n"+
        "it.  Should I go ahead and read it anyway?",

        /*  Msg 193  */
        "It says, \"There is something strange about this place, such that one of the\n"+
        "words I've always known now has a new effect.\"",

        /*  Msg 194  */
        "It says the same thing it did before.",

        /*  Msg 195  */
        "I'm afraid I don't understand.",

        /*  Msg 196  */
        "\"Congratulations on bringing light into the dark-room!\"",

        /*  Msg 197  */
        "You strike the mirror a resounding blow, whereupon it shatters into a myriad\n"+
        "tiny fragments.",

        /*  Msg 198  */
        "You have taken the vase and hurled it delicately to the ground.",

        /*  Msg 199  */
        "You prod the nearest Dwarf, who wakes up grumpily, takes one look at you,\n"+
        "curses, and grabs for his axe.",

        /*  Msg 200  */
        "Is this acceptable?",

        /*  Msg 201  */
        "There's no point in suspending a demonstration game.",

        /*  Msg 202  */
        "Somewhere nearby is Colossal Cave, where others have found fortunes in\n"+
        "treasure and gold, though it is rumored that some who enter are never seen\n"+
        "again.  Magic is said to work in the cave.  I will be your eyes and hands.\n"+
        "Direct me with commands of 1 or 2 words.  I should warn you that I look at\n"+
        "only the first five letters of each word, so you'll have to enter\n",

        /*  Msg 203  */
        "\"Northeast\" as \"ne\" to distinguish it from \"North\".  (Should you get stuck,\n"+
        "type \"help\" for some general hints.\n",

        /*  Msg 204  */
        "This program was originally developed by Willie Crowther. Most of the\n"+
        "features of the current program were added by Don Woods.  This version,\n"+
        "written in BDS 8080 C was adapted by Jay R. Jaeger and was later ported to\n"+
        "MSC V5.1 on the IBM/PC by Bob Withers.\n",

        /*  Msg 205  */
        "I know of places, actions, and things.  Most of my vocabulary describes\n"+
        "places and is used to move you there.  To move, try words like forest,\n"+
        "building, downstream, enter, east, west, north, south, up or down.  I know\n"+
        "about a few special objects, like a black rod hidden in the cave.  These\n"+
        "objects can be manipulated using some of the action words I know. Usually\n"+
        "you will need to give both the object and action words (In either order),",

        /*  Msg 206  */
        "but sometimes I can infer the object from the verb alone.  Some objects also\n"+
        "imply verbs; in particular, \"inventory\" implies \"take inventory\", which\n"+
        "causes me to give you a list of what you're carrying.  The objects have side\n"+
        "effects; for instance, the rod scares the bird.  Usually people having\n"+
        "trouble moving just need to try a few more words.  Usually people trying\n"+
        "unsuccessfully to manipulate an object are attempting something beyond their",

        /*  Msg 207  */
        "(or my!) capabilities and should try a completely different tack.  To speed\n"+
        "the game you can sometimes move long distances with a single word.  For\n"+
        "example, \"building\" usually gets you to the building from anywhere above\n"+
        "ground except when lost in the forest.  Also, note that cave passages turn a\n"+
        "lot, and that leaving a room to the north does not guarantee entering the\n"+
        "next from the south.\n"+
        "\n"+
        "Good luck!",

        /*  Msg 208  */
        "If you want to end your adventure early, say \"quit\".  To suspend you\n"+
        "adventure such that you can continue later say \"suspend\" (or \"pause\" or\n"+
        "\"save\").  To see how well you're doing, say \"score\".  To get full credit for\n"+
        "a treasure, you must have left it safely in the building, though you get\n"+
        "partial credit just for locating it. You lose points for getting killed, or\n"+
        "for quitting, though the former costs you more.  There are also points based",

        /*  Msg 209  */
        "on how much (If any) of the cave you've managed to explore;  in particular,\n"+
        "there is a large bonus just for getting in (to distinguish the beginners\n"+
        "from the rest of the pack), and there are other ways to determine whether\n"+
        "you've been through some of the more harrowing sections. If you think you've\n"+
        "found all the treasures, just keep exploring for a while.  If nothing\n"+
        "interesting happens, you haven't found them all yet.  If something",

        /*  Msg 210  */
        "interesting DOES happen, it means you're getting a bonus and have an\n"+
        "opportunity to garner many more points in the master's section.  I may\n"+
        "occasionally offer hints in you seem to be having trouble.  If I do, I'll\n"+
        "warn you in advance how much it will affect your score to accept the hints.\n"+
        "Finally, to save paper, you may specify \"brief\", which tells me never to\n"+
        "repeat the full description of a place unless you explicitly ask me to.",

        };




    }



}
