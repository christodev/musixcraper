using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using IronPython.Hosting;
// using IronPython.Hosting;

public class PyRunner {
    
    public PyRunner()
    {
        
    }

    public ScriptOutput RunScript(){

        //Create Process Info
        var psi = new ProcessStartInfo();
        psi.FileName = @"/usr/bin/python3";

        //Provide script and args
        var script = @"/Users/kik/Documents/WebScraping/musixcraper2.py";
        psi.Arguments = $"\"{script}\"";

        //Process Config
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;

        //Exec process and get output
        var errors = "";
        var output = "";

        using(var process = Process.Start(psi)){
            errors = process.StandardError.ReadToEnd();
            output = process.StandardOutput.ReadToEnd();
        }


        //Return Errors and Output to display them
        return new ScriptOutput(output, errors);
    }
    public ScriptOutput RunScript2() {
        //Try IronPython on visual studio

        //Create Engine
        var engine = Python.CreateEngine();

        //Provide script and args
        var script = @"/Users/kik/Documents/WebScraping/musixcraper2.py";
        var source = engine.CreateScriptSourceFromFile(script);


        //Output Redirect
        var engineIO = engine.Runtime.IO;

        var errors = new MemoryStream();
        engineIO.SetErrorOutput(errors, Encoding.Default);


        var results = new MemoryStream();
        engineIO.SetOutput(results, Encoding.Default);

        //Execute Script
        var scope = engine.CreateScope();
        source.Execute(scope);

        //Display output
        string str(byte[] x) => Encoding.Default.GetString(x);

        Console.WriteLine("Errors:");
        Console.WriteLine(str(errors.ToArray()));
        Console.WriteLine();
        Console.WriteLine("Results:");
        Console.WriteLine(str(results.ToArray()));

        return new ScriptOutput("","");
    }
}