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

namespace SMART_Scheduler
{
    public partial class SMART_Scheduler_HourInterval : Form
    {
        //string strConnectionString_WAnaSoft;
        string strConnectionString_3ESP;
        DataSet ds = new DataSet();

        string cStrDownloadState;
        //string cStrDeviceID;
        //string cStrDeviceDesc;
        int cIntTimerTickNo;
        //short cIntConnectionState;
        int cIntProcessID;
        //int cIntNoOfUsers;
        //int cIntNoOfLogs;
        bool cBoolIsLogCleared;
        bool cBoolIsLogArchived;
        string cStrDownloadType;
        int cIntDownloadID;

        public SMART_Scheduler_HourInterval()
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

                string str3ESPServerName = "10.96.1.11\\RSFERP_LIVE";//System.Configuration.ConfigurationManager.AppSettings["ServerName"];
                string str3ESPDatabase = "3ESP";//System.Configuration.ConfigurationManager.AppSettings["Database"];
                string str3ESPUserName = "THREEESP";//System.Configuration.ConfigurationManager.AppSettings["UserName"];
                string str3ESPPassword = "vnght45113ESPfrsfrre";//System.Configuration.ConfigurationManager.AppSettings["Password"];

                //string str3ESPUserName = "ETL_3ESP_WAnaSoft_Bridge";//System.Configuration.ConfigurationManager.AppSettings["UserName"];
                //string str3ESPPassword = "rsferpWAnaSoft";//System.Configuration.ConfigurationManager.AppSettings["Password"];

                //this.toolStripStatusLabel1.Text = "Server name: " + strServerName;
                //this.toolStripStatusLabel2.Text = "Database: " + strDatabase;
                //this.statusStrip1.Refresh();

                //strConnectionString_WAnaSoft = "Data Source=" + strWAnaSoftServerName + ";Initial Catalog=" + strWAnaSoftDatabase + ";Persist Security Info=True;User ID=" + strWAnaSoftUserName + ";Password=" + strWAnaSoftPassword;
                strConnectionString_3ESP = "Data Source=" + str3ESPServerName + ";Initial Catalog=" + str3ESPDatabase + ";Persist Security Info=True;User ID=" + str3ESPUserName + ";Password=" + str3ESPPassword;

                //this.cboDisbursementNo.SelectedIndex = 0;
                //string strSameDateLastMonth = String.Format("{0:dd-MMM-yy}", this.startDTP.Value.AddMonths(-1));

                //this.startDTP.Value = Convert.ToDateTime("01" + strSameDateLastMonth.Substring(2,7));
                //this.endDTP.Value = this.endDTP.Value.AddDays(this.endDTP.Value.Day * -1);

                cStrDownloadType = "AUTO";
                //this.chkAuto.Checked = false;

                cIntTimerTickNo = 0;
                cIntProcessID = 1;
                cIntDownloadID = 0;

                cBoolIsLogCleared = false;
                cBoolIsLogArchived = false;

                //this.timer1.Interval = 1000 * 30; //Me.NumericUpDown1.Value '1 Second x 60 Second x 5 = 5 Minutes
                ////Me.NumericUpDown1.Enabled = False
                //this.timer1.Start();

                ////StartDownloadDeliveryFromWAnaSoftNUpdate3ESP();

