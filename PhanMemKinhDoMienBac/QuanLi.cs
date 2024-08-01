using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PhanMemKinhDoMienBac
{
    public partial class QuanLi : Form
    {
        private Dictionary<Control, Rectangle> originalSizes = new Dictionary<Control, Rectangle>();
        private Size originalFormSize;
        private bool sizesStored = false;
        public QuanLi()
        {
            InitializeComponent();
            //Add SIZE vào store để lưu giá trị
            this.Load += (s, e) =>
            {
                originalFormSize = this.ClientSize;
                StoreOriginalSizes(this);
                sizesStored = true;// Lưu kích thước ban đầu sau khi tất cả các điều khiển đã được thêm vào
            };


            this.SizeChanged += MainForm_SizeChanged;
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int simulatedPLCValue = GetSimulatedPLCValue();
            OnPLCDataReceived(simulatedPLCValue);
        }

        private Color GetRandomColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        private void QuanLi_Load(object sender, EventArgs e)
        {


        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        //Code thay đổi sizze giao diện khi có thay đổi size
        private void StoreOriginalSizes(Control control)
        {
            foreach (Control c in this.Controls) // Lưu kích thước cho các điều khiển ngoài panel
            {
                if (!originalSizes.ContainsKey(c))
                {
                    originalSizes[c] = new Rectangle(c.Left, c.Top, c.Width, c.Height);
                    Console.WriteLine($"Stored size for {c.Name}: {originalSizes.ContainsKey(c)}");

                }
            }

            foreach (Control c in control.Controls)
            {
                if (!originalSizes.ContainsKey(c))
                {
                    originalSizes[c] = new Rectangle(c.Left, c.Top, c.Width, c.Height);
                    Console.WriteLine($"Stored size for {c.Name}: {originalSizes.ContainsKey(c)}");
                }

                if (c.Controls.Count > 0)
                {
                    StoreOriginalSizes(c);  // Đệ quy để lưu kích thước của tất cả các điều khiển con
                }
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                if (!sizesStored)
                {
                    // Chờ cho đến khi StoreOriginalSizes hoàn tất
                    this.BeginInvoke(new Action(() =>
                    {
                        ResizeAllControls(this);
                    }));
                }
                else
                {
                    ResizeAllControls(this);
                }
            }
        }

        private void ResizeAllControls(Control control)
        {
            float xRatio = (float)this.ClientSize.Width / originalFormSize.Width;
            float yRatio = (float)this.ClientSize.Height / originalFormSize.Height;

            foreach (Control c in control.Controls)
            {
                var l = originalSizes.ContainsKey(c);
                if (originalSizes.ContainsKey(c))
                {
                    Rectangle originalRect = originalSizes[c];
                    c.Left = (int)(originalRect.Left * xRatio);
                    c.Top = (int)(originalRect.Top * yRatio);
                    c.Width = (int)(originalRect.Width * xRatio);
                    c.Height = (int)(originalRect.Height * yRatio);
                }

                if (c.Controls.Count > 0)
                {
                    ResizeAllControls(c);
                }
            }
        }


        // code test giả lập giá trị plc truyền vào
        // Phương thức này giả định bạn nhận giá trị từ PLC và cần cập nhật điều khiển
        private void UpdateSymbolFactoryControlFromPLC(int plcValue)
        {
            // Cập nhật giá trị cho SymbolFactoryControl
            if (plcValue == 0)
            {
                //Motor 160KW1
                motor1601Control.DiscreteValue1 = true;
                motor1601Control.DiscreteValue2 = false;
                motor1601Control.DiscreteValue3 = false;

                //Motor 160KW2
                motor1602Control.DiscreteValue1 = true;
                motor1602Control.DiscreteValue2 = false;
                motor1602Control.DiscreteValue3 = false;

                //Motor 70KW
                motor70Control.DiscreteValue1 = true;
                motor70Control.DiscreteValue2 = false;
                motor70Control.DiscreteValue3 = false;

                //Motor 90KW1
                motor901Control.DiscreteValue1 = true;
                motor901Control.DiscreteValue2 = false;
                motor901Control.DiscreteValue3 = false;

                //Motor 90KW2
                motor902Control.DiscreteValue1 = true;
                motor902Control.DiscreteValue2 = false;
                motor902Control.DiscreteValue3 = false;
            }
            else if (plcValue == 1)
            {
                //Motor 160KW1
                motor1601Control.DiscreteValue1 = false;
                motor1601Control.DiscreteValue2 = true;
                motor1601Control.DiscreteValue3 = false;

                //Motor 160KW2
                motor1602Control.DiscreteValue1 = false;
                motor1602Control.DiscreteValue2 = true;
                motor1602Control.DiscreteValue3 = false;

                //Motor 70KW
                motor70Control.DiscreteValue1 = false;
                motor70Control.DiscreteValue2 = true;
                motor70Control.DiscreteValue3 = false;

                //Motor 90KW1
                motor901Control.DiscreteValue1 = false;
                motor901Control.DiscreteValue2 = true;
                motor901Control.DiscreteValue3 = false;

                //Motor 90KW2
                motor902Control.DiscreteValue1 = false;
                motor902Control.DiscreteValue2 = true;
                motor902Control.DiscreteValue3 = false;
            }
            else
            {
                //Motor 160KW1
                motor1601Control.DiscreteValue1 = false;
                motor1601Control.DiscreteValue2 = false;
                motor1601Control.DiscreteValue3 = true;

                //Motor 160KW2
                motor1602Control.DiscreteValue1 = false;
                motor1602Control.DiscreteValue2 = false;
                motor1602Control.DiscreteValue3 = true;

                //Motor 70KW
                motor70Control.DiscreteValue1 = false;
                motor70Control.DiscreteValue2 = false;
                motor70Control.DiscreteValue3 = true;

                //Motor 90KW1
                motor901Control.DiscreteValue1 = false;
                motor901Control.DiscreteValue2 = false;
                motor901Control.DiscreteValue3 = true;

                //Motor 90KW2
                motor902Control.DiscreteValue1 = false;
                motor902Control.DiscreteValue2 = false;
                motor902Control.DiscreteValue3 = true;
            }

        }

        // Ví dụ gọi UpdateSymbolFactoryControlFromPLC khi có dữ liệu từ PLC

        private void OnPLCDataReceived(int plcValue)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => UpdateSymbolFactoryControlFromPLC(plcValue)));
            }
            else
            {
                UpdateSymbolFactoryControlFromPLC(plcValue);
            }
        }

        private int GetSimulatedPLCValue()
        {
            // Giả lập giá trị PLC
            // Thay đổi giá trị ở đây để kiểm tra
            return new Random().Next(0, 3); // Giá trị ngẫu nhiên từ 0 đến 2
        }
    }
}
