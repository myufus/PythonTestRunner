A GUI application to select and run Python tests/scripts.

To run Python scripts, the application needs a JSON file outlining the locations and parameters for the Python methods to be run. The JSON file can be structured as a list of test information or as a tree with non-test group nodes for added organization.

Group Node JSON Fields
| field | type | description|
| --- | --- | --- |
| name | string | The name to display for this node in the application |
| subgroups | list | Other test group nodes to include under this group |
| tests | list | Test nodes to include under this group |

Test Node JSON Fields
| field | type | description|
| --- | --- | --- |
| name | string | The name to display for this node in the application |
| isTest | boolean | Include as true to indicate that this node contains Python test information |
| pythonPath | string | An absolute path to the file containing the test method |
| methodName | string | The name of the Python method to run |
| args | list[string, *] | (Optional) A list of arguments the Python method takes and the values to provide |
| logPath | string | (Optional) An absolute path to a text file containing the log outputs from this Python method |
