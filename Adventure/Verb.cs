using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCS
{
    partial class TheAdventure
    {

        void  TravelVerb()
        {
            switch (Verb) {
	            case CALM:
	            case WALK:
	            case QUIT:
	            case SCORE:
	            case FOO:
	            case BRIEF:
	            case SUSPEND:
	            case HOURS:
	            case LOG:
	                vActionMsg(Verb);
	                break;

	            case TAKE:
                    vTake();
	                break;

	            case DROP:
	                vDrop();
	                break;
	            case OPEN:
	            case LOCK:
                    vOpen();
	                break;
	            case SAY:
	                vSay();
	                break;
	            case NOTHING:
	                rspeak(54);
	                break;
	            case ON:
	                vOn();
	                break;
	            case OFF:
	                vOff();
	                break;
	            case WAVE:
	                vWave();
	                break;
	            case KILL:
	                vKill();
	                break;
	            case POUR:
	                vPour();
	                break;
	            case EAT:
	                vEat();
	                break;
	            case DRINK:
	                vDrink();
	                break;
	            case RUB:
                    if (aeobject != LAMP)
		                rspeak(76);
	                else
		                vActionMsg(RUB);
	                break;
	            case THROW:
	                vThrow();
	                break;
	            case FEED:
	                vFeed();
	                break;
	            case FIND:
	            case INVENTORY:
	                vFind();
	                break;
	            case FILL:
	                vFill();
	                break;
	            case READ:
	                vRead();
	                break;
	            case BLAST:
	                vBlast();
	                break;
	            case BREAK:
	                vBreak();
	                break;
	            case WAKE:
	                vWake();
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
	            default:
	                Console.WriteLine("This verb is not implemented yet.\n");
                    break;
            }

        return;
    }

        /*
                CARRY TAKE etc.
        */
        void vTake()
        {
            int	msg;
            int	i;

            if (toting(aeobject)) {
	            vActionMsg(Verb);
	            return;
            }

            /* special case objects and fixed objects */
            msg = 25;

            if (aeobject == PLANT && Property[PLANT] <= 0)
	            msg = 115;

            if (aeobject == BEAR && Property[BEAR] == 1)
	            msg = 169;

            if (aeobject == CHAIN && Property[BEAR] != 0)
	            msg = 170;

            if (FixedLocation[aeobject] > 0) {
	            rspeak(msg);
	            return;
            }

            /* special case for liquids */
            if (aeobject == WATER || aeobject == OIL) {
	            if (!IsHere(BOTTLE) || liq() != aeobject) {
	                aeobject = BOTTLE;
	                if (toting(BOTTLE) && Property[BOTTLE] == 1) {
                        vFill();
		                return;
	                }

	                if (Property[BOTTLE] != 1)
		                msg = 105;
	                if (!toting(BOTTLE))
		                msg = 104;

	                rspeak(msg);
	                return;
	            }

	            aeobject = BOTTLE;
            }

            if (Holding >= 7) {
	            rspeak(92);
	            return;
            }

            /* special case for bird. */
            if (aeobject == BIRD && Property[BIRD] == 0) {
	            if (toting(ROD)) {
	                rspeak(26);
	                return;
	            }

	            if (!toting(CAGE)) {
	                rspeak(27);
	                return;
	            }

	            Property[BIRD] = 1;
            }

            if ((aeobject == BIRD || aeobject == CAGE) && Property[BIRD] != 0)
                Carry((BIRD + CAGE) - aeobject, Location);

            Carry(aeobject, Location);

            /* handle liquid in bottle */
            i = liq();
            if (aeobject == BOTTLE && i != 0)
	            Place[i] = -1;
            rspeak(54);

            return;
        }

/*
        DROP etc.
*/
        void vDrop()
        {
            int      i;

            /* check for dynamite */
            if (toting(ROD2) && aeobject == ROD && !toting(ROD))
	            aeobject = ROD2;

            if (!toting(aeobject))
            {
	        vActionMsg(Verb);
	        return;
            }

            /* snake and bird */
            if (aeobject == BIRD && IsHere(SNAKE)) {
	            rspeak(30);
	            if (b_closed)
	                dwarfend();

	            dstroy(SNAKE);
	            Property[SNAKE] = -1;
            }
            else {			/* coins and vending machine */
	        if (aeobject == COINS && IsHere(VEND)) {
	            dstroy(COINS);
                drop(BATTERIES, Location);
	            pspeak(BATTERIES, 0);
	            return;
	        }
	        else			/* bird and dragon (ouch!!) */
	        {
	            if (aeobject == BIRD && at(DRAGON) && Property[DRAGON] == 0) {
		            rspeak(154);
		            dstroy(BIRD);
		            Property[BIRD] = 0;
		            if (Place[SNAKE] != 0)
		                ++Tally2;
		            return;
	            }
	        }
            }

            /* Bear and troll */
            if (aeobject == BEAR && at(TROLL)) {
	            rspeak(163);
                Move(TROLL, 0);
                Move((TROLL + MAXOBJ), 0);
                Move(TROLL2, 117);
                Move((TROLL2 + MAXOBJ), 122);
                Juggle(CHASM);
	            Property[TROLL] = 2;
            }
            else {			/* vase */
	            if (aeobject == VASE) {
                    if (Location == 96)
		                rspeak(54);
	                else {
		                Property[VASE] = at(PILLOW) ? 0 : 2;
		                pspeak(VASE, Property[VASE] + 1);
		                if (Property[VASE] != 0)
		                    FixedLocation[VASE] = -1;
	                }
	            }
            }

            /* handle liquid and bottle */
            i = liq();
            if(i == aeobject)
                aeobject = BOTTLE;

            if (aeobject == BOTTLE && i != 0)
	            Place[i] = 0;

            /* handle bird and cage */
            if (aeobject == CAGE && Property[BIRD] != 0)
                drop(BIRD, Location);
            if (aeobject == BIRD)
	            Property[BIRD] = 0;

            drop(aeobject, Location);

            return;
        }

        /*
                LOCK, UNLOCK, OPEN, CLOSE etc.
        */
        void vOpen()
        {
            int msg, oyclam;

            switch (aeobject) {
	            case CLAM:
	            case OYSTER:
	                oyclam = (aeobject == OYSTER ? 1 : 0);
	                if (Verb == LOCK)
		                msg = 61;
	                else {
		                if (!toting(TRIDENT))
		                    msg = 122 + oyclam;
		                else {
		                    if (toting(aeobject))
			                    msg = 120 + oyclam;
		                    else {
			                    msg = 124 + oyclam;
			                    dstroy(CLAM);
                                drop(OYSTER, Location);
			                    drop(PEARL, 105);
		                    }
		                }
	                }
	                break;
	            case DOOR:
	                msg = (Property[DOOR] == 1 ? 54 : 111);
	                break;
	            case CAGE:
	                msg = 32;
	                break;
	            case KEYS:
	                msg = 55;
	                break;
	            case CHAIN:
	                if (!IsHere(KEYS))
		                msg = 31;
	                else {
		                if (Verb == LOCK) {
		                    if (Property[CHAIN] != 0)
			                    msg = 34;
		                    else
                                if (Location != 130)
			                    msg = 173;
		                    else {
			                    Property[CHAIN] = 2;
			                    if (toting(CHAIN))
                                    drop(CHAIN, Location);
			                    FixedLocation[CHAIN] = -1;
			                    msg = 172;
		                    }
		                }
		                else {
		                    if (Property[BEAR] == 0)
			                    msg = 41;
		                    else {
			                    if (Property[CHAIN] == 0)
			                        msg = 37;
			                    else {
			                        Property[CHAIN] = 0;
			                        FixedLocation[CHAIN] = 0;
			                        if (Property[BEAR] != 3)
				                        Property[BEAR] = 2;
			                        FixedLocation[BEAR] = 2 - Property[BEAR];
			                        msg = 171;
			                    }
		                    }
		                }
	                }
	                break;
	            case GRATE:
	                if (!IsHere(KEYS))
		                msg = 31;
	                else {
		                if(bClosing) {
                            if (Panic == 0) {
			                    clock2 = 15;
                                ++Panic;
		                    }
		                    msg = 130;
		                }
		                else {
		                    msg = 34 + Property[GRATE];
		                    Property[GRATE] = (Verb == LOCK ? 0 : 1);
		                    msg += 2 * Property[GRATE];
		                }
	                }
	                break;
	            default:
	                msg = 33;
                    break;
            }
            rspeak(msg);
            return;
        }

        /*
                SAY etc.
        */
        void vSay()
        {
            int wtype = 0, wval = 0;

            AnalyzeWord(word1, ref wtype, ref wval);
            Console.WriteLine("Okay.\n%s\n", wval == SAY ? word2 : word1);
            return;
        }

        /*
                ON etc.
        */
        void vOn()
        {
            if (!IsHere(LAMP))
	            vActionMsg(Verb);
            else {
	            if (limit < 0)
	                rspeak(184);
	            else {
	                Property[LAMP] = 1;
	                rspeak(39);
	                if (true == b_wzdark) {
	                    b_wzdark = false;
                        Describe();
                        DescribeItem();
	                }
	            }
            }

            return;
        }

        /*
                OFF etc.
        */
        void vOff()
        {
            if (!IsHere(LAMP))
	            vActionMsg(Verb);
            else {
	            Property[LAMP] = 0;
	            rspeak(40);
            }

            return;
        }

        /*
                WAVE etc.
        */
        void vWave()
        {
            if (!toting(aeobject) && (aeobject != ROD || !toting(ROD2)))
	            rspeak(29);
            else {
	            if (aeobject != ROD || !at(FISSURE) || !toting(aeobject) || bClosing)
	                vActionMsg(Verb);
	            else {
	                Property[FISSURE] = 1 - Property[FISSURE];
	                pspeak(FISSURE, 2 - Property[FISSURE]);
	            }
            }
        }

        /*
                ATTACK, KILL etc.
        */
        void vKill()
        {
            int      msg = 0;
            int      i = 0;

            switch (aeobject) {
	            case BIRD:
	                if ( b_closed)
		                msg = 137;
	                else {
		                dstroy(BIRD);
		                Property[BIRD] = 0;
		                if (Place[SNAKE] == 19)
		                    ++Tally2;
		                msg = 45;
	                }
	                break;
	            case 0:
	                msg = 44;
	                break;
	            case CLAM:
	            case OYSTER:
	                msg = 150;
	                break;
	            case SNAKE:
	                msg = 46;
	                break;
	            case DWARF:
	                if( b_closed )
		                dwarfend();
	                msg = 49;
	                break;
	            case TROLL:
	                msg = 157;
	                break;
	            case BEAR:
	                msg = 165 + (Property[BEAR] + 1) / 2;
	                break;
	            case DRAGON:
	                if (Property[DRAGON] != 0) {
		                msg = 167;
		                break;
	                }
	                if (false == ReadInputLine(49, 0, 0))
		                break;
	                pspeak(DRAGON, 1);
	                Property[DRAGON] = 2;
	                Property[RUG] = 0;
                    Move((DRAGON + MAXOBJ), -1);
                    Move((RUG + MAXOBJ), 0);
                    Move(DRAGON, 120);
                    Move(RUG, 120);
                    for(i = 1; i < MAXOBJ; ++i) {
                        if(Place[i] == 119 || Place[i] == 121)
                            Move(i, 120);
                    }
                    NewLocation = 120;
	                return;
	            default:
	                vActionMsg(Verb);
	                return;
            }
            rspeak(msg);
        }

        /*
                POUR
        */
        void vPour()
        {
            if (aeobject == BOTTLE || aeobject == 0)
	            aeobject = liq();

            if (aeobject == 0) {
	            NeedObj();
	            return;
            }

            if (!toting(aeobject)) {
	            vActionMsg(Verb);
	            return;
            }

            if (aeobject != OIL && aeobject != WATER) {
	            rspeak(78);
	            return;
            }

            Property[BOTTLE] = 1;
            Place[aeobject] = 0;

            if (at(PLANT)) {
	            if (aeobject != WATER)
	                rspeak(112);
	            else {
	                pspeak(PLANT, Property[PLANT] + 1);
	                Property[PLANT] = (Property[PLANT] + 2) % 6;
	                Property[PLANT2] = Property[PLANT] / 2;
                    Describe();
	            }
            }
            else {
	            if (at(DOOR)) {
	                Property[DOOR] = (aeobject == OIL ? 1 : 0);
	                rspeak(113 + Property[DOOR]);
	            }
	            else
	                rspeak(77);
            }

            return;
        }

        /*
                EAT
        */
        void vEat()
        {
            int      msg = 0;

            switch (aeobject) {
	            case FOOD:
	                dstroy(FOOD);
	                msg = 72;
	                break;
	            case BIRD:
	            case SNAKE:
	            case CLAM:
	            case OYSTER:
	            case DWARF:
	            case DRAGON:
	            case TROLL:
	            case BEAR:
	                msg = 71;
	                break;
	            default:
	                vActionMsg(Verb);
	                return;
            }
            rspeak(msg);
            return;
        }

        /*
                DRINK
        */
        void vDrink()
        {
            if (aeobject != WATER)
	            rspeak(110);
            else {
	            if (liq() != WATER || !IsHere(BOTTLE))
	                vActionMsg(Verb);
	            else {
	                Property[BOTTLE] = 1;
	                Place[WATER] = 0;
	                rspeak(74);
	            }
            }

            return;
        }

        /*
                THROW etc.
        */
        void vThrow()
        {
            int      msg = 0;
            int i = 0;

            if (toting(ROD2) && aeobject == ROD && !toting(ROD))
	            aeobject = ROD2;

            if (!toting(aeobject)) {
	            vActionMsg(Verb);
	            return;
            }

            /* treasure to troll */
            if (at(TROLL) && aeobject >= 50 && aeobject < MAXOBJ) {
	            rspeak(159);
	            drop(aeobject, 0);
                Move(TROLL, 0);
                Move((TROLL + MAXOBJ), 0);
	            drop(TROLL2, 117);
	            drop((TROLL2 + MAXOBJ), 122);
                Juggle(CHASM);
	            return;
            }

            /* feed the bears... */
            if (aeobject == FOOD && IsHere(BEAR)) {
	            aeobject = BEAR;
                vFeed();
	            return;
            }

            /* if not axe, same as drop... */
            if (aeobject != AXE) {
                vDrop();
	            return;
            }

            /* AXE is THROWN */
            /* at a dwarf... */
            i = dcheck();
            if( i > 0 ) {
	            msg = 48;

	        if (pct(33)) {
	            DwarfSeen[i] = DwarfLocation[i] = 0;
	            msg = 47;
	            ++DwarvesKilled;
	            if (DwarvesKilled == 1)
		            msg = 149;
	        }
            }
            else {			/* at a dragon... */
	            if (at(DRAGON) && Property[DRAGON] == 0)
	                msg = 152;
	            else {			/* at the troll... */
	                if (at(TROLL))
		                msg = 158;
	                else {		/* at the bear... */
		                if (IsHere(BEAR) && Property[BEAR] == 0) {
		                    rspeak(164);
                            drop(AXE, Location);
		                    FixedLocation[AXE] = -1;
		                    Property[AXE]  = 1;
                            Juggle(BEAR);
		                    return;
		                }
		                else {		/* otherwise it is an attack */
		                    Verb = KILL;
		                    aeobject = 0;
		                    itVerb();
		                    return;
		                }
	                }
	            }
            }

            /* handle the left over axe... */
            rspeak(msg);
            drop(AXE, Location);
            Describe();
            return;
        }

        /*
                INVENTORY, FIND etc.
        */
        void vFind()
        {
            int msg = 0;

            if (toting(aeobject))
	            msg = 24;
            else {
	            if (b_closed)
	                msg = 138;
	            else {
	                int i = dcheck();
                    if (i > 0 && DwarfFlag >= 2 && aeobject == DWARF)
		                msg = 94;
	                else {
                        if (at(aeobject) || (liq() == aeobject && IsHere(BOTTLE)) || aeobject == liqloc(Location))
		                    msg = 94;
		                else {
		                    vActionMsg(Verb);
		                    return;
		                }
	                }
	            }
            }
            rspeak(msg);

            return;
        }

        /*
                FILL
        */
        void vFill()
        {
            int	    i = 0;
            int   msg = 0;

            switch (aeobject) {
	            case BOTTLE:
	                if (liq() != 0)
		                msg = 105;
	                else {
                        if (liqloc(Location) == 0)
		                    msg = 106;
		                else {
                            Property[BOTTLE] = Condition[Location] & WATOIL;
		                    i = liq();
		                    if (toting(BOTTLE))
			                    Place[i] = -1;
		                    msg = (i == OIL ? 108 : 107);
		                }
	                }
	                break;
	            case VASE:
                    if (liqloc(Location) == 0) {
		                msg = 144;
		                break;
	                }
	                if (!toting(VASE)) {
		                msg = 29;
		                break;
	                }
	                rspeak(145);
                    vDrop();
	                return;
	            default:
	                msg = 29;
                    break;
            }
            rspeak(msg);
        }

        /*
                FEED
        */
        void vFeed()
        {
            int      msg = 0;

            switch (aeobject) {
	            case BIRD:
	                msg = 100;
	                break;
	            case DWARF:
	                if (!IsHere(FOOD)) {
		                vActionMsg(Verb);
		                return;
	                }
                    ++DwarfFlag;
	                msg = 103;
	                break;
	            case BEAR:
	                if (!IsHere(FOOD)) {
		                if (Property[BEAR] == 0)
		                    msg = 102;
		                else {
		                    if (Property[BEAR] == 3)
			                    msg = 110;
		                    else {
			                    vActionMsg(Verb);
			                    return;
		                    }
		                }
		                break;
	                }
	                dstroy(FOOD);
	                Property[BEAR] = 1;
	                FixedLocation[AXE] = 0;
	                Property[AXE] = 0;
	                msg = 168;
	                break;
	            case DRAGON:
	                msg = (Property[DRAGON] != 0 ? 110 : 102);
	                break;
	            case TROLL:
	                msg = 182;
	                break;
	            case SNAKE:
	                if( b_closed || !IsHere(BIRD)) {
		                msg = 102;
		                break;
	                }
	                msg = 101;
	                dstroy(BIRD);
	                Property[BIRD] = 0;
	                ++Tally2;
	                break;
	            default:
	                msg = 14;
                    break;
            }
            rspeak(msg);
        }

        /*
                READ etc.
        */
        void vRead()
        {
            int      msg = 0;

            if (IsDark()) {
	            Console.WriteLine("I see no %s here.\n", probj(aeobject));
	            return;
            }
            switch (aeobject) {
	            case MAGAZINE:
	                msg = 190;
	                break;
	            case TABLET:
	                msg = 196;
	                break;
	            case MESSAGE:
	                msg = 191;
	                break;
	            case OYSTER:
	                if (!toting(OYSTER) || false == b_closed)
		            break;
	                ReadInputLine(192, 193, 54);
	                return;
	            default:
	                ;
                    break;
            }
            if (msg > 0)
	            rspeak(msg);
            else
	            vActionMsg(Verb);

            return;
        }

        /*
                BLAST etc.
        */
        void vBlast()
        {
            if (Property[ROD2] < 0 || false == b_closed)
	            vActionMsg(Verb);
            else {
	            bonus = 133;
                if (Location == 115)
	                bonus = 134;
	            if (IsHere(ROD2))
	                bonus = 135;
	            rspeak(bonus);
	            normend();
            }

            return;
        }

        /*
                BREAK etc.
        */
        void vBreak()
        {
            int      msg = 0;

            if (aeobject == MIRROR) {
	            msg = 148;
	        if (b_closed) {
	            rspeak(197);
	            dwarfend();
	        }
            }
            else {
	            if (aeobject == VASE && Property[VASE] == 0) {
	                msg = 198;
	                if (toting(VASE))
                        drop(VASE, Location);
	                Property[VASE]	= 2;
	                FixedLocation[VASE] = -1;
	            }
	            else {
	                vActionMsg(Verb);
	                return;
	            }
            }
            rspeak(msg);

            return;
        }

        /*
                WAKE etc.
        */
        void vWake()
        {
            if (aeobject != DWARF || false == b_closed)
	            vActionMsg(Verb);
            else {
	            rspeak(199);
	            dwarfend();
            }

            return;
        }

        /*
                Routine to speak default verb message
        */
        void  vActionMsg(int nVerb)
        {
            int      i = 0;

            if (nVerb < 1 || nVerb > 31)
	            bug(39);

            i = ActionMsg[nVerb];
            if( i > 0 )
	            rspeak(i);

            return;
        }

        /*
                Routine to indicate no reasonable
                object for verb found.  Used mostly by
                intransitive verbs.
        */
        void  NeedObj()
        {
            int      wtype = 0, wval = 0;

            AnalyzeWord(word1, ref wtype, ref wval);
            Console.WriteLine("%s what?\n", wtype == 2 ? word1 : word2);
            return;
        }



    }

}
