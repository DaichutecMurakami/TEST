
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace LaserMakerCodeTransfer
{
    static class LazerMakerInitialize
    {
        //common
        public static string SettingNumber = "0000,";
        public static string BlockNumber = "000,";
		/***************** COM Port初期化処理 *****************/
        private static void COMPort_Initialize()
		{
            LZM_TESTForm fm = new LZM_TESTForm();

            //通信条件の初期設定
            ComModule.gstrPort = "1";
            ComModule.gstrBaudrate = "38400";
            ComModule.gstrParity = "N";
            ComModule.gstrStopbit = "1";
            ComModule.gstrDelimiter = "13";
            ComModule.gstrHeader = "1";
            ComModule.gstrCheckSumOnOff = "0";

            fm.LZM_Comm1.PortName = ComModule.gstrPort;
            fm.LZM_Comm1.BaudRate = Convert.ToInt32(ComModule.gstrBaudrate);
            fm.LZM_Comm1.Parity = System.IO.Ports.Parity.None;
            fm.LZM_Comm1.DataBits = 8;
            fm.LZM_Comm1.StopBits = System.IO.Ports.StopBits.One;
            fm.LZM_Comm1.ReadBufferSize = 4096;
            fm.LZM_Comm1.WriteBufferSize = 4096;
        }
        /***************** 設定作成開始コマンド *****************/
        private static int setting_Start()
        {
			int chkCmd=0;
			
            ComModule.gstrCommand = "XS," + SettingNumber;
            chkCmd = ComModule.Common_TX_RX_Processing();
			
			return chkCmd;
        }
        /***************** 設定作成終了コマンド *****************/
        private static int setting_End()
        {
			int chkCmd=0;
			
            ComModule.gstrCommand = "YE," + SettingNumber;
            chkCmd = ComModule.Common_TX_RX_Processing();
			
			return chkCmd;
        }
        /***************** 印字共通条件設定 *********************/
        private static int common_setting()
        {
			int chkCmd=0;
			
            string KindOfSetting = "0,";
            string MovingDirection = "0,";
            string FixedValue01 = "1,";
            string PrintDirection = "0,";
            string MovingCondition_XY = "1,";
            string MovingCondition_Z = "0,";
            string PrintTime_LineSpeed_MaxLineSpeed = "1,";
            string TriggerDelay = "0,";
            string NumberOfEncoderPalse = "0,";
            string MinDistancceBetweenWork = "5,";
            string MovingPrintStartPosition = "60,";
            string MovingPrintEndPosition = "60,";
            string FixedValue02 = "00,";
            string ContinuousPrintTimes = "1,";
            string ContinuousPrintBetween = "0,";
            string Distance_PointerPosition = "0,";
            string RunawayScanSpeed = "0,";
            string OptimizationScanSpeed = "00000,";
            string ScanOptimizationFlag = "2,";
            string PrintOrderFlag = "1,";

            ComModule.gstrCommand = "K0," + SettingNumber + KindOfSetting + MovingDirection + FixedValue01 + PrintDirection + MovingCondition_XY + MovingCondition_Z + PrintTime_LineSpeed_MaxLineSpeed + TriggerDelay
                                  + NumberOfEncoderPalse + MinDistancceBetweenWork + MovingPrintStartPosition + MovingPrintEndPosition + FixedValue02 + ContinuousPrintTimes + ContinuousPrintBetween + Distance_PointerPosition
                                  + RunawayScanSpeed + OptimizationScanSpeed + ScanOptimizationFlag + PrintOrderFlag;

            chkCmd = ComModule.Common_TX_RX_Processing();
			
			return chkCmd;
        }
        /***************** ブロック条件設定 *********************/
        private static int Block_Condition_Setting()
        {
			int chkCmd=0;
			
            string Block3DShape = "099,";
            string KindOfBlock = "000,";
            //位置情報
            string PotisionInfomation_X = "0,";
            string PotisionInfomation_Y = "0,";
            string PotisionInfomation_Z = "0,";
            string PotisionInfomation_Spot = "0,";
            string PotisionInfomation_PrintAngle = "0,";
            string PotisionInfomation_StringAngle = "0,";
            //速度情報
            string SpeedInfomation_PrintFlag = "1,";
            string SpeedInfomation_RunawayDistance = "0,";
            string SpeedInfomation_RunawayDistanceBetweenString = "1,";
            string SpeedInfomation_FixedValue = "00000,";
            string SpeedInfomation_ScanSpeed = "1,";
            string SpeedInfomation_PrintPower = "10,";
            //サイズ情報
            string SizeInfomation_KindOfLine = "00,";
            string SizeInfomation_FontNumber = "00,";
            string SizeInfomation_StringHight = "00,";
            string SizeInfomation_StringWidth = "00,";
            string SizeInfomation_IntersectionRemoval = "0,";
            string SizeInfomation_PrintLineTimes_OverLapRatio = "0,";
            string SizeInfomation_BoldLine = "0,";
            string SizeInfomation_FastChangeString = "0,";
            string SizeInfomation_EvenArrangementFlag = "1,";
            string SizeInfomation_BetweenStringDistance = "0,";
            string SizeInfomation_FullWidth = "0,";
            string SizeInfomation_AngleBetweenString = "0,";
            string SizeInfomation_OpenAngle = "0,";

            ComModule.gstrCommand = "K2," + SettingNumber + BlockNumber + Block3DShape + KindOfBlock
                                  + PotisionInfomation_X + PotisionInfomation_Y + PotisionInfomation_Z
                                  + PotisionInfomation_Spot + PotisionInfomation_PrintAngle + PotisionInfomation_StringAngle
                                  + SpeedInfomation_PrintFlag + SpeedInfomation_RunawayDistance + SpeedInfomation_RunawayDistanceBetweenString
                                  + SpeedInfomation_FixedValue + SpeedInfomation_ScanSpeed + SpeedInfomation_PrintPower
                                  + SizeInfomation_KindOfLine + SizeInfomation_FontNumber + SizeInfomation_StringHight + SizeInfomation_StringWidth
                                  + SizeInfomation_IntersectionRemoval + SizeInfomation_PrintLineTimes_OverLapRatio + SizeInfomation_BoldLine
                                  + SizeInfomation_FastChangeString + SizeInfomation_EvenArrangementFlag + SizeInfomation_BetweenStringDistance
                                  + SizeInfomation_FullWidth + SizeInfomation_AngleBetweenString + SizeInfomation_OpenAngle;


            chkCmd = ComModule.Common_TX_RX_Processing();
			
			return chkCmd;
        }
        /***************** タイトル設定 *************************/
        private static int Title_Setting()
        {
			int chkCmd=0;
			
            string TitleName = "PRIMARY-ISSUING-MACHINE";

            ComModule.gstrCommand = "G4," + SettingNumber + TitleName;
            chkCmd = ComModule.Common_TX_RX_Processing();
			
			return chkCmd;
        }
        /***************** カウンタ条件設定 *************************/
        private static int CounterCondition_Setting()
        {
			int chkCmd=0;
			
            //個別カウンタ
            string IndividualCounter_Number = "0000,";
            string IndividualCounter_StepWidth = "1000,";
            string IndividualCounter_CounterInitialValue = "0,";
            string IndividualCounter_StartValue = "0,";
            string IndividualCounter_EndValue = "1000,";
            string IndividualCounter_PrintTimes = "999,";
            string IndividualCounter_ResetTiming = "2,";
            string IndividualCounter_CountTiming = "1,";
            string IndividualCounter_XNumber = "10,";

            //共通カウンタ
            string CommonCounter_Number = "A,";
            string CommonCounter_StepWidth = "1000,";
            string CommonCounter_CounterInitialValue = "0,";
            string CommonCounter_StartValue = "0,";
            string CommonCounter_EndValue = "1000,";
            string CommonCounter_PrintTimes = "999,";
            string CommonCounter_ResetTiming = "2,";
            string CommonCounter_CountTiming = "1,";
            string CommonCounter_XNumber = "10,";

            ComModule.gstrCommand = "G6," + SettingNumber + IndividualCounter_Number + IndividualCounter_StepWidth
                                  + IndividualCounter_CounterInitialValue + IndividualCounter_StartValue + IndividualCounter_EndValue
                                  + IndividualCounter_PrintTimes + IndividualCounter_ResetTiming + IndividualCounter_CountTiming
                                  + IndividualCounter_XNumber
                                  + CommonCounter_Number + CommonCounter_StepWidth + CommonCounter_CounterInitialValue + CommonCounter_StartValue
                                  + CommonCounter_EndValue + CommonCounter_PrintTimes + CommonCounter_ResetTiming + CommonCounter_CountTiming
                                  + CommonCounter_XNumber;
            chkCmd = ComModule.Common_TX_RX_Processing();
			
			return chkCmd;
        }
		/***************** パレット内均等配置条件設定 **************/
		private static int PaletEvenArrangement_Setting()
		{
			int chkCmd=0;
			
			string PriorityPrintDirection = "1,";
			string BetweenLinesEvenArrangementFlag = "1,";
			string BetweencolumnsEvenArrangementFlag = "1,";
			string NumberOfColumns = "1,";
			string NumberOfLines = "1,";
			string BetweenColumns = "1,";
			string BetweenLines = "1,";
			string PrintStartPaletNumber = "0001,";
			string StandardPosition_X = "0";
			string StandardPosition_Y = "0";
			
			ComModule.gstrCommand = "KU," + SettingNumber + PriorityPrintDirection + BetweenLinesEvenArrangementFlag + BetweencolumnsEvenArrangementFlag
								  + NumberOfColumns + NumberOfLines + BetweenColumns + BetweenLines + PrintStartPaletNumber
								  + StandardPosition_X + StandardPosition_Y;
			chkCmd = ComModule.Common_TX_RX_Processing();
			
			return chkCmd;
		}
		/***************** パレット個別条件設定 **************/
		private static int PaletEvenArrangement_IndividualSetting()
		{
			int chkCmd=0;
			
			string PaletNumber = "0001,";
			string PrintProprietyFlag = "1,";
			string NextPrintPaletNumber = "-0001,";
			string PaletOffset_X = "0";
			string PaletOffset_Y = "0";
			string PaletOffset_Z = "0";
			string PaletOffset_Angle = "0";
			
			ComModule.gstrCommand = "KW," + SettingNumber + PaletNumber + PrintProprietyFlag + NextPrintPaletNumber
								  + PaletOffset_X + PaletOffset_Y + PaletOffset_Z + PaletOffset_Angle;
			chkCmd = ComModule.Common_TX_RX_Processing();
			
			return chkCmd;
		}
        /***************** 初期設定処理部 *********************/
        public static void LazerMaker_Initialize()
        {
			int chkCmd = 0;

            LaserMakerState.iState = Driver_Header.LZM_INITIALIZING;

            COMPort_Initialize();
			
            chkCmd = setting_Start();
			if(chkCmd != 0)
			{
MessageBox.Show("1", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LaserMakerState.iState = -1;
				return;
			}
			
			chkCmd = common_setting();
			if(chkCmd != 0)
			{
MessageBox.Show("2", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LaserMakerState.iState = -1;
				return;
			}
			
			chkCmd = Block_Condition_Setting();
			if(chkCmd != 0)
			{
 MessageBox.Show("3", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LaserMakerState.iState = -1;
				return;
			}
			
			chkCmd = Title_Setting();
			if(chkCmd != 0)
			{
MessageBox.Show("4", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LaserMakerState.iState = -1;
				return;
			}
			
			chkCmd = CounterCondition_Setting();
			if(chkCmd != 0)
			{
MessageBox.Show("5", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LaserMakerState.iState = -1;
				return;
			}
			
			chkCmd = PaletEvenArrangement_Setting();
			if(chkCmd != 0)
			{
MessageBox.Show("6", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LaserMakerState.iState = -1;
				return;
			}
			
			chkCmd = PaletEvenArrangement_IndividualSetting();
			if(chkCmd != 0)
			{
MessageBox.Show("7", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LaserMakerState.iState = -1;
				return;
			}
			
            chkCmd = setting_End();
			if(chkCmd != 0)
			{
MessageBox.Show("✕", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LaserMakerState.iState = -1;
				return;
			} else {
                LaserMakerState.iState = Driver_Header.LZM_IDLE;
            }
        }
        /********************************************************/
    }
}
