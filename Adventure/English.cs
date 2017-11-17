using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCS
{
    partial class TheAdventure
    {

        bool english()
        {
            string strMsg;
            int	type1, type2, val1, val2;

            Verb = aeobject = Motion = 0;
            type2 = val2 = -1;
            type1 = val1 = -1;
            //msg = "bad grammar...";
            strMsg = "bad grammar...";

            GetInput();
            if( !AnalyzeWord(word1, ref type1, ref val1) )
                return false;

            if (type1 == 2 && val1 == SAY) {
	            Verb = SAY;
	            aeobject = 1;
                return true;
            }

            if( false == string.IsNullOrEmpty(word2) ) {
                if(!AnalyzeWord(word2, ref type2, ref val2))
                    return false;
            }

            /* check his grammar */
            if (type1 == 3) {
	            rspeak(val1);
                return false;
            }
            else {
	            if (type2 == 3) {
	                rspeak(val2);
	                return false;
	            }
	            else {
	                if (type1 == 0) {
	                    if(type2 == 0) {
	                        Console.WriteLine("{0}", strMsg);
	                        return false;
	                    }
	                    else
                            Motion = val1;
	                }
	                else {
		                if (type2 == 0)
                            Motion = val2;
		                else {
		                    if(type1 == 1) {
		                        aeobject = val1;
		                        if(type2 == 2)
		                            Verb = val2;
		                        if(type2 == 1) {
		                            Console.WriteLine("{0}\n", strMsg);
		                            return false;
		                        }
		                    }
		                    else {
			                    if (type1 == 2) {
			                        Verb = val1;
			                        if (type2 == 1)
				                        aeobject = val2;
			                        if (type2 == 2) {
				                        Console.WriteLine("{0}\n", strMsg);
			                            return false;
			                        }
			                }
			                else
			                    bug(36);
		                    }
		                }
	                }
	            }
            }
            return true;
        }

        /*
                        Routine to AnalyzeWord a word.
        */
        bool AnalyzeWord( string strWord, ref int nType, ref int nValue ) 
        {
            int	 wordval;
            int  msg;

            /* make sure I understand */
            if ((wordval = vocab(strWord, 0)) == -1) {
                switch (m_rndNumber.Next() % 3) {
	                case 0:
		                msg = 60;
		                break;
	                case 1:
		                msg = 61;
		                break;
	                default:
		                msg = 13;
                        break;
	            }

	            rspeak(msg);

	            return false;
            }

            nType  = wordval / 1000;
            nValue = wordval % 1000;

            return true;
        }

        /*
                routine to get two words of input
                and convert them to lower case
        */
        void GetInput()
        {

            word1 = string.Empty;
            word2 = string.Empty;

            Console.Write("> ");
            string strInput = Console.ReadLine();
            string[] words = strInput.Split(' ');
            
            // either no input or more words than we can handle
            if( words.Length < 1 || words.Length > 2)
                return;

            if(words.Length >= 1)
                word1 = words[0];
            
            if(words.Length == 2)
                word2 = words[1];

            return;
        }

    }

}
