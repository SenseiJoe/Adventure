using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventureCS
{

    public class TravelTable {

        private SortedList<int, int[,]> tTable = new SortedList<int, int[,]>();
        public int[,] mTravelTable;

        public int Destination
        {
            get; set;
        }
        public int Verb
        {
            get; set;
        }
        public int Condition
        {
            get; set;
        }


        public TravelTable()
        {
            InitTravelTable();
            mTravelTable = tTable[1];

            Destination = mTravelTable[0, 0];
            Verb = mTravelTable[0, 1];
            Condition = mTravelTable[0, 2];
        }
        public TravelTable(int[,] Trav)
        {
            mTravelTable = Trav;

            Destination = Trav[0, 0];
            Verb = Trav[0, 1];
            Condition = Trav[0, 2];
        }

        public TravelTable(TravelTable prevTRAV)
        {
            mTravelTable = prevTRAV.mTravelTable;

            Destination = prevTRAV.Destination;
            Verb = prevTRAV.Verb;
            Condition = prevTRAV.Condition;
        }

        public void Clear()
        {
            Destination = 0;
            Verb = 0;
            Condition = 0;
        }

        public void SetRow(int nRow)
        {
            mTravelTable = tTable[nRow];
            Destination = GetDestination(0);
            Verb = GetVerb(0);
            Condition = GetCondition(0);
        }
        public string[] GetRow(int nRow = 0)
        {
            string[] strRow = new string[3] {
                mTravelTable[nRow, 0].ToString(),
                mTravelTable[nRow, 1].ToString(),
                mTravelTable[nRow, 2].ToString()
            };
            return strRow;
        }
        public int GetDestination(int nRow)
        {
            return Convert.ToInt32(mTravelTable[nRow, 0]);
        }
        public int GetVerb(int nRow)
        {
            return Convert.ToInt32(mTravelTable[nRow, 1]);
        }
        public int GetCondition(int nRow)
        {
            return Convert.ToInt32(mTravelTable[nRow, 2]);
        }
        public int TravelCount()
        {
            return mTravelTable.GetLength(0);
        }

        void InitTravelTable()
        {

            tTable.Add(000, Trav001);
            tTable.Add(001, Trav002);
            tTable.Add(002, Trav003);
            tTable.Add(003, Trav004);
            tTable.Add(004, Trav005);
            tTable.Add(005, Trav006);
            tTable.Add(006, Trav007);
            tTable.Add(007, Trav008);
            tTable.Add(008, Trav009);
            tTable.Add(009, Trav010);
            tTable.Add(010, Trav011);
            tTable.Add(011, Trav012);
            tTable.Add(012, Trav013);
            tTable.Add(013, Trav014);
            tTable.Add(014, Trav015);
            tTable.Add(015, Trav016);
            tTable.Add(016, Trav017);
            tTable.Add(017, Trav018);
            tTable.Add(018, Trav019);
            tTable.Add(019, Trav020);
            tTable.Add(020, Trav021);
            tTable.Add(021, Trav022);
            tTable.Add(022, Trav023);
            tTable.Add(023, Trav024);
            tTable.Add(024, Trav025);
            tTable.Add(025, Trav026);
            tTable.Add(026, Trav027);
            tTable.Add(027, Trav028);
            tTable.Add(028, Trav029);
            tTable.Add(029, Trav030);
            tTable.Add(030, Trav031);
            tTable.Add(031, Trav032);
            tTable.Add(032, Trav033);
            tTable.Add(033, Trav034);
            tTable.Add(034, Trav035);
            tTable.Add(035, Trav036);
            tTable.Add(036, Trav037);
            tTable.Add(037, Trav038);
            tTable.Add(038, Trav039);
            tTable.Add(039, Trav040);
            tTable.Add(040, Trav041);
            tTable.Add(041, Trav042);
            tTable.Add(042, Trav043);
            tTable.Add(043, Trav044);
            tTable.Add(044, Trav045);
            tTable.Add(045, Trav046);
            tTable.Add(046, Trav047);
            tTable.Add(047, Trav048);
            tTable.Add(048, Trav049);
            tTable.Add(049, Trav050);
            tTable.Add(050, Trav051);
            tTable.Add(051, Trav052);
            tTable.Add(052, Trav053);
            tTable.Add(053, Trav054);
            tTable.Add(054, Trav055);
            tTable.Add(055, Trav056);
            tTable.Add(056, Trav057);
            tTable.Add(057, Trav058);
            tTable.Add(058, Trav059);
            tTable.Add(059, Trav060);
            tTable.Add(060, Trav061);
            tTable.Add(061, Trav062);
            tTable.Add(062, Trav063);
            tTable.Add(063, Trav064);
            tTable.Add(064, Trav065);
            tTable.Add(065, Trav066);
            tTable.Add(066, Trav067);
            tTable.Add(067, Trav068);
            tTable.Add(068, Trav069);
            tTable.Add(069, Trav070);
            tTable.Add(070, Trav071);
            tTable.Add(071, Trav072);
            tTable.Add(072, Trav073);
            tTable.Add(073, Trav074);
            tTable.Add(074, Trav075);
            tTable.Add(075, Trav076);
            tTable.Add(076, Trav077);
            tTable.Add(077, Trav078);
            tTable.Add(078, Trav079);
            tTable.Add(079, Trav080);
            tTable.Add(080, Trav081);
            tTable.Add(081, Trav082);
            tTable.Add(082, Trav083);
            tTable.Add(083, Trav084);
            tTable.Add(084, Trav085);
            tTable.Add(085, Trav086);
            tTable.Add(086, Trav087);
            tTable.Add(087, Trav088);
            tTable.Add(088, Trav089);
            tTable.Add(089, Trav090);
            tTable.Add(090, Trav091);
            tTable.Add(091, Trav092);
            tTable.Add(092, Trav093);
            tTable.Add(093, Trav094);
            tTable.Add(094, Trav095);
            tTable.Add(095, Trav096);
            tTable.Add(096, Trav097);
            tTable.Add(097, Trav098);
            tTable.Add(098, Trav099);
            tTable.Add(099, Trav100);
            tTable.Add(100, Trav101);
            tTable.Add(101, Trav102);
            tTable.Add(102, Trav103);
            tTable.Add(103, Trav104);
            tTable.Add(104, Trav105);
            tTable.Add(105, Trav106);
            tTable.Add(106, Trav107);
            tTable.Add(107, Trav108);
            tTable.Add(108, Trav109);
            tTable.Add(109, Trav110);
            tTable.Add(110, Trav111);
            tTable.Add(111, Trav112);
            tTable.Add(112, Trav113);
            tTable.Add(113, Trav114);
            tTable.Add(114, Trav115);
            tTable.Add(115, Trav116);
            tTable.Add(116, Trav117);
            tTable.Add(117, Trav118);
            tTable.Add(118, Trav119);
            tTable.Add(119, Trav120);
            tTable.Add(120, Trav121);
            tTable.Add(121, Trav122);
            tTable.Add(122, Trav123);
            tTable.Add(123, Trav124);
            tTable.Add(124, Trav125);
            tTable.Add(125, Trav126);
            tTable.Add(126, Trav127);
            tTable.Add(127, Trav128);
            tTable.Add(128, Trav129);
            tTable.Add(129, Trav130);
            tTable.Add(130, Trav131);
            tTable.Add(131, Trav132);
            tTable.Add(132, Trav133);
            tTable.Add(133, Trav134);
            tTable.Add(134, Trav135);
            tTable.Add(135, Trav136);
            tTable.Add(136, Trav137);
            tTable.Add(137, Trav138);
            tTable.Add(138, Trav139);
            tTable.Add(139, Trav140);

        }

        #region Travel Tables
        int[,] Trav001 = new int[16, 3] 
        {
            {	2,   2,   0 },
            {	2,  44,   0 },
            {	2,  29,   0 },
            {	3,   3,   0 },
            {	3,  12,   0 },
            {	3,  19,   0 },
            {	3,  43,   0 },
            {	4,   5,   0 },
            {	4,  13,   0 },
            {	4,  14,   0 },
            {	4,  46,   0 },
            {	4,  30,   0 },
            {	5,   6,   0 },
            {	5,  45,   0 },
            {	5,  43,   0 },
            {	8,  63,   0 },
        };

        int[,] Trav002 = new int[9, 3] 
        {
            {	1,   2,   0 },
            {	1,  12,   0 },
            {	1,   7,   0 },
            {	1,  43,   0 },
            {	1,  45,   0 },
            {	1,  30,   0 },
            {	5,   6,   0 },
            {	5,  45,   0 },
            {	5,  46,   0 },
        };

        int[,] Trav003 = new int[8, 3] 
        {
            {	1,   3,   0 },
            {	1,  11,   0 },
            {	1,  32,   0 },
            {	1,  44,   0 },
            {  11,  62,   0 },
            {  33,  65,   0 },
            {  79,   5,   0 },
            {  79,  14,   0 },
        };

        int[,] Trav004 = new int[11, 3] 
        {
            {	1,   4,   0 },
            {	1,  12,   0 },
            {	1,  45,   0 },
            {	5,   6,   0 },
            {	5,  43,   0 },
            {	5,  44,   0 },
            {	5,  29,   0 },
            {	7,   5,   0 },
            {	7,  46,   0 },
            {	7,  30,   0 },
            {	8,  63,   0 },
        };

        int[,] Trav005 = new int[9, 3]
        {
            {	4,   9,   0 },
            {	4,  43,   0 },
            {	4,  30,   0 },
            {	5,   6,  50 },
            {	5,   7,  50 },
            {	5,  45,  50 },
            {	6,   6,   0 },
            {	5,  44,   0 },
            {	5,  46,   0 },
        };

        int[,] Trav006 = new int[8, 3]
        {
            {	1,   2,   0 },
            {	1,  45,   0 },
            {	4,   9,   0 },
            {	4,  43,   0 },
            {	4,  44,   0 },
            {	4,  30,   0 },
            {	5,   6,   0 },
            {	5,  46,   0 },
        };

        int[,] Trav007 = new int[13, 3]
        {
            {	1,  12,   0 },
            {	4,   4,   0 },
            {	4,  45,   0 },
            {	5,   6,   0 },
            {	5,  43,   0 },
            {	5,  44,   0 },
            {	8,   5,   0 },
            {	8,  15,   0 },
            {	8,  16,   0 },
            {	8,  46,   0 },
            { 595,  60,   0 },
            { 595,  14,   0 },
            { 595,  30,   0 },
        };

        int[,] Trav008 = new int[12, 3]
        {
            {	5,   6,   0 },
            {	5,  43,   0 },
            {	5,  46,   0 },
            {	5,  44,   0 },
            {	1,  12,   0 },
            {	7,   4,   0 },
            {	7,  13,   0 },
            {	7,  45,   0 },
            {	9,   3, 303 },
            {	9,  19, 303 },
            {	9,  30, 303 },
            { 593,   3,   0 },
        };

        int[,] Trav009 = new int[9, 3]
        {
            {	8,  11, 303 },
            {	8,  29, 303 },
            { 593,  11,   0 },
            {  10,  17,   0 },
            {  10,  18,   0 },
            {  10,  19,   0 },
            {  10,  44,   0 },
            {  14,  31,   0 },
            {  11,  51,   0 },
        };

        int[,] Trav010 = new int[9, 3]
        {
            {	9,  11,   0 },
            {	9,  20,   0 },
            {	9,  21,   0 },
            {	9,  43,   0 },
            {  11,  19,   0 },
            {  11,  22,   0 },
            {  11,  44,   0 },
            {  11,  51,   0 },
            {  14,  31,   0 },
        };

        int[,] Trav011 = new int[13, 3]
        {
            {	8,  63, 303 },
            {	9,  64,   0 },
            {  10,  17,   0 },
            {  10,  18,   0 },
            {  10,  23,   0 },
            {  10,  24,   0 },
            {  10,  43,   0 },
            {  12,  25,   0 },
            {  12,  19,   0 },
            {  12,  29,   0 },
            {  12,  44,   0 },
            {	3,  62,   0 },
            {  14,  31,   0 },
        };

        int[,] Trav012 = new int[9, 3]
        {
            {	8,  63, 303 },
            {	9,  64,   0 },
            {  11,  30,   0 },
            {  11,  43,   0 },
            {  11,  51,   0 },
            {  13,  19,   0 },
            {  13,  29,   0 },
            {  13,  44,   0 },
            {  14,  31,   0 },
        };

        int[,] Trav013 = new int[8, 3]
        {
            {	8,  63, 303 },
            {	9,  64,   0 },
            {  11,  51,   0 },
            {  12,  25,   0 },
            {  12,  43,   0 },
            {  14,  23,   0 },
            {  14,  31,   0 },
            {  14,  44,   0 },
        };

        int[,] Trav014 = new int[11, 3]
        {
            {	8,  63, 303 },
            {	9,  64,   0 },
            {  11,  51,   0 },
            {  13,  23,   0 },
            {  13,  43,   0 },
            {  20,  30, 150 },
            {  20,  31, 150 },
            {  20,  34, 150 },
            {  15,  30,   0 },
            {  16,  33,   0 },
            {  16,  44,   0 },
        };

        int[,] Trav015 = new int[16, 3]
        {
            {  18,  36,   0 },
            {  18,  46,   0 },
            {  17,   7,   0 },
            {  17,  38,   0 },
            {  17,  44,   0 },
            {  19,  10,   0 },
            {  19,  30,   0 },
            {  19,  45,   0 },
            {  22,  29, 150 },
            {  22,  31, 150 },
            {  22,  34, 150 },
            {  22,  35, 150 },
            {  22,  23, 150 },
            {  22,  43, 150 },
            {  14,  29,   0 },
            {  34,  55,   0 },
        };

        int[,] Trav016 = new int[1, 3]
        {
            {  14,   1,   0 },
        };

        int[,] Trav017 = new int[9, 3]
        {
            {  15,  38,   0 },
            {  15,  43,   0 },
            { 596,  39, 312 },
            {  21,   7, 412 },
            { 597,  41, 412 },
            { 597,  42, 412 },
            { 597,  44, 412 },
            { 597,  69, 412 },
            {  27,  41,   0 },
        };

        int[,] Trav018 = new int[3, 3]
        {
            {  15,  38,   0 },
            {  15,  11,   0 },
            {  15,  45,   0 },
        };

        int[,] Trav019 = new int[13, 3]
        {
            {  15,  10,   0 },
            {  15,  29,   0 },
            {  15,  43,   0 },
            {  28,  45, 311 },
            {  28,  36, 311 },
            {  29,  46, 311 },
            {  29,  37, 311 },
            {  30,  44, 311 },
            {  30,   7, 311 },
            {  32,  45,   0 },
            {  74,  49,  35 },
            {  32,  49, 211 },
            {  74,  66,   0 },
        };

        int[,] Trav020 = new int[1, 3]
        {
            {	0,   1,   0 },
        };

        int[,] Trav021 = new int[1, 3]
        {
            {	0,   1,   0 },
        };

        int[,] Trav022 = new int[1, 3]
        {
            {  15,   1,   0 },
        };

        int[,] Trav023 = new int[7, 3]
        {
            {  67,  43,   0 },
            {  67,  42,   0 },
            {  68,  44,   0 },
            {  68,  61,   0 },
            {  25,  30,   0 },
            {  25,  31,   0 },
            { 648,  52,   0 },
        };

        int[,] Trav024 = new int[2, 3]
        {
            {  67,  29,   0 },
            {  67,  11,   0 },
        };

        int[,] Trav025 = new int[4, 3]
        {
            {  23,  29,   0 },
            {  23,  11,   0 },
            {  31,  56, 724 },
            {  26,  56,   0 },
        };

        int[,] Trav026 = new int[1, 3]
        {
            {  88,   1,   0 },
        };

        int[,] Trav027 = new int[9, 3]
        {
            { 596,  39, 312 },
            {  21,   7, 412 },
            { 597,  41, 412 },
            { 597,  42, 412 },
            { 597,  43, 412 },
            { 597,  69, 412 },
            {  17,  41,   0 },
            {  40,  45,   0 },
            {  41,  44,   0 },
        };

        int[,] Trav028 = new int[7, 3]
        {
            {  19,  38,   0 },
            {  19,  11,   0 },
            {  19,  46,   0 },
            {  33,  45,   0 },
            {  33,  55,   0 },
            {  36,  30,   0 },
            {  36,  52,   0 },
        };

        int[,] Trav029 = new int[3, 3]
        {
            {  19,  38,   0 },
            {  19,  11,   0 },
            {  19,  45,   0 },
        };

        int[,] Trav030 = new int[5, 3]
        {
            {  19,  38,   0 },
            {  19,  11,   0 },
            {  19,  43,   0 },
            {  62,  44,   0 },
            {  62,  29,   0 },
        };

        int[,] Trav031 = new int[2, 3]
        {
            {  89,   1, 524 },
            {  90,   1,   0 },
        };

        int[,] Trav032 = new int[1, 3]
        {
            {  19,   1,   0 },
        };

        int[,] Trav033 = new int[8, 3]
        {
            {	3,  65,   0 },
            {  28,  46,   0 },
            {  34,  43,   0 },
            {  34,  53,   0 },
            {  34,  54,   0 },
            {  35,  44,   0 },
            { 302,  71, 159 },
            { 100,  71,   0 },
        };

        int[,] Trav034 = new int[3, 3]
        {
            {  33,  30,   0 },
            {  33,  55,   0 },
            {  15,  29,   0 },
        };

        int[,] Trav035 = new int[3, 3]
        {
            {  33,  43,   0 },
            {  33,  55,   0 },
            {  20,  39,   0 },
        };

        int[,] Trav036 = new int[6, 3]
        {
            {  37,  43,   0 },
            {  37,  17,   0 },
            {  28,  29,   0 },
            {  28,  52,   0 },
            {  39,  44,   0 },
            {  65,  70,   0 },
        };

        int[,] Trav037 = new int[5, 3]
        {
            {  36,  44,   0 },
            {  36,  17,   0 },
            {  38,  30,   0 },
            {  38,  31,   0 },
            {  38,  56,   0 },
        };

        int[,] Trav038 = new int[8, 3]
        {
            {  37,  56,   0 },
            {  37,  29,   0 },
            {  37,  11,   0 },
            { 595,  60,   0 },
            { 595,  14,   0 },
            { 595,  30,   0 },
            { 595,   4,   0 },
            { 595,   5,   0 },
        };

        int[,] Trav039 = new int[6, 3]
        {
            {  36,  43,   0 },
            {  36,  23,   0 },
            {  64,  30,   0 },
            {  64,  52,   0 },
            {  64,  58,   0 },
            {  65,  70,   0 },
        };

        int[,] Trav040 = new int[1, 3]
        {
            {  41,   1,   0 },
        };

        int[,] Trav041 = new int[8, 3]
        {
            {  42,  46,   0 },
            {  42,  29,   0 },
            {  42,  23,   0 },
            {  42,  56,   0 },
            {  27,  43,   0 },
            {  59,  45,   0 },
            {  60,  44,   0 },
            {  60,  17,   0 },
        };

        int[,] Trav042 = new int[5, 3]
        {
            {  41,  29,   0 },
            {  42,  45,   0 },
            {  43,  43,   0 },
            {  45,  46,   0 },
            {  80,  44,   0 },
        };

        int[,] Trav043 = new int[3, 3]
        {
            {  42,  44,   0 },
            {  44,  46,   0 },
            {  45,  43,   0 },
        };

        int[,] Trav044 = new int[4, 3]
        {
            {  43,  43,   0 },
            {  48,  30,   0 },
            {  50,  46,   0 },
            {  82,  45,   0 },
        };

        int[,] Trav045 = new int[6, 3]
        {
            {  42,  44,   0 },
            {  43,  45,   0 },
            {  46,  43,   0 },
            {  47,  46,   0 },
            {  87,  29,   0 },
            {  87,  30,   0 },
        };

        int[,] Trav046 = new int[2, 3]
        {
            {  45,  44,   0 },
            {  45,  11,   0 },
        };

        int[,] Trav047 = new int[2, 3]
        {
            {  45,  43,   0 },
            {  45,  11,   0 },
        };

        int[,] Trav048 = new int[2, 3]
        {
            {  44,  29,   0 },
            {  44,  11,   0 },
        };

        int[,] Trav049 = new int[2, 3]
        {
            {  50,  43,   0 },
            {  51,  44,   0 },
        };

        int[,] Trav050 = new int[4, 3]
        {
            {  44,  43,   0 },
            {  49,  44,   0 },
            {  51,  30,   0 },
            {  52,  46,   0 },
        };

        int[,] Trav051 = new int[4, 3]
        {
            {  49,  44,   0 },
            {  50,  29,   0 },
            {  52,  43,   0 },
            {  53,  46,   0 },
        };

        int[,] Trav052 = new int[6, 3]
        {
            {  50,  44,   0 },
            {  51,  43,   0 },
            {  52,  46,   0 },
            {  53,  29,   0 },
            {  55,  45,   0 },
            {  86,  30,   0 },
        };

        int[,] Trav053 = new int[3, 3]
        {
            {  51,  44,   0 },
            {  52,  45,   0 },
            {  54,  46,   0 },
        };

        int[,] Trav054 = new int[2, 3]
        {
            {  53,  44,   0 },
            {  53,  11,   0 },
        };

        int[,] Trav055 = new int[4, 3]
        {
            {  52,  44,   0 },
            {  55,  45,   0 },
            {  56,  30,   0 },
            {  57,  43,   0 },
        };

        int[,] Trav056 = new int[2, 3]
        {
            {  55,  29,   0 },
            {  55,  11,   0 },
        };

        int[,] Trav057 = new int[6, 3]
        {
            {  13,  30,   0 },
            {  13,  56,   0 },
            {  55,  44,   0 },
            {  58,  46,   0 },
            {  83,  45,   0 },
            {  84,  43,   0 },
        };

        int[,] Trav058 = new int[2, 3]
        {
            {  57,  43,   0 },
            {  57,  11,   0 },
        };

        int[,] Trav059 = new int[1, 3]
        {
            {  27,   1,   0 },
        };

        int[,] Trav060 = new int[7, 3]
        {
            {  41,  43,   0 },
            {  41,  29,   0 },
            {  41,  17,   0 },
            {  61,  44,   0 },
            {  62,  45,   0 },
            {  62,  30,   0 },
            {  62,  52,   0 },
        };

        int[,] Trav061 = new int[3, 3]
        {
            {  60,  43,   0 },
            {  62,  45,   0 },
            { 107,  46, 100 },
        };

        int[,] Trav062 = new int[4, 3]
        {
            {  60,  44,   0 },
            {  63,  45,   0 },
            {  30,  43,   0 },
            {  61,  46,   0 },
        };

        int[,] Trav063 = new int[2, 3]
        {
            {  62,  46,   0 },
            {  62,  11,   0 },
        };

        int[,] Trav064 = new int[8, 3]
        {
            {  39,  29,   0 },
            {  39,  56,   0 },
            {  39,  59,   0 },
            {  65,  44,   0 },
            {  65,  70,   0 },
            { 103,  45,   0 },
            { 103,  74,   0 },
            { 106,  43,   0 },
        };

        int[,] Trav065 = new int[12, 3]
        {
            {  64,  43,   0 },
            {  66,  44,   0 },
            { 556,  46,  80 },
            {  68,  61,   0 },
            { 556,  29,  80 },
            {  70,  29,  50 },
            {  39,  29,   0 },
            { 556,  45,  60 },
            {  72,  45,  75 },
            {  71,  45,   0 },
            { 556,  30,  80 },
            { 106,  30,   0 },
        };

        int[,] Trav066 = new int[7, 3]
        {
            {  65,  47,   0 },
            {  67,  44,   0 },
            { 556,  46,  80 },
            {  77,  25,   0 },
            {  96,  43,   0 },
            { 556,  50,  50 },
            {  97,  72,   0 },
        };

        int[,] Trav067 = new int[5, 3]
        {
            {  66,  43,   0 },
            {  23,  44,   0 },
            {  23,  42,   0 },
            {  24,  30,   0 },
            {  24,  31,   0 },
        };

        int[,] Trav068 = new int[4, 3]
        {
            {  23,  46,   0 },
            {  69,  29,   0 },
            {  69,  56,   0 },
            {  65,  45,   0 },
        };

        int[,] Trav069 = new int[6, 3]
        {
            {  68,  30,   0 },
            {  68,  61,   0 },
            { 120,  46, 331 },
            { 119,  46,   0 },
            { 109,  45,   0 },
            { 113,  75,   0 },
        };

        int[,] Trav070 = new int[4, 3]
        {
            {  71,  45,   0 },
            {  65,  30,   0 },
            {  65,  23,   0 },
            { 111,  46,   0 },
        };

        int[,] Trav071 = new int[3, 3]
        {
            {  65,  48,   0 },
            {  70,  46,   0 },
            { 110,  45,   0 },
        };

        int[,] Trav072 = new int[5, 3]
        {
            {  65,  70,   0 },
            { 118,  49,   0 },
            {  73,  45,   0 },
            {  97,  48,   0 },
            {  97,  72,   0 },
        };

        int[,] Trav073 = new int[3, 3]
        {
            {  72,  46,   0 },
            {  72,  17,   0 },
            {  72,  11,   0 },
        };

        int[,] Trav074 = new int[4, 3]
        {
            {  19,  43,   0 },
            { 120,  44, 331 },
            { 121,  44,   0 },
            {  75,  30,   0 },
        };

        int[,] Trav075 = new int[2, 3]
        {
            {  76,  46,   0 },
            {  77,  45,   0 },
        };

        int[,] Trav076 = new int[1, 3]
        {
            {  75,  45,   0 },
        };

        int[,] Trav077 = new int[4, 3]
        {
            {  75,  43,   0 },
            {  78,  44,   0 },
            {  66,  45,   0 },
            {  66,  17,   0 },
        };

        int[,] Trav078 = new int[1, 3]
        {
            {  77,  46,   0 },
        };

        int[,] Trav079 = new int[1, 3]
        {
            {	3,   1,   0 },
        };

        int[,] Trav080 = new int[4, 3]
        {
            {  42,  45,   0 },
            {  80,  44,   0 },
            {  80,  46,   0 },
            {  81,  43,   0 },
        };

        int[,] Trav081 = new int[2, 3]
        {
            {  80,  44,   0 },
            {  80,  11,   0 },
        };

        int[,] Trav082 = new int[2, 3]
        {
            {  44,  46,   0 },
            {  44,  11,   0 },
        };

        int[,] Trav083 = new int[3, 3]
        {
            {  57,  46,   0 },
            {  84,  43,   0 },
            {  85,  44,   0 },
        };

        int[,] Trav084 = new int[3, 3]
        {
            {  57,  45,   0 },
            {  83,  44,   0 },
            { 114,  50,   0 },
        };

        int[,] Trav085 = new int[2, 3]
        {
            {  83,  43,   0 },
            {  83,  11,   0 },
        };

        int[,] Trav086 = new int[2, 3]
        {
            {  52,  29,   0 },
            {  52,  11,   0 },
        };

        int[,] Trav087 = new int[2, 3]
        {
            {  45,  29,   0 },
            {  45,  30,   0 },
        };

        int[,] Trav088 = new int[6, 3]
        {
            {  25,  30,   0 },
            {  25,  56,   0 },
            {  25,  43,   0 },
            {  20,  39,   0 },
            {  92,  44,   0 },
            {  92,  27,   0 },
        };

        int[,] Trav089 = new int[1, 3]
        {
            {  25,  1,	 0 },
        };

        int[,] Trav090 = new int[1, 3]
        {
            {  23,   1,   0 },
        };

        int[,] Trav091 = new int[5, 3]
        {
            {  95,  45,   0 },
            {  95,  73,   0 },
            {  95,  23,   0 },
            {  72,  30,   0 },
            {  72,  56,   0 },
        };

        int[,] Trav092 = new int[3, 3]
        {
            {  88,  46,   0 },
            {  93,  43,   0 },
            {  94,  45,   0 },
        };

        int[,] Trav093 = new int[3, 3]
        {
            {  92,  46,   0 },
            {  92,  27,   0 },
            {  92,  11,   0 },
        };

        int[,] Trav094 = new int[7, 3]
        {
            {  92,  46,   0 },
            {  92,  27,   0 },
            {  92,  23,   0 },
            {  95,  45, 309 },
            {  95,   3, 309 },
            {  95,  73, 309 },
            { 611,  45,   0 },
        };

        int[,] Trav095 = new int[4, 3]
        {
            {  94,  46,   0 },
            {  94,  11,   0 },
            {  92,  27,   0 },
            {  91,  44,   0 },
        };

        int[,] Trav096 = new int[2, 3]
        {
            {  66,  44,   0 },
            {  66,  11,   0 },
        };

        int[,] Trav097 = new int[6, 3]
        {
            {  66,  48,   0 },
            {  72,  44,   0 },
            {  72,  17,   0 },
            {  98,  29,   0 },
            {  98,  45,   0 },
            {  98,  73,   0 },
        };

        int[,] Trav098 = new int[3, 3]
        {
            {  97,  46,   0 },
            {  97,  72,   0 },
            {  99,  44,   0 },
        };

        int[,] Trav099 = new int[5, 3]
        {
            {  98,  50,   0 },
            {  98,  73,   0 },
            {  301, 43,   0 },
            {  301, 23,   0 },
            {  100, 43,   0 },
        };

        int[,] Trav100 = new int[8, 3]
        {
            { 301,  44,   0 },
            { 301,  23,   0 },
            { 301,  11,   0 },
            {  99,  44,   0 },
            { 302,  71, 159 },
            {  33,  71,   0 },
            { 101,  47,   0 },
            { 101,  22,   0 },
        };

        int[,] Trav101 = new int[3, 3]
        {
            { 100,  46,   0 },
            { 100,  71,   0 },
            { 100,  11,   0 },
        };

        int[,] Trav102 = new int[3, 3]
        {
            { 103,  30,   0 },
            { 103,  74,   0 },
            { 103,  11,   0 },
        };

        int[,] Trav103 = new int[6, 3]
        {
            { 102,  29,   0 },
            { 102,  38,   0 },
            { 104,  30,   0 },
            { 618,  46, 114 },
            { 619,  46, 115 },
            {  64,  46,   0 },
        };

        int[,] Trav104 = new int[3, 3]
        {
            { 103,  29,   0 },
            { 103,  74,   0 },
            { 105,  30,   0 },
        };

        int[,] Trav105 = new int[3, 3]
        {
            { 104,  29,   0 },
            { 104,  11,   0 },
            { 103,  74,   0 },
        };

        int[,] Trav106 = new int[3, 3]
        {
            {  64,  29,   0 },
            {  65,  44,   0 },
            { 108,  43,   0 },
        };

        int[,] Trav107 = new int[10, 3]
        {
            { 131,  46,   0 },
            { 132,  49,   0 },
            { 133,  47,   0 },
            { 134,  48,   0 },
            { 135,  29,   0 },
            { 136,  50,   0 },
            { 137,  43,   0 },
            { 138,  44,   0 },
            { 139,  45,   0 },
            {  61,  30,   0 },
        };

        int[,] Trav108 = new int[11, 3]
        {
            { 556,  43,  95 },
            { 556,  45,  95 },
            { 556,  46,  95 },
            { 556,  47,  95 },
            { 556,  48,  95 },
            { 556,  49,  95 },
            { 556,  50,  95 },
            { 556,  29,  95 },
            { 556,  30,  95 },
            { 106,  43,   0 },
            { 626,  44,   0 },
        };

        int[,] Trav109 = new int[3, 3]
        {
            {  69,  46,   0 },
            { 113,  45,   0 },
            { 113,  75,   0 },
        };

        int[,] Trav110 = new int[2, 3]
        {
            {  71,  44,   0 },
            {  20,  39,   0 },
        };

        int[,] Trav111 = new int[6, 3]
        {
            {  70,  45,   0 },
            {  50,  30,  40 },
            {  50,  39,  40 },
            {  50,  56,  40 },
            {  53,  30,  50 },
            {  45,  30,   0 },
        };

        int[,] Trav112 = new int[10, 3]
        {
            { 131,  49,   0 },
            { 132,  45,   0 },
            { 133,  43,   0 },
            { 134,  50,   0 },
            { 135,  48,   0 },
            { 136,  47,   0 },
            { 137,  44,   0 },
            { 138,  30,   0 },
            { 139,  29,   0 },
            { 140,  46,   0 },
        };

        int[,] Trav113 = new int[3, 3]
        {
            { 109,  46,   0 },
            { 109,  11,   0 },
            { 109, 109,   0 },
        };

        int[,] Trav114 = new int[1, 3]
        {
            {  84,  48,   0 },
        };

        int[,] Trav115 = new int[1, 3]
        {
            { 116,  49,   0 },
        };

        int[,] Trav116 = new int[2, 3]
        {
            { 115,  47,   0 },
            { 593,  30,   0 },
        };

        int[,] Trav117 = new int[9, 3]
        {
            { 118,  49,   0 },
            { 660,  41, 233 },
            { 660,  42, 233 },
            { 660,  69, 233 },
            { 660,  47, 233 },
            { 661,  41, 332 },
            { 303,  41,   0 },
            {  21,  39, 332 },
            { 596,  39,   0 },
        };

        int[,] Trav118 = new int[2, 3]
        {
            {  72,  30,   0 },
            { 117,  29,   0 },
        };

        int[,] Trav119 = new int[4, 3]
        {
            {  69,  45,   0 },
            {  69,  11,   0 },
            { 653,  43,   0 },
            { 653,   7,   0 },
        };

        int[,] Trav120 = new int[2, 3]
        {
            {  69,  45,   0 },
            {  74,  43,   0 },
        };

        int[,] Trav121 = new int[4, 3]
        {
            {  74,  43,   0 },
            {  74,  11,   0 },
            { 653,  45,   0 },
            { 653,   7,   0 },
        };

        int[,] Trav122 = new int[10, 3]
        {
            { 123,  47,   0 },
            { 660,  41, 233 },
            { 660,  42, 233 },
            { 660,  69, 233 },
            { 660,  49, 233 },
            { 303,  41,   0 },
            { 596,  39,   0 },
            { 124,  77,   0 },
            { 126,  28,   0 },
            { 129,  40,   0 },
        };

        int[,] Trav123 = new int[5, 3]
        {
            { 122,  44,   0 },
            { 124,  43,   0 },
            { 124,  77,   0 },
            { 126,  28,   0 },
            { 129,  40,   0 },
        };

        int[,] Trav124 = new int[8, 3]
        {
            { 123,  44,   0 },
            { 125,  47,   0 },
            { 125,  36,   0 },
            { 128,  48,   0 },
            { 128,  37,   0 },
            { 128,  30,   0 },
            { 126,  28,   0 },
            { 129,  40,   0 },
        };

        int[,] Trav125 = new int[6, 3]
        {
            { 124,  46,   0 },
            { 124,  77,   0 },
            { 126,  45,   0 },
            { 126,  28,   0 },
            { 127,  43,   0 },
            { 127,  17,   0 },
        };

        int[,] Trav126 = new int[6, 3]
        {
            { 125,  46,   0 },
            { 125,  23,   0 },
            { 125,  11,   0 },
            { 124,  77,   0 },
            { 610,  30,   0 },
            { 610,  39,   0 },
        };

        int[,] Trav127 = new int[5, 3]
        {
            { 125,  44,   0 },
            { 125,  11,   0 },
            { 125,  17,   0 },
            { 124,  77,   0 },
            { 126,  28,   0 },
        };

        int[,] Trav128 = new int[7, 3]
        {
            { 124,  45,   0 },
            { 124,  29,   0 },
            { 124,  77,   0 },
            { 129,  46,   0 },
            { 129,  30,   0 },
            { 129,  40,   0 },
            { 126,  28,   0 },
        };

        int[,] Trav129 = new int[8, 3]
        {
            { 128,  44,   0 },
            { 128,  29,   0 },
            { 124,  77,   0 },
            { 130,  43,   0 },
            { 130,  19,   0 },
            { 130,  40,   0 },
            { 130,   3,   0 },
            { 126,  28,   0 },
        };

        int[,] Trav130 = new int[3, 3]
        {
            { 129,  44,   0 },
            { 124,  77,   0 },
            { 126,  28,   0 },
        };

        int[,] Trav131 = new int[10, 3]
        {
            { 107,  44,   0 },
            { 132,  48,   0 },
            { 133,  50,   0 },
            { 134,  49,   0 },
            { 135,  47,   0 },
            { 136,  29,   0 },
            { 137,  30,   0 },
            { 138,  45,   0 },
            { 139,  46,   0 },
            { 112,  43,   0 },
        };

        int[,] Trav132 = new int[10, 3]
        {
            { 107,  50,   0 },
            { 131,  29,   0 },
            { 133,  45,   0 },
            { 134,  46,   0 },
            { 135,  44,   0 },
            { 136,  49,   0 },
            { 137,  47,   0 },
            { 138,  43,   0 },
            { 139,  30,   0 },
            { 112,  48,   0 },
        };

        int[,] Trav133 = new int[10, 3]
        {
            { 107,  29,   0 },
            { 131,  30,   0 },
            { 132,  44,   0 },
            { 134,  47,   0 },
            { 135,  49,   0 },
            { 136,  43,   0 },
            { 137,  45,   0 },
            { 138,  50,   0 },
            { 139,  48,   0 },
            { 112,  46,   0 },
        };

        int[,] Trav134 = new int[10, 3]
        {
            { 107,  47,   0 },
            { 131,  45,   0 },
            { 132,  50,   0 },
            { 133,  48,   0 },
            { 135,  43,   0 },
            { 136,  30,   0 },
            { 137,  46,   0 },
            { 138,  29,   0 },
            { 139,  44,   0 },
            { 112,  49,   0 },
        };

        int[,] Trav135 = new int[10, 3]
        {
            { 107,  45,   0 },
            { 131,  48,   0 },
            { 132,  30,   0 },
            { 133,  46,   0 },
            { 134,  43,   0 },
            { 136,  44,   0 },
            { 137,  49,   0 },
            { 138,  47,   0 },
            { 139,  50,   0 },
            { 112,  29,   0 },
        };

        int[,] Trav136 = new int[10, 3]
        {
            { 107,  43,   0 },
            { 131,  44,   0 },
            { 132,  29,   0 },
            { 133,  49,   0 },
            { 134,  30,   0 },
            { 135,  46,   0 },
            { 137,  50,   0 },
            { 138,  48,   0 },
            { 139,  47,   0 },
            { 112,  45,   0 },
        };

        int[,] Trav137 = new int[10, 3]
        {
            { 107,  48,   0 },
            { 131,  47,   0 },
            { 132,  46,   0 },
            { 133,  30,   0 },
            { 134,  29,   0 },
            { 135,  50,   0 },
            { 136,  45,   0 },
            { 138,  49,   0 },
            { 139,  43,   0 },
            { 112,  44,   0 },
        };

        int[,] Trav138 = new int[10, 3]
        {
            { 107,  30,   0 },
            { 131,  43,   0 },
            { 132,  47,   0 },
            { 133,  29,   0 },
            { 134,  44,   0 },
            { 135,  45,   0 },
            { 136,  46,   0 },
            { 137,  48,   0 },
            { 139,  49,   0 },
            { 112,  50,   0 },
        };

        int[,] Trav139 = new int[10, 3]
        {
            { 107,  49,   0 },
            { 131,  50,   0 },
            { 132,  43,   0 },
            { 133,  44,   0 },
            { 134,  45,   0 },
            { 135,  30,   0 },
            { 136,  48,   0 },
            { 137,  29,   0 },
            { 138,  46,   0 },
            { 112,  47,   0 },
        };

        int[,] Trav140 = new int[2, 3]
        {
            { 112,  45,   0 },
            { 112,  11,   0 },
        };
        #endregion

    };

    [Serializable]
    public class advData : ISerializable
    {
        public const int MAXOBJ = 100;
        public const int MAXLOC = 150;
        public const int DWARFMAX = 7;
        
        public advData()
        {
            if (null == pTravel) { 
                pTravel = new TravelTable();
            }        
        }
        public void Clear()
        {
            Array.Clear(Condition, 0, Condition.Length);
            Array.Clear(Place, 0, Place.Length);
            Array.Clear(FixedLocation, 0, FixedLocation.Length);
            Array.Clear(Visited, 0, Visited.Length);
            Array.Clear(Property, 0, Property.Length);
            Array.Clear(DwarfLocation, 0, DwarfLocation.Length);
            Array.Clear(DwarfSeen, 0, DwarfSeen.Length);
            Array.Clear(OldDwarfLocation, 0, OldDwarfLocation.Length);
            Array.Clear(ActionMsg, 0, ActionMsg.Length);

            pTravel.Clear();

        }

        #region StartingData
        public int[] Condition = new int[MAXLOC] {
            0,  5,  1,  5,  5,  1,  1,  5, 17,  1,  /*   0 -   9 */
            1,  0,  0, 32,  0,  0,  2,  0,  0, 64,  /*  10 -  19 */
            2,  2,  2,  0,  6,  0,  2,  0,  0,  0,  /*  20 -  29 */
            0,  2,  2,  0,  0,  0,  0,  0,  4,  0,  /*  30 -  39 */
            2, 0, 128, 128, 128, 128, 136, 136, 136, 128,  /*  40 -  49 */
            128, 128, 128, 136, 128, 136, 0, 8, 0, 2,  /*  50 -  59 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /*  60 -  69 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 2,  /*  70 -  79 */
            128, 128, 136, 0, 0, 8, 136, 128, 0, 2,  /*  80 -  89 */
            2, 0, 0, 0, 0, 4, 0, 0, 0, 0,  /*  90 -  99 */
            1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 100 - 109 */
            0, 0, 0, 4, 0, 1, 1, 0, 0, 0,  /* 110 - 119 */
            0, 0, 8, 8, 8, 8, 8, 8, 8, 8,  /* 120 - 129 */
            8, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 130 - 139 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 140 - 149 */
        };
        public int[] Place = new int[MAXOBJ] 	        /* object location    */
        {
            0, 3, 3, 8, 10, 11, 0, 14, 13, 94,  /*  0 -	9 */
            96, 19, 17, 101, 103, 0, 106, 0, 0, 3,  /* 10 - 19 */
            3, 0, 0, 109, 25, 23, 111, 35, 0, 97,  /* 20 - 29 */
            0, 119, 117, 117, 0, 130, 0, 126, 140, 0,  /* 30 - 39 */
            96, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 40 - 49 */
            18, 27, 28, 29, 30, 0, 92, 95, 97, 100,  /* 50 - 59 */
            101, 0, 119, 127, 130, 0, 0, 0, 0, 0,  /* 60 - 69 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 70 - 79 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 80 - 89 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 90 - 99 */
        };
        public int[] FixedLocation = new int[MAXOBJ]         /* second object loc  */
        {
            0, 0, 0, 9, 0, 0, 0, 15, 0, -1,  /*  0 -	9 */
            0, -1, 27, -1, 0, 0, 0, -1, 0, 0,  /* 10 - 19 */
            0, 0, 0, -1, -1, 67, -1, 110, 0, -1,  /* 20 - 29 */
            -1, 121, 122, 122, 0, -1, -1, -1, -1, 0,  /* 30 - 39 */
            -1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 40 - 49 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 50 - 59 */
            0, 0, 121, 0, -1, 0, 0, 0, 0, 0,  /* 60 - 69 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 70 - 79 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 80 - 89 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  /* 90 - 99 */
        };
        public int[] Visited = new int[MAXLOC];
        public int[] Property = new int[MAXOBJ] {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, /*  0 -	9 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, /* 10 - 19 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, /* 20 - 29 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, /* 30 - 39 */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, /* 40 - 49 */
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, /* 50 - 59 */
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, /* 60 - 69 */
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, /* 70 - 79 */
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, /* 80 - 89 */
            -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, /* 90 - 99 */
        };
        public int[] DwarfLocation = new int[DWARFMAX]	      /* dwarf locations    */
        {
            0, 19, 27, 33, 44, 64, 0		       /*  0 - 6  */
        };
        public int[] DwarfSeen = new int[DWARFMAX];	       /* dwarf seen flag    */
        public int[] OldDwarfLocation = new int[DWARFMAX];	       /* dwarf old locs     */
        public int[] ActionMsg = new int[] {
            0, 24, 29, 0, 33, 0, 33, 38, 38, 42,  /*  0 -	9 */
            14, 43, 110, 29, 110, 73, 75, 29, 13, 59,  /* 10 - 19 */
            59, 174, 109, 67, 13, 147, 155, 195, 146, 110,  /* 20 - 29 */
            13, 13					       /* 30 - 31 */
        };
        #endregion

        #region Class Variables
        public TravelTable pTravel;
        public int sTravCnt = 0;

        public int nVerb;
        public int aeobject;
        public int nMotion;

        public int nTurns = 0;
        public int nLocation = 1;
        public int nOldLocation = 1;
        public int nOldLocation2 = 1;
        public int nNewLocation = 3;

        public int nTally = 15;             /* item counts	     */
        public int nTally2 = 0;
        public int limit = 100;             /* time limit	     */
        public int lmwarn = 0;              /* lamp warning flag  */
        public bool b_wzdark = false;
        public bool bClosing = false;
        public bool b_closed = false;
        public int nHolding = 0;            /* count of held items*/
        public int detail = 0;              /* LOOK count	     */
        public int nKnifeLocation = 0;      /* knife location     */
        public int clock1 = 30;             /* timing variables   */
        public int clock2 = 50;
        public int nPanic = 0;

        public int nDwarfFlag = 0;          /* dwarf flag	     */
        public int nDwarfAltLocation = 18;  /* alt appearance     */
        public int nDwarvesKilled = 0;      /* dwarves killed     */
        public int nChestLocations = 114;   /* chest locations    */
        public int nChestLocations2 = 140;
        public int bonus = 0;               /* to pass to end     */
        public int nNumberOfDeaths = 0;     /* number of deaths   */
        public int object1;		            /* to help intrans.   */
        public int foobar = 0;              /* fie fie foe foo... */
        public bool bDebug = false;		    /* game in restart?   */
        #endregion

        #region Serialization Routines
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Condition", this.Condition);
            info.AddValue("Place", this.Place);
            info.AddValue("FixedLocation", this.FixedLocation);
            info.AddValue("Visited", this.Visited);
            info.AddValue("Property", this.Property);
            info.AddValue("DwarfLocation", this.DwarfLocation);
            info.AddValue("DwarfSeen", this.DwarfSeen);
            info.AddValue("OldDwarfLocation", this.OldDwarfLocation);
            info.AddValue("ActionMsg", this.ActionMsg);

            info.AddValue("pTravelDest", this.pTravel.Destination);
            info.AddValue("pTravelCond", this.pTravel.Condition);
            info.AddValue("pTravelVerb", this.pTravel.Verb);
            info.AddValue("pTravelCount", this.sTravCnt);

            info.AddValue("Verb", this.nVerb);
            info.AddValue("aeobject", this.aeobject );
            info.AddValue("motion", this.nMotion);

            info.AddValue("Turns", this.nTurns);
            info.AddValue("Location", this.nLocation);
            info.AddValue("OldLocation", this.nOldLocation);
            info.AddValue("OldLocation2", this.nOldLocation2);
            info.AddValue("NewLocation", this.nNewLocation);

            info.AddValue("Tally", this.nTally);
            info.AddValue("Tally2", this.nTally2);
            info.AddValue("limit", this.limit);
            info.AddValue("lmwarn", this.lmwarn);
            info.AddValue("b_wzdark", this.b_wzdark);
            info.AddValue("bClosing", this.bClosing);
            info.AddValue("b_closed", this.b_closed);
            info.AddValue("Holding", this.nHolding);
            info.AddValue("detail", this.detail);
            info.AddValue("KnifeLocation", this.nKnifeLocation);
            info.AddValue("clock1", this.clock1);
            info.AddValue("clock2", this.clock2);
            info.AddValue("Panic", this.nPanic);

            info.AddValue("DwarfFlag", this.nDwarfFlag);
            info.AddValue("DwarfAltLocation", this.nDwarfAltLocation);
            info.AddValue("DwarvesKilled", this.nDwarvesKilled);
            info.AddValue("ChestLocations", this.nChestLocations);
            info.AddValue("ChestLocations2", this.nChestLocations2);
            info.AddValue("NumberOfDeaths", this.nNumberOfDeaths);
            info.AddValue("object1", this.object1);
            info.AddValue("foobar", this.foobar);
            info.AddValue("Debug", this.bDebug);
        }
        public advData(SerializationInfo info, StreamingContext ctxt)
        {

            if (null == pTravel) {
                pTravel = new TravelTable();
            }        

            this.Condition = (int[])info.GetValue("Condition", typeof(int[]));
            this.Place = (int[])info.GetValue("Place", typeof(int[]));
            this.FixedLocation = (int[])info.GetValue("FixedLocation", typeof(int[]));
            this.Visited = (int[])info.GetValue("Visited", typeof(int[]));
            this.Property = (int[])info.GetValue("Property", typeof(int[]));
            this.DwarfLocation = (int[])info.GetValue("DwarfLocation", typeof(int[]));
            this.DwarfSeen = (int[])info.GetValue("DwarfSeen", typeof(int[]));
            this.OldDwarfLocation = (int[])info.GetValue("OldDwarfLocation", typeof(int[]));
            this.ActionMsg = (int[])info.GetValue("ActionMsg", typeof(int[]));

            this.pTravel.Destination = (int)info.GetValue("pTravelDest", typeof(int));
            this.pTravel.Condition = (int)info.GetValue("pTravelCond", typeof(int));
            this.pTravel.Verb = (int)info.GetValue("pTravelVerb", typeof(int));
            this.sTravCnt = (int)info.GetValue("pTravelCount", typeof(int));

            this.nVerb = (int)info.GetValue("Verb", typeof(int));
            this.aeobject = (int)info.GetValue("aeobject", typeof(int));
            this.nMotion = (int)info.GetValue("motion", typeof(int));

            this.nTurns = (int)info.GetValue("Turns", typeof(int));
            this.nLocation = (int)info.GetValue("Location", typeof(int));
            this.nOldLocation = (int)info.GetValue("OldLocation", typeof(int));
            this.nOldLocation2 = (int)info.GetValue("OldLocation2", typeof(int));
            this.nNewLocation = (int)info.GetValue("NewLocation", typeof(int));

            this.nTally =        (int)info.GetValue("Tally", typeof(int));      
            this.nTally2 =       (int)info.GetValue("Tally2", typeof(int));     
            this.limit =        (int)info.GetValue("limit", typeof(int));      
            this.lmwarn =       (int)info.GetValue("lmwarn", typeof(int));     
            this.b_wzdark =     (bool)info.GetValue("b_wzdark", typeof(bool));   
            this.bClosing =    (bool)info.GetValue("bClosing", typeof(bool));  
            this.b_closed =     (bool)info.GetValue("b_closed", typeof(bool));
            this.nHolding = (int)info.GetValue("Holding", typeof(int));    
            this.detail =       (int)info.GetValue("detail", typeof(int));     
            this.nKnifeLocation =       (int)info.GetValue("KnifeLocation", typeof(int));     
            this.clock1 =       (int)info.GetValue("clock1", typeof(int));     
            this.clock2 =       (int)info.GetValue("clock2", typeof(int));     
            this.nPanic =        (int)info.GetValue("Panic", typeof(int));

            this.nDwarfFlag = (int)info.GetValue("DwarfFlag", typeof(int));
            this.nDwarfAltLocation = (int)info.GetValue("DwarfAltLocation", typeof(int));
            this.nDwarvesKilled =        (int)info.GetValue("DwarvesKilled", typeof(int));  
            this.nChestLocations =        (int)info.GetValue("ChestLocations", typeof(int));  
            this.nChestLocations2 =       (int)info.GetValue("ChestLocations2", typeof(int));
            this.nNumberOfDeaths = (int)info.GetValue("NumberOfDeaths", typeof(int)); 
            this.object1 =      (int)info.GetValue("object1", typeof(int));
            this.foobar =       (int)info.GetValue("foobar", typeof(int)); 
            this.bDebug =       (bool)info.GetValue("Debug", typeof(int));

        }
        #endregion

    }

    partial class TheAdventure
    {
        
        #region Constants
		 
        public const int MAXLOC = 150;
        public const int MAXOBJ = 100;
        public const int WORDSIZE = 20;

        public const int DWARFMAX = 7;
        public const int MAXDIE = 3;
        public const int MAXTRS = 79;

        public const string READ_BIN = "rb";
        public const string WRITE_BIN = "wb";

        public const int VOCAB_OBJECT = 1000;
        public const int VOCAB_VERB = 2000;
        public const int VOCAB_MSG = 3000;

        /*
        Object definitions
        */
        public const int KEYS = 1;
        public const int LAMP = 2;
        public const int GRATE = 3;
        public const int CAGE = 4;
        public const int ROD = 5;
        public const int ROD2 = 6;
        public const int STEPS = 7;
        public const int BIRD = 8;
        public const int DOOR = 9;
        public const int PILLOW = 10;
        public const int SNAKE = 11;
        public const int FISSURE = 12;
        public const int TABLET = 13;
        public const int CLAM = 14;
        public const int OYSTER = 15;
        public const int MAGAZINE = 16;
        public const int DWARF = 17;
        public const int KNIFE = 18;
        public const int FOOD = 19;
        public const int BOTTLE = 20;
        public const int WATER = 21;
        public const int OIL = 22;
        public const int MIRROR = 23;
        public const int PLANT = 24;
        public const int PLANT2 = 25;
        public const int STALACTITE = 26;
        public const int FIGURE = 27;
        public const int AXE = 28;
        public const int DRAWING = 29;
        public const int PIRATE = 30;
        public const int DRAGON = 31;
        public const int CHASM = 32;
        public const int TROLL = 33;
        public const int TROLL2 = 34;
        public const int BEAR = 35;
        public const int MESSAGE = 36;
        public const int VOLCANO = 37;
        public const int VEND = 38;
        public const int BATTERIES = 39;
        public const int CARPET = 40;
        public const int NUGGET = 50;
        public const int DIAMONDS = 51;
        public const int SILVER = 52;
        public const int JEWELS = 53;
        public const int COINS = 54;
        public const int CHEST = 55;
        public const int EGGS = 56;
        public const int TRIDENT = 57;
        public const int VASE = 58;
        public const int EMERALD = 59;
        public const int PYRAMID = 60;
        public const int PEARL = 61;
        public const int RUG = 62;
        public const int SPICES = 63;
        public const int CHAIN = 64;

        /*
        Verb definitions
        */
        public const int NULLX = 21;
        public const int BACK = 8;
        public const int LOOK = 57;
        public const int CAVE = 67;
        public const int ENTRANCE = 64;
        public const int DEPRESSION = 63;

        /*
        Action verb definitions
        */
        public const int TAKE = 1;
        public const int DROP = 2;
        public const int SAY = 3;
        public const int OPEN = 4;
        public const int NOTHING = 5;
        public const int LOCK = 6;
        public const int ON = 7;
        public const int OFF = 8;
        public const int WAVE = 9;
        public const int CALM = 10;
        public const int WALK = 11;
        public const int KILL = 12;
        public const int POUR = 13;
        public const int EAT = 14;
        public const int DRINK = 15;
        public const int RUB = 16;
        public const int THROW = 17;
        public const int QUIT = 18;
        public const int FIND = 19;
        public const int INVENTORY = 20;
        public const int FEED = 21;
        public const int FILL = 22;
        public const int BLAST = 23;
        public const int SCORE = 24;
        public const int FOO = 25;
        public const int BRIEF = 26;
        public const int READ = 27;
        public const int BREAK = 28;
        public const int WAKE = 29;
        public const int SUSPEND = 30;
        public const int HOURS = 31;
        public const int LOG = 32;
        public const int SAVE = 33;
        public const int RESTORE = 34;
        public const int VERBOSE = 35;

        /*
        Bits of array cond
        indicating location status
        */
        public const int LIGHT = 1;
        public const int WATOIL = 2;
        public const int LIQUID = 4;
        public const int NOPIRAT = 8;
        public const int HINTC = 16;
        public const int HINTB = 32;
        public const int HINTS = 64;
        public const int HINTM = 128;
        public const int HINT = 240;
	#endregion
        
        private Random m_rndNumber;
        private advData aData = new advData();

        #region Adventure Data
            private TravelTable pTravel
            {
                get { return aData.pTravel; }
                set { aData.pTravel = value; }
            }
            private int sTravCnt
            {
                get { return aData.sTravCnt; }
                set { aData.sTravCnt = value; }
            }

            public class VOCABTAB
            {
                public int key;             // sWord
                public string pWord;         //char* pWord;
            };
            int nVocabCount = 0;
            private string word1;
            private string word2;

            private int aeobject
            {
                get { return aData.aeobject;  }
                set { aData.aeobject = value;  }
            }
            private int Verb
            {
                get { return aData.nVerb; }
                set { aData.nVerb = value; }
            }
            private int Motion
            {
                get { return aData.nMotion; }
                set { aData.nMotion = value; }
            }
            private int Turns
            {
                get { return aData.nTurns; }
                set { aData.nTurns = value; }
            }
            private int Location
            {
                get { return aData.nLocation; }
                set { aData.nLocation = value; }
            }
            private int OldLocation
            {
                get { return aData.nOldLocation; }
                set { aData.nOldLocation = value; }
            }
            private int OldLocation2
            {
                get { return aData.nOldLocation2; }
                set { aData.nOldLocation2 = value; }
            }
            private int NewLocation
            {
                get { return aData.nNewLocation; }
                set { aData.nNewLocation = value; }
            }

            private int[] Place
            {
                get { return aData.Place; }
                set { aData.Place = value; }
            }
            private int[] Property
            {
                get { return aData.Property; }
                set { aData.Property = value; }
            }
            private int[] FixedLocation
            {
                get { return aData.FixedLocation; }
                set { aData.FixedLocation = value; }
            }
            private int[] Condition
            {
                get { return aData.Condition; }
                set { aData.Condition = value; }
            }
            private int[] Visited
            {
                get { return aData.Visited; }
                set { aData.Visited = value; }
            }
            private int[] ActionMsg
            {
                get { return aData.ActionMsg; }
                set { aData.ActionMsg = value; }
            }
            private int[] DwarfLocation
            {
                get { return aData.DwarfLocation; }
                set { aData.DwarfLocation = value; }
            }
            private int[] DwarfSeen
            {
                get { return aData.DwarfSeen; }
                set { aData.DwarfSeen = value; }
            }
            private int[] OldDwarfLocation
            {
                get { return aData.OldDwarfLocation; }
                set { aData.OldDwarfLocation = value; }
            }

            private int Tally 
            {
                get { return aData.nTally; }
                set { aData.nTally = value;}
            }
            private int Tally2
            {
                get { return aData.nTally2; }
                set { aData.nTally2 = value;}
            }
            private int limit 
            {
                get { return aData.limit; }
                set { aData.limit = value;}
            }

            private int lmwarn
            {
                get { return aData.lmwarn; }
                set { aData.lmwarn = value;}
            }
            private bool b_wzdark 
            {
                get { return aData.b_wzdark; }
                set { aData.b_wzdark = value;}
            }
            private bool bClosing
            {
                get { return aData.bClosing; }
                set { aData.bClosing = value;}
            }
            private bool b_closed 
            {
                get { return aData.b_closed; }
                set { aData.b_closed = value;}
            }
            private int Holding
            {
                get { return aData.nHolding; }
                set { aData.nHolding = value;}
            }
            private int detail 
            {
                get { return aData.detail; }
                set { aData.detail = value;}
            }
            private int KnifeLocation 
            {
                get { return aData.nKnifeLocation; }
                set { aData.nKnifeLocation = value;}
            }
            private int clock1 
            {
                get { return aData.clock1; }
                set { aData.clock1 = value;}
            }
            private int clock2 
            {
                get { return aData.clock2; }
                set { aData.clock2 = value;}
            }
            private int Panic
            {
                get { return aData.nPanic; }
                set { aData.nPanic = value;}
            }

            private int DwarfFlag           /* dwarf flag	     */
            {
                get { return aData.nDwarfFlag; }
                set { aData.nDwarfFlag = value; }
            }
            private int DwarfAltLocation         /* alt appearance     */
            {
                get { return aData.nDwarfAltLocation; }
                set { aData.nDwarfAltLocation = value;}
            }
            private int DwarvesKilled           /* dwarves killed     */
            {
                get { return aData.nDwarvesKilled; }
                set { aData.nDwarvesKilled = value;}
            }
            private int ChestLocations           /* chest locations    */
            {
                get { return aData.nChestLocations; }
                set { aData.nChestLocations = value;}
            }
            private int ChestLocations2
            {
                get { return aData.nChestLocations2; }
                set { aData.nChestLocations2 = value;}
            }
            private int bonus           /* to pass to end     */
            {
                get { return aData.bonus; }
                set { aData.bonus = value;}
            }
            private int NumberOfDeaths          /* number of deaths   */
            {
                get { return aData.nNumberOfDeaths; }
                set { aData.nNumberOfDeaths = value; }
            }
            private int object1		    /* to help intrans.   */
            {
                get { return aData.object1; }
                set { aData.object1 = value;}
            }
            private int foobar          /* fie fie foe foo... */
            {
                get { return aData.foobar; }
                set { aData.foobar = value;}
            }
            private bool Debug		    /* game in restart?   */
            {
                get { return aData.bDebug; }
                set { aData.bDebug = value;}
            }
        #endregion

        private bool m_bSaveGame = false;           /* game being saved?  */
        private bool m_bGaveUp = false;
    }


    public class Serializer
    {
       public Serializer()
       {
       }

       public void SerializeObject(string filename, advData objectToSerialize)
       {
          Stream stream = File.Open(filename, FileMode.Create);
          BinaryFormatter bFormatter = new BinaryFormatter();
          bFormatter.Serialize(stream, objectToSerialize);
          stream.Close();
       }

       public advData DeSerializeObject(string filename)
       {
          advData objectToSerialize;
          Stream stream = File.Open(filename, FileMode.Open);
          BinaryFormatter bFormatter = new BinaryFormatter();
          objectToSerialize = (advData)bFormatter.Deserialize(stream);
          stream.Close();
          return objectToSerialize;
       }
    }


}

