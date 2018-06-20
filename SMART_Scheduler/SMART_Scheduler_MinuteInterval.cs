using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;


namespace SMART_Scheduler
{
    public partial class SMART_Scheduler_MinuteInterval : Form
    {
        //string strConnectionString_WAnaSoft;
        string strConnectionString_RASolarERP;
        string strConnectionString_RASolarERP_RRERRN;
        DataSet ds = new DataSet();

        //string cStrDownloadState;
        //string cStrDeviceID;
        //string cStrDeviceDesc;
        int cIntTimerTickNo;
        int cIntMinuteCounterToCallbKashAPI;
        //short cIntConnectionState;
        int cIntProcessID;
        //int cIntNoOfUsers;
        //int cIntNoOfLogs;
        //bool cBoolIsLogCleared;
        //bool cBoolIsLogArchived;
        string cStrDownloadType;
        int cIntDownloadID;

        public SMART_Scheduler_MinuteInterval()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //string strWAnaSoftServerName = "10.32.2.54";//System.Configuration.ConfigurationManager.AppSettings["ServerName"];
                //string strWAnaSoftDatabase = "WAnaSoft";//System.Configuration.ConfigurationManager.AppSettings["Database"];
                //string strWAnaSoftUserName = "RSF";//System.Configuration.ConfigurationManager.AppSettings["UserName"];
                //string strWAnaSoftPassword = "rsf@123";//System.Configuration.ConfigurationManager.AppSettings["Password"];

                string strRASolarERPServerName = "10.96.1.11\\RSFERP_LIVE";//System.Configuration.ConfigurationManager.AppSettings["ServerName"];
                string strRASolarERPDatabase = "RASolarERP";//System.Configuration.ConfigurationManager.AppSettings["Database"];
                string strRASolarERPUserName = "THREEESP";//System.Configuration.ConfigurationManager.AppSettings["UserName"];
                string strRASolarERPPassword = "vnght45113ESPfrsfrre";//System.Configuration.ConfigurationManager.AppSettings["Password"];

                //string strRASolarERPUserName = "ETL_RASolarERP_WAnaSoft_Bridge";//System.Configuration.ConfigurationManager.AppSettings["UserName"];
                //string strRASolarERPPassword = "rsferpWAnaSoft";//System.Configuration.ConfigurationManager.AppSettings["Password"];

                //this.toolStripStatusLabel1.Text = "Server name: " + strServerName;
                //this.toolStripStatusLabel2.Text = "Database: " + strDatabase;
                //this.statusStrip1.Refresh();

                //strConnectionString_WAnaSoft = "Data Source=" + strWAnaSoftServerName + ";Initial Catalog=" + strWAnaSoftDatabase + ";Persist Security Info=True;User ID=" + strWAnaSoftUserName + ";Password=" + strWAnaSoftPassword;
                strConnectionString_RASolarERP = "Data Source=" + strRASolarERPServerName + ";Initial Catalog=" + strRASolarERPDatabase + ";Persist Security Info=True;User ID=" + strRASolarERPUserName + ";Password=" + strRASolarERPPassword;

                strConnectionString_RASolarERP_RRERRN = "Data Source=" + strRASolarERPServerName + ";Initial Catalog=RASolarERP_RRERRN;Persist Security Info=True;User ID=" + strRASolarERPUserName + ";Password=" + strRASolarERPPassword;

                //this.cboDisbursementNo.SelectedIndex = 0;
                //string strSameDateLastMonth = String.Format("{0:dd-MMM-yy}", this.startDTP.Value.AddMonths(-1));

                //this.startDTP.Value = Convert.ToDateTime("01" + strSameDateLastMonth.Substring(2,7));
                //this.endDTP.Value = this.endDTP.Value.AddDays(this.endDTP.Value.Day * -1);

                cStrDownloadType = "AUTO";
                //this.chkAuto.Checked = false;

                cIntTimerTickNo = 1;//Immidiate Call
                cIntMinuteCounterToCallbKashAPI = 1;
                cIntProcessID = 1;
                //cIntDownloadID = 0;

                //cBoolIsLogCleared = false;
                //cBoolIsLogArchived = false;

                //this.timer1.Interval = 1000 * 30; //Me.NumericUpDown1.Value '1 Second x 60 Second x 5 = 5 Minutes
                //this.timer1.Interval = Convert.ToInt32(1000 * 60 * 1); //1 Second (1000 Mili Second) x 60 Seconds x 1 Minute = 1 Minute
                ////Me.NumericUpDown1.Enabled = False
                //this.timer1.Start();

                ////StartDownloadDeliveryFromWAnaSoftNUpdateRASolarERP();

            }
            catch (Exception ex)
            {
                this.WriteErrorLog("\nERROR #101: from ETL_RASolarERP_WAnaSoft_Bridge_Load_Event " + GetErrorEndingString());
                this.WriteErrorLog(ex.Message);
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnON_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtCurrentTime = DateTime.Now;
                //DateTime dtFirstTickExecutionTime = dtCurrentTime.AddHours(1).AddMinutes(-dtCurrentTime.Minute).AddSeconds(-dtCurrentTime.Second);// new DateTime(2016, 10, 16, 17, 05, 00);
                DateTime dtFirstTickExecutionTime = dtCurrentTime.AddMinutes(1);// new DateTime(2016, 10, 16, 17, 05, 00);

                //string strNextUpdateTime = "";
                if (this.chkAuto.Checked)
                {
                    this.chkAuto.Text = "Scheduler is ON...";
                    this.chkAuto.Refresh();
                    //strNextUpdateTime = DateTime.Now.AddMinutes(Convert.ToDouble(this.NumericUpDown1.Value)).ToString();

                    //cIntTimerTickNo = 0; // 0 Because No Instant Run

                    //Interval for the Next Run in a Rounded Clock Time
                    //this.timer1.Interval = Convert.ToInt32(dtFirstTickExecutionTime.Subtract(dtCurrentTime).TotalMilliseconds);//Convert.ToInt32(1000 * 60 * 5); //1 Second (1000 Mili Second) x 60 Seconds x 5 Minutes = 5 Minute
                    //this.timer1.Interval = Convert.ToInt32(1000 * 60 * 5); //1 Second (1000 Mili Second) x 60 Seconds x 5 Minutes = 5 Minute
                    this.timer1.Interval = Convert.ToInt32(1000 * 60 * 1); //1 Second (1000 Mili Second) x 60 Seconds x 1 Minute = 1 Minute
                    this.NumericUpDown1.Enabled = false;

                    this.timer1.Start();
                }

                //cIntMinuteCounterToCallbKashAPI = 5; //Immidiate Call
                //Starting the process of downloading and updating tables (for Instant Run)
                this.RunTheProcessesInMinuteInterval();

                if (this.chkAuto.Checked)
                {
                    if (cIntTimerTickNo > 0)
                    {
                        this.lblTickNo2.Text = cIntTimerTickNo.ToString().Trim();
                        this.lblLastUpdate2.Text = dtCurrentTime.ToString("dd-MMM-yyyy HH:mm:ss");
                    }
                    this.lblNextUpdate2.Text = dtFirstTickExecutionTime.ToString("dd-MMM-yyyy HH:mm:ss");//strNextUpdateTime;
                }
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("\nERROR #102: from btnON_Click_Event " + GetErrorEndingString());
                this.WriteErrorLog(ex.Message);
                if (cStrDownloadType == "MANUAL")
                {
                    MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.btnON.Enabled = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                cIntTimerTickNo += 1;
                cIntMinuteCounterToCallbKashAPI += 1;

                //Starting the process of downloading and updating tables (Recurring Run)
                this.RunTheProcessesInMinuteInterval();

                this.lblTickNo2.Text = cIntTimerTickNo.ToString().Trim();
                this.lblLastUpdate2.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
                //this.lblNextUpdate2.Text = DateTime.Now.AddMinutes(1).ToString();//strNextUpdateTime;

                if (cIntTimerTickNo == 1)
                {
                    //this.timer1.Interval = Convert.ToInt32(1000 * 60 * 60 * 24); //1 Second (1000 Mili Second) x 60 Seconds x 60 Minutes x 24 Hours = 1 Day
                    //Interval for the Next Run in a Regular 5 Minutes Schedule
                    //this.timer1.Interval = Convert.ToInt32(1000 * 60 * 60 * 1); //1 Second (1000 Mili Second) x 60 Seconds x 60 Minutes x 1 Hours = 1 Hour
                    //this.timer1.Interval = Convert.ToInt32(1000 * 60 * 5); //1 Second (1000 Mili Second) x 60 Seconds x 5 Minutes = 5 Minute
                    this.timer1.Interval = Convert.ToInt32(1000 * 60 * 1); //1 Second (1000 Mili Second) x 60 Seconds x 1 Minute = 1 Minute
                }
                //this.lblNextUpdate2.Text = DateTime.Now.AddMilliseconds(this.timer1.Interval).ToString("dd-MMM-yyyy HH:mm:ss");//strNextUpdateTime;
                this.lblNextUpdate2.Text = DateTime.Now.AddMilliseconds(this.timer1.Interval).ToString("dd-MMM-yyyy HH:mm:ss");//strNextUpdateTime;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.WriteProcessLog("\nError: " + ex.Message);
                this.lblStatus.Text = "...";
                this.lblStatus.Refresh();
            }
        }

