''' <summary>
''' Base class for plugins
''' </summary>
''' <remarks>
''' Any functionality that should be IDENTICAL acrosss all Plugins is to be placed into this class.
''' Use "Overridable" if the method can be modified (i.e. replaced) by the derived class.
''' </remarks>
Public MustInherit Class Base

    Public Overridable Function Name() As String
        Return "Base: " & Reflection.Assembly.GetExecutingAssembly().GetName.ToString
    End Function

End Class
