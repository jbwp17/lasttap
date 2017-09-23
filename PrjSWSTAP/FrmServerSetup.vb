Public Class Frm
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'SAVE CONFIG
        'SAVE
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
                    CheckConLocal()
                    CloseConnLocal()
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
                    CheckConStaging()
                    CloseConnStaging()
                End If
            End If
        End If

    End Sub
    Private Sub CheckConLocal()
        CONFIG_SERVER()
        If OpenConnLocal() = True Then
            MsgBox("Connection Successful", vbInformation, "Conection")
        Else
            MsgBox("Connection Failed", vbInformation, "Conection")
        End If
    End Sub
    Private Sub CheckConStaging()
        CONFIG_SERVER()
        If OpenConnStaging() = True Then
            MsgBox("Connection Successful", vbInformation, "Conection")
        Else
            MsgBox("Connection Failed", vbInformation, "Conection")
        End If
    End Sub

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