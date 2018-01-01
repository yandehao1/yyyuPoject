using System;
using System.Data;
using System.Collections.Generic;
using yyyu.Common;
using yyyu.Model;
namespace yyyu.BLL
{
	/// <summary>
	/// yyyu_tblSysMenu
	/// </summary>
	public partial class yyyu_tblSysMenu
	{
		private readonly yyyu.DAL.yyyu_tblSysMenu dal=new yyyu.DAL.yyyu_tblSysMenu();
		public yyyu_tblSysMenu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Menu_Id)
		{
			return dal.Exists(Menu_Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(yyyu.Model.yyyu_tblSysMenu model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(yyyu.Model.yyyu_tblSysMenu model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Menu_Id)
		{
			
			return dal.Delete(Menu_Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(yyyu.Common.PageValidate.SafeLongFilter(IDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public yyyu.Model.yyyu_tblSysMenu GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public yyyu.Model.yyyu_tblSysMenu GetModelByCache(int ID)
		{
			string CacheKey = "yyyu_tblSysMenuModel-" + ID;
			object objModel = yyyu.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = yyyu.Common.ConfigHelper.GetConfigInt("ModelCache");
						yyyu.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (yyyu.Model.yyyu_tblSysMenu)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 获取菜单，转换为JSON
        /// </summary>
        /// <returns></returns>
        public string GetMuenList() 
        {
            //获取数据
            DataSet ds = this.GetList("IsActive=1");
            //将数据存放到List<Dictionary<string, string>>
            List<Dictionary<string, string>> lisdic = new List<Dictionary<string, string>>();
            Dictionary<string, Model.yyyu.TreeObejct> dic = new Dictionary<string, Model.yyyu.TreeObejct>();
            List<Model.yyyu.TreeObejct> list = new List<Model.yyyu.TreeObejct>();
            Model.yyyu.TreeObejct mp=null;
            //判断是否获取到菜单数据
            if (ds.Tables[0].Rows.Count>0)
            {
                //添加父节点
                DataView dv = ds.Tables[0].DefaultView;//获取视图
                dv.RowFilter = "Menu_ParentId=-1 AND Menu_Level=1";
                DataTable dt=dv.ToTable();
                string json = yyyu.Common.JsonHelper.SerializationStr(dt);//将父节点转化为JSON；
                mp = yyyu.Common.JsonHelper.JsonStrToObject<Model.yyyu.TreeObejct>(json);//将父节点添加到实体中

                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        mp.ID = dt.Rows[i]["Menu_Id"].ToString();
                        mp.Name = dt.Rows[i][""].ToString();
                        mp.PID = dt.Rows[i][""].ToString();
                        if (dt.Rows[i][""].ToString()=="1")
                        {
                            mp.Url = "";
                        }
                        else
                        {
                            mp.Url = dt.Rows[i]["NodeUrl"].ToString();
                        }
                        mp.MeunNum = dt.Rows[i]["MeunNum"].ToString();
                    }
                }
            }
            else
            {

            }
            return "";
        }

                            //        mp.Url = "";
                            //DataView dv2 = ds.Tables[0].DefaultView;//获取视图
                            //dv2.RowFilter = "Menu_ParentId=" + mp.PID;
                            //DataTable dt2 = dv2.ToTable();
                            //for (int j = 0; j < dt2.Rows.Count; j++)
                            //{
                                
                            //}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<yyyu.Model.yyyu_tblSysMenu> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<yyyu.Model.yyyu_tblSysMenu> DataTableToList(DataTable dt)
		{
			List<yyyu.Model.yyyu_tblSysMenu> modelList = new List<yyyu.Model.yyyu_tblSysMenu>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				yyyu.Model.yyyu_tblSysMenu model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

