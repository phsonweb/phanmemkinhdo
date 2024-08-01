using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace PhanMemKinhDoMienBac.Class
{
    public class PlcManager
    {
        private Plc plc;

        public bool IsConnected => plc != null && plc.IsConnected;

        public void Connect(CpuType cpuType, string ipAddress, short rack, short slot)
        {
            plc = new Plc(cpuType, ipAddress, rack, slot);
            plc.Open();
        }

        public void Disconnect()
        {
            if (plc != null && plc.IsConnected)
            {
                plc.Close();
            }
        }

        public object Read(string address)
        {
            if (plc == null || !plc.IsConnected)
            {
                throw new InvalidOperationException("Not connected to PLC.");
            }

            return plc.Read(address);
        }

        public void Write(string address, object value)
        {
            if (plc == null || !plc.IsConnected)
            {
                throw new InvalidOperationException("Not connected to PLC.");
            }

            plc.Write(address, value);
        }
    }
}
