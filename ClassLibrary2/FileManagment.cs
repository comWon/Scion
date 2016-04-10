using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Scion.MainHard
{
    public static class FileManagment
    {
        /// <summary>
        /// Load Monster File from any compatible version. NOTE Many Possible errors thrown;
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>Standard Monster Set Format</returns>
        public static List<Monster> MonsterLoader(string filepath)
        {
            using (FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader rdr = new StreamReader(fileStream))
                {
                    string line1 = rdr.ReadLine();
                    var line1Attribs = line1.Split(',');

                    var check = line1Attribs[0].Split(':');

                    //Check structure = Version
                    if (check[0] != "Version" || line1Attribs[1] != "Monsters") { Exception InvalidFileException = null; throw InvalidFileException; }
                    //Check Version Number <= Current Version 
                    //TODO implement file check for version no
                    if (Convert.ToDecimal(check[1]) > 1) { Exception InvalidVersionException = null; throw InvalidVersionException; }
                    if (Convert.ToDecimal(check[1]) == 1) { return MonsterloaderV1(rdr, check); }

                    /// Add New Versions here



                    ///TODO Finalise neatly
                    ///try oldest version
                    return MonsterloaderV1(rdr, check);
                }
            }


        }

        private static List<Monster> MonsterloaderV1(StreamReader rdr, string[] check)
        {
            List<Monster> output = new List<Monster>();
            while (rdr.EndOfStream == false)
            {
                string line = rdr.ReadLine();
                var seperators = line.Split(',');
                // File Structure = NAME, EpicDex, JoinBattle
                Monster m = new Monster(seperators[0], Convert.ToInt16(seperators[1]), Convert.ToInt16(seperators[2]));

            }
            return output;
        }
        /// <summary>
        /// Writes  out a monster package of all loaded monsters
        /// Overwtrites any existsing file
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="Monsters"></param>
        public static void MonsterSaver(string filepath, List<Monster> Monsters)
        {
            using (FileStream fileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter Wtr = new StreamWriter(fileStream))
                {
                    Wtr.WriteLine("Version:1,Monsters");
                    foreach (Monster MM in Monsters)
                    {
                        Wtr.WriteLine(MM.Name + "," + MM.EpicDex + "," + MM.Joinbattle);
                    }
                }
            }
        }


        public static CharacterSet LoadCharacters (string filepath)
        {
            using (FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader rdr = new StreamReader(fileStream))
                {
                    string line1 = rdr.ReadLine();
                    var line1Attribs = line1.Split(',');

                    var check = line1Attribs[0].Split(':');

                    //Check structure = Version
                    if (check[0] != "Version" || line1Attribs[1] != "Players") { Exception InvalidFileException = null; throw InvalidFileException; }
                    //Check Version Number <= Current Version 
                    //TODO implement file check for version no
                    if (Convert.ToDecimal(check[1]) > 1) { Exception InvalidVersionException = null; throw InvalidVersionException; }
                    if (Convert.ToDecimal(check[1]) == 1) { return CharactersloaderV1(rdr, check); }

                    /// Add New Versions here



                    ///TODO Finalise neatly
                    return CharactersloaderV1(rdr, check);
                }
            }

        }

        private static CharacterSet CharactersloaderV1(StreamReader rdr, string[] check)
        {
            CharacterSet cs = new CharacterSet();
            while (rdr.EndOfStream == false)
            {
                string line = rdr.ReadLine();
                var seperators = line.Split(',');
                // File Structure = NAME,PlayerName, EpicDex, JoinBattle
                CharData c = new CharData(seperators[0], seperators[1], Convert.ToInt16(seperators[3]), Convert.ToInt16(seperators[2]));
                cs.AddCharacter(c);
            }

            return cs;
        }

        /// <summary>
        /// Save Character Files, extracted from current character set, 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="cs"></param>
        public static void CharacterSaver(string filepath, CharacterSet cs)
        {
            using (FileStream fileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter Wtr = new StreamWriter(fileStream))
                {
                    Wtr.WriteLine("Version:1,Players");
                    foreach (CharData C in cs.ActiveCharacters())
                    {
                        Wtr.WriteLine(C.PlayerName + ","+C.ToonName +","+ C.epicDex + "," + C.joinBattle);
                    }
                }
            }
        }
    }
}