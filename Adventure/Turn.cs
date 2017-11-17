using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCS
{
	partial class TheAdventure
	{

		private void Turn()
		{
			int	  i = 0;

			/* if closing, then he can't leave except via the main office. */
			if (NewLocation < 9 && NewLocation != 0 && bClosing)
			{
				rspeak(130);
				NewLocation = Location;
				if (Panic == 0)
					clock2 = 15;
				Panic = 1;
			}
			
			/* see if a dwarf has seen him and has come from where he wants to go. */
			if (NewLocation != Location && !forced(Location) && ((Condition[Location] & NOPIRAT) == 0)) { 
				for( i = 1; i < (DWARFMAX - 1); ++i)
					if ((OldDwarfLocation[i] == NewLocation) && (DwarfSeen[i] > 0)) {
						NewLocation = Location;
						rspeak(2);
						break;
					}
			}

			dwarves();

			/* on to the regular move. */
			if (Location != NewLocation) {
				++Turns;
				Location = NewLocation;

				/* check for death */
				if (Location == 0) {
					Death();
					return;
				}

				/* check for forced move */
				if (forced(Location)) {
					Describe();
					TravelMove();
					return;
				}

				/* check for wandering in dark */
				if (true == b_wzdark && IsDark() && pct(35)) {
					rspeak(23);
					OldLocation2 = Location;
					Death();
					return;
				}

				/* describe his situation */
				Describe();
				if (!IsDark()) {
					++Visited[Location];
					DescribeItem();
				}
			}

			if( true == b_closed) {
				if (Property[OYSTER] < 0 && toting(OYSTER))
					pspeak(OYSTER, 1);

				for ( i = 1; i <= MAXOBJ; ++i) {
					if (toting(i) && Property[i] < 0)
					Property[i] = -1 - Property[i];
				}
			}

			b_wzdark = IsDark();

			if (KnifeLocation > 0 && KnifeLocation != Location)
				KnifeLocation = 0;

			/* run the timer routine */
			if (stimer())
				return;

			/* ask what he wants to do */
			/* debug */
			if (true == Debug)
				Console.WriteLine("Your current location is %d\n", Location);

			while (!english()) {
				Console.WriteLine('>');
			} ;


			/* act on his instructions */
			if (Motion > 0)
				TravelMove();
			else {
				if(aeobject > 0)
					doobj();
				else
					itVerb();
			}

			return;
			//m_bSaveGame = false;
		}






		private void Describe()
		{
			if (toting(BEAR))
				rspeak(141);

			if (IsDark())
				rspeak(16);
			else {
				if (Visited[Location] > 0 && bBrief)
					descsh(Location);
				else
					desclg(Location);
			}
			if (Location == 33 && pct(25) && false == bClosing)
				rspeak(8);

			return;

		}

		private void DescribeItem()
		{
			int i = 0;
			int state = 0;

			for (i = 1; i < MAXOBJ; ++i)  {
				if (at(i))  {
					if (i == STEPS && toting(NUGGET))
						continue;
				
					if (Property[i] < 0)  {
						if (b_closed)
							continue;
						else  {
							Property[i] = 0;
							if (i == RUG || i == CHAIN)
								++Property[i];
							--Tally;
						}
					}
					if (i == STEPS && Location == FixedLocation[STEPS])
						state = 1;
					else
						state = Property[i];
					pspeak(i, state);
				}
			}
			if (Tally == Tally2 && Tally != 0 && limit > 35)
				limit = 35;

			return;        
		}

		private void TravelMove()
		{
			GetTravelLocation(Location);

			switch (Motion) {
				case NULLX:
					break;
				case BACK:
					GoBack();
					break;
				case LOOK:
					if (detail++ < 3)
						rspeak(15);
					b_wzdark = false;
					Visited[Location] = 0;
					NewLocation = Location;
					Location = 0;
					break;
				case CAVE:
					if (Location < 8)
						rspeak(57);
					else
						rspeak(58);
					break;
				default:
					OldLocation2 = OldLocation;
					OldLocation = Location;
					DoTravel();
					Location = 0;		/* Modified BW 09/28/85   */
					break;
			}

			return;        
		}
		private void GoBack()
		{
			int kk, k2, want, temp;
			TravelTable pSavTrav = pTravel;
			int sSavCnt;

			if (forced(OldLocation))
				want = OldLocation2;
			else
				want = OldLocation;

			OldLocation2 = OldLocation;
			OldLocation = Location;
			k2 = 0;

			if (want == Location) {
				rspeak(91);
				return;
			}

			sSavCnt = sTravCnt;

			for (kk = 0; kk < sTravCnt; ++kk) {
				int tcond = pTravel.GetCondition(kk);
				int tdest = pTravel.GetDestination(kk);
				int tverb = pTravel.GetVerb(kk);

				if ( 0 == tcond && tdest == want) {
					Motion = tverb;
					DoTravel();
					return;
				}

				if (0 == tcond) {
					k2 = kk;
					temp = tdest;
					GetTravelLocation(temp);

					// not sure
					int tdest2 = pTravel.GetDestination(0);
					if (forced(temp) && tdest2 == want)
						k2 = temp;

					pTravel = pSavTrav;
					sTravCnt = sSavCnt;
				}
			}

			if (k2 > 0) {
				Motion = pTravel.GetVerb(k2);
				DoTravel();
			}
			else
				rspeak(140);

			return;
		
		}
		private void		 DoTravel()
		{
			int     kk;
			int	    rdest=0, rverb=0, rcond=0, robject=0;
			int	    pctt;

			bool    bMvFlag = false;
			bool    bHitFlag = false;

			NewLocation = Location;

			pctt = m_rndNumber.Next() % 100;

			for (kk = 0; kk < sTravCnt && false == bMvFlag; ++kk) {
				rdest = pTravel.GetDestination(kk);
				rverb = pTravel.GetVerb(kk);
				rcond = pTravel.GetCondition(kk);
				
				robject = rcond % 100;

				if (rverb != 1 && rverb != Motion && false == bHitFlag)
					continue;
				bHitFlag = true;
				switch (rcond / 100) {
					case 0:
						if (rcond == 0 || pctt < rcond)
							bMvFlag = true;

						/* debug */
						if (rcond > 0 && true == Debug)
							Console.WriteLine("%% move {0} {1}\n", pctt, bMvFlag);

						break;

					case 1:
						if (robject == 0)
							bMvFlag = true;
						else {
							if (toting(robject))
								bMvFlag = true;
						}
						break;
					case 2:
						if (toting(robject) || at(robject))
							bMvFlag = true;
						break;
					case 3:
					case 4:
					case 5:
					case 7:
						if (Property[robject] != (rcond / 100) - 3)
							bMvFlag = true;
						break;
					default:
						bug(37);
						break;
				}
			}
			if (false == bMvFlag)
				badmove();
			else {
				if (rdest > 500)
					rspeak(rdest - 500);
				else {
					if (rdest > 300)
						spcmove(rdest);
					else
						NewLocation = rdest;
				}
			}

			return;
		
		}
		private void		 badmove()
		{
			short msg = 12;

			if (Motion >= 43 && Motion <= 50)
				msg = 9;
			if (Motion == 29 || Motion == 30)
				msg = 9;
			if (Motion == 7 || Motion == 36 || Motion == 37)
				msg = 10;
			if (Motion == 11 || Motion == 19)
				msg = 11;
			if (Verb == FIND || Verb == INVENTORY)
				msg = 59;
			if (Motion == 62 || Motion == 65)
				msg = 42;
			if (Motion == 17)
				msg = 80;

			rspeak(msg);

			return;        
		}
		private void		 spcmove(int rdest)
		{
			 switch (rdest - 300) {
				case 1:		/* plover movement via alcove */
					if( (Holding > 0) || (Holding == 1 && toting(EMERALD)))
						NewLocation = (99 + 100) - Location;
					else
						rspeak(117);
					break;
				case 2:		/* trying to remove plover, bad route */
					drop(EMERALD, Location);
					break;
				case 3:		/* troll bridge */
					if (Property[TROLL] == 1) {
						pspeak(TROLL, 1);
						Property[TROLL] = 0;
						Move(TROLL2, 0);
						Move((TROLL2 + MAXOBJ), 0);
						Move(TROLL, 117);
						Move((TROLL + MAXOBJ), 122);
						Juggle(CHASM);
						NewLocation = Location;
					}
					else {
						NewLocation = (Location == 117 ? 122 : 117);
					
						if (Property[TROLL] == 0)
							++Property[TROLL];

						if (!toting(BEAR))
							return;

						rspeak(162);
						Property[CHASM] = 1;
						Property[TROLL] = 2;
						drop(BEAR, NewLocation);
						FixedLocation[BEAR] = -1;
						Property[BEAR] = 3;
						
						if (Property[SPICES] < 0)
							++Tally2;
						
						OldLocation2 = NewLocation;
						Death();
					}
					break;
				default:
					bug(38);   
					break;
			 }
		}

		private void		 dwarfend()
		{
			Death();
			normend();			/* no return from here */
		}

		private void normend()
		{
			score();
			Environment.Exit(1);
		}

		private void score()
		{
			int	t, i, k, s;

			s = t = 0;
			for (i = 50; i <= MAXTRS; ++i)  {
			if (i == CHEST)
				k = 14;
			else
				k = i > CHEST ? 16 : 12;

			if (Property[i] >= 0)
				t += 2;

			if (Place[i] == 3 && Property[i] == 0)
				t += k - 2;
			}

			Console.WriteLine("{0}Treasures: {1}", "".PadLeft(20), s=t);
			t = (MAXDIE - NumberOfDeaths) * 10;
			if( t > 0 )
				Console.WriteLine("{0}Survival: {1}", "".PadLeft(20), t);
			s += t;
			if (false == m_bGaveUp)
				s += 4;
			t = (DwarfFlag > 0) ? 25 : 0;
			
			if( t > 0 )
				Console.WriteLine("{0}Getting Well In: {1}", "".PadLeft(20), t);
			s += t;
			t = (true == bClosing) ? 25 : 0;

			if (t > 0)
				Console.WriteLine("{0}Masters Section: {1}", "".PadLeft(20), t);

			s += t;

			if( true == b_closed)  {
				if (bonus == 0)
					t = 10;
				else {
					if (bonus == 135)
						t = 25;
					else {
						if (bonus == 134)
							t = 30;
						else {
							if (bonus == 133)
							t = 45;
						}
					}
				}
				Console.WriteLine("{0}Bonus: {1}", "".PadLeft(20), t);
				s += t;
			}

			if (Place[MAGAZINE] == 108)
				s += 1;
			s += 2;
			Console.WriteLine("{0}Score: {1}", "".PadLeft(20), s );
			Console.ReadLine();
			return;        
		}
		private void Death()
		{
			bool yea = false;

			int i, j;

			if (false == bClosing)  {
				yea = ReadInputLine(81 + NumberOfDeaths * 2, 82 + NumberOfDeaths * 2, 54);
				if (++NumberOfDeaths >= MAXDIE || (false == yea))
					normend();

				Place[WATER] = 0;
				Place[OIL] = 0;

				if (toting(LAMP))
					Property[LAMP] = 0;

				for (j = 1; j < 101; ++j) {
					i = 101 - j;
					if (toting(i))
						drop(i, i == LAMP ? 1 : OldLocation2);
				}

				NewLocation = 3;
				OldLocation = Location;
				return;
			}

			/* closing -- no resurrection... */
			rspeak(131);
			++NumberOfDeaths;
			normend();				/* no return from here */
		}
		private void		 doobj()
		{
			/* is object here?  if so, transitive */
			if (FixedLocation[aeobject] == Location || IsHere(aeobject))
				trobj();
			/* did he give grate as destination? */
			else  {
			if (aeobject == GRATE)  {
				if (Location == 1 || Location == 4 || Location == 7) {
					Motion = DEPRESSION;
					TravelMove();
				}
				else {
					if (Location > 9 && Location < 15) {
						Motion = ENTRANCE;
						TravelMove();
					}
				}
			}
			/* is it a dwarf he is after? */
			else  {
				if (dcheck() > 0 && DwarfFlag >= 2) {
					aeobject = DWARF;
					trobj();
				}
				/* is he trying to get/use a liquid? */
				else  {
					if ((liq() == aeobject && IsHere(BOTTLE)) || liqloc(Location) == aeobject)
						trobj();
					else  {
						if (aeobject == PLANT && at(PLANT2) && Property[PLANT2] == 0)  {
							aeobject = PLANT2;
							trobj();
						}
						/* is he trying to grab a knife? */
						else {
							if (aeobject == KNIFE && KnifeLocation == Location) {
								rspeak(116);
								KnifeLocation = -1;
							}
							/* is he trying to get at dynamite? */
							else  {
								if (aeobject == ROD && IsHere(ROD2)) {
									aeobject = ROD2;
									trobj();
								}
								else
									Console.WriteLine("I see no %s here.\n", probj(aeobject));
							}
						}
					}
				}
			}
			}

			return;
		
		}
/*
		Routine to process an object being
		referred to.
*/
		void trobj()
		{
			if(Verb > 0)
				TravelVerb();
			else
				Console.WriteLine("What do you want to do with the %s?\n", probj(aeobject) );

			return;
		}

/*
		Routine to print word corresponding to object
*/
		string probj(int obj = 0)
		{
			int	  wtype = 0, wval = 0;

			AnalyzeWord(word1, ref wtype, ref wval);
			return((wtype == 1) ? word1 : word2);
		}

/*
		dwarf stuff.
*/
		void dwarves()
		{
			int	i, j = 0, k, trying, attack, stick, dtotal;

			/* see if dwarves allowed here */
			if (NewLocation == 0 || forced(NewLocation) || ((Condition[NewLocation] & NOPIRAT) > 0))
				return;
			/* see if dwarves are active. */
			if (DwarfFlag == 0) {
				if (NewLocation > 15)
					++DwarfFlag;
				return;
			}

			/* if first close encounter (of 3rd kind) kill 0, 1 or 2 */
			if (DwarfFlag == 1) {
				if (NewLocation < 15 || pct(95))
					return;
				++DwarfFlag;
				for (i = 1; i < 3; ++i) {
					if (pct(50))
						DwarfLocation[m_rndNumber.Next() % 5 + 1] = 0;
				}

				for (i = 1; i < (DWARFMAX - 1); ++i) {
					if (DwarfLocation[i] == NewLocation)
						DwarfLocation[i] = DwarfAltLocation;
						 OldDwarfLocation[i] = DwarfLocation[i];
					}
					rspeak(3);
					drop(AXE, NewLocation);
					return;
			}

			dtotal = attack = stick = 0;
			for (i = 1; i < DWARFMAX; ++i) {
				if (DwarfLocation[i] == 0)
					continue;
				/* move a dwarf at random.  we don't have a matrix around to do it as
					* in the original version... */
				for (trying = 1; trying < 20; ++trying) {
					j = m_rndNumber.Next() % 106 + 15;	/* allowed area */
					if (j !=  OldDwarfLocation[i] && j != DwarfLocation[i]  &&  !(i == (DWARFMAX - 1) && (Condition[j] & NOPIRAT) == 1))
						break;
				}
				if (j == 0)
					j =  OldDwarfLocation[i];
				
				 OldDwarfLocation[i] = DwarfLocation[i];
				DwarfLocation[i] = j;
				if ((DwarfSeen[i] > 0 && NewLocation >= 15) || DwarfLocation[i] == NewLocation || OldDwarfLocation[i] == NewLocation)
					 DwarfSeen[i] = 1;
				else
					 DwarfSeen[i] = 0;

				if ( DwarfSeen[i] == 0)
					continue;
				DwarfLocation[i] = NewLocation;
				if (i == 6)
					DoPirate();
				else {
					++dtotal;
					if ( OldDwarfLocation[i] == DwarfLocation[i]) {
						++attack;
						if (KnifeLocation >= 0)
							KnifeLocation = NewLocation;
						if (m_rndNumber.Next() % 1000 < 30 * (DwarfFlag - 2))
							++stick;
					}
				}
			}
			if (dtotal == 0)
				return;
			if (dtotal > 1)
				Console.WriteLine("There are %d threatening little dwarves in the room with you!\n", dtotal);
			else
				rspeak(4);
			if (attack == 0)
				return;
			if (DwarfFlag == 2)
				++DwarfFlag;

			if (attack > 1) {
				Console.WriteLine("%d of them throw knives at you!!\n", attack);
				k = 6;
			}
			else  {
				rspeak(5);
				k = 52;
			}

			if (stick <= 1) {
				rspeak(stick + k);
				if (stick == 0)
					return;
			}
			else
				Console.WriteLine("%d of them get you !!!\n", stick);

			OldLocation2 = NewLocation;
			Death();

			return;
		}

/*
		pirate stuff
*/
	void DoPirate()
	{
		int	  j, k;

		if (NewLocation == ChestLocations || Property[CHEST] >= 0)
			return;

		k = 0;
		for (j = 50; j <= MAXTRS; ++j)
			if (j != PYRAMID || (NewLocation != Place[PYRAMID] && NewLocation != Place[EMERALD]))
			{
				if (toting(j))
					goto stealit;

				if (IsHere(j))
					++k;
			}

		if (Tally == Tally2 + 1 && k == 0 && Place[CHEST] == 0  && IsHere(LAMP) && Property[LAMP] == 1) {
			rspeak(186);
			Move(CHEST, ChestLocations);
			Move(MESSAGE, ChestLocations2);
			DwarfLocation[6] = ChestLocations;
			 OldDwarfLocation[6] = ChestLocations;
			 DwarfSeen[6] = 0;
			return;
		}
		if ( OldDwarfLocation[6] != DwarfLocation[6] && pct(20))  {
			rspeak(127);
			return;
		}
		return;

stealit:
		rspeak(128);
		if (Place[MESSAGE] == 0)
			Move(CHEST, ChestLocations);

		Move(MESSAGE, ChestLocations2);
		for (j = 50; j <= MAXTRS; ++j) {
			if (j == PYRAMID && (NewLocation == Place[PYRAMID] || NewLocation == Place[EMERALD]))
				continue;
			if (at(j) && FixedLocation[j] == 0)
				Carry(j, NewLocation);
			if (toting(j))
				drop(j, ChestLocations);
		}
		DwarfLocation[6] = ChestLocations;
		 OldDwarfLocation[6] = ChestLocations;
		 DwarfSeen[6] = 0;

		return;
	}

/*
		special time limit stuff...
*/
	bool stimer()
	{
	
		int	  i;

		foobar = foobar > 0 ? -foobar : 0;
		if (Tally == 0 && Location >= 15 && Location != 33)
			--clock1;

		if (clock1 == 0) {
			/* start closing the cave */
			Property[GRATE] = 0;
			Property[FISSURE] = 0;
			
			for (i = 1; i < DWARFMAX; ++i)
				 DwarfSeen[i] = 0;

			Move(TROLL, 0);
			Move((TROLL + MAXOBJ), 0);
			Move(TROLL2, 117);
			Move((TROLL2 + MAXOBJ), 122);
			Juggle(CHASM);
			
			if (Property[BEAR] != 3)
				dstroy(BEAR);
			
			Property[CHAIN] = 0;
			FixedLocation[CHAIN] = 0;
			Property[AXE] = 0;
			FixedLocation[AXE] = 0;
			rspeak(129);
			clock1	= -1;
			bClosing = true;

			return false;
		}

		if (clock1 < 0)
			--clock2;

		if (clock2 == 0) {
			/* set up storage room... and close the cave... */
			Property[BOTTLE] = put(BOTTLE, 115, 1);
			Property[PLANT]  = put(PLANT, 115, 0);
			Property[OYSTER] = put(OYSTER, 115, 0);
			Property[LAMP]   = put(LAMP, 115, 0);
			Property[ROD]    = put(ROD, 115, 0);
			Property[DWARF]  = put(DWARF, 115, 0);
			Location = 115;
			OldLocation	     = 115;
			NewLocation = 115;
			put(GRATE, 116, 0);
			Property[SNAKE]  = put(SNAKE, 116, 1);
			Property[BIRD]   = put(BIRD, 116, 1);
			Property[CAGE]   = put(CAGE, 116, 0);
			Property[ROD2]   = put(ROD2, 116, 0);
			Property[PILLOW] = put(PILLOW, 116, 0);
			Property[MIRROR] = put(MIRROR, 115, 0);
			FixedLocation[MIRROR] = 116;
			
			for (i = 1; i <= MAXOBJ; ++i)
				if (toting(i))
					dstroy(i);

			rspeak(132);
			b_closed = true;
			return(true);
		}

		if (Property[LAMP] == 1)
			--limit;

		if (limit <= 30 && IsHere(BATTERIES) && Property[BATTERIES] == 0 && IsHere(LAMP))  {
			rspeak(188);
			Property[BATTERIES] = 1;
			if (toting(BATTERIES))
				drop(BATTERIES, Location);
			limit += 2500;
			lmwarn = 0;
			return false;
		}

		if (limit == 0)  {
			--limit;
			Property[LAMP] = 0;
			if (IsHere(LAMP))
				rspeak(184);

			return false;
		}

		if (limit < 0 && Location <= 8) {
			rspeak(185);
			m_bGaveUp = true;
			normend();
		}

		if (limit <= 30) {
			if (lmwarn > 0 || !IsHere(LAMP))
				return false;

			lmwarn = 1;
			i = 187;
			if (Place[BATTERIES] == 0)
				i = 183;
			if (Property[BATTERIES] == 1)
				i = 189;
			rspeak(i);
		}

		return false;
	}

	}

}
