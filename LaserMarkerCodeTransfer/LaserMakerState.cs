
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
	static class LaserMakerState
	{
		//common
		public static int iState=0;
		public static int ijudge=0;
		public static int ichkstate=0;
		
		/********** Main処理部 **************/ 
		/*
		*strCmd1 : 指示文字列
		*strCmd2 : 文字列変更時の文字列
		*/
		public static int LaserMakerMain(string strCmd1, string strCmd2)
		{
			switch(strCmd1)
			{
				case "CHECK_STATE":
					ichkstate = CheckState();
					return ichkstate;
                    //break;
                case "ERROR_CLR":
                    StateClear();
                    break;
                default:
					CheckStateMachine(strCmd1, strCmd2);
					break;
			}
			
			return 0;
		}		
		/********** ステートチェック処理部 **********/ 
		/*
		*strCmd1 : 指示文字列
		*strCmd2 : 文字列変更時の文字列
		*/
		private static int CheckStateMachine(string strCmd1, string strCmd2)
		{
			switch(iState)
			{
                /*** 初期化が必要 ***/
                case Driver_Header.LZM_NEED_INITIALIZE:
					if(strCmd1 == "INITSTART")
					{
#if DEBUG
                        System.Threading.Thread.Sleep(1000);
                        iState = Driver_Header.LZM_IDLE;
#else
                        LazerMakerInitialize.LazerMaker_Initialize();
#endif
					}
					break;
				/*** 処理中 ***/
				case Driver_Header.LZM_INITIALIZING:
				case Driver_Header.LZM_PRINTING:
				case Driver_Header.LZM_STRING_CHANGING:
					break;
				/*** 待機状態 ***/
				case Driver_Header.LZM_IDLE:
					if(strCmd1 == "PRINTSTART")
					{
						//処理を入れる(中にステート入れるのを忘れない)
						ijudge = PrintProcessing();
						
						if(ijudge == -1){
							iState = Driver_Header.UNKNOWN_ERROR;//Error
						} else {
							iState = Driver_Header.LZM_IDLE;
						}
					}
					else if(strCmd1 == "CHANGESTRING")
					{
						//ijudge = LaserMakerChangeString.ChangeStrings(strCmd2);
						ijudge = ChangeStrings(strCmd2);
						
						if(ijudge == -1){
							iState = Driver_Header.UNKNOWN_ERROR;//Error
						} else {
							iState = Driver_Header.LZM_IDLE;
						}
					} else {
						if(strCmd1 == "") iState = Driver_Header.UNKNOWN_ERROR;//Error
					}
					break;
				/*** 異常処理 ***/
				default:
					iState = Driver_Header.UNKNOWN_ERROR;//Error
					break;
			}
			
			return iState;
		}
		/********** ステートチェック処理部 **********/
		private static int CheckState()
		{
			return iState;
		}
		/********** ステートクリア処理部 ***********/
		//Error発生時、Main側でError Clearを実施する(Error->IDLEに復帰させる)
		private static void StateClear()
		{
			iState = Driver_Header.LZM_IDLE;
		}
		/********** 文字列変更処理部 ***********/
		/*返り値
		* 文字列変更成功:0
		*　　　　　　　　失敗：-1
		*/
		private static int ChangeStrings(string strCmd)
		{
			int chkCmd=0;
			
			//文字列があるかチェック
			if(strCmd == "")
			{
				return -1;
			}
			
			//State-->ChangeStringに変更
			LaserMakerState.iState = Driver_Header.LZM_STRING_CHANGING;
			
			//文字列変更コマンド生成
            ComModule.gstrCommand = "C2," + LazerMakerInitialize.SettingNumber + "," 
								  + LazerMakerInitialize.BlockNumber + "," + strCmd;
								  
			chkCmd = ComModule.Common_TX_RX_Processing();
			
			if(chkCmd == 0)
			{
				return 0;
			}
			else
			{
				return -1;
			}
		}
		/********** 印字処理部 ***************/
		private static int PrintProcessing()
		{
			Byte bKeyProtectFlag = 0;
            //int SendJudge = 0;
			int chkCmd = 0;

			iState = Driver_Header.LZM_PRINTING;
			
            do
            {
                //レディー状態要求
                ComModule.gstrCommand = "RE";
                chkCmd = ComModule.Common_TX_RX_Processing();
				
				if(chkCmd != 0)
				{
					return -1;
				}

                //送信データと受信データの表示
                //txtTransmitData.Text = Strings.Mid(ComModule.gstrBuf1, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf1) - Convert.ToInt16(ComModule.gstrHeader));
                //txtReceiveData.Text = Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf2) - Convert.ToInt16(ComModule.gstrHeader));

                //エラー処理
                if (ComModule.ErrorSyori() == 0)
                {
                    return -1;
                }

                switch (Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader) + 5, 1))
                {
                    case "1":
					case "2":
                        //エラー発生
                        //return;
                        bKeyProtectFlag = 1;
                        break;
                }
                if (bKeyProtectFlag == 1)
                {
                    return -1;
                }

            } while (!(Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader) + 5, 1) == "0"));

            //印字開始入力
            ComModule.gstrCommand = "NT";//"TX";
            chkCmd = ComModule.Common_TX_RX_Processing();
			
			if(chkCmd != 0)
			{
				return -1;
			}

            //送信データと受信データの表示
            //txtTransmitData.Text = Strings.Mid(ComModule.gstrBuf1, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf1) - Convert.ToInt16(ComModule.gstrHeader));
            //txtReceiveData.Text = Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader), Strings.Len(ComModule.gstrBuf2) - Convert.ToInt16(ComModule.gstrHeader));

            if (Strings.Mid(ComModule.gstrBuf2, Convert.ToInt16(ComModule.gstrHeader) + 3, 1) == "0")
            {
                //エラー処理
                return -1;
            }
            else if (ComModule.ErrorSyori() == 0)
            {
                return 0;
            }

            return -1;
		}
		/**********************************/
	}
}