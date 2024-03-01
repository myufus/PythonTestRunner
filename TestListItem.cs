using Python.Runtime;
using System;
using System.Configuration;
using System.Reflection;

public class TestListItem
{
    public string? name, pythonPath, methodName, logPath;
    public List<TestListItem>? subgroups, tests;
    public bool? isTest, testResult;
    public Dictionary<string, dynamic>? args;
    public TreeNode? node;

    public async void Run()
    {
        if (pythonPath != null && methodName != null)
        {
            PythonEngine.Initialize();
            dynamic sys = Py.Import("sys");
            sys.path.append(Path.GetDirectoryName(pythonPath));

            PyObject[] arguments;
            if (args == null)
            {
                arguments = Array.Empty<PyObject>();
            }
            else
            {
                arguments = new PyObject[args.Values.Count];
                for (int i = 0; i < args.Values.Count; i++)
                {
                    arguments[i] = PyObject.FromManagedObject(args.Values.ElementAt(i));
                }
            }

            using (Py.GIL())
            {
                PyObject module = Py.Import(Path.GetFileNameWithoutExtension(pythonPath));
                dynamic result = module.InvokeMethod(methodName, arguments);
                testResult = result.IsTrue();
            }

            PythonEngine.Shutdown();
        }
    }
}
