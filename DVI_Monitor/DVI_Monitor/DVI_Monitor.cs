using System;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace TestProject
{
    public partial class DVI_Monitor : Form
    {
        public static DVIService.monitorSoapClient ds = new DVIService.monitorSoapClient();
        clockEditor clockCfg = new clockEditor();
        Timer stockTimer = new Timer(5000);
        Timer clockTimer = new Timer(500);
        public DVI_Monitor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setting up timers to call functions on elapse and then starting them
            stockTimer.Elapsed += UpdateInfo;
            UpdateInfo(null, null);
            stockTimer.Start();

            clockTimer.Elapsed += UpdateClocks;
            clockTimer.Start();
        }

        private void UpdateClocks(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currTime = DateTime.UtcNow;

            //Update clock text
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                Clock1_Name.Text = clockCfg.Clock1_Selection;
                if (clockCfg.Clock1_Selection != "None") 
                {
                    Clock1_Time.Text = getTimeString(currTime, clockCfg.Clock1_Selection);
                } 
                else { Clock1_Time.Text = "-"; }

                Clock2_Name.Text = clockCfg.Clock2_Selection;
                if (clockCfg.Clock2_Selection != "None")
                {
                    Clock2_Time.Text = getTimeString(currTime, clockCfg.Clock2_Selection);
                }
                else { Clock2_Time.Text = "-"; }

                Clock3_Name.Text = clockCfg.Clock3_Selection;
                if (clockCfg.Clock3_Selection != "None")
                {
                    Clock3_Time.Text = getTimeString(currTime, clockCfg.Clock3_Selection);
                }
                else { Clock3_Time.Text = "-"; }
            });
        }

        public string getTimeString(DateTime currUtcTime, string timeZoneID)
        {
            //format time information given the current utc time and a timeZoneID
            DateTime localizedClock = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currUtcTime, timeZoneID);

            return $"{localizedClock.DayOfWeek} {localizedClock.ToShortDateString()} - {localizedClock.TimeOfDay.ToString("hh\\:mm\\:ss")}";
        }

        private void UpdateInfo(object sender, EventArgs e)
        {
            //grab stock information while on a seperate thread
            //this avoids unnecessarily blocking the main thread
            string[] tmpVal = new string[4]
            { 
                $"Temp: {ds.StockTemp()}°C", 
                $"Hummidity: {ds.StockHumidity()} %", 
                $"Temp: {ds.OutdoorTemp()}°C", 
                $"Hummidity: {ds.OutdoorHumidity()} %" 
            };
            string[][] tmpArr = new string[3][] 
            { 
                ds.StockItemsUnderMin().ToArray(), 
                ds.StockItemsOverMax().ToArray(), 
                ds.StockItemsMostSold().ToArray()
            };

            //Update information on ui elements
            this.BeginInvoke((MethodInvoker)delegate () 
            { 
                strgTmpLbl.Text = tmpVal[0]; 
                strgHmdLbl.Text = tmpVal[1];

                outTmpLbl.Text = tmpVal[2]; 
                outHmdLbl.Text = tmpVal[3];

                stockMin.Items.Clear();
                stockMax.Items.Clear();
                stockSold.Items.Clear();

                stockMin.Items.AddRange(tmpArr[0]);
                stockMax.Items.AddRange(tmpArr[1]);
                stockSold.Items.AddRange(tmpArr[2]);
            });
        }

        private void editClock(object sender, EventArgs e)
        {
            //display clock editing window
            clockCfg.Show();
        }
    }
}
