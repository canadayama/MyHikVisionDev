using EB.Cameras.HikVision.Extensions.ParameterSettings;

namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// 
    /// </summary>
    class CommandParam : MVSParam, ICommandParam
    {
        #region ************************** Properties **************************

        #endregion *************************************************************

        #region ************************** Constructor *************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        public CommandParam( MVS mvs, string strKey ) : base( mvs, strKey )
        { }

        #endregion *************************************************************

        #region *********************** Instance Methods ***********************

        /// <summary>
        /// Execute command.
        /// </summary>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public bool Execute()
        {
            return Mvs.ExecuteCommand( StrKey );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format( "{0} {1} {2}",
                                    base.ToString(),
                                        nameof( Execute ),
                                            FormatAccessModeString() );
        }

        #endregion *************************************************************
    }
}
