using EB.Cameras.HikVision.Settings;

namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    class UserSetCtrls : IUserSetCtrls
    {
        #region ************************** Properties **************************
        
        /// <summary></summary>
        public IIntParamRO Current { get; }

        ///// <summary></summary>
        //public IEnumParam Selector { get; }
        
        /// <summary></summary>
        public ICommandParam Load { get; }

        /// <summary></summary>
        public ICommandParam Save { get; }

        ///// <summary></summary>
        //public IEnumParam Default { get; }

        #endregion *************************************************************

        #region ************************* Constructor ************************** 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        public UserSetCtrls( MVS mvs )
        {
            Current = new IntParam( mvs, MVSConsts.UserSetCurrent );
            //Selector = new EnumParam( mvs, MVSConsts.UserSetSelector );
            Load = new CommandParam( mvs, MVSConsts.UserSetLoad );
            Save = new CommandParam( mvs, MVSConsts.UserSetSave );
            //Default = new IntParam( mvs, MVSConsts.UserSetDefault );
        }

        #endregion *************************************************************
    }
}