        private void RunTheProcesses()
        {
            this.ProgressBar2.Value = 0;
            this.lblProgress2.Text = "";

            if (cIntProcessID > 1000)
            {
                cIntProcessID = 1;
                this.listBox1.Items.Clear();
            }

            this.WriteProcessLog("\n*** Starting the process (Process #: " + cIntTimerTickNo.ToString() + ") on " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + " ***");

            //cStrDownloadState = "Start";
            this.lblStatus.Text = "Processing data, please wait...";
            this.lblStatus.Refresh();


            //SqlTransaction sqlTran_RASolarERP;
            try
            {
                //Make Connection to the TCDBridge Database
                //this.WriteProcessLog("\nConnecting to the RASolarERP Database");
                SqlConnection sqlConn_RASolarERP = new SqlConnection(strConnectionString_RASolarERP);
                sqlConn_RASolarERP.Open();
                this.WriteProcessLog("\nConnected to the RASolarERP Database successfully.");

                string strQuery;
                SqlCommand sqlCmd_RASolarERP = new SqlCommand();

                //sqlTran_RASolarERP = sqlConn_RASolarERP.BeginTransaction();

                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlCmd_RASolarERP.Connection = sqlConn_RASolarERP;//sqlTran_RASolarERP.Connection;
                //sqlCmd_RASolarERP.Transaction = sqlTran_RASolarERP;
                sqlCmd_RASolarERP.CommandTimeout = 3600;

                try
                {
                    try
                    {
                        this.WriteProcessLog("\nSending Scheduled Mail");
                        sqlCmd_RASolarERP.CommandText = "EXEC [SP_SMART_Scheduler_SendScheduledMail]";
                        //sqlCmd_RASolarERP.ExecuteNonQuery();
                        MessageBox.Show("Test Message");
                    }
                    catch (Exception ex0)
                    {
                        //this.WriteErrorLog("\nERROR #102: from btnON_Click_Event " + GetErrorEndingString());
                        if (cStrDownloadType == "MANUAL")
                        {
                            throw;
                        }
                        else
                        {
                            this.WriteProcessLog("\nERROR for Mail-: " + ex0.Message);
                            //this.WriteErrorLog(ex0.Message); //Auto written by process log using the tag ERROR
                        }
                    }

                    try
                    {
                        this.WriteProcessLog("\nSending Scheduled SMS");
                        this.SMART_Scheduler_SendScheduledSMS("DAILYMORSMS2CUST");
                        this.SMART_Scheduler_SendScheduledSMS("DAILYEVESMS2CUST");
                    }
                    catch (Exception ex0)
                    {
                        //this.WriteErrorLog("\nERROR #102: from btnON_Click_Event " + GetErrorEndingString());
                        if (cStrDownloadType == "MANUAL")
                        {
                            throw;
                        }
                        else
                        {
                            this.WriteProcessLog("\nERROR for SMS: " + ex0.Message);
                            //this.WriteErrorLog(ex0.Message); //Auto written by process log using the tag ERROR
                        }
                    }

                    try
                    {
                        this.WriteProcessLog("\nCreating Alarm Log");
                        strQuery = "INSERT INTO [SMART_Scheduler_AlarmLog] ([AlarmExecutionDate],[TimerTickNo],[ExecutedOn]) VALUES(";
                        strQuery += "GETDATE()," + cIntTimerTickNo.ToString() + ",GETDATE())";
                        sqlCmd_RASolarERP.CommandText = strQuery;
                        sqlCmd_RASolarERP.ExecuteNonQuery();
                    }
                    catch (Exception ex0)
                    {
                        //this.WriteErrorLog("\nERROR #102: from btnON_Click_Event " + GetErrorEndingString());
                        if (cStrDownloadType == "MANUAL")
                        {
                            throw;
                        }
                        else
                        {
                            this.WriteProcessLog("\nERROR for AlarmLog: " + ex0.Message);
                            //this.WriteErrorLog(ex0.Message); //Auto written by process log using the tag ERROR
                        }
                    }

                    //sqlTran_RASolarERP.Commit();
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();
                }
                catch (Exception)
                {
                    //sqlTran_RASolarERP.Rollback();
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();
                    throw;
                }

                //cStrDownloadState = "Completed";
                this.lblStatus.Text = "";
                this.lblStatus.Refresh();

                //this.WriteProcessLog("Data downloading from FingerTec devices completed successfully.");
                //MessageBox.Show("Data Transfer from WAnaSoft to RSFERP Completed Successfully.", "WAnaSoft Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this.WriteProcessLog("\nThe process completed successfully.");
                this.WriteProcessLog("*** Ending the process (Process #: " + cIntTimerTickNo.ToString() + ") on " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + " ***");

                //if (cStrDownloadType == "MANUAL")
                //{
                //    //Showing new downloaded data
                //    string strSelectString;
                //    strSelectString = "SELECT d.Numeric_SBU_ID,d.EmployeeID,d.EmpEnrollNo,m.EmployeeNo,ISNULL([Name],'Visitor - Not in RAPID') [Name],TransDateTime,CASE WHEN InOut = 0 THEN 'Out' WHEN InOut = 1 THEN 'In' ELSE '**' END InOut,d.[Status],d.LocationID,d.DeviceOrAppID,d.DataSource FROM tblInOutTransLog_Regular d LEFT OUTER JOIN HRMIS.dbo.EMPLOYEE m ON d.EmployeeID = m.EmployeeID ";
                //    strSelectString += " WHERE d.[Status] = 1 ORDER BY Numeric_SBU_ID,d.EmployeeID,TransDateTime";
                //    this.ShowData(strSelectString, sqlConnection1);
                //}

            }
            catch
            {
                //MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.lblStatus.Text = "...";
                //this.lblStatus.Refresh();
                throw;
            }

        }
        private void RunTheProcessesInMinuteInterval()
        {
            this.ProgressBar2.Value = 0;
            this.lblProgress2.Text = "";

            if (cIntProcessID > 1000)
            {
                cIntProcessID = 1;
                this.listBox1.Items.Clear();
            }

            this.WriteProcessLog("\n*** Starting the process (Process #: " + cIntTimerTickNo.ToString() + ") on " + cIntMinuteCounterToCallbKashAPI.ToString() + ", " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + " ***");

            //cStrDownloadState = "Start";
            this.lblStatus.Text = "Processing data, please wait...";
            this.lblStatus.Refresh();


            //SqlTransaction sqlTran_RASolarERP;
            try
            {
                ////Make Connection to the TCDBridge Database
                ////this.WriteProcessLog("\nConnecting to the RASolarERP Database");
                //SqlConnection sqlConn_RASolarERP = new SqlConnection(strConnectionString_RASolarERP);
                //sqlConn_RASolarERP.Open();
                //this.WriteProcessLog("\nConnected to the RASolarERP Database successfully.");

                //string strQuery;
                //SqlCommand sqlCmd_RASolarERP = new SqlCommand();

                ////sqlTran_RASolarERP = sqlConn_RASolarERP.BeginTransaction();

                //SqlDataAdapter sqlDa = new SqlDataAdapter();
                //sqlCmd_RASolarERP.Connection = sqlConn_RASolarERP;//sqlTran_RASolarERP.Connection;
                ////sqlCmd_RASolarERP.Transaction = sqlTran_RASolarERP;
                //sqlCmd_RASolarERP.CommandTimeout = 3600;

                try
                {
                    //Sending Scheduled Mail -----------------------------------------------------------------------------------------------------------------------------------
                    //try
                    //{
                    //    this.WriteProcessLog("\nSending Scheduled Mail");
                    //    sqlCmd_RASolarERP.CommandText = "EXEC [SP_SMART_Scheduler_SendScheduledMail]";
                    //    //sqlCmd_RASolarERP.ExecuteNonQuery();
                    //    MessageBox.Show("Test Message");
                    //}
                    //catch (Exception ex0)
                    //{
                    //    //this.WriteErrorLog("\nERROR #102: from btnON_Click_Event " + GetErrorEndingString());
                    //    if (cStrDownloadType == "MANUAL")
                    //    {
                    //        throw;
                    //    }
                    //    else
                    //    {
                    //        this.WriteProcessLog("\nERROR for Mail-: " + ex0.Message);
                    //        //this.WriteErrorLog(ex0.Message); //Auto written by process log using the tag ERROR
                    //    }
                    //}


                    //Downloading bKash Transaction ----------------------------------------------------------------------------------------------------------------------------
                    try
                    {
                        if (cIntMinuteCounterToCallbKashAPI >= 5 || cIntTimerTickNo == 1) //Call the bKash API in 5 minutes interval
                        {
                            if (cIntTimerTickNo == 1)
                                cIntMinuteCounterToCallbKashAPI = 1;
                            else
                                cIntMinuteCounterToCallbKashAPI = 0;

                            //this.WriteProcessLog("\nDownloading bKash Transaction for RSF (in 5 minutes interval)"); 
                            //this.SMART_Scheduler_SendScheduledSMS("DAILYMORSMS2CUST");
                            //this.SMART_Scheduler_SendScheduledSMS("DAILYEVESMS2CUST");
                            //this.SMART_Scheduler_DownloadDataFrombKashAPIforRSF();

                            this.WriteProcessLog("\nDownloading bKash Transaction for RRE (in 5 minutes interval)");
                            this.SMART_Scheduler_DownloadDataFrombKashAPIforRRE();

                            this.WriteProcessLog("\nCall SparkCloud for Payment (in 5 minutes interval)");
                            this.CallSparkCloudAPIAgainstTheMobilePaymentsFromTheCustomers();
                        }
                    }
                    catch (Exception ex0)
                    {
                        //this.WriteErrorLog("\nERROR #102: from btnON_Click_Event " + GetErrorEndingString());
                        if (cStrDownloadType == "MANUAL")
                        {
                            throw;
                        }
                        else
                        {
                            this.WriteProcessLog("\nERROR for SMS: " + ex0.Message);
                            //this.WriteErrorLog(ex0.Message); //Auto written by process log using the tag ERROR
                        }
                    }


                    //Creating Alarm Log ---------------------------------------------------------------------------------------------------------------------------------------
                    //try
                    //{
                    //    this.WriteProcessLog("\nCreating Alarm Log");
                    //    strQuery = "INSERT INTO [SMART_Scheduler_AlarmLog] ([AlarmExecutionDate],[TimerTickNo],[ExecutedOn]) VALUES(";
                    //    strQuery += "GETDATE()," + cIntTimerTickNo.ToString() + ",GETDATE())";
                    //    sqlCmd_RASolarERP.CommandText = strQuery;
                    //    sqlCmd_RASolarERP.ExecuteNonQuery();
                    //}
                    //catch (Exception ex0)
                    //{
                    //    //this.WriteErrorLog("\nERROR #102: from btnON_Click_Event " + GetErrorEndingString());
                    //    if (cStrDownloadType == "MANUAL")
                    //    {
                    //        throw;
                    //    }
                    //    else
                    //    {
                    //        this.WriteProcessLog("\nERROR for AlarmLog: " + ex0.Message);
                    //        //this.WriteErrorLog(ex0.Message); //Auto written by process log using the tag ERROR
                    //    }
                    //}

                    ////sqlTran_RASolarERP.Commit();
                    //sqlConn_RASolarERP.Close();
                    //sqlConn_RASolarERP.Dispose();
                }
                catch (Exception)
                {
                    ////sqlTran_RASolarERP.Rollback();
                    //sqlConn_RASolarERP.Close();
                    //sqlConn_RASolarERP.Dispose();
                    throw;
                }

                //cStrDownloadState = "Completed";
                this.lblStatus.Text = "";
                this.lblStatus.Refresh();

                //this.WriteProcessLog("Data downloading from FingerTec devices completed successfully.");
                //MessageBox.Show("Data Transfer from WAnaSoft to RSFERP Completed Successfully.", "WAnaSoft Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this.WriteProcessLog("\nThe process completed successfully.");
                this.WriteProcessLog("*** Ending the process (Process #: " + cIntTimerTickNo.ToString() + ") on " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + " ***");

                //if (cStrDownloadType == "MANUAL")
                //{
                //    //Showing new downloaded data
                //    string strSelectString;
                //    strSelectString = "SELECT d.Numeric_SBU_ID,d.EmployeeID,d.EmpEnrollNo,m.EmployeeNo,ISNULL([Name],'Visitor - Not in RAPID') [Name],TransDateTime,CASE WHEN InOut = 0 THEN 'Out' WHEN InOut = 1 THEN 'In' ELSE '**' END InOut,d.[Status],d.LocationID,d.DeviceOrAppID,d.DataSource FROM tblInOutTransLog_Regular d LEFT OUTER JOIN HRMIS.dbo.EMPLOYEE m ON d.EmployeeID = m.EmployeeID ";
                //    strSelectString += " WHERE d.[Status] = 1 ORDER BY Numeric_SBU_ID,d.EmployeeID,TransDateTime";
                //    this.ShowData(strSelectString, sqlConnection1);
                //}
            }
            catch
            {
                //MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.lblStatus.Text = "...";
                //this.lblStatus.Refresh();
                throw;
            }
        }

