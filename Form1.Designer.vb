<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tetris
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InstructionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ScoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LayersDestroyedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TilePreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lblBoard = New System.Windows.Forms.Label
        Me.lblPreviewPrompt = New System.Windows.Forms.Label
        Me.lblPreview = New System.Windows.Forms.Label
        Me.lblLayersLable = New System.Windows.Forms.Label
        Me.lblLayers = New System.Windows.Forms.Label
        Me.lblScoreLable = New System.Windows.Forms.Label
        Me.lblScore = New System.Windows.Forms.Label
        Me.lblInstructions = New System.Windows.Forms.Label
        Me.BtnSoftDrop = New System.Windows.Forms.Button
        Me.btnHardDrop = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.tmrFall = New System.Windows.Forms.Timer(Me.components)
        Me.grpLevel = New System.Windows.Forms.GroupBox
        Me.radLevel3 = New System.Windows.Forms.RadioButton
        Me.radLevel2 = New System.Windows.Forms.RadioButton
        Me.radLevel1 = New System.Windows.Forms.RadioButton
        Me.btnPause = New System.Windows.Forms.Button
        Me.btnMusic = New System.Windows.Forms.Button
        Me.BtnRotate = New System.Windows.Forms.Button
        Me.btnRight = New System.Windows.Forms.Button
        Me.BtnLeft = New System.Windows.Forms.Button
        Me.MnuMain.SuspendLayout()
        Me.grpLevel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.BackColor = System.Drawing.Color.PaleGreen
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(433, 24)
        Me.MnuMain.TabIndex = 0
        Me.MnuMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.NewGameToolStripMenuItem.Text = "New Game"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstructionsToolStripMenuItem, Me.ScoreToolStripMenuItem, Me.LayersDestroyedToolStripMenuItem, Me.TilePreviewToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'InstructionsToolStripMenuItem
        '
        Me.InstructionsToolStripMenuItem.Checked = True
        Me.InstructionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem"
        Me.InstructionsToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.InstructionsToolStripMenuItem.Text = "Instructions"
        '
        'ScoreToolStripMenuItem
        '
        Me.ScoreToolStripMenuItem.Checked = True
        Me.ScoreToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ScoreToolStripMenuItem.Name = "ScoreToolStripMenuItem"
        Me.ScoreToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.ScoreToolStripMenuItem.Text = "Score"
        '
        'LayersDestroyedToolStripMenuItem
        '
        Me.LayersDestroyedToolStripMenuItem.Checked = True
        Me.LayersDestroyedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LayersDestroyedToolStripMenuItem.Name = "LayersDestroyedToolStripMenuItem"
        Me.LayersDestroyedToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.LayersDestroyedToolStripMenuItem.Text = "Layers Destroyed"
        '
        'TilePreviewToolStripMenuItem
        '
        Me.TilePreviewToolStripMenuItem.Checked = True
        Me.TilePreviewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TilePreviewToolStripMenuItem.Name = "TilePreviewToolStripMenuItem"
        Me.TilePreviewToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.TilePreviewToolStripMenuItem.Text = "Piece Preview"
        '
        'lblBoard
        '
        Me.lblBoard.BackColor = System.Drawing.Color.Black
        Me.lblBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBoard.Location = New System.Drawing.Point(24, 36)
        Me.lblBoard.Name = "lblBoard"
        Me.lblBoard.Size = New System.Drawing.Size(250, 500)
        Me.lblBoard.TabIndex = 1
        '
        'lblPreviewPrompt
        '
        Me.lblPreviewPrompt.AutoSize = True
        Me.lblPreviewPrompt.Font = New System.Drawing.Font("Copperplate Gothic Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreviewPrompt.Location = New System.Drawing.Point(280, 36)
        Me.lblPreviewPrompt.Name = "lblPreviewPrompt"
        Me.lblPreviewPrompt.Size = New System.Drawing.Size(67, 14)
        Me.lblPreviewPrompt.TabIndex = 2
        Me.lblPreviewPrompt.Text = "Preview:"
        '
        'lblPreview
        '
        Me.lblPreview.BackColor = System.Drawing.SystemColors.ControlText
        Me.lblPreview.Location = New System.Drawing.Point(284, 55)
        Me.lblPreview.Name = "lblPreview"
        Me.lblPreview.Size = New System.Drawing.Size(125, 100)
        Me.lblPreview.TabIndex = 3
        '
        'lblLayersLable
        '
        Me.lblLayersLable.AutoSize = True
        Me.lblLayersLable.Font = New System.Drawing.Font("Copperplate Gothic Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLayersLable.Location = New System.Drawing.Point(284, 155)
        Me.lblLayersLable.Name = "lblLayersLable"
        Me.lblLayersLable.Size = New System.Drawing.Size(132, 14)
        Me.lblLayersLable.TabIndex = 4
        Me.lblLayersLable.Text = "Layers Destroyed:"
        '
        'lblLayers
        '
        Me.lblLayers.AutoSize = True
        Me.lblLayers.Font = New System.Drawing.Font("Copperplate Gothic Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLayers.Location = New System.Drawing.Point(284, 169)
        Me.lblLayers.Name = "lblLayers"
        Me.lblLayers.Size = New System.Drawing.Size(16, 14)
        Me.lblLayers.TabIndex = 5
        Me.lblLayers.Text = "0"
        '
        'lblScoreLable
        '
        Me.lblScoreLable.AutoSize = True
        Me.lblScoreLable.Font = New System.Drawing.Font("Copperplate Gothic Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScoreLable.Location = New System.Drawing.Point(284, 192)
        Me.lblScoreLable.Name = "lblScoreLable"
        Me.lblScoreLable.Size = New System.Drawing.Size(53, 14)
        Me.lblScoreLable.TabIndex = 6
        Me.lblScoreLable.Text = "Score:"
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("Copperplate Gothic Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.Location = New System.Drawing.Point(343, 192)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(16, 14)
        Me.lblScore.TabIndex = 7
        Me.lblScore.Text = "0"
        '
        'lblInstructions
        '
        Me.lblInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstructions.Location = New System.Drawing.Point(284, 206)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(137, 108)
        Me.lblInstructions.TabIndex = 8
        Me.lblInstructions.Text = "Instructions: Use the arrow buttons to move the piece side to side, the Rotate bu" & _
            "tton to rotate the piece, the soft drop button to speed up the fall, and the har" & _
            "d drop button to drop the piece."
        '
        'BtnSoftDrop
        '
        Me.BtnSoftDrop.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSoftDrop.Location = New System.Drawing.Point(283, 358)
        Me.BtnSoftDrop.Name = "BtnSoftDrop"
        Me.BtnSoftDrop.Size = New System.Drawing.Size(43, 38)
        Me.BtnSoftDrop.TabIndex = 12
        Me.BtnSoftDrop.Text = "Soft Drop"
        Me.BtnSoftDrop.UseVisualStyleBackColor = True
        '
        'btnHardDrop
        '
        Me.btnHardDrop.Location = New System.Drawing.Point(386, 359)
        Me.btnHardDrop.Name = "btnHardDrop"
        Me.btnHardDrop.Size = New System.Drawing.Size(43, 38)
        Me.btnHardDrop.TabIndex = 13
        Me.btnHardDrop.Text = "Hard Drop"
        Me.btnHardDrop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Copperplate Gothic Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnStart.Location = New System.Drawing.Point(283, 402)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(146, 43)
        Me.btnStart.TabIndex = 14
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'tmrFall
        '
        Me.tmrFall.Enabled = True
        Me.tmrFall.Interval = 500
        '
        'grpLevel
        '
        Me.grpLevel.Controls.Add(Me.radLevel3)
        Me.grpLevel.Controls.Add(Me.radLevel2)
        Me.grpLevel.Controls.Add(Me.radLevel1)
        Me.grpLevel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpLevel.Location = New System.Drawing.Point(287, 448)
        Me.grpLevel.Name = "grpLevel"
        Me.grpLevel.Size = New System.Drawing.Size(90, 87)
        Me.grpLevel.TabIndex = 15
        Me.grpLevel.TabStop = False
        Me.grpLevel.Text = "Level"
        '
        'radLevel3
        '
        Me.radLevel3.AutoSize = True
        Me.radLevel3.Location = New System.Drawing.Point(16, 65)
        Me.radLevel3.Name = "radLevel3"
        Me.radLevel3.Size = New System.Drawing.Size(60, 17)
        Me.radLevel3.TabIndex = 2
        Me.radLevel3.Text = "Level 3"
        Me.radLevel3.UseVisualStyleBackColor = True
        '
        'radLevel2
        '
        Me.radLevel2.AutoSize = True
        Me.radLevel2.Location = New System.Drawing.Point(16, 42)
        Me.radLevel2.Name = "radLevel2"
        Me.radLevel2.Size = New System.Drawing.Size(60, 17)
        Me.radLevel2.TabIndex = 1
        Me.radLevel2.Text = "Level 2"
        Me.radLevel2.UseVisualStyleBackColor = True
        '
        'radLevel1
        '
        Me.radLevel1.AutoSize = True
        Me.radLevel1.Checked = True
        Me.radLevel1.Location = New System.Drawing.Point(16, 19)
        Me.radLevel1.Name = "radLevel1"
        Me.radLevel1.Size = New System.Drawing.Size(60, 17)
        Me.radLevel1.TabIndex = 0
        Me.radLevel1.TabStop = True
        Me.radLevel1.Text = "Level 1"
        Me.radLevel1.UseVisualStyleBackColor = True
        '
        'btnPause
        '
        Me.btnPause.BackgroundImage = Global.FinalProject.My.Resources.Resources.untitled
        Me.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPause.Location = New System.Drawing.Point(388, 458)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(33, 34)
        Me.btnPause.TabIndex = 17
        Me.btnPause.UseVisualStyleBackColor = True
        '
        'btnMusic
        '
        Me.btnMusic.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnMusic.BackgroundImage = Global.FinalProject.My.Resources.Resources._500px_Speaker_Icon_svg
        Me.btnMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMusic.Location = New System.Drawing.Point(388, 501)
        Me.btnMusic.Name = "btnMusic"
        Me.btnMusic.Size = New System.Drawing.Size(33, 34)
        Me.btnMusic.TabIndex = 16
        Me.btnMusic.UseVisualStyleBackColor = False
        '
        'BtnRotate
        '
        Me.BtnRotate.BackgroundImage = Global.FinalProject.My.Resources.Resources.arrow_black_gloss_clockwise
        Me.BtnRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRotate.Location = New System.Drawing.Point(330, 317)
        Me.BtnRotate.Name = "BtnRotate"
        Me.BtnRotate.Size = New System.Drawing.Size(52, 52)
        Me.BtnRotate.TabIndex = 11
        Me.BtnRotate.UseVisualStyleBackColor = True
        '
        'btnRight
        '
        Me.btnRight.BackgroundImage = Global.FinalProject.My.Resources.Resources.imgres
        Me.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRight.Location = New System.Drawing.Point(388, 317)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(41, 36)
        Me.btnRight.TabIndex = 10
        Me.btnRight.Tag = "Right"
        Me.btnRight.UseVisualStyleBackColor = True
        '
        'BtnLeft
        '
        Me.BtnLeft.BackgroundImage = Global.FinalProject.My.Resources.Resources.left_arrow
        Me.BtnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnLeft.Location = New System.Drawing.Point(283, 316)
        Me.BtnLeft.Name = "BtnLeft"
        Me.BtnLeft.Size = New System.Drawing.Size(39, 36)
        Me.BtnLeft.TabIndex = 9
        Me.BtnLeft.Tag = "Left"
        Me.BtnLeft.UseVisualStyleBackColor = True
        '
        'Tetris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(433, 547)
        Me.Controls.Add(Me.btnPause)
        Me.Controls.Add(Me.btnMusic)
        Me.Controls.Add(Me.grpLevel)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnHardDrop)
        Me.Controls.Add(Me.BtnSoftDrop)
        Me.Controls.Add(Me.BtnRotate)
        Me.Controls.Add(Me.btnRight)
        Me.Controls.Add(Me.BtnLeft)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.lblScoreLable)
        Me.Controls.Add(Me.lblLayers)
        Me.Controls.Add(Me.lblLayersLable)
        Me.Controls.Add(Me.lblPreview)
        Me.Controls.Add(Me.lblPreviewPrompt)
        Me.Controls.Add(Me.lblBoard)
        Me.Controls.Add(Me.MnuMain)
        Me.MainMenuStrip = Me.MnuMain
        Me.Name = "Tetris"
        Me.Text = "Tetris"
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.grpLevel.ResumeLayout(False)
        Me.grpLevel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstructionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LayersDestroyedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TilePreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblBoard As System.Windows.Forms.Label
    Friend WithEvents lblPreviewPrompt As System.Windows.Forms.Label
    Friend WithEvents lblPreview As System.Windows.Forms.Label
    Friend WithEvents lblLayersLable As System.Windows.Forms.Label
    Friend WithEvents lblLayers As System.Windows.Forms.Label
    Friend WithEvents lblScoreLable As System.Windows.Forms.Label
    Friend WithEvents lblScore As System.Windows.Forms.Label
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents BtnLeft As System.Windows.Forms.Button
    Friend WithEvents btnRight As System.Windows.Forms.Button
    Friend WithEvents BtnRotate As System.Windows.Forms.Button
    Friend WithEvents BtnSoftDrop As System.Windows.Forms.Button
    Friend WithEvents btnHardDrop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents tmrFall As System.Windows.Forms.Timer
    Friend WithEvents grpLevel As System.Windows.Forms.GroupBox
    Friend WithEvents radLevel3 As System.Windows.Forms.RadioButton
    Friend WithEvents radLevel2 As System.Windows.Forms.RadioButton
    Friend WithEvents radLevel1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnMusic As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button

End Class
