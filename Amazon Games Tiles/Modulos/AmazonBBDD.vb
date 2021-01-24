Module AmazonBBDD

    Public Function Listado()
        Dim lista As New List(Of AmazonBBDDJuego) From {
           New AmazonBBDDJuego("A Knight's Quest", "782d4c40-a964-436b-9d4c-a86d5f1b5787", Nothing),
           New AmazonBBDDJuego("Algo Bot", "e10a6883-3afc-4e14-ba19-6fd0e208677e", "286300"),
           New AmazonBBDDJuego("Along the Edge", "be2368f5-06d1-4f64-b9f2-e2f896e14bf2", "504390"),
           New AmazonBBDDJuego("Alt Frequencies", "372f336e-2387-40db-8ff1-4d2fd218aeb6", "1035050"),
           New AmazonBBDDJuego("Art of Fighting 2", "a9670805-c3fc-4c06-a949-afc0b410756c", Nothing),
           New AmazonBBDDJuego("Aurion: Legacy of the Kori-Odan", "e717af74-a0df-4f4a-a415-887af44c3bb4", "368080"),
           New AmazonBBDDJuego("Autonauts", "d05de3bb-6234-423b-a96d-2cd48d78bd31", "979120"),
           New AmazonBBDDJuego("Baseball Stars 2", "ec16febb-a04e-44d0-8134-27c894f0f985", "366230"),
           New AmazonBBDDJuego("Blazing Chrome", "75790de1-8b94-447d-8c1a-28393eb47215", "609110"),
           New AmazonBBDDJuego("Blazing Star", "30af9c0e-6dfa-457a-a8af-eab5f243ea80", Nothing),
           New AmazonBBDDJuego("Bridge Constructor", "163db846-013b-41cd-bfae-c6033d67f2d9", "250460"),
           New AmazonBBDDJuego("Bridge Constructor Medieval", "ee62e5c5-bb8a-4e92-be8b-8ae9bb3ec0ee", "319850"),
           New AmazonBBDDJuego("Bridge Constructor Playground", "90dd5458-e86e-4324-b129-541d4649587b", "279990"),
           New AmazonBBDDJuego("Chroma Squad", "2ee6b231-e74f-4d55-b04b-3acc8816d6b7", "251130"),
           New AmazonBBDDJuego("Close to the Sun", "01c9088e-3278-4634-89d6-2a5074b64296", "968870"),
           New AmazonBBDDJuego("Cyber Hook", "16fad9ee-75fc-4342-9eb2-e6f526fdddc9", "1130410"),
           New AmazonBBDDJuego("Darkside Detective", "9242e234-46a5-4b48-b67c-3795b4c30067", "368390"),
           New AmazonBBDDJuego("Day of the Tentacle", "d96d188b-283a-44e1-8402-1fbf3f1f2d72", "388210"),
           New AmazonBBDDJuego("Dead Age", "0f7fa0ea-639f-4ffa-a79e-9551ab193203", "363930"),
           New AmazonBBDDJuego("Deadlight: Director's Cut", "bb3a962e-180e-47c2-b2ea-9790fd7d521f", "423950"),
           New AmazonBBDDJuego("Deponia", "26dcc8a0-cc0d-4ca3-98f3-9e7f442f9916", "214340"),
           New AmazonBBDDJuego("DubWars", "cf14c339-f4fd-4ace-b066-9803987be077", "290000"),
           New AmazonBBDDJuego("Effie", "b302b6a1-5b98-4146-a944-491982086556", "975950"),
           New AmazonBBDDJuego("Extreme Exorcism", "c9650db1-2e89-40cf-a593-973cff69e367", "334100"),
           New AmazonBBDDJuego("Fatal Fury Special", "67b7a89f-69e8-4b4d-a0a6-80a5bb6f1f75", Nothing),
           New AmazonBBDDJuego("Frozen Cortex", "58076754-0dff-4e07-94c1-9e81060e2f04", "237350"),
           New AmazonBBDDJuego("Garou", "9ebdf97d-7f3e-4235-9412-4ea3c8d133f5", "366240"),
           New AmazonBBDDJuego("Genesis Alpha One Deluxe Edition", "7d0c58f3-6fb1-471e-9d78-00d48f237410", "712190"),
           New AmazonBBDDJuego("Gone Home", "f41d91c5-83b4-40e1-869e-01a0d6056f97", "232430"),
           New AmazonBBDDJuego("HyperDot", "1099aa20-6956-41ac-8a5a-e6624d2a05b1", "876500"),
           New AmazonBBDDJuego("Impulsion", "99d6f109-8e0a-46ec-93bc-59fdeac739de", "811270"),
           New AmazonBBDDJuego("Ironcast", "82aa61fa-70b0-4550-87be-6f35cdaea38e", "327670"),
           New AmazonBBDDJuego("Ironclad", "fa610758-0d0f-4af2-a17c-caf61177cfe7", Nothing),
           New AmazonBBDDJuego("Jay and Silent Bob: Mall Brawl", "f975231e-641b-496c-865c-ef14b31b507a", "1087440"),
           New AmazonBBDDJuego("King of the Monsters", "8f4bf0e4-4bda-42ca-851c-8523badc979c", Nothing),
           New AmazonBBDDJuego("KONA", "e3477a8d-b638-434b-b4d0-559d5610059d", "365160"),
           New AmazonBBDDJuego("Layers of Fear", "345b53a8-5464-427e-9e59-82280938934b", "391720"),
           New AmazonBBDDJuego("Lethis - Path of Progress", "7700e4ce-5d73-4962-bc3a-431e01a7e95c", "359230"),
           New AmazonBBDDJuego("Lost Horizon", "8bf7e683-9157-46e4-9744-2a8729841a12", "40350"),
           New AmazonBBDDJuego("Metal Slug 2", "fbcc4aaa-a6f1-469c-b34e-dc65756f7141", "366260"),
           New AmazonBBDDJuego("Metal Slug 3", "661f739f-90e4-49eb-a79d-8b50d8fef1e0", "250180"),
           New AmazonBBDDJuego("Outcast Second Contact", "b3c36d32-49d9-4038-b7f3-a1ae9aa79c66", "618970"),
           New AmazonBBDDJuego("Overcooked!", "a3f5ee11-7f45-4cf2-9dd9-642fb2597124", "448510"),
           New AmazonBBDDJuego("Pulstar", "dcece97c-dedf-4090-affd-58f3f0ae839a", Nothing),
           New AmazonBBDDJuego("Pumped BMX Pro", "eeb2fd4c-e7aa-4e73-a1d4-071b90e1060d", "966720"),
           New AmazonBBDDJuego("Q.U.B.E. 2", "b6dae532-9785-4db3-9364-2da90271cbf8", "359100"),
           New AmazonBBDDJuego("Samurai Shodown II", "05996bea-0bdf-42a9-970b-02c76b663ca9", Nothing),
           New AmazonBBDDJuego("Samurai Shodown V Special", "c7827e1e-8182-4d9e-bfe1-c625e7b2603b", "1076550"),
           New AmazonBBDDJuego("Sengoku 3", "cfe75f9c-4583-4efd-842a-a927958ae86e", Nothing),
           New AmazonBBDDJuego("SEUM: Speedrunners from Hell", "80be6c5e-7328-471c-924e-b4e9eb75d512", "457210"),
           New AmazonBBDDJuego("Shaq Fu 2", "969ae4a5-eb89-4ae8-858a-182a0ff9194e", "496040"),
           New AmazonBBDDJuego("Sheltered", "e7c6de90-7b14-4bbf-b722-162f40d77acd", "356040"),
           New AmazonBBDDJuego("Shock Troopers", "09c9b422-1e05-4da7-8307-42dcb2a9877e", "366270"),
           New AmazonBBDDJuego("Shock Troopers: 2nd Squad", "6350f1e0-29e9-4186-af20-d9c6d95e6032", "465870"),
           New AmazonBBDDJuego("Sigma Theory: Global Cold War", "a947fa3c-3317-4a96-b06d-3f671d81c44d", "716640"),
           New AmazonBBDDJuego("Silver Chains", "02eb9df3-491c-4c96-b509-3dc837f3916d", "975470"),
           New AmazonBBDDJuego("Smoke and Sacrifice", "a1597314-37f8-4ed9-a31c-767bdcf6436e", "695100"),
           New AmazonBBDDJuego("SNK 40th Anniversary Collection", "cdbe10a3-63e6-4efa-837c-6238631cddd1", "865940"),
           New AmazonBBDDJuego("Stick it to the Man", "ad9998ac-f86d-488e-8d63-727b2d781429", "251830"),
           New AmazonBBDDJuego("Surf World Series", "935097f4-3cea-4e41-b22e-b20edb41e0dd", "462640"),
           New AmazonBBDDJuego("Sword Legacy Omen", "25071895-d6cb-49ce-98fe-4a2c3c92b9fc", "690140"),
           New AmazonBBDDJuego("System Shock 2", "da725ca3-04b9-403d-a520-851b66322098", "238210"),
           New AmazonBBDDJuego("Tempest", "864eddfc-f0ae-4aa2-a64a-9007bef4abb4", "418180"),
           New AmazonBBDDJuego("The Flame In The Flood", "d43e7ff9-3b1a-448d-8835-572fe729c157", "318600"),
           New AmazonBBDDJuego("The Inner World", "17717725-268b-468a-bfa4-674657464d3d", "251430"),
           New AmazonBBDDJuego("The King of Fighters 2000", "82d8ca92-26ed-4d0a-9ed8-b990c67727d6", Nothing),
           New AmazonBBDDJuego("The King of Fighters 2002", "e9144f0f-a84c-43fd-9280-02b572609706", Nothing),
           New AmazonBBDDJuego("The King of Fighters 2002 Unlimited Match", "cd488e76-7247-4087-b418-06faaac5e958", "222440"),
           New AmazonBBDDJuego("The King of Fighters '97 Global Match", "704bc6ca-518d-4284-8604-9bd8fa94599e", "702120"),
           New AmazonBBDDJuego("The King of Fighters '98 Ultimate Match", "756758e1-80ec-4564-a100-b9417d1aed0a", "222420"),
           New AmazonBBDDJuego("The Last Blade 2", "eedaf213-ce16-4343-8133-cea98fc9126d", "702110"),
           New AmazonBBDDJuego("The Occupation", "53c1e73d-af16-48c6-bb3f-4db8cc3e8753", "765880"),
           New AmazonBBDDJuego("The Spectrum Retreat", "99b3c529-785f-4b7d-b448-1a25d4b3d21c", "763250"),
           New AmazonBBDDJuego("Tiny Troopers Joint Ops", "0b2fc570-5632-44c3-8d83-0901f144268b", Nothing),
           New AmazonBBDDJuego("Treachery In Beatdown City", "5f35c569-55f6-4965-8230-a3775ff949a2", "762180"),
           New AmazonBBDDJuego("Truberbrook", "ab770290-3067-45d0-9b10-5aa0d3475a68", "757300"),
           New AmazonBBDDJuego("Turmoil", "9f710b74-9960-4411-bdfc-3cd846ca812c", "361280"),
           New AmazonBBDDJuego("Victor Vran Overkill Edition", "da7d2f0c-fd75-4b14-81dc-346d109220e7", "345180"),
           New AmazonBBDDJuego("Void Bastards", "c9d1ea59-a0d8-4244-9289-69ab221e4db5", "857980"),
           New AmazonBBDDJuego("Vostok", "6c7be799-12fb-4f2d-8f6b-844483e42af8", "656460"),
           New AmazonBBDDJuego("Warsaw", "b5750a8c-652f-4a83-8bfc-82c5eb16fbf5", "1026420"),
           New AmazonBBDDJuego("When Ski Lifts Go Wrong", "2ad346bf-d6b0-4f34-b462-7e1389727805", "638000"),
           New AmazonBBDDJuego("Wizard of Legend", "19ae680d-5c1e-42f6-a276-5a556b40e812", "445980"),
           New AmazonBBDDJuego("Yooka-Laylee", "96427040-1a7d-4884-a0dd-ed08bdaae57e", "360830"),
           New AmazonBBDDJuego("Yooka-Laylee and the Impossible Lair", "477ebfe3-f3a0-470b-9112-e8b9cfbf2510", "846870")
        }

        Return lista
    End Function

End Module

Public Class AmazonBBDDJuego

    Public Titulo As String
    Public IDAmazon As String
    Public IDSteam As String

    Public Sub New(ByVal titulo As String, ByVal idAmazon As String, ByVal idSteam As String)
        Me.Titulo = titulo
        Me.IDAmazon = idAmazon
        Me.IDSteam = idSteam
    End Sub

End Class