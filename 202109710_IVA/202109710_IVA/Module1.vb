Imports System.IO
Imports System.Runtime.InteropServices.ComTypes

Module Module1
    Sub Main()
        Dim opcion As Char = ""
        Dim opcion2 As ConsoleKeyInfo
        Dim precio, iva, sinIva As Double

        Console.WriteLine("Ingrese su nombre: ")

        Do
            Try
                Console.Clear()
                Console.WriteLine("Bienvenido")
                Console.WriteLine("----------")
                Console.WriteLine("Selecciona una opción")
                Console.WriteLine("1. Consulta el IVA de un precio")
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
                        Console.WriteLine("Ingrese un precio en quetzales ")
                        precio = Console.ReadLine()
                        sinIva = precio / 1.12
                        iva = sinIva * 0.12
                        Console.WriteLine("El IVA es " & iva & " quetzales ")
                        Console.WriteLine("El precio sin IVA es " & sinIva & " quetzales ")

                        Console.ReadKey()

                        Dim historial As StreamWriter
                        historial = File.AppendText("salida.txt")
                        historial.WriteLine("El IVA es: " & iva & " es precio del IVA es: " & sinIva & " en quetzales")
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
                        Console.WriteLine("Historia de consulta")
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