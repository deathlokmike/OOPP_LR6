using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Drozdov_OOPP_L6
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SharpStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string name;
        [MarshalAs(UnmanagedType.R8)]
        public double strt_prc;
        [MarshalAs(UnmanagedType.I4)]
        public int year;
        [MarshalAs(UnmanagedType.I4)]
        public int torque;
        [MarshalAs(UnmanagedType.I4)]
        public int engine_power;
    }
    public partial class Form1 : Form
    {
        int index;
        bool state = false;
        bool block = true;

        DrozdovConcern cars = new DrozdovConcern();
        public Form1()
        {
            InitializeComponent();
            index = listBox1.SelectedIndex;
            if (index <= 0)
            {
                label1.Visible = false;
                textBoxName.Visible = false;
                label2.Visible = false;
                textBoxYear.Visible = false;
                label3.Visible = false;
                textBoxStrPrc.Visible = false;
                textBoxTorque.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBoxPower.Visible = false;
            }
        }

        [DllImport("MFCLibrary.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void load(StringBuilder path);

        [DllImport("MFCLibrary.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void save(StringBuilder path);

        [DllImport("MFCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void clear();

        [DllImport("MFCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int getSize();

        [DllImport("MFCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int getType(int n);

        [DllImport("MFCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void GetStruct(ref SharpStruct s, int n);

        [DllImport("MFCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void SetStruct(ref SharpStruct s, int n);

        public void listBoxRewrite()
        {
            listBox1.Items.Clear();
            foreach (var car in cars.motorshow)
            {
                listBox1.Items.Add(car.name);
            }
        }
        public void OneRewrite(int n)
        {
            listBox1.Items.RemoveAt(n);
            listBox1.Items.Insert(n, cars.motorshow[n].name);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            onChangeFormTextBox();
        }

        private void textBoxStrPrc_TextChanged(object sender, EventArgs e)
        {
            onChangeFormTextBox();
        }

        private void clearControls()
        {
            textBoxTorque.Text = "";
            textBoxPower.Text = "";
            textBoxName.Text = "";
            textBoxYear.Text = "";
            textBoxStrPrc.Text = "";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = new StringBuilder(fileDialog.FileName);
                load(fileName);
                cars.motorshow.Clear();
                for (int i = 0; i < getSize(); i++)
                {

                    var s = new SharpStruct();
                    GetStruct(ref s, i);
                    if (s.torque == 0)
                        cars.add(s);
                    else
                        cars.adds(s);
                }
                listBoxRewrite();
            }
        }

        private void onChangeFormTextBox()
        {
            if (listBox1.SelectedIndex >= 0 && !block)
            {
                state = true;
                index = listBox1.SelectedIndex;
                var car = cars.motorshow[index];
                car.saveData(this);
                OneRewrite(index);
                listBox1.SetSelected(index, true);
                state = false;
            }
        }

        private void textBoxYear_TextChanged(object sender, EventArgs e)
        {
            onChangeFormTextBox();
        }

        private void textBoxTorque_TextChanged(object sender, EventArgs e)
        {
            onChangeFormTextBox();
        }

        private void textBoxPower_TextChanged(object sender, EventArgs e)
        {
            onChangeFormTextBox();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (state == false)
                {
                    var car = cars.motorshow[listBox1.SelectedIndex];
                    block = true;
                    car.updateForm(this);
                    block = false;
                }
            }
        }

        private void машинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            DrozdovCar car = new DrozdovCar();
            cars.motorshow.Add(car);
            listBox1.Items.Add(car.getMainData());
            clearControls();
            listBox1.SetSelected(listBox1.Items.Count - 1, true);
        }

        private void спорткарToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            DrozdovSportCar car = new DrozdovSportCar();
            cars.motorshow.Add(car);
            listBox1.Items.Add(car.getMainData());
            clearControls();
            listBox1.SetSelected(listBox1.Items.Count - 1, true);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                cars.motorshow.RemoveAt(index);
                listBox1.Items.RemoveAt(index);
            }

            clearControls();
            
            textBoxTorque.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBoxPower.Visible = false;
            if (index == 0)
            {
                label1.Visible = false;
                textBoxName.Visible = false;
                label2.Visible = false;
                textBoxYear.Visible = false;
                label3.Visible = false;
                textBoxStrPrc.Visible = false;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Filter = "All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                clear();
                for (int i = 0; i < cars.motorshow.Count; i++)
                {
                    var s = new SharpStruct();
                    s = cars.upload(i);
                    SetStruct(ref s, i);
                    
                }
                save(new StringBuilder(fileDialog.FileName));
            }
        }
    }
}
