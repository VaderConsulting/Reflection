Public Class frmMain


    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        For Each Filename In IO.Directory.GetFiles(My.Application.Info.DirectoryPath, "*.dll")
            lstFiles.Items.Add(Filename)
        Next
    End Sub

    Private Sub lstFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFiles.SelectedIndexChanged
        Dim SelectedFileName As String = lstFiles.SelectedItem.ToString
        Dim PlugInName As String = "Importer"
        Dim Parameters() As String = {}
        Dim AssemblyName As String = ExecuteMethod(SelectedFileName, PlugInName, "Name", Parameters)
        Dim PlugInResult As String = ExecuteMethod(SelectedFileName, PlugInName, "Data")

        If Not PlugInResult Is Nothing Then
            lblResultValue.Text = AssemblyName & " returned:" & PlugInResult
        Else
            lblResultValue.Text = "-"
        End If

    End Sub

    ''' <summary>
    ''' Execute the given Method of the given Class in the given Filename.  Parameters can be specified.
    ''' </summary>
    ''' <param name="FileName">The filename of the Assembly</param>
    ''' <param name="ClassName">The Class containing the method to Invoke</param>
    ''' <param name="MethodName">The Method to Invoke</param>
    ''' <param name="Parameters">Optional Parameters() to supply</param>
    ''' <returns>Object, which the results of the Invoke specified</returns>
    ''' <remarks></remarks>
    Private Function ExecuteMethod(ByVal FileName As String, ByVal ClassName As String, ByVal MethodName As String, Optional ByVal Parameters() As Object = Nothing) As Object
        ' Create our return Object
        Dim ReturnObject As Object = Nothing

        ' Load the DLL
        Dim PlugInDLL As System.Reflection.Assembly

        Try
            PlugInDLL = System.Reflection.Assembly.LoadFrom(FileName)

            ' Load the types
            Dim DLLTypes() As Type = PlugInDLL.GetTypes

            ' Go through each Type...
            For Each AssemblyObject As Type In DLLTypes
                ' ... we are looking for a Class called [ClassName]
                If AssemblyObject.Name = ClassName And AssemblyObject.IsClass Then
                    ' Get the methods
                    Dim Methods() As System.Reflection.MethodInfo = AssemblyObject.GetMethods

                    ' Now look at the methods.  There should be a Method called [MethodName]
                    For Each Method In Methods
                        If Method.Name = MethodName Then
                            Dim Instance As Object = Activator.CreateInstance(AssemblyObject)

                            ' Finally, invoke the [MethodName] method and grab the returned object
                            ReturnObject = Method.Invoke(Instance, Parameters)

                            ' Cleanup 
                            Instance = Nothing

                            ' Return the object to the caller
                            Return ReturnObject
                        End If
                    Next
                End If
            Next
        Catch
            ' it is possible to get problems
        End Try

        PlugInDLL = Nothing

        Return Nothing
    End Function

End Class
