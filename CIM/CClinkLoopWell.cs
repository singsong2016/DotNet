#region 1.cclink loop 

var a = CClinkCore.ReadLed();//  0b1011 alarm 1101111 warn 
CClinkLoopWell = a == 0b1100111; //ok
if (!PLC.Simulation)
{
    if (a == 0b1101111)
    {
        DispenserMonitor.BuzzOn = true;
        PLC.set_R(CimMain.Node10 ? 922.08 : 922.04, true);
    }
    else
    {
        PLC.set_R(CimMain.Node10 ? 922.08 : 922.04, false);
    }
    if (a == 0b1011 || a == 0)
    {
        PLC.set_R(CimMain.Node10 ? 922.09 : 922.05, true);

        DispenserMonitor.BuzzOn = true;
        DispenserMonitor.StopDispenser = true;
    }
    else
    {
        PLC.set_R(CimMain.Node10 ? 922.09 : 922.05, false);
        DispenserMonitor.StopDispenser = false;
    }
    labelCCLINK.BackColor = CClinkLoopWell ? Color.Green : Color.OrangeRed;
    labelCCLINK.Text = CClinkLoopWell ? "CCLink Well" : "CClink Err";
}

#endregion
