using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCS
{
    partial class TheAdventure
    {

        private void GetTravelLocation(int nLoc)
        {
            --nLoc;
            if (null == pTravel)
                pTravel = new TravelTable();

            pTravel.SetRow(nLoc);
            sTravCnt = pTravel.TravelCount();
            return;
        }
        private bool ReadInputLine(int msg1, int msg2, int msg3)
        {
            string strAnswer = string.Empty;
            string strChar = string.Empty;

            if( msg1 > 0 )
	            rspeak(msg1);

            Console.Write(">");
            while (string.IsNullOrEmpty(strAnswer = Console.ReadLine()))
                ;
            strAnswer = strAnswer.ToLower();
            strChar = (strAnswer.Length > 0) ? strAnswer.Substring(0, 1) : string.Empty;

            if( "n" == strChar ) {
	            if (msg3 > 0)
	                rspeak(msg3);
	            return false;
            }

            if (msg2 > 0)
	            rspeak(msg2);

            return true;
        }

        private void rspeak(int msg)
        {
            if(true == Debug)
	            Console.WriteLine("** rspeak(%{0}) ** ", msg);

            DisplayText(pTextMsg, msg);

            return;
        }

        private void pspeak(int item, int state)
        {
            string strP;
            string[] strSpeak;

            if( true == Debug )
	            Console.WriteLine("** pspeak(%d,%d) ** ", item, state);

            strP = pObjDesc[item - 1];
            strSpeak = strP.Split('/');

            //int nItem = 0;
            //do {
            //    Console.WriteLine(strSpeak[nItem++]);
            //    --state;
            //} while (state > -1);


            for (int nSpeakItem = state+1; nSpeakItem > state; nSpeakItem--)
                Console.WriteLine(strSpeak[nSpeakItem]);

                return;
        }

        private void desclg(int nLoc)
        {

            if(true == Debug)
                Console.WriteLine("** desclg(%d) ** ", nLoc);

            DisplayText(pLongRmDesc, nLoc);
            Console.WriteLine("\n");

            return;
        }
        private void descsh(int nLoc)
        {

            if (true == Debug)
	            Console.WriteLine("** descsh(%d) ** ", nLoc);

            DisplayText(pShortRmDesc, nLoc);
            Console.WriteLine("\n");

            return;
        }


        void DisplayText( string[] pTbl, int sMsg)
        {

            --sMsg;
            string strMsg = pTbl[sMsg];


            if ('@' == strMsg[0]) {
                
                string[] strMsgItems = strMsg.Remove(0,1).Split(',');
                foreach( string strItem in strMsgItems ) {
                    Console.WriteLine(pTbl[Convert.ToInt32(strItem)-1] );
                }

            }
            else
                Console.WriteLine(pTbl[sMsg]);

            return;
        }



        /*  routine to look up a vocabulary word.
                word is the word to look up.
                val  is the minimum acceptable value,
                        if != 0 return %1000
        */
        int vocab(string strWord, int val)
        {
            try {
                int nValue = vTable[strWord];
                return ((val > 0) ? nValue % 1000 : nValue);
            }
            catch (Exception ) {
                return (-1);
            }
            
        }

        private bool IsDark()
        {
            return ( ((Condition[Location] & LIGHT) == 0) && ( (Property[LAMP] == 0) || !IsHere(LAMP) ));
        }
        private bool IsHere(int item)
        {
            return (Place[item] == Location || toting(item));
        }
        private bool toting(int item)
        {
            return (Place[item] == -1);
        }
        private bool forced(int atloc)
        {
            return (Condition[atloc] == 2);
        }
        private bool pct(int x)
        {
            int nRand = m_rndNumber.Next();

            return ( nRand % 100 < x);
        }
        private bool at(int item) 
        {
            return (Place[item] == Location || FixedLocation[item] == Location); 
        }
        private void dstroy(int obj)
        {
            Move(obj, 0);
            return;
        }
        private void Move(int obj, int where) 
        {
            int @from = (obj < MAXOBJ) ? Place[obj] : FixedLocation[obj];
    
            if (from > 0 && from <= 300)
	            Carry(obj, from);

            drop(obj, where);
            return;
        }

        /*
        Juggle an object
        currently a no-op
        */
        private void Juggle(int nLoc)
        {
            //loc = loc;
            Location = nLoc;
            return;
        }
        private void Carry(int obj, int where = 0)
        {
            if (obj < MAXOBJ) {
                if (Place[obj] == -1)
                    return;

                Place[obj] = -1;
                ++Holding;
            }

            return;
        }
        private void drop(int obj, int where) 
        {    
            
            if (obj < MAXOBJ) {
	            if (Place[obj] == -1)
	            --Holding;

	            Place[obj] = where;
            }
            else
	            FixedLocation[obj - MAXOBJ] = where;

            return; 
        }
        private int put(int obj, int where, int pval)
        {
            int sReturn = -1 - pval;
            Move(obj, where);

            return( sReturn );
        }
        private int dcheck()
        {
            int  i;
            for (i = 1; i < (DWARFMAX - 1); ++i) {
	            if (DwarfLocation[i] == Location)
	                return(i);
            }
            return(0);
        }
        private int liq()
        {
            int i, j;

            i = Property[BOTTLE];
            j = (-1) - i;

            return (liq2(i > j ? i : j));
        }
        private int liqloc(int nLoc)
        {
            if( (Condition[nLoc] & LIQUID) > 0 )
                return (liq2(Condition[nLoc] & WATOIL));

            return (liq2(1));
        }
    
        /*
        Convert  0 to WATER
                 1 to nothing
                 2 to OIL
        */
        int liq2(int pbottle)
        {
            return( (1 - pbottle) * WATER + (pbottle >> 1) * (WATER + OIL));
        }

        private void bug(int n)
        {
            Console.WriteLine("Fatal error number %d\n", n);
            throw new InvalidProgramException();
        }

    }

}
