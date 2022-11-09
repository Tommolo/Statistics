<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.ButtonMeanVariance = New System.Windows.Forms.Button()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.RichTextBoxM_V = New System.Windows.Forms.RichTextBox()
        Me.TextBoxN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChartMean = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.ChartMean, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonMeanVariance
        '
        Me.ButtonMeanVariance.Location = New System.Drawing.Point(349, 12)
        Me.ButtonMeanVariance.Name = "ButtonMeanVariance"
        Me.ButtonMeanVariance.Size = New System.Drawing.Size(152, 63)
        Me.ButtonMeanVariance.TabIndex = 0
        Me.ButtonMeanVariance.Text = "MEAN AND VARIANCE"
        Me.ButtonMeanVariance.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(863, 526)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(152, 63)
        Me.ButtonClose.TabIndex = 2
        Me.ButtonClose.Text = "CLOSE"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'RichTextBoxM_V
        '
        Me.RichTextBoxM_V.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBoxM_V.Location = New System.Drawing.Point(507, 12)
        Me.RichTextBoxM_V.Name = "RichTextBoxM_V"
        Me.RichTextBoxM_V.Size = New System.Drawing.Size(340, 63)
        Me.RichTextBoxM_V.TabIndex = 3
        Me.RichTextBoxM_V.Text = ""
        '
        'TextBoxN
        '
        Me.TextBoxN.Location = New System.Drawing.Point(121, 32)
        Me.TextBoxN.Name = "TextBoxN"
        Me.TextBoxN.Size = New System.Drawing.Size(94, 22)
        Me.TextBoxN.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(142, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Insert N"
        '
        'ChartMean
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartMean.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.ChartMean.Legends.Add(Legend1)
        Me.ChartMean.Location = New System.Drawing.Point(12, 81)
        Me.ChartMean.Name = "ChartMean"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartMean.Series.Add(Series1)
        Me.ChartMean.Size = New System.Drawing.Size(835, 508)
        Me.ChartMean.TabIndex = 7
        Me.ChartMean.Text = "Chart1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 601)
        Me.Controls.Add(Me.ChartMean)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxN)
        Me.Controls.Add(Me.RichTextBoxM_V)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.ButtonMeanVariance)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.ChartMean, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonMeanVariance As Button
    Friend WithEvents ButtonClose As Button
    Friend WithEvents RichTextBoxM_V As RichTextBox
    Friend WithEvents TextBoxN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ChartMean As DataVisualization.Charting.Chart
End Class
