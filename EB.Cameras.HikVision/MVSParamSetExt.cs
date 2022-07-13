using System;
using System.Reflection;
using System.Collections.Generic;

using BE.Cameras;
using BE.Cameras.Exceptions;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision
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
        /// <returns>Boolean value.</returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static bool GetBoolValue( this MVS mvs, string strKey )
        {
            if ( mvs.IsOpen )
            {
                bool pbValue = false;
                
                int rslt = mvs.Cam.MV_CC_GetBoolValue_NET( strKey, ref pbValue );
                if ( rslt == MV_OK )
                {
                    return pbValue;
                }

                throw new CamGetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// Set the value of camera boolean type node.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="bValue">Node value.</param>
        /// <exception cref="CamSetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static void SetBoolValue( this MVS mvs,
                                           string strKey, bool bValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetBoolValue_NET( strKey, bValue );
                if ( rslt == MV_OK )
                {
                    return;
                }

                throw new CamSetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        #endregion -------------------------------------------------------------

        #region ------------------------- Enum Methods -------------------------

        /// <summary>
        /// Get the value of camera Enum type node.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pstValue"></param>
        /// <returns></returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static bool GetEnumValue( this MVS mvs,
                                           string strKey, ref MVCC_ENUMVALUE pstValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetEnumValue_NET( strKey, ref pstValue );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                throw new CamGetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// Set the value of camera Enum type node.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="nValue"></param>
        /// <exception cref="CamSetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static void SetEnumValue( this MVS mvs,
                                           string strKey, uint nValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetEnumValue_NET( strKey, nValue );
                if ( rslt == MV_OK )
                {
                    return;
                }

                throw new CamSetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// Set the value of camera Enum with string value.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="sValue"></param>
        internal static void SetEnumValueByString( this MVS mvs,
                                                   string strKey, string sValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetEnumValueByString_NET( strKey, sValue );
                if ( rslt == MV_OK )
                {
                    return;
                }

                throw new CamSetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <returns></returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static uint GetEnumValue( this MVS mvs, string strKey )
        {
            MVCC_ENUMVALUE pstValue = new MVCC_ENUMVALUE();
            mvs.GetEnumValue( strKey, ref pstValue );
            return pstValue.nCurValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <returns></returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static uint[] GetSupportedValues( this MVS mvs, string strKey )
        {
            MVCC_ENUMVALUE pstValue = new MVCC_ENUMVALUE();
            mvs.GetEnumValue( strKey, ref pstValue );
            return pstValue.nSupportValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <param name="enumDic"></param>
        /// <returns></returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static string GetEnumStringValue( this MVS mvs,
                                                   string strKey,
                                                   Dictionary<uint, string> enumDic )
        {
            MVCC_ENUMVALUE pstValue = new MVCC_ENUMVALUE();
            mvs.GetEnumValue( strKey, ref pstValue );
            if ( enumDic.TryGetValue( pstValue.nCurValue, out string eStr ) )
            {
                return eStr;
            }

            throw new CamGetException( string.Format( "Unknown {0} value({1})", strKey, pstValue.nCurValue ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <param name="enumDic"></param>
        /// <returns></returns>
        internal static MVSEnum[] GetEnumValues( this MVS mvs,
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
        /// <returns></returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static void GetFloatValue( this MVS mvs,
                                            string strKey, ref MVCC_FLOATVALUE pstValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetFloatValue_NET( strKey, ref pstValue );
                if ( rslt == MV_OK )
                {
                    return;
                }

                throw new CamGetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="fValue"></param>
        /// <exception cref="CamSetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static void SetFloatValue( this MVS mvs,
                                            string strKey, float fValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetFloatValue_NET( strKey, fValue );
                if ( rslt == MV_OK )
                {
                    return;
                }

                throw new CamSetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <returns></returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static float GetFloatValue( this MVS mvs, string strKey )
        {
            MVCC_FLOATVALUE pstValue = new MVCC_FLOATVALUE();
            mvs.GetFloatValue( strKey, ref pstValue );
            return pstValue.fCurValue;
        }

        #endregion -------------------------------------------------------------

        #region ----------------------- Integer Methods ------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pstValue"></param>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static void GetIntValueEx( this MVS mvs,
                                            string strKey, ref MVCC_INTVALUE_EX pstValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetIntValueEx_NET( strKey, ref pstValue );
                if ( rslt == MV_OK )
                {
                    return;
                }

                throw new CamGetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="nValue"></param>
        /// <exception cref="CamSetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static void SetIntValueEx( this MVS mvs,
                                            string strKey, int nValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetIntValueEx_NET( strKey, nValue );
                if ( rslt == MV_OK )
                {
                    return;
                }

                throw new CamSetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <returns></returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static long GetIntValueEx( this MVS mvs, string strKey )
        {
            MVCC_INTVALUE_EX pstValue = new MVCC_INTVALUE_EX();
            mvs.GetIntValueEx( strKey, ref pstValue );
            return pstValue.nCurValue;
        }

        #endregion -------------------------------------------------------------

        #region ------------------------ String Methods ------------------------

        /// <summary>
        /// Get the value of camera string type node.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pstValue">Obtained node MVCC_STRINGVALUE value.</param>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static void GetStringValue( this MVS mvs,
                                               string strKey, ref MVCC_STRINGVALUE pstValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetStringValue_NET( strKey, ref pstValue );
                if ( rslt == MV_OK )
                {
                    return;
                }

                throw new CamGetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// Set the value of camera string type node.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <param name="strValue">Node value.</param>
        /// <exception cref="CamSetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static void SetStringValue( this MVS mvs,
                                             string strKey, string strValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetStringValue_NET( strKey, strValue );
                if ( rslt == MV_OK )
                {
                    return;
                }

                throw new CamSetException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <returns></returns>
        /// <exception cref="CamGetException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        internal static string GetStringValue( this MVS mvs, string strKey )
        {
            MVCC_STRINGVALUE pstValue = new MVCC_STRINGVALUE();
            mvs.GetStringValue( strKey, ref pstValue );
            return pstValue.chCurValue;
        }

        #endregion -------------------------------------------------------------

        #region ----------------------- Command Methods ------------------------

        /// <summary>
        /// Set the value of camera node with ICommand type.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey">Node name.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        internal static bool SetCommandValue( this MVS mvs, string strKey )
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
        internal static bool ReadMemory( this MVS mvs,
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
        internal static bool WriteMemory( this MVS mvs,
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
