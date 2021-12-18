
Public Class NPEFuntions

    Public Function BornNPE(xNPE As String) As String

        'Arreglos
        Dim Posiciones(34)
        Dim Impar(17)
        Dim SumaImp(17)
        Dim Total(17)
        Dim Marcelo(17)
        Dim gTotal, Impares As Integer
        Dim respuesta As String

        Impares = 34
        Dim StringLength = Len(xNPE)

        For i = 1 To StringLength
            Posiciones(i) = Mid(xNPE, i, 1)
        Next i

        'Dim one = 0
        Dim contador = 0
        Dim back = 0
        gTotal = 0

        For i = 1 To Impares Step 2
            contador = contador + 1
            Impar(contador) = Posiciones(i) * 2

            If i = 34 Then
                SumaImp(contador) = Impar(contador)
            Else
                SumaImp(contador) = Impar(contador) + IIf(Len(RTrim(Str(Impar(contador)))) > 2, 1, 0)
            End If

            Total(contador) = Posiciones(back)

            Marcelo(contador) = SumaImp(contador) + Total(contador)

            gTotal = gTotal + Marcelo(contador)

            back = back + 2

        Next i


        Dim x = RTrim(Str(Math.Round(gTotal)))
        Dim y = Mid(x, Len(x), 1)

        If y = 0 Then
            respuesta = "0"
        Else
            respuesta = (gTotal + (10 - y)) - gTotal
            respuesta = RTrim(Str(Math.Round(Double.Parse(respuesta))))
        End If

        Trim(respuesta)
        BornNPE = respuesta

    End Function

    Public Function divNPE(Body As String, Veri As String) As String
        Dim xBody, xVeri, Union, Union1 As String

        xBody = LTrim(Body)
        xVeri = LTrim(Veri)

        Union1 = xBody & xVeri

        For x = 1 To 36 Step 4
            Union = Union & Mid(Union1, x, 4) & " "
        Next x

        divNPE = Union

    End Function

End Class
