Public Class Importer
    Inherits PlugIn.Base
    Implements PlugIn.IPlugIn

    Public Function Data() As String Implements PlugIn.IPlugIn.Data
        Return "DLL 2"
    End Function

End Class
