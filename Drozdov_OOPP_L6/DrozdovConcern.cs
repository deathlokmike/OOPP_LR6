using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Drozdov_OOPP_L6
{
    public class DrozdovConcern 
    {
        public List<DrozdovCar> motorshow = new List<DrozdovCar>();
        public void add(SharpStruct s)
        {
            DrozdovCar vhcl = new DrozdovCar();
            vhcl.add(s);
            motorshow.Add(vhcl);
        }
        public void adds(SharpStruct s)
        {
            DrozdovCar vhcl = new DrozdovSportCar();
            vhcl.add(s);
            motorshow.Add(vhcl);
        }

        public SharpStruct upload(int i)
        {
            var t = new SharpStruct();
            t = motorshow[i].upload();
            return t;
        }
    }
}

