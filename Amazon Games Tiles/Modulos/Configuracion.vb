Imports Windows.System

Module Configuracion

    Public Sub Cargar()

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim botonAbrirConfig As Button = pagina.FindName("botonAbrirConfig")

        AddHandler botonAbrirConfig.Click, AddressOf AbrirConfigClick
        AddHandler botonAbrirConfig.PointerEntered, AddressOf Interfaz.EfectosHover.Entra_Boton_IconoTexto
        AddHandler botonAbrirConfig.PointerExited, AddressOf Interfaz.EfectosHover.Sale_Boton_IconoTexto

        Dim botonConfigOpcion As Button = pagina.FindName("botonConfigOpcion")

        AddHandler botonConfigOpcion.Click, AddressOf AbrirOpcionClick
        AddHandler botonConfigOpcion.PointerEntered, AddressOf Interfaz.EfectosHover.Entra_Boton_IconoTexto
        AddHandler botonConfigOpcion.PointerExited, AddressOf Interfaz.EfectosHover.Sale_Boton_IconoTexto

        Dim botonConfigImagen As Button = pagina.FindName("botonConfigImagen")

        AddHandler botonConfigImagen.Click, AddressOf AbrirImagenClick
        AddHandler botonConfigImagen.PointerEntered, AddressOf Interfaz.EfectosHover.Entra_Boton_IconoTexto
        AddHandler botonConfigImagen.PointerExited, AddressOf Interfaz.EfectosHover.Sale_Boton_IconoTexto

        Dim botonBuscarCarpetaAmazon As Button = pagina.FindName("botonBuscarCarpetaAmazon")

        AddHandler botonBuscarCarpetaAmazon.Click, AddressOf BuscarAmazonClick
        AddHandler botonBuscarCarpetaAmazon.PointerEntered, AddressOf Interfaz.EfectosHover.Entra_Boton_IconoTexto
        AddHandler botonBuscarCarpetaAmazon.PointerExited, AddressOf Interfaz.EfectosHover.Sale_Boton_IconoTexto

    End Sub

    Private Sub AbrirConfigClick(sender As Object, e As RoutedEventArgs)

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim gridConfig As Grid = pagina.FindName("gridConfig")

        Dim recursos As New Resources.ResourceLoader()
        Interfaz.Pestañas.Visibilidad_Pestañas(gridConfig, recursos.GetString("Config"))

    End Sub

    Private Async Sub AbrirOpcionClick(sender As Object, e As RoutedEventArgs)

        Await Launcher.LaunchUriAsync(New Uri(“ms-settings:privacy-broadfilesystemaccess”))

    End Sub

    Private Sub AbrirImagenClick(sender As Object, e As RoutedEventArgs)

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim grid As Grid = pagina.FindName("gridConfigImagen")
        Dim icono As FontAwesome5.FontAwesome = pagina.FindName("iconoConfigImagen")

        If grid.Visibility = Visibility.Collapsed Then
            grid.Visibility = Visibility.Visible
            icono.Icon = FontAwesome5.EFontAwesomeIcon.Solid_AngleDoubleUp
        Else
            grid.Visibility = Visibility.Collapsed
            icono.Icon = FontAwesome5.EFontAwesomeIcon.Solid_AngleDoubleDown
        End If

    End Sub

    Private Sub BuscarAmazonClick(sender As Object, e As RoutedEventArgs)

        Amazon.Generar(True)

    End Sub

    Public Sub Estado(estado As Boolean)

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim botonAbrirConfig As Button = pagina.FindName("botonAbrirConfig")
        botonAbrirConfig.IsEnabled = estado

        Dim botonBuscarCarpetaAmazon As Button = pagina.FindName("botonBuscarCarpetaAmazon")
        botonBuscarCarpetaAmazon.IsEnabled = estado

    End Sub

End Module