Imports System.IO

Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Export
Imports DevExpress.XtraPrinting
Imports Microsoft.VisualBasic
Imports System

Public Class FrmRptPenerimaan
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Loadview()
    End Sub
    Private Sub Loadview()

        If DateEdit1.Text <> "" = True Or DateEdit2.Text <> "" = True Then
            SQL = "Select no_ticket,wbcode,do_spb,weight_in, " +
                " weight_out,netto,adjust_weight, " +
                " adjust_netto,del_qty, " +
                " driver_name,ffa,moisture,dirt," +
                " no_segel,sim,no_noki,delivery_type, " +
                " tahun_tanam,estate,BLOCK,ffb_units,date_in,date_out, " +
                " export,employe,afdeling,police_no,customer_name,remarks,supplier_name,transporter_name, " +
                " material_code,material,contract_no1,contract_no2,janjang, ref_ticketno,verified " +
                " FROM v_ticket_finish" +
                " WHERE to_char(DATE_IN) BETWEEN  '" & DateEdit1.Text & "' And '" & DateEdit2.Text & "'" +
                " And customer_name = '' " +
                " And material_code Like '%" & ComboBoxEdit2.Text & "%' "
        Else
            SQL = "Select no_ticket,wbcode,do_spb,weight_in, " +
                " weight_out,netto,adjust_weight, " +
                " adjust_netto,del_qty, " +
                " driver_name,ffa,moisture,dirt," +
                " no_segel,sim,no_noki,delivery_type, " +
                " tahun_tanam,estate,BLOCK,ffb_units,date_in,date_out, " +
                " export,employe,afdeling,police_no,customer_name,remarks,supplier_name,transporter_name, " +
                " material_code,material,contract_no1,contract_no2,janjang, ref_ticketno,verified " +
                " FROM v_ticket_finish " +
                " WHERE customer_name = '' "
        End If
        GridControl1.DataSource = Nothing
        FILLGridView(SQL, GridControl1)

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
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
                GridView1.ExportToXls(nama)
                MsgBox("EXSPORT SUCCESS", MessageBoxIcon.Information, "REPORT PENERIMAAN")
            End If
        End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Me.Close()
    End Sub

    Private Sub FrmRptPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "REPORT PENERIMAAN"
        Dim Date1 As Date = Now
        Dim Date2 As Date = Now
        DateEdit1.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
        DateEdit1.Properties.Mask.EditMask = "dd-MM-yyyy"
        DateEdit1.Properties.Mask.UseMaskAsDisplayFormat = True
        DateEdit1.Properties.CharacterCasing = CharacterCasing.Upper

        DateEdit2.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
        DateEdit2.Properties.Mask.EditMask = "dd-MM-yyyy"
        DateEdit2.Properties.Mask.UseMaskAsDisplayFormat = True
        DateEdit2.Properties.CharacterCasing = CharacterCasing.Upper

        Loadview() 'load data
    End Sub

    Private Sub FrmRptPenerimaan_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        GridControl1.Height = Me.Height - 120
    End Sub
End Class