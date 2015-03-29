using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HTMLElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HTMLElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HTMLTable(rows, cols);
        }
    }

    public abstract class Element : IElement
    {
        private string name;
        private string textContent;
        protected ICollection<IElement> childElements;

        public Element(string name, string textContent)
        {
            this.name = name;
            this.textContent = textContent;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    this.name = value;
                else
                    this.name = null;
            }
        }

        public virtual string TextContent
        {
            get
            {
                return this.textContent;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    this.textContent = value;
                else
                    this.textContent = null;
            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { return new List<IElement>(childElements); }
        }

        public abstract void AddElement(IElement element);

        public abstract void Render(StringBuilder output);

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            this.Render(output);

            return output.ToString();
        }
    }

    public class HTMLElement : Element
    {
        public HTMLElement(string name, string content)
            : base(name, content)
        {
            base.childElements = new List<IElement>();
        }

        public HTMLElement(string name)
            : this(name, null) 
        {
        }

        public override void AddElement(IElement element)
        {
            base.childElements.Add(element);
        }

        public override void Render(StringBuilder output)
        {
            if (!string.IsNullOrWhiteSpace(base.Name))
            {
                output.Append(string.Format("<{0}>", base.Name));
            }

            if (!string.IsNullOrWhiteSpace(base.TextContent))
            {
                StringBuilder escapedContent = new StringBuilder();

                foreach (char ch in base.TextContent)
                {
                    if (ch == '<')
                        escapedContent.Append("&lt;");
                    else if (ch == '>')
                        escapedContent.Append("&gt;");
                    else
                        escapedContent.Append(ch);
                }

                output.Append(escapedContent.ToString());
            }

            foreach (IElement element in base.ChildElements)
            {
                output.Append(element.ToString());
            }

            if (!string.IsNullOrWhiteSpace(base.Name))
            {
                output.Append(string.Format("</{0}>", base.Name));
            }
        }
    }

    public class HTMLTable : Element, ITable
    {
        private int rows;
        private int cols;
        private IElement[,] matrix;

        public HTMLTable(int rows, int cols)
            : base("table", null)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new IElement[this.Rows, this.Cols];
        }

        public int Rows
        {
            get { return this.rows; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("The rows of a table cannot be negative;");

                this.rows = value;
            }
        }

        public int Cols
        {
            get { return this.cols; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("The cols of a table cannot be negative;");

                this.cols = value;
            }
        }

        public override string TextContent
        {
            get
            { throw new ApplicationException("The table doesn't have text contnet");}
            set
            { throw new ApplicationException("The table doesn't have text contnet");
}
        }

        public IElement this[int row, int col]
        {
            get
            {
                if (row <= 0 || row >= this.Rows)
                    throw new ArgumentException("The row you requested is outside the bounders of the table");

                if (col <= 0 || col >= this.Cols)
                    throw new ArgumentException("The col you requested is outside the bounders of the table");

                return this.matrix[row, col];
            }
            set
            {
                if (row <= 0 || row >= this.Rows)
                    throw new ArgumentException("The row you requested to set is outside the bounders of the table");

                if (col <= 0 || col >= this.Cols)
                    throw new ArgumentException("The col you requested to set is outside the bounders of the table");

                this.matrix[row, col] = value;
            }
        }

        public override void AddElement(IElement element)
        {
            throw new ApplicationException("The tables cannot have child elements");
        }

        public override void Render(StringBuilder output)
        {
            output.Append("<table>");
            for (int i = 0; i < this.Rows; i++)
            {
                output.Append("<tr>");

                for (int j = 0; j < this.Cols; j++)
                {
                    output.Append("<td>");

                    if (this[i, j] != null)
                        output.Append(this[i, j].ToString());

                    output.Append("</td>");
                }
                output.Append("</tr>");
            }

            output.Append("</table>");
        }
    }

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
			string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}

