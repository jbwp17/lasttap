﻿Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading.Tasks
Imports System.Text.RegularExpressions ' Namespace untuk manipulasi registry
Imports System.Text

Imports Oracle.ManagedDataAccess.Client 'Imports Devart.Data.Oracle

Imports DevExpress
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository

Imports System.ComponentModel

Public Class FrmConfigurationMenu
    Dim nAction As String = ""
    Dim IdTabel As String = ""
    Dim frs As String

    Dim source1 As String '//CAM1
    Dim source3 As String '//CAM1

    Public Sub New()
        InitializeComponent()
        BW1.WorkerReportsProgress = True
        BW1.WorkerSupportsCancellation = True
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'CLOSE
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'SAVE
        If Not IsEmptyCombo({ComboBoxEdit1}) Then
            If Not IsEmptyText({TextEdit1, TextEdit2, TextEdit3, TextEdit4, TextEdit5}) Then
                If ComboBoxEdit1.Text = "LOKAL" Then
                    My.Settings.DBSourceLocal = TextEdit1.Text
                    My.Settings.Save()
                    My.Settings.DBVerLocal = TextEdit2.Text
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

        TextEdit2.Text = My.Settings.DBVerLocal.ToString     'version

        TextEdit4.Text = My.Settings.DBUserLocal.ToString    'user
        TextEdit5.Text = My.Settings.DBPassLocal.ToString    'pass
    End Sub
    Private Sub StagingConfig()
        TextEdit1.Text = My.Settings.DBSourceStaging.ToString  'ipadress
        TextEdit3.Text = My.Settings.DBPortStaging.ToString     'ipport

        TextEdit2.Text = My.Settings.DBVerStaging.ToString   'version

        TextEdit4.Text = My.Settings.DBUserStaging.ToString    'user
        TextEdit5.Text = My.Settings.DBPassStaging.ToString    'pass
    End Sub
    Private Sub CheckConLocal()
        GetConfig()
        If OpenConnLocal() = True Then
            MsgBox("Connection Successful", vbInformation, "Conection")
        Else
            MsgBox("Connection Failed", vbInformation, "Conection")
        End If
    End Sub
    Private Sub CheckConStaging()
        GetConfig()
        If OpenConnStaging() = True Then
            MsgBox("Connection Successful", vbInformation, "Conection")
        Else
            MsgBox("Connection Failed", vbInformation, "Conection")
        End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        'Add Camera
        IdTabel = "CM"
        ClearInputCm()
        TextEdit11.Text = GetCode(IdTabel)
        nAction = "Save"
        IdTabel = "CM"
        SimpleButton5.Enabled = False 'ADD
        SimpleButton16.Enabled = False 'EDIT
        SimpleButton4.Enabled = True 'SAVE
        SimpleButton9.Enabled = True 'CANCEL
    End Sub
    Private Sub ClearInputCm()
        TextEdit11.Text = ""
        TextEdit10.Text = ""
        TextEdit8.Text = ""
        TextEdit9.Text = ""
        TextEdit7.Text = ""
        TextEdit13.Text = ""
        SimpleButton16.Enabled = False
        SimpleButton4.Enabled = False
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        'Save Camera
        If Not IsEmptyText({TextEdit11, TextEdit10, TextEdit8, TextEdit13}) Then
            SQL = "SELECT * FROM T_CCTV WHERE KDNAMA='" & TextEdit11.Text & "'"
            Dim KDNAMA As String = TextEdit11.Text
            Dim NAMACCTV As String = TextEdit10.Text
            Dim KONFIG As String = TextEdit8.Text
            Dim IPCCTV As String = TextEdit9.Text
            Dim PORT As String = TextEdit7.Text
            Dim LOKASICCTV As String = TextEdit13.Text

            If CheckRecord(SQL) = 0 Then
                SQL = "INSERT INTO T_CCTV (KDNAMA,NAMA,CONFIG,IPADDRESS,PORT,LOKASICCTV,UPDATEUSER,UPDATEDATE,AKTIF) " +
                      "VALUES ('" & KDNAMA & "','" & NAMACCTV & "','" & KONFIG & "','" & IPCCTV & "','" & PORT & "','" & LOKASICCTV & "','" & USERNAME & "','" & Now & "','Y') "
                ExecuteNonQuery(SQL)
                SQL = "SELECT * FROM T_CCTV WHERE KDNAMA='" & TextEdit11.Text & "'"
                If CheckRecord(SQL) > 0 Then UpdateCode("CM")
                LoadView()
                MsgBox("SAVE SUCCEEDED", vbInformation, "MASTER CCTV")
                UNLockAll_IpCamera()
                ClearInputCm()
            Else
                SQL = "UPDATE T_CCTV SET NAMA='" & NAMACCTV & "',CONFIG='" & KONFIG & "',IPADDRESS='" & IPCCTV & "',PORT='" & PORT & "',LOKASICCTV='" & LOKASICCTV & "',UPDATEUSER='" & USERNAME & "',UPDATEDATE='" & Now & "'  " +
                      " WHERE KDNAMA='" & TextEdit11.Text & "'"
                ExecuteNonQuery(SQL)
                LoadView()
                MsgBox("SAVE SUCCEEDED", vbInformation, "MASTER CCTV")
            End If
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        'Close Camera
        Me.Close()

    End Sub

    Private Sub FrmConfigurationMenu_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelControl4.Height = Me.Height - (273 + 42)
        PanelControl12.Height = Me.Height - (263 + 42)  'ip indicator
        PanelControl13.Height = Me.Height - 200 'ip indicator

    End Sub
    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        'Close
        Me.Close()
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        'SAVE GENERAL CONFIG
        If Not IsEmptyText({TextEdit41}) Then
            SaveConfig()  'save ke my setting
            GetConfig()
            saveGConfig() 'save ke Database
            SimpleButton13.Enabled = False
            MsgBox("Save Succeeded", vbInformation, "Configuration")
            LockAll_GConfig()
        End If
    End Sub
    Private Sub saveGConfig()

        CompanyCode = My.MySettings.Default.CompanyCode
        Company = My.MySettings.Default.Company
        Dim MILLPLANT As String = My.MySettings.Default.Millplant
        Dim LocationSite As String = My.MySettings.Default.LocationSite
        Dim STORELOC1 As String = My.MySettings.Default.StoreLocation1
        Dim STORELOC2 As String = My.MySettings.Default.StoreLocation2
        Dim WBSETTING As String = My.MySettings.Default.ComportSetting
        WBCode = My.MySettings.Default.WBCode
        Dim IP_DERIVER As String = My.MySettings.Default.IPCamera1
        Dim IP_VEHICLE As String = My.MySettings.Default.IPCamera2
        Dim IPINDICATOR As String = My.MySettings.Default.IPIndicator
        Dim LRT As String = My.MySettings.Default.LoadingRampTransit

        Dim ConnECTION_STG_NAME As String = My.MySettings.Default.DBNameStaging
        Dim ConnECTION_STG_USER As String = My.MySettings.Default.DBUserStaging
        Dim ConnECTION_STG_PASS As String = My.MySettings.Default.DBPassStaging
        Dim ConnECTION_STG_IP As String = My.MySettings.Default.DBSourceStaging
        Dim ConnECTION_STG_PORT As String = My.MySettings.Default.DBPortStaging
        Dim ConnECTION_STG_VER As String = My.MySettings.Default.DBVerStaging

        Dim ConnECTION_LOC_NAME As String = My.MySettings.Default.DBNameLocal
        Dim ConnECTION_LOC_USER As String = My.MySettings.Default.DBUserLocal
        Dim ConnECTION_LOC_PASS As String = My.MySettings.Default.DBPassLocal
        Dim ConnECTION_LOC_IP As String = My.MySettings.Default.DBSourceLocal
        Dim ConnECTION_LOC_PORT As String = My.MySettings.Default.DBPortLocal
        Dim ConnECTION_LOC_VER As String = My.MySettings.Default.DBVerLocal

        Dim FFBCODE As String = ""
        Dim PKCODE As String = ""
        Dim CPOCODE As String = ""
        Dim SHELLCODE As String = ""
        Dim MM As String = ""
        Dim KTU As String = ""
        SAP = My.MySettings.Default.SAP
        ValTare = My.MySettings.Default.ValidasiTara

        SQL = "SELECT * FROM T_CONFIG WHERE COMPANYCODE='" & TextEdit41.Text & "' "

        If CheckRecord(SQL) = 0 Then
            SQL = "INSERT INTO T_CONFIG " +
            "(CompanyCode,COMPANY,WBCODE,WBSETTING,MILLPLANT, " +
            "STORELOC1,STORELOC2,IP_DERIVER,IP_VEHICLE,FFBCODE,CPOCODE,PKCODE,SHELLCODE,MM,KTU,LRT,SAP, " +
            "ConnECTION_STG_NAME, ConnECTION_STG_USER, ConnECTION_STG_PASS, ConnECTION_STG_IP, ConnECTION_STG_PORT, ConnECTION_STG_VER, " +
            "ConnECTION_LOC_NAME,ConnECTION_LOC_USER,ConnECTION_LOC_PASS,ConnECTION_LOC_IP,ConnECTION_LOC_PORT,ConnECTION_LOC_VER) " +
            "VALUES " +
            "('" & CompanyCode & "','" & Company & "','" & WBCode & "','" & WBSETTING & "','" & MILLPLANT & "', " +
            "'" & STORELOC1 & "','" & STORELOC2 & "','" & IP_DERIVER & "','" & IP_VEHICLE & "','" & FFBCODE & "','" & CPOCODE & "','" & PKCODE & "','" & SHELLCODE & "','" & MM & "','" & KTU & "','" & LRT & "','" & SAP & "', " +
            "'" & ConnECTION_STG_NAME & "','" & ConnECTION_STG_USER & "','" & ConnECTION_STG_PASS & "','" & ConnECTION_STG_IP & "','" & ConnECTION_STG_PORT & "','" & ConnECTION_STG_VER & "', " +
            "'" & ConnECTION_LOC_NAME & "','" & ConnECTION_LOC_USER & "','" & ConnECTION_LOC_PASS & "','" & ConnECTION_LOC_IP & "','" & ConnECTION_LOC_PORT & "','" & ConnECTION_LOC_VER & "') "
        Else
            SQL = "Update T_CONFIG SET " +
                " CompanyCode='" & CompanyCode & "', " +
                " Company='" & Company & "'," +
                " WBCode='" & WBCode & "'," +
                " WBSETTING='" & WBSETTING & "', " +
                " MILLPLANT='" & MILLPLANT & "'," +
                " STORELOC1='" & STORELOC1 & "', " +
                " STORELOC2='" & STORELOC2 & "'," +
                " IP_DERIVER='" & IP_DERIVER & "', " +
                " IP_VEHICLE='" & IP_VEHICLE & "'," +
                " FFBCODE='" & FFBCODE & "', " +
                " CPOCODE='" & CPOCODE & "'," +
                " PKCODE='" & PKCODE & "', " +
                " SHELLCODE='" & SHELLCODE & "'," +
                " MM='" & MM & "', " +
                " KTU='" & KTU & "'," +
                " LRT='" & LRT & "', " +
                " SAP='" & SAP & "'," +
                " ConnECTION_STG_NAME='" & ConnECTION_STG_NAME & "', " +
                " ConnECTION_STG_USER='" & ConnECTION_STG_USER & "'," +
                " ConnECTION_STG_PASS='" & ConnECTION_STG_PASS & "', " +
                " ConnECTION_STG_IP='" & ConnECTION_STG_IP & "'," +
                " ConnECTION_STG_PORT='" & ConnECTION_STG_PORT & "', " +
                " ConnECTION_STG_VER='" & ConnECTION_STG_VER & "'," +
                " ConnECTION_LOC_NAME='" & ConnECTION_LOC_NAME & "', " +
                " ConnECTION_LOC_USER='" & ConnECTION_LOC_USER & "'," +
                " ConnECTION_LOC_PASS='" & ConnECTION_LOC_PASS & "', " +
                " ConnECTION_LOC_IP='" & ConnECTION_LOC_IP & "'," +
                " ConnECTION_LOC_PORT='" & ConnECTION_LOC_PORT & "', " +
                " ConnECTION_LOC_VER='" & ConnECTION_LOC_VER & "'" +
                " WHERE CompanyCode ='" & CompanyCode & "'"
        End If
        ExecuteNonQuery(SQL)
        GetConfig()
    End Sub


    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        'Close GENERAL CONFIG
        Close()
    End Sub
    Public Sub LoadConfig()
        TextEdit41.Text = My.MySettings.Default.CompanyCode.Trim.ToString
        TextEdit40.Text = My.MySettings.Default.Company  'My.Settings.Company
        TextEdit39.Text = My.MySettings.Default.Millplant
        TextEdit38.Text = My.MySettings.Default.LocationSite
        TextEdit37.Text = My.MySettings.Default.StoreLocation1
        TextEdit36.Text = My.MySettings.Default.StoreLocation2
        TextEdit35.Text = My.MySettings.Default.ComportSetting
        TextEdit16.Text = My.MySettings.Default.WBCode

        TextEdit24.Text = My.MySettings.Default.IPCamera1
        TextEdit26.Text = My.MySettings.Default.IPCamera2
        TextEdit31.Text = My.MySettings.Default.IPIndicator
        ComboBoxEdit3.Text = My.MySettings.Default.LoadingRampTransit
        ComboBoxEdit4.Text = My.MySettings.Default.SAP
    End Sub
    Private Sub LoadNew()
        Dim DT As New DataTable
        SQL = "SELECT * FROM T_CONFIG WHERE COMPANYCODE='" & TextEdit41.Text & "'"
        DT = ExecuteQuery(SQL)
        If DT.Rows.Count > 0 Then

            TextEdit41.Text = DT.Rows(0).Item("COMPANYCODE").ToString 'My.MySettings.Default.CompanyCode.Trim.ToString
            TextEdit40.Text = DT.Rows(0).Item("COMPANY").ToString ' My.MySettings.Default.Company  'My.Settings.Company
            TextEdit39.Text = DT.Rows(0).Item("MILLPLANT").ToString 'My.MySettings.Default.Millplant
            TextEdit38.Text = DT.Rows(0).Item("COMPANY").ToString 'My.MySettings.Default.LocationSite
            TextEdit37.Text = DT.Rows(0).Item("STORELOC1").ToString 'My.MySettings.Default.StoreLocation1
            TextEdit36.Text = DT.Rows(0).Item("STORELOC2").ToString ' My.MySettings.Default.StoreLocation2
            TextEdit16.Text = DT.Rows(0).Item("WBCODE").ToString 'My.MySettings.Default.WBCode

            TextEdit24.Text = DT.Rows(0).Item("IP_DERIVER").ToString ' My.MySettings.Default.IPCamera1
            TextEdit26.Text = DT.Rows(0).Item("IP_VEHICLE").ToString ' My.MySettings.Default.IPCamera2

            ComboBoxEdit3.Text = DT.Rows(0).Item("LRT").ToString 'My.MySettings.Default.LoadingRampTransit
            ComboBoxEdit4.Text = DT.Rows(0).Item("SAP").ToString 'My.MySettings.Default.SAP
        End If
    End Sub


    Public Sub SaveConfig()
        My.Settings.CompanyCode = TextEdit41.Text
        My.Settings.Save()
        My.Settings.Company = TextEdit40.Text
        My.Settings.Save()
        My.Settings.Millplant = TextEdit39.Text
        My.Settings.Save()
        My.Settings.LocationSite = TextEdit38.Text
        My.Settings.Save()
        My.Settings.StoreLocation1 = TextEdit37.Text
        My.Settings.Save()
        My.Settings.StoreLocation2 = TextEdit36.Text
        My.Settings.Save()
        My.Settings.ComportSetting = TextEdit35.Text
        My.Settings.Save()
        My.Settings.WBCode = TextEdit16.Text
        My.Settings.Save()
        My.Settings.IPCamera1 = TextEdit24.Text
        My.Settings.Save()
        My.Settings.IPCamera2 = TextEdit26.Text
        My.Settings.Save()
        My.Settings.IPIndicator = TextEdit31.Text
        My.Settings.Save()
        My.Settings.LoadingRampTransit = ComboBoxEdit3.Text
        My.Settings.Save()
        My.Settings.SAP = ComboBoxEdit4.Text
        My.Settings.Save()
        My.Settings.ValidasiTara = ComboBoxEdit6.Text
        My.Settings.Save()

    End Sub

    Private Sub BackstageViewTabItem1_SELECTedChanged(sender As Object, e As DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs) Handles BackstageViewTabItem1.SelectedChanged
        LoadConfig()
    End Sub

    Private Sub FrmConfigurationMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "CONFIGURATION MENU"
        BackstageViewTabItem1.Selected = True
        If TextEdit41.Text <> "" Then LockAll_GConfig()
        GridHeader()
        LoadView() 'DATA INDIKATOR & CCTV
    End Sub
    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        'EDIT GENERAL CONFIG
        If TextEdit41.Text = "" Then SimpleButton11.Text = "Update"
        UnLockAll_GConfig()
    End Sub

    Private Sub UnLockAll_GConfig()
        TextEdit41.Enabled = True
        TextEdit40.Enabled = True
        TextEdit39.Enabled = True
        TextEdit38.Enabled = True
        TextEdit37.Enabled = True
        TextEdit36.Enabled = True
        TextEdit35.Enabled = True
        TextEdit16.Enabled = True
        TextEdit24.Enabled = True
        TextEdit26.Enabled = True
        TextEdit31.Enabled = True
        ComboBoxEdit3.Enabled = True
        ComboBoxEdit4.Enabled = True

        SimpleButton13.Enabled = True 'SAVE
        SimpleButton15.Enabled = False 'EDIT

        SimpleButton20.Enabled = True
        SimpleButton21.Enabled = True
        SimpleButton22.Enabled = True
    End Sub

    Private Sub LockAll_GConfig()
        TextEdit41.Enabled = False
        TextEdit40.Enabled = False
        TextEdit39.Enabled = False
        TextEdit38.Enabled = False
        TextEdit37.Enabled = False
        TextEdit36.Enabled = False
        TextEdit35.Enabled = False
        TextEdit16.Enabled = False
        TextEdit24.Enabled = False
        TextEdit26.Enabled = True
        TextEdit31.Enabled = False
        ComboBoxEdit3.Enabled = False
        ComboBoxEdit4.Enabled = False
        SimpleButton13.Enabled = False 'SAVE
        SimpleButton15.Enabled = True 'EDIT

        SimpleButton20.Enabled = False
        SimpleButton21.Enabled = False
        SimpleButton22.Enabled = False
    End Sub


