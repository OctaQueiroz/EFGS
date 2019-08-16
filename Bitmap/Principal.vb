Imports System.Data.DataTable
Public Class Principal
    'lista de pontos X e Y
    Dim tabelaDeRetas As New DataTable("Retas")
    Dim tabelaDeCirculos As New DataTable("Circulos")
    Dim idRetas, contadorPontosJanela, idCirculos As Integer
    Dim pontosX As New List(Of Integer)()
    Dim pontosY As New List(Of Integer)()
    Dim preenchimentoBoundaryFill, preenchimentoFloodFill, janelaCohenSutherland, janelaLiangBarsky As Boolean

    'Variáveis para limitação da janela
    Dim xMin, xMax, yMin, yMax, xInt, yInt As Double

    'Criação do bitmap e suas dimensões
    Dim bmp As New Drawing.Bitmap(1039, 570)
    Dim gfx As Graphics = Graphics.FromImage(bmp)

    'Inicializações ao abrir o programa
    Private Sub Principal_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        tabelaDeRetas.Columns.Add("Reta", Type.GetType("System.String"))
        tabelaDeRetas.Columns.Add("Ponto inicial", Type.GetType("System.String"))
        tabelaDeRetas.Columns.Add("Ponto final", Type.GetType("System.String"))
        tabelaDeRetas.Columns.Add("Cor", Type.GetType("System.String"))

        tabelaDeCirculos.Columns.Add("Circulo", Type.GetType("System.String"))
        tabelaDeCirculos.Columns.Add("Centro", Type.GetType("System.String"))
        tabelaDeCirculos.Columns.Add("Limite do raio", Type.GetType("System.String"))

    End Sub

    'Botão pra traçar reta pelo DDA
    Private Sub DDA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles retaDDA.Click
        'Verifica se um par de pontos foi selecionado na tela
        If (pontosX.Count > 1) Then
            Dim cor As Color
            Dim codigoCor As String
            If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                codigoCor = ColorTranslator.ToHtml(ColorDialog1.Color)
                cor = ColorTranslator.FromHtml(codigoCor)
            End If

            Try
                dda(pontosX(pontosX.Count - 2), pontosY(pontosY.Count - 2), pontosX(pontosX.Count - 1), pontosY(pontosY.Count - 1), cor)
            Catch ex As OverflowException

            End Try

            'Adiciona a nova reta à Tabela de retas e coordenadas
            tabelaDeRetas.Rows.Add("Reta" + CStr(idRetas), CStr(pontosX(pontosX.Count - 2)) + "," + CStr(pontosY(pontosY.Count - 2)), CStr(pontosX(pontosX.Count - 1)) + "," + CStr(pontosY(pontosY.Count - 1)), codigoCor)
            idRetas += 1

        Else
            MessageBox.Show("Selecione ao menos dois pontos na tela para gerar a reta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Popula o grid com a tabela de retas
        Me.tabelaRetas.DataSource = tabelaDeRetas

        'Carrega o bitmap para a tela
        mapa.Image = bmp
    End Sub

    'Botão para traçar reta usando Bresenham
    Private Sub BresenhamReta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles retaBresenham.Click
        'Verifica se um par de pontos foi selecionado na tela
        If (pontosX.Count > 1) Then
            Dim cor As Color
            Dim codigoCor As String
            If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                codigoCor = ColorTranslator.ToHtml(ColorDialog1.Color)
                cor = ColorTranslator.FromHtml(codigoCor)
            End If

            Try
                bresenhamReta(pontosX(pontosX.Count - 2), pontosY(pontosY.Count - 2), pontosX(pontosX.Count - 1), pontosY(pontosY.Count - 1), ColorTranslator.FromHtml(codigoCor))
            Catch ex As OverflowException

            End Try

            'Adiciona a nova reta à Tabela de retas e coordenadas
            tabelaDeRetas.Rows.Add("Reta" + CStr(idRetas), CStr(pontosX(pontosX.Count - 2)) + "," + CStr(pontosY(pontosY.Count - 2)), CStr(pontosX(pontosX.Count - 1)) + "," + CStr(pontosY(pontosY.Count - 1)), codigoCor)
            idRetas += 1

        Else
            MessageBox.Show("Selecione ao menos dois pontos na tela para gerar a reta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Popula o grid com a tabela de retas
        Me.tabelaRetas.DataSource = tabelaDeRetas

        'Carrega o bitmap para a tela
        mapa.Image = bmp

    End Sub

    'Botão para traçar o círculo usando Bresenham
    Private Sub BresenhamCirculo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles circuloBresenham.Click
        'Verifica se um par de pontos foi selecionado na tela
        If (pontosX.Count > 1) Then

            Try
                bresenhamCirculo(pontosX(pontosX.Count - 2), pontosY(pontosY.Count - 2), pontosX(pontosX.Count - 1), pontosY(pontosY.Count - 1), Color.White)
            Catch ex As OverflowException

            End Try

            'Adiciona o novo circulo à Tabela de Circulos e coordenadas
            tabelaDeCirculos.Rows.Add("Circulo" + CStr(idCirculos), CStr(pontosX(pontosX.Count - 2)) + "," + CStr(pontosY(pontosY.Count - 2)), CStr(pontosX(pontosX.Count - 1)) + "," + CStr(pontosY(pontosY.Count - 1)))
            idCirculos += 1

        Else
            MessageBox.Show("Selecione ao menos dois pontos na tela para gerar o círculo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Popula o grid com a tabela de retas
        Me.tabelaCirculos.DataSource = tabelaDeCirculos

        'Carrega o bitmap para a tela
        mapa.Image = bmp
    End Sub

    '--------------------------- Fim dos botões de criação de figuras ----------------------------------------------------------------------------------------------

    'Botão para aplicar escala na reta
    Private Sub escala_Click(ByVal sender As Object, ByVal e As EventArgs) Handles calculaEscala.Click

        Dim escX, escY As Double

        'verifica se o texto foi deixado em branco, se sim, assume o valor como 0, senão atribuí o valor que foi passado
        If Not (tabelaRetas.CurrentRow Is Nothing) Then

            If (TextBox1.Text.Equals("")) Then
                escX = 1
            Else
                escX = CDbl(TextBox1.Text)
            End If
            If (TextBox3.Text.Equals("")) Then
                escY = 1
            Else
                escY = CDbl(TextBox3.Text)
            End If

            'Busca na tabela os dados da reta selecionada
            Dim coordenadas1 As String() = (tabelaRetas.CurrentRow.Cells(1).Value.ToString()).Split(",")
            Dim coordenadas2 As String() = (tabelaRetas.CurrentRow.Cells(2).Value.ToString()).Split(",")
            Dim cor As Color = ColorTranslator.FromHtml((tabelaRetas.CurrentRow.Cells(3).Value.ToString()))

            'Aplica a transformaçãon
            Try
                escala(CInt(coordenadas1(0)), CInt(coordenadas1(1)), CInt(coordenadas2(0)), CInt(coordenadas2(1)), cor, escX, escY)
            Catch ex As OverflowException

            End Try

            'Popula o grid com a tabela de retas
            Me.tabelaRetas.DataSource = tabelaDeRetas

            mapa.Image = bmp

            TextBox1.Text = ""
            TextBox3.Text = ""

        Else
            MessageBox.Show("Selecione uma reta para aplicar a operação", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Botão para aplicar translação na reta
    Private Sub translacao_Click(ByVal sender As Object, ByVal e As EventArgs) Handles calculaTransladacao.Click

        Dim tX, tY As Integer

        'verifica se o texto foi deixado em branco, se sim, assume o valor como 0, senão atribuí o valor que foi passado
        If Not (tabelaRetas.CurrentRow Is Nothing) Then
            If (TextBox2.Text.Equals("")) Then
                tX = 0
            Else
                tX = CInt(TextBox2.Text)
            End If
            If (TextBox4.Text.Equals("")) Then
                tY = 0
            Else
                tY = CInt(TextBox4.Text)
            End If

            'Busca na tabela os dados da reta selecionada
            Dim coordenadas1 As String() = (tabelaRetas.CurrentRow.Cells(1).Value.ToString()).Split(",")
            Dim coordenadas2 As String() = (tabelaRetas.CurrentRow.Cells(2).Value.ToString()).Split(",")
            Dim cor As Color = ColorTranslator.FromHtml((tabelaRetas.CurrentRow.Cells(3).Value.ToString()))

            'Aplica a transformação
            Try
                transladar(CInt(coordenadas1(0)), CInt(coordenadas1(1)), CInt(coordenadas2(0)), CInt(coordenadas2(1)), cor, tX, tY)
            Catch ex As OverflowException

            End Try

            'Popula o grid com a tabela de retas
            Me.tabelaRetas.DataSource = tabelaDeRetas

            mapa.Image = bmp

            TextBox2.Text = ""
            TextBox4.Text = ""
        Else
            MessageBox.Show("Selecione uma reta para aplicar a operação", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Botão para aplicar a rotação na reta
    Private Sub rotacao_Click(ByVal sender As Object, ByVal e As EventArgs) Handles calculaRotacao.Click

        Dim angulo As Double

        If Not (tabelaRetas.CurrentRow Is Nothing) Then
            If (TextBox6.Text.Equals("")) Then
                angulo = 0
            Else
                'Passa o valor do angulo para radianos
                angulo = CDbl(TextBox6.Text) * Math.PI / 180
            End If

            'Busca na tabela os dados da reta selecionada
            Dim coordenadas1 As String() = (tabelaRetas.CurrentRow.Cells(1).Value.ToString()).Split(",")
            Dim coordenadas2 As String() = (tabelaRetas.CurrentRow.Cells(2).Value.ToString()).Split(",")
            Dim cor As Color = ColorTranslator.FromHtml((tabelaRetas.CurrentRow.Cells(3).Value.ToString()))

            'Aplica a transformação
            Try
                rotacionar(CInt(coordenadas1(0)), CInt(coordenadas1(1)), CInt(coordenadas2(0)), CInt(coordenadas2(1)), cor, angulo)
            Catch ex As OverflowException

            End Try

            'Popula o grid com a tabela de retas
            Me.tabelaRetas.DataSource = tabelaDeRetas

            mapa.Image = bmp
            TextBox6.Text = ""
        Else
            MessageBox.Show("Selecione uma reta para aplicar a operação", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Botão para criar uma reta espelhada
    Private Sub espelhar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles calculaEspelhagem.Click

        If Not (tabelaRetas.CurrentRow Is Nothing) Then
            If Not (ComboBox1.SelectedItem Is Nothing) Then

                Dim cor As Color
                Dim codigoCor As String
                If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                    codigoCor = ColorTranslator.ToHtml(ColorDialog1.Color)
                    cor = ColorTranslator.FromHtml(codigoCor)
                End If

                'Busca na tabela os dados da reta selecionada
                Dim coordenadas1 As String() = (tabelaRetas.CurrentRow.Cells(1).Value.ToString()).Split(",")
                Dim coordenadas2 As String() = (tabelaRetas.CurrentRow.Cells(2).Value.ToString()).Split(",")

                'Aplica a transformação
                Try
                    espelhar(CInt(coordenadas1(0)), CInt(coordenadas1(1)), CInt(coordenadas2(0)), CInt(coordenadas2(1)), cor, ComboBox1.SelectedIndex)
                Catch ex As OverflowException

                End Try

                'Popula o grid com a tabela de retas
                Me.tabelaRetas.DataSource = tabelaDeRetas

                mapa.Image = bmp
                ComboBox1.SelectedItem = Nothing

            End If

        Else
            MessageBox.Show("Selecione uma reta para aplicar a operação", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Botão para aplicar o cisalhamento na reta
    Private Sub cisalhamento_Click(sender As Object, e As EventArgs) Handles calculaCisalhamento.Click
        Dim fX, fY As Double
        If Not (tabelaRetas.CurrentRow Is Nothing) Then

            If (TextBox2.Text.Equals("")) Then
                fX = 1
            Else
                fX = CInt(TextBox2.Text)
            End If
            If (TextBox4.Text.Equals("")) Then
                fY = 1
            Else
                fY = CInt(TextBox4.Text)
            End If

            'Busca na tabela os dados da reta selecionada
            Dim coordenadas1 As String() = (tabelaRetas.CurrentRow.Cells(1).Value.ToString()).Split(",")
            Dim coordenadas2 As String() = (tabelaRetas.CurrentRow.Cells(2).Value.ToString()).Split(",")
            Dim cor As Color = ColorTranslator.FromHtml((tabelaRetas.CurrentRow.Cells(3).Value.ToString()))

            'Aplica a transformação
            Try
                cisalhamento(CInt(coordenadas1(0)), CInt(coordenadas1(1)), CInt(coordenadas2(0)), CInt(coordenadas2(1)), cor, fX, fY)
            Catch ex As OverflowException

            End Try

            'Popula o grid com a tabela de retas
            Me.tabelaRetas.DataSource = tabelaDeRetas

            mapa.Image = bmp

        Else
            MessageBox.Show("Selecione uma reta para aplicar a operação", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    '--------------------------- Fim dos botões de transformação----------------------------------------------------------------------------------------------

    'Botão para ativar/desativar o preenchimento usando Boundary-Fill
    Private Sub boundaryFill_Click(sender As Object, e As EventArgs) Handles preencheBoundary.Click

        If (preenchimentoBoundaryFill) Then
            preenchimentoBoundaryFill = False
            MessageBox.Show("Função de preenchimento Boundary-Fill desativada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        preenchimentoBoundaryFill = True
        MessageBox.Show("Função de preenchimento Boundary-Fill ativada! Clique dentro de uma figura pequena na tela para colori-la ou clique no botão novamente para desativar a função", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    'Botão para ativar/desativar o preenchimento usando Flood-Fill
    Private Sub floodFill_Click(sender As Object, e As EventArgs) Handles preencheFlood.Click

        If (preenchimentoFloodFill) Then
            preenchimentoFloodFill = False
            MessageBox.Show("Função de preenchimento Flood-Fill desativada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        preenchimentoFloodFill = True
        MessageBox.Show("Função de preenchimento Flood-Fill ativada! Clique dentro de uma figura pequena na tela para colori-la ou clique no botão novamente para desativar a função", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    'Botão para ativar/desativar o o corte de janela usando Cohen-Sutherland
    Private Sub cohenSutherland_Click(sender As Object, e As EventArgs) Handles janelaCohen.Click

        If (janelaCohenSutherland) Then
            janelaCohenSutherland = False
            MessageBox.Show("Função de corte de Cohen-Sutherland desativado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        janelaCohenSutherland = True

        'Para previnir bugs, altera o contador de pontos da janela para 0
        contadorPontosJanela = 0

        MessageBox.Show("Função de corte Cohen-Sutherland ativado! Clique em dois pontos na tela para delimitar a diagonal da janela de corte ou clique no botão novamente para desativar a função", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    'Botão para ativar/desativar o corte de janela usando Liang-Barsky
    Private Sub liangBarsky_Click(sender As Object, e As EventArgs) Handles janelaLiang.Click

        If (janelaLiangBarsky) Then
            janelaLiangBarsky = False
            MessageBox.Show("Função de corte de Liang-Barsky desativado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        janelaLiangBarsky = True

        'Para previnir bugs, altera o contador de pontos da janela para 0
        contadorPontosJanela = 0

        MessageBox.Show("Função de corte Liang-Barsky ativado! Clique em dois pontos na tela para delimitar a diagonal da janela de corte ou clique no botão novamente para desativar a função", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    'Captura a coordenada do clique do mouse
    Private Sub Mapa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mapa.Click

        'valores subtraídos para posicionar o pixel no bitmap e salvos na lista de pontos X e Y
        pontosX.Add(MousePosition.X - Me.Location.X - mapa.Location.X - 8)
        pontosY.Add(MousePosition.Y - Me.Location.Y - mapa.Location.Y - 30)

        'Se ao clicar na tela, a função de preenchimento de Boundary-Fill estiver ativa, realiza o preenchimento e depois finaliza a função
        If (preenchimentoBoundaryFill) Then

            Dim cor As Color
            Dim codigoCor As String
            If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                codigoCor = ColorTranslator.ToHtml(ColorDialog1.Color)
                cor = ColorTranslator.FromHtml(codigoCor)
            End If

            boundaryFill(pontosX(pontosX.Count - 1), pontosY(pontosY.Count - 1), cor, Color.White)

            preenchimentoBoundaryFill = False

        Else
            'Se ao clicar na tela, a função de preenchimento de Flood-Fill estiver ativa, realiza o preenchimento e depois finaliza a função
            If (preenchimentoFloodFill) Then
                Dim cor As Color
                Dim codigoCor As String
                If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                    codigoCor = ColorTranslator.ToHtml(ColorDialog1.Color)
                    cor = ColorTranslator.FromHtml(codigoCor)
                End If

                floodFill(pontosX(pontosX.Count - 1), pontosY(pontosY.Count - 1), cor, bmp.GetPixel(pontosX(pontosX.Count - 1), pontosY(pontosY.Count - 1)))

                preenchimentoFloodFill = False

            Else
                'Se ao clicar na tela, a função de corte de janela por Cohen-Sutherland estiver ativa,
                'acrescenta 1 ao contador de pontos e espera por um novo clique na tela para realizar o corte
                If (janelaCohenSutherland) Then
                    contadorPontosJanela += 1
                    If (contadorPontosJanela = 2) Then
                        If Not (tabelaRetas.CurrentRow Is Nothing) Then
                            Dim linhas As Integer = tabelaDeRetas.Rows.Count
                            For index = 0 To linhas - 1
                                'Atribuindo as dadas dimensões à janela
                                If (pontosX(pontosX.Count - 1) > pontosX(pontosX.Count - 2)) Then
                                    xMin = pontosX(pontosX.Count - 2)
                                    xMax = pontosX(pontosX.Count - 1)
                                Else
                                    xMin = pontosX(pontosX.Count - 1)
                                    xMax = pontosX(pontosX.Count - 2)
                                End If

                                If (pontosY(pontosY.Count - 2) > pontosY(pontosY.Count - 1)) Then
                                    yMin = pontosY(pontosY.Count - 1)
                                    yMax = pontosY(pontosY.Count - 2)
                                Else
                                    yMin = pontosY(pontosY.Count - 2)
                                    yMax = pontosY(pontosY.Count - 1)
                                End If

                                'Busca na tabela os dados da reta selecionada
                                Dim coordenadas1 As String() = (tabelaRetas.SelectedRows(0).Cells(1).Value.ToString()).Split(",")
                                Dim coordenadas2 As String() = (tabelaRetas.SelectedRows(0).Cells(2).Value.ToString()).Split(",")
                                Dim cor As Color = ColorTranslator.FromHtml((tabelaRetas.SelectedRows(0).Cells(3).Value.ToString()))

                                Try
                                    cohenSutherland(CInt(coordenadas1(0)), CInt(coordenadas1(1)), CInt(coordenadas2(0)), CInt(coordenadas2(1)), cor)
                                Catch ex As OverflowException

                                End Try

                            Next
                            mapa.Image = bmp
                            contadorPontosJanela = 0
                            janelaCohenSutherland = False
                        Else
                            MessageBox.Show("Selecione uma reta para aplicar a operação", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        Exit Sub
                    End If

                Else
                    'Se ao clicar na tela, a função de corte de janela por Liang-Barsky estiver ativa,
                    'acrescenta 1 ao contador de pontos e espera por um novo clique na tela para realizar o corte
                    If (janelaLiangBarsky) Then
                        contadorPontosJanela += 1
                        If (contadorPontosJanela = 2) Then
                            If Not (tabelaRetas.CurrentRow Is Nothing) Then
                                Dim linhas As Integer = tabelaDeRetas.Rows.Count
                                For index = 0 To linhas - 1

                                    'Atribuindo as dadas dimensões à janela
                                    If (pontosX(pontosX.Count - 1) > pontosX(pontosX.Count - 2)) Then
                                        xMin = pontosX(pontosX.Count - 2)
                                        xMax = pontosX(pontosX.Count - 1)
                                    Else
                                        xMin = pontosX(pontosX.Count - 1)
                                        xMax = pontosX(pontosX.Count - 2)
                                    End If

                                    If (pontosY(pontosY.Count - 2) > pontosY(pontosY.Count - 1)) Then
                                        yMin = pontosY(pontosY.Count - 1)
                                        yMax = pontosY(pontosY.Count - 2)
                                    Else
                                        yMin = pontosY(pontosY.Count - 2)
                                        yMax = pontosY(pontosY.Count - 1)
                                    End If



                                    'Busca na tabela os dados da reta selecionada
                                    Dim coordenadas1 As String() = (tabelaRetas.SelectedRows(0).Cells(1).Value.ToString()).Split(",")
                                    Dim coordenadas2 As String() = (tabelaRetas.SelectedRows(0).Cells(2).Value.ToString()).Split(",")
                                    Dim cor As Color = ColorTranslator.FromHtml((tabelaRetas.SelectedRows(0).Cells(3).Value.ToString()))

                                    Try
                                        liangBarsky(CInt(coordenadas1(0)), CInt(coordenadas1(1)), CInt(coordenadas2(0)), CInt(coordenadas2(1)), cor)
                                    Catch ex As OverflowException

                                    End Try

                                Next

                                mapa.Image = bmp
                                contadorPontosJanela = 0
                                janelaLiangBarsky = False

                            Else
                                MessageBox.Show("Selecione uma reta para aplicar a operação", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                            Exit Sub
                        End If

                    Else

                        'Seta o pixel do clique na tela
                        bmp.SetPixel(MousePosition.X - Me.Location.X - mapa.Location.X - 8, MousePosition.Y - Me.Location.Y - mapa.Location.Y - 30, Color.Black)

                    End If

                End If

            End If

        End If

        'Popula o grid com a tabela de retas
        Me.tabelaRetas.DataSource = tabelaDeRetas

        'Carrega o bitmap para a tela 
        mapa.Image = bmp
    End Sub

    'Botão para apagar uma reta específica
    Private Sub apagar_Click(sender As Object, e As EventArgs) Handles apagarReta.Click

        'Busca na tabela os dados da reta selecionada
        Dim coordenadas1 As String() = (tabelaRetas.CurrentRow.Cells(1).Value.ToString()).Split(",")
        Dim coordenadas2 As String() = (tabelaRetas.CurrentRow.Cells(2).Value.ToString()).Split(",")

        'Aplica a transformação

        apagar(CInt(coordenadas1(0)), CInt(coordenadas1(1)), CInt(coordenadas2(0)), CInt(coordenadas2(1)))

        'Popula o grid com a tabela de retas
        Me.tabelaRetas.DataSource = tabelaDeRetas

        mapa.Image = bmp

    End Sub
    '--------------------------- Fim da sessão de botões----------------------------------------------------------------------------------------------

    'Algoritmo para calcular retas que utiliza pontos flutuante em seus cálculos
    Function dda(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal cor As Color)
        Dim x As Double = x1
        Dim y As Double = y1
        Dim dx As Double = x2 - x1
        Dim dy As Double = y2 - y1
        Dim passos As Integer
        Dim xIncr, yIncr As Double

        If (Math.Abs(dx) > Math.Abs(dy)) Then
            passos = Math.Abs(dx)
        Else
            passos = Math.Abs(dy)
        End If

        xIncr = dx / passos
        yIncr = dy / passos
        If (x < bmp.Size.Width And y < bmp.Size.Height) Then
            Try
                bmp.SetPixel(x, y, cor)
            Catch ex As ArgumentOutOfRangeException

            End Try

        End If

        For i = 0 To passos
            x += xIncr
            y += yIncr
            'Verifica se o ponto atual está dentro do bitmap, se etiver fora não é considerado
            If (Math.Round(x) < bmp.Size.Width And Math.Round(y) < bmp.Size.Height And Math.Round(x) > 0 And Math.Round(x) > 0) Then
                Try
                    bmp.SetPixel(Math.Round(x), Math.Round(y), cor)
                Catch ex As ArgumentOutOfRangeException

                End Try

            End If

        Next

    End Function

    'Algoritmo para traçar o círculo utilizando simetría de pontos
    Function bresenhamCirculo(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cor As Color)

        'Calcula ó módulo do vetor equivalente ao raio
        Dim r As Integer = Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)))

        Dim x As Integer = 0
        Dim y As Integer = r
        Dim p As Integer = 3 - 2 * r

        plotaSimetricos(x, y, x1, y1, cor)

        While (x < y)
            If (p < 0) Then
                p += 4 * x + 6
            Else
                p += 4 * (x - y) + 10
                y -= 1
            End If

            x += 1

            plotaSimetricos(x, y, x1, y1, cor)

        End While

    End Function

    'Algoritmo para plotar os pontos simétricos de uma circunferência, dado o seu ponto central
    Function plotaSimetricos(ByVal x As Integer, ByVal y As Integer, ByVal xC As Integer, ByVal yC As Integer, ByVal cor As Color)

        'Cadeia de condicionais que verificam se os pontos a serem inseridos estão dentro da região do bitmap, para evitar o uso do try catch
        If (xC + x < bmp.Size.Width And xC + x > 0) Then
            If (yC + y < bmp.Size.Height And yC + y > 0) Then
                bmp.SetPixel(xC + x, yC + y, cor)
            End If
            If (yC - y < bmp.Size.Height And yC - y > 0) Then
                bmp.SetPixel(xC + x, yC - y, cor)
            End If
        End If

        If (xC - x < bmp.Size.Width And xC - x > 0) Then
            If (yC + y < bmp.Size.Height And yC + y > 0) Then
                bmp.SetPixel(xC - x, yC + y, cor)
            End If
            If (yC - y < bmp.Size.Height And yC - y > 0) Then
                bmp.SetPixel(xC - x, yC - y, cor)
            End If
        End If

        If (xC + y < bmp.Size.Width And xC + y > 0) Then
            If (yC + x < bmp.Size.Height And yC + x > 0) Then
                bmp.SetPixel(xC + y, yC + x, cor)
            End If
            If (yC - x < bmp.Size.Height And yC - x > 0) Then
                bmp.SetPixel(xC + y, yC - x, cor)
            End If
        End If

        If (xC - y < bmp.Size.Width And xC - y > 0) Then
            If (yC + x < bmp.Size.Height And yC + x > 0) Then
                bmp.SetPixel(xC - y, yC + x, cor)
            End If
            If (yC - x < bmp.Size.Height And yC - x > 0) Then
                bmp.SetPixel(xC - y, yC - x, cor)
            End If
        End If

    End Function

    'Algoritmo de Bresenham para traçar retas utilizando apenas calculos com números inteiros
    Function bresenhamReta(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cor As Color)
        Dim x As Double = x1
        Dim y As Double = y1
        Dim dx As Integer = x2 - x1
        Dim dy As Integer = y2 - y1
        Dim p, xIncr, yIncr, const1, const2 As Integer

        bmp.SetPixel(x, y, cor)
        Me.Refresh()

        If (dx < 0) Then
            dx = -dx
            xIncr = -1
        Else
            xIncr += 1
        End If

        If (dy < 0) Then
            dy = -dy
            yIncr = -1
        Else
            yIncr += 1
        End If

        If (dx > dy) Then
            p = 2 * dy - dx
            const1 = 2 * dy
            const2 = 2 * (dy - dx)
            For i = 0 To dx
                x += xIncr
                If (p < 0) Then
                    p += const1
                Else
                    y += yIncr
                    p += const2
                End If

                If (x < bmp.Size.Width And y < bmp.Size.Height And x > 0 And y > 0) Then
                    Try
                        bmp.SetPixel(x, y, cor)
                    Catch ex As ArgumentOutOfRangeException

                    End Try

                End If

            Next
        Else
            p = 2 * dx - dy
            const1 = 2 * dx
            const2 = 2 * (dx - dy)

            For i = 0 To dy
                y += yIncr
                If (p < 0) Then
                    p += const1
                Else
                    p += const2
                    x += xIncr
                End If
                If (x < bmp.Size.Width And y < bmp.Size.Height And x > 0 And y > 0) Then
                    Try
                        bmp.SetPixel(x, y, cor)
                    Catch ex As ArgumentOutOfRangeException

                    End Try

                End If


            Next
        End If

    End Function

    '--------------------------- Fim da sessão de Algoritmos de formas algébricas---------------------------------------------------------------------

    'Aplica a escala dada à reta
    Function escala(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cor As Color, ByVal multX As Double, ByVal multY As Double)
        Dim tempX, tempY As Double

        'Apaga a reta atual para a inserção de sua nova versão
        apagar(x1, y1, x2, y2)

        tempX = x2 - x1
        tempY = y2 - y1

        tempX *= multX
        tempY *= multY

        x2 = tempX + x1
        y2 = tempY + y1

        dda(x1, y1, x2, y2, cor)

        'Adiciona a nova reta à tabela de retas e coordenadas
        tabelaDeRetas.Rows.Add("Reta" + CStr(idRetas), CStr(x1) + "," + CStr(y1), CStr(x2) + "," + CStr(y2), ColorTranslator.ToHtml(cor))
        idRetas += 1

        'Popula o grid com a tabela de retas
        Me.tabelaRetas.DataSource = tabelaDeRetas

    End Function

    'Aplica a translação dada  à reta
    Function transladar(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cor As Color, ByVal tX As Integer, ByVal tY As Integer)
        If Not (tX = 0 And tY = 0) Then

            'Apaga a reta atual para a inserção de sua nova versão
            apagar(x1, y1, x2, y2)

            'Traça a nova reta alterada
            dda(x1 + tX, y1 - tY, x2 + tX, y2 - tY, cor)

            'Adiciona a nova reta à tabela de retas e coordenadas
            tabelaDeRetas.Rows.Add("Reta" + CStr(idRetas), CStr(x1 + tX) + "," + CStr(y1 - tY), CStr(x2 + tX) + "," + CStr(y2 - tY), ColorTranslator.ToHtml(cor))
            idRetas += 1

            'Popula o grid com a tabela de retas
            Me.tabelaRetas.DataSource = tabelaDeRetas

        End If
    End Function

    'Aplica a rotação indicada pelo ângulo à reta
    Function rotacionar(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cor As Color, ByVal angulo As Double)
        Dim xfinal, yFinal As Double

        'Apaga a reta atual para a inserção de sua nova versão
        apagar(x1, y1, x2, y2)

        'Translada o ponto final para como se a reta começasse na origem 
        x2 = x2 - x1
        y2 = y2 - y1

        'Calcula o deslocamento do ponto final pós-rotação
        xfinal = x2 * Math.Cos(angulo) - y2 * Math.Sin(angulo)
        yFinal = x2 * Math.Sin(angulo) + y2 * Math.Cos(angulo)

        'Desfaz a translação do ponto final
        x2 = xfinal + x1
        y2 = yFinal + y1

        'Traça a nova reta alterada
        dda(x1, y1, x2, y2, cor)

        'Adiciona a nova reta à tabela de retas e coordenadas
        tabelaDeRetas.Rows.Add("Reta" + CStr(idRetas), CStr(x1) + "," + CStr(y1), CStr(x2) + "," + CStr(y2), ColorTranslator.ToHtml(cor))
        idRetas += 1

        'Popula o grid com a tabela de retas
        Me.tabelaRetas.DataSource = tabelaDeRetas

    End Function

    'Aplica a espelhagem na direção indicada
    Function espelhar(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cor As Color, ByVal direcao As Integer)
        'Se for para cima
        If (direcao = 0) Then
            'Verificando qual dos pontos será a origem da simetria e qual será o final
            If (y1 > y2) Then
                y1 -= 2 * (Math.Abs(y1 - y2))
            Else
                y2 -= 2 * (Math.Abs(y1 - y2))
            End If
            dda(x1, y1, x2, y2, cor)
        Else
            'Se for para baixo
            If (direcao = 1) Then
                'Verificando qual dos pontos será a origem da simetria e qual será o final
                If (y1 > y2) Then
                    y2 += 2 * (Math.Abs(y1 - y2))
                Else
                    y1 += 2 * (Math.Abs(y1 - y2))
                End If
                dda(x1, y1, x2, y2, cor)
            Else
                'Se for para a esquerda
                If (direcao = 2) Then
                    'Verificando qual dos pontos será a origem da simetria e qual será o final
                    If (x1 > x2) Then
                        x1 -= 2 * (Math.Abs(x1 - x2))
                    Else
                        x2 -= 2 * (Math.Abs(x1 - x2))
                    End If
                    dda(x1, y1, x2, y2, cor)
                Else
                    'Se for para a direita
                    If (direcao = 3) Then
                        'Verificando qual dos pontos será a origem da simetria e qual será o final
                        If (x1 > x2) Then
                            x2 += 2 * (Math.Abs(x1 - x2))
                        Else
                            x1 += 2 * (Math.Abs(x1 - x2))
                        End If
                        dda(x1, y1, x2, y2, cor)

                    End If
                End If
            End If
        End If

        'Adiciona a nova reta à tabela de retas e coordenadas
        tabelaDeRetas.Rows.Add("Reta" + CStr(idRetas), CStr(x1) + "," + CStr(y1), CStr(x2) + "," + CStr(y2), ColorTranslator.ToHtml(cor))
        idRetas += 1

    End Function

    'Aplica o cisalhamento de força fX/fY à reta dada
    Function cisalhamento(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal cor As Color, ByVal fX As Double, ByVal fY As Double)

        Dim tempX, tempY As Double
        'Apaga a reta atual para a inserção de sua nova versão
        apagar(x1, y1, x2, y2)

        tempX = Math.Abs(x2 - x1)
        tempY = Math.Abs(y2 - y1)

        tempX *= fX
        tempY *= fY

        If (y1 = y2) Then 'Caso a reta seja paralela ao eixo X
            If (x1 > x2) Then
                y1 -= tempX
            Else
                y2 -= tempX
            End If
        Else
            If (x1 = x2) Then 'Caso a reta seja paralela ao eixo Y
                If (y1 < y2) Then
                    x1 += tempY
                Else
                    x2 += tempY
                End If
            Else    'Caso a reta seja inclinada
                If (x1 > x2) Then
                    y1 -= tempX
                Else
                    y2 -= tempX
                End If

                If (y1 < y2) Then
                    x1 += tempY
                Else
                    x2 += tempY
                End If
            End If
        End If

        dda(x1, y1, x2, y2, cor)

        'Adiciona a nova reta à tabela de retas e coordenadas
        tabelaDeRetas.Rows.Add("Reta" + CStr(idRetas), CStr(x1) + "," + CStr(y1), CStr(x2) + "," + CStr(y2), ColorTranslator.ToHtml(cor))
        idRetas += 1

        'Popula o grid com a tabela de retas
        Me.tabelaRetas.DataSource = tabelaDeRetas
    End Function

    'Apaga a reta selecionada
    Function apagar(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        'Traça uma reta da cor do fundo de tela para "excluir a reta"
        bresenhamReta(x1, y1, x2, y2, Color.Black)
        'Remove a reta da tabela de retas
        tabelaDeRetas.Rows.RemoveAt(tabelaRetas.CurrentRow.Index)

        mapa.Image = bmp

    End Function

    '--------------------------- Fim da sessão de Transformações-------------------------------------------------------------------------------------

    'Realiza o preenchimento da figura utilizando Boundary-Fill
    Function boundaryFill(x As Integer, y As Integer, corNova As Color, contorno As Color)
        Dim corAtual As Color

        'Obtem a cor do pixel especificado
        corAtual = bmp.GetPixel(x, y)

        If (corAtual.ToArgb <> corNova.ToArgb And corAtual.ToArgb <> contorno.ToArgb) Then

            bmp.SetPixel(x, y, corNova)

            boundaryFill(x + 1, y, corNova, contorno)
            boundaryFill(x - 1, y, corNova, contorno)
            boundaryFill(x, y + 1, corNova, contorno)
            boundaryFill(x, y - 1, corNova, contorno)

        End If

    End Function

    'Realiza o preenchimento utilizando Flood-Fill
    Function floodFill(x As Integer, y As Integer, corNova As Color, fundo As Color)

        If (bmp.GetPixel(x, y).ToArgb = fundo.ToArgb) Then

            bmp.SetPixel(x, y, corNova)

            floodFill(x + 1, y, corNova, fundo)
            floodFill(x - 1, y, corNova, fundo)
            floodFill(x, y + 1, corNova, fundo)
            floodFill(x, y - 1, corNova, fundo)

        End If

    End Function

    'Realiza o corte de janela utilizando Cohen-Sutherland
    Function cohenSutherland(x1 As Double, y1 As Double, x2 As Double, y2 As Double, cor As Color)

        Dim aceite, feito As Boolean
        Dim c1(3) As Integer
        Dim c2(3) As Integer
        Dim cfora(3) As Integer
        Dim tempX, tempY As Double

        'remove a reta atual
        apagar(x1, y1, x2, y2)

        While Not (feito)
            c1 = region_code(x1, y1)
            c2 = region_code(x2, y2)

            If (c1(0) = 0 And c1(1) = 0 And c1(2) = 0 And c1(3) = 0 And c2(0) = 0 And c2(1) = 0 And c2(2) = 0 And c2(3) = 0) Then
                aceite = True
                feito = True
            Else
                If ((c1(0) <> 0 And c2(0) <> 0) Or (c1(1) <> 0 And c2(1) <> 0) Or (c1(2) <> 0 And c2(2) <> 0) Or (c1(3) <> 0 And c2(3) <> 0)) Then
                    feito = True
                Else
                    If (c1(0) <> 0 Or c1(1) <> 0 Or c1(2) <> 0 Or c1(3) <> 0) Then
                        cfora = c1
                    Else
                        cfora = c2
                    End If
                End If
            End If

            If (cfora(3) = 1) Then 'Limite esquerdo
                xInt = xMin

                tempX = x2 - x1
                tempY = y2 - y1

                yInt = y1 + tempY * (xMin - x1) / tempX
            Else
                If (cfora(2) = 1) Then 'Limite direito
                    xInt = xMax

                    tempX = x2 - x1
                    tempY = y2 - y1

                    yInt = y1 + tempY * (xMax - x1) / tempX
                Else
                    If (cfora(1) = 1) Then 'Limite abaixo
                        yInt = yMin

                        tempX = x2 - x1
                        tempY = y2 - y1

                        xInt = x1 + tempX * (yMin - y1) / tempY
                    Else
                        If (cfora(0) = 1) Then 'Limite acima
                            yInt = yMax

                            tempX = x2 - x1
                            tempY = y2 - y1

                            xInt = x1 + tempX * (yMax - y1) / tempY
                        End If
                    End If
                End If
            End If

            If (c1(0) = cfora(0) And c1(1) = cfora(1) And c1(2) = cfora(2) And c1(3) = cfora(3)) Then
                x1 = xInt
                y1 = yInt
            Else
                x2 = xInt
                y2 = yInt
            End If

            If (aceite) Then
                bresenhamReta(Math.Round(x1), Math.Round(y1), Math.Round(x2), Math.Round(y2), cor)
                'Adiciona a nova reta à Tabela de retas e coordenadas
                Dim codigoCor As String = ColorTranslator.ToHtml(cor)
                tabelaDeRetas.Rows.Add("Reta" + CStr(idRetas), CStr(Math.Round(x1)) + "," + CStr(Math.Round(y1)), CStr(Math.Round(x2)) + "," + CStr(Math.Round(y2)), codigoCor)
                idRetas += 1

            End If
        End While

    End Function

    'Verifica quais cortes ainda são necessários para que a reta fique dentro da janela de Cohen-Sutherland
    Function region_code(x As Integer, y As Integer) As Integer()
        Dim codigo(3) As Integer

        If (x < xMin) Then 'Esquerda - bit 0
            codigo(3) = 1
        End If
        If (x > xMax) Then 'direita - bit 1
            codigo(2) = 1
        End If
        If (y < yMin) Then 'baixo - bit 2
            codigo(1) = 1
        End If
        If (y > yMax) Then 'cima - bit 3
            codigo(0) = 1
        End If

        Return codigo

    End Function

    'Realiza o corte de janela utilizando Liang-Barsky
    Function liangBarsky(x1 As Double, y1 As Double, x2 As Double, y2 As Double, cor As Color)

        Dim u1 As Double = 0.0
        Dim u2 As Double = 1.0
        Dim dx As Double = x2 - x1
        Dim dy As Double = y2 - y1

        'remove a reta atual
        apagar(x1, y1, x2, y2)

        If (clipTest(-dx, x1 - xMin, u1, u2)) Then
            If (clipTest(dx, xMax - x1, u1, u2)) Then
                If (clipTest(-dy, y1 - yMin, u1, u2)) Then
                    If (clipTest(dy, yMax - y1, u1, u2)) Then
                        If (u2 < 1) Then
                            x2 = x1 + u2 * dx
                            y2 = y1 + u2 * dy
                        End If
                        If (u1 > 0) Then
                            x1 = x1 + u1 * dx
                            y1 = y1 + u1 * dy
                        End If

                        bresenhamReta(Math.Round(x1), Math.Round(y1), Math.Round(x2), Math.Round(y2), cor)
                        'Adiciona a nova reta à Tabela de retas e coordenadas
                        Dim codigoCor As String = ColorTranslator.ToHtml(cor)
                        tabelaDeRetas.Rows.Add("Reta" + CStr(idRetas), CStr(Math.Round(x1)) + "," + CStr(Math.Round(y1)), CStr(Math.Round(x2)) + "," + CStr(Math.Round(y2)), codigoCor)
                        idRetas += 1

                    End If
                End If
            End If
        End If
    End Function

    Function clipTest(p As Double, q As Double, ByRef u1 As Double, ByRef u2 As Double) As Boolean
        Dim result As Boolean = True
        Dim r As Double
        If (p < 0) Then 'fora para dentro
            r = q / p
            If (r > u2) Then
                result = False
            Else
                If (r > u1) Then
                    u1 = r
                End If
            End If
        Else
            If (p > 0) Then 'dentro para fora
                r = q / p
                If (r < u1) Then
                    result = False
                Else
                    If (r < u2) Then
                        u2 = r
                    End If
                End If
            Else
                If (q < 0) Then
                    result = False
                End If
            End If
        End If

        Return result

    End Function
    '--------------------------- Fim da sessão de preenchimentos e cortes----------------------------------------------------------------------------
End Class

