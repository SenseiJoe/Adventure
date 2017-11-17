using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCS
{
    partial class TheAdventure
    {

        private void itVerb()
        {
            switch (Verb) {
	            case DROP:
	            case SAY:
	            case WAVE:
	            case CALM:
	            case RUB:
	            case THROW:
	            case FIND:
	            case FEED:
	            case BREAK:
	            case WAKE:
	                NeedObj();
	                break;
	            case TAKE:
	                ivTake();
	                break;
	            case OPEN:
	            case LOCK:
	                ivOpen();
	                break;
	            case NOTHING:
	                rspeak(54);
	                break;
	            case ON:
	            case OFF:
	            case POUR:
                    TravelVerb();
	                break;
	            case WALK:
	                vActionMsg(Verb);
	                break;
	            case KILL:
	                ivkill();
	                break;
            #if defined
	            case EAT:
	                iveat();
	                break;
            #endif
	            case DRINK:
	                ivDrink();
	                break;
	            case QUIT:
	                ivQuit();
	                break;
            #if defined
	            case FILL:
	                ivFill();
	                 break;
            #endif
	            case BLAST:
                    vBlast();
	                break;
	            case SCORE:
	                score();
	                break;
	            case FOO:
	                ivfoo();
	                break;
	            case SUSPEND:
                    m_bSaveGame = true;
	                break;
	            case INVENTORY:
	                inventory();
	                break;
	            case SAVE:
                    SaveGame();
	                Describe();
                    DescribeItem();
	                break;
	            case RESTORE:
	                RestoreGame();
                    Describe();
                    DescribeItem();
	                break;
	            case BRIEF:
	            case VERBOSE:
                    bBrief = (BRIEF == Verb);
	                rspeak(54);
	                break;
	            default:
	                Console.WriteLine("This intransitive not implemented yet\n");
                    break;
            }

            return;            

        }

        private void ivTake()
        {
            int	anobj =0;
            int item = 1;

            for (item = 1; item < MAXOBJ; ++item) {
                if (Place[item] == Location) {
	                if (anobj != 0) {
		                NeedObj();
		                return;
	                }
	                anobj = item;
	            }
            }

            if (anobj == 0 || ((dcheck() > 0) && (DwarfFlag >= 2))) {
	            NeedObj();
	            return;
            }

            aeobject = anobj;
            vTake();
            return;            
        }

        private void ivOpen()
        {
            if (IsHere(CLAM))
	            aeobject = CLAM;

            if (IsHere(OYSTER))
	            aeobject = OYSTER;

            if (at(DOOR))
	            aeobject = DOOR;

            if (at(GRATE))
	            aeobject = GRATE;

            if (IsHere(CHAIN)) {
	            if (aeobject != 0) {
	                NeedObj();
	                return;
	            }
	            aeobject = CHAIN;
            }
            if(aeobject == 0)
            {
	            rspeak(28);
	            return;
            }
            vOpen();
            return;            
        }

        private void ivkill()
        {
            object1 = 0;

            if ((dcheck() > 0) && DwarfFlag >= 2)
	            aeobject = DWARF;

            if (IsHere(SNAKE))
	            addobj(SNAKE);

            if (at(DRAGON) && Property[DRAGON] == 0)
	            addobj(DRAGON);

            if (at(TROLL))
	            addobj(TROLL);

            if (IsHere(BEAR) && Property[BEAR] == 0)
	            addobj(BEAR);

            if (object1 != 0) {
	            NeedObj();
	            return;
            }

            if (aeobject != 0) {
                vKill();
	            return;
            }

            if (IsHere(BIRD) && Verb != THROW)
	            aeobject = BIRD;

            if (IsHere(CLAM) || IsHere(OYSTER))
	            addobj(CLAM);

            if (object1 != 0) {
	            NeedObj();
	            return;
            }
            vKill();
            return;            
        }

        private void iveat()
        {
            if(!IsHere(FOOD))
               NeedObj();
            else {
	            aeobject = FOOD;
                vEat();
            }

            return;
        }

        private void ivDrink()
        {
            if (liqloc(Location) != WATER && (liq() != WATER || !IsHere(BOTTLE)))
	            NeedObj();
            else {
	            aeobject = WATER;
                vDrink();
            }

            return;            
        }
        /*
            QUIT
        */
        private void ivQuit()
        {
            m_bGaveUp = ReadInputLine(22, 54, 54);
            if (true == m_bGaveUp)
	            normend();

            return;
        }

        private void ivFill()
        {
            if (!IsHere(BOTTLE))
	            NeedObj();
            else {
	            aeobject=BOTTLE;
                vFill();
            }

            return;            
        }

        private void ivfoo()
        {
            int	 k, msg;

            k	= vocab(word1, 3000);
            msg = 42;
            if (foobar != 1 - k) {
	            if (foobar != 0)
	                msg = 151;
	            rspeak(msg);
	            return;
            }
            foobar = k;
            if (k != 4)
	            return;
            foobar = 0;
            if (Place[EGGS] == 92 || (toting(EGGS) && Location == 92)) {
	            rspeak(msg);
	            return;
            }

            if (Place[EGGS] == 0 && Place[TROLL] == 0 && Property[TROLL] == 0)
	            Property[TROLL] = 1;

            if (IsHere(EGGS))
	            k = 1;
            else {
                if (Location == 92)
	                k = 0;
	            else
	                k = 2;
            }

            Move(EGGS, 92);
            pspeak(EGGS, k);
            
            return;
        }

        private void ivread()
        {

            if (IsHere(MAGAZINE))
	            aeobject = MAGAZINE;

            if (IsHere(TABLET))
	            aeobject = aeobject * 100 + TABLET;

            if (IsHere(MESSAGE))
	            aeobject = aeobject*100 + MESSAGE;

            if (aeobject > 100 || aeobject == 0 || IsDark()) {
	            NeedObj();
	            return;
            }

            vRead();
            return;
            
        }

        private void inventory()
        {
            int	   msg = 98;
            int	   i = 1;

            for (i = 0; i < MAXOBJ; ++i) {
	            if (i == BEAR || !toting(i))
	                continue;
	            if (msg > 0)
	                rspeak(99);
	            msg = 0;
	            pspeak(i, -1);
            }

            if (toting(BEAR))
	            msg = 141;
            if (msg > 0)
	            rspeak(msg);

            return;            
        }

        private void addobj(int obj)
        {
            if(object1 != 0)
	            return;

            if (aeobject != 0) {
	            object1 = -1;
	            return;
            }

            aeobject = obj;
            return;            

        }

    }

}
