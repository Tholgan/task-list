using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    abstract class Command
    {
        private string Name;
        abstract public void Action(string[] args);
        abstract public void Action();
    }
}
