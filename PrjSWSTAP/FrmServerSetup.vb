Imports Oracle.ManagedDataAccess.Client
Public Class Frm
    Dim Conn1 As New OracleConnection
    Dim Conn2 As New OracleConnection
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'SAVE CONFIG
        MemoEdit1.Text = ""
        MemoEdit2.Text = ""
        If Not IsEmptyCombo({ComboBoxEdit1}) Then
            If Not IsEmptyText({TextEdit1, TextEdit2, TextEdit3, TextEdit4, TextEdit5}) Then
                If ComboBoxEdit1.Text = "LOKAL" Then
                    My.Settings.DBSourceLocal = TextEdit1.Text
                    My.Settings.Save()
                    My.Settings.DBVerLocal = TextEdit2.Text
                    My.Settings.Save()
                    My.Settings.DBNameLocal = TextEdit19.Text
                    My.Settings.Save()
                    My.Settings.DBPortLocal = TextEdit3.Text
                    My.Settings.Save()
                    My.Settings.DBUserLocal = TextEdit4.Text
                    My.Settings.Save()
                    My.Settings.DBPassLocal = TextEdit5.Text
                    My.Settings.Save()
                    CheckCon1Local()
                    If Conn1.State = ConnectionState.Open Then Conn1.Close()
                ElseIf ComboBoxEdit1.Text = "STAGING" Then
                    My.Settings.DBSourceStaging = TextEdit1.Text
                    My.Settings.Save()
                    My.Settings.DBVerStaging = TextEdit2.Text
                    My.Settings.Save()
                    My.Settings.DBNameStaging = TextEdit19.Text
                    My.Settings.Save()
                    My.Settings.DBPortStaging = TextEdit3.Text
                    My.Settings.Save()
                    My.Settings.DBUserStaging = TextEdit4.Text
                    My.Settings.Save()
                    My.Settings.DBPassStaging = TextEdit5.Text
                    My.Settings.Save()
                    CheckCon1Staging()
                    If Conn2.State = ConnectionState.Open Then Conn2.Close()
                End If
            End If
        End If

    End Sub
    Private Sub CheckCon1Local()
        CONFIG_SERVER()
        If ConnLocal() = True Then
            MemoEdit1.Text = "Connection Success"
        End If
    End Sub
    Private Sub CheckCon1Staging()
        CONFIG_SERVER()
        If ConnStaging() = True Then
            MemoEdit1.Text = "Connection Success"
        End If
    End Sub
    Private Function ConnLocal() As Boolean
        ConnLocal = False
        GetLocalDbConfig()
        MemoEdit2.Text = ConStringLocal
        Try
            If Conn1.State = ConnectionState.Closed Then
                Conn1 = New OracleConnection(ConStringLocal)
                Conn1.Open()
                ConnLocal = True
            Else
                ConnLocal = True
            End If
        Catch ex As Exception
            MemoEdit1.Text = ex.ToString
        End Try
    End Function
    Private Function ConnStaging() As Boolean
        ConnStaging = False
        GetStagingDbConfig()
        MemoEdit2.Text = ConStringStaging
        Try
            If Conn2.State = ConnectionState.Closed Then
                Conn2 = New OracleConnection(ConStringStaging)
                Conn2.Open()
                ConnStaging = True
            Else
                ConnStaging = True
            End If
        Catch ex As Exception
            MemoEdit1.Text = ex.ToString
        End Try
    End Function

    Private Sub CONFIG_SERVER()
        'local seting
        DBSourceLocal = My.Settings.DBSourceLocal.ToString
        DBPortLocal = My.Settings.DBPortLocal.ToString
        DBNameLocal = My.Settings.DBNameLocal.ToString
        DBVerLocal = My.Settings.DBVerLocal.ToString
        DBUserLocal = My.Settings.DBUserLocal.ToString
        DBPassLocal = My.Settings.DBPassLocal.ToString
        'staging
        DBSourceStaging = My.Settings.DBSourceStaging.ToString
        DBPortStaging = My.Settings.DBPortStaging.ToString
        DBNameStaging = My.Settings.DBNameStaging.ToString
        DBVerStaging = My.Settings.DBVerStaging.ToString
        DBUserStaging = My.Settings.DBUserStaging.ToString
        DBPassStaging = My.Settings.DBPassStaging.ToString
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Close()
    End Sub

    Private Sub ComboBoxEdit1_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit1.SelectedIndexChanged
        If ComboBoxEdit1.Text = "LOKAL" Then
            LocalConfig()
        ElseIf ComboBoxEdit1.Text = "STAGING" Then
            StagingConfig()
        End If
    End Sub
    Private Sub LocalConfig()
        TextEdit1.Text = My.Settings.DBSourceLocal.ToString  'ipadress
        TextEdit3.Text = My.Settings.DBPortLocal.ToString    'ipport

        TextEdit19.Text = My.Settings.DBNameLocal.ToString     'db name
        TextEdit2.Text = My.Settings.DBVerLocal.ToString     'version

        TextEdit4.Text = My.Settings.DBUserLocal.ToString    'user
        TextEdit5.Text = My.Settings.DBPassLocal.ToString    'pass
    End Sub
    Private Sub StagingConfig()
        TextEdit1.Text = My.Settings.DBSourceStaging.ToString  'ipadress
        TextEdit3.Text = My.Settings.DBPortStaging.ToString     'ipport

        TextEdit19.Text = My.Settings.DBNameStaging.ToString   'db name
        TextEdit2.Text = My.Settings.DBVerStaging.ToString   'version

        TextEdit4.Text = My.Settings.DBUserStaging.ToString    'user
        TextEdit5.Text = My.Settings.DBPassStaging.ToString    'pass
    End Sub

    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "SERVER KONFIGURASI"
    End Sub

End Class