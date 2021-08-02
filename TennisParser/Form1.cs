using MatchesParser;
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

            var list = setAnalyzer.Analyze(set);

            foreach (var point in list)
            {
                analyzedPointsListBox.Items.Add(point);
            }

            ChartPoints.ChartPoints chartPoints = new ChartPoints.ChartPoints(pictureBox1.Width, pictureBox1.Height);

            pictureBox1.Image = chartPoints.GetChart(list);


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

            int i = 1;

            try
            {
                foreach (var set in sets)
                {

                    concreteMatchInfoListBox.Items.Add("===========================");

                    concreteMatchInfoListBox.Items.Add("SET " + i);

                    foreach (var matchPoint in set.MatchPoints)
                    {

                        foreach (var matchPoint15 in matchPoint.MatchPoints15)
                        {
                            concreteMatchInfoListBox.Items.Add("\t\t" + matchPoint15.Item1 + "-" + matchPoint15.Item2);
                        }

                        concreteMatchInfoListBox.Items.Add("\tMatch point " + matchPoint.MatchPointScore.Item1
                            + "-" + matchPoint.MatchPointScore.Item2);
                    }

                    i++;
                }
            }
            catch
            {
                // ignored
            }

            currentSetNumericUpDown.Maximum = sets.Length;

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
