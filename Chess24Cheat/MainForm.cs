using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess24Cheat
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;

        public string chess24Address = "https://chess24.com/";
        private static RichTextBox rtb;
        private static RadioButton whiteRb;
        private static Label scoreLabel;
        Process engineProcess;
        static StreamWriter EngineStreamWriter;
        static Label resultLabel;
        bool ourMove = false;

        public string GlobalFen;

        public MainForm()
        {
            InitializeComponent();
            rtb = richTextBox;
            resultLabel = AnalysisResult;
            whiteRb = white;
            scoreLabel = score;
        }

        ChromiumWebBrowser chrome;

        private void MainForm_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            chrome = new ChromiumWebBrowser(chess24Address);
            browserPanel.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;

            InitEngineWithUciCommand();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EngineStreamWriter?.WriteLine("quit");

            Cef.Shutdown();
        }

        private void start_Click(object sender, EventArgs e)
        {
            chrome.Load(chess24Address);
        }

        private void InitEngine_Click(object sender, EventArgs e)
        {
            InitEngineWithUciCommand();
        }

        private void InitEngineWithUciCommand()
        {
            InitEngine();

            while (EngineStreamWriter == null)
            {
            }

            Thread.Sleep(500);

            EngineStreamWriter.WriteLine("uci");
        }

        public string GetFenFromWebPage(string pageHtml)
        {
            var cbStart = pageHtml.IndexOf("<!-- chessBoard -->");
            var cbEnd = pageHtml.IndexOf("<!-- END chessBoard -->");

            var cb = pageHtml.Substring(cbStart + 24, cbEnd - (cbStart + 24));

            var startIndex = 0;
            var count = 0;
            var boardArray = new string[8][];
            for (int i = 0; i < 8; i++)
            {
                boardArray[i] = new string[8];
            }

            do
            {
                var cellPos = cb.IndexOf("<div class=\"_", startIndex);
                cellPos += 13;

                var i = int.Parse(cb[cellPos].ToString());
                var j = int.Parse(cb[cellPos + 1].ToString());

                var closingDivPos = cb.IndexOf("</div>", cellPos);

                var imagesHtml = cb.Substring(cellPos, closingDivPos - cellPos);

                var imgCount = Regex.Matches(imagesHtml, "<img").Count;

                if (imgCount == 2)
                {
                    var pos = imagesHtml.IndexOf("<img", imagesHtml.IndexOf("<img") + 1);

                    var imageStart = imagesHtml.IndexOf("\"", pos);
                    var imageEnd = imagesHtml.IndexOf("\"", imageStart + 1);

                    var imageUrl = imagesHtml.Substring(imageStart + 1, imageEnd - imageStart - 1);
                    var IUS = imageUrl.Split('/').ToList();
                    var colorPiece = IUS.Skip(IUS.Count - 2).Take(2).ToList();
                    var color = colorPiece[0];
                    var piece = colorPiece[1][0].ToString();

                    boardArray[i][j] = (color == "white") ? piece.ToUpper() : piece;
                }
                else
                {
                    boardArray[i][j] = "";
                }

                startIndex = closingDivPos;

                count++;
            } while (count < 64);

            var fen = "";
            var emptyCount = 0;

            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (boardArray[i][j] == "")
                    {
                        emptyCount++;
                    }
                    else
                    {
                        if (emptyCount != 0)
                        {
                            fen += emptyCount.ToString();
                            emptyCount = 0;
                        }

                        fen += boardArray[i][j];
                    }
                }

                if (emptyCount != 0)
                {
                    fen += emptyCount.ToString();
                    emptyCount = 0;
                }

                if (i != 0)
                {
                    fen += "/";
                }
            }

            return fen;
        }

        private Task InitEngine()
        {
            var engine = EngineFilename.Text;
            return Task.Run(() => {
                // Initialize the process and its StartInfo properties.
                // The sort command is a console application that
                // reads and sorts text input.

                engineProcess = new Process();
                engineProcess.StartInfo.FileName = engine;

                // Set UseShellExecute to false for redirection.
                engineProcess.StartInfo.UseShellExecute = false;

                // Redirect the standard output of the sort command.  
                // This stream is read asynchronously using an event handler.
                engineProcess.StartInfo.RedirectStandardOutput = true;

                // CreateNoWindow = true;
                engineProcess.StartInfo.CreateNoWindow = true;

                // Set our event handler to asynchronously read the sort output.
                engineProcess.OutputDataReceived += new DataReceivedEventHandler(EngineOutputHandler);

                // Redirect standard input as well.  This stream
                // is used synchronously.
                engineProcess.StartInfo.RedirectStandardInput = true;

                // Start the process.
                engineProcess.Start();

                // Use a stream writer to synchronously write the sort input.
                EngineStreamWriter = engineProcess.StandardInput;

                // Start the asynchronous read of the sort output stream.
                engineProcess.BeginOutputReadLine();

                // Wait for the sort process to write the sorted text lines.
                engineProcess.WaitForExit();

                // End the input stream to the sort command.
                EngineStreamWriter.Close();

                engineProcess.Close();
            });
        }

        private static void EngineOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                rtb.Invoke(new Action(() =>
                {
                    rtb.AppendText(Environment.NewLine + outLine.Data);
                }));

                if (outLine.Data.StartsWith("bestmove"))
                {
                    Tuple<Point, Point> p;
                    string move = outLine.Data.Split(' ').ToList()[1];

                    resultLabel.Invoke(new Action(() =>
                    {
                        resultLabel.Text = move;
                    }));

                    p = getCoordinates(move, whiteRb.Checked);

                    var cursorPosition = Cursor.Position;
                    
                    // Thread.Sleep(100);
                    // 90 425
                    // 410 395
                    MakeClick(90 + (p.Item1.X - 1) * 53, 425 + (p.Item1.Y - 1) * 53);

                    // Thread.Sleep(100);
                    MakeClick(90 + (p.Item2.X - 1) * 53, 425 + (p.Item2.Y - 1) * 53);

                    Cursor.Position = cursorPosition;
                }

                if (outLine.Data.Contains("score"))
                {
                    var line = outLine.Data;
                    var scorePos = line.IndexOf("score");
                    var nodesPosition = line.IndexOf("nodes");
                    var str = line.Substring(scorePos + 6, nodesPosition - scorePos - 7);

                    if (str.StartsWith("cp "))
                    {
                        str = str.Substring(3);
                    }

                    str = str.Replace("upperbound", "u").Replace("lowerbound", "l");

                    scoreLabel.Invoke(new Action(() => {
                        scoreLabel.Text = str;
                    }));
                }
            }
        }

        private static Tuple<Point, Point> getCoordinates(string move, bool white)
        {
            var p11 = white ? LetterToInt(move[0]) : 9 - LetterToInt(move[0]);
            var p12 = white ? (9 - int.Parse(move[1].ToString())) : int.Parse(move[1].ToString());
            var p21 = white ? LetterToInt(move[2]) : 9 - LetterToInt(move[2]);
            var p22 = white ? (9 - int.Parse(move[3].ToString())) : int.Parse(move[3].ToString());

            var p1 = new Point(p11, p12);
            var p2 = new Point(p21, p22);

            return new Tuple<Point, Point>(p1, p2);
        }

        private static int LetterToInt(char v)
        {
            switch (v)
            {
                case 'a': return 1;
                case 'b': return 2;
                case 'c': return 3;
                case 'd': return 4;
                case 'e': return 5;
                case 'f': return 6;
                case 'g': return 7;
                case 'h': return 8;
                default: return '*';
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            richTextBox.SelectionStart = richTextBox.Text.Length;
            // scroll it automatically
            richTextBox.ScrollToCaret();
        }

        private async void RunAnalysis_Click(object sender, EventArgs e)
        {
            AnalyseAndMove();
        }

        private async void AnalyseAndMove(string FenPosition = "")
        {
            AnalysisResult.Text = "....";
            var html = "";
            string fen;

            if (FenPosition == "")
            {
                await chrome.GetSourceAsync().ContinueWith(taskHtml =>
                {
                    html = taskHtml.Result;
                });

                fen = GetFenFromWebPage(html);
            }
            else
            {
                fen = FenPosition;
            }

            fen += " " + (white.Checked ? "w" : "b");

            fen += " " + CombineKQkqBoxes();

            try
            {
                EngineStreamWriter.WriteLine("ucinewgame");
            }
            catch (Exception e)
            {
                richTextBox.AppendText(e.Message);
            }

            Thread.Sleep(100);

            try
            {
                EngineStreamWriter.WriteLine("position fen " + fen);
            }
            catch (Exception e)
            {
                richTextBox.AppendText(e.Message);
            }

            richTextBox.AppendText("position " + fen + "\n");
            Thread.Sleep(100);

            int lowerTime;
            int.TryParse(AnalysisTimeLower.Text, out lowerTime);

            int upperTime;
            int.TryParse(AnalysisTimeUpper.Text, out upperTime);

            Random r = new Random();
            int analysisTime = r.Next(lowerTime, upperTime);

            try
            {
                EngineStreamWriter.WriteLine("go movetime " + analysisTime);
            }
            catch (Exception e)
            {
                richTextBox.AppendText(e.Message);
            }
        }

        private string CombineKQkqBoxes()
        {
            var result = "";

            result += KBox.Checked ? "K" : "";
            result += QBox.Checked ? "Q" : "";
            result += KSmBox.Checked ? "k" : "";
            result += QSmBox.Checked ? "q" : "";

            return result;
        }

        public static void MakeClick(int x, int y)
        {
            Cursor.Position = new Point(x, y);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0u, 0u, 0u, (UIntPtr)0);
            Thread.Sleep(50);
            mouse_event(MOUSEEVENTF_LEFTUP, 0u, 0u, 0u, (UIntPtr)0);
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;

            string localfen;

            try
            {
                localfen = await GetFenFromBrowser();
            }
            catch (Exception exception)
            {
                richTextBox.AppendText(exception.Message);
                return;
            }


            if (localfen != GlobalFen)
            {
                GlobalFen = localfen;

                ourMove = !ourMove;

                if (ourMove)
                {
                    AnalyseAndMove(GlobalFen);
                }
            }

            timer.Enabled = true;
        }

        private async Task<string> GetFenFromBrowser()
        {
            string html = "";
            await chrome.GetSourceAsync().ContinueWith(taskHtml =>
            {
                html = taskHtml.Result;
            });

            return GetFenFromWebPage(html);
        }

        private void PlayForMe_CheckedChanged(object sender, EventArgs e)
        {
            timer.Enabled = PlayForMe.Checked;

            if (timer.Enabled)
            {
                ourMove = false;
            }
        }

        private void cliiiick_Click(object sender, EventArgs e)
        {
            MakeClick(int.Parse(xCoord.Text), int.Parse(yCoord.Text));
        }

        private void ClearRtb_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }
    }
}
