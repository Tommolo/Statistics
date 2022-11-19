Public Class Form1

    Private Bitmap As Bitmap
    Private Graphics As Graphics
    Private Bitmap2 As Bitmap
    Private Graphics2 As Graphics
    Private rand As Random = New Random()
    Private PenAbso As Pen = New Pen(Color.LightGreen, 2)
    Dim interarrivals As List(Of Integer)
    Dim interarrivals_distribution_dictionary As SortedDictionary(Of Integer, Integer)


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
        Dim lambda = TrackBar3.Value
        interarrivals = New List(Of Integer)
        Dim count_interarrivals = 0
        Dim rectangle = New Rectangle(20, 20, Bitmap.Width, Bitmap.Height)
        'Graphics.FillRectangle(Brushes.Black, rectangle)
        'Graphics.DrawRectangle(Pens.Black, rectangle)
        RichTextBox1.Clear()

        Dim probability As Double = (lambda / trials) * 100
        RichTextBox1.AppendText("probability: " & probability)
        RichTextBox1.AppendText(Environment.NewLine)


        Dim minX_a As Double = 0
        Dim maxX_a As Double = CDbl(trials)
        Dim minY_a As Double = 0
        Dim maxY_a As Double = CDbl(trials)


        Dim y_a As Double = 0
        Dim points_a As List(Of Point) = New List(Of Point)
        For tria_num As Integer = 0 To trials - 1
            Dim random_number = rand.Next(0, 100)
            If random_number <= probability Then
                y_a = y_a + 1
                interarrivals.Add(count_interarrivals)
                count_interarrivals = 0
            Else
                count_interarrivals = count_interarrivals + 1
            End If
            'Absolute
            Dim cord_x_a As Integer = tranX(tria_num, minX_a, maxX_a, rectangle.Width)
            Dim cord_y_a As Integer = tranY(y_a, minY_a, maxY_a, rectangle.Height)
            Dim p_a As Point = New Point(cord_x_a, cord_y_a)
            points_a.Add(p_a)
            'RichTextBox1.AppendText(tria_num.ToString & ": " & y_a)
            'RichTextBox1.AppendText(Environment.NewLine)
        Next
        Graphics.DrawLines(PenAbso, points_a.ToArray)
        PictureBox1.Image = Bitmap
        interarrivals_distribution()
        draw_interarrivals_distribuiton()
    End Sub

    Private Sub interarrivals_distribution()
        interarrivals_distribution_dictionary = New SortedDictionary(Of Integer, Integer)
        For Each elem In interarrivals
            'RichTextBox1.AppendText("elem: " & elem)
            'RichTextBox1.AppendText(Environment.NewLine)
            If Not interarrivals_distribution_dictionary.ContainsKey(elem) Then
                interarrivals_distribution_dictionary.Add(elem, 1)

            Else
                interarrivals_distribution_dictionary(elem) += 1
            End If
            'RichTextBox1.AppendText("elem_val: " & interarrivals_distribution_dictionary(elem))
            'RichTextBox1.AppendText(Environment.NewLine)
        Next
    End Sub

    Private Sub draw_interarrivals_distribuiton()
        Bitmap2 = New Bitmap(PictureBox2.Width, PictureBox2.Height)
        Graphics2 = Graphics.FromImage(Bitmap2)
        Graphics2.Clear(Color.Black)
        Dim rectangle2 = New Rectangle(0, 0, Bitmap2.Width, Bitmap2.Height)

        Dim max_value = interarrivals_distribution_dictionary.Values.Max
        Dim space_height = rectangle2.Bottom - rectangle2.Top
        Dim space_width = rectangle2.Right - rectangle2.Left
        Dim number_of_keys = interarrivals_distribution_dictionary.Keys.Count
        Dim bar_width = space_width / number_of_keys

        Dim start = rectangle2.X

        For Each key In interarrivals_distribution_dictionary
            Dim rect_height = key.Value / max_value * space_height
            Dim bar_rect = New Rectangle(start, rectangle2.Bottom - rect_height, bar_width, rect_height)

            Graphics2.FillRectangle(Brushes.Green, bar_rect)
            Graphics2.DrawRectangle(Pens.White, bar_rect)
            start += bar_width

            RichTextBox1.AppendText("key: " & key.Key)
            RichTextBox1.AppendText(Environment.NewLine)
            RichTextBox1.AppendText("value: " & key.Value)
            RichTextBox1.AppendText(Environment.NewLine)
        Next




        PictureBox2.Image = Bitmap2
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label1.Text = "Trials: " & TrackBar1.Value.ToString
    End Sub


    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Label3.Text = "Lambda: " & TrackBar3.Value.ToString
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
