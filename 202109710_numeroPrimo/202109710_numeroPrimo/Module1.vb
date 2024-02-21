Imports System.IO

Module Module1
    Sub Main()
        Dim opcion As Char = ""
        Dim opcion2 As ConsoleKeyInfo
        Dim numero As Integer
        Dim primo As Boolean = True

        Console.WriteLine("Ingrese su nombre: ")

        Do
            Try
                Console.Clear()
                Console.WriteLine("Bienvenido ")
                Console.WriteLine("-----------------")
                Console.WriteLine("Seleccione una opción del Menú:")
                Console.WriteLine("-----------------")
                Console.WriteLine("1. Determinar si el numero es primo o compuesto")
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
                        Console.WriteLine("Ingrese un número:")
                        numero = Convert.ToInt32(Console.ReadLine())
                        If numero <= 1 Then
                            primo = False
                        Else
                            For i As Integer = 2 To Math.Sqrt(numero)
                                If numero Mod i = 0 Then
                                    primo = False
                                    Exit For
                                End If
                            Next
                        End If
                        If primo Then
                            Console.WriteLine(numero & " es un número primo.")
                        Else
                            Console.WriteLine(numero & " es un número compuesto.")
                        End If
                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        If primo Then
                            historial.WriteLine(numero & " es un número primo.")
                        Else
                            historial.WriteLine(numero & " es un número compuesto.")
                        End If
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
                        Console.WriteLine("Numero consultado")
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