﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMaterial
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up THE component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing THEn
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by THE Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: THE following procedure is required by THE Windows Form Designer
    'It can be modified using THE Windows Form Designer.  
    'Do not modify it using THE code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMaterial))
        Me.BunifuGradientPanel2 = New ns1.BunifuGradientPanel()
        Me.LabelControl89 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.LabelControl123 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl126 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl128 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl6 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.BunifuGradientPanel2.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl6.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BunifuGradientPanel2
        '
        Me.BunifuGradientPanel2.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel2.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel2.Controls.Add(Me.LabelControl89)
        Me.BunifuGradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.BunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.DarkGreen
        Me.BunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.White
        Me.BunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.Green
        Me.BunifuGradientPanel2.GradientTopRight = System.Drawing.Color.White
        Me.BunifuGradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BunifuGradientPanel2.Name = "BunifuGradientPanel2"
        Me.BunifuGradientPanel2.Quality = 10
        Me.BunifuGradientPanel2.Size = New System.Drawing.Size(1019, 43)
        Me.BunifuGradientPanel2.TabIndex = 73
        '
        'LabelControl89
        '
        Me.LabelControl89.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl89.Appearance.ForeColor = System.Drawing.Color.White
        Me.LabelControl89.Appearance.Options.UseFont = True
        Me.LabelControl89.Appearance.Options.UseForeColor = True
        Me.LabelControl89.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl89.Name = "LabelControl89"
        Me.LabelControl89.Size = New System.Drawing.Size(64, 14)
        Me.LabelControl89.TabIndex = 0
        Me.LabelControl89.Text = "MATERIAL"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.GridControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 158)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1019, 461)
        Me.PanelControl1.TabIndex = 86
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(2, 2)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1015, 457)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel10.Controls.Add(Me.LabelControl123)
        Me.Panel10.Controls.Add(Me.LabelControl126)
        Me.Panel10.Controls.Add(Me.LabelControl128)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel10.ForeColor = System.Drawing.Color.Black
        Me.Panel10.Location = New System.Drawing.Point(0, 43)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(153, 115)
        Me.Panel10.TabIndex = 87
        '
        'LabelControl123
        '
        Me.LabelControl123.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl123.Appearance.Options.UseFont = True
        Me.LabelControl123.Location = New System.Drawing.Point(10, 92)
        Me.LabelControl123.Name = "LabelControl123"
        Me.LabelControl123.Size = New System.Drawing.Size(88, 13)
        Me.LabelControl123.TabIndex = 6
        Me.LabelControl123.Text = "MATERIAL TYPE"
        '
        'LabelControl126
        '
        Me.LabelControl126.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl126.Appearance.Options.UseFont = True
        Me.LabelControl126.Location = New System.Drawing.Point(10, 70)
        Me.LabelControl126.Name = "LabelControl126"
        Me.LabelControl126.Size = New System.Drawing.Size(92, 13)
        Me.LabelControl126.TabIndex = 4
        Me.LabelControl126.Text = "MATERIAL NAME"
        '
        'LabelControl128
        '
        Me.LabelControl128.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl128.Appearance.Options.UseFont = True
        Me.LabelControl128.Location = New System.Drawing.Point(10, 48)
        Me.LabelControl128.Name = "LabelControl128"
        Me.LabelControl128.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl128.TabIndex = 3
        Me.LabelControl128.Text = "MATERIAL CODE"
        '
        'PanelControl6
        '
        Me.PanelControl6.Controls.Add(Me.PanelControl2)
        Me.PanelControl6.Controls.Add(Me.SimpleButton5)
        Me.PanelControl6.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl6.Location = New System.Drawing.Point(153, 43)
        Me.PanelControl6.Name = "PanelControl6"
        Me.PanelControl6.Size = New System.Drawing.Size(866, 39)
        Me.PanelControl6.TabIndex = 94
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.SimpleButton4)
        Me.PanelControl2.Controls.Add(Me.SimpleButton2)
        Me.PanelControl2.Controls.Add(Me.SimpleButton1)
        Me.PanelControl2.Controls.Add(Me.SimpleButton3)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(312, 35)
        Me.PanelControl2.TabIndex = 90
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton4.Appearance.ForeColor = System.Drawing.Color.Green
        Me.SimpleButton4.Appearance.Options.UseFont = True
        Me.SimpleButton4.Appearance.Options.UseForeColor = True
        Me.SimpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton4.Location = New System.Drawing.Point(235, 3)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(75, 27)
        Me.SimpleButton4.TabIndex = 3
        Me.SimpleButton4.Text = "Cancel"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton2.Appearance.ForeColor = System.Drawing.Color.Green
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Appearance.Options.UseForeColor = True
        Me.SimpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton2.Location = New System.Drawing.Point(81, 3)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 27)
        Me.SimpleButton2.TabIndex = 1
        Me.SimpleButton2.Text = "Save"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.Green
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton1.Location = New System.Drawing.Point(4, 3)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 27)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Add"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton3.Appearance.ForeColor = System.Drawing.Color.Green
        Me.SimpleButton3.Appearance.Options.UseFont = True
        Me.SimpleButton3.Appearance.Options.UseForeColor = True
        Me.SimpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton3.Location = New System.Drawing.Point(158, 3)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(75, 27)
        Me.SimpleButton3.TabIndex = 2
        Me.SimpleButton3.Text = "Delete"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SimpleButton5.Appearance.ForeColor = System.Drawing.Color.Green
        Me.SimpleButton5.Appearance.Options.UseFont = True
        Me.SimpleButton5.Appearance.Options.UseForeColor = True
        Me.SimpleButton5.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SimpleButton5.Location = New System.Drawing.Point(317, 5)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(75, 27)
        Me.SimpleButton5.TabIndex = 0
        Me.SimpleButton5.Text = "Close"
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.EnterMoveNextControl = True
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(159, 132)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Properties.MaxLength = 4
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(229, 20)
        Me.ComboBoxEdit1.TabIndex = 2
        '
        'TextEdit1
        '
        Me.TextEdit1.EnterMoveNextControl = True
        Me.TextEdit1.Location = New System.Drawing.Point(159, 88)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.MaxLength = 10
        Me.TextEdit1.Size = New System.Drawing.Size(229, 20)
        Me.TextEdit1.TabIndex = 0
        '
        'TextEdit2
        '
        Me.TextEdit2.EnterMoveNextControl = True
        Me.TextEdit2.Location = New System.Drawing.Point(159, 110)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.MaxLength = 40
        Me.TextEdit2.Size = New System.Drawing.Size(229, 20)
        Me.TextEdit2.TabIndex = 1
        '
        'FrmMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 619)
        Me.Controls.Add(Me.TextEdit2)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.ComboBoxEdit1)
        Me.Controls.Add(Me.PanelControl6)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BunifuGradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMaterial"
        Me.Text = "FrmMaterial"
        Me.BunifuGradientPanel2.ResumeLayout(False)
        Me.BunifuGradientPanel2.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.PanelControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl6.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WiTHEvents BunifuGradientPanel2 As ns1.BunifuGradientPanel
    Friend WiTHEvents LabelControl89 As DevExpress.XtraEditors.LabelControl
    Friend WiTHEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WiTHEvents Panel10 As Panel
    Friend WiTHEvents LabelControl123 As DevExpress.XtraEditors.LabelControl
    Friend WiTHEvents LabelControl126 As DevExpress.XtraEditors.LabelControl
    Friend WiTHEvents LabelControl128 As DevExpress.XtraEditors.LabelControl
    Friend WiTHEvents PanelControl6 As DevExpress.XtraEditors.PanelControl
    Friend WiTHEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WiTHEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WiTHEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WiTHEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WiTHEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WiTHEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WiTHEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WiTHEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WiTHEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WiTHEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WiTHEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
