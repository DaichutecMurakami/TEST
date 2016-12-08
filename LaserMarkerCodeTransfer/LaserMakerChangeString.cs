
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
	static class LaserMakerChangeString
	{
		/*返り値
		* 文字列変更成功:0
		*　　　　　　　　失敗：-1
		*/
		public static int ChangeStrings(string strCmd)
		{
			//文字列があるかチェック
			if(strCmd)
			{
				return -1;
			}
			
			//State-->ChangeStringに変更
			LaserMakerState.iState = STRING_CHANGING;
			
			//文字列変更コマンド生成
            ComModule.gstrCommand = "C2," + LazerMakerInitialize.SettingNumber + "," 
								  + LazerMakerInitialize.BlockNumber + "," + strCmd;
								  
			LazerMakerInitialize.Common_TX_RX_Processing();
			
			return 0;
		}
	}
}