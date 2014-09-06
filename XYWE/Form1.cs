using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;

namespace XYWE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] specieslist = { };
        string[] metXY_00000 = { };
        byte[] zonedata = { };
        string[] LocationNames = { };
        private string[] encdatapaths;
        private string[] filepaths;

        private void Form1_Load(object sender, EventArgs e)
        {
            specieslist = getStringList("Species", "en");
            specieslist[0] = "---";
            #region Forme List Initialization
            this.CB_FormeList.Items.AddRange(new string[] {"Unown-A - 0",
            "Unown-B - 1",
            "Unown-C - 2",
            "Unown-D - 3",
            "Unown-E - 4",
            "Unown-F - 5",
            "Unown-G - 6",
            "Unown-H - 7",
            "Unown-I - 8",
            "Unown-J - 9",
            "Unown-K - 10",
            "Unown-L - 11",
            "Unown-M - 12",
            "Unown-N - 13",
            "Unown-O - 14",
            "Unown-P - 15",
            "Unown-Q - 16",
            "Unown-R - 17",
            "Unown-S - 18",
            "Unown-T - 19",
            "Unown-U - 20",
            "Unown-V - 21",
            "Unown-W - 22",
            "Unown-X - 23",
            "Unown-Y - 24",
            "Unown-Z - 25",
            "Unown-! - 26",
            "Unown-? - 27",
            "",
            "Castform-Normal - 0",
            "Castform-Sunny - 1",
            "Castform-Rainy - 2",
            "Castform-Snowy - 3",
            "",
            "Deoxys-Normal - 0",
            "Deoxys-Attack - 1",
            "Deoxys-Defense - 2",
            "Deoxys-Speed - 3",
            "",
            "Burmy-Plant Cloak - 0",
            "Burmy-Sandy Cloak - 1",
            "Burmy-Trash Cloak - 2",
            "",
            "Wormadam-Plant Cloak - 0",
            "Wormadam-Sandy Cloak - 1",
            "Wormadam-Trash Cloak - 2",
            "",
            "Cherrim-Overcast - 0",
            "Cherrim-Sunshine - 1",
            "",
            "Shellos-West Sea - 0",
            "Shellos-East Sea - 1",
            "",
            "Gastrodon-West Sea - 0",
            "Gastrodon-East Sea - 1",
            "",
            "Rotom-Normal - 0",
            "Rotom-Heat - 1",
            "Rotom-Wash - 2",
            "Rotom-Frost - 3",
            "Rotom-Fan - 4",
            "Rotom-Mow - 5",
            "",
            "Giratina-Altered - 0",
            "Giratina-Origin - 1",
            "",
            "Shaymin-Land - 0",
            "Shaymin-Sky - 1",
            "",
            "Arceus-Normal - 0",
            "Arceus-Fighting - 1",
            "Arceus-Flying - 2",
            "Arceus-Poison - 3",
            "Arceus-Ground - 4",
            "Arceus-Rock - 5",
            "Arceus-Bug - 6",
            "Arceus-Ghost - 7",
            "Arceus-Steel - 8",
            "Arceus-Fire - 9",
            "Arceus-Water - 10",
            "Arceus-Grass - 11",
            "Arceus-Electric - 12",
            "Arceus-Psychic - 13",
            "Arceus-Ice - 14",
            "Arceus-Dragon - 15",
            "Arceus-Dark - 16",
            "",
            "Basculin-Red-Striped - 0",
            "Basculin-Blue-Striped - 1",
            "",
            "Darmanitan-Standard Mode - 0",
            "Darmanitan-Zen Mode - 1",
            "",
            "Deerling-Spring - 0",
            "Deerling-Summer - 1",
            "Deerling-Autumn - 2",
            "Deerling-Winter - 3",
            "",
            "Sawsbuck-Spring - 0",
            "Sawsbuck-Summer - 1",
            "Sawsbuck-Autumn - 2",
            "Sawsbuck-Winter - 3",
            "",
            "Tornadus-Incarnate - 0",
            "Tornadus-Therian - 1",
            "",
            "Thundurus-Incarnate - 0",
            "Thundurus-Therian - 1",
            "",
            "Landorus-Incarnate - 0",
            "Landorus-Therian - 1",
            "",
            "Kyurem-Normal - 0",
            "Kyurem-White - 1",
            "Kyurem-Black - 2",
            "",
            "Keldeo-Usual - 0",
            "Keldeo-Resolution - 1",
            "",
            "Meloetta-Aria - 0",
            "Meloetta-Pirouette - 1",
            "",
            "Genesect-Normal - 0",
            "Genesect-Water - 1",
            "Genesect-Electric - 2",
            "Genesect-Fire - 3",
            "Genesect-Ice - 4",
            "",
            "Flabebe-Red - 0",
            "Flabebe-Yellow - 1",
            "Flabebe-Orange - 2",
            "Flabebe-Blue - 3",
            "Flabebe-White - 4",
            "",
            "Floette-Red - 0",
            "Floette-Yellow - 1",
            "Floette-Orange - 2",
            "Floette-Blue - 3",
            "Floette-Wite - 4",
            "Floette-Eternal - 5",
            "",
            "Florges-Red - 0",
            "Florges-Yellow - 1",
            "Florges-Orange - 2",
            "Florges-Blue - 3",
            "Florges-White - 4",
            "",
            "Furfrou- Natural - 0",
            "Furfrou- Heart - 1",
            "Furfrou- Star - 2",
            "Furfrou- Diamond - 3",
            "Furfrou- Deputante - 4",
            "Furfrou- Matron - 5",
            "Furfrou- Dandy - 6",
            "Furfrou- La Reine- 7",
            "Furfrou- Kabuki - 8",
            "Furfrou- Pharaoh - 9",
            "",
            "Aegislash- Shield - 0",
            "Aegislash- Blade - 0",
            "",
            "Vivillon-Icy Snow - 0",
            "Vivillon-Polar - 1",
            "Vivillon-Tundra - 2",
            "Vivillon-Continental  - 3",
            "Vivillon-Garden - 4",
            "Vivillon-Elegant - 5",
            "Vivillon-Meadow - 6",
            "Vivillon-Modern  - 7",
            "Vivillon-Marine - 8",
            "Vivillon-Archipelago - 9",
            "Vivillon-High-Plains - 10",
            "Vivillon-Sandstorm - 11",
            "Vivillon-River - 12",
            "Vivillon-Monsoon - 13",
            "Vivillon-Savannah  - 14",
            "Vivillon-Sun - 15",
            "Vivillon-Ocean - 16",
            "Vivillon-Jungle - 17",
            "Vivillon-Fancy - 18",
            "Vivillon-Poké Ball - 19",
            "",
            "Pumpkaboo/Gourgeist-Small - 0",
            "Pumpkaboo/Gourgeist-Average - 1",
            "Pumpkaboo/Gourgeist-Large - 2",
            "Pumpkaboo/Gourgeist-Super - 3",
            "",
            "Megas-Normal - 0",
            "Megas-Mega (X) - 1",
            "Megas-Mega (Y) - 2"
            });
            #endregion
            #region Clear Default Data
            CB_Grass1.Items.Clear();
            CB_Grass2.Items.Clear();
            CB_Grass3.Items.Clear();
            CB_Grass4.Items.Clear();
            CB_Grass5.Items.Clear();
            CB_Grass6.Items.Clear();
            CB_Grass7.Items.Clear();
            CB_Grass8.Items.Clear();
            CB_Grass9.Items.Clear();
            CB_Grass10.Items.Clear();
            CB_Grass11.Items.Clear();
            CB_Grass12.Items.Clear();
            CB_Yellow1.Items.Clear();
            CB_Yellow2.Items.Clear();
            CB_Yellow3.Items.Clear();
            CB_Yellow4.Items.Clear();
            CB_Yellow5.Items.Clear();
            CB_Yellow6.Items.Clear();
            CB_Yellow7.Items.Clear();
            CB_Yellow8.Items.Clear();
            CB_Yellow9.Items.Clear();
            CB_Yellow10.Items.Clear();
            CB_Yellow11.Items.Clear();
            CB_Yellow12.Items.Clear();
            CB_Purple1.Items.Clear();
            CB_Purple2.Items.Clear();
            CB_Purple3.Items.Clear();
            CB_Purple4.Items.Clear();
            CB_Purple5.Items.Clear();
            CB_Purple6.Items.Clear();
            CB_Purple7.Items.Clear();
            CB_Purple8.Items.Clear();
            CB_Purple9.Items.Clear();
            CB_Purple10.Items.Clear();
            CB_Purple11.Items.Clear();
            CB_Purple12.Items.Clear();
            CB_Red1.Items.Clear();
            CB_Red2.Items.Clear();
            CB_Red3.Items.Clear();
            CB_Red4.Items.Clear();
            CB_Red5.Items.Clear();
            CB_Red6.Items.Clear();
            CB_Red7.Items.Clear();
            CB_Red8.Items.Clear();
            CB_Red9.Items.Clear();
            CB_Red10.Items.Clear();
            CB_Red11.Items.Clear();
            CB_Red12.Items.Clear();
            CB_RT1.Items.Clear();
            CB_RT2.Items.Clear();
            CB_RT3.Items.Clear();
            CB_RT4.Items.Clear();
            CB_RT5.Items.Clear();
            CB_RT6.Items.Clear();
            CB_RT7.Items.Clear();
            CB_RT8.Items.Clear();
            CB_RT9.Items.Clear();
            CB_RT10.Items.Clear();
            CB_RT11.Items.Clear();
            CB_RT12.Items.Clear();
            CB_Surf1.Items.Clear();
            CB_Surf2.Items.Clear();
            CB_Surf3.Items.Clear();
            CB_Surf4.Items.Clear();
            CB_Surf5.Items.Clear();
            CB_RockSmash1.Items.Clear();
            CB_RockSmash2.Items.Clear();
            CB_RockSmash3.Items.Clear();
            CB_RockSmash4.Items.Clear();
            CB_RockSmash5.Items.Clear();
            CB_Old1.Items.Clear();
            CB_Old2.Items.Clear();
            CB_Old3.Items.Clear();
            CB_Good1.Items.Clear();
            CB_Good2.Items.Clear();
            CB_Good3.Items.Clear();
            CB_Super1.Items.Clear();
            CB_Super2.Items.Clear();
            CB_Super3.Items.Clear();
            CB_HordeA1.Items.Clear();
            CB_HordeA2.Items.Clear();
            CB_HordeA3.Items.Clear();
            CB_HordeA4.Items.Clear();
            CB_HordeA5.Items.Clear();
            CB_HordeB1.Items.Clear();
            CB_HordeB2.Items.Clear();
            CB_HordeB3.Items.Clear();
            CB_HordeB4.Items.Clear();
            CB_HordeB5.Items.Clear();
            CB_HordeC1.Items.Clear();
            CB_HordeC2.Items.Clear();
            CB_HordeC3.Items.Clear();
            CB_HordeC4.Items.Clear();
            CB_HordeC5.Items.Clear();

            #endregion
            #region Add Data to Boxes
            foreach (string s in specieslist)
            {
                CB_Grass1.Items.Add(s);
                CB_Purple1.Items.Add(s);
                CB_Yellow1.Items.Add(s);
                CB_Red1.Items.Add(s);
                CB_RT1.Items.Add(s);
                CB_Grass2.Items.Add(s);
                CB_Purple2.Items.Add(s);
                CB_Yellow2.Items.Add(s);
                CB_Red2.Items.Add(s);
                CB_RT2.Items.Add(s);
                CB_Grass3.Items.Add(s);
                CB_Purple3.Items.Add(s);
                CB_Yellow3.Items.Add(s);
                CB_Red3.Items.Add(s);
                CB_RT3.Items.Add(s);
                CB_Grass4.Items.Add(s);
                CB_Purple4.Items.Add(s);
                CB_Yellow4.Items.Add(s);
                CB_Red4.Items.Add(s);
                CB_RT4.Items.Add(s);
                CB_Grass5.Items.Add(s);
                CB_Purple5.Items.Add(s);
                CB_Yellow5.Items.Add(s);
                CB_Red5.Items.Add(s);
                CB_RT5.Items.Add(s);
                CB_Grass6.Items.Add(s);
                CB_Purple6.Items.Add(s);
                CB_Yellow6.Items.Add(s);
                CB_Red6.Items.Add(s);
                CB_RT6.Items.Add(s);
                CB_Grass7.Items.Add(s);
                CB_Purple7.Items.Add(s);
                CB_Yellow7.Items.Add(s);
                CB_Red7.Items.Add(s);
                CB_RT7.Items.Add(s);
                CB_Grass8.Items.Add(s);
                CB_Purple8.Items.Add(s);
                CB_Yellow8.Items.Add(s);
                CB_Red8.Items.Add(s);
                CB_RT8.Items.Add(s);
                CB_Grass9.Items.Add(s);
                CB_Purple9.Items.Add(s);
                CB_Yellow9.Items.Add(s);
                CB_Red9.Items.Add(s);
                CB_RT9.Items.Add(s);
                CB_Grass10.Items.Add(s);
                CB_Purple10.Items.Add(s);
                CB_Yellow10.Items.Add(s);
                CB_Red10.Items.Add(s);
                CB_RT10.Items.Add(s);
                CB_Grass11.Items.Add(s);
                CB_Purple11.Items.Add(s);
                CB_Yellow11.Items.Add(s);
                CB_Red11.Items.Add(s);
                CB_RT11.Items.Add(s);
                CB_Grass12.Items.Add(s);
                CB_Purple12.Items.Add(s);
                CB_Yellow12.Items.Add(s);
                CB_Red12.Items.Add(s);
                CB_RT12.Items.Add(s);
                CB_Surf1.Items.Add(s);
                CB_RockSmash1.Items.Add(s);
                CB_HordeA1.Items.Add(s);
                CB_HordeB1.Items.Add(s);
                CB_HordeC1.Items.Add(s);
                CB_Surf2.Items.Add(s);
                CB_RockSmash2.Items.Add(s);
                CB_HordeA2.Items.Add(s);
                CB_HordeB2.Items.Add(s);
                CB_HordeC2.Items.Add(s);
                CB_Surf3.Items.Add(s);
                CB_RockSmash3.Items.Add(s);
                CB_HordeA3.Items.Add(s);
                CB_HordeB3.Items.Add(s);
                CB_HordeC3.Items.Add(s);
                CB_Surf4.Items.Add(s);
                CB_RockSmash4.Items.Add(s);
                CB_HordeA4.Items.Add(s);
                CB_HordeB4.Items.Add(s);
                CB_HordeC4.Items.Add(s);
                CB_Surf5.Items.Add(s);
                CB_RockSmash5.Items.Add(s);
                CB_HordeA5.Items.Add(s);
                CB_HordeB5.Items.Add(s);
                CB_HordeC5.Items.Add(s);
                CB_Old1.Items.Add(s);
                CB_Good1.Items.Add(s);
                CB_Super1.Items.Add(s);
                CB_Old2.Items.Add(s);
                CB_Good2.Items.Add(s);
                CB_Super2.Items.Add(s);
                CB_Old3.Items.Add(s);
                CB_Good3.Items.Add(s);
                CB_Super3.Items.Add(s);
            }
            CB_Grass1.SelectedIndex = 0;
            CB_Purple1.SelectedIndex = 0;
            CB_Yellow1.SelectedIndex = 0;
            CB_Red1.SelectedIndex = 0;
            CB_RT1.SelectedIndex = 0;
            CB_Grass2.SelectedIndex = 0;
            CB_Purple2.SelectedIndex = 0;
            CB_Yellow2.SelectedIndex = 0;
            CB_Red2.SelectedIndex = 0;
            CB_RT2.SelectedIndex = 0;
            CB_Grass3.SelectedIndex = 0;
            CB_Purple3.SelectedIndex = 0;
            CB_Yellow3.SelectedIndex = 0;
            CB_Red3.SelectedIndex = 0;
            CB_RT3.SelectedIndex = 0;
            CB_Grass4.SelectedIndex = 0;
            CB_Purple4.SelectedIndex = 0;
            CB_Yellow4.SelectedIndex = 0;
            CB_Red4.SelectedIndex = 0;
            CB_RT4.SelectedIndex = 0;
            CB_Grass5.SelectedIndex = 0;
            CB_Purple5.SelectedIndex = 0;
            CB_Yellow5.SelectedIndex = 0;
            CB_Red5.SelectedIndex = 0;
            CB_RT5.SelectedIndex = 0;
            CB_Grass6.SelectedIndex = 0;
            CB_Purple6.SelectedIndex = 0;
            CB_Yellow6.SelectedIndex = 0;
            CB_Red6.SelectedIndex = 0;
            CB_RT6.SelectedIndex = 0;
            CB_Grass7.SelectedIndex = 0;
            CB_Purple7.SelectedIndex = 0;
            CB_Yellow7.SelectedIndex = 0;
            CB_Red7.SelectedIndex = 0;
            CB_RT7.SelectedIndex = 0;
            CB_Grass8.SelectedIndex = 0;
            CB_Purple8.SelectedIndex = 0;
            CB_Yellow8.SelectedIndex = 0;
            CB_Red8.SelectedIndex = 0;
            CB_RT8.SelectedIndex = 0;
            CB_Grass9.SelectedIndex = 0;
            CB_Purple9.SelectedIndex = 0;
            CB_Yellow9.SelectedIndex = 0;
            CB_Red9.SelectedIndex = 0;
            CB_RT9.SelectedIndex = 0;
            CB_Grass10.SelectedIndex = 0;
            CB_Purple10.SelectedIndex = 0;
            CB_Yellow10.SelectedIndex = 0;
            CB_Red10.SelectedIndex = 0;
            CB_RT10.SelectedIndex = 0;
            CB_Grass11.SelectedIndex = 0;
            CB_Purple11.SelectedIndex = 0;
            CB_Yellow11.SelectedIndex = 0;
            CB_Red11.SelectedIndex = 0;
            CB_RT11.SelectedIndex = 0;
            CB_Grass12.SelectedIndex = 0;
            CB_Purple12.SelectedIndex = 0;
            CB_Yellow12.SelectedIndex = 0;
            CB_Red12.SelectedIndex = 0;
            CB_RT12.SelectedIndex = 0;
            CB_Surf1.SelectedIndex = 0;
            CB_RockSmash1.SelectedIndex = 0;
            CB_HordeA1.SelectedIndex = 0;
            CB_HordeB1.SelectedIndex = 0;
            CB_HordeC1.SelectedIndex = 0;
            CB_Surf2.SelectedIndex = 0;
            CB_RockSmash2.SelectedIndex = 0;
            CB_HordeA2.SelectedIndex = 0;
            CB_HordeB2.SelectedIndex = 0;
            CB_HordeC2.SelectedIndex = 0;
            CB_Surf3.SelectedIndex = 0;
            CB_RockSmash3.SelectedIndex = 0;
            CB_HordeA3.SelectedIndex = 0;
            CB_HordeB3.SelectedIndex = 0;
            CB_HordeC3.SelectedIndex = 0;
            CB_Surf4.SelectedIndex = 0;
            CB_RockSmash4.SelectedIndex = 0;
            CB_HordeA4.SelectedIndex = 0;
            CB_HordeB4.SelectedIndex = 0;
            CB_HordeC4.SelectedIndex = 0;
            CB_Surf5.SelectedIndex = 0;
            CB_RockSmash5.SelectedIndex = 0;
            CB_HordeA5.SelectedIndex = 0;
            CB_HordeB5.SelectedIndex = 0;
            CB_HordeC5.SelectedIndex = 0;
            CB_Old1.SelectedIndex = 0;
            CB_Good1.SelectedIndex = 0;
            CB_Super1.SelectedIndex = 0;
            CB_Old2.SelectedIndex = 0;
            CB_Good2.SelectedIndex = 0;
            CB_Super2.SelectedIndex = 0;
            CB_Old3.SelectedIndex = 0;
            CB_Good3.SelectedIndex = 0;
            CB_Super3.SelectedIndex = 0;
            #endregion
            //Preload Tabs
            PreloadTabs();
        }

        private string[] getStringList(string f, string l)
        {
            object txt = Properties.Resources.ResourceManager.GetObject("text_" + f + "_" + l); // Fetch File, \n to list.
            List<string> rawlist = ((string)txt).Split(new char[] { '\n' }).ToList();

            string[] stringdata = new string[rawlist.Count];
            for (int i = 0; i < rawlist.Count; i++)
                stringdata[i] = rawlist[i];

            return stringdata;
        }

        private void B_Open_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            this.encdatapaths = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.TopDirectoryOnly);
            Array.Sort(encdatapaths);
            this.filepaths = new string[this.encdatapaths.Length-1];
            Array.Copy(this.encdatapaths, 1, this.filepaths, 0, this.filepaths.Length);
            #region Data Verification
            //Verify that data is legitimate
            if (!this.encdatapaths[0].Contains("360.bin")) // first file is zonedata data
            {
                return;
            }
            foreach (string s in filepaths)
            {
                if (!s.Contains("dec_")) { return; } //Check that all files are of form dec_*.bin
            }
            if (this.encdatapaths.Length != 361) //Check that there are exactly 361 files
            {
                return;
            }
            #endregion
            metXY_00000 = getStringList("xy_00000", "en");
            zonedata = File.ReadAllBytes(encdatapaths[0]);
            LocationNames = new string[this.filepaths.Length];
            for (int f = 0; f < filepaths.Length; f++)
            {
                string name = Path.GetFileNameWithoutExtension(filepaths[f]);
                ;
                int LocationNum = Convert.ToInt16(name.Substring(4, name.Length - 4));
                string LocationName = metXY_00000[zonedata[LocationNum * 56 + 0x1C]];
                LocationNames[f] = (LocationNum.ToString("000") + " - " + LocationName);
            }
            CB_LocationID.DataSource = LocationNames;
            B_Open.Enabled = false;
            B_Save.Enabled = true;
            CB_LocationID.Enabled = true;
            CB_LocationID_SelectedIndexChanged(null, null);
        }

        private bool hasData()
        {
            #region CheckFornon0Vals
            if (CB_Grass1.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme1.Value > 0) { return true; }
            if (NUP_GrassMin1.Value > 0) { return true; }
            if (NUP_GrassMax1.Value > 0) { return true; }
            if (CB_Grass2.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme2.Value > 0) { return true; }
            if (NUP_GrassMin2.Value > 0) { return true; }
            if (NUP_GrassMax2.Value > 0) { return true; }
            if (CB_Grass3.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme3.Value > 0) { return true; }
            if (NUP_GrassMin3.Value > 0) { return true; }
            if (NUP_GrassMax3.Value > 0) { return true; }
            if (CB_Grass4.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme4.Value > 0) { return true; }
            if (NUP_GrassMin4.Value > 0) { return true; }
            if (NUP_GrassMax4.Value > 0) { return true; }
            if (CB_Grass5.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme5.Value > 0) { return true; }
            if (NUP_GrassMin5.Value > 0) { return true; }
            if (NUP_GrassMax5.Value > 0) { return true; }
            if (CB_Grass6.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme6.Value > 0) { return true; }
            if (NUP_GrassMin6.Value > 0) { return true; }
            if (NUP_GrassMax6.Value > 0) { return true; }
            if (CB_Grass7.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme7.Value > 0) { return true; }
            if (NUP_GrassMin7.Value > 0) { return true; }
            if (NUP_GrassMax7.Value > 0) { return true; }
            if (CB_Grass8.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme8.Value > 0) { return true; }
            if (NUP_GrassMin8.Value > 0) { return true; }
            if (NUP_GrassMax8.Value > 0) { return true; }
            if (CB_Grass9.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme9.Value > 0) { return true; }
            if (NUP_GrassMin9.Value > 0) { return true; }
            if (NUP_GrassMax9.Value > 0) { return true; }
            if (CB_Grass10.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme10.Value > 0) { return true; }
            if (NUP_GrassMin10.Value > 0) { return true; }
            if (NUP_GrassMax10.Value > 0) { return true; }
            if (CB_Grass11.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme11.Value > 0) { return true; }
            if (NUP_GrassMin11.Value > 0) { return true; }
            if (NUP_GrassMax11.Value > 0) { return true; }
            if (CB_Grass12.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme12.Value > 0) { return true; }
            if (NUP_GrassMin12.Value > 0) { return true; }
            if (NUP_GrassMax12.Value > 0) { return true; }
            if (CB_Yellow1.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme1.Value > 0) { return true; }
            if (NUP_YellowMin1.Value > 0) { return true; }
            if (NUP_YellowMax1.Value > 0) { return true; }
            if (CB_Yellow2.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme2.Value > 0) { return true; }
            if (NUP_YellowMin2.Value > 0) { return true; }
            if (NUP_YellowMax2.Value > 0) { return true; }
            if (CB_Yellow3.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme3.Value > 0) { return true; }
            if (NUP_YellowMin3.Value > 0) { return true; }
            if (NUP_YellowMax3.Value > 0) { return true; }
            if (CB_Yellow4.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme4.Value > 0) { return true; }
            if (NUP_YellowMin4.Value > 0) { return true; }
            if (NUP_YellowMax4.Value > 0) { return true; }
            if (CB_Yellow5.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme5.Value > 0) { return true; }
            if (NUP_YellowMin5.Value > 0) { return true; }
            if (NUP_YellowMax5.Value > 0) { return true; }
            if (CB_Yellow6.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme6.Value > 0) { return true; }
            if (NUP_YellowMin6.Value > 0) { return true; }
            if (NUP_YellowMax6.Value > 0) { return true; }
            if (CB_Yellow7.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme7.Value > 0) { return true; }
            if (NUP_YellowMin7.Value > 0) { return true; }
            if (NUP_YellowMax7.Value > 0) { return true; }
            if (CB_Yellow8.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme8.Value > 0) { return true; }
            if (NUP_YellowMin8.Value > 0) { return true; }
            if (NUP_YellowMax8.Value > 0) { return true; }
            if (CB_Yellow9.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme9.Value > 0) { return true; }
            if (NUP_YellowMin9.Value > 0) { return true; }
            if (NUP_YellowMax9.Value > 0) { return true; }
            if (CB_Yellow10.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme10.Value > 0) { return true; }
            if (NUP_YellowMin10.Value > 0) { return true; }
            if (NUP_YellowMax10.Value > 0) { return true; }
            if (CB_Yellow11.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme11.Value > 0) { return true; }
            if (NUP_YellowMin11.Value > 0) { return true; }
            if (NUP_YellowMax11.Value > 0) { return true; }
            if (CB_Yellow12.SelectedIndex > 0) { return true; }
            if (NUP_YellowForme12.Value > 0) { return true; }
            if (NUP_YellowMin12.Value > 0) { return true; }
            if (NUP_YellowMax12.Value > 0) { return true; }
            if (CB_Purple1.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme1.Value > 0) { return true; }
            if (NUP_PurpleMin1.Value > 0) { return true; }
            if (NUP_PurpleMax1.Value > 0) { return true; }
            if (CB_Purple2.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme2.Value > 0) { return true; }
            if (NUP_PurpleMin2.Value > 0) { return true; }
            if (NUP_PurpleMax2.Value > 0) { return true; }
            if (CB_Purple3.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme3.Value > 0) { return true; }
            if (NUP_PurpleMin3.Value > 0) { return true; }
            if (NUP_PurpleMax3.Value > 0) { return true; }
            if (CB_Purple4.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme4.Value > 0) { return true; }
            if (NUP_PurpleMin4.Value > 0) { return true; }
            if (NUP_PurpleMax4.Value > 0) { return true; }
            if (CB_Purple5.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme5.Value > 0) { return true; }
            if (NUP_PurpleMin5.Value > 0) { return true; }
            if (NUP_PurpleMax5.Value > 0) { return true; }
            if (CB_Purple6.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme6.Value > 0) { return true; }
            if (NUP_PurpleMin6.Value > 0) { return true; }
            if (NUP_PurpleMax6.Value > 0) { return true; }
            if (CB_Purple7.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme7.Value > 0) { return true; }
            if (NUP_PurpleMin7.Value > 0) { return true; }
            if (NUP_PurpleMax7.Value > 0) { return true; }
            if (CB_Purple8.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme8.Value > 0) { return true; }
            if (NUP_PurpleMin8.Value > 0) { return true; }
            if (NUP_PurpleMax8.Value > 0) { return true; }
            if (CB_Purple9.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme9.Value > 0) { return true; }
            if (NUP_PurpleMin9.Value > 0) { return true; }
            if (NUP_PurpleMax9.Value > 0) { return true; }
            if (CB_Purple10.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme10.Value > 0) { return true; }
            if (NUP_PurpleMin10.Value > 0) { return true; }
            if (NUP_PurpleMax10.Value > 0) { return true; }
            if (CB_Purple11.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme11.Value > 0) { return true; }
            if (NUP_PurpleMin11.Value > 0) { return true; }
            if (NUP_PurpleMax11.Value > 0) { return true; }
            if (CB_Purple12.SelectedIndex > 0) { return true; }
            if (NUP_PurpleForme12.Value > 0) { return true; }
            if (NUP_PurpleMin12.Value > 0) { return true; }
            if (NUP_PurpleMax12.Value > 0) { return true; }
            if (CB_Red1.SelectedIndex > 0) { return true; }
            if (NUP_RedForme1.Value > 0) { return true; }
            if (NUP_RedMin1.Value > 0) { return true; }
            if (NUP_RedMax1.Value > 0) { return true; }
            if (CB_Red2.SelectedIndex > 0) { return true; }
            if (NUP_RedForme2.Value > 0) { return true; }
            if (NUP_RedMin2.Value > 0) { return true; }
            if (NUP_RedMax2.Value > 0) { return true; }
            if (CB_Red3.SelectedIndex > 0) { return true; }
            if (NUP_RedForme3.Value > 0) { return true; }
            if (NUP_RedMin3.Value > 0) { return true; }
            if (NUP_RedMax3.Value > 0) { return true; }
            if (CB_Red4.SelectedIndex > 0) { return true; }
            if (NUP_RedForme4.Value > 0) { return true; }
            if (NUP_RedMin4.Value > 0) { return true; }
            if (NUP_RedMax4.Value > 0) { return true; }
            if (CB_Red5.SelectedIndex > 0) { return true; }
            if (NUP_RedForme5.Value > 0) { return true; }
            if (NUP_RedMin5.Value > 0) { return true; }
            if (NUP_RedMax5.Value > 0) { return true; }
            if (CB_Red6.SelectedIndex > 0) { return true; }
            if (NUP_RedForme6.Value > 0) { return true; }
            if (NUP_RedMin6.Value > 0) { return true; }
            if (NUP_RedMax6.Value > 0) { return true; }
            if (CB_Red7.SelectedIndex > 0) { return true; }
            if (NUP_RedForme7.Value > 0) { return true; }
            if (NUP_RedMin7.Value > 0) { return true; }
            if (NUP_RedMax7.Value > 0) { return true; }
            if (CB_Red8.SelectedIndex > 0) { return true; }
            if (NUP_RedForme8.Value > 0) { return true; }
            if (NUP_RedMin8.Value > 0) { return true; }
            if (NUP_RedMax8.Value > 0) { return true; }
            if (CB_Red9.SelectedIndex > 0) { return true; }
            if (NUP_RedForme9.Value > 0) { return true; }
            if (NUP_RedMin9.Value > 0) { return true; }
            if (NUP_RedMax9.Value > 0) { return true; }
            if (CB_Red10.SelectedIndex > 0) { return true; }
            if (NUP_RedForme10.Value > 0) { return true; }
            if (NUP_RedMin10.Value > 0) { return true; }
            if (NUP_RedMax10.Value > 0) { return true; }
            if (CB_Red11.SelectedIndex > 0) { return true; }
            if (NUP_RedForme11.Value > 0) { return true; }
            if (NUP_RedMin11.Value > 0) { return true; }
            if (NUP_RedMax11.Value > 0) { return true; }
            if (CB_Red12.SelectedIndex > 0) { return true; }
            if (NUP_RedForme12.Value > 0) { return true; }
            if (NUP_RedMin12.Value > 0) { return true; }
            if (NUP_RedMax12.Value > 0) { return true; }
            if (CB_RT1.SelectedIndex > 0) { return true; }
            if (NUP_RTForme1.Value > 0) { return true; }
            if (NUP_RTMin1.Value > 0) { return true; }
            if (NUP_RTMax1.Value > 0) { return true; }
            if (CB_RT2.SelectedIndex > 0) { return true; }
            if (NUP_RTForme2.Value > 0) { return true; }
            if (NUP_RTMin2.Value > 0) { return true; }
            if (NUP_RTMax2.Value > 0) { return true; }
            if (CB_RT3.SelectedIndex > 0) { return true; }
            if (NUP_RTForme3.Value > 0) { return true; }
            if (NUP_RTMin3.Value > 0) { return true; }
            if (NUP_RTMax3.Value > 0) { return true; }
            if (CB_RT4.SelectedIndex > 0) { return true; }
            if (NUP_RTForme4.Value > 0) { return true; }
            if (NUP_RTMin4.Value > 0) { return true; }
            if (NUP_RTMax4.Value > 0) { return true; }
            if (CB_RT5.SelectedIndex > 0) { return true; }
            if (NUP_RTForme5.Value > 0) { return true; }
            if (NUP_RTMin5.Value > 0) { return true; }
            if (NUP_RTMax5.Value > 0) { return true; }
            if (CB_RT6.SelectedIndex > 0) { return true; }
            if (NUP_RTForme6.Value > 0) { return true; }
            if (NUP_RTMin6.Value > 0) { return true; }
            if (NUP_RTMax6.Value > 0) { return true; }
            if (CB_RT7.SelectedIndex > 0) { return true; }
            if (NUP_RTForme7.Value > 0) { return true; }
            if (NUP_RTMin7.Value > 0) { return true; }
            if (NUP_RTMax7.Value > 0) { return true; }
            if (CB_RT8.SelectedIndex > 0) { return true; }
            if (NUP_RTForme8.Value > 0) { return true; }
            if (NUP_RTMin8.Value > 0) { return true; }
            if (NUP_RTMax8.Value > 0) { return true; }
            if (CB_RT9.SelectedIndex > 0) { return true; }
            if (NUP_RTForme9.Value > 0) { return true; }
            if (NUP_RTMin9.Value > 0) { return true; }
            if (NUP_RTMax9.Value > 0) { return true; }
            if (CB_RT10.SelectedIndex > 0) { return true; }
            if (NUP_RTForme10.Value > 0) { return true; }
            if (NUP_RTMin10.Value > 0) { return true; }
            if (NUP_RTMax10.Value > 0) { return true; }
            if (CB_RT11.SelectedIndex > 0) { return true; }
            if (NUP_RTForme11.Value > 0) { return true; }
            if (NUP_RTMin11.Value > 0) { return true; }
            if (NUP_RTMax11.Value > 0) { return true; }
            if (CB_RT12.SelectedIndex > 0) { return true; }
            if (NUP_RTForme12.Value > 0) { return true; }
            if (NUP_RTMin12.Value > 0) { return true; }
            if (NUP_RTMax12.Value > 0) { return true; }
            if (CB_Surf1.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme1.Value > 0) { return true; }
            if (NUP_SurfMin1.Value > 0) { return true; }
            if (NUP_SurfMax1.Value > 0) { return true; }
            if (CB_Surf2.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme2.Value > 0) { return true; }
            if (NUP_SurfMin2.Value > 0) { return true; }
            if (NUP_SurfMax2.Value > 0) { return true; }
            if (CB_Surf3.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme3.Value > 0) { return true; }
            if (NUP_SurfMin3.Value > 0) { return true; }
            if (NUP_SurfMax3.Value > 0) { return true; }
            if (CB_Surf4.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme4.Value > 0) { return true; }
            if (NUP_SurfMin4.Value > 0) { return true; }
            if (NUP_SurfMax4.Value > 0) { return true; }
            if (CB_Surf5.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme5.Value > 0) { return true; }
            if (NUP_SurfMin5.Value > 0) { return true; }
            if (NUP_SurfMax5.Value > 0) { return true; }
            if (CB_RockSmash1.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme1.Value > 0) { return true; }
            if (NUP_RockSmashMin1.Value > 0) { return true; }
            if (NUP_RockSmashMax1.Value > 0) { return true; }
            if (CB_RockSmash2.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme2.Value > 0) { return true; }
            if (NUP_RockSmashMin2.Value > 0) { return true; }
            if (NUP_RockSmashMax2.Value > 0) { return true; }
            if (CB_RockSmash3.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme3.Value > 0) { return true; }
            if (NUP_RockSmashMin3.Value > 0) { return true; }
            if (NUP_RockSmashMax3.Value > 0) { return true; }
            if (CB_RockSmash4.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme4.Value > 0) { return true; }
            if (NUP_RockSmashMin4.Value > 0) { return true; }
            if (NUP_RockSmashMax4.Value > 0) { return true; }
            if (CB_RockSmash5.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme5.Value > 0) { return true; }
            if (NUP_RockSmashMin5.Value > 0) { return true; }
            if (NUP_RockSmashMax5.Value > 0) { return true; }
            if (CB_Old1.SelectedIndex > 0) { return true; }
            if (NUP_OldForme1.Value > 0) { return true; }
            if (NUP_OldMin1.Value > 0) { return true; }
            if (NUP_OldMax1.Value > 0) { return true; }
            if (CB_Old2.SelectedIndex > 0) { return true; }
            if (NUP_OldForme2.Value > 0) { return true; }
            if (NUP_OldMin2.Value > 0) { return true; }
            if (NUP_OldMax2.Value > 0) { return true; }
            if (CB_Old3.SelectedIndex > 0) { return true; }
            if (NUP_OldForme3.Value > 0) { return true; }
            if (NUP_OldMin3.Value > 0) { return true; }
            if (NUP_OldMax3.Value > 0) { return true; }
            if (CB_Good1.SelectedIndex > 0) { return true; }
            if (NUP_GoodForme1.Value > 0) { return true; }
            if (NUP_GoodMin1.Value > 0) { return true; }
            if (NUP_GoodMax1.Value > 0) { return true; }
            if (CB_Good2.SelectedIndex > 0) { return true; }
            if (NUP_GoodForme2.Value > 0) { return true; }
            if (NUP_GoodMin2.Value > 0) { return true; }
            if (NUP_GoodMax2.Value > 0) { return true; }
            if (CB_Good3.SelectedIndex > 0) { return true; }
            if (NUP_GoodForme3.Value > 0) { return true; }
            if (NUP_GoodMin3.Value > 0) { return true; }
            if (NUP_GoodMax3.Value > 0) { return true; }
            if (CB_Super1.SelectedIndex > 0) { return true; }
            if (NUP_SuperForme1.Value > 0) { return true; }
            if (NUP_SuperMin1.Value > 0) { return true; }
            if (NUP_SuperMax1.Value > 0) { return true; }
            if (CB_Super2.SelectedIndex > 0) { return true; }
            if (NUP_SuperForme2.Value > 0) { return true; }
            if (NUP_SuperMin2.Value > 0) { return true; }
            if (NUP_SuperMax2.Value > 0) { return true; }
            if (CB_Super3.SelectedIndex > 0) { return true; }
            if (NUP_SuperForme3.Value > 0) { return true; }
            if (NUP_SuperMin3.Value > 0) { return true; }
            if (NUP_SuperMax3.Value > 0) { return true; }
            if (CB_HordeA1.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme1.Value > 0) { return true; }
            if (NUP_HordeAMin1.Value > 0) { return true; }
            if (NUP_HordeAMax1.Value > 0) { return true; }
            if (CB_HordeA2.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme2.Value > 0) { return true; }
            if (NUP_HordeAMin2.Value > 0) { return true; }
            if (NUP_HordeAMax2.Value > 0) { return true; }
            if (CB_HordeA3.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme3.Value > 0) { return true; }
            if (NUP_HordeAMin3.Value > 0) { return true; }
            if (NUP_HordeAMax3.Value > 0) { return true; }
            if (CB_HordeA4.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme4.Value > 0) { return true; }
            if (NUP_HordeAMin4.Value > 0) { return true; }
            if (NUP_HordeAMax4.Value > 0) { return true; }
            if (CB_HordeA5.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme5.Value > 0) { return true; }
            if (NUP_HordeAMin5.Value > 0) { return true; }
            if (NUP_HordeAMax5.Value > 0) { return true; }
            if (CB_HordeB1.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme1.Value > 0) { return true; }
            if (NUP_HordeBMin1.Value > 0) { return true; }
            if (NUP_HordeBMax1.Value > 0) { return true; }
            if (CB_HordeB2.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme2.Value > 0) { return true; }
            if (NUP_HordeBMin2.Value > 0) { return true; }
            if (NUP_HordeBMax2.Value > 0) { return true; }
            if (CB_HordeB3.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme3.Value > 0) { return true; }
            if (NUP_HordeBMin3.Value > 0) { return true; }
            if (NUP_HordeBMax3.Value > 0) { return true; }
            if (CB_HordeB4.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme4.Value > 0) { return true; }
            if (NUP_HordeBMin4.Value > 0) { return true; }
            if (NUP_HordeBMax4.Value > 0) { return true; }
            if (CB_HordeB5.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme5.Value > 0) { return true; }
            if (NUP_HordeBMin5.Value > 0) { return true; }
            if (NUP_HordeBMax5.Value > 0) { return true; }
            if (CB_HordeC1.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme1.Value > 0) { return true; }
            if (NUP_HordeCMin1.Value > 0) { return true; }
            if (NUP_HordeCMax1.Value > 0) { return true; }
            if (CB_HordeC2.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme2.Value > 0) { return true; }
            if (NUP_HordeCMin2.Value > 0) { return true; }
            if (NUP_HordeCMax2.Value > 0) { return true; }
            if (CB_HordeC3.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme3.Value > 0) { return true; }
            if (NUP_HordeCMin3.Value > 0) { return true; }
            if (NUP_HordeCMax3.Value > 0) { return true; }
            if (CB_HordeC4.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme4.Value > 0) { return true; }
            if (NUP_HordeCMin4.Value > 0) { return true; }
            if (NUP_HordeCMax4.Value > 0) { return true; }
            if (CB_HordeC5.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme5.Value > 0) { return true; }
            if (NUP_HordeCMin5.Value > 0) { return true; }
            if (NUP_HordeCMax5.Value > 0) { return true; }
#endregion
            return false;
        }

        private void parse(byte[] ed)
        {
            // 12,12,12,12,12
            // 5,5
            // 3,3,3
            // 5,5,5,
            byte[] slot = new Byte[4];
            int[] data = new int[4];
            int offset = 0;
            #region ReadData
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass1.SelectedIndex = data[0];
            NUP_GrassForme1.Value = data[1];
            NUP_GrassMin1.Value = data[2];
            NUP_GrassMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass2.SelectedIndex = data[0];
            NUP_GrassForme2.Value = data[1];
            NUP_GrassMin2.Value = data[2];
            NUP_GrassMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass3.SelectedIndex = data[0];
            NUP_GrassForme3.Value = data[1];
            NUP_GrassMin3.Value = data[2];
            NUP_GrassMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass4.SelectedIndex = data[0];
            NUP_GrassForme4.Value = data[1];
            NUP_GrassMin4.Value = data[2];
            NUP_GrassMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass5.SelectedIndex = data[0];
            NUP_GrassForme5.Value = data[1];
            NUP_GrassMin5.Value = data[2];
            NUP_GrassMax5.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass6.SelectedIndex = data[0];
            NUP_GrassForme6.Value = data[1];
            NUP_GrassMin6.Value = data[2];
            NUP_GrassMax6.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass7.SelectedIndex = data[0];
            NUP_GrassForme7.Value = data[1];
            NUP_GrassMin7.Value = data[2];
            NUP_GrassMax7.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass8.SelectedIndex = data[0];
            NUP_GrassForme8.Value = data[1];
            NUP_GrassMin8.Value = data[2];
            NUP_GrassMax8.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass9.SelectedIndex = data[0];
            NUP_GrassForme9.Value = data[1];
            NUP_GrassMin9.Value = data[2];
            NUP_GrassMax9.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass10.SelectedIndex = data[0];
            NUP_GrassForme10.Value = data[1];
            NUP_GrassMin10.Value = data[2];
            NUP_GrassMax10.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass11.SelectedIndex = data[0];
            NUP_GrassForme11.Value = data[1];
            NUP_GrassMin11.Value = data[2];
            NUP_GrassMax11.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Grass12.SelectedIndex = data[0];
            NUP_GrassForme12.Value = data[1];
            NUP_GrassMin12.Value = data[2];
            NUP_GrassMax12.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow1.SelectedIndex = data[0];
            NUP_YellowForme1.Value = data[1];
            NUP_YellowMin1.Value = data[2];
            NUP_YellowMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow2.SelectedIndex = data[0];
            NUP_YellowForme2.Value = data[1];
            NUP_YellowMin2.Value = data[2];
            NUP_YellowMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow3.SelectedIndex = data[0];
            NUP_YellowForme3.Value = data[1];
            NUP_YellowMin3.Value = data[2];
            NUP_YellowMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow4.SelectedIndex = data[0];
            NUP_YellowForme4.Value = data[1];
            NUP_YellowMin4.Value = data[2];
            NUP_YellowMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow5.SelectedIndex = data[0];
            NUP_YellowForme5.Value = data[1];
            NUP_YellowMin5.Value = data[2];
            NUP_YellowMax5.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow6.SelectedIndex = data[0];
            NUP_YellowForme6.Value = data[1];
            NUP_YellowMin6.Value = data[2];
            NUP_YellowMax6.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow7.SelectedIndex = data[0];
            NUP_YellowForme7.Value = data[1];
            NUP_YellowMin7.Value = data[2];
            NUP_YellowMax7.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow8.SelectedIndex = data[0];
            NUP_YellowForme8.Value = data[1];
            NUP_YellowMin8.Value = data[2];
            NUP_YellowMax8.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow9.SelectedIndex = data[0];
            NUP_YellowForme9.Value = data[1];
            NUP_YellowMin9.Value = data[2];
            NUP_YellowMax9.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow10.SelectedIndex = data[0];
            NUP_YellowForme10.Value = data[1];
            NUP_YellowMin10.Value = data[2];
            NUP_YellowMax10.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow11.SelectedIndex = data[0];
            NUP_YellowForme11.Value = data[1];
            NUP_YellowMin11.Value = data[2];
            NUP_YellowMax11.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Yellow12.SelectedIndex = data[0];
            NUP_YellowForme12.Value = data[1];
            NUP_YellowMin12.Value = data[2];
            NUP_YellowMax12.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple1.SelectedIndex = data[0];
            NUP_PurpleForme1.Value = data[1];
            NUP_PurpleMin1.Value = data[2];
            NUP_PurpleMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple2.SelectedIndex = data[0];
            NUP_PurpleForme2.Value = data[1];
            NUP_PurpleMin2.Value = data[2];
            NUP_PurpleMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple3.SelectedIndex = data[0];
            NUP_PurpleForme3.Value = data[1];
            NUP_PurpleMin3.Value = data[2];
            NUP_PurpleMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple4.SelectedIndex = data[0];
            NUP_PurpleForme4.Value = data[1];
            NUP_PurpleMin4.Value = data[2];
            NUP_PurpleMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple5.SelectedIndex = data[0];
            NUP_PurpleForme5.Value = data[1];
            NUP_PurpleMin5.Value = data[2];
            NUP_PurpleMax5.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple6.SelectedIndex = data[0];
            NUP_PurpleForme6.Value = data[1];
            NUP_PurpleMin6.Value = data[2];
            NUP_PurpleMax6.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple7.SelectedIndex = data[0];
            NUP_PurpleForme7.Value = data[1];
            NUP_PurpleMin7.Value = data[2];
            NUP_PurpleMax7.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple8.SelectedIndex = data[0];
            NUP_PurpleForme8.Value = data[1];
            NUP_PurpleMin8.Value = data[2];
            NUP_PurpleMax8.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple9.SelectedIndex = data[0];
            NUP_PurpleForme9.Value = data[1];
            NUP_PurpleMin9.Value = data[2];
            NUP_PurpleMax9.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple10.SelectedIndex = data[0];
            NUP_PurpleForme10.Value = data[1];
            NUP_PurpleMin10.Value = data[2];
            NUP_PurpleMax10.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple11.SelectedIndex = data[0];
            NUP_PurpleForme11.Value = data[1];
            NUP_PurpleMin11.Value = data[2];
            NUP_PurpleMax11.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Purple12.SelectedIndex = data[0];
            NUP_PurpleForme12.Value = data[1];
            NUP_PurpleMin12.Value = data[2];
            NUP_PurpleMax12.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red1.SelectedIndex = data[0];
            NUP_RedForme1.Value = data[1];
            NUP_RedMin1.Value = data[2];
            NUP_RedMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red2.SelectedIndex = data[0];
            NUP_RedForme2.Value = data[1];
            NUP_RedMin2.Value = data[2];
            NUP_RedMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red3.SelectedIndex = data[0];
            NUP_RedForme3.Value = data[1];
            NUP_RedMin3.Value = data[2];
            NUP_RedMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red4.SelectedIndex = data[0];
            NUP_RedForme4.Value = data[1];
            NUP_RedMin4.Value = data[2];
            NUP_RedMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red5.SelectedIndex = data[0];
            NUP_RedForme5.Value = data[1];
            NUP_RedMin5.Value = data[2];
            NUP_RedMax5.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red6.SelectedIndex = data[0];
            NUP_RedForme6.Value = data[1];
            NUP_RedMin6.Value = data[2];
            NUP_RedMax6.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red7.SelectedIndex = data[0];
            NUP_RedForme7.Value = data[1];
            NUP_RedMin7.Value = data[2];
            NUP_RedMax7.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red8.SelectedIndex = data[0];
            NUP_RedForme8.Value = data[1];
            NUP_RedMin8.Value = data[2];
            NUP_RedMax8.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red9.SelectedIndex = data[0];
            NUP_RedForme9.Value = data[1];
            NUP_RedMin9.Value = data[2];
            NUP_RedMax9.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red10.SelectedIndex = data[0];
            NUP_RedForme10.Value = data[1];
            NUP_RedMin10.Value = data[2];
            NUP_RedMax10.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red11.SelectedIndex = data[0];
            NUP_RedForme11.Value = data[1];
            NUP_RedMin11.Value = data[2];
            NUP_RedMax11.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Red12.SelectedIndex = data[0];
            NUP_RedForme12.Value = data[1];
            NUP_RedMin12.Value = data[2];
            NUP_RedMax12.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT1.SelectedIndex = data[0];
            NUP_RTForme1.Value = data[1];
            NUP_RTMin1.Value = data[2];
            NUP_RTMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT2.SelectedIndex = data[0];
            NUP_RTForme2.Value = data[1];
            NUP_RTMin2.Value = data[2];
            NUP_RTMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT3.SelectedIndex = data[0];
            NUP_RTForme3.Value = data[1];
            NUP_RTMin3.Value = data[2];
            NUP_RTMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT4.SelectedIndex = data[0];
            NUP_RTForme4.Value = data[1];
            NUP_RTMin4.Value = data[2];
            NUP_RTMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT5.SelectedIndex = data[0];
            NUP_RTForme5.Value = data[1];
            NUP_RTMin5.Value = data[2];
            NUP_RTMax5.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT6.SelectedIndex = data[0];
            NUP_RTForme6.Value = data[1];
            NUP_RTMin6.Value = data[2];
            NUP_RTMax6.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT7.SelectedIndex = data[0];
            NUP_RTForme7.Value = data[1];
            NUP_RTMin7.Value = data[2];
            NUP_RTMax7.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT8.SelectedIndex = data[0];
            NUP_RTForme8.Value = data[1];
            NUP_RTMin8.Value = data[2];
            NUP_RTMax8.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT9.SelectedIndex = data[0];
            NUP_RTForme9.Value = data[1];
            NUP_RTMin9.Value = data[2];
            NUP_RTMax9.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT10.SelectedIndex = data[0];
            NUP_RTForme10.Value = data[1];
            NUP_RTMin10.Value = data[2];
            NUP_RTMax10.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT11.SelectedIndex = data[0];
            NUP_RTForme11.Value = data[1];
            NUP_RTMin11.Value = data[2];
            NUP_RTMax11.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RT12.SelectedIndex = data[0];
            NUP_RTForme12.Value = data[1];
            NUP_RTMin12.Value = data[2];
            NUP_RTMax12.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Surf1.SelectedIndex = data[0];
            NUP_SurfForme1.Value = data[1];
            NUP_SurfMin1.Value = data[2];
            NUP_SurfMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Surf2.SelectedIndex = data[0];
            NUP_SurfForme2.Value = data[1];
            NUP_SurfMin2.Value = data[2];
            NUP_SurfMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Surf3.SelectedIndex = data[0];
            NUP_SurfForme3.Value = data[1];
            NUP_SurfMin3.Value = data[2];
            NUP_SurfMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Surf4.SelectedIndex = data[0];
            NUP_SurfForme4.Value = data[1];
            NUP_SurfMin4.Value = data[2];
            NUP_SurfMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Surf5.SelectedIndex = data[0];
            NUP_SurfForme5.Value = data[1];
            NUP_SurfMin5.Value = data[2];
            NUP_SurfMax5.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RockSmash1.SelectedIndex = data[0];
            NUP_RockSmashForme1.Value = data[1];
            NUP_RockSmashMin1.Value = data[2];
            NUP_RockSmashMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RockSmash2.SelectedIndex = data[0];
            NUP_RockSmashForme2.Value = data[1];
            NUP_RockSmashMin2.Value = data[2];
            NUP_RockSmashMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RockSmash3.SelectedIndex = data[0];
            NUP_RockSmashForme3.Value = data[1];
            NUP_RockSmashMin3.Value = data[2];
            NUP_RockSmashMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RockSmash4.SelectedIndex = data[0];
            NUP_RockSmashForme4.Value = data[1];
            NUP_RockSmashMin4.Value = data[2];
            NUP_RockSmashMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_RockSmash5.SelectedIndex = data[0];
            NUP_RockSmashForme5.Value = data[1];
            NUP_RockSmashMin5.Value = data[2];
            NUP_RockSmashMax5.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Old1.SelectedIndex = data[0];
            NUP_OldForme1.Value = data[1];
            NUP_OldMin1.Value = data[2];
            NUP_OldMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Old2.SelectedIndex = data[0];
            NUP_OldForme2.Value = data[1];
            NUP_OldMin2.Value = data[2];
            NUP_OldMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Old3.SelectedIndex = data[0];
            NUP_OldForme3.Value = data[1];
            NUP_OldMin3.Value = data[2];
            NUP_OldMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Good1.SelectedIndex = data[0];
            NUP_GoodForme1.Value = data[1];
            NUP_GoodMin1.Value = data[2];
            NUP_GoodMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Good2.SelectedIndex = data[0];
            NUP_GoodForme2.Value = data[1];
            NUP_GoodMin2.Value = data[2];
            NUP_GoodMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Good3.SelectedIndex = data[0];
            NUP_GoodForme3.Value = data[1];
            NUP_GoodMin3.Value = data[2];
            NUP_GoodMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Super1.SelectedIndex = data[0];
            NUP_SuperForme1.Value = data[1];
            NUP_SuperMin1.Value = data[2];
            NUP_SuperMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Super2.SelectedIndex = data[0];
            NUP_SuperForme2.Value = data[1];
            NUP_SuperMin2.Value = data[2];
            NUP_SuperMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_Super3.SelectedIndex = data[0];
            NUP_SuperForme3.Value = data[1];
            NUP_SuperMin3.Value = data[2];
            NUP_SuperMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeA1.SelectedIndex = data[0];
            NUP_HordeAForme1.Value = data[1];
            NUP_HordeAMin1.Value = data[2];
            NUP_HordeAMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeA2.SelectedIndex = data[0];
            NUP_HordeAForme2.Value = data[1];
            NUP_HordeAMin2.Value = data[2];
            NUP_HordeAMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeA3.SelectedIndex = data[0];
            NUP_HordeAForme3.Value = data[1];
            NUP_HordeAMin3.Value = data[2];
            NUP_HordeAMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeA4.SelectedIndex = data[0];
            NUP_HordeAForme4.Value = data[1];
            NUP_HordeAMin4.Value = data[2];
            NUP_HordeAMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeA5.SelectedIndex = data[0];
            NUP_HordeAForme5.Value = data[1];
            NUP_HordeAMin5.Value = data[2];
            NUP_HordeAMax5.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeB1.SelectedIndex = data[0];
            NUP_HordeBForme1.Value = data[1];
            NUP_HordeBMin1.Value = data[2];
            NUP_HordeBMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeB2.SelectedIndex = data[0];
            NUP_HordeBForme2.Value = data[1];
            NUP_HordeBMin2.Value = data[2];
            NUP_HordeBMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeB3.SelectedIndex = data[0];
            NUP_HordeBForme3.Value = data[1];
            NUP_HordeBMin3.Value = data[2];
            NUP_HordeBMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeB4.SelectedIndex = data[0];
            NUP_HordeBForme4.Value = data[1];
            NUP_HordeBMin4.Value = data[2];
            NUP_HordeBMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeB5.SelectedIndex = data[0];
            NUP_HordeBForme5.Value = data[1];
            NUP_HordeBMin5.Value = data[2];
            NUP_HordeBMax5.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeC1.SelectedIndex = data[0];
            NUP_HordeCForme1.Value = data[1];
            NUP_HordeCMin1.Value = data[2];
            NUP_HordeCMax1.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeC2.SelectedIndex = data[0];
            NUP_HordeCForme2.Value = data[1];
            NUP_HordeCMin2.Value = data[2];
            NUP_HordeCMax2.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeC3.SelectedIndex = data[0];
            NUP_HordeCForme3.Value = data[1];
            NUP_HordeCMin3.Value = data[2];
            NUP_HordeCMax3.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeC4.SelectedIndex = data[0];
            NUP_HordeCForme4.Value = data[1];
            NUP_HordeCMin4.Value = data[2];
            NUP_HordeCMax4.Value = data[3];
            offset += 4;
            Array.Copy(ed, offset, slot, 0, 4);
            data = pslot(slot);
            CB_HordeC5.SelectedIndex = data[0];
            NUP_HordeCForme5.Value = data[1];
            NUP_HordeCMin5.Value = data[2];
            NUP_HordeCMax5.Value = data[3];
            offset += 4;
#endregion
        }

        private int[] pslot(byte[] slot)
        {
            int index = BitConverter.ToUInt16(slot, 0) & 0x7FF;
            int form = BitConverter.ToUInt16(slot, 0) >> 11;
            int min = slot[2];
            int max = slot[3];
            int[] data = new int[4];
            data[0] = index;
            data[1] = form;
            data[2] = min;
            data[3] = max;
            return data;
        }

        private string parseslot(byte[] slot)
        {
            int index = BitConverter.ToUInt16(slot, 0) & 0x7FF;
            if (index == 0) return "";
            int form = BitConverter.ToUInt16(slot, 0) >> 11;
            int min = slot[2];
            int max = slot[3];
            string species = specieslist[index];
            if (form > 0) species += "-"+form.ToString();
            return species + ',' + min + ',' + max + ',';
        }



        private void CB_LocationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int f = CB_LocationID.SelectedIndex;
            FileStream InStream = File.OpenRead(filepaths[f]);
            BinaryReader br = new BinaryReader(InStream);
            br.BaseStream.Seek(0x10, SeekOrigin.Begin);
            int offset = br.ReadInt32() + 0x10;
            int length = (int)br.BaseStream.Length - offset;
            if (length < 0x178) //no encounters in this map
            {
                ClearData();
                return;
            }
            br.Close();

            byte[] filedata = File.ReadAllBytes(filepaths[f]);

            byte[] encounterdata = new Byte[0x178];
            Array.Copy(filedata, offset, encounterdata, 0, 0x178);
            parse(encounterdata);
        }

        private void ClearData()
        {
            #region Clear Data
            CB_Grass1.SelectedIndex = 0;
            NUP_GrassForme1.Value = 0;
            NUP_GrassMin1.Value = 0;
            NUP_GrassMax1.Value = 0;
            CB_Grass2.SelectedIndex = 0;
            NUP_GrassForme2.Value = 0;
            NUP_GrassMin2.Value = 0;
            NUP_GrassMax2.Value = 0;
            CB_Grass3.SelectedIndex = 0;
            NUP_GrassForme3.Value = 0;
            NUP_GrassMin3.Value = 0;
            NUP_GrassMax3.Value = 0;
            CB_Grass4.SelectedIndex = 0;
            NUP_GrassForme4.Value = 0;
            NUP_GrassMin4.Value = 0;
            NUP_GrassMax4.Value = 0;
            CB_Grass5.SelectedIndex = 0;
            NUP_GrassForme5.Value = 0;
            NUP_GrassMin5.Value = 0;
            NUP_GrassMax5.Value = 0;
            CB_Grass6.SelectedIndex = 0;
            NUP_GrassForme6.Value = 0;
            NUP_GrassMin6.Value = 0;
            NUP_GrassMax6.Value = 0;
            CB_Grass7.SelectedIndex = 0;
            NUP_GrassForme7.Value = 0;
            NUP_GrassMin7.Value = 0;
            NUP_GrassMax7.Value = 0;
            CB_Grass8.SelectedIndex = 0;
            NUP_GrassForme8.Value = 0;
            NUP_GrassMin8.Value = 0;
            NUP_GrassMax8.Value = 0;
            CB_Grass9.SelectedIndex = 0;
            NUP_GrassForme9.Value = 0;
            NUP_GrassMin9.Value = 0;
            NUP_GrassMax9.Value = 0;
            CB_Grass10.SelectedIndex = 0;
            NUP_GrassForme10.Value = 0;
            NUP_GrassMin10.Value = 0;
            NUP_GrassMax10.Value = 0;
            CB_Grass11.SelectedIndex = 0;
            NUP_GrassForme11.Value = 0;
            NUP_GrassMin11.Value = 0;
            NUP_GrassMax11.Value = 0;
            CB_Grass12.SelectedIndex = 0;
            NUP_GrassForme12.Value = 0;
            NUP_GrassMin12.Value = 0;
            NUP_GrassMax12.Value = 0;
            CB_Yellow1.SelectedIndex = 0;
            NUP_YellowForme1.Value = 0;
            NUP_YellowMin1.Value = 0;
            NUP_YellowMax1.Value = 0;
            CB_Yellow2.SelectedIndex = 0;
            NUP_YellowForme2.Value = 0;
            NUP_YellowMin2.Value = 0;
            NUP_YellowMax2.Value = 0;
            CB_Yellow3.SelectedIndex = 0;
            NUP_YellowForme3.Value = 0;
            NUP_YellowMin3.Value = 0;
            NUP_YellowMax3.Value = 0;
            CB_Yellow4.SelectedIndex = 0;
            NUP_YellowForme4.Value = 0;
            NUP_YellowMin4.Value = 0;
            NUP_YellowMax4.Value = 0;
            CB_Yellow5.SelectedIndex = 0;
            NUP_YellowForme5.Value = 0;
            NUP_YellowMin5.Value = 0;
            NUP_YellowMax5.Value = 0;
            CB_Yellow6.SelectedIndex = 0;
            NUP_YellowForme6.Value = 0;
            NUP_YellowMin6.Value = 0;
            NUP_YellowMax6.Value = 0;
            CB_Yellow7.SelectedIndex = 0;
            NUP_YellowForme7.Value = 0;
            NUP_YellowMin7.Value = 0;
            NUP_YellowMax7.Value = 0;
            CB_Yellow8.SelectedIndex = 0;
            NUP_YellowForme8.Value = 0;
            NUP_YellowMin8.Value = 0;
            NUP_YellowMax8.Value = 0;
            CB_Yellow9.SelectedIndex = 0;
            NUP_YellowForme9.Value = 0;
            NUP_YellowMin9.Value = 0;
            NUP_YellowMax9.Value = 0;
            CB_Yellow10.SelectedIndex = 0;
            NUP_YellowForme10.Value = 0;
            NUP_YellowMin10.Value = 0;
            NUP_YellowMax10.Value = 0;
            CB_Yellow11.SelectedIndex = 0;
            NUP_YellowForme11.Value = 0;
            NUP_YellowMin11.Value = 0;
            NUP_YellowMax11.Value = 0;
            CB_Yellow12.SelectedIndex = 0;
            NUP_YellowForme12.Value = 0;
            NUP_YellowMin12.Value = 0;
            NUP_YellowMax12.Value = 0;
            CB_Purple1.SelectedIndex = 0;
            NUP_PurpleForme1.Value = 0;
            NUP_PurpleMin1.Value = 0;
            NUP_PurpleMax1.Value = 0;
            CB_Purple2.SelectedIndex = 0;
            NUP_PurpleForme2.Value = 0;
            NUP_PurpleMin2.Value = 0;
            NUP_PurpleMax2.Value = 0;
            CB_Purple3.SelectedIndex = 0;
            NUP_PurpleForme3.Value = 0;
            NUP_PurpleMin3.Value = 0;
            NUP_PurpleMax3.Value = 0;
            CB_Purple4.SelectedIndex = 0;
            NUP_PurpleForme4.Value = 0;
            NUP_PurpleMin4.Value = 0;
            NUP_PurpleMax4.Value = 0;
            CB_Purple5.SelectedIndex = 0;
            NUP_PurpleForme5.Value = 0;
            NUP_PurpleMin5.Value = 0;
            NUP_PurpleMax5.Value = 0;
            CB_Purple6.SelectedIndex = 0;
            NUP_PurpleForme6.Value = 0;
            NUP_PurpleMin6.Value = 0;
            NUP_PurpleMax6.Value = 0;
            CB_Purple7.SelectedIndex = 0;
            NUP_PurpleForme7.Value = 0;
            NUP_PurpleMin7.Value = 0;
            NUP_PurpleMax7.Value = 0;
            CB_Purple8.SelectedIndex = 0;
            NUP_PurpleForme8.Value = 0;
            NUP_PurpleMin8.Value = 0;
            NUP_PurpleMax8.Value = 0;
            CB_Purple9.SelectedIndex = 0;
            NUP_PurpleForme9.Value = 0;
            NUP_PurpleMin9.Value = 0;
            NUP_PurpleMax9.Value = 0;
            CB_Purple10.SelectedIndex = 0;
            NUP_PurpleForme10.Value = 0;
            NUP_PurpleMin10.Value = 0;
            NUP_PurpleMax10.Value = 0;
            CB_Purple11.SelectedIndex = 0;
            NUP_PurpleForme11.Value = 0;
            NUP_PurpleMin11.Value = 0;
            NUP_PurpleMax11.Value = 0;
            CB_Purple12.SelectedIndex = 0;
            NUP_PurpleForme12.Value = 0;
            NUP_PurpleMin12.Value = 0;
            NUP_PurpleMax12.Value = 0;
            CB_Red1.SelectedIndex = 0;
            NUP_RedForme1.Value = 0;
            NUP_RedMin1.Value = 0;
            NUP_RedMax1.Value = 0;
            CB_Red2.SelectedIndex = 0;
            NUP_RedForme2.Value = 0;
            NUP_RedMin2.Value = 0;
            NUP_RedMax2.Value = 0;
            CB_Red3.SelectedIndex = 0;
            NUP_RedForme3.Value = 0;
            NUP_RedMin3.Value = 0;
            NUP_RedMax3.Value = 0;
            CB_Red4.SelectedIndex = 0;
            NUP_RedForme4.Value = 0;
            NUP_RedMin4.Value = 0;
            NUP_RedMax4.Value = 0;
            CB_Red5.SelectedIndex = 0;
            NUP_RedForme5.Value = 0;
            NUP_RedMin5.Value = 0;
            NUP_RedMax5.Value = 0;
            CB_Red6.SelectedIndex = 0;
            NUP_RedForme6.Value = 0;
            NUP_RedMin6.Value = 0;
            NUP_RedMax6.Value = 0;
            CB_Red7.SelectedIndex = 0;
            NUP_RedForme7.Value = 0;
            NUP_RedMin7.Value = 0;
            NUP_RedMax7.Value = 0;
            CB_Red8.SelectedIndex = 0;
            NUP_RedForme8.Value = 0;
            NUP_RedMin8.Value = 0;
            NUP_RedMax8.Value = 0;
            CB_Red9.SelectedIndex = 0;
            NUP_RedForme9.Value = 0;
            NUP_RedMin9.Value = 0;
            NUP_RedMax9.Value = 0;
            CB_Red10.SelectedIndex = 0;
            NUP_RedForme10.Value = 0;
            NUP_RedMin10.Value = 0;
            NUP_RedMax10.Value = 0;
            CB_Red11.SelectedIndex = 0;
            NUP_RedForme11.Value = 0;
            NUP_RedMin11.Value = 0;
            NUP_RedMax11.Value = 0;
            CB_Red12.SelectedIndex = 0;
            NUP_RedForme12.Value = 0;
            NUP_RedMin12.Value = 0;
            NUP_RedMax12.Value = 0;
            CB_RT1.SelectedIndex = 0;
            NUP_RTForme1.Value = 0;
            NUP_RTMin1.Value = 0;
            NUP_RTMax1.Value = 0;
            CB_RT2.SelectedIndex = 0;
            NUP_RTForme2.Value = 0;
            NUP_RTMin2.Value = 0;
            NUP_RTMax2.Value = 0;
            CB_RT3.SelectedIndex = 0;
            NUP_RTForme3.Value = 0;
            NUP_RTMin3.Value = 0;
            NUP_RTMax3.Value = 0;
            CB_RT4.SelectedIndex = 0;
            NUP_RTForme4.Value = 0;
            NUP_RTMin4.Value = 0;
            NUP_RTMax4.Value = 0;
            CB_RT5.SelectedIndex = 0;
            NUP_RTForme5.Value = 0;
            NUP_RTMin5.Value = 0;
            NUP_RTMax5.Value = 0;
            CB_RT6.SelectedIndex = 0;
            NUP_RTForme6.Value = 0;
            NUP_RTMin6.Value = 0;
            NUP_RTMax6.Value = 0;
            CB_RT7.SelectedIndex = 0;
            NUP_RTForme7.Value = 0;
            NUP_RTMin7.Value = 0;
            NUP_RTMax7.Value = 0;
            CB_RT8.SelectedIndex = 0;
            NUP_RTForme8.Value = 0;
            NUP_RTMin8.Value = 0;
            NUP_RTMax8.Value = 0;
            CB_RT9.SelectedIndex = 0;
            NUP_RTForme9.Value = 0;
            NUP_RTMin9.Value = 0;
            NUP_RTMax9.Value = 0;
            CB_RT10.SelectedIndex = 0;
            NUP_RTForme10.Value = 0;
            NUP_RTMin10.Value = 0;
            NUP_RTMax10.Value = 0;
            CB_RT11.SelectedIndex = 0;
            NUP_RTForme11.Value = 0;
            NUP_RTMin11.Value = 0;
            NUP_RTMax11.Value = 0;
            CB_RT12.SelectedIndex = 0;
            NUP_RTForme12.Value = 0;
            NUP_RTMin12.Value = 0;
            NUP_RTMax12.Value = 0;
            CB_Surf1.SelectedIndex = 0;
            NUP_SurfForme1.Value = 0;
            NUP_SurfMin1.Value = 0;
            NUP_SurfMax1.Value = 0;
            CB_Surf2.SelectedIndex = 0;
            NUP_SurfForme2.Value = 0;
            NUP_SurfMin2.Value = 0;
            NUP_SurfMax2.Value = 0;
            CB_Surf3.SelectedIndex = 0;
            NUP_SurfForme3.Value = 0;
            NUP_SurfMin3.Value = 0;
            NUP_SurfMax3.Value = 0;
            CB_Surf4.SelectedIndex = 0;
            NUP_SurfForme4.Value = 0;
            NUP_SurfMin4.Value = 0;
            NUP_SurfMax4.Value = 0;
            CB_Surf5.SelectedIndex = 0;
            NUP_SurfForme5.Value = 0;
            NUP_SurfMin5.Value = 0;
            NUP_SurfMax5.Value = 0;
            CB_RockSmash1.SelectedIndex = 0;
            NUP_RockSmashForme1.Value = 0;
            NUP_RockSmashMin1.Value = 0;
            NUP_RockSmashMax1.Value = 0;
            CB_RockSmash2.SelectedIndex = 0;
            NUP_RockSmashForme2.Value = 0;
            NUP_RockSmashMin2.Value = 0;
            NUP_RockSmashMax2.Value = 0;
            CB_RockSmash3.SelectedIndex = 0;
            NUP_RockSmashForme3.Value = 0;
            NUP_RockSmashMin3.Value = 0;
            NUP_RockSmashMax3.Value = 0;
            CB_RockSmash4.SelectedIndex = 0;
            NUP_RockSmashForme4.Value = 0;
            NUP_RockSmashMin4.Value = 0;
            NUP_RockSmashMax4.Value = 0;
            CB_RockSmash5.SelectedIndex = 0;
            NUP_RockSmashForme5.Value = 0;
            NUP_RockSmashMin5.Value = 0;
            NUP_RockSmashMax5.Value = 0;
            CB_Old1.SelectedIndex = 0;
            NUP_OldForme1.Value = 0;
            NUP_OldMin1.Value = 0;
            NUP_OldMax1.Value = 0;
            CB_Old2.SelectedIndex = 0;
            NUP_OldForme2.Value = 0;
            NUP_OldMin2.Value = 0;
            NUP_OldMax2.Value = 0;
            CB_Old3.SelectedIndex = 0;
            NUP_OldForme3.Value = 0;
            NUP_OldMin3.Value = 0;
            NUP_OldMax3.Value = 0;
            CB_Good1.SelectedIndex = 0;
            NUP_GoodForme1.Value = 0;
            NUP_GoodMin1.Value = 0;
            NUP_GoodMax1.Value = 0;
            CB_Good2.SelectedIndex = 0;
            NUP_GoodForme2.Value = 0;
            NUP_GoodMin2.Value = 0;
            NUP_GoodMax2.Value = 0;
            CB_Good3.SelectedIndex = 0;
            NUP_GoodForme3.Value = 0;
            NUP_GoodMin3.Value = 0;
            NUP_GoodMax3.Value = 0;
            CB_Super1.SelectedIndex = 0;
            NUP_SuperForme1.Value = 0;
            NUP_SuperMin1.Value = 0;
            NUP_SuperMax1.Value = 0;
            CB_Super2.SelectedIndex = 0;
            NUP_SuperForme2.Value = 0;
            NUP_SuperMin2.Value = 0;
            NUP_SuperMax2.Value = 0;
            CB_Super3.SelectedIndex = 0;
            NUP_SuperForme3.Value = 0;
            NUP_SuperMin3.Value = 0;
            NUP_SuperMax3.Value = 0;
            CB_HordeA1.SelectedIndex = 0;
            NUP_HordeAForme1.Value = 0;
            NUP_HordeAMin1.Value = 0;
            NUP_HordeAMax1.Value = 0;
            CB_HordeA2.SelectedIndex = 0;
            NUP_HordeAForme2.Value = 0;
            NUP_HordeAMin2.Value = 0;
            NUP_HordeAMax2.Value = 0;
            CB_HordeA3.SelectedIndex = 0;
            NUP_HordeAForme3.Value = 0;
            NUP_HordeAMin3.Value = 0;
            NUP_HordeAMax3.Value = 0;
            CB_HordeA4.SelectedIndex = 0;
            NUP_HordeAForme4.Value = 0;
            NUP_HordeAMin4.Value = 0;
            NUP_HordeAMax4.Value = 0;
            CB_HordeA5.SelectedIndex = 0;
            NUP_HordeAForme5.Value = 0;
            NUP_HordeAMin5.Value = 0;
            NUP_HordeAMax5.Value = 0;
            CB_HordeB1.SelectedIndex = 0;
            NUP_HordeBForme1.Value = 0;
            NUP_HordeBMin1.Value = 0;
            NUP_HordeBMax1.Value = 0;
            CB_HordeB2.SelectedIndex = 0;
            NUP_HordeBForme2.Value = 0;
            NUP_HordeBMin2.Value = 0;
            NUP_HordeBMax2.Value = 0;
            CB_HordeB3.SelectedIndex = 0;
            NUP_HordeBForme3.Value = 0;
            NUP_HordeBMin3.Value = 0;
            NUP_HordeBMax3.Value = 0;
            CB_HordeB4.SelectedIndex = 0;
            NUP_HordeBForme4.Value = 0;
            NUP_HordeBMin4.Value = 0;
            NUP_HordeBMax4.Value = 0;
            CB_HordeB5.SelectedIndex = 0;
            NUP_HordeBForme5.Value = 0;
            NUP_HordeBMin5.Value = 0;
            NUP_HordeBMax5.Value = 0;
            CB_HordeC1.SelectedIndex = 0;
            NUP_HordeCForme1.Value = 0;
            NUP_HordeCMin1.Value = 0;
            NUP_HordeCMax1.Value = 0;
            CB_HordeC2.SelectedIndex = 0;
            NUP_HordeCForme2.Value = 0;
            NUP_HordeCMin2.Value = 0;
            NUP_HordeCMax2.Value = 0;
            CB_HordeC3.SelectedIndex = 0;
            NUP_HordeCForme3.Value = 0;
            NUP_HordeCMin3.Value = 0;
            NUP_HordeCMax3.Value = 0;
            CB_HordeC4.SelectedIndex = 0;
            NUP_HordeCForme4.Value = 0;
            NUP_HordeCMin4.Value = 0;
            NUP_HordeCMax4.Value = 0;
            CB_HordeC5.SelectedIndex = 0;
            NUP_HordeCForme5.Value = 0;
            NUP_HordeCMin5.Value = 0;
            NUP_HordeCMax5.Value = 0;

            #endregion
        }

        private byte[] MakeSlotData(int species, int form, int min, int max)
        {
            byte[] data = new byte[4];
            Array.Copy(BitConverter.GetBytes(Convert.ToUInt16((Convert.ToUInt16(form) << 11) + species)), 0, data, 0, 2);
            data[2] = (byte)min;
            data[3] = (byte)max;
            return data;
        }

        private byte[] MakeEncounterData()
        {
            byte[] ed = new byte[0x178];
            byte[] data;
            int offset = 0;
            #region MakeData
            data = MakeSlotData(CB_Grass1.SelectedIndex, (int)NUP_GrassForme1.Value, (int)NUP_GrassMin1.Value, (int)NUP_GrassMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass2.SelectedIndex, (int)NUP_GrassForme2.Value, (int)NUP_GrassMin2.Value, (int)NUP_GrassMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass3.SelectedIndex, (int)NUP_GrassForme3.Value, (int)NUP_GrassMin3.Value, (int)NUP_GrassMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass4.SelectedIndex, (int)NUP_GrassForme4.Value, (int)NUP_GrassMin4.Value, (int)NUP_GrassMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass5.SelectedIndex, (int)NUP_GrassForme5.Value, (int)NUP_GrassMin5.Value, (int)NUP_GrassMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass6.SelectedIndex, (int)NUP_GrassForme6.Value, (int)NUP_GrassMin6.Value, (int)NUP_GrassMax6.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass7.SelectedIndex, (int)NUP_GrassForme7.Value, (int)NUP_GrassMin7.Value, (int)NUP_GrassMax7.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass8.SelectedIndex, (int)NUP_GrassForme8.Value, (int)NUP_GrassMin8.Value, (int)NUP_GrassMax8.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass9.SelectedIndex, (int)NUP_GrassForme9.Value, (int)NUP_GrassMin9.Value, (int)NUP_GrassMax9.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass10.SelectedIndex, (int)NUP_GrassForme10.Value, (int)NUP_GrassMin10.Value, (int)NUP_GrassMax10.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass11.SelectedIndex, (int)NUP_GrassForme11.Value, (int)NUP_GrassMin11.Value, (int)NUP_GrassMax11.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Grass12.SelectedIndex, (int)NUP_GrassForme12.Value, (int)NUP_GrassMin12.Value, (int)NUP_GrassMax12.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow1.SelectedIndex, (int)NUP_YellowForme1.Value, (int)NUP_YellowMin1.Value, (int)NUP_YellowMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow2.SelectedIndex, (int)NUP_YellowForme2.Value, (int)NUP_YellowMin2.Value, (int)NUP_YellowMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow3.SelectedIndex, (int)NUP_YellowForme3.Value, (int)NUP_YellowMin3.Value, (int)NUP_YellowMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow4.SelectedIndex, (int)NUP_YellowForme4.Value, (int)NUP_YellowMin4.Value, (int)NUP_YellowMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow5.SelectedIndex, (int)NUP_YellowForme5.Value, (int)NUP_YellowMin5.Value, (int)NUP_YellowMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow6.SelectedIndex, (int)NUP_YellowForme6.Value, (int)NUP_YellowMin6.Value, (int)NUP_YellowMax6.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow7.SelectedIndex, (int)NUP_YellowForme7.Value, (int)NUP_YellowMin7.Value, (int)NUP_YellowMax7.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow8.SelectedIndex, (int)NUP_YellowForme8.Value, (int)NUP_YellowMin8.Value, (int)NUP_YellowMax8.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow9.SelectedIndex, (int)NUP_YellowForme9.Value, (int)NUP_YellowMin9.Value, (int)NUP_YellowMax9.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow10.SelectedIndex, (int)NUP_YellowForme10.Value, (int)NUP_YellowMin10.Value, (int)NUP_YellowMax10.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow11.SelectedIndex, (int)NUP_YellowForme11.Value, (int)NUP_YellowMin11.Value, (int)NUP_YellowMax11.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Yellow12.SelectedIndex, (int)NUP_YellowForme12.Value, (int)NUP_YellowMin12.Value, (int)NUP_YellowMax12.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple1.SelectedIndex, (int)NUP_PurpleForme1.Value, (int)NUP_PurpleMin1.Value, (int)NUP_PurpleMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple2.SelectedIndex, (int)NUP_PurpleForme2.Value, (int)NUP_PurpleMin2.Value, (int)NUP_PurpleMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple3.SelectedIndex, (int)NUP_PurpleForme3.Value, (int)NUP_PurpleMin3.Value, (int)NUP_PurpleMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple4.SelectedIndex, (int)NUP_PurpleForme4.Value, (int)NUP_PurpleMin4.Value, (int)NUP_PurpleMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple5.SelectedIndex, (int)NUP_PurpleForme5.Value, (int)NUP_PurpleMin5.Value, (int)NUP_PurpleMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple6.SelectedIndex, (int)NUP_PurpleForme6.Value, (int)NUP_PurpleMin6.Value, (int)NUP_PurpleMax6.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple7.SelectedIndex, (int)NUP_PurpleForme7.Value, (int)NUP_PurpleMin7.Value, (int)NUP_PurpleMax7.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple8.SelectedIndex, (int)NUP_PurpleForme8.Value, (int)NUP_PurpleMin8.Value, (int)NUP_PurpleMax8.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple9.SelectedIndex, (int)NUP_PurpleForme9.Value, (int)NUP_PurpleMin9.Value, (int)NUP_PurpleMax9.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple10.SelectedIndex, (int)NUP_PurpleForme10.Value, (int)NUP_PurpleMin10.Value, (int)NUP_PurpleMax10.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple11.SelectedIndex, (int)NUP_PurpleForme11.Value, (int)NUP_PurpleMin11.Value, (int)NUP_PurpleMax11.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Purple12.SelectedIndex, (int)NUP_PurpleForme12.Value, (int)NUP_PurpleMin12.Value, (int)NUP_PurpleMax12.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red1.SelectedIndex, (int)NUP_RedForme1.Value, (int)NUP_RedMin1.Value, (int)NUP_RedMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red2.SelectedIndex, (int)NUP_RedForme2.Value, (int)NUP_RedMin2.Value, (int)NUP_RedMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red3.SelectedIndex, (int)NUP_RedForme3.Value, (int)NUP_RedMin3.Value, (int)NUP_RedMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red4.SelectedIndex, (int)NUP_RedForme4.Value, (int)NUP_RedMin4.Value, (int)NUP_RedMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red5.SelectedIndex, (int)NUP_RedForme5.Value, (int)NUP_RedMin5.Value, (int)NUP_RedMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red6.SelectedIndex, (int)NUP_RedForme6.Value, (int)NUP_RedMin6.Value, (int)NUP_RedMax6.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red7.SelectedIndex, (int)NUP_RedForme7.Value, (int)NUP_RedMin7.Value, (int)NUP_RedMax7.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red8.SelectedIndex, (int)NUP_RedForme8.Value, (int)NUP_RedMin8.Value, (int)NUP_RedMax8.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red9.SelectedIndex, (int)NUP_RedForme9.Value, (int)NUP_RedMin9.Value, (int)NUP_RedMax9.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red10.SelectedIndex, (int)NUP_RedForme10.Value, (int)NUP_RedMin10.Value, (int)NUP_RedMax10.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red11.SelectedIndex, (int)NUP_RedForme11.Value, (int)NUP_RedMin11.Value, (int)NUP_RedMax11.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Red12.SelectedIndex, (int)NUP_RedForme12.Value, (int)NUP_RedMin12.Value, (int)NUP_RedMax12.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT1.SelectedIndex, (int)NUP_RTForme1.Value, (int)NUP_RTMin1.Value, (int)NUP_RTMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT2.SelectedIndex, (int)NUP_RTForme2.Value, (int)NUP_RTMin2.Value, (int)NUP_RTMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT3.SelectedIndex, (int)NUP_RTForme3.Value, (int)NUP_RTMin3.Value, (int)NUP_RTMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT4.SelectedIndex, (int)NUP_RTForme4.Value, (int)NUP_RTMin4.Value, (int)NUP_RTMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT5.SelectedIndex, (int)NUP_RTForme5.Value, (int)NUP_RTMin5.Value, (int)NUP_RTMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT6.SelectedIndex, (int)NUP_RTForme6.Value, (int)NUP_RTMin6.Value, (int)NUP_RTMax6.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT7.SelectedIndex, (int)NUP_RTForme7.Value, (int)NUP_RTMin7.Value, (int)NUP_RTMax7.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT8.SelectedIndex, (int)NUP_RTForme8.Value, (int)NUP_RTMin8.Value, (int)NUP_RTMax8.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT9.SelectedIndex, (int)NUP_RTForme9.Value, (int)NUP_RTMin9.Value, (int)NUP_RTMax9.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT10.SelectedIndex, (int)NUP_RTForme10.Value, (int)NUP_RTMin10.Value, (int)NUP_RTMax10.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT11.SelectedIndex, (int)NUP_RTForme11.Value, (int)NUP_RTMin11.Value, (int)NUP_RTMax11.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RT12.SelectedIndex, (int)NUP_RTForme12.Value, (int)NUP_RTMin12.Value, (int)NUP_RTMax12.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Surf1.SelectedIndex, (int)NUP_SurfForme1.Value, (int)NUP_SurfMin1.Value, (int)NUP_SurfMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Surf2.SelectedIndex, (int)NUP_SurfForme2.Value, (int)NUP_SurfMin2.Value, (int)NUP_SurfMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Surf3.SelectedIndex, (int)NUP_SurfForme3.Value, (int)NUP_SurfMin3.Value, (int)NUP_SurfMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Surf4.SelectedIndex, (int)NUP_SurfForme4.Value, (int)NUP_SurfMin4.Value, (int)NUP_SurfMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Surf5.SelectedIndex, (int)NUP_SurfForme5.Value, (int)NUP_SurfMin5.Value, (int)NUP_SurfMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RockSmash1.SelectedIndex, (int)NUP_RockSmashForme1.Value, (int)NUP_RockSmashMin1.Value, (int)NUP_RockSmashMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RockSmash2.SelectedIndex, (int)NUP_RockSmashForme2.Value, (int)NUP_RockSmashMin2.Value, (int)NUP_RockSmashMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RockSmash3.SelectedIndex, (int)NUP_RockSmashForme3.Value, (int)NUP_RockSmashMin3.Value, (int)NUP_RockSmashMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RockSmash4.SelectedIndex, (int)NUP_RockSmashForme4.Value, (int)NUP_RockSmashMin4.Value, (int)NUP_RockSmashMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_RockSmash5.SelectedIndex, (int)NUP_RockSmashForme5.Value, (int)NUP_RockSmashMin5.Value, (int)NUP_RockSmashMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Old1.SelectedIndex, (int)NUP_OldForme1.Value, (int)NUP_OldMin1.Value, (int)NUP_OldMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Old2.SelectedIndex, (int)NUP_OldForme2.Value, (int)NUP_OldMin2.Value, (int)NUP_OldMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Old3.SelectedIndex, (int)NUP_OldForme3.Value, (int)NUP_OldMin3.Value, (int)NUP_OldMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Good1.SelectedIndex, (int)NUP_GoodForme1.Value, (int)NUP_GoodMin1.Value, (int)NUP_GoodMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Good2.SelectedIndex, (int)NUP_GoodForme2.Value, (int)NUP_GoodMin2.Value, (int)NUP_GoodMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Good3.SelectedIndex, (int)NUP_GoodForme3.Value, (int)NUP_GoodMin3.Value, (int)NUP_GoodMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Super1.SelectedIndex, (int)NUP_SuperForme1.Value, (int)NUP_SuperMin1.Value, (int)NUP_SuperMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Super2.SelectedIndex, (int)NUP_SuperForme2.Value, (int)NUP_SuperMin2.Value, (int)NUP_SuperMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_Super3.SelectedIndex, (int)NUP_SuperForme3.Value, (int)NUP_SuperMin3.Value, (int)NUP_SuperMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeA1.SelectedIndex, (int)NUP_HordeAForme1.Value, (int)NUP_HordeAMin1.Value, (int)NUP_HordeAMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeA2.SelectedIndex, (int)NUP_HordeAForme2.Value, (int)NUP_HordeAMin2.Value, (int)NUP_HordeAMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeA3.SelectedIndex, (int)NUP_HordeAForme3.Value, (int)NUP_HordeAMin3.Value, (int)NUP_HordeAMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeA4.SelectedIndex, (int)NUP_HordeAForme4.Value, (int)NUP_HordeAMin4.Value, (int)NUP_HordeAMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeA5.SelectedIndex, (int)NUP_HordeAForme5.Value, (int)NUP_HordeAMin5.Value, (int)NUP_HordeAMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeB1.SelectedIndex, (int)NUP_HordeBForme1.Value, (int)NUP_HordeBMin1.Value, (int)NUP_HordeBMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeB2.SelectedIndex, (int)NUP_HordeBForme2.Value, (int)NUP_HordeBMin2.Value, (int)NUP_HordeBMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeB3.SelectedIndex, (int)NUP_HordeBForme3.Value, (int)NUP_HordeBMin3.Value, (int)NUP_HordeBMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeB4.SelectedIndex, (int)NUP_HordeBForme4.Value, (int)NUP_HordeBMin4.Value, (int)NUP_HordeBMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeB5.SelectedIndex, (int)NUP_HordeBForme5.Value, (int)NUP_HordeBMin5.Value, (int)NUP_HordeBMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeC1.SelectedIndex, (int)NUP_HordeCForme1.Value, (int)NUP_HordeCMin1.Value, (int)NUP_HordeCMax1.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeC2.SelectedIndex, (int)NUP_HordeCForme2.Value, (int)NUP_HordeCMin2.Value, (int)NUP_HordeCMax2.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeC3.SelectedIndex, (int)NUP_HordeCForme3.Value, (int)NUP_HordeCMin3.Value, (int)NUP_HordeCMax3.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeC4.SelectedIndex, (int)NUP_HordeCForme4.Value, (int)NUP_HordeCMin4.Value, (int)NUP_HordeCMax4.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            data = MakeSlotData(CB_HordeC5.SelectedIndex, (int)NUP_HordeCForme5.Value, (int)NUP_HordeCMin5.Value, (int)NUP_HordeCMax5.Value);
            Array.Copy(data, 0, ed, offset, 4);
            offset += 4;
            #endregion
            return ed;
        }

        private byte[] ConcatArrays(byte[] b1, byte[] b2)
        {
            byte[] concat = new byte[b1.Length + b2.Length];
            Array.Copy(b1, 0, concat, 0, b1.Length);
            Array.Copy(b2, 0, concat, b1.Length, b2.Length);
            return concat;
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            int f = CB_LocationID.SelectedIndex;
            string filepath = filepaths[f];
            FileStream InStream = File.OpenRead(filepaths[f]);
            BinaryReader br = new BinaryReader(InStream);
            br.BaseStream.Seek(0x10, SeekOrigin.Begin);
            int offset = br.ReadInt32() + 0x10;
            int length = (int)br.BaseStream.Length - offset;
            br.Close();
            byte[] filedata = File.ReadAllBytes(filepaths[f]);
            byte[] preoffset = new byte[] { };
            if (offset < filedata.Length)
            {
                preoffset = new byte[offset];
                Array.Copy(filedata, preoffset, offset);
            }
            else
            {
                preoffset = new byte[filedata.Length];
                Array.Copy(filedata, preoffset, filedata.Length);
                //overwrite offset so the game actually looks at the data
                Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(filedata.Length)), 0, preoffset, 0x10, 4);
            }
            byte[] encdata = new byte[] { };
            if (hasData()) { encdata = MakeEncounterData(); }
            byte[] newdata = ConcatArrays(preoffset, encdata);
            File.WriteAllBytes(filepath, newdata);
        }

        private void PreloadTabs()
        {
            for (int i = 0; i < this.TabControl_EncounterData.TabPages.Count; i++)
            {
                this.TabControl_EncounterData.TabPages[i].Show();
            }
            this.TabControl_EncounterData.TabPages[0].Show();
        }

    }
}
