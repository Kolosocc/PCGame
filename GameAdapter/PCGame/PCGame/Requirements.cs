namespace GameApp.Models
{
    public class Requirements
    {
        private int gpuGB;
        private int hddGB;
        private int ramGB;
        private double cpuGhz;
        private int coresNum;

        public Requirements(int gpuGB, int hddGB, int ramGB, double cpuGhz, int coresNum)
        {
            this.gpuGB = gpuGB;
            this.hddGB = hddGB;
            this.ramGB = ramGB;
            this.cpuGhz = cpuGhz;
            this.coresNum = coresNum;
        }

        public int GetGpuGB() => gpuGB;
        public int GetHddGB() => hddGB;
        public int GetRamGB() => ramGB;
        public double GetCpuGhz() => cpuGhz;
        public int GetCoresNum() => coresNum;
    }
}
