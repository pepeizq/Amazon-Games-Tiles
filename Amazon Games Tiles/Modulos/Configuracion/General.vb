Namespace Configuracion
    Module General

        Public Sub Cargar()

            Dim frame As Frame = Window.Current.Content
            Dim pagina As Page = frame.Content

            Dim botonAbrirConfig As Button = pagina.FindName("botonAbrirConfig")

            AddHandler botonAbrirConfig.Click, AddressOf AbrirConfigClick
            AddHandler botonAbrirConfig.PointerEntered, AddressOf Interfaz.EfectosHover.Entra_Boton_IconoTexto
            AddHandler botonAbrirConfig.PointerExited, AddressOf Interfaz.EfectosHover.Sale_Boton_IconoTexto

        End Sub

        Private Sub AbrirConfigClick(sender As Object, e As RoutedEventArgs)

            Dim frame As Frame = Window.Current.Content
            Dim pagina As Page = frame.Content

            Dim gridConfig As Grid = pagina.FindName("gridConfig")

            Dim recursos As New Resources.ResourceLoader()
            Interfaz.Pestañas.Visibilidad(gridConfig, recursos.GetString("Config"), sender)

        End Sub

    End Module
End Namespace