using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomClock
{
    public partial class Form1 : Form
    {
        public Graphics _GRAPHICS;
        public int _CLOCKSTATE = 0;

        public int _HOUR = 0;
        public int _MINUTE = 0;
        public int _SECOND = 0;

        public float _DIGITALSTARTX = 16;
        public float _DIGITALSTARTY = 32;
        public float _DIGITALPIXSIZE = 12;

        public Color _DIGITALBACKGROUND = Color.FromArgb(0, 0, 0);//Color.FromArgb(67, 82, 61);
        public Color _DIGITALFOREGROUND = Color.FromArgb(63, 207, 63);//Color.FromArgb(199, 240, 216);

        public int[] _TIMERTIME = { 0, 0, 0, 0 };

        public bool _TIMERACTIVE = false;
        public float _TIMERSTARTX = 16;
        public float _TIMERSTARTY = 64;
        public float _TIMERPIXSIZE = 10;

        public int[] _COUNTDOWNTIME = null;
        SoundPlayer _COUNTDOWNALARM = new SoundPlayer(Properties.Resources.Alarm);

        public float _COUNTDOWNSTARTX = 16;
        public float _COUNTDOWNSTARTY = 32;
        public float _COUNTDOWNPIXSIZE = 10;

        public Size _STATE0SIZE;
        public Size _STATE1SIZE;
        public Size _STATE2SIZE;
        public Size _STATE3SIZE;

        public string[] _SEGMENTS = { "1110111", "0010010", "1011101", "1011011", "0111010", "1101011", "1101111", "1010010", "1111111", "1111011" };

        public Form1()
        {
            InitializeComponent();

            txtCountDownTime.Visible = false;
            cmdStartCountDown.Visible = false;

            cmdToggleTimer.Visible = false;
            cmdReset.Visible = false;

            _GRAPHICS = CreateGraphics();

            _STATE0SIZE = new Size(516, 539);
            _STATE1SIZE = new Size(516, (int)_DIGITALSTARTY + 13 * (int)_DIGITALPIXSIZE + 6);
            _STATE2SIZE = new Size(516, (int)_TIMERSTARTY + 13 * (int)_TIMERPIXSIZE + 13);
            _STATE3SIZE = new Size(516, (int)_COUNTDOWNSTARTY + 13 * (int)_COUNTDOWNPIXSIZE + 13);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(DateTime.Now.Second != _SECOND || _CLOCKSTATE >= 2)
            {
                clearState();

                DateTime current = DateTime.Now;
                _HOUR = current.Hour;
                _MINUTE = current.Minute;
                _SECOND = current.Second;

                drawState();
            }
        }

        public void clearState()
        {
            switch (_CLOCKSTATE)
            {
                case 0:
                    Pen pen = new Pen(BackColor);

                    float secondsVal = (_SECOND / 60f) * 360f * (float)(Math.PI / 180f);
                    float minutesVal = (_MINUTE / 60f) * 360f * (float)(Math.PI / 180f);
                    float hoursVal = ((_HOUR > 12 ? _HOUR - 12 : _HOUR) / 12f) * 360f * (float)(Math.PI / 180f);
                    _GRAPHICS.DrawLine(pen, new PointF(250, 250), new PointF(250 + (float)Math.Sin(secondsVal) * 185, 250 + (float)Math.Cos(secondsVal) * -185));
                    _GRAPHICS.DrawLine(pen, new PointF(250, 250), new PointF(250 + (float)Math.Sin(minutesVal) * 155, 250 + (float)Math.Cos(minutesVal) * -155));
                    _GRAPHICS.DrawLine(pen, new PointF(250, 250), new PointF(250 + (float)Math.Sin(hoursVal) * 100, 250 + (float)Math.Cos(hoursVal) * -100));
                    break;
                case 2:
                    break;
            }
        }

        public void drawState()
        {
            switch (_CLOCKSTATE)
            {
                case 0:
                    _GRAPHICS.DrawEllipse(Pens.Black, new Rectangle(40, 40, 420, 420));

                    float secondsVal = (_SECOND / 60f)*360f*(float)(Math.PI/180f);
                    float minutesVal = (_MINUTE / 60f)*360f*(float)(Math.PI/180f);
                    float hoursVal = ((_HOUR > 12 ? _HOUR - 12 : _HOUR) / 12f)*360f*(float)(Math.PI/180f);
                    _GRAPHICS.DrawLine(Pens.Red, new PointF(250, 250), new PointF(250+(float)Math.Sin(secondsVal)*185, 250+(float)Math.Cos(secondsVal)*-185));
                    _GRAPHICS.DrawLine(Pens.Black, new PointF(250, 250), new PointF(250+(float)Math.Sin(minutesVal)*155, 250+(float)Math.Cos(minutesVal)*-155));
                    _GRAPHICS.DrawLine(Pens.Black, new PointF(250, 250), new PointF(250+(float)Math.Sin(hoursVal)*100, 250+(float)Math.Cos(hoursVal)*-100));

                    _GRAPHICS.DrawEllipse(Pens.Black, new Rectangle(40, 40, 420, 420));
                    for (int i = 0; i < 60; i++)
                    {
                        int length = i % 5 == 0 ? 20 : 10;
                        float val = (i / 60f) * 360f * (float)(Math.PI / 180f);

                        _GRAPHICS.DrawLine(Pens.Black, new PointF(250 + (float)(Math.Sin(val)) * (210 - length), 250 + (float)(Math.Cos(val)) * (210 - length)), new PointF(250 + (float)(Math.Sin(val)) * (210), 250 + (float)(Math.Cos(val)) * (210)));
                    }
                    break;
                case 1:
                    float pixSize = _DIGITALPIXSIZE;
                    float startX = _DIGITALSTARTX;
                    float startY = _DIGITALSTARTY;

                    string hour = _HOUR.ToString(); if (hour.Length == 1) hour = "0" + hour;
                    string minute = _MINUTE.ToString(); if (minute.Length == 1) minute = "0" + minute;
                    string second = _SECOND.ToString(); if (second.Length == 1) second = "0" + second;

                    _GRAPHICS.FillRectangle(new SolidBrush(_DIGITALBACKGROUND), _DIGITALSTARTX - _DIGITALPIXSIZE, _DIGITALSTARTY - _DIGITALPIXSIZE, 41 * _DIGITALPIXSIZE, 11 * _DIGITALPIXSIZE);
                    
                    drawDigitalNumber(int.Parse(hour[0].ToString()), startX, startY, pixSize);
                    drawDigitalNumber(int.Parse(hour[1].ToString()), startX + 6*pixSize, startY, pixSize);
                    drawColon(startX + 12*pixSize, startY, pixSize);
                    drawDigitalNumber(int.Parse(minute[0].ToString()), startX + 14*pixSize, startY, pixSize);
                    drawDigitalNumber(int.Parse(minute[1].ToString()), startX + 20*pixSize, startY, pixSize);
                    drawColon(startX + 26*pixSize, startY, pixSize);
                    drawDigitalNumber(int.Parse(second[0].ToString()), startX + 28*pixSize, startY, pixSize);
                    drawDigitalNumber(int.Parse(second[1].ToString()), startX + 34*pixSize, startY, pixSize);
                    break;
                case 2:
                    if (_TIMERACTIVE)
                    {
                        int hour3 = _TIMERTIME[0];
                        int minute3 = _TIMERTIME[1];
                        int second3 = _TIMERTIME[2];
                        int millis3 = _TIMERTIME[3];

                        millis3++;
                        if (millis3 > 9)
                        {
                            millis3 = 0;
                            second3++;
                            if (second3 > 59)
                            {
                                second3 = 0;
                                minute3++;
                                if (minute3 > 59)
                                {
                                    minute3 = 0;
                                    hour3++;
                                }
                            }
                        }

                        string hStr2 = hour3.ToString(); if (hStr2.Length == 1) hStr2 = "0" + hStr2;
                        string mStr2 = minute3.ToString(); if (mStr2.Length == 1) mStr2 = "0" + mStr2;
                        string sStr2 = second3.ToString(); if (sStr2.Length == 1) sStr2 = "0" + sStr2;
                        string miStr2 = millis3.ToString();

                        _GRAPHICS.FillRectangle(new SolidBrush(_DIGITALBACKGROUND), _TIMERSTARTX - _TIMERPIXSIZE, _TIMERSTARTY - _TIMERPIXSIZE, 49 * _TIMERPIXSIZE, 11 * _TIMERPIXSIZE);

                        drawDigitalNumber(int.Parse(hStr2[0].ToString()), _TIMERSTARTX, _TIMERSTARTY, _TIMERPIXSIZE);
                        drawDigitalNumber(int.Parse(hStr2[1].ToString()), _TIMERSTARTX + 6 * _TIMERPIXSIZE, _TIMERSTARTY, _TIMERPIXSIZE);
                        drawColon(_TIMERSTARTX + 12 * _TIMERPIXSIZE, _TIMERSTARTY, _TIMERPIXSIZE);
                        drawDigitalNumber(int.Parse(mStr2[0].ToString()), _TIMERSTARTX + 14 * _TIMERPIXSIZE, _TIMERSTARTY, _TIMERPIXSIZE);
                        drawDigitalNumber(int.Parse(mStr2[1].ToString()), _TIMERSTARTX + 20 * _TIMERPIXSIZE, _TIMERSTARTY, _TIMERPIXSIZE);
                        drawColon(_TIMERSTARTX + 26 * _TIMERPIXSIZE, _TIMERSTARTY, _TIMERPIXSIZE);
                        drawDigitalNumber(int.Parse(sStr2[0].ToString()), _TIMERSTARTX + 28 * _TIMERPIXSIZE, _TIMERSTARTY, _TIMERPIXSIZE);
                        drawDigitalNumber(int.Parse(sStr2[1].ToString()), _TIMERSTARTX + 34 * _TIMERPIXSIZE, _TIMERSTARTY, _TIMERPIXSIZE);
                        drawColon(_TIMERSTARTX + 40 * _TIMERPIXSIZE, _TIMERSTARTY, _TIMERPIXSIZE);
                        drawDigitalNumber(int.Parse(miStr2[0].ToString()), _TIMERSTARTX + 42 * _TIMERPIXSIZE, _TIMERSTARTY, _TIMERPIXSIZE);

                        _TIMERTIME = new int[] { hour3, minute3, second3, millis3 };
                    }
                    break;
                case 3:
                    if (_COUNTDOWNTIME != null)
                    {
                        int hour2 = _COUNTDOWNTIME[0];
                        int minute2 = _COUNTDOWNTIME[1];
                        int second2 = _COUNTDOWNTIME[2];
                        int millis2 = _COUNTDOWNTIME[3];

                        string hStr = hour2.ToString(); if (hStr.Length == 1) hStr = "0" + hStr;
                        string mStr = minute2.ToString(); if (mStr.Length == 1) mStr = "0" + mStr;
                        string sStr = second2.ToString(); if (sStr.Length == 1) sStr = "0" + sStr;
                        string miStr = millis2.ToString();

                        millis2--;
                        if (millis2 < 0)
                        {
                            millis2 = 9;
                            second2--;
                            if (second2 < 0)
                            {
                                second2 = 59;
                                minute2--;
                                if (minute2 < 0)
                                {
                                    minute2 = 59;
                                    hour2--;
                                    if (hour2 < 0)
                                    {
                                        hour2 = 0;
                                        minute2 = 0;
                                        second2 = 0;
                                        millis2 = 0;
                                    }
                                }
                            }
                        }

                        _COUNTDOWNTIME = new int[] { hour2, minute2, second2, millis2 };

                        _GRAPHICS.FillRectangle(new SolidBrush(_DIGITALBACKGROUND), _COUNTDOWNSTARTX - _COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY - _COUNTDOWNPIXSIZE, 49 * _COUNTDOWNPIXSIZE, 11 * _COUNTDOWNPIXSIZE);
                        
                        drawDigitalNumber(int.Parse(hStr[0].ToString()), _COUNTDOWNSTARTX, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);
                        drawDigitalNumber(int.Parse(hStr[1].ToString()), _COUNTDOWNSTARTX + 6*_COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);
                        drawColon(_COUNTDOWNSTARTX + 12*_COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);
                        drawDigitalNumber(int.Parse(mStr[0].ToString()), _COUNTDOWNSTARTX + 14 * _COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);
                        drawDigitalNumber(int.Parse(mStr[1].ToString()), _COUNTDOWNSTARTX + 20 * _COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);
                        drawColon(_COUNTDOWNSTARTX + 26 * _COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);
                        drawDigitalNumber(int.Parse(sStr[0].ToString()), _COUNTDOWNSTARTX + 28 * _COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);
                        drawDigitalNumber(int.Parse(sStr[1].ToString()), _COUNTDOWNSTARTX + 34 * _COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);
                        drawColon(_COUNTDOWNSTARTX + 40 * _COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);
                        drawDigitalNumber(int.Parse(miStr[0].ToString()), _COUNTDOWNSTARTX + 42 * _COUNTDOWNPIXSIZE, _COUNTDOWNSTARTY, _COUNTDOWNPIXSIZE);

                        if (hour2 == 0 && minute2 == 0 && second2 == 0 && millis2 == 0)
                        {
                            _COUNTDOWNTIME = null;
                            _COUNTDOWNALARM.Play();
                        }
                    }
                    break;
            }
        }

        //functions

        public void drawDigitalNumber(int num, float x, float y, float pixSize)
        {
            string seg = _SEGMENTS[num];
            SolidBrush brush = new SolidBrush(_DIGITALFOREGROUND);

            if (seg[0] == '1') _GRAPHICS.FillRectangle(brush, new RectangleF(x + 1 * pixSize, y + 0 * pixSize, 3 * pixSize, 1 * pixSize));
            if (seg[1] == '1') _GRAPHICS.FillRectangle(brush, new RectangleF(x + 0 * pixSize, y + 1 * pixSize, 1 * pixSize, 3 * pixSize));
            if (seg[2] == '1') _GRAPHICS.FillRectangle(brush, new RectangleF(x + 4 * pixSize, y + 1 * pixSize, 1 * pixSize, 3 * pixSize));
            if (seg[3] == '1') _GRAPHICS.FillRectangle(brush, new RectangleF(x + 1 * pixSize, y + 4 * pixSize, 3 * pixSize, 1 * pixSize));
            if (seg[4] == '1') _GRAPHICS.FillRectangle(brush, new RectangleF(x + 0 * pixSize, y + 5 * pixSize, 1 * pixSize, 3 * pixSize));
            if (seg[5] == '1') _GRAPHICS.FillRectangle(brush, new RectangleF(x + 4 * pixSize, y + 5 * pixSize, 1 * pixSize, 3 * pixSize));
            if (seg[6] == '1') _GRAPHICS.FillRectangle(brush, new RectangleF(x + 1 * pixSize, y + 8 * pixSize, 3 * pixSize, 1 * pixSize));
        }

        public void drawColon(float x, float y, float pixSize)
        {
            _GRAPHICS.FillRectangle(new SolidBrush(_DIGITALFOREGROUND), new RectangleF(x, y+3*pixSize, pixSize, pixSize));
            _GRAPHICS.FillRectangle(new SolidBrush(_DIGITALFOREGROUND), new RectangleF(x, y+5*pixSize, pixSize, pixSize));
        }

        //change state

        private void clockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCountDownTime.Visible = false;
            cmdStartCountDown.Visible = false;
            cmdToggleTimer.Visible = false;
            cmdReset.Visible = false;
            _COUNTDOWNALARM.Stop();
            _COUNTDOWNTIME = null;
            _TIMERTIME = new int[] { 0, 0, 0, 0 };

            Text = "Clock+ - 12 Hour Clock";
            _CLOCKSTATE = 0;
            _GRAPHICS.Clear(BackColor);
            Size = _STATE0SIZE;
            drawState();
        }

        private void digitalClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCountDownTime.Visible = false;
            cmdStartCountDown.Visible = false;
            cmdToggleTimer.Visible = false;
            cmdReset.Visible = false;
            _COUNTDOWNALARM.Stop();
            _COUNTDOWNTIME = null;
            _TIMERTIME = new int[] { 0, 0, 0, 0 };

            Text = "Clock+ - Digital Clock";
            _CLOCKSTATE = 1;
            _GRAPHICS.Clear(BackColor);
            Size = _STATE1SIZE;
            drawState();
        }

        private void stopwatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCountDownTime.Visible = false;
            cmdStartCountDown.Visible = false;
            cmdToggleTimer.Visible = true;
            cmdReset.Visible = true;
            _COUNTDOWNALARM.Stop();
            _COUNTDOWNTIME = null;
            _TIMERTIME = new int[] { 0, 0, 0, 0 };

            Text = "Clock+ - Stop Watch";
            _CLOCKSTATE = 2;
            _GRAPHICS.Clear(BackColor);
            Size = _STATE2SIZE;
            drawState();
        }

        private void countdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCountDownTime.Visible = true;
            cmdStartCountDown.Visible = true;
            cmdToggleTimer.Visible = false;
            cmdReset.Visible = false;
            _COUNTDOWNALARM.Stop();
            _COUNTDOWNTIME = null;
            _TIMERTIME = new int[] { 0, 0, 0, 0 };

            Text = "Clock+ - Countdown";
            _CLOCKSTATE = 3;
            _GRAPHICS.Clear(BackColor);
            Size = _STATE3SIZE;
            drawState();
        }

        private void cmdStartCountDown_Click(object sender, EventArgs e)
        {
            if (txtCountDownTime.Text.Contains(":"))
            {
                string[] time = txtCountDownTime.Text.Split(':');

                txtCountDownTime.Visible = false;
                cmdStartCountDown.Visible = false;

                int hour = int.Parse(time[0].ToString());
                int minute = int.Parse(time[1].ToString());
                int second = int.Parse(time[2].ToString());
                int millis = int.Parse(time[3].ToString());

                _COUNTDOWNTIME = new int[] { hour, minute, second, millis };
            }
            else _COUNTDOWNTIME = null;
        }

        private void cmdToggleTimer_Click(object sender, EventArgs e)
        {
            if (_TIMERACTIVE)
            {
                _TIMERACTIVE = false;
                cmdToggleTimer.Text = "Start";
            } else
            {
                _TIMERACTIVE = true;
                cmdToggleTimer.Text = "Stop";
            }
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            _TIMERTIME = new int[] { 0, 0, 0, 0 };
            _GRAPHICS.FillRectangle(new SolidBrush(_DIGITALBACKGROUND), _TIMERSTARTX - _TIMERPIXSIZE, _TIMERSTARTY - _TIMERPIXSIZE, 49 * _TIMERPIXSIZE, 11 * _TIMERPIXSIZE);
        }
    }
}
