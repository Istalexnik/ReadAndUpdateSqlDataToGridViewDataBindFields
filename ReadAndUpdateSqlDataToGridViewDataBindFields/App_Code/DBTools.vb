Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class DBTools
    Inherits BasePage

    Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    Public Sub LoadGrid(grid As GridView, table As String, Optional sortExpression As String = Nothing)

        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("select * from " & table & " order by 1 desc", con)
                Using sda As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable
                    sda.Fill(dt)
                    If Not sortExpression Is Nothing Then
                        Dim dv As DataView = dt.AsDataView
                        Me.SortDirection = IIf(Me.SortDirection = "ASC", "DESC", "ASC")
                        dv.Sort = sortExpression & " " & Me.SortDirection
                        grid.DataSource = dv
                    Else
                        grid.DataSource = dt
                    End If
                    grid.DataBind()
                End Using
            End Using
        End Using
    End Sub

    Public Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "DESC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property



    Public Sub InsertDataText(params As Dictionary(Of String, String), table As String)
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandType = CommandType.Text
                ' If Me.Page.IsValid Then

                Dim lParams As New List(Of String)
                Dim lColumns As New List(Of String)


                For Each p In params
                    If Not String.IsNullOrEmpty(p.Value) Then
                        cmd.Parameters.AddWithValue("@" + p.Key, p.Value)
                        lParams.Add("@" + p.Key)
                        lColumns.Add(p.Key)
                    End If
                Next

                'cmd.Parameters.AddWithValue("@lastname", txtLastname.Text)
                'cmd.Parameters.AddWithValue("@nickname", txtNickname.Text)
                'cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                'cmd.Parameters.AddWithValue("@password", txtPassword.Text)

                If lColumns.Any() Then
                    cmd.CommandText = "Insert into " & table & " (" & String.Join(",", lColumns) & ") values (" & String.Join(",", lParams) & ")"
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()

                    Dim message As String = "Record Inserted"
                    ' Response.Write("<script>window.location='PlayersData.aspx';</script>")
                    Response.Write("<script>alert('" + message + "');window.location='PlayersData.aspx';</script>")
                    'ClientScript.RegisterClientScriptBlock(Me.GetType(), "ConfirmationAlert", "<script>alert('Record Saved');</script>")
                End If

                '   End If
            End Using
        End Using
    End Sub


    Public Sub InsertDataProc(params As Dictionary(Of String, String), procName As String)
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(procName, con)
                cmd.CommandType = CommandType.StoredProcedure

                Dim lParams As New List(Of String)
                Dim lColumns As New List(Of String)


                For Each p In params
                    If Not String.IsNullOrEmpty(p.Value) Then
                        cmd.Parameters.AddWithValue("@" + p.Key, p.Value)
                        lParams.Add("@" + p.Key)
                        lColumns.Add(p.Key)
                    End If
                Next
                cmd.Parameters.Add("@outputmessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output

                con.Open()
                cmd.ExecuteNonQuery()

                Dim message As String = cmd.Parameters("@outputmessage").Value
                Response.Write("<script>alert('" + message + "');window.location='PlayersData.aspx';</script>")
                'ClientScript.RegisterClientScriptBlock(Me.GetType(), "ConfirmationAlert", "<script>alert('Record Saved');</script>")
            End Using
        End Using
    End Sub


    Public Sub SearchDataQuery(grid As GridView, params As Dictionary(Of String, String), table As String)
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand()
                cmd.CommandType = CommandType.Text
                Dim sda As New SqlDataAdapter(cmd)

                Dim searchStatement As String = "select * from " & table & " where 1=1 "

                For Each p In params
                    If Not String.IsNullOrEmpty(p.Value) Then
                        cmd.Parameters.AddWithValue("@" + p.Key, "%" + p.Value + "%")
                        searchStatement &= " and " & p.Key & " like @" + p.Key
                    End If
                Next

                cmd.CommandText = searchStatement & " order by 1 desc"
                cmd.Connection = con
                Dim dt As New DataTable
                sda.Fill(dt)
                grid.DataSource = dt
                grid.DataBind()

            End Using
        End Using
    End Sub





    'for update maybe
    'If lColumns.Any() Then
    '                cmd.CommandText = "select * from " & table & " where " & lColumns(0) & " = " & lParams(0)
    '                For i As Integer = 1 To lColumns.Skip(1).Count
    '                    cmd.CommandText &= " and " & lColumns(i) & " = " & lParams(i)
    '                Next
    'End If
End Class
