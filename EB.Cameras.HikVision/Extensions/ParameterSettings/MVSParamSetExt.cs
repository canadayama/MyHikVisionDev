using System;
using System.Reflection;
using System.Collections.Generic;

using EB.Cameras.HikVision.Settings;
using EB.Cameras.HikVision.Classes;

using BE.Cameras;
using BE.Cameras.Exceptions;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Extensions.ParameterSettings
{
    /// <summary>
    /// Parameter Settings 
    /// </summary>
    public static class MVSParamSetExt
    {
        #region ====================== Parameter Settings ======================

        #region ------------------------- Bool Methods -------------------------

        /// <summary>
        /// Get the value of camera boolean type node.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pbValue"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetBoolValue( this MVS mvs, string strKey, ref bool pbValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetBoolValue_NET( strKey, ref pbValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Set the value of camera boolean type node.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="bValue">Node value.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetBoolValue( this MVS mvs,
                                           string strKey, bool bValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetBoolValue_NET( strKey, bValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <returns>Bool value on success; false on fail w/ GetErr sent to OnCamEvent.</returns>
        public static bool GetBool( this MVS mvs, string strKey )
        {
            bool bValue = false;
            if ( mvs.GetBoolValue( strKey, ref bValue ) )
            {
                return bValue;
            }
            
            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <param name="bValue"></param>
        /// <remarks>If error occurs then a SetErr sent to OnCamEvent.</remarks>
        public static void SetBool( this MVS mvs, string strKey, bool bValue )
        {
            if ( mvs.SetBoolValue( strKey, bValue ) )
            {
                return;
            }

            mvs.Notify( CamEvnt.SetErr, mvs.LastErrorMessage );
        }

        #endregion -------------------------------------------------------------

        #region ------------------------- Enum Methods -------------------------

        /// <summary>
        /// Get the value of camera Enum type node.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pstValue"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetEnumValue( this MVS mvs,
                                           string strKey, ref MVCC_ENUMVALUE pstValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetEnumValue_NET( strKey, ref pstValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Set the value of camera Enum type node.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="nValue"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetEnumValue( this MVS mvs,
                                           string strKey, uint nValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetEnumValue_NET( strKey, nValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Set the value of camera Enum with string value.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="sValue"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetEnumValueByString( this MVS mvs,
                                                   string strKey, string sValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetEnumValueByString_NET( strKey, sValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <returns></returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        public static uint GetEnumValue( this MVS mvs, string strKey )
        {
            MVCC_ENUMVALUE pstValue = new MVCC_ENUMVALUE();
            if ( mvs.GetEnumValue( strKey, ref pstValue ) )
            {
                return pstValue.nCurValue;
            }

            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <returns></returns>
        public static uint[] GetSupportedValues( this MVS mvs, string strKey )
        {
            MVCC_ENUMVALUE pstValue = new MVCC_ENUMVALUE();
            if ( mvs.GetEnumValue( strKey, ref pstValue ) )
            {
                return pstValue.nSupportValue;
            }

            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return new uint[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <param name="enumDic"></param>
        /// <returns></returns>
        public static string GetEnumStringValue( this MVS mvs,
                                                   string strKey,
                                                   Dictionary<uint, string> enumDic )
        {
            MVCC_ENUMVALUE pstValue = new MVCC_ENUMVALUE();
            if ( mvs.GetEnumValue( strKey, ref pstValue ) )
            {
                if ( enumDic.TryGetValue( pstValue.nCurValue, out string eStr ) )
                {
                    return eStr;
                }

                return string.Format( "Unknown {0} value({1})", strKey, pstValue.nCurValue );
            }

            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <param name="enumDic"></param>
        /// <returns></returns>
        public static MVSEnum[] GetEnumValues( this MVS mvs,
                                                 string strKey,
                                                 Dictionary<uint, string> enumDic )
        {
            List<MVSEnum> enumList = new List<MVSEnum>();

            uint[] eValues = mvs.GetSupportedValues( strKey );
            for ( int i = 0; i < eValues.Length; i++ )
            {
                uint eVal = eValues[i]; 
                if ( enumDic.TryGetValue( eVal, out string eStr ) )
                {
                    enumList.Add( new MVSEnum( eVal, eStr ) );
                    continue;
                }

                mvs.Notify( CamEvnt.GetErr,
                            CamHelper.StdErrorMessage( mvs.CamName,
                                                       MVSHelper.StdGetSetErrHeader( strKey, MethodBase.GetCurrentMethod().Name ),
                                                       string.Format( "EnumValue({0})Dictionaryにありません。", eVal ) ) );
            }

            return enumList.ToArray();
        }

        #endregion -------------------------------------------------------------

        #region ------------------------ Float Methods -------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pstValue"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetFloatValue( this MVS mvs,
                                          string strKey, ref MVCC_FLOATVALUE pstValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetFloatValue_NET( strKey, ref pstValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return true;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="fValue">Float value.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetFloatValue( this MVS mvs,
                                          string strKey, float fValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetFloatValue_NET( strKey, fValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <returns>float value on success; -1 on fail w/ GetErr sent to OnCamEvent.</returns>
        public static float GetFloat( this MVS mvs, string strKey )
        {
            MVCC_FLOATVALUE pstValue = new MVCC_FLOATVALUE();
            if ( mvs.GetFloatValue( strKey, ref pstValue ) )
            {
                return pstValue.fCurValue;
            }

            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="fValue">Float value.</param>
        /// <remarks>If error occurs then a SetErr sent to OnCamEvent.</remarks>
        public static void SetFloat( this MVS mvs, string strKey, float fValue )
        {
            if ( mvs.SetFloatValue( strKey, fValue ) )
            {
                return;
            }

            mvs.Notify( CamEvnt.SetErr, mvs.LastErrorMessage );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pd"></param>
        /// <returns>float on success; -1 on fail w/ GetErr sent to OnCamEvent.</returns>
        public static float GetFloat( this MVS mvs, string strKey, ParamDet pd )
        {
            MVCC_FLOATVALUE pstValue = new MVCC_FLOATVALUE();
            if ( mvs.GetFloatValue( strKey, ref pstValue ) )
            {
                switch ( pd )
                {
                    case ParamDet.Minimum:
                        return pstValue.fMin;

                    case ParamDet.Maximum:
                        return pstValue.fMax;

                    default:
                        mvs.Notify( CamEvnt.GetErr,
                                    CamHelper.StdErrorMessage( mvs.CamName,
                                                               MVSHelper.StdGetSetErrHeader( strKey, MethodBase.GetCurrentMethod().Name ),
                                                               string.Format( "({0}) {1} Unknown", pd, nameof( ParamDet ) ) ) );
                        return -1;
                }
            }

            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return -1;
        }

        #endregion -------------------------------------------------------------

        #region ----------------------- Integer Methods ------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pstValue"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetIntValueEx( this MVS mvs,
                                            string strKey, ref MVCC_INTVALUE_EX pstValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetIntValueEx_NET( strKey, ref pstValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="nValue"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetIntValueEx( this MVS mvs,
                                            string strKey, long nValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetIntValueEx_NET( strKey, nValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <returns>long value on success; -1 on fail w/ GetErr sent to OnCamEvent.</returns>
        public static long GetInt( this MVS mvs, string strKey )
        {
            MVCC_INTVALUE_EX pstValue = new MVCC_INTVALUE_EX();
            if ( mvs.GetIntValueEx( strKey, ref pstValue ) )
            {
                return pstValue.nCurValue;
            }

            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="nValue">Integer value.</param>
        /// <remarks>If error occurs then a SetErr sent to OnCamEvent.</remarks>
        public static void SetInt( this MVS mvs, string strKey, long nValue )
        {
            if ( mvs.SetIntValueEx( strKey, nValue ) )
            {
                return;
            }

            mvs.Notify( CamEvnt.SetErr, mvs.LastErrorMessage );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <param name="pd"></param>
        /// <returns>long value on success; -1 on fail w/ GetErr sent to OnCamEvent.</returns>
        internal static long GetInt( this MVS mvs, string strKey, ParamDet pd )
        {
            MVCC_INTVALUE_EX intValue = new MVCC_INTVALUE_EX();
            if ( mvs.GetIntValueEx( strKey, ref intValue ) )
            {
                switch ( pd )
                {
                    case ParamDet.Increment:
                        return intValue.nInc;

                    case ParamDet.Minimum:
                        return intValue.nMin;

                    case ParamDet.Maximum:
                        return intValue.nMax;

                    default:
                        mvs.Notify( CamEvnt.GetErr,
                                    CamHelper.StdErrorMessage( mvs.CamName,
                                                                MVSHelper.StdGetSetErrHeader( strKey, MethodBase.GetCurrentMethod().Name ),
                                                                string.Format( "({0}) {1} Unknown", pd, nameof( ParamDet ) ) ) );
                        return -1;
                }
            }

            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return -1;
        }

        #endregion -------------------------------------------------------------

        #region ------------------------ String Methods ------------------------

        /// <summary>
        /// Get the value of camera string type node.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pstValue">Obtained node MVCC_STRINGVALUE value.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetStringValue( this MVS mvs,
                                           string strKey,
                                           ref MVCC_STRINGVALUE pstValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetStringValue_NET( strKey, ref pstValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Set the value of camera string type node.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="strValue">Node value.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetStringValue( this MVS mvs,
                                           string strKey,
                                           string strValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetStringValue_NET( strKey, strValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                      MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <returns>string for node;
        /// empty string on error w/ GetErr sent to OnCamEvent.</returns>
        public static string GetString( this MVS mvs, string strKey )
        {
            MVCC_STRINGVALUE pstValue = new MVCC_STRINGVALUE();
            if ( mvs.GetStringValue( strKey, ref pstValue ) )
            {
                return pstValue.chCurValue;
            }

            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <param name="strValue"></param>
        /// <remarks>If error occurs SetErr sent to OnCamEvent.</remarks>
        public static void SetString( this MVS mvs,
                                      string strKey, string strValue )
        {
            if ( mvs.SetStringValue( strKey, strValue ) )
            {
                return;
            }

            mvs.Notify( CamEvnt.SetErr, mvs.LastErrorMessage );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <returns>String max length;
        /// -1 if error occurs w/ GetErr sent to OnCamEvent</returns>
        public static long GetStringMaxLength( this MVS mvs, string strKey )
        {
            MVCC_STRINGVALUE pstValue = new MVCC_STRINGVALUE();
            if ( mvs.GetStringValue( strKey, ref pstValue ) )
            {
                return pstValue.nMaxLength;
            }

            mvs.Notify( CamEvnt.GetErr, mvs.LastErrorMessage );
            return -1;
        }

        #endregion -------------------------------------------------------------

        #region ----------------------- Command Methods ------------------------

        /// <summary>
        /// Set the value of camera node with ICommand type.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetCommandValue( this MVS mvs, string strKey )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetCommandValue_NET( strKey );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Executes the command using node name strKey.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool ExecuteCommand( this MVS mvs, string strKey )
        {
            return mvs.SetCommandValue( strKey );
        }

        #endregion -------------------------------------------------------------

        #region ------------------------ Memory Methods ------------------------

        /// <summary>
        /// Read data from the device register.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="pBuffer"></param>
        /// <param name="nAddress"></param>
        /// <param name="nLength"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool ReadMemory( this MVS mvs,
                                         IntPtr pBuffer, long nAddress, long nLength )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_ReadMemory_NET( pBuffer, nAddress, nLength );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Write data into the device register.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="pBuffer"></param>
        /// <param name="nAddress"></param>
        /// <param name="nLength"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool WriteMemory( this MVS mvs,
                                          IntPtr pBuffer, long nAddress, long nLength )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_WriteMemory_NET( pBuffer, nAddress, nLength );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        #endregion -------------------------------------------------------------

        #endregion =============================================================
    }
}
