using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Engine
    {
        private int engineSpeed;
        private int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EngineSpeed
        {
            get
            {
                return this.engineSpeed;
            }
            private set
            {
                this.engineSpeed = value;
            }
        }

        public int EnginePower
        {
            get
            {
                return this.enginePower;
            }
            private set
            {
                this.enginePower = value;
            }
        }
    }
}