#Region "Indicator"
    Private Sub AppendOutput(message As String) ''cetak hasil baca data
        If TxtIndikator.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf AppendOutput)
            Invoke(x, New Object() {(Text)})
        Else
            TxtIndikator.Text = CType(Num(message), String)
            If GETwEIGHT = True Then
                WEIGHT = TxtIndikator.Text
            End If
        End If
    End Sub
    Private Sub DoAcceptClient(result As IAsyncResult)
        Dim monitorInfo As MonitorInfo = CType(_ConnectionMontior.AsyncState, MonitorInfo)
        If monitorInfo.Listener IsNot Nothing AndAlso Not monitorInfo.Cancel Then
            Dim info As ConnectionInfo = CType(result.AsyncState, ConnectionInfo)
            monitorInfo.Connections.Add(info)
            info.AcceptClient(result)
            ListenForClient(monitorInfo)
            info.AwaitData()
            Dim doUpdateConnectionCountLabel As New Action(AddressOf UpdateConnectionCountLabel)
            Invoke(doUpdateConnectionCountLabel)
        End If
    End Sub
    Private Sub DoMonitorConnections()
        Dim doAppendOutput As New Action(Of String)(AddressOf AppendOutput)
        Dim doUpdateConnectionCountLabel As New Action(AddressOf UpdateConnectionCountLabel)
        Dim monitorInfo As MonitorInfo = CType(_ConnectionMontior.AsyncState, MonitorInfo)
        Do
            Dim lostCount As Integer = 0
            For index As Integer = monitorInfo.Connections.Count - 1 To 0 Step -1
                Dim info As ConnectionInfo = monitorInfo.Connections(index)
                If info.Client.Connected Then
                    If info.DataQueue.Count > 0 Then
                        Dim messageBytes As New List(Of Byte)
                        While info.DataQueue.Count > 0
                            Dim value As Byte
                            If info.DataQueue.TryDequeue(value) Then
                                messageBytes.Add(value)
                            End If
                        End While
                        Invoke(doAppendOutput, System.Text.Encoding.ASCII.GetString(messageBytes.ToArray))
                    End If
                Else
                    monitorInfo.Connections.Remove(info)
                    lostCount += 1
                End If
            Next
            If lostCount > 0 Then
                Invoke(doUpdateConnectionCountLabel)
            End If
            _ConnectionMontior.Wait(1)
        Loop While Not monitorInfo.Cancel
        For Each info As ConnectionInfo In monitorInfo.Connections
            info.Client.Close()
        Next
        monitorInfo.Connections.Clear()
        Invoke(doUpdateConnectionCountLabel)
    End Sub
    Private Sub ListenForClient(monitor As MonitorInfo)
        Dim info As New ConnectionInfo(monitor)
        _Listener.BeginAcceptTcpClient(AddressOf DoAcceptClient, info)
    End Sub

    Private Sub GridHeader()
        'WB
        'KDNAMA,NAMA,BREND,IPADDRESS,PORT,UNIT,LOKASI,RL,LEN
        Dim View As ColumnView = CType(GridControl2.MainView, ColumnView)
        Dim FieldNames() As String = New String() {"KODE", "NAMA", "BREND", "IPADDRESS", "PORT", "UNIT", "LOKASI", "RL", "LEN"}
        Dim I As Integer
        Dim Column As DevExpress.XtraGrid.Columns.GridColumn

        View.Columns.Clear()
        For I = 0 To FieldNames.Length - 1
            Column = View.Columns.AddField(FieldNames(I))
            Column.VisibleIndex = I
        Next
    End Sub
    Private Sub ToggleSwitch2_Toggled(sender As Object, e As EventArgs) Handles ToggleSwitch2.Toggled
        'INDIKATOR SWITCH
        nPortIndicator = Val(TextEdit20.Text)
        If nPortIndicator = 0 Then
            MsgBox("THE IP Indicator port Is Not loaded yet")
            ToggleSwitch2.IsOn = False
            Exit Sub
        Else
            TxtWeight.Text = 0
            If ToggleSwitch2.IsOn = True Then
                LockAll_IPIndicator()
                ResultLabel.Text = "Start"
                GetWBConfig()
                INDICATORON()
            ElseIf ToggleSwitch2.IsOn = False Then
                UnLockAll_IPIndicator()
                ResultLabel.Text = "Stop"
                GetWBConfig()
                INDICATOROFF()
            End If
        End If
    End Sub
    Private Sub INDICATORON()
        WB_ON = True
        If BW1.IsBusy <> True Then
            BW1.RunWorkerAsync()
            ResultLabel.Text = "Connected..."
        End If
    End Sub
    Private Sub INDICATOROFF()
        WB_ON = False
        If BW1.WorkerSupportsCancellation = True Then
            BW1.CancelAsync()
        End If
    End Sub

    Private Sub LockAll_IPIndicator()
        TextEdit18.Enabled = False
        ComboBoxEdit5.Enabled = False
        TextEdit23.Enabled = False
        TextEdit22.Enabled = False
        TextEdit21.Enabled = False
        TextEdit20.Enabled = False
        TextEdit17.Enabled = False
        ComboBoxEdit14.Enabled = False
        TextEdit14.Enabled = False
    End Sub
    Private Sub UnLockAll_IPIndicator()
        TextEdit18.Enabled = True
        ComboBoxEdit5.Enabled = True
        TextEdit23.Enabled = True
        TextEdit22.Enabled = True
        TextEdit21.Enabled = True
        TextEdit20.Enabled = True
        TextEdit17.Enabled = True
        ComboBoxEdit14.Enabled = True
        TextEdit14.Enabled = True
    End Sub
    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        'save IP INdicator

        If Not IsEmptyCombo({ComboBoxEdit5}) Then
            Dim RL As String = If(ComboBoxEdit14.SelectedIndex = 0, "R", "L")
            Dim LEN As Integer = If(TextEdit14.Text = "", 0, TextEdit14.Text)
            If Not IsEmptyText({TextEdit18, TextEdit23, TextEdit22, TextEdit21, TextEdit20, TextEdit17}) Then
                'check data
                SQL = "SELECT * FROM T_wb WHERE kdnama='" & TextEdit18.Text & "'"
                If CheckRecord(SQL) = 0 Then
                    'ADD IP INDICATOR /WB
                    SQL = "INSERT INTO T_WB (KDNAMA,NAMA,BREND,IPADDRESS,PORT,UNIT,LOKASI,UPDATEDATE,AKTIF,UPDATEUSER,RL,LEN)" +
                          " VALUES ('" & TextEdit18.Text & "','" & TextEdit23.Text & "','" & TextEdit21.Text & "','" & TextEdit22.Text & "','" & TextEdit20.Text & "','" & ComboBoxEdit5.Text & "','" & TextEdit17.Text & "',SYSDATE,'Y','" & USERNAME & "','" & RL & "','" & LEN & "')"
                    ExecuteNonQuery(SQL)
                    SQL = "SELECT * FROM T_WB WHERE kdnama='" & TextEdit18.Text & "'"
                    If CheckRecord(SQL) > 0 Then UpdateCode("WB")
                    LoadView()
                    MsgBox("SAVE SUCCEEDED", vbInformation, "MASTER INDICATOR")
                    UnLockAll_IPIndicator()
                    ClearInputWB()
                Else
                    'UPDATE IP INDICATOR /WB
                    SQL = "UPDATE T_WB SET NAMA='" & TextEdit23.Text & "',BREND='" & TextEdit21.Text & "',IPADDRESS='" & TextEdit22.Text & "',PORT='" & TextEdit20.Text & "',UNIT='" & ComboBoxEdit5.Text & "',LOKASI='" & TextEdit17.Text & "',UPDATEDATE=SYSDATE,UPDATEUSER='" & USERNAME & "'" +
                        " ,RL='" & RL & "',LEN='" & LEN & "'" +
                        " WHERE KDNAMA='" & TextEdit18.Text & "'"
                    ExecuteNonQuery(SQL)
                    LoadView()
                    MsgBox("UPDATE SUCCEEDED", vbInformation, "MASTER INDICATOR")
                    LockAll_IPIndicator()
                    SimpleButton8.Enabled = False
                End If
            End If
        End If
    End Sub
    Private Sub LoadView()
        If OpenConnLocal() = True Then
            'WB
            SQL = "SELECT KDNAMA AS KODE,NAMA ,BREND,IPADDRESS,PORT,UNIT,LOKASI,RL,LEN FROM T_WB ORDER BY KDNAMA"
            GridControl2.DataSource = Nothing
            FILLGridView(SQL, GridControl2)
            'CCTV
            SQL = "SELECT KDNAMA AS CCTVID,NAMA AS CCTV,CONFIG,IPADDRESS,PORT,USERN,PASSN,LOKASICCTV FROM T_CCTV ORDER BY KDNAMA"
            GridControl1.DataSource = Nothing
            FILLGridView(SQL, GridControl1)
            'LOG
            SQL = "SELECT * FROM TLOGINHISTORY"
            GridControl3.DataSource = Nothing
            FILLGridView(SQL, GridControl3)
        End If
    End Sub
    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        'Add IP Indicator
        IdTabel = "WB"
        ClearInputWB()
        TextEdit18.Text = GetCode(IdTabel)
        nAction = "Save"
        IdTabel = "WB"
        SimpleButton8.Enabled = True
    End Sub
    Private Sub ClearInputWB()
        TextEdit23.Text = ""
        TextEdit22.Text = ""
        TextEdit21.Text = ""
        TextEdit20.Text = ""
        TextEdit17.Text = ""
        ComboBoxEdit5.Text = ""
        SimpleButton14.Enabled = False
        SimpleButton8.Enabled = False
    End Sub
    Private Sub SaveData()
        'SAVE 
        ' nAction = UCase(SimpleButton3.Text)
        If nAction = "SAVE" Then
            If IdTabel = "WB" Then
                SQL = "insert into m_name (KDNAMA,NAMA,DESCRIPTION,NOTE,IDTABEL,AKTIF) "
                SQL = SQL & "values ('" & TextEdit18.Text & "','" & TextEdit23.Text & "','" & TextEdit22.Text & "','" & TextEdit3.Text & "','" & IdTabel & "','Y')"
            End If
            ExecuteNonQuery(SQL)
            UpdateCode(IdTabel)
            MsgBox("Data Save Succesfuly", vbInformation, "New Master Data")
        ElseIf nAction = "EDIT" Then
            If IdTabel = "WB" Then
                SQL = "Update m_name set NAMA='" & TextEdit4.Text & "',DESCRIPTION='" & TextEdit1.Text & "',NOTE='" & TextEdit3.Text & "' "
                SQL = SQL & " WHERE idtabel='" & IdTabel & "' AND KDNAMA='" & TextEdit2.Text & "' AND AKTIF='Y'"
            End If
            ExecuteNonQuery(SQL)
            MsgBox("Edit Save Succesfuly", vbInformation, "Edit Master Data")
        End If
        nAction = ""
    End Sub
    Private Sub SimpleButton16_Click(sender As Object, e As EventArgs) Handles SimpleButton16.Click
        'edit CCTV
        UNLockAll_IpCamera()
        TextEdit11.Enabled = False
        SimpleButton4.Enabled = True 'SAVE/UPDATE
    End Sub
    Private Sub LockAll_IpCamera()
        TextEdit11.Enabled = False
        TextEdit10.Enabled = False
        TextEdit8.Enabled = False
        TextEdit9.Enabled = False
        TextEdit7.Enabled = False
        TextEdit13.Enabled = False

    End Sub
    Private Sub UNLockAll_IpCamera()
        TextEdit11.Enabled = True
        TextEdit10.Enabled = True
        TextEdit8.Enabled = True
        TextEdit9.Enabled = True
        TextEdit7.Enabled = True
        TextEdit13.Enabled = True

    End Sub
    Private Sub gridView2_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView2.RowCellClick
        'GRID INDIKATOR
        On Error Resume Next
        If e.RowHandle < 0 Then
            SimpleButton6.Enabled = True 'ADD
            SimpleButton8.Enabled = False 'SAVE
            SimpleButton8.Text = "Save" 'SAVE
            SimpleButton14.Enabled = False 'EDIT
            ClearInputWB()
            ToggleSwitch2.IsOn = False
            Exit Sub
        Else
            SimpleButton6.Enabled = False 'ADD
            SimpleButton8.Enabled = False 'SAVE
            SimpleButton8.Text = "Update" 'SAVE
            SimpleButton14.Enabled = True 'EDIT
            ToggleSwitch2.IsOn = False
            TextEdit18.Text = GridView2.GetRowCellValue(e.RowHandle, "KODE").ToString()  'ID
            TextEdit23.Text = GridView2.GetRowCellValue(e.RowHandle, "NAMA").ToString() 'NAME
            TextEdit21.Text = GridView2.GetRowCellValue(e.RowHandle, "BREND").ToString()   'BRAND
            TextEdit22.Text = GridView2.GetRowCellValue(e.RowHandle, "IPADDRESS").ToString()   'IP
            TextEdit20.Text = GridView2.GetRowCellValue(e.RowHandle, "PORT").ToString() 'PORT
            ComboBoxEdit5.Text = GridView2.GetRowCellValue(e.RowHandle, "UNIT").ToString()   'UNIT
            TextEdit17.Text = GridView2.GetRowCellValue(e.RowHandle, "LOKASI").ToString() 'LOCATION
            ComboBoxEdit14.Text = If(GridView2.GetRowCellValue(e.RowHandle, "RL").ToString() = "R", "RIGHT", "LEFT") 'LEN
            TextEdit14.Text = GridView2.GetRowCellValue(e.RowHandle, "LEN").ToString() 'LEN

            nAction = "EDIT"
            UnLockAll_IPIndicator()
            TextEdit18.Enabled = False
            SimpleButton8.Enabled = True
            SimpleButton8.Text = "Update"
        End If
    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        'DELETE
        UnLockAll_IPIndicator()
        TextEdit18.Enabled = False
        SimpleButton8.Enabled = True 'SAVE/UPDATE
    End Sub
    Private Sub SimpleButton18_Click(sender As Object, e As EventArgs) Handles SimpleButton18.Click
        'CANCEL IP INDICATOR 
        UnLockAll_IPIndicator()
        ClearInputWB()
        TextEdit18.Text = ""
        SimpleButton6.Enabled = True 'ADD
        SimpleButton8.Enabled = False 'SAVE
        SimpleButton8.Text = "Save" 'SAVE
        SimpleButton14.Enabled = False 'EDIT
    End Sub
    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        'cancel camera
        UNLockAll_IpCamera()
        ClearInputCm()
        TextEdit11.Text = ""
        SimpleButton5.Enabled = True 'ADD
        SimpleButton4.Enabled = False 'SAVE
        SimpleButton4.Text = "Save" 'SAVE
        SimpleButton16.Enabled = False 'EDIT
    End Sub
    Private Sub TextEdit8_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit8.EditValueChanged
        If TextEdit8.Text = "" Then
            SimpleButton23.Enabled = False
        Else
            SimpleButton23.Enabled = True
        End If
    End Sub
    Private Sub gridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowCellClick
        'GRIDCCTV 
        On Error Resume Next
        If e.RowHandle < 0 Then
            SimpleButton5.Enabled = True 'ADD
            SimpleButton4.Enabled = False 'SAVE
            SimpleButton4.Text = "Save" 'SAVE
            SimpleButton16.Enabled = False 'EDIT
            ClearInputCm()
            SimpleButton23.Enabled = False
            Exit Sub
        Else
            SimpleButton5.Enabled = False 'ADD
            SimpleButton4.Enabled = False 'SAVE
            SimpleButton4.Text = "Update" 'SAVE
            SimpleButton16.Enabled = True 'EDIT
            SimpleButton23.Enabled = False

            TextEdit11.Text = GridView1.GetRowCellValue(e.RowHandle, "CCTVID").ToString()  'ID
            TextEdit10.Text = GridView1.GetRowCellValue(e.RowHandle, "CCTV").ToString() 'NAME
            TextEdit8.Text = GridView1.GetRowCellValue(e.RowHandle, "CONFIG").ToString()   'BRAND
            TextEdit9.Text = GridView1.GetRowCellValue(e.RowHandle, "IPADDRESS").ToString()   'IP
            TextEdit7.Text = GridView1.GetRowCellValue(e.RowHandle, "PORT").ToString() 'PORT
            TextEdit13.Text = GridView1.GetRowCellValue(e.RowHandle, "LOKASICCTV").ToString() 'LOCATION
            nAction = "EDIT"
            LockAll_IpCamera()
        End If
    End Sub
    Private Sub SimpleButton7_Click_1(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Me.Close()
    End Sub
    Private Sub FrmConfigurationMenu_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If ToggleSwitch2.IsOn = True Then ToggleSwitch2.IsOn = False 'WB
    End Sub

    Private Sub SimpleButton19_Click(sender As Object, e As EventArgs) Handles SimpleButton19.Click
        'SETTING SITE
        LSQL = "SELECT COMPANYCODE,TRIM(COMPANY)COMPANY,WBCODE,SAP  FROM T_CONFIG "
        LField = "COMPANYCODE"
        ValueLoV = ""
        TextEdit41.Text = FrmShowLOV(FrmLoV, LSQL, "COMPANYCODE", "COMPANYCODE")
        LoadNew()
    End Sub

    Private Sub SimpleButton20_Click(sender As Object, e As EventArgs) Handles SimpleButton20.Click
        'WB
        LSQL = "Select NAMA WB_CODE ,IPADDRESS,PORT,LOKASI,AKTIF FROM T_WB"
        LField = "WB_CODE"
        ValueLoV = ""
        TextEdit16.Text = FrmShowLOV(FrmLoV, LSQL, "WB_CODE", "WB_CODE")
    End Sub

    Private Sub SimpleButton21_Click(sender As Object, e As EventArgs) Handles SimpleButton21.Click
        'CAM1
        LSQL = "SELECT NAMA,CONFIG,IPADDRESS,PORT,AKTIF FROM T_CCTV"
        LField = "NAMA"
        ValueLoV = ""
        TextEdit24.Text = FrmShowLOV(FrmLoV, LSQL, "NAMA", "NAMA")
    End Sub
    Private Sub SimpleButton22_Click(sender As Object, e As EventArgs) Handles SimpleButton22.Click
        'CAM2
        LSQL = "SELECT NAMA,CONFIG,IPADDRESS,PORT,AKTIF FROM T_CCTV"
        LField = "NAMA"
        ValueLoV = ""
        TextEdit26.Text = FrmShowLOV(FrmLoV, LSQL, "WB_CODE", "NAMA")
    End Sub
    Private Sub BW1_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BW1.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim Ip As String = Trim(TextEdit22.Text)
        Dim Port As Int32 = CInt(TextEdit20.Text)
        Try
            Do Until Not WB_ON = True
                If (worker.CancellationPending = True) Then
                    e.Cancel = True
                    Exit Do
                Else
                    Dim responseData As [String] = [String].Empty
                    responseData = GetSCSMessage(Ip, Port)
                    worker.ReportProgress(Trim(responseData))
                End If
            Loop
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BW1_ProgressChanged(ByVal sender As System.Object, ByVal e As ProgressChangedEventArgs) Handles BW1.ProgressChanged
        If WBRL = "L" Then
            TxtWeight.Text = Microsoft.VisualBasic.Left((e.ProgressPercentage.ToString()), WBLEN)
        ElseIf WBRL = "R" Then
            TxtWeight.Text = Microsoft.VisualBasic.Right((e.ProgressPercentage.ToString()), WBLEN)
        Else
            TxtWeight.Text = Microsoft.VisualBasic.Right((e.ProgressPercentage.ToString()), 7)
        End If
    End Sub
    Private Sub BW1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs) Handles BW1.RunWorkerCompleted
        If e.Cancelled = True Then
            ResultLabel.Text = "Canceled!"
        ElseIf e.Error IsNot Nothing Then
            ResultLabel.Text = "Error: " & e.Error.Message
        Else
            ResultLabel.Text = "Done!"
            INDICATORON()
        End If
    End Sub


    Private Sub TextEdit16_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit16.EditValueChanged
        Dim DTS As New DataTable
        SQL = "SELECT KDNAMA,NAMA,BREND,IPADDRESS,PORT FROM T_WB WHERE AKTIF='Y' AND NAMA='" & TextEdit16.Text & "'"
        DTS = ExecuteQuery(SQL)
        If DTS.Rows.Count > 0 Then
            TextEdit31.Text = DTS.Rows(0).Item("IPADDRESS").ToString
            TextEdit35.Text = DTS.Rows(0).Item("PORT").ToString
        Else
            TextEdit31.Text = ""
            TextEdit35.Text = ""
        End If
    End Sub

    Private Sub BWC1_DoWork(sender As Object, e As DoWorkEventArgs)
        Try
            Do Until Not CAMCON1 = True

            Loop
        Catch ex As Exception
        End Try
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    Private Sub SimpleButton24_Click(sender As Object, e As EventArgs) Handles SimpleButton24.Click
        SQL = "update TLOGINHISTORY set used='N'  WHERE USED='Y' and userid='" & TextEdit29.Text & "' and ipaddress='" & TextEdit32.Text & "' "
        ExecuteNonQuery(SQL)
        MsgBox("SUCCES")
        LoadView()
    End Sub

    Private Sub gridView4_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView4.RowCellClick
        If e.RowHandle < 0 Then
            Exit Sub
        Else
            TextEdit27.Text = GridView4.GetRowCellValue(e.RowHandle, "LOGINDATE").ToString()  'ID
            TextEdit29.Text = GridView4.GetRowCellValue(e.RowHandle, "USERID").ToString() 'NAME
            TextEdit32.Text = GridView4.GetRowCellValue(e.RowHandle, "IPADDRESS").ToString()   'BRAND
            TextEdit33.Text = GridView4.GetRowCellValue(e.RowHandle, "USED").ToString()   'IP
        End If
    End Sub

    Private Sub SimpleButton26_Click(sender As Object, e As EventArgs) Handles SimpleButton26.Click
        Close()
    End Sub

    Private Sub SimpleButton23_Click(sender As Object, e As EventArgs) Handles SimpleButton23.Click
        'get image
        Try
            Dim buffer As Byte() = New Byte(99999) {}
            Dim read As Integer, total As Integer = 0
            Dim req As HttpWebRequest = DirectCast(WebRequest.Create(TextEdit8.Text), HttpWebRequest)
            req.Method = "POST"
            req.Timeout = 10000
            'Dim cred As New NetworkCredential("USER", "PASSWORD")
            'req.Credentials = cred
            Dim resp As WebResponse = req.GetResponse()
            Dim stream As Stream = resp.GetResponseStream()
            While (InlineAssignHelper(read, stream.Read(buffer, total, 1000))) <> 0
                total += read
            End While
            Dim bmp As Bitmap = DirectCast(Bitmap.FromStream(New MemoryStream(buffer, 0, total)), Bitmap)
            PictureBox1.Image = bmp
        Catch EX As Exception
            PictureBox1.BackgroundImage = My.Resources.cctv
        End Try
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub BackstageViewControl1_Click(sender As Object, e As EventArgs) Handles BackstageViewControl1.Click

    End Sub


#End Region
End Class

