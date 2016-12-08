
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using System.Diagnostics;
//using System.Threading;
using System.Timers;

// ERROR: Not supported in C#: OptionDeclaration
namespace LaserMakerCodeTransfer
{
    static class ComModule
    {
        //通信ポート
        public static string gstrPort;
        //ボーレート
        public static string gstrBaudrate;
        //パリティ
        public static string gstrParity;
        //ストップビット
        public static string gstrStopbit;
        //デリミタ
        public static string gstrDelimiter;
        //ヘッダの有無
        public static string gstrHeader;
        //チェックサム付加
        public static string gstrCheckSumOnOff;
        //チェックサム
        public static string gstrCheckSum;
        //コマンド
        public static string gstrCommand;
        //送信バッファ
        public static string gstrBuf1;
        //受信バッファ
        public static string gstrBuf2;

        //public static byte bRcvEvent;
		
		public static byte bRcvCompFlag;

        public static byte bTimeoutFlag = 0;

        public static byte bTimeoutFlag2 = 0;

        //データ送信プロシージャ
        //public static void Transmittier()
        public static int Transmittier()
        {
           LZM_TESTForm f = new LZM_TESTForm();
           f.LZM_Comm1.WriteTimeout = 500;

            //通信ポートの確認
            try
            {
                if (f.LZM_Comm1.IsOpen == false)
                {
                    f.LZM_Comm1.Open();// = true;
                }

            }
            catch(UnauthorizedAccessException)
            {
                //MessageBox.Show("Access Error");
                //MessageBox.Show(e.Message);

                return -1;
            }
            catch (ArgumentOutOfRangeException)
            {
                //MessageBox.Show("Out of Range Argument Error");
                //MessageBox.Show(e.Message);

                return -1;
            }
            catch (ArgumentException)
            {
                //MessageBox.Show("Argument Error");
                //MessageBox.Show(e.Message);

                return -1;
            }
            catch (System.IO.IOException)
            {
                //MessageBox.Show("System I/O Error");
                //MessageBox.Show(e.Message);

                return -1;
            }
            catch (InvalidOperationException)
            {
                //MessageBox.Show("InvalidOperation Error");
                //MessageBox.Show(e.Message);

                return -1;
            }
            catch (Exception)
            {
                //MessageBox.Show("Unknown Error");
                //MessageBox.Show(e.Message);

                return -1;
            }


            //受信バッファをクリア
            f.LZM_Comm1.DiscardInBuffer();
            //Form1.LZM_Comm1.InBufferCount = 0;
            gstrBuf1 = "";


            //デリミタとチェックサムの付加
            if (gstrDelimiter == "3")
            {
                //ヘッダ"STX"の付加
                gstrBuf1 = gstrBuf1 + ((char)(2)).ToString();//Strings.Chr(2);

                //チェックサムの付加判別と送信データのセット
                switch (gstrCheckSumOnOff)
                {
                    case "0":
                        //チェックサムなしのとき
                        gstrBuf1 = gstrBuf1 + gstrCommand;
                        gstrBuf1 = gstrBuf1 + ((char)(3)).ToString();//Strings.Chr(3);
                        break;

                    case "1":
                        //チェックサム付加のとき
                        gstrBuf1 = gstrBuf1 + gstrCommand;

                        CulCheckSum();
                        //チェックサム計算プロシージャ

                        gstrBuf1 = gstrBuf1 + "," + gstrCheckSum + ((char)(3)).ToString();//Strings.Chr(3);
                        break;

                }

            }
            else
            {
                //チェックサムの付加判別と送信データのセット
                switch (gstrCheckSumOnOff)
                {
                    case "0":
                        //チェックサムなしのとき
                        gstrBuf1 = gstrBuf1 + gstrCommand;
                        gstrBuf1 = gstrBuf1 + ((char)(13)).ToString();//Strings.Chr(13);
                        break;

                    case "1":
                        //チェックサム付加のとき
                        gstrBuf1 = gstrBuf1 + gstrCommand;

                        CulCheckSum();
                        //チェックサム計算プロシージャ

                        gstrBuf1 = gstrBuf1 + "," + gstrCheckSum + ((char)(13)).ToString();//Strings.Chr(13);
                        break;

                }

            }

            //データの送信
            f.LZM_Comm1.Write(gstrBuf1);
            //Form1.LZM_Comm1.Output = gstrBuf1;

            return 0;
        }


