Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Dim dice As New List(Of Integer)({1, 2, 3, 4, 5, 6})
    Dim length_dice = dice.Count
    Dim p = (1 / length_dice)
    Function CheckLimit()
        If String.IsNullOrEmpty(TextBoxN.Text) Then
            MsgBox("Insert N into Box (es. 1,...,1000)")
            Return False
        End If
        Return True
    End Function
    Public Function Mean(list As List(Of Integer), probability As Double) As Double
        Dim m As New Double
        m = 0
        For Each number In list
            m += number * probability
        Next
        Console.WriteLine(m)
        Return m
    End Function
    Public Function Variance(list As List(Of Integer)) As Double
        Dim m = Mean(dice, p)
        Dim v As New Double
        v = 0
        For Each number In list
            v += Math.Pow((m - number), 2) / 6
        Next
        Console.WriteLine(Math.Round(v, 2))
        'MsgBox(Math.Round(v, 2))
        Return Math.Round(v, 2)
    End Function
    Public Function SampleMean(list As List(Of Integer)) As Double
        Dim m As New Double
        m = 0
        Dim n = list.Count
        For Each number In list
            m += number / n
        Next
        'MsgBox(m)
        Return Math.Round(m, 2)
    End Function
    Public Function SampleVariance(list As List(Of Integer)) As Double
        Dim sample_mean = SampleMean(list)
        Dim diff = New Double
        Dim pow_diff = New Double
        Dim sum_pow_diff = New Double
        Dim sample_variance = New Double
        For Each number In list
            diff = number - sample_mean
            pow_diff = Math.Pow((diff), 2)
            sum_pow_diff += pow_diff
        Next
        sample_variance = sum_pow_diff / list.Count
        Dim rounded_sample_variance = Math.Round(sample_variance, 2)
        Return rounded_sample_variance
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonMeanVariance.Click
        ChartMean.Titles.Clear()
        ChartMean.Series.Clear()

        If CheckLimit() Then
            Try
                'CHART
                ChartMean.Titles.Add("Mean & Variance of the roll dice ")
                Dim s As New Series
                s.Name = "Percentage \n of \n outcome"
                'Change to a line graph.
                s.ChartType = SeriesChartType.Column

                Dim n = CInt(TextBoxN.Text)
                Mean(dice, p)
                Variance(dice)
                Randomize()

                Dim randoms As Integer
                Dim dictionary = New Dictionary(Of Integer, Integer)
                For Each number In dice
                    dictionary.Add(number, 0)
                Next
                For i As Integer = 0 To n - 1
                    'randoms(i) = CInt(Int((n * Rnd()) + 1))
                    randoms = CInt(Int((length_dice * Rnd()) + 1))
                    Console.WriteLine(randoms)
                    dictionary(randoms) += 1
                Next
                Console.WriteLine("##############")
                ' Get list of keys.
                Dim keys As List(Of Integer) = dictionary.Keys.ToList
                ' Sort the keys.
                keys.Sort()
                Dim list_values_keys = New List(Of Integer)
                For Each key As Integer In keys
                    Console.WriteLine(key.ToString & " " & dictionary(key))
                    list_values_keys.Add(dictionary(key))
                    s.Points.AddXY(key.ToString, dictionary(key))
                Next
                Console.WriteLine("##############")
                'Mean After Random
                Dim sample_mean = SampleMean(list_values_keys)
                RichTextBoxM_V.AppendText("Mean = " & sample_mean & Environment.NewLine)
                Console.WriteLine(sample_mean)
                Dim vari = SampleVariance(list_values_keys)
                RichTextBoxM_V.AppendText("Variance = " & vari)
                Console.WriteLine(vari)
                'Variance After Random

                ChartMean.Series.Add(s)
            Catch ex As Exception
                MsgBox("Insert an Integer and not anymore")
            End Try
        End If
    End Sub

    Private Sub ButtonVariance_Click(sender As Object, e As EventArgs)
        If CheckLimit() Then
            Try
                Dim n = CInt(TextBoxN.Text)
                Variance(dice)
            Catch ex As Exception
                MsgBox("Insert an Integer and not anymore")
            End Try
        End If
    End Sub
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub RichTextBoxMean_TextChanged(sender As Object, e As EventArgs) Handles RichTextBoxM_V.TextChanged

    End Sub
End Class
