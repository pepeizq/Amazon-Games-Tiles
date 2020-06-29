Imports SQLite.Net.Attributes

<Table("DbSet")>
Public Class AmazonDB

    <Column("ProductTitle")>
    Public Property Titulo As String

    <Column("ProductIdStr")>
    Public Property ID As String

    <Column("ProductIconUrl")>
    Public Property Imagen As String

End Class