                //this.Width = 1520;
                //this.Height = 920;
            }
            catch (Exception ex)
            {
                this.WriteErrorLog("\nERROR #101: from Scheduler_Load_Event " + GetErrorEndingString());
                this.WriteErrorLog(ex.Message);
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnON_Click(object sender, EventArgs e)
        {
            //this.label16.Text = "Hello World";
            try
            {
                DateTime dtCurrentTime = DateTime.Now;
                DateTime dtFirstTickExecutionTime = dtCurrentTime.AddHours(1).AddMinutes(-dtCurrentTime.Minute).AddSeconds(-dtCurrentTime.Second);// new DateTime(2016, 10, 16, 17, 05, 00);

                //string strNextUpdateTime = "";
                if (this.chkAuto.Checked)
                {
                    this.chkAuto.Text = "Scheduler is ON...";
                    this.chkAuto.Refresh();
                    //strNextUpdateTime = DateTime.Now.AddMinutes(Convert.ToDouble(this.NumericUpDown1.Value)).ToString();

                    cIntTimerTickNo = 0; // 0 Because No Instant Run

                    //Interval for the Next Run in a Rounded Clock Time
                    this.timer1.Interval = Convert.ToInt32(dtFirstTickExecutionTime.Subtract(dtCurrentTime).TotalMilliseconds);//Convert.ToInt32(1000 * 60 * 5); //1 Second (1000 Mili Second) x 60 Seconds x 5 Minutes = 5 Minute

                    this.NumericUpDown1.Enabled = false;

                    this.timer1.Start();
                }

                ////Starting the process of downloading and updating tables (for Instant Run)
                //this.DoTheJob();

                if (this.chkAuto.Checked)
                {
                    if (cIntTimerTickNo > 0)
                    {
                        this.lblTickNo2.Text = cIntTimerTickNo.ToString().Trim();
                        this.lblLastUpdate2.Text = dtCurrentTime.ToString("dd-MMM-yyyy HH:mm:ss");
                    }
                    this.lblNextUpdate2.Text = dtFirstTickExecutionTime.ToString("dd-MMM-yyyy HH:mm:ss");//strNextUpdateTime;
                    this.lblNextUpdate2.Refresh();
                    //this.label16.Text = "Hello World";
                    //this.lblNextUpdate2.Text = "Hello World1";
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

                //Starting the process of downloading and updating tables (Recurring Run)
                this.RunTheProcesses();

                this.lblTickNo2.Text = cIntTimerTickNo.ToString().Trim();
                this.lblLastUpdate2.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
                //this.lblNextUpdate2.Text = DateTime.Now.AddMinutes(5).ToString();//strNextUpdateTime;

                if (cIntTimerTickNo == 1)
                {
                    //this.timer1.Interval = Convert.ToInt32(1000 * 60 * 60 * 24); //1 Second (1000 Mili Second) x 60 Seconds x 60 Minutes x 24 Hours = 1 Day
                    //Interval for the Next Run in a Regular 1 Hour Schedule
                    this.timer1.Interval = Convert.ToInt32(1000 * 60 * 60 * 1); //1 Second (1000 Mili Second) x 60 Seconds x 60 Minutes x 1 Hours = 1 Hour
                    //this.timer1.Interval = Convert.ToInt32(1000 * 60 * 5); //1 Second (1000 Mili Second) x 60 Seconds x 5 Minutes = 5 Minute
                }
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

            cStrDownloadState = "Start";
            this.lblStatus.Text = "Processing data, please wait...";
            this.lblStatus.Refresh();


            //SqlTransaction sqlTran_3ESP;
            try
            {
                //Make Connection to the TCDBridge Database
                //this.WriteProcessLog("\nConnecting to the 3ESP Database");
                SqlConnection sqlConn_3ESP = new SqlConnection(strConnectionString_3ESP);
                sqlConn_3ESP.Open();
                this.WriteProcessLog("\nConnected to the 3ESP Database successfully.");

                string strQuery;
                SqlCommand sqlCmd_3ESP = new SqlCommand();

                //sqlTran_3ESP = sqlConn_3ESP.BeginTransaction();

                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlCmd_3ESP.Connection = sqlConn_3ESP;//sqlTran_3ESP.Connection;
                //sqlCmd_3ESP.Transaction = sqlTran_3ESP;
                sqlCmd_3ESP.CommandTimeout = 3600;

                try
                {
                    try
                    {
                        this.WriteProcessLog("\nSending Scheduled Mail");
                        sqlCmd_3ESP.CommandText = "EXEC [SP_SMART_Scheduler_SendScheduledMail]";
                        sqlCmd_3ESP.ExecuteNonQuery();
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

                    //try [Comment by ZIR on 19-Jun-2018 as now SMS Currently required]
                    //{
                    //    this.WriteProcessLog("\nSending Scheduled SMS");
                    //    //this.SMART_Scheduler_SendScheduledSMS("DAILYMORSMS2CUST");
                    //    //this.SMART_Scheduler_SendScheduledSMS("DAILYEVESMS2CUST");
                    //    this.SMART_Scheduler_SendScheduledSMS("SMS_TO_UDDOKTA_FOR_PO_CONFIRMATION");
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
                    //        this.WriteProcessLog("\nERROR for SMS: " + ex0.Message);
                    //        //this.WriteErrorLog(ex0.Message); //Auto written by process log using the tag ERROR
                    //    }
                    //}

                    try
                    {
                        this.WriteProcessLog("\nCreating Alarm Log");
                        strQuery = "INSERT INTO [SMART_Scheduler_AlarmLog] ([AlarmExecutionDate],[TimerTickNo],[ExecutedOn]) VALUES(";
                        strQuery += "GETDATE()," + cIntTimerTickNo.ToString() + ",GETDATE())";
                        sqlCmd_3ESP.CommandText = strQuery;
                        sqlCmd_3ESP.ExecuteNonQuery();
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

                    //sqlTran_3ESP.Commit();
                    sqlConn_3ESP.Close();
                    sqlConn_3ESP.Dispose();
                }
                catch (Exception)
                {
                    //sqlTran_3ESP.Rollback();
                    sqlConn_3ESP.Close();
                    sqlConn_3ESP.Dispose();
                    throw;
                }

                cStrDownloadState = "Completed";
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
            //SqlTransaction sqlTran_3ESP;
            try
            {
                SqlConnection sqlConn_3ESP = new SqlConnection(strConnectionString_3ESP);
                sqlConn_3ESP.Open();

                string strQuery;
                //string strSMSBatchTag = "DAILYEVESMS2CUST";//"MissingCollectionSummaryReport_ToAllUM";//"TESTBANGLASMS";//"C_D_OD_Customer";

                int intSMSCount = 0;

                SqlCommand sqlCmd_3ESP = new SqlCommand();

                //sqlTran_3ESP = sqlConn_3ESP.BeginTransaction();

            
                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlCmd_3ESP.Connection = sqlConn_3ESP;// sqlTran_3ESP.Connection;
                //sqlCmd_3ESP.Transaction = sqlTran_3ESP;
                sqlCmd_3ESP.CommandTimeout = 3600;

                try
                {
                    DataSet ds = new DataSet();

                    strQuery = "EXEC [REP_SMSGateway_GetCustomersToSendSMS] '" + strSMSBatchTag + "'";

                    DataTable dtTable = new DataTable("Table");
                    ds.Tables.Add(dtTable);

                    sqlCmd_3ESP.CommandText = strQuery;
                    //sqlCmd_3ESP.Connection = sqlConn_3ESP;
                    sqlDa.SelectCommand = sqlCmd_3ESP;
                    sqlDa.Fill(ds, "Table");
                    int intTotalRows = dtTable.Rows.Count;
                    if (intTotalRows == 0)
                    {
                        //MessageBox.Show("No data found, please try again changing the selection criteria.", "3ESP Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                        else if (strSMSBatchTag == "SMS_TO_UDDOKTA_FOR_PO_CONFIRMATION")
                        {
                            strMessageText = "Prio " + strRecipientName + ", Agami Kal Apnar PO Confirmation Er Din. Pryojonio Load Nin Ebong PO Dear Prostuti Nin. Apnar Shafollo Kamona Korsi. Dhonnobad";
                            //strMessageText = "Prio " + strRecipientName + ", Aj Apnar PO Confirmation Er Din. Pryojonio Load Nin Ebong PO Dear Prostuti Nin. Apnar Shafollo Kamona Korsi. Dhonnobad";
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

                            if (strSMSBatchTag == "DAILYMORSMS2CUST" || strSMSBatchTag == "DAILYEVESMS2CUST")
                            {
                                //INSERT INTO Sal_CollectionFromCustomers_SMSRegister
                                queryForInsertTable = "INSERT INTO [SMSGateway_SMSToCustomerTransaction] ([CustomerCode],[CreatedOn],[CustomerName],[OverdueBalance],[OutstandingBalance],[SMSSentToMobileNo],[RecipientGroupID],[SMSBatchID]) ";
                                queryForInsertTable += "VALUES('" + sourceRow["CustomerCode"].ToString() + "',GETDATE(),'" + sourceRow["RecipientName"].ToString() + "','" + sourceRow["ODBalanceUpToDate"].ToString().Trim() + "','" + sourceRow["OutstandingBalanceUpToDate"].ToString().Trim() + "','" + strRecipientMobileNo + "','ALLCUSTOMR','" + strSMSBatchTag + "')";

                                sqlCmd_3ESP.CommandText = queryForInsertTable;
                                sqlCmd_3ESP.ExecuteNonQuery(); // Temporarily comment
                            }
                            else if (strSMSBatchTag == "SMS_TO_UDDOKTA_FOR_PO_CONFIRMATION")
                            {
                                //INSERT INTO Sal_CollectionFromCustomers_SMSRegister
                                queryForInsertTable = "INSERT INTO [SMSGateway_SMSToEmployeeTransaction] ([EmployeeID],[CreatedOn],[EmployeeName],[SMSSentToMobileNo],[RecipientGroupID],[SMSBatchID],[EmployeeLocationCode],[IsSMSSendSuccessful]) ";
                                queryForInsertTable += "VALUES('" + sourceRow["EmployeeID"].ToString() + "',GETDATE(),'" + sourceRow["RecipientName"].ToString() + "','" + strRecipientMobileNo + "','ALLUNITMAN','" + strSMSBatchTag + "','" + sourceRow["LocationCode"].ToString() +"',1)";

                                sqlCmd_3ESP.CommandText = queryForInsertTable;
                                sqlCmd_3ESP.ExecuteNonQuery(); // Temporarily comment
                            }
                        }
                    }

                    //sqlTran_3ESP.Commit(); //Comment by ZIR as If any Problem in DB; SMS Fired but Log not writen
                    sqlConn_3ESP.Close();
                    sqlConn_3ESP.Dispose();

                }
                catch (Exception)
                {
                    //sqlTran_3ESP.Rollback();
                    sqlConn_3ESP.Close();
                    sqlConn_3ESP.Dispose();

                    throw;
                }
                if (intSMSCount > 0)
                {
                    //MessageBox.Show(intSMSCount.ToString().Trim() + " SMS has been sent successfully.", "3ESP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.WriteProcessLog("\nSMS: " + intSMSCount.ToString().Trim() + " SMS has been sent successfully.");
                }
                else
                {
                    //MessageBox.Show("Failed to send SMS!", "3ESP Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.WriteProcessLog("\nSMS: Failed to send SMS!");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.WriteProcessLog("\nSMS Error: " + ex.Message);
            }
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
            //this.label16.Text = "Hello World";
            try
            {
                DateTime dtCurrentTime = DateTime.Now;
                DateTime dtFirstTickExecutionTime = dtCurrentTime.AddHours(1).AddMinutes(-dtCurrentTime.Minute).AddSeconds(-dtCurrentTime.Second);// new DateTime(2016, 10, 16, 17, 05, 00);

                //string strNextUpdateTime = "";
                if (this.chkAuto.Checked)
                {
                    this.chkAuto.Text = "Scheduler is ON...";
                    this.chkAuto.Refresh();
                    //strNextUpdateTime = DateTime.Now.AddMinutes(Convert.ToDouble(this.NumericUpDown1.Value)).ToString();

                    cIntTimerTickNo = 0; // 0 Because No Instant Run

                    //Interval for the Next Run in a Rounded Clock Time
                    this.timer1.Interval = Convert.ToInt32(dtFirstTickExecutionTime.Subtract(dtCurrentTime).TotalMilliseconds);//Convert.ToInt32(1000 * 60 * 5); //1 Second (1000 Mili Second) x 60 Seconds x 5 Minutes = 5 Minute

                    this.NumericUpDown1.Enabled = false;

                    //this.timer1.Start();
                }

                ////Starting the process of downloading and updating tables (for Instant Run)
                //this.DoTheJob();

                if (this.chkAuto.Checked)
                {
                    if (cIntTimerTickNo > 0)
                    {
                        this.lblTickNo2.Text = cIntTimerTickNo.ToString().Trim();
                        this.lblLastUpdate2.Text = dtCurrentTime.ToString("dd-MMM-yyyy HH:mm:ss");
                    }
                    this.lblNextUpdate2.Text = dtFirstTickExecutionTime.ToString("dd-MMM-yyyy HH:mm:ss");//strNextUpdateTime;
                    this.lblNextUpdate2.Refresh();
                    //this.label16.Text = "Hello World";
                    //this.lblNextUpdate2.Text = "Hello World1";
                }
                //this.lblNextUpdate2.Text = "Hello World1";
                //this.WriteProcessLog("\nHello World for Testing");
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

        }
    } // End of Class
} // End of Namespace