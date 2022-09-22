using System;

namespace Drozdov_OOPP_L6
{
    [Serializable]
    public class DrozdovSportCar : DrozdovCar
    {
        public int engine_power;
        public int torque = 0;
        public override void updateForm(Form1 form)
        {
            base.updateForm(form);
            form.label4.Visible = true;
            form.label5.Visible = true;
            form.textBoxTorque.Visible = true;
            form.textBoxPower.Visible = true;
            form.textBoxTorque.Text = Convert.ToString(torque);
            form.textBoxPower.Text = Convert.ToString(engine_power);
        }

        public override void saveData(Form1 form)
        {
            base.saveData(form);
            if (form.textBoxTorque.Text != "")
            {
                torque = Convert.ToInt32(form.textBoxTorque.Text);
            }
            if (form.textBoxPower.Text != "")
            {
                engine_power = Convert.ToInt32(form.textBoxPower.Text);
            }
        }
        public override void add(SharpStruct st)
        {
            base.add(st);
            torque = st.torque;
            engine_power = st.engine_power;
        }
        public override void output(SharpStruct st)
        {
            base.output(st);
            st.torque = torque;
            st.engine_power = engine_power;
        }

        public override string getMainData()
        {
            return String.Format("{0}", base.getMainData());
        }
        public override SharpStruct upload()
        {
            var s = new SharpStruct();
            s = base.upload();
            s.torque = torque;
            s.engine_power = engine_power;
            return s;
        }
    }
}
