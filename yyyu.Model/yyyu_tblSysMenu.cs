using System;
namespace yyyu.Model
{
	/// <summary>
	/// yyyu_tblSysMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class yyyu_tblSysMenu
	{
		public yyyu_tblSysMenu()
		{}
		#region Model
		private int _id;
		private int _menu_id;
		private int _menu_level;
		private int _menu_parentid;
		private string _name;
		private string _showname;
		private int? _meunnum;
		private string _ishasson;
		private string _nodeurl;
		private string _isactive;
		private string _createby;
		private DateTime _createtime= DateTime.Now;
		/// <summary>
		/// 表自增ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 主键ID
		/// </summary>
		public int Menu_Id
		{
			set{ _menu_id=value;}
			get{return _menu_id;}
		}
		/// <summary>
		/// 菜单等级：1,2,3
		/// </summary>
		public int Menu_Level
		{
			set{ _menu_level=value;}
			get{return _menu_level;}
		}
		/// <summary>
		/// 上级菜单的ID
		/// </summary>
		public int Menu_ParentId
		{
			set{ _menu_parentid=value;}
			get{return _menu_parentid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 显示名称
		/// </summary>
		public string ShowName
		{
			set{ _showname=value;}
			get{return _showname;}
		}
		/// <summary>
		/// 序号
		/// </summary>
		public int? MeunNum
		{
			set{ _meunnum=value;}
			get{return _meunnum;}
		}
		/// <summary>
		/// 是否包含子菜单
		/// </summary>
		public string IshasSon
		{
			set{ _ishasson=value;}
			get{return _ishasson;}
		}
		/// <summary>
		/// 菜单节点对应的跳转URL
		/// </summary>
		public string NodeUrl
		{
			set{ _nodeurl=value;}
			get{return _nodeurl;}
		}
		/// <summary>
		/// 是否激活,1:激活 2：关闭
		/// </summary>
		public string IsActive
		{
			set{ _isactive=value;}
			get{return _isactive;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public string CreateBy
		{
			set{ _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

