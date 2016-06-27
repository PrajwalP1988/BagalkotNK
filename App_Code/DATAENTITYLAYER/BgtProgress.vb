Imports Microsoft.VisualBasic

Public Class BgtProgress
    Private _SchemeCode As Integer
    Private _SeriesYearCode As Integer
    Private _TalukCode As Integer
    Private _SourceId As Integer
    Private _GPSOperator As Integer
    Private _TalukName_Kan As String
    Private _TalukName_Eng As String
    Private _DeptName_Kan As String
    Private _DeptName_Eng As String
    Private _SourceName_Kan As String
    Private _SourceName_Eng As String
    Private _Series As String
    Private _EnggName As String
    Private _GPsOptName As String
    Private _WorkNature_Eng As String
    Private _WorkNature_Kan As String
    Private _SchemeName_Kan As String
    Private _SchemeName_Eng As String
    Private _Location As String
    Private _Work As String
    Private _Nuntis As Integer
    Private _Tuntis As Integer
    Private _Unitcost As Single
    Private _TotalCost As Single
    Private _TSNumber As String
    Private _TSDate As String
    Private _RefNumber As String
    Private _RefDate As String
    Private _EnggId As Integer
    Private _DeptId As Integer
    Private _WorkId As Integer
    Private _DocFile As String

    Public Property RefNumber() As String
        Get
            Return _RefNumber
        End Get
        Set(ByVal value As String)
            _RefNumber = value
        End Set
    End Property
    Public Property DocFile() As String
        Get
            Return _DocFile
        End Get
        Set(ByVal value As String)
            _DocFile = value
        End Set
    End Property
    Public Property RefDate() As String
        Get
            Return _RefDate
        End Get
        Set(ByVal value As String)
            _RefDate = value
        End Set
    End Property
    Public Property TSNumber() As String
        Get
            Return _TSNumber
        End Get
        Set(ByVal value As String)
            _TSNumber = value
        End Set
    End Property
    Public Property TSDate() As String
        Get
            Return _TSDate
        End Get
        Set(ByVal value As String)
            _TSDate = value
        End Set
    End Property
    Public Property TotalCost() As Single
        Get
            Return _TotalCost
        End Get
        Set(ByVal value As Single)
            _TotalCost = value
        End Set
    End Property
    Public Property Unitcost() As Single
        Get
            Return _Unitcost
        End Get
        Set(ByVal value As Single)
            _Unitcost = value
        End Set
    End Property
    Public Property Location() As String
        Get
            Return _Location
        End Get
        Set(ByVal value As String)
            _Location = value
        End Set
    End Property
    Public Property Work() As String
        Get
            Return _Work
        End Get
        Set(ByVal value As String)
            _Work = value
        End Set
    End Property
    Public Property Nuntis() As Integer
        Get
            Return _Nuntis
        End Get
        Set(ByVal value As Integer)
            _Nuntis = value
        End Set
    End Property
    Public Property Tuntis() As Integer
        Get
            Return _Tuntis
        End Get
        Set(ByVal value As Integer)
            _Tuntis = value
        End Set
    End Property
    Public Property Series() As String
        Get
            Return _Series
        End Get
        Set(ByVal value As String)
            _Series = value
        End Set
    End Property
    Public Property GPsOptName() As String
        Get
            Return _GPsOptName
        End Get
        Set(ByVal value As String)
            _GPsOptName = value
        End Set
    End Property
    Public Property EnggName() As String
        Get
            Return _EnggName
        End Get
        Set(ByVal value As String)
            _EnggName = value
        End Set
    End Property

    Public Property SourceName_Eng() As String
        Get
            Return _SourceName_Eng
        End Get
        Set(ByVal value As String)
            _SourceName_Eng = value
        End Set
    End Property
    Public Property SourceName_Kan() As String
        Get
            Return _SourceName_Kan
        End Get
        Set(ByVal value As String)
            _SourceName_Kan = value
        End Set
    End Property
    Public Property WorkNature_Eng() As String
        Get
            Return _WorkNature_Eng
        End Get
        Set(ByVal value As String)
            _WorkNature_Eng = value
        End Set
    End Property
    Public Property WorkNature_Kan() As String
        Get
            Return _WorkNature_Kan
        End Get
        Set(ByVal value As String)
            _WorkNature_Kan = value
        End Set
    End Property

    Public Property DeptName_Kan() As String
        Get
            Return _DeptName_Kan
        End Get
        Set(ByVal value As String)
            _DeptName_Kan = value
        End Set
    End Property
    Public Property DeptName_Eng() As String
        Get
            Return _DeptName_Eng
        End Get
        Set(ByVal value As String)
            _DeptName_Eng = value
        End Set
    End Property
    Public Property SchemeName_Kan() As String
        Get
            Return _SchemeName_Kan
        End Get
        Set(ByVal value As String)
            _SchemeName_Kan = value
        End Set
    End Property
    Public Property SchemeName_Eng() As String
        Get
            Return _SchemeName_Eng
        End Get
        Set(ByVal value As String)
            _SchemeName_Eng = value
        End Set
    End Property
    Public Property TalukName_Kan() As String
        Get
            Return _TalukName_Kan
        End Get
        Set(ByVal value As String)
            _TalukName_Kan = value
        End Set
    End Property
    Public Property TalukName_Eng() As String
        Get
            Return _TalukName_Eng
        End Get
        Set(ByVal value As String)
            _TalukName_Eng = value
        End Set
    End Property
    Public Property DeptId() As Integer
        Get
            Return _DeptId
        End Get
        Set(ByVal value As Integer)
            _DeptId = value
        End Set
    End Property
    Public Property WorkId() As Integer
        Get
            Return _WorkId
        End Get
        Set(ByVal value As Integer)
            _WorkId = value
        End Set
    End Property
    Public Property EnggId() As Integer
        Get
            Return _EnggId

        End Get
        Set(ByVal value As Integer)
            _EnggId = value
        End Set
    End Property
    Public Property SourceId() As Integer
        Get
            Return _SourceId
        End Get
        Set(ByVal value As Integer)
            _SourceId = value
        End Set
    End Property
    Public Property GPSOperator() As Integer
        Get
            Return _GPSOperator
        End Get
        Set(ByVal value As Integer)
            _GPSOperator = value
        End Set
    End Property
    Public Property TalukCode() As Integer
        Get
            Return _TalukCode
        End Get
        Set(ByVal value As Integer)
            _TalukCode = value
        End Set
    End Property
    Public Property SchemeCode() As Integer
        Get
            Return _SchemeCode
        End Get
        Set(ByVal value As Integer)
            _SchemeCode = value
        End Set
    End Property
    Public Property SeriesYearCode() As String
        Get
            Return _SeriesYearCode
        End Get
        Set(ByVal value As String)
            _SeriesYearCode = value
        End Set
    End Property
End Class