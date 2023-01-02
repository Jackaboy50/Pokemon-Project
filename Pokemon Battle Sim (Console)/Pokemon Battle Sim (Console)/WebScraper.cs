using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Battle_Sim__Console_
{
    static class WebScraper
    {
        #region Inflictors
        public static string[,] GetBurnInflictors()
        {
            Functions fn = new Functions();
            string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
            string[,] Burn = new string[21, 2];
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            for (int index = 0; index < 21; index++)
            {
                Burn[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[1]/tbody/tr[{index + 1}]/td[1]").InnerText;
                string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[1]/tbody/tr[{index + 1}]/td[3]").InnerText;
                Burn[index, 1] = fn.SplitPercentage(text);
            }
            return Burn;
        }

        public static string[,] GetParalysisInflictors()
        {
            Functions fn = new Functions();
            string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
            string[,] Paralysis = new string[25, 2];
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            for (int index = 0; index < 24; index++)
            {
                if (doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[2]/tbody/tr[{index + 1}]/td[1]").InnerText.Substring(0, 1) != "G")
                {
                    Paralysis[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[2]/tbody/tr[{index + 1}]/td[1]").InnerText;
                    string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[2]/tbody/tr[{index + 1}]/td[3]").InnerText;
                    Paralysis[index, 1] = fn.SplitPercentage(text);
                }
            }
            return Paralysis;
        }

        public static string[,] GetSleepInflictors()
        {
            Functions fn = new Functions();
            string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
            string[,] Sleep = new string[13, 2];
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            for (int index = 0; index < 12; index++)
            {
                if (doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[3]/tbody/tr[{index + 1}]/td[1]").InnerText.Substring(0, 1) != "G" && doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[3]/tbody/tr[{index + 1}]/td[1]").InnerText != "Rest")
                {
                    Sleep[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[3]/tbody/tr[{index + 1}]/td[1]").InnerText;
                    string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[3]/tbody/tr[{index + 1}]/td[3]").InnerText;
                    Sleep[index, 1] = fn.SplitPercentage(text);
                }
            }
            return Sleep;
        }

        public static string[,] GetConfusionInflictors()
        {
            Functions fn = new Functions();
            string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
            string[,] Confusion = new string[16, 2];
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            for (int index = 0; index < 15; index++)
            {
                if (doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[4]/tbody/tr[{index + 1}]/td[1]").InnerText.Substring(0, 1) != "G")
                {
                    Confusion[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[4]/tbody/tr[{index + 1}]/td[1]").InnerText;
                    string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[4]/tbody/tr[{index + 1}]/td[3]").InnerText;
                    Confusion[index, 1] = fn.SplitPercentage(text);
                }
            }
            return Confusion;
        }

        public static string[,] GetFrozenInflictors()
        {
            Functions fn = new Functions();
            string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
            string[,] Frozen = new string[9, 2];
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            for (int index = 0; index < 8; index++)
            {
                Frozen[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[5]/tbody/tr[{index + 1}]/td[1]").InnerText;
                string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[5]/tbody/tr[{index + 1}]/td[3]").InnerText;
                Frozen[index, 1] = fn.SplitPercentage(text);
            }
            return Frozen;
        }

        public static string[,] GetPoisonInflictors()
        {
            Functions fn = new Functions();
            string url = "https://game8.co/games/pokemon-sword-shield/archives/338976#hl_1/";
            string[,] Poison = new string[21, 2];
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            for (int index = 0; index < 20; index++)
            {
                if (doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[6]/tbody/tr[{index + 1}]/td[1]").InnerText.Substring(1, 1) != "-")
                {
                    Poison[index, 0] = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[6]/tbody/tr[{index + 1}]/td[1]").InnerText;
                    string text = doc.DocumentNode.SelectSingleNode($"/html/body/div[5]/div[2]/div[1]/div[1]/div[4]/table[6]/tbody/tr[{index + 1}]/td[3]").InnerText;
                    Poison[index, 1] = fn.SplitPercentage(text);
                }
            }
            return Poison;
        }
        #endregion
        public static string GetPokemonImageRef(string PKMN)
        {
            Functions fn = new Functions();
            string baseurl = "https://www.serebii.net/pokemon/";
            string[] words = fn.SplitRegion(PKMN);
            string dexnum = "000";
            if (words != null)
            {
                PKMN = words[1];
                dexnum = GetDexNum(PKMN);
                string region = words[0];
                region = region.Substring(0, 1).ToLower();
                dexnum += $"-{region}";
            }
            else
            {
                dexnum = GetDexNum(PKMN);
            }
            string imageref = baseurl + $"art/{dexnum}.png";
            return imageref;

        }
        public static List<int> GetBaseStats(string PKMN)
        {
            int div = 1;
            string[] regionalCheck = PKMN.Split(" ");
            if(regionalCheck.Contains("A") || regionalCheck.Contains("G") || regionalCheck.Contains("H") || regionalCheck.Contains("P"))
            {
                div++;
            }
            string baseurl = "https://pokemondb.net/pokedex/";
            string url = baseurl + regionalCheck[0].ToLower();
            List<int> BaseStats = new List<int>();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var nodes = doc.DocumentNode.SelectNodes($"/html/body/main/div[2]/div[2]/div[{div}]/div[2]/div[1]/div[2]/table/tbody/tr[position()>0]");

            foreach (var node in nodes)
            {
                if (BaseStats.Count < 6)
                {
                    BaseStats.Add(int.Parse(node.SelectSingleNode("td[1]").InnerText));
                }
            }
            return BaseStats;
        }

        public static List<string> GetPossibleMoves(string PKMN)
        {
            int div = 1;
            string[] regionalCheck = PKMN.Split(" ");
            if (regionalCheck.Contains("A") || regionalCheck.Contains("G") || regionalCheck.Contains("H") || regionalCheck.Contains("P"))
            {
                div++;
            }
            string baseurl = "https://pokemondb.net/pokedex/";
            string url = baseurl + regionalCheck[0].ToLower();
            List<string> possibleMoves = new List<string>();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var tables = doc.DocumentNode.SelectNodes("//table[position()>0][@class=\"data-table\"]");
            int counter = 0;
            int index = 2;
            Functions fn = new Functions();
            HtmlNodeCollection cells;
            foreach (HtmlNode dataTable in tables)
            {
                cells = dataTable.SelectNodes($".//tr/td[2]");
                if (int.TryParse(cells[0].InnerText, out _) || fn.FindType(cells[0].InnerText) != null)
                {
                    cells = dataTable.SelectNodes($".//tr/td[1]");
                }

                foreach (HtmlNode cell in cells)
                {
                    if (!possibleMoves.Contains(cell.InnerText))
                    {
                        possibleMoves.Add(cell.InnerText);
                    }
                }
            }
            return possibleMoves;
        }

        public static List<string> GetPossibleMovesRegionalTest(string PKMN)
        {
            int div = 1;
            bool regional = false;
            bool toggleMask = false;
            string[] regionalCheck = PKMN.Split(" ");
            if (regionalCheck.Contains("A") || regionalCheck.Contains("G") || regionalCheck.Contains("H") || regionalCheck.Contains("P"))
            {
                div++;
                regional = true;
            }
            string baseurl = "https://pokemondb.net/pokedex/";
            string url = baseurl + regionalCheck[0].ToLower();
            List<string> possibleMoves = new List<string>();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            HtmlNodeCollection tables = doc.DocumentNode.SelectNodes("//table[position()>0][@class=\"data-table\"]");
            int counter = 0;
            Functions fn = new Functions();
            HtmlNodeCollection cells;
            foreach (HtmlNode dataTable in tables)
            {
                if (regional == toggleMask && counter < tables.Count / 2 - 1)
                {
                    cells = dataTable.SelectNodes($".//tr/td[2]");
                    if (int.TryParse(cells[0].InnerText, out _) || fn.FindType(cells[0].InnerText) != null)
                    {
                        cells = dataTable.SelectNodes($".//tr/td[1]");
                    }

                    foreach (HtmlNode cell in cells)
                    {
                        if (!possibleMoves.Contains(cell.InnerText))
                        {
                            possibleMoves.Add(cell.InnerText);
                        }
                    }
                    counter++;
                }
                toggleMask = !toggleMask;
            }
            return possibleMoves;
        }

        public static string GetType1Name(string PKMN)
        {
            int div = 1;
            string[] regionalCheck = PKMN.Split(" ");
            if (regionalCheck.Contains("A") || regionalCheck.Contains("G") || regionalCheck.Contains("H") || regionalCheck.Contains("P"))
            {
                div++;
            }
            string baseurl = "https://pokemondb.net/pokedex/";
            string url = baseurl + regionalCheck[0].ToLower();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode($"/html/body/main/div[2]/div[2]/div[{div}]/div[1]/div[2]/table/tbody/tr[2]/td/a[1]");
            string TypeName = node.InnerText.ToString();
            return TypeName;
        }

        public static string GetType2Name(string PKMN)
        {
            int div = 1;
            string[] regionalCheck = PKMN.Split(" ");
            if (regionalCheck.Contains("A") || regionalCheck.Contains("G") || regionalCheck.Contains("H") || regionalCheck.Contains("P"))
            {
                div++;
            }
            string baseurl = "https://pokemondb.net/pokedex/";
            string url = baseurl + regionalCheck[0].ToLower();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode($"/html/body/main/div[2]/div[2]/div[{div}]/div[1]/div[2]/table/tbody/tr[2]/td/a[2]");
            if (node != null)
            {
                string TypeName = node.InnerText.ToString();
                return TypeName;
            }
            return "Pokemon has no Second Type";
        }

        public static Move GetMove(string move)
        {
            Functions fn = new Functions();
            move = fn.Hyphonator(move);
            int BaseDamage = 0;
            int Accuracy = 1;
            string baseurl = "https://pokemondb.net/move/";
            string url = baseurl + move.ToLower();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[1]/td/a");
            string TypeName = node.InnerText.ToString().Trim();
            PType T;
            if (fn.FindType(TypeName) == null)
            {
                return null;
            }
            T = fn.FindType(TypeName);
            var node2 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[2]/td/text()");
            string TempAttackType = node2.InnerText.ToString();
            string AttackType = (TempAttackType.Substring(TempAttackType.IndexOf(" "))).Trim();
            var node3 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[3]/td");
            if (node3.InnerText.ToString() != "—")
            {
                BaseDamage = int.Parse(node3.InnerText.ToString());
            }

            var node4 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[5]/td/text()");
            string tempPP = node4.InnerText.ToString();
            int PP = -1;
            if(!tempPP.Contains("—"))
            {
                PP = int.Parse(tempPP.Substring(0, tempPP.IndexOf(" ")));
            }
            var node5 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[1]/table/tbody/tr[4]/td");
            int.TryParse(node5.InnerText.ToString(), out Accuracy);
            var node7 = doc.DocumentNode.SelectSingleNode("/html/body/main/h1/text()");
            string moveName = node7.InnerText.ToString().Trim();
            var node6 = doc.DocumentNode.SelectSingleNode("/html/body/main/div[1]/div[2]/p/text()");
            string MoveInfo = moveName + " " + node6.InnerText.ToString().TrimStart();
            return new Move(moveName, T, MoveInfo, BaseDamage, AttackType, PP, Accuracy);
        }

        public static string GetDexNum(string PKMN)
        {
            Functions fn = new Functions();
            string[] regionalCheck = PKMN.Split(" ");
            string baseurl = "https://pokemondb.net/pokedex/";
            string url = baseurl + regionalCheck[0].ToLower();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("/html/body/main/div[2]/div[2]/div/div[1]/div[2]/table/tbody/tr[1]/td/strong");
            string dexnum = node.InnerText;
            return dexnum;
        }

        public static Pokemon GetPokemon(string PKMN)
        {
            Functions fn = new Functions();
            string[] regionalCheck = PKMN.Split(" ");
            string baseurl = "https://pokemondb.net/pokedex/";
            string url = baseurl + regionalCheck[0].ToLower();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(url);
            var node = doc.DocumentNode.SelectSingleNode("/html/body/main/h1");
            if (node == null)
            {
                Console.WriteLine("Pokemon does not exist");
                return null;
            }

            PType T1 = fn.FindType(GetType1Name(PKMN));
            PType T2 = fn.FindType(GetType2Name(PKMN));
            int[] B = GetBaseStats(PKMN).ToArray();
            List<string> PM = GetPossibleMoves(PKMN);

            string regionalName = "";
            if(regionalCheck.Length > 1)
            {
                switch (regionalCheck[1])
                {
                    case "A":
                        regionalName = "Alolan";
                        break;
                    case "G":
                        regionalName = "Galarian";
                        break;
                    case "H":
                        regionalName = "Hisuian";
                        break;
                    case "P":
                        regionalName = "Paldean";
                        break;
                }
            }
            return new Pokemon( $"{regionalName} {regionalCheck[0]}", T1, T2, B, PM);

        }
    }
}
