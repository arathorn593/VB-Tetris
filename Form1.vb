Option Explicit On


Imports System.Drawing.Graphics
Public Class Tetris

    Const LPiece As Integer = 1         'gives the pieces numbers
    Const JPiece As Integer = 2
    Const LinePiece As Integer = 3
    Const SPiece As Integer = 4
    Const ZPiece As Integer = 5
    Const SquarePiece As Integer = 6
    Const TPiece As Integer = 7

    Dim LPieceBrush As New SolidBrush(Color.Orange)       'gives brushes to pieces
    Dim JPieceBrush As New SolidBrush(Color.Blue)
    Dim LinePieceBrush As New SolidBrush(Color.LightBlue)
    Dim SPieceBrush As New SolidBrush(Color.Green)
    Dim ZPieceBrush As New SolidBrush(Color.Red)
    Dim SquareBrush As New SolidBrush(Color.Yellow)
    Dim TPieceBrush As New SolidBrush(Color.Purple)
    Dim WhiteBrush As New SolidBrush(Color.White)
    Dim blackbrush As New SolidBrush(Color.Black)

    Dim CurrentPiece As Integer = 0
    Dim NextPiece As Integer = 0

    Dim GameSurface As Graphics       'Game surface
    Dim PreviewSurface As Graphics    'preview surface

    Dim Board(19, 9) As Integer         'sets board and variables to set piece
    Dim row1 As Integer
    Dim row2 As Integer
    Dim row3 As Integer
    Dim row4 As Integer
    Dim col1 As Integer
    Dim col2 As Integer
    Dim col3 As Integer
    Dim col4 As Integer

    Dim FallRate As Integer = 500
    Dim Position As Integer = 1
    Dim HaltDrop As Boolean = False
    Dim HaltMove As Boolean = False
    Dim FullRow As Integer = 0
    Dim RowsKilled As Integer = 0
    Dim TopRow As Integer = 0
    Dim SpecificRowsKilled(19) As Integer
    Dim totalrowsKilled As Integer
    Dim score As Double


    Private Sub Tetris_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GameSurface = Me.lblBoard.CreateGraphics 'Game surface
        PreviewSurface = Me.lblPreview.CreateGraphics   'preview surface


        Dim Name As String
        Name = InputBox("Enter your name:", "Name")
        If Name = Nothing Then
            Name = " "
        Else
            Me.Text = Name & "'s Tetris Game" 'Sets the title bar to have the players name
        End If
        My.Computer.Audio.Play(My.Resources._13_Tetris, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub Start_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStart.Click, NewGameToolStripMenuItem.Click
        GameSurface.Clear(Me.lblBoard.BackColor)
        Me.tmrFall.Enabled = True
        Me.tmrFall.Interval = FallRate
        score = 0
        totalrowsKilled = 0

        For row As Integer = 0 To 19
            For col As Integer = 0 To 9
                Board(row, col) = 0
            Next
        Next


        NextPiece = 0
        CurrentPiece = 0

        Randomize()
        NextPiece = CInt(6 * Rnd() + 1)
        CurrentPiece = CInt(6 * Rnd() + 1)

        
        Call SetPreview()
        Call SetBoard()
    End Sub

    Sub SetPreview()
        Dim prevLPoints() As Point = {New Point(25, 25), New Point(100, 25), New Point(100, 50), New Point(50, 50), New Point(50, 75), New Point(25, 75)}
        Dim prevJPoints() As Point = {New Point(25, 25), New Point(100, 25), New Point(100, 75), New Point(75, 75), New Point(75, 50), New Point(25, 50)}
        Dim prevLinePoints() As Point = {New Point(13, 37), New Point(113, 37), New Point(113, 62), New Point(13, 62)}
        Dim prevSpoints() As Point = {New Point(25, 50), New Point(50, 50), New Point(50, 25), New Point(100, 25), New Point(100, 50), New Point(75, 50), New Point(75, 75), New Point(25, 75)}
        Dim prevZPoints() As Point = {New Point(25, 25), New Point(75, 25), New Point(75, 50), New Point(100, 50), New Point(100, 75), New Point(50, 75), New Point(50, 50), New Point(25, 50)}
        Dim prevSquarePoints() As Point = {New Point(37, 25), New Point(87, 25), New Point(87, 75), New Point(37, 75)}
        Dim prevTPoints() As Point = {New Point(25, 25), New Point(100, 25), New Point(100, 50), New Point(75, 50), New Point(75, 75), New Point(50, 75), New Point(50, 50), New Point(25, 50)}
        Dim BlackPen As New Pen(Color.Black, 2)

        Select Case NextPiece                                                   'Draws the preview for the next piece
            Case 1
                PreviewSurface.Clear(Me.lblPreview.BackColor)
                PreviewSurface.FillPolygon(LPieceBrush, prevLPoints)
                PreviewSurface.DrawPolygon(BlackPen, prevLPoints)
                PreviewSurface.DrawLine(BlackPen, 75, 25, 75, 50)
                PreviewSurface.DrawLine(BlackPen, 50, 25, 50, 50)
                PreviewSurface.DrawLine(BlackPen, 25, 50, 50, 50)
            Case 2
                PreviewSurface.Clear(Me.lblPreview.BackColor)
                PreviewSurface.FillPolygon(JPieceBrush, prevJPoints)
                PreviewSurface.DrawPolygon(BlackPen, prevJPoints)
                PreviewSurface.DrawLine(BlackPen, 75, 25, 75, 50)
                PreviewSurface.DrawLine(BlackPen, 50, 25, 50, 50)
                PreviewSurface.DrawLine(BlackPen, 75, 50, 100, 50)
            Case 3
                PreviewSurface.Clear(Me.lblPreview.BackColor)
                PreviewSurface.FillPolygon(LinePieceBrush, prevLinePoints)
                PreviewSurface.DrawPolygon(BlackPen, prevLinePoints)
                PreviewSurface.DrawLine(BlackPen, 37, 37, 37, 62)
                PreviewSurface.DrawLine(BlackPen, 62, 37, 62, 62)
                PreviewSurface.DrawLine(BlackPen, 87, 37, 87, 62)
            Case 4
                PreviewSurface.Clear(Me.lblPreview.BackColor)
                PreviewSurface.FillPolygon(SPieceBrush, prevSpoints)
                PreviewSurface.DrawPolygon(BlackPen, prevSpoints)
                PreviewSurface.DrawLine(BlackPen, 75, 25, 75, 50)
                PreviewSurface.DrawLine(BlackPen, 75, 50, 50, 50)
                PreviewSurface.DrawLine(BlackPen, 50, 50, 50, 75)
            Case 5
                PreviewSurface.Clear(Me.lblPreview.BackColor)
                PreviewSurface.FillPolygon(ZPieceBrush, prevZPoints)
                PreviewSurface.DrawPolygon(BlackPen, prevZPoints)
                PreviewSurface.DrawLine(BlackPen, 50, 25, 50, 50)
                PreviewSurface.DrawLine(BlackPen, 50, 50, 75, 50)
                PreviewSurface.DrawLine(BlackPen, 75, 50, 75, 75)
            Case 6
                PreviewSurface.Clear(Me.lblPreview.BackColor)
                PreviewSurface.FillPolygon(SquareBrush, prevSquarePoints)
                PreviewSurface.DrawPolygon(BlackPen, prevSquarePoints)
                PreviewSurface.DrawLine(BlackPen, 62, 25, 62, 75)
                PreviewSurface.DrawLine(BlackPen, 37, 50, 87, 50)
            Case 7
                PreviewSurface.Clear(Me.lblPreview.BackColor)
                PreviewSurface.FillPolygon(TPieceBrush, prevTPoints)
                PreviewSurface.DrawPolygon(BlackPen, prevTPoints)
                PreviewSurface.DrawLine(BlackPen, 50, 25, 50, 50)
                PreviewSurface.DrawLine(BlackPen, 50, 50, 75, 50)
                PreviewSurface.DrawLine(BlackPen, 75, 50, 75, 25)
            Case Else
                MessageBox.Show("ERROR" & NextPiece)
        End Select

    End Sub

    Sub SetBoard()

        Position = 1
        For col As Integer = 0 To 9
            If Board(0, col) > 0 Then
                Me.tmrFall.Enabled = False
                MessageBox.Show("Game Over" & vbCrLf & "Your Score was " & score)
                Exit Sub

            End If
        Next
        Select Case CurrentPiece
            Case 1
                row1 = 0
                row2 = 0
                row3 = 0
                row4 = 1
                col1 = 3
                col2 = 4
                col3 = 5
                col4 = 3
            Case 2
                row1 = 0
                row2 = 0
                row3 = 0
                row4 = 1
                col1 = 3
                col2 = 4
                col3 = 5
                col4 = 5
            Case 3
                row1 = 0
                row2 = 0
                row3 = 0
                row4 = 0
                col1 = 3
                col2 = 4
                col3 = 5
                col4 = 6
            Case 4
                row1 = 0
                row2 = 0
                row3 = 1
                row4 = 1
                col1 = 5
                col2 = 4
                col3 = 4
                col4 = 3
            Case 5
                row1 = 0
                row2 = 0
                row3 = 1
                row4 = 1
                col1 = 3
                col2 = 4
                col3 = 4
                col4 = 5
            Case 6
                row1 = 0
                row2 = 0
                row3 = 1
                row4 = 1
                col1 = 4
                col2 = 5
                col3 = 4
                col4 = 5
            Case 7
                row1 = 0
                row2 = 0
                row3 = 0
                row4 = 1
                col1 = 3
                col2 = 4
                col3 = 5
                col4 = 4
        End Select

        Board(row1, col1) = CurrentPiece
        Board(row2, col2) = CurrentPiece
        Board(row3, col3) = CurrentPiece
        Board(row4, col4) = CurrentPiece

        Call DrawBoard()


    End Sub

    Sub DrawBoard()
        GameSurface.Clear(Me.lblBoard.BackColor)
        For row As Integer = 0 To 19
            For col As Integer = 0 To 9
                If Board(row, col) > 0 Then

                    Select Case Board(row, col)                         'check if there is a block in that spot and draw it)
                        Case 1
                            GameSurface.FillRectangle(LPieceBrush, (col * 25 + 1), (row * 25 + 1), 23, 23)
                        Case 2
                            GameSurface.FillRectangle(JPieceBrush, (col * 25 + 1), (row * 25 + 1), 23, 23)
                        Case 3
                            GameSurface.FillRectangle(LinePieceBrush, (col * 25 + 1), (row * 25 + 1), 23, 23)
                        Case 4
                            GameSurface.FillRectangle(SPieceBrush, (col * 25 + 1), (row * 25 + 1), 23, 23)
                        Case 5
                            GameSurface.FillRectangle(ZPieceBrush, (col * 25 + 1), (row * 25 + 1), 23, 23)
                        Case 6
                            GameSurface.FillRectangle(SquareBrush, (col * 25 + 1), (row * 25 + 1), 23, 23)
                        Case 7
                            GameSurface.FillRectangle(TPieceBrush, (col * 25 + 1), (row * 25 + 1), 23, 23)
                    End Select
                End If
            Next

        Next
        Me.lblScore.Text = score
        Me.lblLayers.Text = totalrowsKilled
    End Sub

    Private Sub tmrFall_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrFall.Tick

        Call PieceFall()
        If HaltDrop Then
            score += 10
            CurrentPiece = NextPiece
            Randomize()
            NextPiece = CInt(6 * Rnd() + 1)
            Call DeleteRow()
            Call SetPreview()
            Call SetBoard()
        End If
    End Sub
    
    Private Sub BtnLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLeft.Click
        Call MoveLeft()
    End Sub

    Private Sub btnRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRight.Click
        Call MoveRight()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub BtnSoftDrop_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnSoftDrop.MouseDown
        Me.tmrFall.Interval = CInt(FallRate / 3)
    End Sub

    Private Sub BtnSoftDrop_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnSoftDrop.MouseUp
        Me.tmrFall.Interval = FallRate
    End Sub

    Private Sub BtnRotate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRotate.Click
        Call Rotate()
    End Sub

    Private Sub btnHardDrop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHardDrop.Click
        Call HardDrop()
    End Sub

    Sub DeleteRow()
        For row As Integer = 0 To 19
            For col As Integer = 0 To 9
                If Board(row, col) > 0 Then
                    FullRow += 1
                End If
            Next
            If FullRow = 10 Then
                RowsKilled += 1
                totalrowsKilled += 1
                SpecificRowsKilled(row) = 1
                If RowsKilled = 1 Then
                    TopRow = row              'if it is the first row killed set it as top row
                End If
            End If
            FullRow = 0
        Next
        If HaltDrop Then
            If RowsKilled > 0 Then              'if it is not a completed row but others are
                For row As Integer = 0 To 19
                    If SpecificRowsKilled(row) > 0 Then
                        System.Threading.Thread.Sleep(100)
                        GameSurface.FillRectangle(WhiteBrush, 0, (row * 25), 250, 25)
                        System.Threading.Thread.Sleep(100)
                        GameSurface.FillRectangle(blackbrush, 0, (row * 25), 250, 25)
                        System.Threading.Thread.Sleep(100)
                        For col As Integer = 0 To 9
                            Board(row, col) = 0
                        Next
                        For rowCopy As Integer = row - 1 To 0 Step -1
                            For col As Integer = 0 To 9
                                If Board(rowCopy, col) > 0 Then
                                    Board(rowCopy + 1, col) = Board(rowCopy, col)
                                    Board(rowCopy, col) = 0
                                End If
                            Next
                        Next
                    End If

                Next
                For row As Integer = 0 To 19
                    SpecificRowsKilled(row) = 0
                Next
                score += RowsKilled ^ 2 * 100
                RowsKilled = 0
                HaltDrop = False
                Call DrawBoard()
            End If
        End If
    End Sub

    Sub PieceFall()
        If row1 <> 19 And row2 <> 19 And row3 <> 19 And row4 <> 19 Then            'Check if it is at the bottom
            HaltDrop = False
            Select Case CurrentPiece
                Case 1
                    Select Case Position
                        Case 1
                            If Board(row4 + 1, col4) > 0 Or Board(row2 + 1, col2) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 2
                            If Board(row4 + 1, col4) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 3
                            If Board(row1 + 1, col1) > 0 Or Board(row2 + 1, col2) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 4
                            If Board(row4 + 1, col4) > 0 Or Board(row1 + 1, col1) > 0 Then
                                HaltDrop = True
                            End If
                    End Select
                Case 2
                    Select Case Position
                        Case 1
                            If Board(row1 + 1, col1) > 0 Or Board(row2 + 1, col2) > 0 Or Board(row4 + 1, col4) > 0 Then
                                HaltDrop = True
                            End If
                        Case 2
                            If Board(row4 + 1, col4) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 3
                            If Board(row1 + 1, col1) > 0 Or Board(row2 + 1, col2) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 4
                            If Board(row1 + 1, col1) > 0 Or Board(row4 + 1, col4) > 0 Then
                                HaltDrop = True
                            End If
                    End Select
                Case 3
                    Select Case Position
                        Case 1, 3
                            If Board(row1 + 1, col1) > 0 Or Board(row2 + 1, col2) > 0 Or Board(row3 + 1, col3) > 0 Or Board(row4 + 1, col4) > 0 Then
                                HaltDrop = True
                            End If
                        Case 2, 4
                            If Board(row4 + 1, col4) > 0 Then
                                HaltDrop = True
                            End If
                    End Select
                Case 4
                    Select Case Position
                        Case 1, 3
                            If Board(row1 + 1, col1) > 0 Or Board(row4 + 1, col4) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 2, 4
                            If Board(row1 + 1, col1) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                    End Select
                Case 5
                    Select Case Position
                        Case 1, 3
                            If Board(row1 + 1, col1) > 0 Or Board(row4 + 1, col4) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 2, 4
                            If Board(row4 + 1, col4) > 0 Or Board(row2 + 1, col2) > 0 Then
                                HaltDrop = True
                            End If
                    End Select
                Case 6
                    If Board(row4 + 1, col4) > 0 Or Board(row3 + 1, col3) > 0 Then
                        HaltDrop = True
                    End If
                Case 7
                    Select Case Position
                        Case 1
                            If Board(row1 + 1, col1) > 0 Or Board(row4 + 1, col4) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 2
                            If Board(row4 + 1, col4) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 3
                            If Board(row1 + 1, col1) > 0 Or Board(row2 + 1, col2) > 0 Or Board(row3 + 1, col3) > 0 Then
                                HaltDrop = True
                            End If
                        Case 4
                            If Board(row1 + 1, col1) > 0 Or Board(row4 + 1, col4) > 0 Then
                                HaltDrop = True
                            End If
                    End Select
            End Select
        Else
            HaltDrop = True
        End If


        If Not HaltDrop Then
            Board(row1, col1) = 0                                                   'Move the piece down
            Board(row2, col2) = 0
            Board(row3, col3) = 0
            Board(row4, col4) = 0
            row1 += 1
            row2 += 1
            row3 += 1
            row4 += 1
            Board(row1, col1) = CurrentPiece
            Board(row2, col2) = CurrentPiece
            Board(row3, col3) = CurrentPiece
            Board(row4, col4) = CurrentPiece
            Call DrawBoard()
        End If
    End Sub

    Private Sub Tetris_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Left) Then
            Call MoveLeft()
        ElseIf e.KeyChar = ChrW(Keys.Right) Then
            Call MoveRight()
        ElseIf e.KeyChar = ChrW(Keys.Space) Then
            Call HardDrop()
        ElseIf e.KeyChar = ChrW(Keys.Up) Then
            Call Rotate()
        End If
    End Sub

    Sub MoveLeft()
        If col1 <> 0 And col2 <> 0 And col3 <> 0 And col4 <> 0 Then
            HaltMove = False
            Select Case CurrentPiece
                Case 1
                    Select Case Position
                        Case 1
                            If Board(row4, col4 - 1) > 0 Or Board(row1, col1 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2
                            If Board(row4, col4 - 1) > 0 Or Board(row3, col3 - 1) > 0 Or Board(row2, col2 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 3
                            If Board(row4, col4 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 4
                            If Board(row1, col1 - 1) > 0 Or Board(row2, col2 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 2
                    Select Case Position
                        Case 1
                            If Board(row1, col1 - 1) > 0 Or Board(row4, col4 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2
                            If Board(row4, col4 - 1) > 0 Or Board(row2, col2 - 1) > 0 Or Board(row1, col1 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 3
                            If Board(row4, col4 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 4
                            If Board(row1, col1 - 1) > 0 Or Board(row2, col2 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 3
                    Select Case Position
                        Case 1, 3
                            If Board(row1, col1 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2, 4
                            If Board(row1, col1 - 1) > 0 Or Board(row2, col2 - 1) > 0 Or Board(row3, col3 - 1) > 0 Or Board(row4, col4 - 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 4
                    Select Case Position
                        Case 1, 3
                            If Board(row2, col2 - 1) > 0 Or Board(row4, col4 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2, 4
                            If Board(row1, col1 - 1) > 0 Or Board(row3, col3 - 1) > 0 Or Board(row4, col4 - 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 5
                    Select Case Position
                        Case 1, 3
                            If Board(row1, col1 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2, 4
                            If Board(row4, col4 - 1) > 0 Or Board(row1, col1 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 6
                    If Board(row1, col1 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                        HaltMove = True
                    End If
                Case 7
                    Select Case Position
                        Case 1
                            If Board(row1, col1 - 1) > 0 Or Board(row4, col4 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2
                            If Board(row4, col4 - 1) > 0 Or Board(row1, col1 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 3
                            If Board(row4, col4 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 4
                            If Board(row1, col1 - 1) > 0 Or Board(row2, col2 - 1) > 0 Or Board(row3, col3 - 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
            End Select
        Else
            HaltMove = True
        End If
        If Not HaltMove Then
            Board(row1, col1) = 0                                                   'reset the piece and move it left if room
            Board(row2, col2) = 0
            Board(row3, col3) = 0
            Board(row4, col4) = 0
            col1 -= 1
            col2 -= 1
            col3 -= 1
            col4 -= 1
            Board(row1, col1) = CurrentPiece
            Board(row2, col2) = CurrentPiece
            Board(row3, col3) = CurrentPiece
            Board(row4, col4) = CurrentPiece
            Call DrawBoard()
        End If
    End Sub

    Sub MoveRight()
        If col1 <> 9 And col2 <> 9 And col3 <> 9 And col4 <> 9 Then
            HaltMove = False
            Select Case CurrentPiece
                Case 1
                    Select Case Position
                        Case 1
                            If Board(row4, col4 + 1) > 0 Or Board(row3, col3 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2
                            If Board(row1, col1 + 1) > 0 Or Board(row3, col3 + 1) > 0 Or Board(row2, col2 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 3
                            If Board(row4, col4 + 1) > 0 Or Board(row1, col1 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 4
                            If Board(row4, col4 + 1) > 0 Or Board(row2, col2 + 1) > 0 Or Board(row3, col3 + 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 2
                    Select Case Position
                        Case 1
                            If Board(row3, col3 + 1) > 0 Or Board(row4, col4 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2
                            If Board(row3, col3 + 1) > 0 Or Board(row2, col2 + 1) > 0 Or Board(row1, col1 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 3
                            If Board(row4, col4 + 1) > 0 Or Board(row1, col1 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 4
                            If Board(row1, col1 + 1) > 0 Or Board(row2, col2 + 1) > 0 Or Board(row4, col4 + 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 3
                    Select Case Position
                        Case 1, 3
                            If Board(row4, col4 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2, 4
                            If Board(row1, col1 + 1) > 0 Or Board(row2, col2 + 1) > 0 Or Board(row3, col3 + 1) > 0 Or Board(row4, col4 + 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 4
                    Select Case Position
                        Case 1, 3
                            If Board(row1, col1 + 1) > 0 Or Board(row3, col3 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2, 4
                            If Board(row2, col2 + 1) > 0 Or Board(row1, col1 + 1) > 0 Or Board(row4, col4 + 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 5
                    Select Case Position
                        Case 1, 3
                            If Board(row2, col2 + 1) > 0 Or Board(row4, col4 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2, 4
                            If Board(row4, col4 + 1) > 0 Or Board(row1, col1 + 1) > 0 Or Board(row2, col2 + 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
                Case 6
                    If Board(row2, col2 + 1) > 0 Or Board(row4, col4 + 1) > 0 Then
                        HaltMove = True
                    End If
                Case 7
                    Select Case Position
                        Case 1
                            If Board(row3, col3 + 1) > 0 Or Board(row4, col4 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 2
                            If Board(row2, col2 + 1) > 0 Or Board(row1, col1 + 1) > 0 Or Board(row3, col3 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 3
                            If Board(row4, col4 + 1) > 0 Or Board(row1, col1 + 1) > 0 Then
                                HaltMove = True
                            End If
                        Case 4
                            If Board(row1, col1 + 1) > 0 Or Board(row4, col4 + 1) > 0 Or Board(row3, col3 + 1) > 0 Then
                                HaltMove = True
                            End If
                    End Select
            End Select
        Else
            HaltMove = True
        End If

        If Not HaltMove Then
            Board(row1, col1) = 0                                                   'reset and move right if room
            Board(row2, col2) = 0
            Board(row3, col3) = 0
            Board(row4, col4) = 0
            col1 += 1
            col2 += 1
            col3 += 1
            col4 += 1
            Board(row1, col1) = CurrentPiece
            Board(row2, col2) = CurrentPiece
            Board(row3, col3) = CurrentPiece
            Board(row4, col4) = CurrentPiece
            Call DrawBoard()
        End If
    End Sub

    Sub HardDrop()
        Do While HaltDrop = False
            Call PieceFall()
        Loop
        Call DrawBoard()
    End Sub

    Sub Rotate()
        Dim tempRow1 As Integer = row1
        Dim tempRow3 As Integer = row3
        Dim tempRow4 As Integer = row4
        Dim tempCol1 As Integer = col1
        Dim tempCol3 As Integer = col3
        Dim tempCol4 As Integer = col4



        Select Case CurrentPiece
            Case 1
                Select Case Position
                    Case 1
                        tempRow1 = row2 - 1
                        tempCol1 = col2
                        tempRow3 = row2 + 1
                        tempCol3 = col2
                        tempRow4 = row2 - 1
                        tempCol4 = col2 - 1
                    Case 2
                        tempRow1 = row2
                        tempCol1 = col2 + 1
                        tempRow3 = row2
                        tempCol3 = col2 - 1
                        tempRow4 = row2 - 1
                        tempCol4 = col2 + 1
                    Case 3
                        tempRow1 = row2 + 1
                        tempCol1 = col2
                        tempRow3 = row2 - 1
                        tempCol3 = col2
                        tempRow4 = row2 + 1
                        tempCol4 = col2 + 1
                    Case 4
                        tempRow1 = row2
                        tempCol1 = col2 - 1
                        tempRow3 = row2
                        tempCol3 = col2 + 1
                        tempRow4 = row2 + 1
                        tempCol4 = col2 - 1
                End Select
            Case 2
                Select Case Position
                    Case 1
                        tempRow1 = row2 - 1
                        tempCol1 = col2
                        tempRow3 = row2 + 1
                        tempCol3 = col2
                        tempRow4 = row2 + 1
                        tempCol4 = col2 - 1
                    Case 2
                        tempRow1 = row2
                        tempCol1 = col2 + 1
                        tempRow3 = row2
                        tempCol3 = col2 - 1
                        tempRow4 = row2 - 1
                        tempCol4 = col2 - 1
                    Case 3
                        tempRow1 = row2 + 1
                        tempCol1 = col2
                        tempRow3 = row2 - 1
                        tempCol3 = col2
                        tempRow4 = row2 - 1
                        tempCol4 = col2 + 1
                    Case 4
                        tempRow1 = row2
                        tempCol1 = col2 - 1
                        tempRow3 = row2
                        tempCol3 = col2 + 1
                        tempRow4 = row2 + 1
                        tempCol4 = col2 + 1
                    Case 3
                End Select

            Case 3
                Select Case Position
                    Case 1, 3
                        tempRow1 = row2 - 1
                        tempCol1 = col2
                        tempRow3 = row2 + 1
                        tempCol3 = col2
                        tempRow4 = row2 + 2
                        tempCol4 = col2
                    Case 2, 4
                        tempRow1 = row2
                        tempCol1 = col2 - 1
                        tempRow3 = row2
                        tempCol3 = col2 + 1
                        tempRow4 = row2
                        tempCol4 = col2 + 2
                End Select
            Case 4
                Select Case Position
                    Case 1, 3
                        tempRow1 = row2 + 1
                        tempCol1 = col2
                        tempRow3 = row2
                        tempCol3 = col2 - 1
                        tempRow4 = row2 - 1
                        tempCol4 = col2 - 1
                    Case 2, 4
                        tempRow1 = row2
                        tempCol1 = col2 + 1
                        tempRow3 = row2 + 1
                        tempCol3 = col2
                        tempRow4 += 2

                End Select
            Case 5
                Select Case Position
                    Case 1, 3
                        tempRow1 = row2 - 1
                        tempCol1 = col2
                        tempRow3 = row2
                        tempCol3 = col2 - 1
                        tempRow4 = row2 + 1
                        tempCol4 = col2 - 1
                    Case 2, 4
                        tempRow1 = row2
                        tempCol1 = col2 - 1
                        tempRow3 = row2 + 1
                        tempCol3 = col2
                        tempRow4 = row2 + 1
                        tempCol4 = col2 + 1
                End Select
            Case 7
                Select Case Position
                    Case 1
                        tempRow1 = row2 - 1
                        tempCol1 = col2
                        tempRow3 = row2 + 1
                        tempCol3 = col2
                        tempRow4 = row2
                        tempCol4 = col2 - 1
                    Case 2
                        tempRow1 = row2
                        tempCol1 = col2 + 1
                        tempRow3 = row2
                        tempCol3 = col2 - 1
                        tempRow4 = row2 - 1
                        tempCol4 = col2
                    Case 3
                        tempRow1 = row2 + 1
                        tempCol1 = col2
                        tempRow3 = row2 - 1
                        tempCol3 = col2
                        tempRow4 = row2
                        tempCol4 = col2 + 1
                    Case 4
                        tempRow1 = row2
                        tempCol1 = col2 - 1
                        tempRow3 = row2
                        tempCol3 = col2 + 1
                        tempRow4 = row2 + 1
                        tempCol4 = col2
                End Select
        End Select

        If tempRow1 < 19 And tempRow1 > 0 And tempRow3 < 19 And tempRow3 > 0 And tempRow4 < 19 And tempRow4 > 0 And _
        tempCol1 < 9 And tempCol1 > 0 And tempCol3 < 9 And tempCol3 > 0 And tempCol4 < 9 And tempCol4 > 0 Then
            If (Board(tempRow1, tempCol1) = 0 Or Board(tempRow1, tempCol1) = CurrentPiece) And _
            (Board(tempRow3, tempCol3) = 0 Or Board(tempRow3, tempCol3) = CurrentPiece) And _
            (Board(tempRow4, tempCol4) = 0 Or Board(tempRow4, tempCol4) = CurrentPiece) Then
                Board(row1, col1) = 0
                Board(row3, col3) = 0
                Board(row4, col4) = 0
                row1 = tempRow1                                         'if it is still in bounds set it
                row3 = tempRow3
                row4 = tempRow4
                col1 = tempCol1
                col3 = tempCol3
                col4 = tempCol4
                Board(row1, col1) = CurrentPiece
                Board(row3, col3) = CurrentPiece
                Board(row4, col4) = CurrentPiece
                If Position < 4 Then
                    Position += 1
                Else
                    Position = 1
                End If
            End If

        End If

        Call DrawBoard()
    End Sub

    Private Sub Tetris_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Down Then
            Me.tmrFall.Interval = FallRate
        End If
    End Sub

    Private Sub Tetris_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Down Then
            Me.tmrFall.Interval = 100
        End If
    End Sub

    Private Sub radLevel1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLevel1.CheckedChanged
        FallRate = 500
        Me.tmrFall.Interval = FallRate
    End Sub

    Private Sub radLevel2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLevel2.CheckedChanged
        FallRate = 375
        Me.tmrFall.Interval = FallRate
    End Sub

    Private Sub radLevel3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLevel3.CheckedChanged
        FallRate = 200
        Me.tmrFall.Interval = FallRate
    End Sub

    Private Sub btnMusic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMusic.Click
        Static State As Integer = 0
        If State = 0 Then
            Me.btnMusic.BackgroundImage = My.Resources.Mute
            My.Computer.Audio.Stop()
        Else
            Me.btnMusic.BackgroundImage = My.Resources._500px_Speaker_Icon_svg
            My.Computer.Audio.Play(My.Resources._13_Tetris, AudioPlayMode.BackgroundLoop)
        End If
        State = 1 - State
    End Sub

    Private Sub InstructionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstructionsToolStripMenuItem.Click
        Static state As Integer = 0
        If state = 0 Then
            Me.lblInstructions.Visible = False
            Me.InstructionsToolStripMenuItem.Checked = False
        Else
            Me.lblInstructions.Visible = True
            Me.InstructionsToolStripMenuItem.Checked = True
        End If
        state = 1 - state
    End Sub

    Private Sub ScoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScoreToolStripMenuItem.Click
        Static state As Integer = 0
        If state = 0 Then
            Me.lblScore.Visible = False
            Me.lblScoreLable.Visible = False
            Me.ScoreToolStripMenuItem.Checked = False
        Else
            Me.lblScore.Visible = True
            Me.lblScoreLable.Visible = True
            Me.ScoreToolStripMenuItem.Checked = True
        End If
        state = 1 - state
    End Sub

    Private Sub LayersDestroyedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayersDestroyedToolStripMenuItem.Click
        Static state As Integer = 0
        If state = 0 Then
            Me.lblLayers.Visible = False
            Me.lblLayersLable.Visible = False
            Me.LayersDestroyedToolStripMenuItem.Checked = False
        Else
            Me.lblLayers.Visible = True
            Me.lblLayersLable.Visible = True
            Me.LayersDestroyedToolStripMenuItem.Checked = True
        End If
        state = 1 - state
    End Sub

    Private Sub TilePreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TilePreviewToolStripMenuItem.Click
        Static state As Integer = 0
        If state = 0 Then
            Me.lblPreviewPrompt.Visible = False
            Me.lblPreview.Visible = False
            Me.TilePreviewToolStripMenuItem.Checked = False
        Else
            Me.lblPreviewPrompt.Visible = True
            Me.lblPreview.Visible = True
            Me.TilePreviewToolStripMenuItem.Checked = True
        End If
        state = 1 - state
    End Sub

    
    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        Static state As Integer = 0
        If state = 0 Then
            Me.tmrFall.Stop()
            Me.btnPause.BackgroundImage = My.Resources.play
        Else
            Me.tmrFall.Start()
            Me.btnPause.BackgroundImage = My.Resources.untitled
        End If
        state = 1 - state
    End Sub
End Class
