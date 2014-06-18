using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextNet
{
    public static class Carriers
    {
        static Carriers()
        {
            US = new USCarriers();
        }

        public static USCarriers US { get; private set; }

        public class USCarriers
        {
            public USCarriers()
            {
                AcsWireless = "US-AcsWireless";
                Alltel = "US-Alltel";
                Att = "US-AT&T";
                CellularOne = "US-CellularOne";
                Qwest = "US-Qwest";
                Rogers = "US-Rogers";
                SprintPcs = "US-SprintPcs";
                Telus = "US-Telus";
                TMobile = "US-TMobile";
                USCellular = "US-USCellular";
                Verizon = "US-Verizon";
                WindMobile = "US-WindMobile";
            }

            public string AcsWireless { get; private set; }
            public string Alltel { get; private set; }
            public string Att { get; private set; }
            public string CellularOne { get; private set; }
            public string Qwest { get; private set; }
            public string Rogers { get; private set; }
            public string SprintPcs { get; private set; }
            public string Telus { get; private set; }
            public string TMobile { get; private set; }
            public string USCellular { get; private set; }
            public string Verizon { get; private set; }
            public string WindMobile { get; private set; }

            public IEnumerable<string> All
            {
                get
                {
                    yield return AcsWireless;
                    yield return Alltel;
                    yield return Att;
                    yield return CellularOne;
                    yield return Qwest;
                    yield return Rogers;
                    yield return SprintPcs;
                    yield return Telus;
                    yield return TMobile;
                    yield return USCellular;
                    yield return Verizon;
                    yield return WindMobile;
                }
            }
        }
    }
}
