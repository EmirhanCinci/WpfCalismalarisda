﻿Class MainWindow
    Private Sub textEmail_MouseDown(sender As Object, e As MouseButtonEventArgs)
        txtEmail.Focus()
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As TextChangedEventArgs)
        If Not String.IsNullOrEmpty(txtEmail.Text) AndAlso txtEmail.Text.Length > 0 Then
            textEmail.Visibility = Visibility.Collapsed
        Else
            textEmail.Visibility = Visibility.Visible
        End If
    End Sub

    Private Sub textPassword_MouseDown(sender As Object, e As MouseButtonEventArgs)
        txtPassword.Focus()
    End Sub

    Private Sub txtPassword_PasswordChanged(sender As Object, e As RoutedEventArgs)
        If Not String.IsNullOrEmpty(txtPassword.Password) AndAlso txtPassword.Password.Length > 0 Then
            textPassword.Visibility = Visibility.Collapsed
        Else
            textPassword.Visibility = Visibility.Visible
        End If
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        If Not String.IsNullOrEmpty(txtEmail.Text) AndAlso String.IsNullOrEmpty(txtPassword.Password) Then
            MessageBox.Show("Giriş bilgileriniz eksiksiz bir şekilde girilmelidir.", "Uyarı Mesajı")
        End If
    End Sub

    Private Sub Border_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If e.ChangedButton = MouseButton.Left Then
            Me.DragMove()
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
