using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace KGCtASP
{
    public partial class MainForm : Form
    {
        GCodeData[] gCode;
        ASData[] asData;
        string lastFileName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void displayList(ListBox lb, string[] strings)
        {
            int dispval = strings.Length;
            if (strings.Length > 1024) { dispval = 1024; }
            for (int i = 0; i < dispval; i++)
            {
                string GCode = strings[i];
                if (InvokeRequired) { Invoke(new Action(() => lb.Items.Add(GCode))); }
                else { lb.Items.Add(GCode); }
            }
        }

        private void updateProgressbar(ProgressBar pb, int value)
        {
            if (InvokeRequired) { Invoke(new Action(() => pb.Value = value)); }
            else { pb.Value = value; }
        }

        private void loadFile(string filename)
        {
            string fileText = System.IO.File.ReadAllText(filename);
            string[] fileGCodeArray = fileText.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            displayList(lbGCodeData, fileGCodeArray);

            gCode = new GCodeData[fileGCodeArray.Length];

            for (int i = 0; i < fileGCodeArray.Length; i++)
            {
                string line = fileGCodeArray[i];
                GCodeData gCodeData = new GCodeData(line);
                gCode[i] = gCodeData;

                if (i % 500 == 0) { updateProgressbar(pbFileLoaded, Convert.ToInt32(i * 100.0 / fileGCodeArray.Length)); }
            }

            updateProgressbar(pbFileLoaded, 100);
            if (InvokeRequired) { Invoke(new Action(() => bParse.Enabled = true)); }
            else { bParse.Enabled = true; }
        }

        private void bOpenFile_Click(object sender, EventArgs e)
        {

            bParse.Enabled = false;
            bSave.Enabled = false;

            if (ofdOpenFile.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = ofdOpenFile.FileName;
            try
            {
                lastFileName = Path.GetFileName(filename).Split('.')[0];
            } catch (Exception ex) { lastFileName = ""; }
            tbFilePath.Text = filename;
            lbGCodeData.Items.Clear();
            pbFileLoaded.Value = 0;
            ThreadStart loadFileDelegate = delegate { loadFile(filename); };
            Thread thread = new Thread(loadFileDelegate);
            thread.Start();
        }

        private void parseFile()
        {
            GCodeParser parser = new GCodeParser();
            asData = parser.Parse(gCode, updateProgressbar, pbFileParsed, cbNoFeeder.Checked);


            List<string> lines = new List<string>();
            foreach (var line in asData)
            {
                lines.AddRange(line.Lines);
            }

            displayList(lbASData, lines.ToArray());
            updateProgressbar(pbFileParsed, 100);
            if (InvokeRequired) { Invoke(new Action(() => bSave.Enabled = true)); }
            else { bSave.Enabled = true; }
        }

        private void bParse_Click(object sender, EventArgs e)
        {
            bParse.Enabled = false;
            lbASData.Items.Clear();
            ThreadStart parseFileDelegate = delegate { parseFile(); };
            Thread thread = new Thread(parseFileDelegate);
            thread.Start();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            ofdSaveFile.FileName = lastFileName;
            ofdSaveFile.DefaultExt = "as";
            if (ofdSaveFile.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = ofdSaveFile.FileName;

            List<string> lines = new List<string>();
            lines.Add(String.Format(".PROGRAM {0}()", Path.GetFileName(filename).Split('.')[0]));
            foreach (var line in asData)
            {
                lines.AddRange(line.Lines);
            }
            lines.Add(".END");
            
            System.IO.File.WriteAllLines(filename, lines.ToArray());
        }
    }
}
