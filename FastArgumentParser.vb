' ***********************************************************************
' Author   : Destroyer
' Github   : https://github.com/DestroyerDarkNess
' Modified : 26-1-2023
' ***********************************************************************
' <copyright file="FastArgumentParser.vb" company="S4lsalsoft">
'     Copyright (c) S4lsalsoft. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Usage Examples "

''Commandline Arguments
'' This contains the following:
'' -file "d3d9.h" -silent 0x146 H&146
'Dim CommandLineArgs As String() = Environment.GetCommandLineArgs

'Dim FastArgumentParser As Core.FastArgumentParser = New Core.FastArgumentParser()

'' Optional Config
'' FastArgumentParser.ArgumentDelimiter = "-"

'' Set your Arguments
'Dim FileA As IArgument = FastArgumentParser.Add("file").SetDescription("file name")
'Dim SilentA As IArgument = FastArgumentParser.Add("silent").SetDescription("start silent")

'' Parse Arguments
'FastArgumentParser.Parse(CommandLineArgs)
'' Or
'' FastArgumentParser.Parse(CommandLineArgs, " ") ' To config Parameters Delimiter


'' Get Arguments Values
'Console.WriteLine("Argument " & FileA.Name & " Value is: " & FileA.Value)
'Console.WriteLine("Argument " & SilentA.Name & " Value is: " & SilentA.Value)

#End Region

#Region " Imports "

Imports System.Collections.Specialized

#End Region

Namespace Core

    Public Class FastArgumentParser

        Private Property ArgumentList As List(Of IArgument)
        Public Property ArgumentDelimiter As String = "-"

        Private UnknownArgs As New List(Of IArgument)
        Public ReadOnly Property UnknownArguments As List(Of IArgument)
            Get
                Return UnknownArgs
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return ArgumentList.Count()
            End Get
        End Property

        Public Sub New()
            ArgumentList = New List(Of IArgument)
        End Sub

        Public Function Add(ByVal name As String) As IArgument
            If name.StartsWith(ArgumentDelimiter) = False Then name = ArgumentDelimiter & name
            Dim ArgHandler As IArgument = New IArgument() With {.Name = name}
            ArgumentList.Add(ArgHandler)
            Return ArgHandler
        End Function

        Public Sub Parse(ByVal args As String(), Optional ByVal ParameterDelimiter As String = " ")
            Dim argCol As StringCollection = New StringCollection()
            argCol.AddRange(args)

            Dim strEnum As StringEnumerator = argCol.GetEnumerator()

            Dim CountRequiredArg As Integer = 0

            Dim LastArg As IArgument = Nothing

            While strEnum.MoveNext()

                If strEnum.Current.StartsWith(ArgumentDelimiter) Then
                    Dim GetArg As IArgument = GetArgCommand(strEnum.Current)
                    LastArg = GetArg

                    If GetArg Is Nothing Then
                        Dim UnknownA As IArgument = New IArgument With {.Name = strEnum.Current}
                        UnknownArgs.Add(UnknownA)
                    End If

                Else
                    If LastArg IsNot Nothing Then
                        If Not LastArg.Value = String.Empty Then LastArg.Value += ParameterDelimiter
                        LastArg.Value += strEnum.Current
                        Continue While
                    End If
                End If

            End While

        End Sub

        Private Function GetArgCommand(ByVal NameEx As String) As IArgument
            For Each item In ArgumentList
                If NameEx.Equals(item.Name) Then Return item
            Next
            Return Nothing
        End Function


    End Class

    Public Class IArgument
        Public Property Name As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property Value As String = String.Empty

        Public Function SetDescription(ByVal _text As String) As IArgument
            Me.Description = _text
            Return Me
        End Function
    End Class

End Namespace

