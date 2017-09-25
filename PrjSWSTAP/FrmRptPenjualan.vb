Imports System.IO

Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Export
Imports DevExpress.XtraPrinting

''
''.Oracle
'Imports Devart.Common

Imports Microsoft.VisualBasic
Imports System
Public Class FrmRptPenjualan
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Loadview()
    End Sub
    Private Sub Loadview()
        Dim tgl1 As String
        Dim tgl2 As String
        Dim TRANSAKSI As String
        Dim MATERIALTYPE As String

        DateEdit1.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
        DateEdit1.Properties.Mask.EditMask = "dd-MM-yyyy"
        DateEdit1.Properties.Mask.UseMaskAsDisplayFormat = True
        DateEdit1.Properties.CharacterCasing = CharacterCasing.Upper
        tgl1 = "DATE_IN('" & DateEdit1.Text & "','dd-MM-yyyy')"

        DateEdit2.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
        DateEdit2.Properties.Mask.EditMask = "dd-MM-yyyy"
        DateEdit2.Properties.Mask.UseMaskAsDisplayFormat = True
        DateEdit2.Properties.CharacterCasing = CharacterCasing.Upper
        tgl2 = "DATE_OUT('" & DateEdit2.Text & "','dd-MM-yyyy')"
        If DateEdit1.Text <> "" = True Or DateEdit2.Text <> "" = True Then
            '   SQL = "SELECT TO_CHAR(DATE_IN,'MM-YYYY')DATE_IN,DATE_OUT,MATERIAL, " +
            ' " FROM V_TICKECT_FINISH " +
            '" WHERE DATE_IN BETWEEN " & tgl1 & " AND " & tgl2 & "" +
            '" ORDER BY DATE_IN DESC"

            SQL = "SELECT * FROM V_TICKET_FINISH WHERE DATE_IN BETWEEN " & tgl1 & " AND " & tgl2 & "" +
           " ORDER BY INPUT_DATE DESC"

        Else
            SQL = "SELECT * FROM V_TICKET_FINISH ORDER BY DATE_IN"
            ' SQL = "SELECT TO_CHAR(DATE_IN,'MM-YYYY')DATE_IN,DATE_OUT,MATERIAL, " +
            '" FROM V_TICKECT_FINISH " +
            ' " ORDER BY DATE_IN DESC"
        End If
        FILLGridView(SQL, GridControl2)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'ex to xls
        Dim myStream As Stream
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*"
        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            myStream = saveFileDialog1.OpenFile()
            If (myStream IsNot Nothing) Then
                Dim nama As String = saveFileDialog1.FileName
                myStream.Close()
                GridView2.ExportToXls(nama)
                MsgBox("Export successfull!", MessageBoxIcon.Information, "Report Penjualan")
            End If
        End If
    End Sub
    Private Sub FrmRptPenjualan(sender As Object, e As EventArgs) Handles Me.Load
        DateEdit1.Text = ""
        DateEdit2.Text = ""
        ComboBoxEdit1.Text = ""
        ComboBoxEdit2.Text = ""
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Me.Close()
    End Sub
End Class