        //データ受信プロシージャ
        public static void Receiver()
        {
            LZM_TESTForm f = new LZM_TESTForm();
            //byte bRcvEvent = 0;
            f.LZM_Comm1.ReadTimeout = 500;

#if false
            char c, d;
#endif

            gstrBuf2 = "";
            //受信バッファの初期化

//通信ポートの確認
#if false
            if (f.LZM_Comm1.IsOpen == false)
            {
                //if (Form1.LZM_Comm1.PortOpen == false) {
                f.LZM_Comm1.Open();
                //Form1.LZM_Comm1.PortOpen = true;
            }
#else
            try
            {
                if (f.LZM_Comm1.IsOpen == false)
                {
                    f.LZM_Comm1.Open();// = true;
                }

            }
            catch (UnauthorizedAccessException)
            {
                //MessageBox.Show("Access Error");
                //MessageBox.Show(e.Message);

                return;
            }
            catch (ArgumentOutOfRangeException)
            {
               //MessageBox.Show("Out of Range Argument Error");
               //MessageBox.Show(e.Message);

                return;
            }
            catch (ArgumentException)
            {
                //MessageBox.Show("Argument Error");
                //MessageBox.Show(e.Message);

                return;
            }
            catch (System.IO.IOException)
            {
                //MessageBox.Show("System I/O Error");
                //MessageBox.Show(e.Message);

                return;
            }
            catch (InvalidOperationException)
            {
                //MessageBox.Show("InvalidOperation Error");
                //MessageBox.Show(e.Message);

                return;
            }
            catch (Exception)
            {
                //MessageBox.Show("Unknown Error");
                //MessageBox.Show(e.Message);

                return;
            }
#endif

            //イベントハンドラ登録
            f.LZM_Comm1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serial_DataReceived);

#if false
            //データの受信
            do
            {
                System.Windows.Forms.Application.DoEvents();
                //if (bRcvEvent == 1)
                //{
                    //bRcvEvent = 0;
                    //if (Form1.LZM_Comm1.InBufferCount) {
                    //gstrBuf2 = gstrBuf2 + f.LZM_Comm1.ReadLine();
                    gstrBuf2 = gstrBuf2 + f.LZM_Comm1.ReadExisting();

                    //gstrBuf2 = gstrBuf2 + Form1.LZM_Comm1.Input;
                    c = char.Parse(gstrDelimiter);
                    d = char.Parse(Strings.Right(gstrBuf2, 1));
                    //if ((Strings.Chr(Convert.ToInt32(gstrDelimiter)) == Strings.Right(gstrBuf2, 1)) {
                    if (c == d)
                    {
                        break; // TODO: might not be correct. Was : Exit Do
                    }
                //}
            } while (true);
#endif

        }

        static void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
#if true
            LZM_TESTForm f = new LZM_TESTForm();
            char cCheckDelimiter, cCheckRcvBuf;
#endif
            //bRcvEvent = 1;
			bRcvCompFlag = 0;
#if true
            //タイマの生成
            var timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnElapsed_TimersTimer);
            timer.Interval = 1000;
			timer.Start();
			
			cCheckDelimiter = char.Parse(gstrDelimiter);

            //データの受信
            bTimeoutFlag = 0;
            do
            {
                //System.Windows.Forms.Application.DoEvents();
                //if (bRcvEvent == 1)
                //{
                    //bRcvEvent = 0;
                    //if (Form1.LZM_Comm1.InBufferCount) {
                    //gstrBuf2 = gstrBuf2 + f.LZM_Comm1.ReadLine();
                    gstrBuf2 = gstrBuf2 + f.LZM_Comm1.ReadExisting();

                    //gstrBuf2 = gstrBuf2 + Form1.LZM_Comm1.Input;
					//cCheckDelimiter = char.Parse(gstrDelimiter);
                    cCheckRcvBuf    = char.Parse(Strings.Right(gstrBuf2, 1));
                    //if ((Strings.Chr(Convert.ToInt32(gstrDelimiter)) == Strings.Right(gstrBuf2, 1)) {
					if (cCheckDelimiter == cCheckRcvBuf)
                    {
						bRcvCompFlag = 1;
                        break; // TODO: might not be correct. Was : Exit Do
                    } else {
						//if(timer.Elapsed == 0)
                        if(bTimeoutFlag == 1)
						{
							break;
						}
					}
                //}
            } while (true);
			timer.Stop();
