Imports Microsoft.VisualBasic
Imports System
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
Imports Microsoft.Practices.ObjectBuilder
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports LoggingBlock.CreateLogFiles

Namespace RGRHCL_Web_App.DataAccessLayer
    Public Class CBgtDataLayer
        Private _objDS As Database
        Private _dbCommand As SqlCommand
        Public Sub New()
            _objDS = DatabaseFactory.CreateDatabase("Connection String")
        End Sub
        Public Function Bgt_BindDataDownload(ByVal GPsOptId As Integer, ByVal TalukCode As String) As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_DataDownloadList")
                _objDS.AddInParameter(_dbCommand, "@GPSOpId", DbType.Int32, GPsOptId)
                _objDS.AddInParameter(_dbCommand, "@TalukCode", DbType.String, TalukCode)
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindUser(ByVal VRoleId As String) As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindUser")
                _objDS.AddInParameter(_dbCommand, "@RoleId", DbType.String, VRoleId)
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindGrid(ByVal GPsOptId As Integer) As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_DataDownload")
                _objDS.AddInParameter(_dbCommand, "@GPSOpId", DbType.Int32, GPsOptId)
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_CheckLogin(ByVal UserName As String, ByVal Password As String) As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_CheckLogin")
                _objDS.AddInParameter(_dbCommand, "@UserName", DbType.String, UserName)
                _objDS.AddInParameter(_dbCommand, "@Password", DbType.String, Password)
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindTaluk(ByVal DistrictCode As Integer) As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindTaluk")
                _objDS.AddInParameter(_dbCommand, "@DistrictCode", DbType.Int32, DistrictCode)
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindGPSView(ByVal WorkId As Integer) As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindGPSView")
                _objDS.AddInParameter(_dbCommand, "@WorkID", DbType.Int32, WorkId)
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindScheme() As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindScheme")
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindSeries() As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindSeries")
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindDepartment() As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindDepartment")
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindEngg() As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindEngginer")
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindGPSOperatorGPS(ByVal Id As Integer) As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindGPSOperatoruser")
                _objDS.AddInParameter(_dbCommand, "@GPSId", DbType.Int32, Id)
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindGPSOperator() As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindGPSOperator")
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindWorkNature() As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindNatureofWork")
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BindFundSource() As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindSourceOfFund")
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddTaluk(ByRef ObjData As BgtProgress) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddTaluk")
                _objDS.AddInParameter(_dbCommand, "@DistrictCode", DbType.Int32, 7)
                _objDS.AddInParameter(_dbCommand, "@TalukCode", DbType.Int32, ObjData.TalukCode)
                _objDS.AddInParameter(_dbCommand, "@TalukName_Eng", DbType.String, ObjData.TalukName_Eng)
                _objDS.AddInParameter(_dbCommand, "@TalukName_Kan", DbType.String, ObjData.TalukName_Kan)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddDept(ByRef ObjData As BgtProgress) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddDepartment")
                _objDS.AddInParameter(_dbCommand, "@vDeptId", DbType.Int32, ObjData.DeptId)
                _objDS.AddInParameter(_dbCommand, "@vDeptName_Eng", DbType.String, ObjData.DeptName_Eng)
                _objDS.AddInParameter(_dbCommand, "@vDeptName_Kan", DbType.String, ObjData.DeptName_Kan)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddEngg(ByRef ObjData As BgtProgress) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddEngineers")
                _objDS.AddInParameter(_dbCommand, "@vEnggId", DbType.Int32, ObjData.EnggId)
                _objDS.AddInParameter(_dbCommand, "@vEnggName", DbType.String, ObjData.EnggName)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddUser(ByRef UserName As String, ByVal Password As String, ByVal x As Integer, ByVal Role As String, ByVal GPsId As Integer) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddUser")
                _objDS.AddInParameter(_dbCommand, "@UserName", DbType.String, UserName)
                _objDS.AddInParameter(_dbCommand, "@Password", DbType.String, Password)
                _objDS.AddInParameter(_dbCommand, "@x", DbType.Int32, x)
                _objDS.AddInParameter(_dbCommand, "@RoleId", DbType.String, Role)
                _objDS.AddInParameter(_dbCommand, "@GPSId", DbType.String, GPsId)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddGPSOperator(ByRef ObjData As BgtProgress, ByVal IMEI As String) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddGPSOperator")
                _objDS.AddInParameter(_dbCommand, "@vGpsOptID", DbType.Int32, ObjData.GPSOperator)
                _objDS.AddInParameter(_dbCommand, "@vGPSOptName", DbType.String, ObjData.GPsOptName)
                _objDS.AddInParameter(_dbCommand, "@vIMEI", DbType.String, IMEI)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddNatureofWork(ByRef ObjData As BgtProgress, ByVal Category As String) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddNatureofWork")
                _objDS.AddInParameter(_dbCommand, "@vWorkId", DbType.Int32, ObjData.WorkId)
                _objDS.AddInParameter(_dbCommand, "@vWNature_Eng", DbType.String, ObjData.WorkNature_Eng)
                _objDS.AddInParameter(_dbCommand, "@vWNature_Kan", DbType.String, ObjData.WorkNature_Kan)
                _objDS.AddInParameter(_dbCommand, "@vGPSMode", DbType.String, Category)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddSCheme(ByRef ObjData As BgtProgress) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddScheme")
                _objDS.AddInParameter(_dbCommand, "@vSchemeCode", DbType.Int32, ObjData.SchemeCode)
                _objDS.AddInParameter(_dbCommand, "@vSchemeName_Eng", DbType.String, ObjData.SchemeName_Eng)
                _objDS.AddInParameter(_dbCommand, "@vSchemeName_Kan", DbType.String, ObjData.SchemeName_Kan)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddSeries(ByRef ObjData As BgtProgress) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddSeries")
                _objDS.AddInParameter(_dbCommand, "@vSchemeCode", DbType.Int32, ObjData.SeriesYearCode)
                _objDS.AddInParameter(_dbCommand, "@vSchemeName_Eng", DbType.String, ObjData.Series)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddSourceofFubd(ByRef ObjData As BgtProgress) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddSourceOfFound")
                _objDS.AddInParameter(_dbCommand, "@vSourceId", DbType.Int32, ObjData.SourceId)
                _objDS.AddInParameter(_dbCommand, "@vFundSource_Eng", DbType.String, ObjData.SourceName_Eng)
                _objDS.AddInParameter(_dbCommand, "@vFundSource_Kan", DbType.String, ObjData.SourceName_Kan)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_AddBeneficiary(ByRef ObjData As BgtProgress) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_AddBeneficiary")
                _objDS.AddInParameter(_dbCommand, "@vTalukCode", DbType.Int32, ObjData.TalukCode)
                _objDS.AddInParameter(_dbCommand, "@vMlaCode", DbType.Int32, ObjData.TalukCode)
                _objDS.AddInParameter(_dbCommand, "@vSchemeCode", DbType.Int32, ObjData.SchemeCode)
                _objDS.AddInParameter(_dbCommand, "@vSeriesYearCode", DbType.Int32, ObjData.SeriesYearCode)
                _objDS.AddInParameter(_dbCommand, "@vDeptId", DbType.Int32, ObjData.DeptId)
                _objDS.AddInParameter(_dbCommand, "@vDeptName", DbType.String, ObjData.DeptName_Eng)
                _objDS.AddInParameter(_dbCommand, "@vWNature", DbType.Int32, ObjData.WorkId)
                _objDS.AddInParameter(_dbCommand, "@vNameofWork", DbType.String, ObjData.Work)
                _objDS.AddInParameter(_dbCommand, "@vFundSource", DbType.Int32, ObjData.SourceId)
                _objDS.AddInParameter(_dbCommand, "@vLocation", DbType.String, ObjData.Location)
                _objDS.AddInParameter(_dbCommand, "@vUnits", DbType.Int32, ObjData.Nuntis)
                _objDS.AddInParameter(_dbCommand, "@vTotalUnits", DbType.Int32, ObjData.Tuntis)
                _objDS.AddInParameter(_dbCommand, "@vUnitCost", DbType.Single, ObjData.Unitcost)
                _objDS.AddInParameter(_dbCommand, "@vTotalCost", DbType.Single, ObjData.TotalCost)
                _objDS.AddInParameter(_dbCommand, "@vTsNumber", DbType.String, ObjData.TSNumber)
                _objDS.AddInParameter(_dbCommand, "@vTsDate", DbType.String, ObjData.TSDate)
                _objDS.AddInParameter(_dbCommand, "@vRefNo", DbType.String, ObjData.RefNumber)
                _objDS.AddInParameter(_dbCommand, "@vRefDate", DbType.String, ObjData.RefDate)
                _objDS.AddInParameter(_dbCommand, "@vEngginer", DbType.Int32, ObjData.EnggId)
                _objDS.AddInParameter(_dbCommand, "@vGpsOptr", DbType.Int32, ObjData.GPSOperator)
                _objDS.AddInParameter(_dbCommand, "@Document", DbType.String, ObjData.DocFile)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_ModifyBeneficiary(ByVal WorkId As Integer, ByRef ObjData As BgtProgress) As Integer
            Dim iRet As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_ModifyBeneficiary")
                _objDS.AddInParameter(_dbCommand, "@WorkID", DbType.Int32, WorkId)
                _objDS.AddInParameter(_dbCommand, "@vTalukCode", DbType.Int32, ObjData.TalukCode)
                _objDS.AddInParameter(_dbCommand, "@vMlaCode", DbType.Int32, ObjData.TalukCode)
                _objDS.AddInParameter(_dbCommand, "@vSchemeCode", DbType.Int32, ObjData.SchemeCode)
                _objDS.AddInParameter(_dbCommand, "@vSeriesYearCode", DbType.Int32, ObjData.SeriesYearCode)
                _objDS.AddInParameter(_dbCommand, "@vDeptId", DbType.Int32, ObjData.DeptId)
                _objDS.AddInParameter(_dbCommand, "@vDeptName", DbType.String, ObjData.DeptName_Eng)
                _objDS.AddInParameter(_dbCommand, "@vWNature", DbType.Int32, ObjData.WorkId)
                _objDS.AddInParameter(_dbCommand, "@vNameofWork", DbType.String, ObjData.Work)
                _objDS.AddInParameter(_dbCommand, "@vFundSource", DbType.Int32, ObjData.SourceId)
                _objDS.AddInParameter(_dbCommand, "@vLocation", DbType.String, ObjData.Location)
                _objDS.AddInParameter(_dbCommand, "@vUnits", DbType.Int32, ObjData.Nuntis)
                _objDS.AddInParameter(_dbCommand, "@vTotalUnits", DbType.Int32, ObjData.Tuntis)
                _objDS.AddInParameter(_dbCommand, "@vUnitCost", DbType.Single, ObjData.Unitcost)
                _objDS.AddInParameter(_dbCommand, "@vTotalCost", DbType.Single, ObjData.TotalCost)
                _objDS.AddInParameter(_dbCommand, "@vTsNumber", DbType.String, ObjData.TSNumber)
                _objDS.AddInParameter(_dbCommand, "@vTsDate", DbType.String, ObjData.TSDate)
                _objDS.AddInParameter(_dbCommand, "@vRefNo", DbType.String, ObjData.RefNumber)
                _objDS.AddInParameter(_dbCommand, "@vRefDate", DbType.String, ObjData.RefDate)
                _objDS.AddInParameter(_dbCommand, "@vEngginer", DbType.Int32, ObjData.EnggId)
                _objDS.AddInParameter(_dbCommand, "@vGpsOptr", DbType.Int32, ObjData.GPSOperator)
                _objDS.AddInParameter(_dbCommand, "@Document", DbType.String, ObjData.DocFile)
                _objDS.AddOutParameter(_dbCommand, "@Val", DbType.Int32, 5)
                _objDS.ExecuteNonQuery(_dbCommand)
                iRet = _objDS.GetParameterValue(_dbCommand, "@Val")
                Return (iRet)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_BlockBeneficiary(ByVal WorkId As Integer, ByVal Remarks As String) As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BlockBeneficiary")
                _objDS.AddInParameter(_dbCommand, "@WorkId", DbType.Int32, WorkId)
                _objDS.AddInParameter(_dbCommand, "@Remarks", DbType.String, Remarks)
                Return _objDS.ExecuteNonQuery(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function Bgt_BindModify(ByVal WorkId As Integer, ByVal Cat As String, ByVal value As Integer) As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindModify")
                _objDS.AddInParameter(_dbCommand, "@WorkID", DbType.Int32, WorkId)
                _objDS.AddInParameter(_dbCommand, "@Category", DbType.String, Cat)
                _objDS.AddInParameter(_dbCommand, "@Value", DbType.Int32, value)
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function
        Public Function Bgt_UpdateRel_Exp(ByVal WorkID As Integer, ByVal Release As Decimal, ByVal Expenditure As Decimal, ByVal Remarks As String) As Integer
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_ModifyReleases")
                _objDS.AddInParameter(_dbCommand, "@vWorkID", DbType.Int32, WorkID)
                _objDS.AddInParameter(_dbCommand, "@vRelease", DbType.Int64, Release)
                _objDS.AddInParameter(_dbCommand, "@vExpenditure", DbType.Int64, Expenditure)
                _objDS.AddInParameter(_dbCommand, "@vRemarks", DbType.String, Remarks)
                Return _objDS.ExecuteNonQuery(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function Bgt_BindReport(ByVal WorkID As Integer) As DataSet
            _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindReport")
            _objDS.AddInParameter(_dbCommand, "@WorkID", DbType.Int16, WorkID)
            Return _objDS.ExecuteDataSet(_dbCommand)
        End Function
        Public Function Bgt_BindDoc(ByVal WorkID As Integer) As DataSet
            Try
                _dbCommand = _objDS.GetStoredProcCommand("Bgt_BindDoc")
                _objDS.AddInParameter(_dbCommand, "@WorkID", DbType.Int16, WorkID)
                Return _objDS.ExecuteDataSet(_dbCommand)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
