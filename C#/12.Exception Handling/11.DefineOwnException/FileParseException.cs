using System;
using System.Collections.Generic;

class FileParseException : Exception
{
    private string fileName;
    private int line;
    private string exceptionMessage;

    //define the properties of the class
    public string FileName
    {
        get
        {
            return this.fileName;
        }
    }

    public int Line
    {
        get
        {
            return this.line;
        }
    }

    public string ExceptionMesssage
    {
        get
        {
            return this.exceptionMessage;
        }
    }

    //define the constructor of the class
    public FileParseException(string FileName, int Line) : base()
    {
        this.fileName = FileName;
        this.line = Line;
        this.exceptionMessage = "In the file " + fileName + " number expected at line " + line;
    }

}
