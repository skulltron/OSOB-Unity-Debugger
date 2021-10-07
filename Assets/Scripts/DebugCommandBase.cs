using System;

public class DebugCommandBase
{
    private string _CommandID, _CommandDescription, _CommandFormat;

    public string CommandID { get { return _CommandID; } }
    public string CommandDescription { get { return _CommandDescription; } }
    public string CommandFormat { get { return _CommandID; } }

    public DebugCommandBase(string ID, string Description, string Format)
    {
        _CommandID          = ID;
        _CommandDescription = Description;
        _CommandFormat      = Format;
    }
}

public class DebugCommand : DebugCommandBase
{
    private Action Command;

    public DebugCommand(string ID, string Description, string Format, Action Command) : base (ID, Description, Format)
    {
        this.Command = Command;
    }

    public void Invoke()
    {
        Command.Invoke();
    }
}

