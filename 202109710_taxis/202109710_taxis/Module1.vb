Imports System.IO
Module Module1
    Sub Main()
        Dim opcion As Char = ""
        Dim opcion2 As ConsoleKeyInfo
        Dim modelo, recorrido As Integer
        Dim estado As String
        Do
            Try
                Console.Clear()
                Console.WriteLine("¡Bienvenido!")
                Console.WriteLine("Menú de opciones:")
                Console.WriteLine("1. Consultar información de taxi")
                Console.WriteLine("2. Ver historial")
                Console.WriteLine("3. Borrar historial")
                Console.WriteLine("4. Salir")
                Console.WriteLine("Seleccione una opción:")
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
                        Console.WriteLine("Ingrese el modelo (año):")
                        modelo = Console.ReadLine()
                        Console.WriteLine("Ingrese el recorrido del taxi (km):")
                        recorrido = Console.ReadLine()
                        If modelo < 2007 AndAlso recorrido > 20000 Then
                            Console.WriteLine("El taxi debe renovarse")
                            estado = ("Renovación")
                        ElseIf modelo >= 2007 AndAlso modelo <= 2013 AndAlso recorrido = 20000 Then
                            Console.WriteLine("El taxi debe recibir mantenimiento")
                            estado = ("Mantenimiento")
                        ElseIf modelo > 2013 AndAlso recorrido < 10000 Then
                            Console.WriteLine("El taxi está en óptimas condiciones")
                            estado = ("Óptimo")
                        Else
                            Console.WriteLine("Mecánico")
                            estado = ("Mecánico")
                        End If
                        Dim historial As StreamWriter
                        historial = File.AppendText("historial_imc.txt")
                        historial.WriteLine("Modelo: " & modelo & ", recorrido: " & recorrido & ", estado " & estado)
                        historial.Close()
                        Console.WriteLine("Resultado guardado en el historial.")
                    Catch ex As DivideByZeroException
                        Console.WriteLine("La altura no puede ser cero.")
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.ReadKey()
                Case "2"
                    Console.Clear()
                    Try
                        Dim historial As StreamReader
                        historial = File.OpenText("historial_imc.txt")
                        Console.WriteLine("Modelo, recorrido, estado")
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
                    Dim historial As String = "historial_imc.txt"
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
