using System;

public class ScriptOutput {
    public string Output { get; set; }

    public string Errors { get; set; }

    public ScriptOutput(string output, string errors)
    {
        Output = output;
        Errors = errors;
    }
}