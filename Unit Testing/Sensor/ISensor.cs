using System;
using System.Collections.Generic;
using System.Text;

namespace Sensor
{
    public interface ISensor
    {
        double PopNextPressurePsiValue();

        double ReadPressureSample();
    }
}
