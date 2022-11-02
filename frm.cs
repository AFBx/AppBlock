using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dfd
{
    public partial class mainForm : Form
    {
        readonly Random rndSeed = new Random(Guid.NewGuid().GetHashCode());
        public mainForm()
        {
            InitializeComponent();
            Task.Run(() => GetSlots());   
            Task.Run(() => DoLeftClick());
            Task.Run(() => DoRightClick());
            Task.Run(() => Randomisation());
            sldLeftCPS.Region = Region.FromHrgn(WinApi.CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        string[] engelle = {
"Fiddler Everywhere",
"ollydbg",
"tcpview",
"autoruns",
"autorunsc",
"filemon",
"procmon",
"idag",
"hookshark",
"peid",
"lordpe",
"regmon",
"idaq",
"idaq64",
"ImmunityDebugger",
"Wireshark",
"dumpcap",
"HookExplorer",
"ImportREC",
"PETools",
"LordPE",
"SysInspector",
"proc_analyzer",
"sysAnalyzer",
"sniff_hit",
"joeboxcontrol",
"joeboxserver",
"ida",
"HTTPDebuggerSvc",
"ResourceHacker",
"ProcessHacker",
"Cheat Engine 7.2",
"cheatengine-x86_64-SSE4-AVX2",
"cheatengine-i386",
"cheatengine-x86_64" };
        public static string Encode(string text)
        {
            var Bytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(Bytes);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        static bool settingsReturn, refreshReturn;
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        private void mainForm_Load(object sender, EventArgs e)
        {
            mainForm.FreeConsole();
            AllocConsole();
            string HWID;
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            HWID = Encode(HWID);
            MessageBox.Show(HWID);
            Clipboard.SetText(HWID);
            RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true); 
            registry.SetValue("ProxyEnable", 0);
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

            bool bl = false;

            if(bl == false) 
            {
                Environment.Exit(1);
            }

        }

}
