Imports System.IO

Module Module1
    Sub Main(args As String())
        Dim opcion As Char = ""
        Dim opcion2 As ConsoleKeyInfo
        Dim numeros(100) As Integer
        Dim suma As Integer = 0
        Dim media As Double
        Dim mediana As Integer
        Dim moda As Integer
        Dim rango As Integer
        Dim desviacion As Double
        Dim varianza As Double

        For i As Integer = 0 To 100
            numeros(i) = i
        Next

        Do
            Try
                Console.Clear()
                Console.WriteLine("Bienvenido, seleccione una opción:")
                Console.WriteLine("-----------------")
                Console.WriteLine("Seleccione la operación a realizar")
                Console.WriteLine("1. MEDIA")
                Console.WriteLine("2. MEDIANA")
                Console.WriteLine("3. MODA")
                Console.WriteLine("4. RANGO")
                Console.WriteLine("5. DESVIACIÓN ESTANDAR")
                Console.WriteLine("6. VARIANZA")
                Console.WriteLine("7. Ver historial")
                Console.WriteLine("8. Borrar historial")
                Console.WriteLine("9. Salir")
                opcion2 = Console.ReadKey()
                opcion = opcion2.KeyChar
                Console.Clear()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            Select Case opcion
                Case "1"
                    Try
                        Console.Clear()
                        For i As Integer = 0 To 100
                            suma += numeros(i)
                        Next
                        media = suma / 101
                        Console.WriteLine("La media de las calificaciones es: " & media)
                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        historial.WriteLine("La media es: " & media)
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial.")
                        Console.WriteLine("------------------------------------")
                        Console.WriteLine("Presione cualquier tecla para volver")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "2"
                    Try
                        Console.Clear()
                        Array.Sort(numeros)
                        mediana = numeros(50)
                        Console.WriteLine("La mediana de las calificaciones es: " & mediana)
                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        historial.WriteLine("La mediana es: " & mediana)
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial.")
                        Console.WriteLine("------------------------------------")
                        Console.WriteLine("Presione cualquier tecla para volver")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "3"
                    Try
                        Console.Clear()
                        Dim contador(101) As Integer
                        For i As Integer = 0 To 100
                            contador(numeros(i)) += 1
                        Next
                        Dim maxContador As Integer = 0
                        For i As Integer = 0 To 100
                            If contador(i) > maxContador Then
                                maxContador = contador(i)
                                moda = i
                            End If
                        Next
                        Console.WriteLine("La moda de las calificaciones es: " & moda)
                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        historial.WriteLine("La moda es: " & moda)
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial.")
                        Console.WriteLine("------------------------------------")
                        Console.WriteLine("Presione cualquier tecla para volver")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "4"
                    Try
                        Console.Clear()
                        rango = numeros(100) - numeros(0)
                        Console.WriteLine("El rango de las calificaciones es: " & rango)
                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        historial.WriteLine("El rango es: " & rango)
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial.")
                        Console.WriteLine("------------------------------------")
                        Console.WriteLine("Presione cualquier tecla para volver")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "5"
                    Try
                        Console.Clear()
                        Dim sumaDifCuadrado As Double = 0
                        For i As Integer = 0 To 100
                            sumaDifCuadrado += (numeros(i) - media) ^ 2
                        Next
                        desviacion = Math.Sqrt(sumaDifCuadrado / 101)
                        Console.WriteLine("La desviación estándar de las calificaciones es: " & desviacion)
                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        historial.WriteLine("La desviación estándar es: " & desviacion)
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial.")
                        Console.WriteLine("------------------------------------")
                        Console.WriteLine("Presione cualquier tecla para volver")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "6"
                    Try
                        Console.Clear()
                        Dim sumaDifCuadrado As Double = 0
                        For i As Integer = 0 To 100
                            sumaDifCuadrado += (numeros(i) - media) ^ 2
                        Next
                        varianza = sumaDifCuadrado / 101
                        Console.WriteLine("La varianza de las calificaciones es: " & varianza)
                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        historial.WriteLine("La varianza es: " & varianza)
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial.")
                        Console.WriteLine("------------------------------------")
                        Console.WriteLine("Presione cualquier tecla para volver")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "7"
                    Console.Clear()
                    Try
                        Dim historial As StreamReader
                        historial = File.OpenText("salida.txt")
                        Console.WriteLine("Historial de estadísticos descriptivos: ")
                        Do Until historial.EndOfStream
                            Console.WriteLine(historial.ReadLine())
                        Loop
                        historial.Close()
                    Catch ex As FileNotFoundException
                        Console.WriteLine("El archivo de historial no existe.”)
                    End Try
                    Console.WriteLine("")
                    Console.WriteLine("Presione cualquier tecla")
                    Console.ReadKey()
                Case "8"
                    Dim historial As String = "salida.txt"
                    File.Delete(historial)
                    Console.WriteLine("Borrar historial")
                    Console.ReadKey()
                Case "9"
                    Console.Clear()
                    Console.WriteLine("¡Hasta pronto!")
                    Exit Do
                    Console.ReadKey()
                Case Else
                    Console.WriteLine("Opción no válida.”)
            End Select
        Loop
    End Sub
End Module
