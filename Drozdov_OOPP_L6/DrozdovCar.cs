using System;
using System.Xml.Serialization;


namespace Drozdov_OOPP_L6
{
    [XmlInclude(typeof(DrozdovSportCar))]
    public class DrozdovCar
    {
        public string name;
        public int year = 0;
        public double strt_prc = 0;
        public virtual void updateForm(Form1 form)
        {
            form.textBoxName.Text = name;
            form.textBoxYear.Text = Convert.ToString(year);
            form.textBoxStrPrc.Text = Convert.ToString(strt_prc);

            form.label1.Visible = true;
            form.textBoxName.Visible = true;
            form.label2.Visible = true;
            form.textBoxYear.Visible = true;
            form.label3.Visible = true;
            form.textBoxStrPrc.Visible = true;
            form.textBoxTorque.Visible = false;
            form.label4.Visible = false;
            form.label5.Visible = false;
            form.textBoxPower.Visible = false;
        }
        public virtual void saveData(Form1 form)
        {
            name = form.textBoxName.Text;
            if (form.textBoxYear.Text != "")
            {
                year = Convert.ToInt32(form.textBoxYear.Text);
            }
            if (form.textBoxStrPrc.Text != "")
            {
                strt_prc = Convert.ToDouble(form.textBoxStrPrc.Text);
            }

        }
        public virtual void add(SharpStruct s)
        {
            name = s.name;
            year = s.year;
            strt_prc = s.strt_prc;
        }
        public virtual void output(SharpStruct s)
        {
            s.name = name;
            s.year = year;
            s.strt_prc = strt_prc;
        }
        public virtual string getMainData()
        {
            return String.Format("{0}", name);
        }

        public virtual SharpStruct upload()
        {
            var s = new SharpStruct();
            s.name = name;
            s.year = year;
            s.strt_prc = strt_prc;
            return s;
        }
    }
}
