namespace Alpaca.Web.CoreAlertTool.Common
{
    public class ConstInfo
    {
        public enum PageId
        {
            /// <summary>
            /// 未指定
            /// </summary>
            None = 0,
            AlertList = 1,
            AlertCreate = 2,
            AlertEdit = 3,
            AlertDelete = 4,
            AlertDetail = 5,
        }

    }

    public class Messages
    {
        public const string DATA_NOT_FOUND = "指定された{0}は存在しません。";
        public const string DATA_ALREADY_FOUND = "既に{0}は存在します。";
    }
}
