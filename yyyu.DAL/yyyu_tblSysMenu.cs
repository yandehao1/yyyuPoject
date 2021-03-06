﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using yyyu.DBUtility;//Please add references
namespace yyyu.DAL
{
	/// <summary>
	/// 数据访问类:yyyu_tblSysMenu
	/// </summary>
	public partial class yyyu_tblSysMenu
	{
		public yyyu_tblSysMenu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Menu_Id", "yyyu_tblSysMenu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Menu_Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from yyyu_tblSysMenu");
			strSql.Append(" where Menu_Id=@Menu_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_Id", SqlDbType.Int,4)			};
			parameters[0].Value = Menu_Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(yyyu.Model.yyyu_tblSysMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into yyyu_tblSysMenu(");
			strSql.Append("Menu_Id,Menu_Level,Menu_ParentId,Name,ShowName,MeunNum,IshasSon,NodeUrl,IsActive,CreateBy,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@Menu_Id,@Menu_Level,@Menu_ParentId,@Name,@ShowName,@MeunNum,@IshasSon,@NodeUrl,@IsActive,@CreateBy,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_Id", SqlDbType.Int,4),
					new SqlParameter("@Menu_Level", SqlDbType.Int,4),
					new SqlParameter("@Menu_ParentId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@ShowName", SqlDbType.VarChar,50),
					new SqlParameter("@MeunNum", SqlDbType.Int,4),
					new SqlParameter("@IshasSon", SqlDbType.NChar,10),
					new SqlParameter("@NodeUrl", SqlDbType.VarChar,50),
					new SqlParameter("@IsActive", SqlDbType.Char,2),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Menu_Id;
			parameters[1].Value = model.Menu_Level;
			parameters[2].Value = model.Menu_ParentId;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.ShowName;
			parameters[5].Value = model.MeunNum;
			parameters[6].Value = model.IshasSon;
			parameters[7].Value = model.NodeUrl;
			parameters[8].Value = model.IsActive;
			parameters[9].Value = model.CreateBy;
			parameters[10].Value = model.CreateTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(yyyu.Model.yyyu_tblSysMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update yyyu_tblSysMenu set ");
			strSql.Append("Menu_Level=@Menu_Level,");
			strSql.Append("Menu_ParentId=@Menu_ParentId,");
			strSql.Append("Name=@Name,");
			strSql.Append("ShowName=@ShowName,");
			strSql.Append("MeunNum=@MeunNum,");
			strSql.Append("IshasSon=@IshasSon,");
			strSql.Append("NodeUrl=@NodeUrl,");
			strSql.Append("IsActive=@IsActive,");
			strSql.Append("CreateBy=@CreateBy,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_Level", SqlDbType.Int,4),
					new SqlParameter("@Menu_ParentId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@ShowName", SqlDbType.VarChar,50),
					new SqlParameter("@MeunNum", SqlDbType.Int,4),
					new SqlParameter("@IshasSon", SqlDbType.NChar,10),
					new SqlParameter("@NodeUrl", SqlDbType.VarChar,50),
					new SqlParameter("@IsActive", SqlDbType.Char,2),
					new SqlParameter("@CreateBy", SqlDbType.VarChar,50),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Menu_Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Menu_Level;
			parameters[1].Value = model.Menu_ParentId;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.ShowName;
			parameters[4].Value = model.MeunNum;
			parameters[5].Value = model.IshasSon;
			parameters[6].Value = model.NodeUrl;
			parameters[7].Value = model.IsActive;
			parameters[8].Value = model.CreateBy;
			parameters[9].Value = model.CreateTime;
			parameters[10].Value = model.ID;
			parameters[11].Value = model.Menu_Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Menu_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from yyyu_tblSysMenu ");
			strSql.Append(" where Menu_Id=@Menu_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Menu_Id", SqlDbType.Int,4)			};
			parameters[0].Value = Menu_Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from yyyu_tblSysMenu ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public yyyu.Model.yyyu_tblSysMenu GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Menu_Id,Menu_Level,Menu_ParentId,Name,ShowName,MeunNum,IshasSon,NodeUrl,IsActive,CreateBy,CreateTime from yyyu_tblSysMenu ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			yyyu.Model.yyyu_tblSysMenu model=new yyyu.Model.yyyu_tblSysMenu();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public yyyu.Model.yyyu_tblSysMenu DataRowToModel(DataRow row)
		{
			yyyu.Model.yyyu_tblSysMenu model=new yyyu.Model.yyyu_tblSysMenu();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Menu_Id"]!=null && row["Menu_Id"].ToString()!="")
				{
					model.Menu_Id=int.Parse(row["Menu_Id"].ToString());
				}
				if(row["Menu_Level"]!=null && row["Menu_Level"].ToString()!="")
				{
					model.Menu_Level=int.Parse(row["Menu_Level"].ToString());
				}
				if(row["Menu_ParentId"]!=null && row["Menu_ParentId"].ToString()!="")
				{
					model.Menu_ParentId=int.Parse(row["Menu_ParentId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["ShowName"]!=null)
				{
					model.ShowName=row["ShowName"].ToString();
				}
				if(row["MeunNum"]!=null && row["MeunNum"].ToString()!="")
				{
					model.MeunNum=int.Parse(row["MeunNum"].ToString());
				}
				if(row["IshasSon"]!=null)
				{
					model.IshasSon=row["IshasSon"].ToString();
				}
				if(row["NodeUrl"]!=null)
				{
					model.NodeUrl=row["NodeUrl"].ToString();
				}
				if(row["IsActive"]!=null)
				{
					model.IsActive=row["IsActive"].ToString();
				}
				if(row["CreateBy"]!=null)
				{
					model.CreateBy=row["CreateBy"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Menu_Id,Menu_Level,Menu_ParentId,Name,ShowName,MeunNum,IshasSon,NodeUrl,IsActive,CreateBy,CreateTime ");
			strSql.Append(" FROM yyyu_tblSysMenu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Menu_Id,Menu_Level,Menu_ParentId,Name,ShowName,MeunNum,IshasSon,NodeUrl,IsActive,CreateBy,CreateTime ");
			strSql.Append(" FROM yyyu_tblSysMenu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM yyyu_tblSysMenu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from yyyu_tblSysMenu T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "yyyu_tblSysMenu";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

