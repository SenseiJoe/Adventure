using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCS
{
    partial class TheAdventure
    {

        private void SaveGame()
        {
            string  strUserName;

            Console.Write("\nWhat do you want to call the saved game? ");
            strUserName = Console.ReadLine();
            strUserName = strUserName.ToUpper();

            if (strUserName.Length == 0)
                strUserName = "SAVE";

            strUserName += ".ADV";
            Console.WriteLine($"Saving Adventure File \"{strUserName}\"");

            Serializer s = new Serializer();
            s.SerializeObject(strUserName, aData);

            Console.WriteLine("Game saved.\n");
            return;
        }

        public void RestoreGame()
        {
            Console.Write("What is your saved game name? ");

            string strInput = Console.ReadLine();
            string strFilename = Path.ChangeExtension(strInput, "ADV");

            if (true == string.IsNullOrEmpty(strFilename) || false == File.Exists(strFilename)) {
                Console.WriteLine( $"Could Not Find File '{strFilename}'");
            }
            else {
                aData.Clear();
                Serializer s = new Serializer();
                aData = s.DeSerializeObject(strFilename);
            }

        }

        public bool CheckForRestore(bool bFlag)
        {
            bool bRflag = true;

            Console.Clear();
            if (false == bFlag) {
                ConsoleKeyInfo cki;

                Console.Write("\nDo you want to restore a saved game? (Y/N) ");
                cki = Console.ReadKey();

                bRflag = false;
                if ("Y" == cki.KeyChar.ToString().ToUpper())
                    bRflag = true;

                Console.WriteLine("\n");
            }

            return bRflag;
        }

    }

}
