Imports Amazon_Games_Tiles.Configuracion
Imports Amazon_Games_Tiles.Interfaz
Imports Microsoft.Toolkit.Uwp.Helpers
Imports Microsoft.Toolkit.Uwp.UI.Controls
Imports Windows.UI
Imports Windows.UI.Xaml.Media.Animation

Module Amazon

    Public anchoColumna As Integer = 180
    Dim clave As String = "AmazonFichero"
    Dim dominioImagenes As String = "https://cdn.cloudflare.steamstatic.com"

    Public Async Sub Generar(buscarFichero As Boolean)

        Dim helper As New LocalObjectStorageHelper

        Dim recursos As New Resources.ResourceLoader()

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Cache.Estado(False)
        LimpiezaArchivos.Estado(False)

        Dim gv As AdaptiveGridView = pagina.FindName("gvTiles")
        gv.DesiredWidth = anchoColumna
        gv.Items.Clear()

        Dim listaJuegos As New List(Of Tile)

        If Await helper.FileExistsAsync("juegos") = True Then
            listaJuegos = Await helper.ReadFileAsync(Of List(Of Tile))("juegos")
        End If

        If listaJuegos Is Nothing Then
            listaJuegos = New List(Of Tile)
        End If

        '-------------------------------------------------------------

        Dim gridProgreso As Grid = pagina.FindName("gridProgreso")
        Pestañas.Visibilidad(gridProgreso, Nothing, Nothing)

        Dim pbProgreso As ProgressBar = pagina.FindName("pbProgreso")
        pbProgreso.Value = 0

        Dim tbProgreso As TextBlock = pagina.FindName("tbProgreso")
        tbProgreso.Text = String.Empty

        Dim listaBBDD As List(Of AmazonBBDDJuego) = AmazonBBDD.Listado
        Dim k As Integer = 0

        For Each juegoBBDD In listaBBDD
            Dim imagenPequeña As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDAmazon, "pequeña")
            Dim imagenMediana As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDAmazon, "mediana")
            Dim imagenAncha As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDAmazon, "ancha")
            Dim imagenGrande As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDAmazon, "grande")

            If Not juegoBBDD.IDSteam = Nothing Then
                If imagenMediana = String.Empty Then
                    Try
                        imagenMediana = Await Cache.DescargarImagen(dominioImagenes + "/steam/apps/" + juegoBBDD.IDSteam + "/logo.png", juegoBBDD.IDAmazon, "mediana")
                    Catch ex As Exception

                    End Try
                End If

                If imagenAncha = String.Empty Then
                    Try
                        imagenAncha = Await Cache.DescargarImagen(dominioImagenes + "/steam/apps/" + juegoBBDD.IDSteam + "/header.jpg", juegoBBDD.IDAmazon, "ancha")
                    Catch ex As Exception

                    End Try
                End If

                If imagenGrande = String.Empty Then
                    Try
                        imagenGrande = Await Cache.DescargarImagen(dominioImagenes + "/steam/apps/" + juegoBBDD.IDSteam + "/library_600x900.jpg", juegoBBDD.IDAmazon, "grande")
                    Catch ex As Exception

                    End Try
                End If
            End If

            Dim tile As New Tile(juegoBBDD.Titulo, juegoBBDD.IDAmazon, juegoBBDD.IDSteam, "amazon-games://play/amzn1.adg.product." + juegoBBDD.IDAmazon, imagenPequeña, imagenMediana, imagenAncha, imagenGrande)

            listaJuegos.Add(tile)

            pbProgreso.Value = CInt((100 / listaBBDD.Count) * k)
            tbProgreso.Text = k.ToString + "/" + listaBBDD.Count.ToString
            k += 1
        Next

        Dim resultadosBusqueda As New List(Of Interfaz.BusquedaFichero)

        If Not listaJuegos Is Nothing Then
            If listaJuegos.Count > 0 Then
                For Each juego In listaJuegos
                    If Not juego Is Nothing Then
                        Try
                            If Await helper.FileExistsAsync("Juegos\juego_" + juego.IDAmazon) = False Then
                                Await helper.SaveFileAsync(Of Tile)("Juegos\juego_" + juego.IDAmazon, juego)
                            End If
                        Catch ex As Exception

                        End Try

                        resultadosBusqueda.Add(New Interfaz.BusquedaFichero(juego.Titulo, "Juegos\juego_" + juego.IDAmazon))
                    End If
                Next
            End If
        End If

        Try
            Await helper.SaveFileAsync(Of List(Of Interfaz.BusquedaFichero))("busqueda", resultadosBusqueda)
        Catch ex As Exception

        End Try

        If Not listaJuegos Is Nothing Then
            If listaJuegos.Count > 0 Then
                Dim gridJuegos As Grid = pagina.FindName("gridJuegos")
                Interfaz.Pestañas.Visibilidad(gridJuegos, recursos.GetString("Games"), Nothing)

                listaJuegos.Sort(Function(x, y)
                                     If Not x Is Nothing Then
                                         If Not y Is Nothing Then
                                             Return x.Titulo.CompareTo(y.Titulo)
                                         End If
                                     End If

                                     If Not x Is Nothing Then
                                         Return x.Titulo
                                     End If

                                     If Not y Is Nothing Then
                                         Return y.Titulo
                                     End If

                                     Return Nothing
                                 End Function)

                gv.Items.Clear()

                For Each juego In listaJuegos
                    BotonEstilo(juego, gv)
                Next
            Else
                Dim gridAvisoNoJuegos As Grid = pagina.FindName("gridAvisoNoJuegos")
                Interfaz.Pestañas.Visibilidad(gridAvisoNoJuegos, Nothing, Nothing)
            End If
        Else
            Dim gridAvisoNoJuegos As Grid = pagina.FindName("gridAvisoNoJuegos")
            Interfaz.Pestañas.Visibilidad(gridAvisoNoJuegos, Nothing, Nothing)
        End If

        Cache.Estado(True)
        LimpiezaArchivos.Estado(True)

    End Sub

    Public Sub BotonEstilo(juego As Tile, gv As GridView)

        Dim imagen As New ImageEx With {
            .Source = juego.ImagenGrande,
            .IsCacheEnabled = True,
            .Stretch = Stretch.UniformToFill,
            .Padding = New Thickness(0, 0, 0, 0),
            .HorizontalAlignment = HorizontalAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Center,
            .EnableLazyLoading = True
        }

        Dim boton As New Button With {
            .Tag = juego,
            .Content = imagen,
            .Padding = New Thickness(0, 0, 0, 0),
            .Background = New SolidColorBrush(Colors.Transparent),
            .Margin = New Thickness(10, 10, 10, 10),
            .MinHeight = 40,
            .MinWidth = 40,
            .MaxWidth = anchoColumna + 20,
            .BorderBrush = New SolidColorBrush(App.Current.Resources("ColorPrimario")),
            .BorderThickness = New Thickness(1, 1, 1, 1),
            .HorizontalAlignment = HorizontalAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Center
        }

        Dim tbToolTip As TextBlock = New TextBlock With {
            .Text = juego.Titulo,
            .FontSize = 16,
            .TextWrapping = TextWrapping.Wrap
        }

        ToolTipService.SetToolTip(boton, tbToolTip)
        ToolTipService.SetPlacement(boton, PlacementMode.Mouse)

        AddHandler boton.Click, AddressOf BotonTile_Click
        AddHandler boton.PointerEntered, AddressOf Interfaz.Entra_Boton_Imagen
        AddHandler boton.PointerExited, AddressOf Interfaz.Sale_Boton_Imagen

        gv.Items.Add(boton)

    End Sub

    Private Sub BotonTile_Click(sender As Object, e As RoutedEventArgs)

        Trial.Detectar()
        Interfaz.AñadirTile.ResetearValores()

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim botonJuego As Button = e.OriginalSource
        Dim juego As Tile = botonJuego.Tag

        Dim botonAñadirTile As Button = pagina.FindName("botonAñadirTile")
        botonAñadirTile.Tag = juego

        Dim imagenJuegoSeleccionado As ImageEx = pagina.FindName("imagenJuegoSeleccionado")
        imagenJuegoSeleccionado.Source = juego.ImagenAncha

        Dim tbJuegoSeleccionado As TextBlock = pagina.FindName("tbJuegoSeleccionado")
        tbJuegoSeleccionado.Text = juego.Titulo

        Dim gridAñadirTile As Grid = pagina.FindName("gridAñadirTile")
        Interfaz.Pestañas.Visibilidad(gridAñadirTile, juego.Titulo, Nothing)

        '---------------------------------------------

        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("animacionJuego", botonJuego)
        Dim animacion As ConnectedAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("animacionJuego")

        If Not animacion Is Nothing Then
            animacion.Configuration = New BasicConnectedAnimationConfiguration
            animacion.TryStart(gridAñadirTile)
        End If

        '---------------------------------------------

        Dim tbImagenTituloTextoTileAncha As TextBox = pagina.FindName("tbImagenTituloTextoTileAncha")
        tbImagenTituloTextoTileAncha.Text = juego.Titulo
        tbImagenTituloTextoTileAncha.Tag = juego.Titulo

        Dim tbImagenTituloTextoTileGrande As TextBox = pagina.FindName("tbImagenTituloTextoTileGrande")
        tbImagenTituloTextoTileGrande.Text = juego.Titulo
        tbImagenTituloTextoTileGrande.Tag = juego.Titulo

        '---------------------------------------------

        Dim imagenPequeña As ImageEx = pagina.FindName("imagenTilePequeña")
        imagenPequeña.Source = Nothing

        Dim imagenMediana As ImageEx = pagina.FindName("imagenTileMediana")
        imagenMediana.Source = Nothing

        Dim imagenAncha As ImageEx = pagina.FindName("imagenTileAncha")
        imagenAncha.Source = Nothing

        Dim imagenGrande As ImageEx = pagina.FindName("imagenTileGrande")
        imagenGrande.Source = Nothing

        If Not juego.ImagenPequeña = Nothing Then
            imagenPequeña.Source = juego.ImagenPequeña
            imagenPequeña.Tag = juego.ImagenPequeña
        End If

        If Not juego.ImagenMediana = Nothing Then
            imagenMediana.Source = juego.ImagenMediana
            imagenMediana.Tag = juego.ImagenMediana
        End If

        If Not juego.ImagenAncha = Nothing Then
            imagenAncha.Source = juego.ImagenAncha
            imagenAncha.Tag = juego.ImagenAncha
        End If

        If Not juego.ImagenGrande = Nothing Then
            imagenGrande.Source = juego.ImagenGrande
            imagenGrande.Tag = juego.ImagenGrande
        End If

    End Sub

End Module
