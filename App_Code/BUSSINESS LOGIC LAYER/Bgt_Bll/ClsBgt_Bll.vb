Imports Microsoft.VisualBasic
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
Imports Microsoft.Practices.ObjectBuilder
Imports System.Data
Imports System
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports RGRHCL_Web_App.DataAccessLayer

Namespace RGRHCL_Web_App.Bgt_Bll
    Public Class ClsBgt_Bll
        Dim ObjData As BgtProgress
        Dim objDAL As New CBgtDataLayer

        Public Function Bgt_BindTaluk(ByVal DistrictCode As Integer) As DataSet
            Return objDAL.Bgt_BindTaluk(DistrictCode)
        End Function
        Public Function Bgt_BindUSer(ByVal UserName As String) As DataSet
            Return objDAL.Bgt_BindUser(UserName)
        End Function
        Public Function Bgt_BindGrid(ByVal GPsOptId As Integer) As DataSet
            Return objDAL.Bgt_BindGrid(GPsOptId)
        End Function
        Public Function Bgt_BindDataDownload(ByVal GPsOptId As Integer, ByVal TalukCode As String) As DataSet
            Return objDAL.Bgt_BindDataDownload(GPsOptId, TalukCode)
        End Function
        Public Function Bgt_BindSCheme() As DataSet
            Return objDAL.Bgt_BindScheme()
        End Function
        Public Function Bgt_BindSeries() As DataSet
            Return objDAL.Bgt_BindSeries()
        End Function
        Public Function Bgt_BindDepartment() As DataSet
            Return objDAL.Bgt_BindDepartment()
        End Function
        Public Function Bgt_BindEngg() As DataSet
            Return objDAL.Bgt_BindEngg()
        End Function
        Public Function Bgt_BindFundSource() As DataSet
            Return objDAL.Bgt_BindFundSource()
        End Function
        Public Function Bgt_BindGPSOperator() As DataSet
            Return objDAL.Bgt_BindGPSOperator()
        End Function
        Public Function Bgt_BindGPSOperatorUser(ByVal Id As Integer) As DataSet
            Return objDAL.Bgt_BindGPSOperatorGPS(Id)
        End Function
        Public Function Bgt_BindWorkNature() As DataSet
            Return objDAL.Bgt_BindWorkNature()
        End Function
        Public Function Bgt_AddScheme(ByRef objDa As BgtProgress) As Integer
            Return objDAL.Bgt_AddSCheme(objDa)
        End Function
        Public Function Bgt_AddSeries(ByRef objDa As BgtProgress) As Integer
            Return objDAL.Bgt_AddSeries(objDa)
        End Function
        Public Function Bgt_AddTaluk(ByRef objDa As BgtProgress) As Integer
            Return objDAL.Bgt_AddTaluk(objDa)
        End Function

        Public Function Bgt_AddSourceFund(ByRef objDa As BgtProgress) As Integer
            Return objDAL.Bgt_AddSourceofFubd(objDa)
        End Function

        Public Function Bgt_AddNatureofWork(ByRef objDa As BgtProgress, ByVal Category As String) As Integer
            Return objDAL.Bgt_AddNatureofWork(objDa, Category)
        End Function

        Public Function Bgt_AddEngg(ByRef objDa As BgtProgress) As Integer
            Return objDAL.Bgt_AddEngg(objDa)
        End Function
        Public Function Bgt_AddGPS(ByRef objDa As BgtProgress, ByVal IMEI As String) As Integer
            Return objDAL.Bgt_AddGPSOperator(objDa, IMEI)
        End Function
        Public Function Bgt_AddUser(ByRef UserName As String, ByVal Password As String, ByVal x As Integer, ByVal role As String, ByVal GPsId As Integer) As Integer
            Return objDAL.Bgt_AddUser(UserName, Password, x, role, GPsId)
        End Function
        Public Function Bgt_AddDept(ByRef objDa As BgtProgress) As Integer
            Return objDAL.Bgt_AddDept(objDa)
        End Function
        Public Function Bgt_AddBeneficiary(ByRef objDa As BgtProgress) As Integer
            Return objDAL.Bgt_AddBeneficiary(objDa)
        End Function
        Public Function Bgt_CheckLogin(ByVal UserName As String, ByVal Password As String) As DataSet
            Return objDAL.Bgt_CheckLogin(UserName, Password)
        End Function
        Public Function Bgt_BindGPSView(ByVal WorkId As Integer) As DataSet
            Return objDAL.Bgt_BindGPSView(WorkId)
        End Function
        Public Function Bgt_BindModify(ByVal WorkId As Integer, ByVal Cat As String, ByVal value As Integer) As DataSet
            Return objDAL.Bgt_BindModify(WorkId, Cat, value)
        End Function
        Public Function Bgt_ModifyBeneficiary(ByVal WorkId As Integer, ByRef objDa As BgtProgress) As Integer
            Return objDAL.Bgt_ModifyBeneficiary(WorkId, objDa)
        End Function
        Public Function Bgt_BlockBeneficiary(ByVal WorkId As Integer, ByVal Remarks As String) As Integer
            Return objDAL.Bgt_BlockBeneficiary(WorkId, Remarks)
        End Function
        Public Function Bgt_UpdateRel_Exp(ByVal WorkID As Integer, ByVal Release As Decimal, ByVal Expenditure As Decimal, ByVal Remarks As String) As Integer
            Return objDAL.Bgt_UpdateRel_Exp(WorkID, Release, Expenditure, Remarks)
        End Function
        Public Function Bgt_BindReport(ByVal WorkID As Integer) As DataSet
            Return objDAL.Bgt_BindReport(WorkID)
        End Function
        Public Function Bgt_BindDoc(ByVal WorkID As Integer) As DataSet
            Return objDAL.Bgt_BindDoc(WorkID)
        End Function
    End Class
End Namespace
