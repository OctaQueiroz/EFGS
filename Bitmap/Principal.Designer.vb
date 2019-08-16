<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.mapa = New System.Windows.Forms.PictureBox()
        Me.retaDDA = New System.Windows.Forms.Button()
        Me.circuloBresenham = New System.Windows.Forms.Button()
        Me.retaBresenham = New System.Windows.Forms.Button()
        Me.calculaEscala = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.calculaTransladacao = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tabelaRetas = New System.Windows.Forms.DataGridView()
        Me.tabelaCirculos = New System.Windows.Forms.DataGridView()
        Me.calculaRotacao = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.calculaEspelhagem = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.preencheBoundary = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.apagarReta = New System.Windows.Forms.Button()
        Me.preencheFlood = New System.Windows.Forms.Button()
        Me.janelaCohen = New System.Windows.Forms.Button()
        Me.janelaLiang = New System.Windows.Forms.Button()
        Me.calculaCisalhamento = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        CType(Me.mapa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabelaRetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabelaCirculos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mapa
        '
        Me.mapa.BackColor = System.Drawing.SystemColors.Desktop
        Me.mapa.Location = New System.Drawing.Point(49, 12)
        Me.mapa.Name = "mapa"
        Me.mapa.Size = New System.Drawing.Size(1039, 570)
        Me.mapa.TabIndex = 0
        Me.mapa.TabStop = False
        '
        'retaDDA
        '
        Me.retaDDA.Location = New System.Drawing.Point(49, 589)
        Me.retaDDA.Name = "retaDDA"
        Me.retaDDA.Size = New System.Drawing.Size(115, 50)
        Me.retaDDA.TabIndex = 1
        Me.retaDDA.Text = "DDA"
        Me.retaDDA.UseVisualStyleBackColor = True
        '
        'circuloBresenham
        '
        Me.circuloBresenham.Location = New System.Drawing.Point(193, 589)
        Me.circuloBresenham.Name = "circuloBresenham"
        Me.circuloBresenham.Size = New System.Drawing.Size(115, 50)
        Me.circuloBresenham.TabIndex = 2
        Me.circuloBresenham.Text = "Bresenham Circulo"
        Me.circuloBresenham.UseVisualStyleBackColor = True
        '
        'retaBresenham
        '
        Me.retaBresenham.Location = New System.Drawing.Point(337, 589)
        Me.retaBresenham.Name = "retaBresenham"
        Me.retaBresenham.Size = New System.Drawing.Size(115, 50)
        Me.retaBresenham.TabIndex = 3
        Me.retaBresenham.Text = "Bresenham Reta"
        Me.retaBresenham.UseVisualStyleBackColor = True
        '
        'calculaEscala
        '
        Me.calculaEscala.Location = New System.Drawing.Point(49, 742)
        Me.calculaEscala.Name = "calculaEscala"
        Me.calculaEscala.Size = New System.Drawing.Size(115, 38)
        Me.calculaEscala.TabIndex = 5
        Me.calculaEscala.Text = "Escala"
        Me.calculaEscala.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TextBox1.Location = New System.Drawing.Point(199, 762)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(64, 22)
        Me.TextBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(170, 742)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Insira a escala que deseja ser aplicada"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(630, 595)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(243, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Selecione uma reta para ser alterada"
        '
        'calculaTransladacao
        '
        Me.calculaTransladacao.Location = New System.Drawing.Point(49, 801)
        Me.calculaTransladacao.Name = "calculaTransladacao"
        Me.calculaTransladacao.Size = New System.Drawing.Size(115, 38)
        Me.calculaTransladacao.TabIndex = 9
        Me.calculaTransladacao.Text = "Transladar"
        Me.calculaTransladacao.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(170, 801)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(226, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Insira os valores para a translação" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(199, 821)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(64, 22)
        Me.TextBox2.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(630, 788)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(307, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Selecione uma circunferência para ser alterada"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(305, 762)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(64, 22)
        Me.TextBox3.TabIndex = 15
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(305, 821)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(64, 22)
        Me.TextBox4.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(172, 765)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 17)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "X:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(172, 824)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "X:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(278, 765)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 17)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Y:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(278, 824)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(21, 17)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Y:"
        '
        'tabelaRetas
        '
        Me.tabelaRetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.tabelaRetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabelaRetas.Location = New System.Drawing.Point(633, 615)
        Me.tabelaRetas.Name = "tabelaRetas"
        Me.tabelaRetas.ReadOnly = True
        Me.tabelaRetas.RowTemplate.Height = 24
        Me.tabelaRetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tabelaRetas.Size = New System.Drawing.Size(455, 150)
        Me.tabelaRetas.TabIndex = 21
        '
        'tabelaCirculos
        '
        Me.tabelaCirculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabelaCirculos.Location = New System.Drawing.Point(633, 808)
        Me.tabelaCirculos.Name = "tabelaCirculos"
        Me.tabelaCirculos.ReadOnly = True
        Me.tabelaCirculos.RowTemplate.Height = 24
        Me.tabelaCirculos.Size = New System.Drawing.Size(455, 150)
        Me.tabelaCirculos.TabIndex = 22
        '
        'calculaRotacao
        '
        Me.calculaRotacao.Location = New System.Drawing.Point(49, 859)
        Me.calculaRotacao.Name = "calculaRotacao"
        Me.calculaRotacao.Size = New System.Drawing.Size(115, 38)
        Me.calculaRotacao.TabIndex = 23
        Me.calculaRotacao.Text = "Rotacionar"
        Me.calculaRotacao.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(170, 882)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 17)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Angulo em graus:"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(305, 879)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(64, 22)
        Me.TextBox6.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(170, 859)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(198, 17)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Insira o ângulo para a rotação"
        '
        'calculaEspelhagem
        '
        Me.calculaEspelhagem.Location = New System.Drawing.Point(49, 915)
        Me.calculaEspelhagem.Name = "calculaEspelhagem"
        Me.calculaEspelhagem.Size = New System.Drawing.Size(115, 38)
        Me.calculaEspelhagem.TabIndex = 28
        Me.calculaEspelhagem.Text = "Espelhar"
        Me.calculaEspelhagem.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Para Cima", "Para Baixo", "Para a Esquerda", "Para a Direita"})
        Me.ComboBox1.Location = New System.Drawing.Point(173, 932)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(196, 24)
        Me.ComboBox1.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(170, 912)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(234, 17)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Selecione a direção da espelhagem" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'preencheBoundary
        '
        Me.preencheBoundary.Location = New System.Drawing.Point(49, 664)
        Me.preencheBoundary.Name = "preencheBoundary"
        Me.preencheBoundary.Size = New System.Drawing.Size(115, 50)
        Me.preencheBoundary.TabIndex = 31
        Me.preencheBoundary.Text = "Boundary-Fill"
        Me.preencheBoundary.UseVisualStyleBackColor = True
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AllowFullOpen = False
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.Color = System.Drawing.Color.Wheat
        Me.ColorDialog1.SolidColorOnly = True
        '
        'apagarReta
        '
        Me.apagarReta.Location = New System.Drawing.Point(479, 589)
        Me.apagarReta.Name = "apagarReta"
        Me.apagarReta.Size = New System.Drawing.Size(115, 50)
        Me.apagarReta.TabIndex = 32
        Me.apagarReta.Text = "Apagar Reta"
        Me.apagarReta.UseVisualStyleBackColor = True
        '
        'preencheFlood
        '
        Me.preencheFlood.Location = New System.Drawing.Point(193, 664)
        Me.preencheFlood.Name = "preencheFlood"
        Me.preencheFlood.Size = New System.Drawing.Size(115, 50)
        Me.preencheFlood.TabIndex = 33
        Me.preencheFlood.Text = "Flood-Fill"
        Me.preencheFlood.UseVisualStyleBackColor = True
        '
        'janelaCohen
        '
        Me.janelaCohen.Location = New System.Drawing.Point(337, 664)
        Me.janelaCohen.Name = "janelaCohen"
        Me.janelaCohen.Size = New System.Drawing.Size(115, 50)
        Me.janelaCohen.TabIndex = 34
        Me.janelaCohen.Text = "Cohen-Sutherland"
        Me.janelaCohen.UseVisualStyleBackColor = True
        '
        'janelaLiang
        '
        Me.janelaLiang.Location = New System.Drawing.Point(479, 664)
        Me.janelaLiang.Name = "janelaLiang"
        Me.janelaLiang.Size = New System.Drawing.Size(115, 50)
        Me.janelaLiang.TabIndex = 35
        Me.janelaLiang.Text = "Liang-Barsky"
        Me.janelaLiang.UseVisualStyleBackColor = True
        '
        'calculaCisalhamento
        '
        Me.calculaCisalhamento.Location = New System.Drawing.Point(49, 972)
        Me.calculaCisalhamento.Name = "calculaCisalhamento"
        Me.calculaCisalhamento.Size = New System.Drawing.Size(115, 38)
        Me.calculaCisalhamento.TabIndex = 36
        Me.calculaCisalhamento.Text = "Cisalhamento"
        Me.calculaCisalhamento.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(280, 995)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 17)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Y:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(174, 995)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(21, 17)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "X:"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(307, 992)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(64, 22)
        Me.TextBox5.TabIndex = 39
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(172, 972)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(294, 17)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Insira a força que deseja ser aplicada na reta"
        '
        'TextBox7
        '
        Me.TextBox7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TextBox7.Location = New System.Drawing.Point(201, 992)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(64, 22)
        Me.TextBox7.TabIndex = 37
        '
        'Principal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(940, 693)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.calculaCisalhamento)
        Me.Controls.Add(Me.janelaLiang)
        Me.Controls.Add(Me.janelaCohen)
        Me.Controls.Add(Me.preencheFlood)
        Me.Controls.Add(Me.apagarReta)
        Me.Controls.Add(Me.preencheBoundary)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.calculaEspelhagem)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.calculaRotacao)
        Me.Controls.Add(Me.tabelaCirculos)
        Me.Controls.Add(Me.tabelaRetas)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.calculaTransladacao)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.calculaEscala)
        Me.Controls.Add(Me.retaBresenham)
        Me.Controls.Add(Me.circuloBresenham)
        Me.Controls.Add(Me.retaDDA)
        Me.Controls.Add(Me.mapa)
        Me.Name = "Principal"
        Me.Text = "AlgoritmosCG"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.mapa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabelaRetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabelaCirculos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mapa As System.Windows.Forms.PictureBox
    Friend WithEvents retaDDA As System.Windows.Forms.Button
    Friend WithEvents circuloBresenham As System.Windows.Forms.Button
    Friend WithEvents retaBresenham As System.Windows.Forms.Button
    Friend WithEvents calculaEscala As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents calculaTransladacao As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tabelaRetas As DataGridView
    Friend WithEvents tabelaCirculos As DataGridView
    Friend WithEvents calculaRotacao As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents calculaEspelhagem As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents preencheBoundary As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents apagarReta As System.Windows.Forms.Button
    Friend WithEvents preencheFlood As System.Windows.Forms.Button
    Friend WithEvents janelaCohen As System.Windows.Forms.Button
    Friend WithEvents janelaLiang As System.Windows.Forms.Button
    Friend WithEvents calculaCisalhamento As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
End Class

