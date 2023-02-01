
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Partial Class PlayersData
    Inherits DBTools

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadGrid(gvPlayers, "tbl_player")
        End If
    End Sub

    Protected Sub gvPlayers_Sorting(sender As Object, e As GridViewSortEventArgs)
        LoadGrid(gvPlayers, "tbl_player", e.SortExpression)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Page.IsValid Then
            Dim params As New Dictionary(Of String, String)
            params.Add("col_firstname", txtFirstname.Text)
            params.Add("col_lastname", txtLastname.Text)
            params.Add("col_nickname", txtNickname.Text)
            params.Add("col_email", txtEmail.Text)
            params.Add("col_password", txtPassword.Text)
            InsertDataProc(params, "Sp_InsertPlayer")
            'InsertDataText(params, "tbl_player")
            ClearFields()
            LoadGrid(gvPlayers, "tbl_player")
        End If
    End Sub


    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtPlayerID.Text = ""
        txtFirstname.Text = ""
        txtLastname.Text = ""
        txtNickname.Text = ""
        txtEmail.Text = ""
        txtPassword.Text = ""
    End Sub

    Protected Sub gvPlayers_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        gvPlayers.PageIndex = e.NewPageIndex
        'LoadGrid(gvPlayers, "tbl_player") --to fix issue with searching when clicking indexpage
        SearchData()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchData()
    End Sub

    Public Sub SearchData()
        Dim params As New Dictionary(Of String, String)
        params.Add("col_playerid", txtPlayerID.Text)
        params.Add("col_firstname", txtFirstname.Text)
        params.Add("col_lastname", txtLastname.Text)
        params.Add("col_nickname", txtNickname.Text)
        params.Add("col_email", txtEmail.Text)
        params.Add("col_password", txtPassword.Text)
        SearchDataQuery(gvPlayers, params, "tbl_player")
    End Sub

    Protected Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadGrid(gvPlayers, "tbl_player")
    End Sub
End Class
