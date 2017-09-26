Imports System.IO

Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Public Class FrmStaging
    Dim LStrSQL As String
    Dim SStrSQL As String
    Private Sub FrmStaging_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Private Sub viewLocalCustomer()
        '///CUSTOMER LOCAL
        LStrSQL = " select COMPANYCODE,CUST_CODE AS CUSTOMERID,CUST_NAME AS CUSTOMERNAME,ADDRESS_CUST AS STREET,STATE_CUST AS CITY,ACCOUNTGROUP,ACCOUNTGROUPNAME,STATUS, CASE WHEN  INACTIVE IS NOT NULL THEN 'X' ELSE '' END DELETED " +
        " FROM T_CUSTOMER " +
        " WHERE NVL(STATUS,'')!='X' " +
        " AND COMPANYCODE ='%""%'"
        GridControl1.DataSource = Nothing
        FILLGridView(LStrSQL, GridControl1)
    End Sub
    Private Sub viewSagingCustomer()
        '///customer staging
        SStrSQL = "select COMPANYCODE,CUSTOMERID,CUSTOMERNAME,STREET,CITY,ACCOUNTGROUP,ACCOUNTGROUPNAME,STATUS, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
        " from wb_customer " +
        " where nvl(status,'') != 'X' " +
        " And companycode = '" & CompanyCode & "'"
        GridControl2.DataSource = Nothing
        FILLGridViewStg(SStrSQL, GridControl2)
    End Sub
    Private Sub viewLocalVendor()
        '// Vendor local
        SStrSQL = "select COMPANYCODE,VENDORID,VENDORNAME,STREET,CITY,ACCOUNTGROUP,ACCOUNTGROUPNAME,STATUS, FLAG_1, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED " +
        " from T_vendor " +
        " where nvl(status,' ') != 'X' " +
        " And companycode = '" & CompanyCode & "'"
        GridControl1.DataSource = Nothing
        FILLGridView(LStrSQL, GridControl1)
    End Sub
    Private Sub viewSagingVendor()
        '///Vendor staging
        SStrSQL = " select COMPANYCODE,VENDORID,VENDORNAME,STREET,CITY,ACCOUNTGROUP,ACCOUNTGROUPNAME,STATUS, FLAG_1, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED " +
        " from wb_vendor " +
        " where nvl(status,' ') != 'X' " +
        " And companycode = '" & CompanyCode & "'"
        GridControl2.DataSource = Nothing
        FILLGridViewStg(SStrSQL, GridControl2)
    End Sub
    Private Sub ViewStagingPO()
        '///PURCHASE PO STAGING
        SStrSQL = " Select  CompanyCode, CONTRACTNO, ITEMNO, DOCTYPE, VENDORID, INCOTERMS1, INCOTERMS2, MATERIALID, PLANT,  TO_CHAR(VALIDITYSTARTDATE,'YYYY-MM-DD') VALIDITYSTARTDATE, TO_CHAR(VALIDITYENDDATE,'YYYY-MM-DD') VALIDITYENDDATE, nvl(FLATRATE,0) FLATRATE, STATUS, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
        " From WB_CONTRACT " +
        " Where nvl(status,' ') != 'X'  " +
        " And CompanyCode = '" & CompanyCode & "'"
        GridControl2.DataSource = Nothing
        FILLGridViewStg(SStrSQL, GridControl2)
    End Sub
    Private Sub ViewLokalPO()
        '///PURCHASE PO LOKAL
        SStrSQL = " SELECT '' AS COMPANYCODE,CONTRACT_NUMBER,ITEMNO,DOCUMENT_TYPE,VENDOR_CODE, INCOTERMS1, INCOTERMS2,MATERIALCODE AS MATERIALID,TO_CHAR(CONTRACT_STARTDATE,'YYYY-MM-DD')VALIDITYSTARTDATE ,TO_CHAR(CONTRACT_ENDDATE,'YYYY-MM-DD')VALIDITYENDDATE ,NVL(FLATE_RATE,0) AS FLATRATE,STATUS,CASE WHEN  INACTIVE IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
        " FROM T_PURCHASECONTRACT " +
        " Where INACTIVE IS NOT NULL  "
        '" And CompanyCode = '" & CompanyCode & "'"
        GridControl1.DataSource = Nothing
        FILLGridView(SStrSQL, GridControl1)
    End Sub
    Private Sub ViewLokalSO()
        '/// Sales Order Local
        SStrSQL = "select COMPANYCODE,SO_NO,CUST_CODE,INCOTERMS1,INCOTERMS2,ITEMNO,SC_NO,MATERIAL_CODE,SO_QTY,TOLERANCE, TO_CHAR(SO_START,'YYY-MM-DD') SO_START, TO_CHAR(SO_END, 'YYYY-MM-DD') SO_END,STATUS,SO_DUP,CUST_CODE_DUP,SC_NO_DUP, CASE WHEN DELETE IS NOT NULL THEN 'X' ELSE '' END DELETED " +
        " FROM T_SALESORDER " +
        " WHERE INACTIVE IS NOT NULL "
        GridControl1.DataSource = Nothing
        FILLGridView(SStrSQL, GridControl1)
    End Sub
    Private Sub ViewStagingSO()
        '/// Sales Order Staging
        SStrSQL = "select COMPANYCODE,SALESORDERNO,CUSTOMERID,INCOTERMS1,INCOTERMS2,ITEMNO, SALESCONTRACTNO, MATERIALID, PLANT, DELETED, CONTRACTQUANTITY , TOLERANCE,TO_CHAR(CONTRACTSTARTDATE,'YYYY-MM-DD') CONTRACTSTARTDATE, TO_CHAR(CONTRACTENDDATE,'YYYY-MM-DD') CONTRACTENDDATE,STATUS , SALESORDERNO_DUP, CUSTOMERID_DUP, SALESCONTRACTNO_DUP, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED  " +
                 " from wb_salesorder " +
        " where nvl(status,' ') != 'X' " +
        " And companycode = '" & CompanyCode & "'"
        GridControl2.DataSource = Nothing
        FILLGridViewstg(SStrSQL, GridControl2)
    End Sub
    Private Sub ViewLokalIO()
        '// INTERNAL ORDER LOKAL
        SStrSQL = "SELECT INTERNALORDER, POLICENO, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED " +
        " FROM T_WBINTERNALORDER " +
        "where ESTATECODE IS NOT NULL " +
        "And companycode = '" & CompanyCode & "'"
        GridControl1.DataSource = Nothing
        FILLGridView(SStrSQL, GridControl1)
    End Sub
    Private Sub ViewStagingIO()
        '/// INTERNAL ORDER STAGING
        SStrSQL = "SELECT INTERNALORDER, POLICENO, CASE WHEN  DELETED IS NOT NULL THEN 'X' ELSE '' END DELETED " +
            " FROM WB_INTERNALORDER " +
             "where nvl(status,' ') != 'X' " +
             "And companycode = '" & CompanyCode & "'"
        GridControl2.DataSource = Nothing
        FILLGridViewstg(SStrSQL, GridControl2)
    End Sub
    Private Sub viewSLokalOR()
        '// ORGANITATION LOKAL
        SStrSQL = "SELECT ESTATECODE, ESTATENAME, DIVISIONCODE, DIVISIONNAME " +
        " FROM WBORGANIZATION " +
        "where ESTATE CODE IS NOT NULL " +
        " And companycode = '" & CompanyCode & "'"
        GridControl1.DataSource = Nothing
        FILLGridView(SStrSQL, GridControl1)
    End Sub
    Private Sub ViewStagingOR()
        '// ORGANITATION STAGING
        SStrSQL = "SELECT ESTATECODE, ESTATENAME, DIVISIONCODE, DIVISIONNAME " +
        " FROM WB_ORGANIZATION " +
        "where nvl(status,' ') != 'X' " +
        "And companycode = '" & CompanyCode & "'"
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        viewLocalCustomer()
        viewSagingCustomer()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
        viewLocalVendor()
        viewSagingVendor()
    End Sub
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)
        ViewLokalPO()
        ViewStagingPO()
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        ViewLokalSO()
        ViewStagingSO()
    End Sub
    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        ViewLokalIO()
        ViewLokalSO()
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        viewSLokalOR()
        ViewStagingOR()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Me.Close()
    End Sub
End Class