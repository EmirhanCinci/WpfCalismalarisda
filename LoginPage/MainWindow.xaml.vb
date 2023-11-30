Imports System.Net.Http
Imports System.Text
Imports System.Text.Json
Class MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Application.Current.Shutdown()
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Linkedin", "Bilgi Mesajı")
    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Google", "Bilgi Mesajı")
    End Sub

    Private Sub Button_Click_3(sender As Object, e As RoutedEventArgs)
        MessageBox.Show("Linkedin 2", "Bilgi Mesajı")
    End Sub

    Private Sub textPassword_MouseDown(sender As Object, e As MouseButtonEventArgs)

    End Sub

    Private Sub textEmail_MouseDown(sender As Object, e As MouseButtonEventArgs)

    End Sub

    Private Async Sub Button_Click_4(sender As Object, e As RoutedEventArgs)
        Dim apiUrl As String = "https://localhost:7257/api/Users/Login"
        Dim email As String = textEmail.Text
        Dim password As String = textPassword.Password

        Using httpClient As New HttpClient()
            Dim loginData As New With {
                .email = email,
                .password = password
            }
            Dim jsonContent As String = JsonSerializer.Serialize(loginData)
            Dim content As New StringContent(jsonContent, Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await httpClient.PostAsync(apiUrl, content)
            If response.IsSuccessStatusCode Then
                Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                MessageBox.Show("Başarılı bir şekilde giriş yapıldı.", "Bilgi Mesajı")
            Else
                MessageBox.Show("Başarısız Deneme.", "Uyarı Mesajı")
            End If
        End Using
    End Sub
End Class
