
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
	static class Driver_Header
	{
/********************************************************
** Driver Common
********************************************************/
	//Command
		public const Byte STX = 0x02;
		public const Byte ETX = 0x03;
	
	//RS232C
		public const int RS232C_WAIT_TIME = 1000;		
		
	//State
		public const Byte UNKNOWN_ERROR = 0xFF;		
/********************************************************
** UPS
********************************************************/
	//State
		public const Byte UPS_INIT = 0x00;
		public const Byte UPS_CHECK_PROCESS = 0x01;
		public const Byte UPS_INIT_ERROR = 0xf1;
		public const Byte UPS_CHECK_ERROR = 0xf2;
		public const Byte EOP = 13;//EOP(End of Packet):CR(13)
/********************************************************
** 集塵脱臭機
********************************************************/
	//GPIO Setting
		public const Byte GPIO_OUTPUT = 0x00;
		public const Byte GPIO_INPUT = 0x01;
		public const Byte GPIO_LOW = 0x0A;
		public const Byte GPIO_HIGH = 0x1A;

	//State
		public const Byte DCDM_NEED_INIT = 0x00;
		public const Byte DCDM_RUN_PROCESS = 0x01;
		public const Byte DCDM_INIT_ERROR = 0xF0;
		public const Byte DCDM_FILTER_CLOGGING_ERROR = 0xF1;
		public const Byte DCDM_DRIVE_OUTPUT_ERROR = 0xF2;
		public const Byte DCDM_PRESSURE_OUTPUT_ERROR = 0xF3;
		public const Byte DCDM_SET_TIMER_ERROR = 0xF4;

	//DCDM Error
		public const Byte GPIO_DRIVE_INPUT = 1;
		public const Byte GPIO_DRIVE_PRESSURE = 2;
		public const Byte GPIO_FILTER_CLOGGING = 3;
		public const Byte GPIO_REMOTE_CHANGE = 4;
		public const Byte GPIO_DRIVE_OUTPUT = 5;
		public const Byte GPIO_PRESSURE_OUTPUT = 6;
		public const Byte GPIO_LEVEL_CHANGE = 7;
		public const Byte GPIO_GND = 8;
/********************************************************
** 画像処理ユニット
********************************************************/
	//Com
		public const Byte CmdID_REQ_RES_PKT = 0x41;
		public const Byte CmdID_IRQ_PKT = 0x42;
		public const Byte CmdID_MSG_PKT = 0x43;
		public const Byte CmdID_DATA_COM = 0x44;
		public const Byte Terminate_Reserved = 0x00;
		public const Byte Send_idenCode = 0x00;
		public const Byte IRQTYPE_BOOTCOMP = 0x31;
		public const Byte IRQTYPE_ERROR = 0x40;
		
	//State
		public const Byte IMGP_NEED_INIT = 0x00;
		public const Byte IMGP_CHECK_IMAGE_START = 0x01;
		public const Byte IMGP_TEST_SETTING = 0x0F;
		public const Byte IMGP_CMD_SEND_ERROR = 0x1F;
		public const Byte IMGP_CMD_RECV_ERROR = 0x2F;
		public const Byte IMGP_PORT_OPEN_FAIL = 0x3F;
		public const Byte IMGP_RS232C_SETCON_ERR = 0x4F;
		public const Byte IMGP_USB_SETCON_ERR = 0x5F;
		public const Byte IMGP_LAN_SETCON_ERR = 0x6F;
		public const Byte IMGP_INSPECT_START_ERR = 0x7f;
		public const Byte IMGP_SIGNUP_STRING_ERR = 0x8f;
		public const Byte IMGP_TRRIGER_CMD_ERR = 0x9f;
		public const Byte IMGP_IMAGE_JUDGE_NG = 0xAf;
		public const Byte IMGP_SIGNUP_STRING_UNMATCH = 0xBF;
		public const Byte IMGP_RECOGNIZE_GETRES_ERR = 0xCF;
/********************************************************
** レーザーマーカー
********************************************************/		
	//Com	
		public const int RS232C_SUCCESS = 0;
		public const int RS232C_TX_FAIL = -1;
		public const int RS232C_RX_FAIL =	-2;
		public const int RS232C_RX_CMD_1 = -3;
		
	//State
		public const Byte LZM_NEED_INITIALIZE = 0x00;
		public const Byte LZM_IDLE = 0x01;
		public const Byte LZM_INITIALIZING = 0x0F;
		public const Byte LZM_PRINTING = 0x1F;
		public const Byte LZM_STRING_CHANGING = 0x2F;

	}
}