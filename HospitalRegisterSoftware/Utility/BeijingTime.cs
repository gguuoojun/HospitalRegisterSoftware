using System.Threading;
using System;

namespace Utility
{
	public class BeijingTime
	{
        private const string HOST = "cn.ntp.org.cn";

		private static BeijingTime _instance;

		private NTPClient _client;
		private TimeSpan _tsClock = new TimeSpan(0L);

		private bool _IsConnect;

        private Thread syncThread;
        private bool bIsExitThread = false;       //是否退出线程
        private AutoResetEvent autoEvent = new AutoResetEvent(false);

        public delegate void NTPServerTimeConnectedHander(bool bIsConnected, TimeSpan bjTimeSpan);
        public event NTPServerTimeConnectedHander NTPServerTimeConnectedEventHander;

        public bool IsConnect
        {
            get
            {
                return this._IsConnect;
            }
        }

		public static BeijingTime Instance
		{
			get
			{
				if (BeijingTime._instance == null)
				{
					BeijingTime._instance = new BeijingTime();
				}
				return BeijingTime._instance;
			}
		}

		private BeijingTime()
		{
			this._client = new NTPClient(HOST);
            syncThread = new Thread(new ThreadStart(SyncTime));
            syncThread.IsBackground = true;
            syncThread.Start();
		}

		public bool SetLocalTime(DateTime dtLocal)
		{
			return this._client.SetTime(dtLocal);
		}

        public void GetNtpTime()
        {
            autoEvent.Set();
        }

		private bool Connect()
		{
			bool result;
			try
			{
				this._client.Connect();
				this._IsConnect = true;
				this._tsClock = new TimeSpan((long)this._client.LocalClockOffset);
				result = true;
			}
			catch (Exception)
			{
				this._IsConnect = false;
				result = false;
			}
			return result;
		}


        /// <summary>
        /// 获取NTP服务器端时间
        /// </summary>
        private void SyncTime()
        {
            while(!bIsExitThread)
            {
                autoEvent.WaitOne();
                if (bIsExitThread)
                {
                    return;
                }

                Connect();

                if (NTPServerTimeConnectedEventHander != null)
                {
                    NTPServerTimeConnectedEventHander(IsConnect, _tsClock);
                }
            }           
        }

        public void Close()
        {
            if (syncThread != null)
            {
                bIsExitThread = true;
                autoEvent.Set();
                while(syncThread.IsAlive)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
                syncThread = null;
            }
        }
	}
}
