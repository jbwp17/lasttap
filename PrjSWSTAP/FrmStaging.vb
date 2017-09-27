Imports System.IO

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Public Class FrmStaging
    Private Sub FrmStaging_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "IMPORT & EXSPORT STAGING"

        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton6.Checked = False
        RadioButton7.Checked = False
    End Sub
    Private Sub viewLocalCustomer()
        '///CUSTOMER LOCAL
        Dim SSQL As String
        SSQL = " select CUST_CODE AS CUSTOMERID,CUST_NAME AS CUSTOMERNAME,ADDRESS_CUST AS STREET,STATE_CUST AS CITY,ACCOUNTGROUP,ACCOUNTGROUPNAME,STATUS, CASE WHEN  INACTIVE IS NOT NULL THEN 'X' ELSE '' END DELETED " +
            " FROM T_CUSTOMER " +
            " WHERE NVL(STATUS,' ')!='X' ORDER BY CUST_CODE "
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        FILLGridView(SSQL, GridControl1)
        LabelControl5.Text = "LOCAL DATA CUSTOMER " & GridView1.RowCount.ToString
    End Sub
    Private Sub viewSagingCustomer()
        '///customer staging
        Dim COMPANYCODE As String = My.Settings.CompanyCode
        Dim SSQL As String
        SSQL = "select COMPANYCODE,CUSTOMERID,CUSTOMERNAME,STREET,CITY,ACCOUNTGROUP,ACCOUNTGROUPNAME,STATUS, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
                " from wb_customer " +
                " where nvl(STATUS,' ')!= 'X' " +
                " And companycode = '" & COMPANYCODE & "' ORDER BY COMPANYCODE"
        GridView2.Columns.Clear()
        GridControl2.DataSource = Nothing
        FILLGridViewstg(SSQL, GridControl2)
        LabelControl6.Text = "STAGING DATA CUSTOMER " & GridView2.RowCount.ToString
    End Sub
    Private Sub viewLocalVendor()
        '// Vendor local
        Dim SSQL As String
        SSQL = "SELECT VENDOR_CODE,VENDOR_NAME,ADDRESS,STATE,ACCOUNTGROUP,ACCOUNTGROUPN,STATUS, CASE WHEN  INACTIVE IS NOT NULL THEN 'X' ELSE '' END DELETED " +
            " from T_vendor " +
            " where nvl(STATUS,' ') != 'X'"
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        FILLGridView(SSQL, GridControl1)
    End Sub
    Private Sub viewSagingVendor()
        '///Vendor staging
        Dim SSQL As String
        SSQL = " SELECT COMPANYCODE,VENDORID,VENDORNAME,STREET,CITY,ACCOUNTGROUP,ACCOUNTGROUPNAME,STATUS, FLAG_1, Case When  DELETED Is Not NULL Then 'X' ELSE '' END DELETED " +
        " FROM WB_VENDOR " +
        " WHERE nvl(STATUS,' ') != 'X'"
        GridView2.Columns.Clear()
        GridControl2.DataSource = Nothing
        FILLGridViewstg(SSQL, GridControl2)
    End Sub
    Private Sub ViewStagingPO()
        '///PURCHASE PO STAGING
        Dim SSQL As String
        SSQL = " Select  CompanyCode, CONTRACTNO, ITEMNO, DOCTYPE, VENDORID, INCOTERMS1, INCOTERMS2, MATERIALID, PLANT,  TO_CHAR(VALIDITYSTARTDATE,'YYYY-MM-DD') VALIDITYSTARTDATE, TO_CHAR(VALIDITYENDDATE,'YYYY-MM-DD') VALIDITYENDDATE, nvl(FLATRATE,0) FLATRATE, STATUS, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
        " From WB_CONTRACT " +
        " Where nvl(status,' ') != 'X'  " +
        " And CompanyCode = '" & CompanyCode & "'"
        GridView1.Columns.Clear()
        GridControl2.DataSource = Nothing
        FILLGridViewstg(SSQL, GridControl2)
    End Sub
    Private Sub ViewLokalPO()
        '///PURCHASE PO LOKAL
        Dim SSQL As String
        SSQL = " SELECT CONTRACT_NUMBER,ITEMNO,DOCUMENT_TYPE,VENDOR_CODE, INCOTERMS1, INCOTERMS2,MATERIALCODE AS MATERIALID,TO_CHAR(CONTRACT_STARTDATE,'YYYY-MM-DD')VALIDITYSTARTDATE ,TO_CHAR(CONTRACT_ENDDATE,'YYYY-MM-DD')VALIDITYENDDATE ,NVL(FLATE_RATE,0) AS FLATRATE,STATUS,CASE WHEN  INACTIVE IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
        " FROM T_PURCHASECONTRACT " +
        " Where INACTIVE IS NOT NULL  "
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        FILLGridView(SSQL, GridControl1)
    End Sub
    Private Sub ViewLokalSO()
        '/// Sales Order Local
        Dim SSQL As String
        SSQL = "select COMPANYCODE,SO_NO,CUST_CODE,INCOTERMS1,INCOTERMS2,ITEMNO,SC_NO,MATERIAL_CODE,SO_QTY,TOLERANCE, TO_CHAR(SO_START,'YYY-MM-DD') SO_START, TO_CHAR(SO_END, 'YYYY-MM-DD') SO_END,STATUS,SO_DUP,CUST_CODE_DUP,SC_NO_DUP, CASE WHEN DELETE IS NOT NULL THEN 'X' ELSE '' END DELETED " +
        " FROM T_SALESORDER " +
        " WHERE INACTIVE IS NOT NULL "
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        FILLGridView(SSQL, GridControl1)
    End Sub
    Private Sub ViewStagingSO()
        '/// Sales Order Staging
        Dim SSQL As String
        SSQL = " select COMPANYCODE,SALESORDERNO,CUSTOMERID,INCOTERMS1,INCOTERMS2,ITEMNO, SALESCONTRACTNO, MATERIALID, PLANT, DELETED, CONTRACTQUANTITY , TOLERANCE,TO_CHAR(CONTRACTSTARTDATE,'YYYY-MM-DD') CONTRACTSTARTDATE, TO_CHAR(CONTRACTENDDATE,'YYYY-MM-DD') CONTRACTENDDATE,STATUS , SALESORDERNO_DUP, CUSTOMERID_DUP, SALESCONTRACTNO_DUP, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
               " from wb_salesorder " +
               " where nvl(status,' ') != 'X' " +
               " And companycode = '" & CompanyCode & "'"
        GridView2.Columns.Clear()
        GridControl2.DataSource = Nothing
        FILLGridViewstg(SSQL, GridControl2)
    End Sub
    Private Sub ViewLokalIO()
        '// INTERNAL ORDER LOKAL
        Dim SSQL As String
        SSQL = " SELECT INTERNALORDER, POLICENO, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED " +
                " FROM T_VEHICLE " +
                " where ESTATECODE IS NOT NULL " +
                " And companycode = '" & CompanyCode & "'"
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        FILLGridView(SSQL, GridControl1)
    End Sub
    Private Sub ViewStagingIO()
        '/// INTERNAL ORDER STAGING (VEHICLE
        Dim SSQL As String
        SSQL = "SELECT INTERNALORDER, POLICENO, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED " +
            " FROM WB_INTERNALORDER " +
             "where nvl(status,' ') != 'X' " +
             "And companycode = '" & CompanyCode & "'"
        GridView2.Columns.Clear()
        GridControl2.DataSource = Nothing
        FILLGridViewstg(SSQL, GridControl2)
    End Sub

    Private Sub viewSLokalOR()
        '// ORGANITATION LOKAL
        Dim SSQL As String
        SSQL = "SELECT ESTATECODE, ESTATENAME, DIVISIONCODE, DIVISIONNAME " +
        " FROM WBORGANIZATION " +
        "where ESTATE CODE IS NOT NULL " +
        " And companycode = '" & CompanyCode & "'"
        GridView1.Columns.Clear()
        GridControl1.DataSource = Nothing
        FILLGridView(SSQL, GridControl1)
    End Sub
    Private Sub ViewStagingOR()
        '// ORGANITATION STAGING
        Dim SSQL As String
        SSQL = "SELECT ESTATECODE, ESTATENAME, DIVISIONCODE, DIVISIONNAME " +
        " FROM WB_ORGANIZATION " +
        "where nvl(status,' ') != 'X' " +
        "And companycode = '" & CompanyCode & "'"
        GridView2.Columns.Clear()
        GridControl2.DataSource = Nothing
        FILLGridViewstg(SSQL, GridControl2)
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        LabelControl13.Text = "PROGRES"
        viewLocalCustomer()
        viewSagingCustomer()
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        LabelControl13.Text = "PROGRES"
        viewLocalVendor()
        viewSagingVendor()
    End Sub
    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        LabelControl13.Text = "PROGRES"
        ViewLokalPO()
        ViewStagingPO()
    End Sub
    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click
        LabelControl13.Text = "PROGRES"
        ViewLokalSO()
        ViewStagingSO()
    End Sub
    Private Sub RadioButton5_Click(sender As Object, e As EventArgs) Handles RadioButton5.Click
        ViewLokalIO()
        ViewStagingIO()
    End Sub

    Private Sub RadioButton6_Click(sender As Object, e As EventArgs) Handles RadioButton6.Click
        viewSLokalOR()
        ViewStagingOR()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click


        'IMPORT DATA STAGING TO LOCAL
        SimpleButton5.Enabled = False
        ProgressBarControl1.Visible = True
        If RadioButton1.Checked Then
            LabelControl13.Text = "CUSTOMER DATA"
            IMPORT_CUSTOMER()
        ElseIf RadioButton2.Checked Then
            LabelControl13.Text = "VENDOR DATA"
            IMPORT_VENDOR()
        ElseIf RadioButton3.Checked Then
            LabelControl13.Text = "PURCHASE CONTRACT DATA"
            IMPORT_PO()
        ElseIf RadioButton4.Checked Then
            LabelControl13.Text = "SALES ORDER DATA"
        ElseIf RadioButton5.Checked Then
            LabelControl13.Text = "INTERNAL ORDER DATA"
        ElseIf RadioButton6.Checked Then
            LabelControl13.Text = "ORGANIZATION DATA"
        ElseIf RadioButton7.Checked Then
            LabelControl13.Text = "CUSTOMER DATA"
        End If
        ProgressBarControl1.Visible = False
        SimpleButton5.Enabled = True
    End Sub
    Private Sub IMPORT_CUSTOMER()
        Dim G As Integer = GridView1.RowCount
        Dim S As Integer = GridView2.RowCount

        If G <> S And G Or S <> 0 Then
            'DATA STAGING
            Dim SSQL As String = "select COMPANYCODE,CUSTOMERID,CUSTOMERNAME,STREET,CITY,ACCOUNTGROUP,ACCOUNTGROUPNAME,STATUS, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
                                " from wb_customer " +
                                " where nvl(STATUS,' ')!= 'X' " +
                                " And companycode = '" & CompanyCode & "' ORDER BY COMPANYCODE"
            Dim DT As DataTable = ExecuteQuery(SSQL) 'GANTI STAGING

            ' Initializing progress bar properties
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Properties.Maximum = DT.Rows.Count
            ProgressBarControl1.EditValue = 0
            Dim TI As Integer = 0  'TOTAL NEW
            Dim TU As Integer = 0  'TOTAL UPDATE
            G = DT.Rows.Count - 1
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim KDCUSTOMERCODE As String = DT.Rows(i).Item("CUSTOMERID").ToString
                Dim CUSTOMERNAME As String = DT.Rows(i).Item("CUSTOMERNAME").ToString
                Dim NPWP As String = "" : Dim EMAIL As String = ""
                Dim ADDRESS As String = DT.Rows(i).Item("STREET").ToString
                Dim POSTALCODE As String = "" : Dim PHONE As String = ""
                Dim MOBILEPHONE As String = "" : Dim FAX As String = ""
                Dim CONTACTPERSON As String = "" : Dim BANKACCOUNT As String = ""
                Dim BANKNAME As String = "" : Dim COUNTRY As String = ""
                Dim STATE As String = DT.Rows(i).Item("CITY").ToString
                Dim ACCOUNTGROUP As String = DT.Rows(i).Item("ACCOUNTGROUP").ToString
                Dim ACCOUNTGROUPN As String = DT.Rows(i).Item("ACCOUNTGROUPNAME").ToString
                Dim STATUS As String = DT.Rows(i).Item("STATUS").ToString
                Dim INACTIVE As String = DT.Rows(i).Item("DELETED").ToString


                SQL = "SELECT * FROM T_CUSTOMER WHERE CUST_CODE='" & KDCUSTOMERCODE & "'"
                If CheckRecord(SQL) = 0 Then
                    SQL = "INSERT INTO T_CUSTOMER (CUST_CODE,CUST_NAME,NPWP_CUST,EMAIL_CUST,ADDRESS_CUST,POSTAL_CODE_CUST,PHONE_CUST,MOBILEPHONE_CUST,FAX_CUST,CONTACT_PERSON_CUST,BANK_ACC_NO_CUST,BANK_NAME_CUST,ACCOUNTGROUP,ACCOUNTGROUPNAME,COUNTRY,INPUT_BY,INPUT_DATE,INACTIVE,STATE_CUST,STATUS)" +
                          "VALUES ('" & KDCUSTOMERCODE & "','" & CUSTOMERNAME & "','" & NPWP & "','" & EMAIL & "','" & ADDRESS & "','" & POSTALCODE & "','" & PHONE & "','" & MOBILEPHONE & "','" & FAX & "','" & CONTACTPERSON & "','" & BANKACCOUNT & "','" & BANKNAME & "','" & ACCOUNTGROUP & "','" & ACCOUNTGROUPN & "','" & COUNTRY & "','" & USERNAME & "',SYSDATE,DEFAULT,'" & STATE & "','" & STATUS & "') "
                    TI = TI + 1
                Else

                    SQL = " UPDATE T_CUSTOMER SET CUST_NAME='" & CUSTOMERNAME & "',NPWP_CUST='" & NPWP & "',EMAIL_CUST='" & EMAIL & "',ADDRESS_CUST='" & ADDRESS & "',POSTAL_CODE_CUST='" & POSTALCODE & "',STATE_CUST='" & STATE & "',COUNTRY='" & COUNTRY & "',PHONE_CUST='" & PHONE & "',MOBILEPHONE_CUST='" & MOBILEPHONE & "',FAX_CUST='" & FAX & "', " +
                          " CONTACT_PERSON_CUST='" & CONTACTPERSON & "',BANK_ACC_NO_CUST ='" & BANKACCOUNT & "',BANK_NAME_CUST='" & BANKNAME & "',ACCOUNTGROUP='" & ACCOUNTGROUP & "',ACCOUNTGROUPNAME='" & ACCOUNTGROUPN & "',UPDATE_BY='" & USERNAME & "',UPDATE_DATE=SYSDATE,STATUS='" & STATUS & "' " +
                          " WHERE CUST_CODE='" & KDCUSTOMERCODE & "'"
                    TU = TU + 1
                End If
                ExecuteNonQuery(SQL)

                'UPDATE STATUS STAGING
                SQL = "UPDATE wb_customer SET STATUS='X'" +
                " WHERE  CUSTOMERID='" & KDCUSTOMERCODE & "'" +
                " And companycode = '" & CompanyCode & "'"
                ExecuteNonQuery(SQL) 'GANTI DATA STAGING
                LabelControl13.Text = "PROSES.. " & G & " (TI=" & TI & ": TU=" & TU & ")"
                'UPDATE PROGRES ...
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
                'REFRESH GRID TARGET (LOCAL)
                viewLocalCustomer()
            Next
        End If
        viewSagingCustomer()

        ProgressBarControl1.Properties.Step = 1
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Properties.Maximum = 1
        ProgressBarControl1.EditValue = 0
        MsgBox("INSERT CUSTOMER BERHASIL", vbInformation, Me.Text)
    End Sub

    Private Sub IMPORT_VENDOR()
        Dim G As Integer = GridView1.RowCount
        Dim S As Integer = GridView2.RowCount

        If G <> S And G Or S <> 0 Then
            'DATA STAGING
            Dim SSQL As String = " SELECT COMPANYCODE,VENDORID,VENDORNAME,STREET,CITY,ACCOUNTGROUP,ACCOUNTGROUPNAME,STATUS, FLAG_1, Case When  DELETED Is Not NULL Then 'X' ELSE '' END DELETED " +
                                " FROM WB_VENDOR " +
                                " WHERE nvl(STATUS,' ') != 'X'" +
                                " And COMPANYCODE = '" & CompanyCode & "' ORDER BY COMPANYCODE"
            Dim DT As DataTable = ExecuteQuery(SSQL) 'GANTI STAGING

            ' Initializing progress bar properties
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Properties.Maximum = DT.Rows.Count
            ProgressBarControl1.EditValue = 0
            Dim TI As Integer = 0  'TOTAL NEW
            Dim TU As Integer = 0  'TOTAL UPDATE
            G = DT.Rows.Count - 1
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim VENCODE As String = DT.Rows(i).Item("VENDORID").ToString
                Dim VENNAME As String = DT.Rows(i).Item("VENDORNAME").ToString
                Dim NPWP As String = "" : Dim EMAIL As String = ""
                Dim ADDRESS As String = DT.Rows(i).Item("STREET").ToString
                Dim POSTALCODE As String = "" : Dim PHONE As String = ""
                Dim MOBILEPHONE As String = "" : Dim FAX As String = ""
                Dim CONTACTPERSON As String = "" : Dim BANKACCOUNT As String = ""
                Dim BANKNAME As String = "" : Dim COUNTRY As String = ""
                Dim STATE As String = DT.Rows(i).Item("CITY").ToString
                Dim ACCOUNTGROUP As String = DT.Rows(i).Item("ACCOUNTGROUP").ToString
                Dim ACCOUNTGROUPN As String = DT.Rows(i).Item("ACCOUNTGROUPNAME").ToString
                Dim STATUS As String = DT.Rows(i).Item("STATUS").ToString
                Dim INACTIVE As String = DT.Rows(i).Item("DELETED").ToString
                Dim INTER As String = "" : Dim POSTCODE As String = ""
                Dim MPHONE As String = "" : Dim CP As String = ""
                Dim BANKACC As String = "" : Dim USERNAME As String = "AUTO"

                SQL = "SELECT * FROM T_VENDOR WHERE VENDOR_CODE='" & VENCODE & "'"
                If CheckRecord(SQL) = 0 Then
                    SQL = " INSERT INTO T_VENDOR (VENDOR_CODE,VENDOR_NAME,INTERNAL,NPWP,EMAIL,ADDRESS,POSTAL_CODE,STATE,COUNTRY,PHONE,MOBILEPHONE,FAX,CONTACTPERSON,BANKACCOUNT,ACCOUNTGROUP,ACCOUNTGROUPN,INPUTBY,INPUTDATE,INACTIVE,STATUS)" +
                      " VALUES('" & VENCODE & "','" & VENNAME & "','" & INTER & "','" & NPWP & "','" & EMAIL & "','" & ADDRESS & "','" & POSTCODE & "','" & STATE & "','" & COUNTRY & "','" & PHONE & "','" & MPHONE & "','" & FAX & "','" & CP & "','" & BANKACC & "','" & ACCOUNTGROUP & "','" & ACCOUNTGROUPN & "','" & USERNAME & "',SYSDATE,NULL,'" & STATUS & "')"
                    TI = TI + 1
                Else

                    SQL = " UPDATE T_CUSTOMER SET CUST_NAME='" & VENNAME & "',NPWP_CUST='" & NPWP & "',EMAIL_CUST='" & EMAIL & "',ADDRESS_CUST='" & ADDRESS & "',POSTAL_CODE_CUST='" & POSTALCODE & "',STATE_CUST='" & STATE & "',COUNTRY='" & COUNTRY & "',PHONE_CUST='" & PHONE & "',MOBILEPHONE_CUST='" & MOBILEPHONE & "',FAX_CUST='" & FAX & "', " +
                          " CONTACT_PERSON_CUST='" & CONTACTPERSON & "',BANK_ACC_NO_CUST ='" & BANKACCOUNT & "',BANK_NAME_CUST='" & BANKNAME & "',ACCOUNTGROUP='" & ACCOUNTGROUP & "',ACCOUNTGROUPNAME='" & ACCOUNTGROUPN & "',UPDATE_BY='" & USERNAME & "',UPDATE_DATE=SYSDATE,STATUS='" & STATUS & "' " +
                          " WHERE CUST_CODE='" & VENCODE & "'"
                    TU = TU + 1
                End If

                ExecuteNonQuery(SQL)

                'UPDATE STATUS STAGING
                SQL = "UPDATE WB_VENDOR SET STATUS='X'" +
                " WHERE  VENDORID='" & VENCODE & "'" +
                " And companycode = '" & CompanyCode & "'"
                ExecuteNonQuery(SQL) 'GANTI DATA STAGING
                LabelControl13.Text = "PROSES.. " & G & " (TI=" & TI & ": TU=" & TU & ")"
                'UPDATE PROGRES ...
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
                'REFRESH GRID TARGET (LOCAL)
                viewLocalVendor()
            Next
        End If
        viewSagingVendor()

        ProgressBarControl1.Properties.Step = 1
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Properties.Maximum = 1
        ProgressBarControl1.EditValue = 0
        MsgBox("INSERT VENDOR BERHASIL", vbInformation, Me.Text)
    End Sub

    Private Sub IMPORT_PO()
        Dim G As Integer = GridView1.RowCount
        Dim S As Integer = GridView2.RowCount

        If G <> S And G Or S <> 0 Then
            'DATA STAGING
            Dim SSQL As String = " Select  COMPANYCODE, CONTRACTNO, ITEMNO, DOCTYPE, VENDORID, INCOTERMS1, INCOTERMS2, MATERIALID, PLANT,  TO_CHAR(VALIDITYSTARTDATE,'YYYY-MM-DD') VALIDITYSTARTDATE, TO_CHAR(VALIDITYENDDATE,'YYYY-MM-DD') VALIDITYENDDATE, nvl(FLATRATE,0) FLATRATE, STATUS, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
                                 " From WB_CONTRACT " +
                                 " Where nvl(status,' ') != 'X'  " +
                                 " And COMPANYCODE = '" & CompanyCode & "'"

            Dim DT As DataTable = ExecuteQuery(SSQL) 'GANTI STAGING
            ' Initializing progress bar properties
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Properties.Maximum = DT.Rows.Count
            ProgressBarControl1.EditValue = 0
            Dim TI As Integer = 0  'TOTAL NEW
            Dim TU As Integer = 0  'TOTAL UPDATE
            G = DT.Rows.Count - 1
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim CONTRACTNO As String = DT.Rows(i).Item("CONTRACTNO").ToString
                Dim ITEMNO As String = DT.Rows(i).Item("ITEMNO").ToString
                Dim DOCTYPE As String = DT.Rows(i).Item("DOCTYPE").ToString
                Dim VENDORID As String = DT.Rows(i).Item("VENDORID").ToString
                Dim INCOTERMS1 As String = DT.Rows(i).Item("INCOTERMS1").ToString
                Dim INCOTERMS2 As String = DT.Rows(i).Item("INCOTERMS2").ToString
                Dim MATERIALID As String = DT.Rows(i).Item("MATERIALID").ToString
                Dim PLANT As String = DT.Rows(i).Item("PLANT").ToString
                Dim VALIDITYSTARTDATE As String = DT.Rows(i).Item("VALIDITYSTARTDATE").ToString
                Dim VALIDITYENDDATE As String = DT.Rows(i).Item("VALIDITYENDDATE").ToString
                Dim FLATRATE As String = DT.Rows(i).Item("FLATRATE").ToString
                Dim STATUS As String = DT.Rows(i).Item("STATUS").ToString
                Dim GRADING As String = ""

                SQL = "SELECT * FROM T_PURCHASECONTRACT WHERE CONTRACT_NUMBER='" & CONTRACTNO & "'"
                If CheckRecord(SQL) = 0 Then
                    SQL = " INSERT INTO T_PURCHASECONTRACT (CONTRACT_NUMBER,DOCUMENT_TYPE,CONTRACT_STARTDATE,CONTRACT_ENDDATE,VENDOR_CODE, " +
                        " INCOTERMS1,INCOTERMS2,ITEMNO,MATERIALCODE,FLATE_RATE,GRADING,STATUS,INACTIVE,INPUT_BY,INPUT_DATE) " +
                        " VALUES ('" & CONTRACTNO & "','" & DOCTYPE & "'," & VALIDITYSTARTDATE & "," & VALIDITYENDDATE & ",'" & VENDORID & "', " +
                        " '" & INCOTERMS1 & "','" & INCOTERMS2 & "','" & ITEMNO & "','" & MATERIALID & "','" & FLATRATE & "','" & GRADING & "','',NULL,'" & USERNAME & "',SYSDATE) "
                    TI = TI + 1
                Else
                    SQL = "UPDATE T_PURCHASECONTRACT SET DOCUMENT_TYPE='" & DOCTYPE & "',CONTRACT_STARTDATE=" & VALIDITYSTARTDATE & ",CONTRACT_ENDDATE=" & VALIDITYENDDATE & ",VENDOR_CODE='" & VENDORID & "',INCOTERMs1='" & INCOTERMS1 & "',INCOTERMS2='" & INCOTERMS2 & "',ITEMNO='" & ITEMNO & "',MATERIALCODE='" & MATERIALID & "',FLATE_RATE='" & FLATRATE & "',UPDATE_BY='" & USERNAME & "',UPDATE_DATE=SYSDATE,GRADING='" & GRADING & "'" +
                        " WHERE CONTRACT_NUMBER= '" & CONTRACTNO & "'"
                    TU = TU + 1
                End If

                ExecuteNonQuery(SQL)

                'UPDATE STATUS STAGING
                SQL = "UPDATE WB_CONTRACT SET STATUS='X'" +
                " WHERE  CONTRACTNO='" & CONTRACTNO & "'" +
                " And companycode = '" & CompanyCode & "'"
                ExecuteNonQuery(SQL) 'GANTI DATA STAGING
                LabelControl13.Text = "PROSES.. " & G & " (TI=" & TI & ": TU=" & TU & ")"
                'UPDATE PROGRES ...
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
                'REFRESH GRID TARGET (LOCAL)
                viewLocalVendor()
            Next
        End If
        viewSagingVendor()

        ProgressBarControl1.Properties.Step = 1
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Properties.Maximum = 1
        ProgressBarControl1.EditValue = 0
        MsgBox("INSERT VENDOR BERHASIL", vbInformation, Me.Text)
    End Sub

    Private Sub IMPORT_SO()
        Dim G As Integer = GridView1.RowCount
        Dim S As Integer = GridView2.RowCount

        If G <> S And G Or S <> 0 Then
            'DATA STAGING
            Dim SSQL As String = " Select  COMPANYCODE, CONTRACTNO, ITEMNO, DOCTYPE, VENDORID, INCOTERMS1, INCOTERMS2, MATERIALID, PLANT,  TO_CHAR(VALIDITYSTARTDATE,'YYYY-MM-DD') VALIDITYSTARTDATE, TO_CHAR(VALIDITYENDDATE,'YYYY-MM-DD') VALIDITYENDDATE, nvl(FLATRATE,0) FLATRATE, STATUS, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
                                 " From WB_CONTRACT " +
                                 " Where nvl(status,' ') != 'X'  " +
                                 " And COMPANYCODE = '" & CompanyCode & "'"

            Dim DT As DataTable = ExecuteQuery(SSQL) 'GANTI STAGING
            ' Initializing progress bar properties
            ProgressBarControl1.Properties.Step = 1
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Properties.Maximum = DT.Rows.Count
            ProgressBarControl1.EditValue = 0
            Dim TI As Integer = 0  'TOTAL NEW
            Dim TU As Integer = 0  'TOTAL UPDATE
            G = DT.Rows.Count - 1
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim CONTRACTNO As String = DT.Rows(i).Item("CONTRACTNO").ToString
                Dim ITEMNO As String = DT.Rows(i).Item("ITEMNO").ToString
                Dim DOCTYPE As String = DT.Rows(i).Item("DOCTYPE").ToString
                Dim VENDORID As String = DT.Rows(i).Item("VENDORID").ToString
                Dim INCOTERMS1 As String = DT.Rows(i).Item("INCOTERMS1").ToString
                Dim INCOTERMS2 As String = DT.Rows(i).Item("INCOTERMS2").ToString
                Dim MATERIALID As String = DT.Rows(i).Item("MATERIALID").ToString
                Dim PLANT As String = DT.Rows(i).Item("PLANT").ToString
                Dim VALIDITYSTARTDATE As String = DT.Rows(i).Item("VALIDITYSTARTDATE").ToString
                Dim VALIDITYENDDATE As String = DT.Rows(i).Item("VALIDITYENDDATE").ToString
                Dim FLATRATE As String = DT.Rows(i).Item("FLATRATE").ToString
                Dim STATUS As String = DT.Rows(i).Item("STATUS").ToString
                Dim GRADING As String = ""

                SQL = "SELECT * FROM T_PURCHASECONTRACT WHERE CONTRACT_NUMBER='" & CONTRACTNO & "'"
                If CheckRecord(SQL) = 0 Then
                    SQL = " INSERT INTO T_PURCHASECONTRACT (CONTRACT_NUMBER,DOCUMENT_TYPE,CONTRACT_STARTDATE,CONTRACT_ENDDATE,VENDOR_CODE, " +
                        " INCOTERMS1,INCOTERMS2,ITEMNO,MATERIALCODE,FLATE_RATE,GRADING,STATUS,INACTIVE,INPUT_BY,INPUT_DATE) " +
                        " VALUES ('" & CONTRACTNO & "','" & DOCTYPE & "'," & VALIDITYSTARTDATE & "," & VALIDITYENDDATE & ",'" & VENDORID & "', " +
                        " '" & INCOTERMS1 & "','" & INCOTERMS2 & "','" & ITEMNO & "','" & MATERIALID & "','" & FLATRATE & "','" & GRADING & "','',NULL,'" & USERNAME & "',SYSDATE) "
                    TI = TI + 1
                Else
                    SQL = "UPDATE T_PURCHASECONTRACT SET DOCUMENT_TYPE='" & DOCTYPE & "',CONTRACT_STARTDATE=" & VALIDITYSTARTDATE & ",CONTRACT_ENDDATE=" & VALIDITYENDDATE & ",VENDOR_CODE='" & VENDORID & "',INCOTERMs1='" & INCOTERMS1 & "',INCOTERMS2='" & INCOTERMS2 & "',ITEMNO='" & ITEMNO & "',MATERIALCODE='" & MATERIALID & "',FLATE_RATE='" & FLATRATE & "',UPDATE_BY='" & USERNAME & "',UPDATE_DATE=SYSDATE,GRADING='" & GRADING & "'" +
                        " WHERE CONTRACT_NUMBER= '" & CONTRACTNO & "'"
                    TU = TU + 1
                End If

                ExecuteNonQuery(SQL)

                'UPDATE STATUS STAGING
                SQL = "UPDATE WB_CONTRACT SET STATUS='X'" +
                " WHERE  CONTRACTNO='" & CONTRACTNO & "'" +
                " And companycode = '" & CompanyCode & "'"
                ExecuteNonQuery(SQL) 'GANTI DATA STAGING
                LabelControl13.Text = "PROSES.. " & G & " (TI=" & TI & ": TU=" & TU & ")"
                'UPDATE PROGRES ...
                ProgressBarControl1.PerformStep()
                ProgressBarControl1.Update()
                'REFRESH GRID TARGET (LOCAL)
                viewLocalVendor()
            Next
        End If
        viewSagingVendor()

        ProgressBarControl1.Properties.Step = 1
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Properties.Maximum = 1
        ProgressBarControl1.EditValue = 0
        MsgBox("INSERT VENDOR BERHASIL", vbInformation, Me.Text)
    End Sub

End Class