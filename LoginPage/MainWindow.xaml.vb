Imports System.Net.Http
Imports System.Text
Imports System.Text.Json

Class MainWindow
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
        txtPassword.Focus()
    End Sub

    Private Sub textEmail_MouseDown(sender As Object, e As MouseButtonEventArgs)
        txtEmail.Focus()
    End Sub

    Private Async Sub Button_Click_4(sender As Object, e As RoutedEventArgs)
        Dim apiUrl As String = "https://localhost:7257/api/Users/Login"
        Dim email As String = textEmail.Text
        Dim password As String = textPassword.Text

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

    Private Sub txtEmail_TextChanged(sender As Object, e As TextChangedEventArgs)
        If Not String.IsNullOrEmpty(txtEmail.Text) AndAlso txtEmail.Text.Length > 0 Then
            textEmail.Visibility = Visibility.Collapsed
        Else
            textEmail.Visibility = Visibility.Visible
        End If
    End Sub

    Private Sub txtPassword_PasswordChanged(sender As Object, e As RoutedEventArgs)
        If Not String.IsNullOrEmpty(txtPassword.Password) AndAlso txtPassword.Password.Length > 0 Then
            textPassword.Visibility = Visibility.Collapsed
        Else
            textPassword.Visibility = Visibility.Visible
        End If
    End Sub

    Private Sub Image_MouseUp(sender As Object, e As MouseButtonEventArgs)
        Application.Current.Shutdown()
    End Sub

    Private Sub Image_MouseUp_1(sender As Object, e As MouseButtonEventArgs)
        If WindowState = WindowState.Normal Then
            WindowState = WindowState.Maximized
        Else
            WindowState = WindowState.Normal
        End If
    End Sub

    Private Sub Image_MouseUp_2(sender As Object, e As MouseButtonEventArgs)
        WindowState = WindowState.Minimized
    End Sub
End Class
