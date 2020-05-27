﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataCallingFirefighters.ApplicationServices.Ports
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