        private void SMART_Scheduler_SendScheduledSMS(string strSMSBatchTag)
        {
            //SqlTransaction sqlTran_RASolarERP;
            try
            {
                SqlConnection sqlConn_RASolarERP = new SqlConnection(strConnectionString_RASolarERP);
                sqlConn_RASolarERP.Open();

                string strQuery;
                //string strSMSBatchTag = "DAILYEVESMS2CUST";//"MissingCollectionSummaryReport_ToAllUM";//"TESTBANGLASMS";//"C_D_OD_Customer";

                int intSMSCount = 0;

                SqlCommand sqlCmd_RASolarERP = new SqlCommand();

                //sqlTran_RASolarERP = sqlConn_RASolarERP.BeginTransaction();

                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlCmd_RASolarERP.Connection = sqlConn_RASolarERP;// sqlTran_RASolarERP.Connection;
                //sqlCmd_RASolarERP.Transaction = sqlTran_RASolarERP;
                sqlCmd_RASolarERP.CommandTimeout = 3600;

                try
                {
                    DataSet ds = new DataSet();

                    strQuery = "EXEC [REP_SMSGateway_GetCustomersToSendSMS] '" + strSMSBatchTag + "'";

                    DataTable dtTable = new DataTable("Table");
                    ds.Tables.Add(dtTable);

                    sqlCmd_RASolarERP.CommandText = strQuery;
                    //sqlCmd_RASolarERP.Connection = sqlConn_RASolarERP;
                    sqlDa.SelectCommand = sqlCmd_RASolarERP;
                    sqlDa.Fill(ds, "Table");
                    int intTotalRows = dtTable.Rows.Count;
                    if (intTotalRows == 0)
                    {
                        //MessageBox.Show("No data found, please try again changing the selection criteria.", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.WriteProcessLog("\nSMS: No data found to send the SMS for " + strSMSBatchTag);
                        return;
                    }
                    else
                    {
                        //this.toolStripProgressBar1.Maximum = intTotalRows;
                    }

                    //CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo; //cultureInfo.TextInfo;

                    string queryForInsertTable = "";

                    string strRecipientName = "";
                    string strRecipientMobileNo = "";
                    string strMessageText = "";
                    string str2ndPartOfTheURL = "";
                    string strAPIReturnedResult = "";
                    string strStatusCode = "";

                    int intRowCount = 0;
                    foreach (DataRow sourceRow in dtTable.Rows)
                    {
                        intRowCount++;
                        strRecipientName = textInfo.ToTitleCase(sourceRow["RecipientName"].ToString().ToLower().Trim());

                        intSMSCount++;

                        //strRecipientMobileNo = "01730326661";
                        //strRecipientMobileNo = "01713018188";
                        //strRecipientMobileNo = "01914239442";
                        //strRecipientMobileNo = "01975124045";
                        strRecipientMobileNo = sourceRow["RecipientMobileNo"].ToString().Trim().Substring(0, 11);

                        //strMessageText = "Prio Grahok " + strRecipientName + ", Salaam, Apnar kase RSF er mot bokea taka, bokea shoho mot paona taka. Bokea porishodh korun, Niomito kistir taka din. RSF Apnar Pashe Ase. Valo Thakben.";
                        //strMessageText = strRecipientName + ", Apnar Unit er " + sourceRow["NoOfActiveCustomer"].ToString().Trim() + " Active Customer er modhe " + sourceRow["NoOfCustomerWithZeroCollectionThisMonth"].ToString().Trim() + " joner kas theke kono collection posting hoini. Collection korun ebong posting din. Valo Thakben.";
                        //strMessageText = "09AA09CD09B009BF09DF0020099709CD09B009BE09B90995002C0020005200530046002009B809CC09B0002009AC09BF09A609CD09AF09C109A409B809B9002000540056002C002000460041004E002C0020004D006F00620069006C00650020098F09AC09820020098F099C09C709A809CD099F002009AC09CD09AF09BE0982099509BF09820020099A09BE09B209C10020099509B009C7099B09C70964002009AA09CD09B009DF09CB099C09A809C009DF002009AA09A309CD09AF00200993002009B809C709AC09BE002009AA09C709A409C700200052005300460020098509AB09BF09B809C7002009AF09CB099709BE09AF09CB09970020099509B009C109A80964";
                        if (strSMSBatchTag == "DAILYMORSMS2CUST")
                        {
                            strMessageText = "Prio Grahok, Agamikal Apnar Solar Er Kisti Tk." + sourceRow["InstallmentSize"].ToString().Trim() + " Prodanar Tarik. Apnar Total Bokeya Tk." + sourceRow["OutstandingBalanceUpToDate"].ToString().Trim() + ". Niomito Kisti Prodan Korun O RSF Er Ponno Kinun. Dhonnobad";
                        }
                        else if (strSMSBatchTag == "DAILYEVESMS2CUST")
                        {
                            strMessageText = "Prio Grahok, Aj Apnar Solar Er Kisti Prodaner Din Cilo Kintu Apni Kisti Den Ni. RSF Er Protinidhir Sathe Jogajog Kore Niomito Kisti Din Abong Seba Nin.Dhonnobad";
                        }

                        //client.GetAsync("controller.home?username=" + cStrBulkSMS_API_UserName + "&password="  + cStrBulkSMS_API_Password + "&apicode=1&msisdn=" + strRecipientMobileNo + "&countrycode=880&cli=RSF&messagetype=1&message=" + strMessageText + "&messageid=0").ToString();
                        //client.GetAsync("username=RSFadmin&password=RSFadmin123&apicode=1&msisdn=" + strCustomerMobileNo + "&countrycode=880&cli=cmpapi&messagetype=1&message=" + strSMSText + "&messageid=0").ToString();
                        //client.GetAsync("send_sms_api/send_sms_from_api.php?user_name=RSFadmin&password=RSFadmin123&subscriber_no=" + strCustomerMobileNo + "&mask=RSF&sms=" + strSMSText).ToString();
                        str2ndPartOfTheURL = "?username=RSFadmin&password=Rsf@Admin123&apicode=1&msisdn=" + strRecipientMobileNo + "&countrycode=880&cli=RSF&messagetype=1&message=" + strMessageText + "&messageid=0";

                        System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender1, certificate, chain, sslPolicyErrors) => true);

                        WebClient client1 = new WebClient();
                        client1.Proxy = new WebProxy("10.96.1.25:8080");

                        string url = "https://cmp.grameenphone.com/gpcmpapi/messageplatform/controller.home" + str2ndPartOfTheURL;

                        Byte[] requestedHTML;
                        requestedHTML = client1.DownloadData(url);

                        UTF8Encoding objUTF8 = new UTF8Encoding();
                        strAPIReturnedResult = objUTF8.GetString(requestedHTML);

                        strStatusCode = strAPIReturnedResult.Substring(0, 3);

                        if (strStatusCode == "200")
                        {
                            //isSMSSendSuccessful = "1";

                            //INSERT INTO Sal_CollectionFromCustomers_SMSRegister
                            queryForInsertTable = "INSERT INTO [SMSGateway_SMSToCustomerTransaction] ([CustomerCode],[CreatedOn],[CustomerName],[OverdueBalance],[OutstandingBalance],[SMSSentToMobileNo],[RecipientGroupID],[SMSBatchID]) ";
                            queryForInsertTable += "VALUES('" + sourceRow["CustomerCode"].ToString() + "',GETDATE(),'" + sourceRow["RecipientName"].ToString() + "','" + sourceRow["ODBalanceUpToDate"].ToString().Trim() + "','" + sourceRow["OutstandingBalanceUpToDate"].ToString().Trim() + "','" + strRecipientMobileNo + "','ALLCUSTOMR','" + strSMSBatchTag + "')";

                            sqlCmd_RASolarERP.CommandText = queryForInsertTable;
                            sqlCmd_RASolarERP.ExecuteNonQuery(); // Temporarily comment
                        }
                    }

                    //sqlTran_RASolarERP.Commit(); //Comment by ZIR as If any Problem in DB; SMS Fired but Log not writen
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();

                }
                catch (Exception)
                {
                    //sqlTran_RASolarERP.Rollback();
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();

                    throw;
                }
                if (intSMSCount > 0)
                {
                    //MessageBox.Show(intSMSCount.ToString().Trim() + " SMS has been sent successfully.", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.WriteProcessLog("\nSMS: " + intSMSCount.ToString().Trim() + " SMS has been sent successfully.");
                }
                else
                {
                    //MessageBox.Show("Failed to send SMS!", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.WriteProcessLog("\nSMS: Failed to send SMS!");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.WriteProcessLog("\nSMS Error: " + ex.Message);
            }
        }

        private void SMART_Scheduler_DownloadDataFrombKashAPIforRSF()
        {
            //SqlTransaction sqlTran_RASolarERP;
            try
            {
                SqlConnection sqlConn_RASolarERP = new SqlConnection(strConnectionString_RASolarERP);
                sqlConn_RASolarERP.Open();

                string strQuery;

                string strStartDateTime = "2017-08-28 17:45:00";

                int intTransCount = 0;

                SqlCommand sqlCmd_RASolarERP = new SqlCommand();

                //sqlTran_RASolarERP = sqlConn_RASolarERP.BeginTransaction();

                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlCmd_RASolarERP.Connection = sqlConn_RASolarERP;// sqlTran_RASolarERP.Connection;
                //sqlCmd_RASolarERP.Transaction = sqlTran_RASolarERP;
                sqlCmd_RASolarERP.CommandTimeout = 3600;

                try
                {
                    if (this.lblUpToDateTime.Text == "...")
                    {
                        //Getting the Last Transaction DateTime
                        sqlCmd_RASolarERP.CommandText = "SELECT TOP 1 CreatedOn FROM [Integration_MBanking_FundTransferTransactions] WHERE BillerID = '100' AND CreatedOn > '2017-08-28' ORDER BY CreatedOn DESC";

                        if (Convert.IsDBNull(sqlCmd_RASolarERP.ExecuteScalar()) == true | sqlCmd_RASolarERP.ExecuteScalar() == null)
                        {
                            //strResult = "299 Invalid Request for PackagePrice";
                            throw new Exception("Invalid Last Transaction DateTime!");
                        }
                        else
                        {
                            strStartDateTime = Convert.ToDateTime(sqlCmd_RASolarERP.ExecuteScalar().ToString()).AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss"); //Math.Round(Convert.ToDecimal(sqlCmd_RASolarERP.ExecuteScalar().ToString()));
                        }
                    }
                    else
                    {
                        strStartDateTime = Convert.ToDateTime(this.lblUpToDateTime.Text.Substring(7,19)).AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    if (Convert.ToDateTime(strStartDateTime) > DateTime.Now.AddMinutes(-25))
                    {
                        strStartDateTime = DateTime.Now.AddMinutes(-25).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    this.lblUpToDateTime.Text = "Up to: "+Convert.ToDateTime(strStartDateTime).AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss");
                    

                    string str2ndPartOfTheURL = "?user=RURALSERVICESTWO&pass=rUr@L52@247&msisdn=01755685000&start_datetime=" + strStartDateTime + "&end_datetime=" + Convert.ToDateTime(strStartDateTime).AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss");//2017-08-27 18:12:00";

                    WebClient c = new WebClient();
                    c.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                    var data = c.DownloadString("https://www.bkashcluster.com:9081/dreamwave/merchant/trxcheck/periodicpullmsg" + str2ndPartOfTheURL);


                    JObject json = JObject.Parse(data);

                    Transaction objTransaction;

                    TransactionList objTransactionList = new TransactionList();

                    List<Transaction> objTransactions = new List<Transaction>();

                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    TransactionList transactions = jss.Deserialize<TransactionList>(data);

                    string queryForInsertTable = "";
                    int intTransAtSourceCount = 0;

                    intTransAtSourceCount = transactions.Transaction.Count();
                    int intResult = 0; //0 for Failed
                    string strBillerID="";
                    string strStatusCode = "";
                    //string abc = transactions.
                    foreach (Transaction trnx in transactions.Transaction)
                    {
                        string strBankTransactionID = string.Empty;
                        string trxStatus = string.Empty;
                        string strTransactionDate = string.Empty;
                        string decTransferAmount = string.Empty;
                        string service = string.Empty;
                        string strPayerNo = string.Empty;
                        string strReceivingbKashNo = string.Empty;
                        string currency = string.Empty;
                        string strReferenceCode = string.Empty;
                        string counter = string.Empty;
                        string reversed = string.Empty;

                        if (trnx != null)
                        {
                            if (!string.IsNullOrEmpty(trnx.trxId))
                            {
                                if (!string.IsNullOrEmpty(trnx.trxStatus))
                                    trxStatus = trnx.trxStatus;

                                if (trxStatus == "0000")
                                {
                                    intTransCount++;

                                    strBankTransactionID = trnx.trxId;
                                    strTransactionDate = Convert.ToDateTime(trnx.trxTimestamp).ToString("dd-MMM-yyyy HH:mm:ss");//trnx.datetime;
                                    decTransferAmount = trnx.amount;
                                    //service
                                    strPayerNo = trnx.sender;
                                    strReceivingbKashNo = trnx.receiver;
                                    //currency
                                    strReferenceCode = trnx.reference;
                                    //counter
                                    //reversed


                                    if (strReceivingbKashNo == "1755686868")
                                        strBillerID = "200"; //for AgentBanking
                                    else
                                        strBillerID = "100"; //for RSF Services


                                    //Initialize SqlCommand
                                    sqlCmd_RASolarERP = new SqlCommand();
                                    sqlCmd_RASolarERP.Connection = sqlConn_RASolarERP;
                                    sqlCmd_RASolarERP.CommandTimeout = 3600;

                                    //Save data to Database
                                    sqlCmd_RASolarERP.CommandType = CommandType.StoredProcedure;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmPayerNo", SqlDbType.NVarChar).Value = strPayerNo;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmTransactionDate", SqlDbType.DateTime).Value = Convert.ToDateTime(strTransactionDate).ToString("dd-MMM-yyyy HH:mm:ss");
                                    sqlCmd_RASolarERP.Parameters.Add("@prmBillerID", SqlDbType.NVarChar).Value = strBillerID;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmReferenceCode", SqlDbType.NVarChar).Value = strReferenceCode;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmBankTransactionID", SqlDbType.NVarChar).Value = strBankTransactionID;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmTransferAmount", SqlDbType.Money).Value = decTransferAmount.ToString();
                                    sqlCmd_RASolarERP.Parameters.Add("@prmUserName", SqlDbType.NVarChar).Value = "bKashAPI";//strUserName;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmDBTransType", SqlDbType.Char).Value = "INSERT";

                                    sqlCmd_RASolarERP.Parameters.Add("@prmOutputResult", SqlDbType.TinyInt);
                                    sqlCmd_RASolarERP.Parameters["@prmOutputResult"].Direction = ParameterDirection.Output;
                                    sqlCmd_RASolarERP.CommandText = "[SP_RASolarERP_FundTransferReconciliation]"; //Convert.ToDateTime(strTransactionDate).ToString("yyyy-MM-dd HH:mm:ss.ffff")

                                    sqlCmd_RASolarERP.ExecuteNonQuery();
                                    intResult = Convert.ToInt32(sqlCmd_RASolarERP.Parameters["@prmOutputResult"].Value);
                                }
                            }
                        }

                        //if (strStatusCode == "200")
                        //{
                        //    ////isSMSSendSuccessful = "1";

                        //    ////INSERT INTO Sal_CollectionFromCustomers_SMSRegister
                        //    //queryForInsertTable = "INSERT INTO [SMSGateway_SMSToCustomerTransaction] ([CustomerCode],[CreatedOn],[CustomerName],[OverdueBalance],[OutstandingBalance],[SMSSentToMobileNo],[RecipientGroupID],[SMSBatchID]) ";
                        //    //queryForInsertTable += "VALUES('" + sourceRow["CustomerCode"].ToString() + "',GETDATE(),'" + sourceRow["RecipientName"].ToString() + "','" + sourceRow["ODBalanceUpToDate"].ToString().Trim() + "','" + sourceRow["OutstandingBalanceUpToDate"].ToString().Trim() + "','" + strRecipientMobileNo + "','ALLCUSTOMR','" + strSMSBatchTag + "')";

                        //    //sqlCmd_RASolarERP.CommandText = queryForInsertTable;
                        //    //sqlCmd_RASolarERP.ExecuteNonQuery(); // Temporarily comment
                        //}
                    }

                    //sqlTran_RASolarERP.Commit(); //Comment by ZIR as If any Problem in DB; SMS Fired but Log not writen
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();
                }
                catch (Exception)
                {
                    //sqlTran_RASolarERP.Rollback();
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();

                    throw;
                }
                if (intTransCount >= 0)
                {
                    //MessageBox.Show(intSMSCount.ToString().Trim() + " SMS has been sent successfully.", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.WriteProcessLog("\nTransaction: " + intTransCount.ToString().Trim() + " Transaction have been downloaded successfully.");
                }
                //else
                //{
                //    //MessageBox.Show("Failed to send SMS!", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.WriteProcessLog("\nSMS: Failed to send SMS!");
                //}
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.WriteProcessLog("\nbKash Error: " + ex.Message);
            }
        }
        private void SMART_Scheduler_DownloadDataFrombKashAPIforRRE()
        {
            //SqlTransaction sqlTran_RASolarERP;
            try
            {
                SqlConnection sqlConn_RASolarERP = new SqlConnection(strConnectionString_RASolarERP);
                sqlConn_RASolarERP.Open();

                string strQuery;

                string strStartDateTime = "2017-08-28 17:45:00";

                int intTransCount = 0;

                SqlCommand sqlCmd_RASolarERP = new SqlCommand();

                //sqlTran_RASolarERP = sqlConn_RASolarERP.BeginTransaction();

                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlCmd_RASolarERP.Connection = sqlConn_RASolarERP;// sqlTran_RASolarERP.Connection;
                //sqlCmd_RASolarERP.Transaction = sqlTran_RASolarERP;
                sqlCmd_RASolarERP.CommandTimeout = 3600;

                try
                {
                    if (this.lblUpToDateTimeRRE.Text == "...")
                    {
                        //Getting the Last Transaction DateTime
                        //sqlCmd_RASolarERP.CommandText = "SELECT TOP 1 CreatedOn FROM [Integration_MBanking_FundTransferTransactions] WHERE BillerID = '500' ORDER BY CreatedOn DESC";
                        sqlCmd_RASolarERP.CommandText = "SELECT TOP 1 TransactionDate CreatedOn FROM [Integration_MBanking_FundTransferTransactions] WHERE BillerID = '500' ORDER BY TransactionDate DESC";
                        //sqlCmd_RASolarERP.CommandText = "SELECT '2018-02-11 22:00:00.000' CreatedOn";

                        if (Convert.IsDBNull(sqlCmd_RASolarERP.ExecuteScalar()) == true | sqlCmd_RASolarERP.ExecuteScalar() == null)
                        {
                            //strResult = "299 Invalid Request for PackagePrice";
                            throw new Exception("Invalid Last Transaction DateTime!");
                        }
                        else
                        {
                            strStartDateTime = Convert.ToDateTime(sqlCmd_RASolarERP.ExecuteScalar().ToString()).AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss"); //Math.Round(Convert.ToDecimal(sqlCmd_RASolarERP.ExecuteScalar().ToString()));
                        }
                    }
                    else
                    {
                        //strStartDateTime = Convert.ToDateTime(this.lblUpToDateTime.Text.Substring(7, 19)).AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss");
                        strStartDateTime = Convert.ToDateTime(this.lblUpToDateTimeRRE.Text.Substring(7, 19)).AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss");
                        //strStartDateTime = Convert.ToDateTime("2018-02-10 12:15:00").AddMinutes(-5).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    if (Convert.ToDateTime(strStartDateTime) > DateTime.Now.AddMinutes(-25))
                    {
                        strStartDateTime = DateTime.Now.AddMinutes(-25).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    //this.lblUpToDateTime.Text = "Up to: " + Convert.ToDateTime(strStartDateTime).AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss");
                    this.lblUpToDateTimeRRE.Text = "Up to: " + Convert.ToDateTime(strStartDateTime).AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss");


                    string str2ndPartOfTheURL = "?user=RAHIMAFROOZRENEWABLEELTD&pass=R@hmafr0zr9wbl3&msisdn=01709954706&start_datetime=" + strStartDateTime + "&end_datetime=" + Convert.ToDateTime(strStartDateTime).AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss");//2017-08-27 18:12:00";

                    WebClient wc = new WebClient();
                    wc.Proxy = new WebProxy("10.96.1.25:8080");

                    wc.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                    var data = wc.DownloadString("https://www.bkashcluster.com:9081/dreamwave/merchant/trxcheck/periodicpullmsg" + str2ndPartOfTheURL);


                    JObject json = JObject.Parse(data);

                    //MBankTransaction objTransaction;

                    TransactionList objTransactionList = new TransactionList();

                    List<Transaction> objTransactions = new List<Transaction>();

                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    TransactionList transactions = jss.Deserialize<TransactionList>(data);

                    //string queryForInsertTable = "";
                    int intTransAtSourceCount = 0;

                    intTransAtSourceCount = transactions.Transaction.Count();
                    //int intResult = 0; //0 for Failed
                    string strBillerID = "";
                    string strStatusCode = "";
                    //string abc = transactions.
                    foreach (Transaction trnx in transactions.Transaction)
                    {
                        string strBankTransactionID = string.Empty;
                        string trxStatus = string.Empty;
                        string strTransactionDate = string.Empty;
                        string decTransferAmount = string.Empty;
                        string service = string.Empty;
                        string strPayerNo = string.Empty;
                        string strReceivingbKashNo = string.Empty;
                        string currency = string.Empty;
                        string strReferenceCode = string.Empty;
                        string counter = string.Empty;
                        string reversed = string.Empty;

                        if (trnx != null)
                        {
                            if (!string.IsNullOrEmpty(trnx.trxId))
                            {
                                if (!string.IsNullOrEmpty(trnx.trxStatus))
                                    trxStatus = trnx.trxStatus;

                                if (trxStatus == "0000")
                                {
                                    intTransCount++;

                                    strBankTransactionID = trnx.trxId;
                                    strTransactionDate = Convert.ToDateTime(trnx.trxTimestamp).ToString("dd-MMM-yyyy HH:mm:ss");//trnx.datetime;
                                    decTransferAmount = trnx.amount;
                                    //service
                                    strPayerNo = trnx.sender;
                                    strReceivingbKashNo = trnx.receiver;
                                    //currency
                                    strReferenceCode = trnx.reference;
                                    //counter
                                    //reversed


                                    //if (strReceivingbKashNo == "1755686868")
                                    //    strBillerID = "200"; //for AgentBanking
                                    //else
                                    strBillerID = "500"; //for RSF Services


                                    //Initialize SqlCommand
                                    sqlCmd_RASolarERP = new SqlCommand();
                                    sqlCmd_RASolarERP.Connection = sqlConn_RASolarERP;
                                    sqlCmd_RASolarERP.CommandTimeout = 3600;

                                    //Save data to Database
                                    sqlCmd_RASolarERP.CommandType = CommandType.StoredProcedure;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmPayerNo", SqlDbType.NVarChar, 15).Value = strPayerNo;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmTransactionDate", SqlDbType.DateTime).Value = Convert.ToDateTime(strTransactionDate).ToString("dd-MMM-yyyy HH:mm:ss");
                                    sqlCmd_RASolarERP.Parameters.Add("@prmBillerID", SqlDbType.NVarChar, 15).Value = strBillerID;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmReferenceCode", SqlDbType.NVarChar, 15).Value = strReferenceCode;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmBankTransactionID", SqlDbType.NVarChar, 15).Value = strBankTransactionID;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmTransferAmount", SqlDbType.Money).Value = decTransferAmount.ToString();
                                    sqlCmd_RASolarERP.Parameters.Add("@prmUserName", SqlDbType.NVarChar, 20).Value = "bKashAPI";//strUserName;
                                    sqlCmd_RASolarERP.Parameters.Add("@prmDBTransType", SqlDbType.Char, 6).Value = "INSERT";

                                    sqlCmd_RASolarERP.Parameters.Add("@prmOutputResult", SqlDbType.NVarChar, 50);
                                    sqlCmd_RASolarERP.Parameters["@prmOutputResult"].Direction = ParameterDirection.Output;
                                    sqlCmd_RASolarERP.CommandText = "[SP_3ESP_MBankIntegration]"; //Convert.ToDateTime(strTransactionDate).ToString("yyyy-MM-dd HH:mm:ss.ffff")

                                    sqlCmd_RASolarERP.ExecuteNonQuery();
                                    strStatusCode = sqlCmd_RASolarERP.Parameters["@prmOutputResult"].ToString();
                                }
                            }
                        }

                        //if (strStatusCode == "200")
                        //{
                        //    ////isSMSSendSuccessful = "1";

                        //    ////INSERT INTO Sal_CollectionFromCustomers_SMSRegister
                        //    //queryForInsertTable = "INSERT INTO [SMSGateway_SMSToCustomerTransaction] ([CustomerCode],[CreatedOn],[CustomerName],[OverdueBalance],[OutstandingBalance],[SMSSentToMobileNo],[RecipientGroupID],[SMSBatchID]) ";
                        //    //queryForInsertTable += "VALUES('" + sourceRow["CustomerCode"].ToString() + "',GETDATE(),'" + sourceRow["RecipientName"].ToString() + "','" + sourceRow["ODBalanceUpToDate"].ToString().Trim() + "','" + sourceRow["OutstandingBalanceUpToDate"].ToString().Trim() + "','" + strRecipientMobileNo + "','ALLCUSTOMR','" + strSMSBatchTag + "')";

                        //    //sqlCmd_RASolarERP.CommandText = queryForInsertTable;
                        //    //sqlCmd_RASolarERP.ExecuteNonQuery(); // Temporarily comment
                        //}
                    }

                    //sqlTran_RASolarERP.Commit(); //Comment by ZIR as If any Problem in DB; SMS Fired but Log not writen
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();
                }
                catch (Exception)
                {
                    //sqlTran_RASolarERP.Rollback();
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();

                    throw;
                }
                if (intTransCount >= 0)
                {
                    //MessageBox.Show(intSMSCount.ToString().Trim() + " SMS has been sent successfully.", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.WriteProcessLog("\nTransaction: " + intTransCount.ToString().Trim() + " Transaction have been downloaded successfully.");
                }
                this.WriteProcessLog("\nNo of Transactions: " + intTransCount.ToString().Trim() + ", StartTime: "+ strStartDateTime+", EndTime:"+ Convert.ToDateTime(strStartDateTime).AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss"));
                //else
                //{
                //    //MessageBox.Show("Failed to send SMS!", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.WriteProcessLog("\nSMS: Failed to send SMS!");
                //}
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.WriteProcessLog("\nbKash Error: " + ex.Message);
            }
        }

        //SparkMeter Mobile Money Integration
        private void CallSparkCloudAPIAgainstTheMobilePaymentsFromTheCustomers()
        {
            try
            {
                SqlConnection sqlConn_RASolarERP = new SqlConnection(strConnectionString_RASolarERP_RRERRN);
                sqlConn_RASolarERP.Open();

                SqlTransaction sqlTran_RASolarERP = null;

                string strQuery;
                int intTransCount = 0;

                SqlCommand sqlCmd_RASolarERP = new SqlCommand();
                SqlDataAdapter sqlDa = new SqlDataAdapter();
                DataSet ds = new DataSet();

                sqlCmd_RASolarERP.Connection = sqlConn_RASolarERP;
                //sqlCmd_RASolarERP.Transaction = sqlTran_RASolarERP;
                sqlCmd_RASolarERP.CommandTimeout = 3600;

                string strCustomerCode = null;
                string strMeterNo = null;
                string strMobileNumber = null;
                string strInternalID = string.Empty;
                string strVendorName = null;

                string strPaymentMode = "cash";

                string strRefPayerNo = string.Empty;
                string strRefBankTransDate = string.Empty;
                string strRefBankID = string.Empty;
                string strRefBankTransactionID = string.Empty;
                string strPaymentAmount = string.Empty;

                try
                {
                    //Getting the mobile payments made by Custommers ............................................................................................................
                    strQuery = "SELECT scri.[CustomerCode],scri.[MeterNo],scri.[MobileNumber],scri.[InternalId],scri.[VendorID],imbft.[PayerNo],imbft.[TransactionDate],imbft.[BankID],imbft.[BankTransactionID],imbft.[TransferAmount] ";
                    strQuery += "FROM [RASolarERP_RRERRN].[dbo].[SparkMeter_CustomerRegistrationInfo] scri INNER JOIN [RASolarERP_RRERRN].dbo.[Integration_MBanking_FundTransferTransactions] imbft ON scri.[CustomerCode] = imbft.[ReferenceCode] ";
                    strQuery += "LEFT OUTER JOIN [RASolarERP_RRERRN].[dbo].[SparkMeter_TransactionDetail] std ";
                    strQuery += "ON imbft.[PayerNo] = std.[RefPayerNo] AND imbft.[TransactionDate] = std.[RefBankTransDate] AND imbft.[BankID] = std.[RefBankID] AND imbft.[BankTransactionID] = std.[RefBankTransactionID] ";
                    strQuery += "WHERE std.[CustomerCode] IS NULL";

                    DataTable dtTable = new DataTable("Table");
                    ds.Tables.Add(dtTable);

                    sqlCmd_RASolarERP.CommandText = strQuery;
                    sqlDa.SelectCommand = sqlCmd_RASolarERP;
                    sqlDa.Fill(ds, "Table");
                    int intTotalRows = dtTable.Rows.Count;

                    if (intTotalRows > 0)
                    {
                        foreach (DataRow sourceRow in dtTable.Rows)
                        {
                            strCustomerCode = sourceRow["CustomerCode"].ToString();
                            strMeterNo = sourceRow["MeterNo"].ToString();
                            strMobileNumber = sourceRow["MobileNumber"].ToString();
                            strInternalID = sourceRow["InternalId"].ToString();
                            strVendorName = sourceRow["VendorID"].ToString();

                            strRefPayerNo = sourceRow["PayerNo"].ToString();
                            strRefBankTransDate = Convert.ToDateTime(sourceRow["TransactionDate"].ToString()).ToString("dd-MMM-yyyy HH:mm:ss");
                            strRefBankID = sourceRow["BankID"].ToString();
                            strRefBankTransactionID = sourceRow["BankTransactionID"].ToString();
                            strPaymentAmount = sourceRow["TransferAmount"].ToString();

                            if (strCustomerCode != null)
                            {
                                sqlTran_RASolarERP = sqlConn_RASolarERP.BeginTransaction();
                                try
                                {
                                    //Calling the SparkCloud API to Transfer the Payment to the Customer's Meter.....................................................................
                                    // Get Method for customer Info
                                    string strUri12 = null;
                                    string authenticationToken = null;
                                    if (strVendorName == "Bhola")
                                    {
                                        strUri12 = "https://sparkcloud-rahi-bhola.herokuapp.com/api/v0/customer/";
                                        authenticationToken = ".eJwNy7kNwDAIAMBdqIOEDTbxLFEK3v1HSK6_B8zWkshCd02UcxOaTkbaRiUjyMeBC1rYeo41O7pcvcW1s__rxRkM7wcFeBTg.DIbBEA.EbOs2uPJSpVXj_glrsNraftQAL0";
                                    }
                                    else if (strVendorName == "Rangabali")
                                    {
                                        strUri12 = "https://rahimafrooz-rangabali.sparkmeter.cloud/api/v0/customer/";
                                        authenticationToken = ".eJwFwckNwDAIALBdeBcJwhGYpeoHEvYfofYLS8q9wtGJC7VOYvlqZFIj85vRBQ9soaa0jstkukvOmMkOXjNHcuD7Ab8JEuk.DJr6Ew.GA54h1u6mute5teijCe3Hv_YbUQ";
                                    }
                                    string URLwithcustomerCode = strUri12 + strCustomerCode; //BM102 Customer Code

                                    string customerInfo = string.Empty;

                                    using (var client = new WebClient())
                                    {
                                        //client.Proxy = new WebProxy("10.96.1.25:8080");
                                        // Set the header so it knows we are sending JSON.
                                        client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";

                                        client.Headers.Add("Authentication-Token", authenticationToken);

                                        // Make the request
                                        var result = client.DownloadData(URLwithcustomerCode);
                                        customerInfo = Encoding.ASCII.GetString(result);
                                    }

                                    Customer objCustomer = new Customer();
                                    List<Customer> objTransactions = new List<Customer>();

                                    JavaScriptSerializer jss12 = new JavaScriptSerializer();
                                    GetCustomerInfo customers = jss12.Deserialize<GetCustomerInfo>(customerInfo);

                                    string Internal_id = string.Empty;

                                    foreach (Customer cst in customers.customers)
                                    {
                                        Internal_id = cst.id;
                                    }

                                    // API Calling Create Transaction Post Method
                                    string strUri = null;
                                    if (strVendorName == "Bhola")
                                    {
                                        strUri = "https://sparkcloud-rahi-bhola.herokuapp.com/api/v0/transaction/";
                                    }
                                    else if (strVendorName == "Rangabali")
                                    {
                                        strUri = "https://rahimafrooz-rangabali.sparkmeter.cloud/api/v0/transaction/";
                                    }

                                    Uri uri = new Uri(strUri);
                                    WebRequest request = WebRequest.Create(uri);
                                    request.Method = "POST";
                                    request.ContentType = "application/x-www-form-urlencoded";
                                    request.Headers.Add("Authentication-Token", authenticationToken);

                                    Guid obj = Guid.NewGuid();

                                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                                    string serOut = "customer_id=" + Internal_id + "&amount=" + strPaymentAmount + "&external_id=" + obj + "&source=" + strPaymentMode;

                                    using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                                    {
                                        writer.Write(serOut);
                                    }

                                    WebResponse responce = request.GetResponse();
                                    Stream reader = responce.GetResponseStream();

                                    StreamReader sReader = new StreamReader(reader);
                                    string outResult = sReader.ReadToEnd();
                                    sReader.Close();
                                    JObject json = JObject.Parse(outResult);

                                    JavaScriptSerializer jss = new JavaScriptSerializer();
                                    SMTransaction ctransaction = jss.Deserialize<SMTransaction>(outResult);

                                    //Send a Confirmation SMS to the Customer against the Recharge ...............................................................................
                                    this.SendAConfirmationSMSToTheCustomerForTheRecharge(strMobileNumber,strPaymentAmount);

                                    //Update SparkMeter Transaction Table ........................................................................................................
                                    //SqlConnection sqlConn_RASolarERP1 = null;
                                    //SqlTransaction sqlTran_RASolarERP1 = null;
                                    //try
                                    //{
                                    //intTransCount++;

                                    //sqlConn_RASolarERP1 = new SqlConnection(strConnectionString_RASolarERP_RRERRN);
                                    //sqlConn_RASolarERP1.Open();

                                    //string strQuery1;

                                    sqlCmd_RASolarERP = new SqlCommand();

                                    //sqlTran_RASolarERP1 = sqlConn_RASolarERP1.BeginTransaction();

                                    sqlCmd_RASolarERP.Connection = sqlTran_RASolarERP.Connection;
                                    sqlCmd_RASolarERP.Transaction = sqlTran_RASolarERP;
                                    sqlCmd_RASolarERP.CommandTimeout = 3600;

                                    strQuery = "INSERT INTO dbo.[SparkMeter_TransactionDetail] ([TransactionID],[MeterNo],[CustomerCode],[TransDate],[TransactionAmount],[TransactionSource],[PaymentMadeBy],[RefPayerNo],[RefBankTransDate],[RefBankID],[RefBankTransactionID],[Status],[CreatedBy],[CreatedOn]) ";
                                    strQuery += "VALUES('" + ctransaction.transaction_id + "','" + strMeterNo + "','" + strCustomerCode + "',GETDATE(),'" + strPaymentAmount + "','API','" + strCustomerCode + "','" + strRefPayerNo + "','" + strRefBankTransDate + "','" + strRefBankID + "','" + strRefBankTransactionID + "',0,'Admin',GETDATE())";
                                    
                                    //strQuery = "INSERT INTO dbo.[SparkMeter_TransactionDetail] ([TransactionID],[MeterNo],[CustomerCode],[TransDate],[TransactionAmount],[TransactionSource],[PaymentMadeBy],[UsedMobAC],[RefBankID],[RefBankTransactionID],[Status],[CreatedBy],[CreatedOn]) ";
                                    //strQuery += "VALUES('" + strBankTransactionID + "','SL123456','" + strCustomerCode + "',GETDATE(),'" + strPaymentAmount + "','API','" + strCustomerCode + "','01755688789','" + strBankID + "','" + strBankTransactionID + "',0,'Admin',GETDATE())";

                                    sqlCmd_RASolarERP.CommandText = strQuery;
                                    sqlCmd_RASolarERP.ExecuteNonQuery();

                                    sqlTran_RASolarERP.Commit();
                                    //sqlConn_RASolarERP1.Close();
                                    //sqlConn_RASolarERP1.Dispose();

                                    intTransCount++;
                                } //End of Try For a single Payment
                                catch (Exception ex0)
                                {
                                    sqlTran_RASolarERP.Rollback();
                                    //sqlConn_RASolarERP1.Close();
                                    //sqlConn_RASolarERP1.Dispose();

                                    //throw;
                                    this.WriteProcessLog("\nSparkMeter Error for Trx: "+strRefBankTransactionID+", Error: " + ex0.Message);
                                    //No Further Action and go for the Next Payment
                                }
                            } //End of [if strCustomerCode]

                        } //End of [foreach]

                    }//End of If [for recordCount > 0]

                    //sqlTran_RASolarERP.Commit();
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();

                    if (intTransCount >= 0)
                    {
                        //MessageBox.Show(intSMSCount.ToString().Trim() + " SMS has been sent successfully.", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.WriteProcessLog("\nSparkMeter: " + intTransCount.ToString().Trim() + " out of " + intTotalRows.ToString().Trim() + " payments have been done successfully.");
                    }
                }
                catch (Exception)
                {
                    //sqlTran_RASolarERP.Rollback();
                    sqlConn_RASolarERP.Close();
                    sqlConn_RASolarERP.Dispose();

                    throw;
                }





                //if (strCustomerCode != null)
                //{
                //    // Get Method for customer Info
                //    string strUri12 = null;
                //    string authenticationToken = null;
                //    if (strVendorName == "Bhola")
                //    {
                //        strUri12 = "https://sparkcloud-rahi-bhola.herokuapp.com/api/v0/customer/";
                //        authenticationToken = ".eJwNy7kNwDAIAMBdqIOEDTbxLFEK3v1HSK6_B8zWkshCd02UcxOaTkbaRiUjyMeBC1rYeo41O7pcvcW1s__rxRkM7wcFeBTg.DIbBEA.EbOs2uPJSpVXj_glrsNraftQAL0";
                //    }
                //    else if (strVendorName == "Rangabali")
                //    {
                //        strUri12 = "https://rahimafrooz-rangabali.sparkmeter.cloud/api/v0/customer/";
                //        authenticationToken = ".eJwFwckNwDAIALBdeBcJwhGYpeoHEvYfofYLS8q9wtGJC7VOYvlqZFIj85vRBQ9soaa0jstkukvOmMkOXjNHcuD7Ab8JEuk.DJr6Ew.GA54h1u6mute5teijCe3Hv_YbUQ";
                //    }
                //    string URLwithcustomerCode = strUri12 + strCustomerCode; //BM102 Customer Code

                //    string customerInfo = string.Empty;

                //    using (var client = new WebClient())
                //    {
                //        //client.Proxy = new WebProxy("10.96.1.25:8080");
                //        // Set the header so it knows we are sending JSON.
                //        client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";

                //        client.Headers.Add("Authentication-Token", authenticationToken);

                //        //client.Headers.Add("password", "1234");

                //        // Make the request
                //        var result = client.DownloadData(URLwithcustomerCode);
                //        customerInfo = Encoding.ASCII.GetString(result);

                //    }

                //    Customer objCustomer = new Customer();
                //    List<Customer> objTransactions = new List<Customer>();

                //    JavaScriptSerializer jss12 = new JavaScriptSerializer();
                //    GetCustomerInfo customers = jss12.Deserialize<GetCustomerInfo>(customerInfo);

                //    string Internal_id = string.Empty;

                //    foreach (Customer cst in customers.customers)
                //    {
                //        Internal_id = cst.id;
                //    }

                //    // API Calling Create Transaction Post Method
                //    string strUri = null;
                //    if (strVendorName == "Bhola")
                //    {
                //        strUri = "https://sparkcloud-rahi-bhola.herokuapp.com/api/v0/transaction/";
                //    }
                //    else if (strVendorName == "Rangabali")
                //    {
                //        strUri = "https://rahimafrooz-rangabali.sparkmeter.cloud/api/v0/transaction/";
                //    }

                //    Uri uri = new Uri(strUri);
                //    WebRequest request = WebRequest.Create(uri);
                //    request.Method = "POST";
                //    request.ContentType = "application/x-www-form-urlencoded";
                //    request.Headers.Add("Authentication-Token", authenticationToken);

                //    Guid obj = Guid.NewGuid();

                //    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                //    string serOut = "customer_id=" + Internal_id + "&amount=" + strPaymentAmount + "&external_id=" + obj + "&source=" + strPaymentMode;

                //    using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                //    {
                //        writer.Write(serOut);
                //    }

                //    WebResponse responce = request.GetResponse();
                //    Stream reader = responce.GetResponseStream();

                //    StreamReader sReader = new StreamReader(reader);
                //    string outResult = sReader.ReadToEnd();
                //    sReader.Close();
                //    JObject json = JObject.Parse(outResult);

                //    JavaScriptSerializer jss = new JavaScriptSerializer();
                //    SMTransaction ctransaction = jss.Deserialize<SMTransaction>(outResult);




                //    // Saving Transaction data to table
                //    SqlConnection sqlConn_RASolarERP1=null;
                //    SqlTransaction sqlTran_RASolarERP1=null;

                //    try
                //    {
                //        intTransCount++;

                //        sqlConn_RASolarERP1 = new SqlConnection(strConnectionString_RASolarERP_RRERRN);
                //        sqlConn_RASolarERP1.Open();

                //        string strQuery1;

                //        SqlCommand sqlCmd_RASolarERP1 = new SqlCommand();

                //       sqlTran_RASolarERP1 = sqlConn_RASolarERP1.BeginTransaction();

                //        sqlCmd_RASolarERP1.Connection = sqlTran_RASolarERP1.Connection;
                //        sqlCmd_RASolarERP1.Transaction = sqlTran_RASolarERP1;
                //        sqlCmd_RASolarERP1.CommandTimeout = 3600;

                //        strQuery1 = "INSERT INTO dbo.[Spark_TransactionDetail] ([TransactionID],[MeterNo],[CustomerCode],[TransDate],[TransactionAmount],[TransactionSource],[PaymentMadeBy],[UsedMobAC],[RefBankID],[RefBankTransactionID],[Status],[CreatedBy],[CreatedOn]) ";
                //        strQuery1 += "VALUES('" + ctransaction.transaction_id + "','SL123456','" + strCustomerCode + "',GETDATE(),'" + strPaymentAmount + "','API','" + strCustomerCode + "','01755688789','" + strBankID + "','" + strBankTransactionID + "',0,'Admin',GETDATE())";

                //        sqlCmd_RASolarERP1.CommandText = strQuery1;
                //        sqlCmd_RASolarERP1.ExecuteNonQuery();


                //        sqlTran_RASolarERP1.Commit();
                //        sqlConn_RASolarERP1.Close();
                //        sqlConn_RASolarERP1.Dispose();
                //    }

                //    catch (Exception)
                //    {
                //        sqlTran_RASolarERP1.Rollback();
                //        sqlConn_RASolarERP1.Close();
                //        sqlConn_RASolarERP1.Dispose();

                //        throw;
                //    }
                //} //End of [if strCustomerCode]

                //if (intTransCount >= 0)
                //{
                //    //MessageBox.Show(intSMSCount.ToString().Trim() + " SMS has been sent successfully.", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.WriteProcessLog("\nSparkMeter: " + intTransCount.ToString().Trim() + " Payment have been done successfully.");
                //}
                //else
                //{
                //    //MessageBox.Show("Failed to send SMS!", "RASolarERP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.WriteProcessLog("\nSMS: Failed to send SMS!");
                //}
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.WriteProcessLog("\nSparkMeter Error: " + ex.Message);
            }
        }
        private void SendAConfirmationSMSToTheCustomerForTheRecharge(string strRecipientMobileNo, string strPaymentAmount)
        {
            SqlConnection sqlConn_RASolarERP = null;
            SqlTransaction sqlTran_RASolarERP = null;
            string strResult = "299 Failed"; //299 for Failed

            try
            {
                sqlConn_RASolarERP = new SqlConnection(strConnectionString_RASolarERP_RRERRN);
                sqlConn_RASolarERP.Open();

                sqlTran_RASolarERP = sqlConn_RASolarERP.BeginTransaction();

                string strQuery;
                int intSMSCount = 0;

                SqlCommand sqlCmd_RASolarERP = new SqlCommand();

                sqlCmd_RASolarERP.Connection = sqlTran_RASolarERP.Connection;
                sqlCmd_RASolarERP.Transaction = sqlTran_RASolarERP;
                sqlCmd_RASolarERP.CommandTimeout = 3600;

                //strQuery = "SELECT LTRIM(RTRIM(STR(ROUND(CASE WHEN cs.OverdueOrAdvanceBalanceUpToDate < 0 THEN cs.OverdueOrAdvanceBalanceUpToDate*-1 ELSE 0 END,0)))) ODBalanceUpToDate, ";
                //strQuery += "LTRIM(RTRIM(STR(ROUND(cs.OutstandingBalanceUpToDate,0)))) OutstandingBalanceUpToDate, ";
                //strQuery += "'01755688789' [RecipientMobileNo], ";
                //strQuery += "cfcexpp.[YearMonth],cfcexpp.[SerialNo], ";
                //strQuery += "cfcexpp.[CollectionAmount],CONVERT(NVARCHAR,cfcexpp.[CollectionDate],103) [CollectionDate] ";
                //strQuery += "FROM Sal_Customer c INNER JOIN Sal_SalesAgreement sa ON c.CustomerCode = sa.CustomerCode INNER JOIN Sal_CustomerStatus cs ON c.CustomerCode = cs.CustomerCode ";
                //strQuery += "LEFT OUTER JOIN (SELECT * FROM Sal_CollectionFromCustomersPrePost ";
                //strQuery += "   WHERE [CustomerCode] = '" + strCustomerCode + "' AND [CashMemoNo] = '" + strCashMemoNo + "' AND [IsTransferredToFinalTable] = 1) cfcexpp ON cfcexpp.CustomerCode = c.CustomerCode ";
                //strQuery += "WHERE c.CustomerCode = '" + strCustomerCode + "'";

                //sqlCmd_RASolarERP.CommandText = strQuery;

                //SqlDataAdapter sqlDa = new SqlDataAdapter();
                //DataSet ds = new DataSet();
                //DataTable dtTable = new DataTable("Table");
                //ds.Tables.Add(dtTable);
                //sqlCmd_RASolarERP.CommandType = CommandType.Text;

                //sqlDa.SelectCommand = sqlCmd_RASolarERP;
                //sqlDa.Fill(ds, "Table");
                //int intTotalRows = dtTable.Rows.Count;
                //if (intTotalRows > 0)
                //{
                string str2ndPartOfTheURL = "";
                string strAPIReturnedResult = "";
                string strStatusCode = "";
                //    string strRecipientMobileNo = "";
                string strMessageText = "";

                //    string queryForInsertTable = "";

                //    int intRowCount = 0;
                //    foreach (DataRow sourceRow in dtTable.Rows)
                //    {
                //intRowCount++;
                //strRecipientMobileNo = sourceRow["RecipientMobileNo"].ToString().Trim();

                if (strRecipientMobileNo.Length == 11)
                {
                    intSMSCount++;

                    //strMessageText = "Prio Grahok, Apnar dea " + strPaymentAmount.Trim() + " taka " + sourceRow["CollectionDate"].ToString().Trim() + " tarikhe MemoNo " + strCashMemoNo + " er madhome RSF e joma hoese. Bortomane Apnar mot bokea taka " + sourceRow["ODBalanceUpToDate"].ToString().Trim() + ", bokea shoho mot paona " + sourceRow["OutstandingBalanceUpToDate"].ToString().Trim() + ". Apnake Onek Dhonnobad.";
                    strMessageText = "Shommanito Grahok, Apnar dea " + strPaymentAmount.Trim() + " taka apnar meter e shofol bhabe recharge kora hoyeche. Apnake Onek Dhonnobad.";
                    str2ndPartOfTheURL = "?username=RSFadmin&password=Rsf@Admin123&apicode=1&msisdn=" + strRecipientMobileNo + "&countrycode=880&cli=RSF&messagetype=1&message=" + strMessageText + "&messageid=0";

                    System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender1, certificate, chain, sslPolicyErrors) => true);

                    WebClient client1 = new WebClient();
                    client1.Proxy = new WebProxy("10.96.1.25:8080");

                    string url = "https://cmp.grameenphone.com/gpcmpapi/messageplatform/controller.home" + str2ndPartOfTheURL;

                    Byte[] requestedHTML;
                    requestedHTML = client1.DownloadData(url);

                    UTF8Encoding objUTF8 = new UTF8Encoding();
                    strAPIReturnedResult = objUTF8.GetString(requestedHTML);

                    strStatusCode = strAPIReturnedResult.Substring(0, 3);

                    if (strStatusCode == "200")
                    {
                        ////INSERT INTO Sal_CollectionFromCustomers_SMSRegister
                        //queryForInsertTable = "UPDATE dbo.[SparkMeter_TransactionDetail] SET ([CustomerCode],[YearMonth],[SerialNo],[SMSSentToMobileNo],[SMSSentOn],[RecipientGroupID]) ";
                        //queryForInsertTable += "VALUES('" + strCustomerCode + "','" + sourceRow["YearMonth"].ToString() + "','" + sourceRow["SerialNo"].ToString() + "','" + strRecipientMobileNo + "',GETDATE(),'INDVCUSTMR')";

                        //sqlCmd_RASolarERP.CommandText = queryForInsertTable;
                        //sqlCmd_RASolarERP.ExecuteNonQuery();
                    }
                    else
                    {
                        strQuery = "EXEC [SP_SendDBEmailAsText] 'ERROR_FROM_CMP','zillur.rahman@rsf-bd.org','Error from GP CMP for SparkMeter','GP CMP: 217,Number Barred'";

                        sqlCmd_RASolarERP.CommandText = strQuery;
                        sqlCmd_RASolarERP.ExecuteNonQuery();
                    }
                    strResult = strAPIReturnedResult;
                }
                //}
                //}

                sqlTran_RASolarERP.Commit();
                sqlConn_RASolarERP.Close();
                sqlConn_RASolarERP.Dispose();
            }
            catch (Exception ex)
            {
                sqlTran_RASolarERP.Rollback();
                sqlConn_RASolarERP.Close();
                sqlConn_RASolarERP.Dispose();

                //string strMessageText;
                //strMessageText = ex.Message.Trim();

                //this.WriteErrorLog("\nERROR:from RASolarERP_CollectionManager_SendAConfirmationSMSForTheCollectionToTheCustomer_Event Ref: TransNo " + GetErrorEndingString("strTransactionNo"));
                //this.WriteErrorLog(strMessageText);
                this.WriteProcessLog("\nSMS Error: " + ex.Message);

                //strResult = "277 " + strMessageText;
            }
            //return strResult;
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkAuto.Text = "Download Auto?";
                this.chkAuto.Refresh();
                this.timer1.Stop();
                this.timer1.Interval = 1000 * 30;
                this.cIntTimerTickNo = 0;
                this.NumericUpDown1.Enabled = this.chkAuto.Checked;
                this.lblTickNo2.Text = "...";
                this.lblLastUpdate2.Text = "...";
                this.lblNextUpdate2.Text = "...";

                if (this.chkAuto.Checked)
                {
                    cStrDownloadType = "AUTO";
                }
                else
                {
                    cStrDownloadType = "MANUAL";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void WriteProcessLog(string strLogText)
        {
            try
            {
                this.listBox1.Items.Insert(0, (strLogText));
                this.listBox1.Items.Insert(0, ((" :").PadLeft(110, '-') + cIntProcessID.ToString().Trim()));
                cIntProcessID += 1;
                this.listBox1.Refresh();

                FileStream fsProcessLog = new FileStream("ProcessLog-" + DateTime.Today.ToString("yyyy-MMMM") + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sProcessLog = new StreamWriter(fsProcessLog);
                sProcessLog.BaseStream.Seek(0, SeekOrigin.End);
                sProcessLog.WriteLine(strLogText);
                //sProcessLog.WriteLine((" :").PadLeft(100, "-") + (cIntProcessID - 1).ToString.Trim);
                sProcessLog.Close();

                if (strLogText.Substring(0, 5) == "ERROR")
                {
                    this.WriteErrorLog("\n" + strLogText);
                }
            }
            catch
            {
                throw;
            }
        }
        private void WriteErrorLog(string strLogText)
        {
            try
            {
                FileStream fsProcessLog = new FileStream("ErrorLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sProcessLog = new StreamWriter(fsProcessLog);
                sProcessLog.BaseStream.Seek(0, SeekOrigin.End);
                sProcessLog.WriteLine(strLogText);
                sProcessLog.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //''Throw 'No where to send
            }
        }
        private string GetErrorEndingString()
        {
            return "[Date: " + DateTime.Now.ToString().Trim() + ", Download ID: " + cIntDownloadID.ToString().Trim() + "]";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.SMART_Scheduler_DownloadDataFrombKashAPI();
            //this.CallSparkCloudAPIAgainstTheMobilePaymentsFromTheCustomers();
            this.SMART_Scheduler_DownloadDataFrombKashAPIforRRE();
        }
    } // End of Class

    public class TransactionList
    {
        public List<Transaction> Transaction { get; set; }
    }

    public class Transaction
    {
        public string trxId { get; set; }
        public string trxStatus { get; set; }
        public string trxTimestamp { get; set; }
        public string amount { get; set; }
        public string service { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string currency { get; set; }
        public string reference { get; set; }
        public string counter { get; set; }
        public string reversed { get; set; }
    }
} // End of Namespace
