using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCS
{

    partial class TheAdventure
    {
        private bool bRestoreFlag;
        private bool bBrief;

        public TheAdventure(bool[] flags)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetBufferSize(200, 200);
            Console.SetWindowSize( 80, 25 );
            Console.SetWindowPosition(10, 5);

            bRestoreFlag = flags[0];
            Debug = flags[1];
            bBrief = flags[2];

            init();

            bRestoreFlag = CheckForRestore(bRestoreFlag);

            if(true == bRestoreFlag)
                RestoreGame();
            
            eadvent();

        }

        public void init()
        {
            InitVocabTable();
            DwarfLocation[DWARFMAX - 1] = ChestLocations;
        }

        public void eadvent()
        {
            m_rndNumber = new Random(511);

            if( ReadInputLine(65, 1, 0) )     // ask if user wants instructions
                limit = 1000;
            else
                limit = 330;

            while (false == m_bSaveGame)
                Turn();

            if (true == m_bSaveGame)
                SaveGame();
        }

    }

    partial class Adventure
    {

        private static int Main(string[] args)
        {
            bool[] flags = new bool[3] {false, false, false};

            foreach(string arg in args) {
                if(false == string.IsNullOrEmpty(arg)) {
                    string[] strArg = arg.Split(new char[] {':'}, 2);
                    switch(strArg[0].ToLower().TrimStart(new char[] {'-', '/'})) {
                        case "r":
                            flags[0] = true; // rflag
                            break;
                        case "d":
                            flags[1] = true; // Debug Flag
                            Console.WriteLine("Debug enabled.");
                            break;
                        case "b":
                            flags[2] = true; // brief_sw
                            Console.WriteLine("Brief mode enabled.");
                            break;
                    }
                }
            }


            TheAdventure advent = new TheAdventure(flags);

            return 0;
        }

    }

}