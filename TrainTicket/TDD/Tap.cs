using System;

namespace TDD
{
    public class Tap
    {
        public readonly DateTime Time;

        public readonly Guid MachineId;

        public Tap(Guid machineId,  DateTime time )
        {
            Time = time;

            MachineId = machineId;
        }

    }
}