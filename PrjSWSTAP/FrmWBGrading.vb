Public Class FrmWBGrading
    Dim NO_TICKET As String = ""
    Dim TAHUN_TANAM As String = ""
    Dim JML_JJG As Integer = 0
    Dim JML_JJG_GRADING As Integer = 0
    'FILL DATA DETAIL
    Dim N501 As Integer = 0
    Dim N502 As Integer = 0
    Dim N503 As Integer = 0
    Dim N504 As Integer = 0
    Dim N505 As Integer = 0
    Dim N506 As Integer = 0
    Dim N507 As Integer = 0
    Dim N508 As Integer = 0
    Dim N509 As Integer = 0
    Dim N510 As Integer = 0
    Dim N511 As Integer = 0
    Dim N512 As Integer = 0
    Dim N513 As Integer = 0
    Dim N514 As Integer = 0
    Dim N515 As Integer = 0
    Dim N516 As Integer = 0
    Dim N517 As Integer = 0
    Dim N518 As Integer = 0
    Dim N519 As Integer = 0
    Dim N520 As Integer = 0
    Dim N521 As Integer = 0
    Dim N522 As Integer = 0
    Dim N523 As Integer = 0
    Dim N524 As Integer = 0
    Dim N525 As Integer = 0
    Dim N526 As Integer = 0
    Dim N527 As Integer = 0
    Dim N528 As Integer = 0
    Dim N529 As Integer = 0
    Dim N530 As Integer = 0
    Dim N531 As Integer = 0
    Dim N532 As Integer = 0
    Dim N533 As Integer = 0
    Dim N534 As Integer = 0
    Dim N535 As Integer = 0
    Dim N536 As Integer = 0
    Dim N537 As Integer = 0
    Dim N538 As Integer = 0
    Dim N539 As Integer = 0
    Dim N540 As Integer = 0
    Dim N541 As Integer = 0
    Dim N542 As Integer = 0
    Dim N543 As Integer = 0
    Dim N544 As Integer = 0
    Dim N545 As Integer = 0
    Dim N546 As Integer = 0
    Dim N547 As Integer = 0
    Dim N548 As Integer = 0
    Dim N549 As Integer = 0
    Dim N550 As Integer = 0
    Dim N551 As Integer = 0
    Dim N552 As Integer = 0
    Dim N553 As Integer = 0
    Dim N554 As Integer = 0
    Dim N555 As Integer = 0
    Dim N556 As Integer = 0
    Dim N557 As Integer = 0
    Dim N558 As Integer = 0

    Private Sub FrmWBGrading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = nFormName

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        'LUV TIKET DENGAN MATERIAL HANYA TBS
        LSQL = "SELECT DISTINCT NO_TICKET,VENDOR_NAME AS SUPPLIER,TAHUN_TANAM,JML_JJG AS JML_JANJANG,JML_JJG_GRADING AS JML_SAMPLE,NETTO FROM V_RPT_GRADING "
        LField = "NO_TICKET"
        ValueLoV = ""
        TextEdit1.Text = FrmShowLOV(FrmLoV, LSQL, "GRADING TBS", "NO TICKET")
        If TextEdit1.Text <> "" THEn
            SQL = "SELECT DISTINCT NO_TICKET,VENDOR_NAME AS SUPPLIER,TAHUN_TANAM,JML_JJG AS JML_JANJANG,JML_JJG_GRADING AS JML_SAMPLE,NETTO FROM V_RPT_GRADING WHERE TRIM(NO_TICKET)='" & Trim(TextEdit1.Text) & "' "
            Dim DTG As New DataTable
            DTG = ExecuteQuery(SQL)
            If DTG.Rows.Count > 0 Then
                TextEdit3.Text = DTG.Rows(0).Item("SUPPLIER").ToString
                TextEdit4.Text = DTG.Rows(0).Item("TAHUN_TANAM").ToString
                TextEdit5.Text = DTG.Rows(0).Item("JML_JANJANG").ToString
                TextEdit6.Text = DTG.Rows(0).Item("JML_SAMPLE").ToString
                TextEdit2.Text = DTG.Rows(0).Item("NETTO").ToString
            End If
            Timer1.Enabled = True
        Else
            ClearText()
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub ClearText()
        'BERAT
        TextEdit2.Text = "0"
        TextEdit63.Text = "0"
        TextEdit78.Text = "0"
        'HEADER
        TextEdit3.Text = "0"
        TextEdit4.Text = "0"
        TextEdit5.Text = "0"
        TextEdit6.Text = "0"
        'DETAIL JANJANG
        TextEdit7.Text = "0"
        TextEdit8.Text = "0"
        TextEdit9.Text = "0"
        TextEdit10.Text = "0"
        TextEdit11.Text = "0"
        TextEdit12.Text = "0"
        TextEdit13.Text = "0"
        TextEdit14.Text = "0"
        TextEdit15.Text = "0"
        TextEdit16.Text = "0"
        TextEdit17.Text = "0"
        TextEdit18.Text = "0"
        TextEdit19.Text = "0"
        TextEdit20.Text = "0"
        'DETAIL JANJANG Grading
        TextEdit21.Text = "0"
        TextEdit22.Text = "0"
        TextEdit23.Text = "0"
        TextEdit24.Text = "0"
        TextEdit25.Text = "0"
        TextEdit26.Text = "0"
        TextEdit27.Text = "0"
        TextEdit28.Text = "0"
        TextEdit29.Text = "0"
        TextEdit30.Text = "0"
        TextEdit31.Text = "0"
        TextEdit32.Text = "0"
        'kg
        TextEdit33.Text = "0"
        TextEdit34.Text = "0"
        TextEdit35.Text = "0"
        TextEdit36.Text = "0"
        TextEdit37.Text = "0"
        TextEdit38.Text = "0"
        TextEdit39.Text = "0"
        TextEdit40.Text = "0"
        TextEdit41.Text = "0"
        TextEdit42.Text = "0"
        TextEdit43.Text = "0"
        TextEdit44.Text = "0"
        TextEdit45.Text = "0"
        TextEdit46.Text = "0"
        TextEdit47.Text = "0"
        'Detail %
        TextEdit62.Text = "0"
        TextEdit61.Text = "0"
        TextEdit60.Text = "0"
        TextEdit59.Text = "0"
        TextEdit58.Text = "0"
        TextEdit57.Text = "0"
        TextEdit56.Text = "0"
        TextEdit55.Text = "0"
        TextEdit54.Text = "0"
        TextEdit53.Text = "0"
        TextEdit52.Text = "0"
        TextEdit51.Text = "0"
        TextEdit50.Text = "0"
        TextEdit49.Text = "0"
        TextEdit48.Text = "0" 'potongam
        'remaks
        TextEdit77.Text = ""
        TextEdit76.Text = ""
        TextEdit75.Text = ""
        TextEdit74.Text = ""
        TextEdit73.Text = ""
        TextEdit72.Text = ""
        TextEdit71.Text = ""
        TextEdit70.Text = ""
        TextEdit69.Text = ""
        TextEdit68.Text = ""
        TextEdit67.Text = ""
        TextEdit66.Text = ""
        TextEdit65.Text = ""
        TextEdit64.Text = ""
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'SAVE
        If Not IsNumericOnly({TextEdit4, TextEdit5, TextEdit6}) = True THEn 'HEADER
            If Not IsNumericOnly({TextEdit7, TextEdit8, TextEdit10, TextEdit11, TextEdit12, TextEdit39, TextEdit40, TextEdit15, TextEdit16, TextEdit17, TextEdit18, TextEdit19, TextEdit20, TextEdit48}) = True THEn 'DETAIL
                'FILL DATA HEADER
                NO_TICKET = TextEdit1.Text
                TAHUN_TANAM = TextEdit4.Text
                JML_JJG = TextEdit5.Text
                JML_JJG_GRADING = TextEdit6.Text
                'FILL DATA DETAIL
                N501 = TextEdit7.Text
                N502 = TextEdit8.Text
                N503 = TextEdit9.Text
                N504 = TextEdit10.Text
                N505 = TextEdit11.Text
                N506 = TextEdit12.Text
                N507 = TextEdit39.Text
                N508 = TextEdit40.Text
                N509 = TextEdit15.Text
                N510 = TextEdit16.Text
                N511 = TextEdit17.Text
                N512 = TextEdit18.Text
                N513 = TextEdit19.Text
                N514 = TextEdit20.Text
                N515 = TextEdit21.Text
                N516 = TextEdit22.Text
                N517 = TextEdit23.Text
                N518 = TextEdit24.Text
                N519 = TextEdit25.Text
                N520 = TextEdit26.Text
                N521 = TextEdit27.Text
                N522 = TextEdit28.Text
                N523 = TextEdit29.Text
                N524 = TextEdit30.Text
                N525 = TextEdit31.Text
                N526 = TextEdit32.Text
                N527 = TextEdit33.Text
                N528 = TextEdit34.Text
                N529 = TextEdit35.Text
                N530 = TextEdit36.Text
                N531 = TextEdit37.Text
                N532 = TextEdit38.Text
                N533 = TextEdit31.Text
                N534 = TextEdit41.Text
                N535 = TextEdit42.Text
                N536 = TextEdit43.Text
                N537 = TextEdit45.Text
                N538 = TextEdit46.Text
                N539 = TextEdit47.Text
                N541 = TextEdit62.Text
                N542 = TextEdit61.Text
                N543 = TextEdit60.Text
                N544 = TextEdit59.Text
                N545 = TextEdit58.Text
                N546 = TextEdit57.Text
                N547 = TextEdit56.Text
                N548 = TextEdit55.Text
                N549 = TextEdit54.Text
                N550 = TextEdit53.Text
                N552 = TextEdit52.Text
                N553 = TextEdit51.Text
                N554 = TextEdit50.Text
                N555 = TextEdit49.Text
                N556 = TextEdit48.Text
                N557 = TextEdit13.Text
                N558 = TextEdit14.Text

                N515 = Val(TextEdit2.Text) * (Val(TextEdit48.Text) / 100) 'POTONGAN
                'update Sortasi
                'HEADER
                SQL = "UPDATE T_SORTASI_HEADER SET TAHUN_TANAM='" & TAHUN_TANAM & "',JML_JJG='" & JML_JJG & "',JML_JJG_GRADING='" & JML_JJG_GRADING & "',UPDATE_BY='" & USERNAME & "',UPDATE_DATE=SYSDATE WHERE NO_TICKET='" & NO_TICKET & "'"
                'MsgBox(SQL)
                ExecuteNonQuery(SQL)
                'DETAIL 
                'update jml
                Dim field As Integer
                Dim i As Integer = 0
                For i = 1 To 14
                    field = 500
                    field = field + i

                    SELECT Case CStr(field)
                        Case "501"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N501 & "',BERAT='" & N527 & "',PERSEN='" & N541 & "',REMARKS='" & Trim(TextEdit77.Text) & "' WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "502"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N502 & "',BERAT='" & N528 & "',PERSEN='" & N542 & ", REMARKS='" & Trim(TextEdit76.Text) & "' WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "503"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N503 & ",BERAT='" & N529 & "',PERSEN='" & N543 & ", REMARKS='" & Trim(TextEdit75.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "504"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N504 & "',BERAT='" & N530 & "',PERSEN='" & N544 & ", REMARKS='" & Trim(TextEdit74.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "505"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N505 & "',BERAT='" & N531 & "',PERSEN='" & N545 & ", REMARKS='" & Trim(TextEdit73.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "506"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N506 & "',BERAT='" & N532 & "',PERSEN='" & N546 & ", REMARKS='" & Trim(TextEdit72.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "507"
                            SQL = "UPDATE T_SORTASI_DETAIL SET BERAT='" & N507 & "',JML='" & N557 & "',PERSEN='" & N547 & ", REMARKS='" & Trim(TextEdit71.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "508"  'KG
                            SQL = "UPDATE T_SORTASI_DETAIL SET BERAT='" & N508 & "',JML='" & N558 & "',PERSEN='" & N548 & ", REMARKS='" & Trim(TextEdit70.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "509" 'KG
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N509 & "',BERAT='" & N534 & "',PERSEN='" & N549 & ", REMARKS='" & Trim(TextEdit69.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "510"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N510 & "',BERAT='" & N535 & "',PERSEN='" & N550 & ", REMARKS='" & Trim(TextEdit68.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "511"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N511 & "',BERAT='" & N536 & "',PERSEN='" & N552 & ", REMARKS='" & Trim(TextEdit67.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "512"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N512 & "',BERAT='" & N515 & "',PERSEN='" & N553 & ", REMARKS='" & Trim(TextEdit66.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "513"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N513 & "',BERAT='" & N537 & "',PERSEN='" & N554 & ", REMARKS='" & Trim(TextEdit65.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"
                        Case "514"
                            SQL = "UPDATE T_SORTASI_DETAIL SET JML='" & N514 & "',BERAT='" & N538 & "',PERSEN='" & N555 & ", REMARKS='" & Trim(TextEdit64.Text) & "'  WHERE NO_TICKET ='" & NO_TICKET & "' AND SORTASI_CODE='" & CStr(field) & "'"

                    End SELECT
                    ExecuteNonQuery(SQL)
                Next
                'msgbox
                ClearText()
                MsgBox("Update Grading Succefuly", vbInformation, Me.Text)
            End If
        End If
    End Sub
    Private Function SumGrading() As Integer

        N501 = Val(TextEdit7.Text)
        N502 = Val(TextEdit8.Text)
        N503 = Val(TextEdit9.Text)
        N504 = Val(TextEdit10.Text)
        N505 = Val(TextEdit11.Text)
        N506 = Val(TextEdit12.Text)
        N507 = Val(TextEdit39.Text)
        N508 = Val(TextEdit40.Text)
        N509 = Val(TextEdit15.Text)
        N510 = Val(TextEdit16.Text)
        N511 = Val(TextEdit17.Text)
        N512 = Val(TextEdit18.Text)
        N513 = Val(TextEdit19.Text)
        N514 = Val(TextEdit20.Text)
        ' NS15 = Val(TextEdit9.Text)
        'NS16 = Val(TextEdit13.Text)
        ''NS17 = Val(TextEdit14.Text)



        SumGrading = 0
        SumGrading = N501 + N502 + N503 + N504 + N505 + N506 + N507 + N508 + N509 + N510 + N511 + N512 + N513 + N514 + N515

        Return SumGrading
    End Function
    Private Sub TextEdit63_EditValueChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        'CLOSE
        Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextEdit63.Text = SumGrading()
        TextEdit78.Text = Val(TextEdit2.Text) - Val(TextEdit63.Text)

    End Sub

    Private Sub PanelControl6_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl6.Paint

    End Sub
End Class