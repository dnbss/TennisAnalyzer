using MatchesParser;
using SetAnalyzer;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tennis;
using TennisParser.CoreParser.Tennis;


namespace TennisParser
{
    public partial class Form1 : Form
    {
        private ParserMatchesWorker<MatchInfo[]> parserMatches;

        private ParserTennisWorker<Set<string>[]> parserTennis;

        private MatchInfo[] matchesInfo;

        private Set<string>[] sets;


        public Form1()
        {
            InitializeComponent();

            parserMatches = new ParserMatchesWorker<MatchInfo[]>(new MathcesParser.MathcesParser(), new MathcesSettings());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            concreteMatchInfoListBox.Items.Clear();

            matchesListBox.Items.Clear();

            analyzedPointsListBox.Items.Clear();

            pictureBox1.Image = null;

            await GetMatches();

            ShowMatches();

        }

        private void ShowSetAnalyze(Set<string> set)
        {
            analyzedPointsListBox.Items.Clear();

            SetAnalyzer.SetAnalyzer setAnalyzer = new SetAnalyzer.SetAnalyzer();

            SetConverter setConverter = new SetConverter();

            var analyzedPoints = setAnalyzer.Analyze(setConverter.Convert(set));

            foreach (var point in analyzedPoints)
            {
                analyzedPointsListBox.Items.Add(point);
            }

            ChartPoints.ChartPoints chartPoints = new ChartPoints.ChartPoints(pictureBox1.Width, pictureBox1.Height);

            pictureBox1.Image = chartPoints.GetChart(setConverter.Convert(set), analyzedPoints);

        }

        private async Task GetMatches()
        {
            matchesInfo = await parserMatches.GetMatches();
        }

        private void ShowMatches()
        {
            foreach (var matchInfo in matchesInfo)
            {
                matchesListBox.Items.Add(matchInfo.Name);
            }
        }

        private async void matchesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            concreteMatchInfoListBox.Items.Clear();

            analyzedPointsListBox.Items.Clear();

            pictureBox1.Image = null;

            string url = matchesInfo[matchesListBox.SelectedIndex].Url;

            parserTennis = new ParserTennisWorker<Set<string>[]>(new TennisParser(), url, new TennisParserSettings());

            sets = await parserTennis.GetMatchStatistics();

           

            for (int i = 0; i < sets.Length; ++i)
            {
                concreteMatchInfoListBox.Items.Add("===========================");

                concreteMatchInfoListBox.Items.Add("SET " + sets[i].NumberSet.ToString());

                foreach (var matchPoint in sets[i].MatchPoints)
                {
                    concreteMatchInfoListBox.Items.Add("\t" + matchPoint.Item1 + "-" + matchPoint.Item2);
                }
            }

            currentSetNumericUpDown.Maximum = sets.Length;

            currentSetNumericUpDown.Value = currentSetNumericUpDown.Maximum;

            ShowSetAnalyze(sets[(int)currentSetNumericUpDown.Value - 1]);
        }

        private void analyzedPointsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void concreteMatchInfoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ShowSetAnalyze(sets[(int)currentSetNumericUpDown.Value - 1]);
        }
    }
}
