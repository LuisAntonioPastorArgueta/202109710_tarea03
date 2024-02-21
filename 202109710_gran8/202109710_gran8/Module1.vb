Imports System.IO

Module Module1
    Sub Main()
        Dim opcion As Char = ""
        Dim opcion2 As ConsoleKeyInfo
        Dim random As New Random()
        Dim continuar As Boolean = True
        Dim resultado As String

        Do
            Try
                Console.Clear()
                Console.WriteLine("Bienvenido al juego del Gran 8")
                Console.WriteLine("-----------------")
                Console.WriteLine("Seleccione una opción del Menú:")
                Console.WriteLine("1. JUGAR")
                Console.WriteLine("2. Ver historial")
                Console.WriteLine("3. Borrar historial")
                Console.WriteLine("4. Salir")
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
                        While continuar
                            Dim dado1 As Integer = random.Next(1, 7)
                            Dim dado2 As Integer = random.Next(1, 7)
                            Dim suma As Integer = dado1 + dado2
                            Console.WriteLine("Presiona cualquier tecla para lanzar los dados...")
                            Console.ReadKey()

                            Console.WriteLine("Has lanzado: " & (dado1) & " y " & (dado2))
                            Console.WriteLine("La suma es: " & (suma))

                            If suma = 8 Then
                                Console.WriteLine("¡Ganaste!")
                                continuar = False
                                resultado = ("Ganaste")
                            ElseIf suma = 7 Then
                                Console.WriteLine("¡Perdiste!")
                                resultado = ("perdiste")
                                continuar = False
                            Else
                                Console.WriteLine("Sigue lanzando...")
                            End If
                        End While
                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        historial.WriteLine("El lanzamiento fue: " & (resultado))
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial.")
                        Console.WriteLine("------------------------------------")
                        Console.WriteLine("Presione cualquier tecla para volver")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "2"
                    Console.Clear()
                    Try
                        Dim historial As StreamReader
                        historial = File.OpenText("salida.txt")
                        Console.WriteLine("Historial de intentos")
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
                Case "3"
                    Dim historial As String = "salida.txt"
                    File.Delete(historial)
                    Console.WriteLine("Borrar historial")
                    Console.ReadKey()
                Case "4"
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
