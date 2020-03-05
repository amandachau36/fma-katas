using System;

namespace TDD
{
    public class TapOn
    {
        public readonly DateTime Time;

        public readonly Guid MachineId;

        public TapOn(Guid machineId,  DateTime time )
        {
            Time = time;

            MachineId = machineId;
        }

    }
}