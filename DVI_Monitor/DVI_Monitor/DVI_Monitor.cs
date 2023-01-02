using System;
using System.Diagnostics;
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
            stockTimer.Elapsed += UpdateInfo;
            UpdateInfo(null, null);
            stockTimer.Start();

            clockTimer.Elapsed += UpdateClocks;
            clockTimer.Start();
        }

        private void UpdateClocks(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                DateTime currTime = DateTime.UtcNow;
                if (clockCfg.currentClocks.Count != clockList.Items.Count)
                {
                    clockList.Items.Clear();
                    foreach (string timezone in clockCfg.currentClocks)
                    {
                        clockList.Items.Add(getTimeString(currTime, timezone));
                    }
                }
                else
                {
                    for (int i = 0; i < clockCfg.currentClocks.Count; i++)
                    {
                        clockList.Items[i] = getTimeString(currTime, clockCfg.currentClocks[i].ToString());
                    }
                }
            });
        }

        public string getTimeString(DateTime currUtcTime, string timeZoneID)
        {
            //format time information given the current utc time and a timeZoneID
            DateTime localizedClock = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currUtcTime, timeZoneID);

            return $"{timeZoneID}: {localizedClock.DayOfWeek} {localizedClock.ToShortDateString()} - {localizedClock.TimeOfDay.ToString("hh\\:mm\\:ss")}";
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

        private void button1_Click(object sender, EventArgs e)
        {
            clockCfg.Show();
        }
    }
}