#endif
        }

        //チェックサム計算プロシージャ
        public static void CulCheckSum()
        {

            int lngCulResult = 0;
            //チェックサム計算結果
            string strCodeValue = null;
            //コード値
            short i = 0;
            string s0;
            string s1;

            //*******************************************************
            //半角文字(1ﾊﾞｲﾄ)と全角文字(2ﾊﾞｲﾄ)をそれぞれ１バイトづつ
            //排他的論理和(Xor)を取り、チェックサムを計算
            //*******************************************************
            for (i = Convert.ToInt16(gstrHeader); i <= Strings.Len(gstrBuf1); i++)
            {
                strCodeValue = "00" + Conversion.Hex(Strings.Asc(Strings.Mid(gstrBuf1, i, 1)));
                //lngCulResult = lngCulResult ^ Conversion.Val("&H" + Strings.Left(Strings.Right(strCodeValue, 4), 2));
                //lngCulResult = lngCulResult ^ Conversion.Val("&H" + Strings.Right(Strings.Right(strCodeValue, 4), 2));
                s0 = Strings.Right(strCodeValue, 4);
                s1 = Strings.Left(s0, 2);
                lngCulResult = lngCulResult ^ int.Parse(s1);
                s0 = Strings.Right(strCodeValue, 4);
                s1 = Strings.Right(s0, 2);
                lngCulResult = lngCulResult ^ int.Parse(s1);//Conversion.Val("&H" + Strings.Right(Strings.Right(strCodeValue, 4), 2));
            }
            lngCulResult = lngCulResult ^ 0x2C;//Conversion.Val("&H" + "2C");

            gstrCheckSum = Strings.Right("0" + Conversion.Hex(lngCulResult), 2);

        }


        //エラー処理プロシージャ
        public static short ErrorSyori()
        {
            short functionReturnValue = 0;
            LZM_TESTForm f = new LZM_TESTForm();

            if (Strings.Mid(gstrBuf2, Convert.ToInt16(gstrHeader) + 3, 1) == "1")
            {

                Interaction.MsgBox("通信エラー発生", MsgBoxStyle.OkOnly);
                //Start of ErrorTableReference
				//ex.)K0,1,S001
				ErrorTableOutput(Strings.Mid(gstrBuf2, Convert.ToInt16(gstrHeader) + 4, 1), Convert.ToInt32(Strings.Mid(gstrBuf2, Convert.ToInt16(gstrHeader) + 5, 3)));
				//
                //End of ErrorTableReference
                f.LZM_Comm1.Close();
                //Form1.LZM_Comm1.PortOpen = false;
                functionReturnValue = 0;
                return functionReturnValue;
            }

            functionReturnValue = 1;
            return functionReturnValue;

        }
        //Strings.Right
        public static string Right(string str, int len)
        {
            if (len > 0)
            {
                throw new ArgumentException("引数'len'は0以上でなければなりません。");
            }
            if (str == null)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(str.Length - len, len);

        }

        public static void ErrorTableOutput(string ErrorStr, int ErrorCode)
        {
            string[] tblErrorCode =
            {
                "設定内容不正エラー",
                "設定メモリフルエラー",
                "内部メモリカードフルエラー",
                "外部メモリカードフルエラー",
                "外部メモリカード未挿入エラー",
                "外部メモリカード認識不能エラー",
                "優先権エラー",
                "ファイル無しエラー",
                "ビジーエラー",
                "印字ブロック無しエラー",
                "ロゴ・外字個数オーバエラー",
                "最適化不正エラー",
                "カレント設定操作エラー",
                "ロゴ・外字ファイル操作エラー",
                "テスト印字不可能エラー",
                "バーコード・２次元コード設定内容不正エラー",
                "全設定復元エラー",
                "データ長エラー",
                "設定番号未登録エラー",
                "ブロック番号未登録エラー",
                "コマンド不正エラー",
                "チェックサムエラー",
                "コマンド認識不能エラー",
                "レスポンスデータ長エラー",
                "印字内容要求エラー",
                "グループ番号未登録エラー",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "高速文字変更設定エラー",
                "点検レーザ不能エラー",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "ブロック種類設定内容不正エラー",
                "ブロック配置設定内容不正エラー",
                "文字サイズ設定内容不正エラー",
                "文字配置設定内容不正エラー",
                "文字詳細設定内容不正エラー",
                "印字条件設定内容不正エラー",
                "バーコード・２次元コード条件設定内容不正エラー",
                "連続印字設定内容不正エラー",
                "移動・印字方向設定内容不正エラー",
                "ライン条件設定内容不正エラー",
                "パレット情報設定内容不正エラー",
                "パレットワーク情報設定内容不正エラー",
                "文字列設定内容不正エラー",
                "個別カウンタ設定内容不正エラー",
                "共通カウンタ設定内容不正エラー",
                "プリセット情報設定内容不正エラー",
                "システム情報設定内容不正エラー",
                "フォント置換情報設定内容不正エラー",
                "フォント拡縮情報設定内容不正エラー",
                "ロゴ・外字バッファ情報設定内容不正エラー",
                "現在地情報設定内容不正エラー",
                "３次元システム情報設定内容不正エラー",
                "３次元設定情報内容不正エラー",
                "動作制限エラー",
                "Wobble設定内容不正エラー",
                "",
                "",
                "",
                "登録バーコードエラー",
                "バーコード・２次元コードリンク設定エラー",
                "バーコード登録状態不正エラー"
            };

            if(ErrorStr == "S")
            {
                Interaction.MsgBox(tblErrorCode[ErrorCode], MsgBoxStyle.OkOnly);
            }
            else//Abnormal ErrorCode
            {
                Interaction.MsgBox("Undefined ErrorCode issue.", MsgBoxStyle.OkOnly);
            }
        }
		
		/***************** 共通送受信処理部 *********************/
        //送信できなかったらどうするか(Retryの実装)=>Call側でやってもらう
        //受信するまで別の処理にKeyを渡すにはどうするか(ここでPollingするだけでは無限ループになる)
		//=>とりあえず受信できるレベルまで作る(ポーリングどうこうは別で)
        public static int Common_TX_RX_Processing()
        {
            int ErrorJudge = 0;
			char chkCmd;

            //タイマの生成
            var timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(OnElapsed_TimersTimer2);
            timer.Interval = 1000;
            timer.Start();

            /********* 送信処理部 *********/
            timer.Interval = Driver_Header.RS232C_WAIT_TIME;
			timer.Start();
			
			//送信待ち
			//while(timer.Elapsed != 0){
            while (bTimeoutFlag2 == 0)
            { 
				ErrorJudge = ComModule.Transmittier();
				if(ErrorJudge == 0) break;
			}
			timer.Stop();
			
            if (ErrorJudge == -1)
            {
                //MessageBox.Show("Send Error");
                //return;
				return Driver_Header.RS232C_TX_FAIL;
            }
			/********* 受信処理部 *********/
			timer.Interval = Driver_Header.RS232C_WAIT_TIME;
			//timer.Reset();
			timer.Start();
			ComModule.Receiver();

            //受信待ち
            bTimeoutFlag2 = 0;
            //while (timer.Elapsed != 0)
            while(bTimeoutFlag2 == 0)
			{
				if(bRcvCompFlag == 1){
					break;
				}
			}
			timer.Stop();

            //時間内に受信できなかった時
            //if( (timer.Elapsed == 0) && (bRcvCompFlag == 0) )
            if ((bTimeoutFlag2 == 1) && (bRcvCompFlag == 0))
            {
				return Driver_Header.RS232C_RX_FAIL;
			}
			
			//入力コマンドが正常に受理されたかチェック
			chkCmd = char.Parse(Strings.Left(gstrBuf2, 4));//ex.)XS,0=>0 or 1 check
			if(chkCmd == 0)
			{
				return Driver_Header.RS232C_SUCCESS;
			}
			else
			{
				return Driver_Header.RS232C_RX_CMD_1;
			}
        }
        /**************************************************/
        private static void OnElapsed_TimersTimer(object sender, ElapsedEventArgs e)
        {
            bTimeoutFlag = 1;
        }

        private static void OnElapsed_TimersTimer2(object sender, ElapsedEventArgs e)
        {
            bTimeoutFlag2 = 1;
        }
    }
}
