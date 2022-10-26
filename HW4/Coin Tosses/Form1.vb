Public Class Form1

    Private Bitmap As Bitmap
    Private Graphics As Graphics
    Private rand As Random = New Random()
    Private PenAbso As Pen = New Pen(Color.LightGreen, 2)
    Private PenRel As Pen = New Pen(Color.Red, 2)
    Private PenNorm As Pen = New Pen(Color.Blue, 2)

    Private Function tranX(ByVal x As Double, ByVal minX As Double, ByVal maxX As Double, ByVal w As Integer) As Integer
        Return CInt((w * (x - minX) / (maxX - minX)))
    End Function

    Private Function tranY(ByVal y As Double, ByVal minY As Double, ByVal maxY As Double, ByVal h As Integer) As Integer
        Return CInt((h - h * (y - minY) / (maxY - minY)))
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Bitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Graphics = Graphics.FromImage(Bitmap)
        Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        Graphics.Clear(Color.Black)
        Dim trials = TrackBar1.Value
        Dim trajectories = TrackBar2.Value
        Dim rectangle = New Rectangle(20, 20, Bitmap.Width, Bitmap.Height)
        Graphics.FillRectangle(Brushes.Black, rectangle)
        Graphics.DrawRectangle(Pens.Black, rectangle)
        RichTextBox1.Clear()

        'AbsoluteG
        Dim minX_a As Double = 0
        Dim maxX_a As Double = CDbl(trials)
        Dim minY_a As Double = 0
        Dim maxY_a As Double = CDbl(trials)
        'Relative
        Dim minX_r As Double = 0
        Dim maxX_r As Double = CDbl(trials)
        Dim minY_r As Double = 0
        Dim maxY_r As Double = 1
        'Normalized
        Dim minX_n As Double = 0
        Dim maxX_n As Double = CDbl(trials)
        Dim minY_n As Double = 0
        Dim maxY_n As Double = CDbl(trials) / Math.Sqrt(CDbl(trials))
        For traj_num As Integer = 0 To trajectories - 1
            Dim y_a As Double = 0
            Dim y_r As Double = 0
            Dim y_n As Double = 0
            Dim points_a As List(Of Point) = New List(Of Point)
            Dim points_r As List(Of Point) = New List(Of Point)
            Dim points_n As List(Of Point) = New List(Of Point)
            For tria_num As Integer = 0 To trials - 1
                If rand.Next(0, 2) > 0 Then
                    y_a = y_a + 1
                End If
                'Absolute
                Dim cord_x_a As Integer = tranX(tria_num, minX_a, maxX_a, rectangle.Width)
                Dim cord_y_a As Integer = tranY(y_a, minY_a, maxY_a, rectangle.Height)
                Dim p_a As Point = New Point(cord_x_a, cord_y_a)
                points_a.Add(p_a)
                RichTextBox1.AppendText(tria_num.ToString & ": " & y_a)
                RichTextBox1.AppendText(Environment.NewLine)
                'Relative
                y_r = y_a / (tria_num + 1)
                Dim cord_x_r As Integer = tranX(tria_num, minX_r, maxX_r, rectangle.Width)
                Dim cord_y_r As Integer = tranY(y_r, minY_r, maxY_r, rectangle.Height)
                Dim p_r As Point = New Point(cord_x_r, cord_y_r)
                points_r.Add(p_r)
                'Normalized
                y_n = y_a / Math.Sqrt(tria_num + 1)
                Dim cord_x_n As Integer = tranX(tria_num, minX_n, maxX_n, rectangle.Width)
                Dim cord_y_n As Integer = tranY(y_n, minY_n, maxY_n, rectangle.Height)
                Dim p_n As Point = New Point(cord_x_n, cord_y_n)
                points_n.Add(p_n)
            Next
            Graphics.DrawLines(PenAbso, points_a.ToArray)
            Graphics.DrawLines(PenRel, points_r.ToArray)
            Graphics.DrawLines(PenNorm, points_n.ToArray)
        Next
        PictureBox1.Image = Bitmap
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label1.Text = "Trials: " & TrackBar1.Value.ToString
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Label2.Text = "Trajectories: " & TrackBar2.Value.ToString
    End Sub
End Class
