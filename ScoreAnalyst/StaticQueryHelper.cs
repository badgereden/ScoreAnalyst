using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using Npgsql;

namespace ScoreAnalyst
{
    /// <summary>
    /// Postgresql数据库访问的静态辅助类
    /// 类初始化时生成初始化列表
    /// </summary>
    public static class StaticQueryHelper
    {
        private static Dictionary<int, bool> initlializedList = new Dictionary<int, bool>(2);
        private static bool id_updated = false;
        private static string cnstr = Global.ConnectionString;
        static StaticQueryHelper()
        {
            initlializedList.Add(1, false);
            initlializedList.Add(2, false);
        }

        /// <summary>
        /// 更新学生的考号
        /// </summary>
        /// <returns></returns>
        public static int UpdateIgnoreID()
        {
            if (id_updated)
            {
                return 0;
            }
            else
            {
                id_updated = true;
                return (int)StoredProcedureScalar("update_ignore_id");
            }
        }


        /// <summary>
        /// 返回年级的每个班级的指定信息,已按班级排序.\r\n
        /// 字段列表:班级,任课教师,人数,最高分
        /// 存储过程格式:getClassInformation(subject int,subject character varying)
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <param name="subject">学科名称</param>
        /// <returns>包含查询返回的数据集的DataTable对象</returns>
        public static DataTable GetClassInformation(int subjectType, string subject)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                (NpgsqlCommand cmd) =>{
                    cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                    cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));                   
                }
                );
            return StoredProcedureQuery("\"getClassInformation\"", addParameters);
        }
        /// <summary>
        /// 返回全年级的每个班级的指标完成情况
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <param name="subject">学科名称</param>
        /// <returns></returns>
        public static DataTable GetClassDifference(int subjectType, string subject)
        {
             Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                (NpgsqlCommand cmd) =>{
                    cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                    cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                }
                );
            return StoredProcedureQuery("\"getClassDifference\"", addParameters);
        }
        /// <summary>
        /// 返回全年级每个班级的优秀率,及格率,平均分
        /// 字段列表:班级,优秀率,及格率,平均分
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <param name="subject">学科名称</param>
        /// <param name="totalScore">满分</param>
        /// <returns></returns>
        public static DataTable GetClassRate(int subjectType, string subject,int totalScore)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                   (NpgsqlCommand cmd) => {
                       cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                       cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                       cmd.Parameters.Add(new NpgsqlParameter("\"@totalScore\"", totalScore));
                    } 
             );

            return StoredProcedureQuery("\"getClassRate\"", addParameters);
        }
        /// <summary>
        /// 返回全年级每个班级的分段累计情况
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <param name="subject">学科名称</param>
        /// <param name="step">分段步长</param>
        /// <param name="count">统计数量</param>
        /// <returns></returns>
        public static DataTable GetClassSectionStatistics(int subjectType, string subject, int step, int count)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                (NpgsqlCommand cmd) =>
                {
                    cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                    cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                    cmd.Parameters.Add(new NpgsqlParameter("@step", step));
                    cmd.Parameters.Add(new NpgsqlParameter("@count", count));
                });
            DataTable dt = StoredProcedureQuery("\"getClassSectionStatistics\"", addParameters, true);
            //修改下列名,在名字前面加上"≥"
            for (int i = 1; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = "≥" + dt.Columns[i].ColumnName;
            }
            return dt;
        }
        /// <summary>
        /// 返回全年级指定学科的分数线(一本线,二本线,三本线)
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <param name="subject">学科名称</param>
        /// <returns></returns>
        public static DataTable GetSectionScore(int subjectType, string subject)
        {
              Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                (NpgsqlCommand cmd) =>{
                    cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                    cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
            });

              return StoredProcedureQuery("\"getSectionScore\"", addParameters);

        }
        /// <summary>
        /// 返回全年级的及格率
        /// </summary>
        /// <param name="subjectType">学科类型</param>
        /// <param name="subject">学科名称</param>
        /// <param name="totalScore">满分</param>
        /// <returns></returns>
        public static double GetGradePassRate(int subjectType, string subject, int totalScore)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                (NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                cmd.Parameters.Add(new NpgsqlParameter("\"@totalScore\"", totalScore));
            });

            return (double)StoredProcedureScalar("\"getGradePassRate\"", addParameters);
        }
        /// <summary>
        /// 返回全年级的优秀率
        /// </summary>
        /// <param name="subjectType">学科类型</param>
        /// <param name="subject">学科名称</param>
        /// <param name="totalScore">满分</param>
        /// <returns></returns>
        public static double GetGradeExcellentRate(int subjectType, string subject, int totalScore)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                (NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                cmd.Parameters.Add(new NpgsqlParameter("\"@totalScore\"", totalScore));
            });

            return (double)StoredProcedureScalar("\"getGradeExcellentRate\"", addParameters);
        }
        /// <summary>
        /// 返回全年级指定学科的平均分
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <param name="subject">学科名称</param>
        /// <returns></returns>
        public static double GetGradeAverage(int subjectType, string subject)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                (NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
            });

            return (double)StoredProcedureScalar("\"getGradeAverage\"", addParameters);
        }

        /// <summary>
        /// 返回指定表格内容
        /// </summary>
        /// <param name="tableName">表格名称</param>
        /// <returns></returns>
        public static DataTable BrowserData(string tableName)
        {
            string sql = string.Format("select * from {0}", tableName);
            return ExecuteQuery(sql, null);
        }
        /// <summary>
        /// 清空指定表格内的所有数据
        /// </summary>
        /// <param name="tableName">表格名字</param>
        /// <returns>受影响的行数</returns>
        public static int  ClearData(string tableName)
        {
            string sql=string.Format("delete from {0}", tableName);
            int n = ExecuteNonQuery(sql);
            ExecuteNonQuery(string.Format("VACUUM ANALYZE  {0};", tableName));
            return n;
        }
        /// <summary>
        /// 返回全年级指定学科的分段累计情况
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <param name="subject">学科名称</param>
        /// <param name="step">分段步长</param>
        /// <param name="count">统计数量</param>
        /// <returns>包含查询返回的数据集的DataTable对象</returns>
        public static DataTable GetGradeSectionStatistics(int subjectType, string subject, int step, int count)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                (NpgsqlCommand cmd) => {
                    cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                    cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                    cmd.Parameters.Add(new NpgsqlParameter("@step", step));
                    cmd.Parameters.Add(new NpgsqlParameter("@count", count));
                }
                );
            DataTable dt=StoredProcedureQuery("\"getGradeSectionStatistics\"", addParameters, true);
            foreach(DataColumn dc in dt.Columns)
            {
                dc.ColumnName = "≥" + dc.ColumnName;
            }
            return dt;
        }
        /// <summary>
        /// 返回年级指定学科的最高分
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <param name="subject">学科名称</param>
        /// <returns></returns>
        public static double GetGradeMaxScore(int subjectType, string subject)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
            });

            return (double)StoredProcedureScalar("\"getGradeMaxScore\"", addParameters);
        }
        /// <summary>
        /// 返回全年级指定的学科类别的参加考试人数
        /// </summary>
        /// <param name="subjectType">学科类别:1-理科,2-文科,9-综合(未分科)</param>
        /// <returns></returns>
        public static int GetGradeCount(int subjectType)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
            });
            return (int)StoredProcedureScalar("\"getGradeCount\"", addParameters);
        }
        /// <summary>
        /// 初始化数据库.在进行任何统计之前,都应该先初始化数据库.
        /// 存储过程名称:initialize(subjectType int) returns void
        /// </summary>
        /// <param name="subjectType">学科类别:1-理科,2-文科</param>
        public static void Initialize(int subjectType)
        {
            ////如果已经初始化过,则直接退出.
            //if (initlializedList[subjectType])
            //{
            //    return; 
            //}

            //Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
            //{
            //    cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
            //});
            //StoredProcedureNonQuery("initialize", addParameters);
            ////UpdateIgnoreID();
            //initlializedList[subjectType] = true;
        }
        /// <summary>
        /// 初始化数据,目前测试阶段使用手动初始化
        /// </summary>
        /// <param name="subjectType">学科类别</param>
        /// <param name="subjectList">学科列表</param>
        /// <param name="totalScoreExpression">总分表达式</param>
        /// <param name="ignore">是否忽略不及考核的学生</param>
        public static void Initialize(int subjectType,string subjectList,string totalScoreExpression,bool ignore=true)
        {
            //如果已经初始化过,则直接退出.
            if (initlializedList[subjectType])
            {
                return;
            }

            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                cmd.Parameters.Add(new NpgsqlParameter("\"@subjectList\"", subjectList));
                
                cmd.Parameters.Add(new NpgsqlParameter("\"@totalScoreExpression\"", totalScoreExpression));
                
                //NpgsqlParameter np = new NpgsqlParameter("\"@subjectList\"", DbType.String, 50);
                //np.NpgsqlValue = subjectList;
                //cmd.Parameters.Add(np);
                //NpgsqlParameter np1 = new NpgsqlParameter("\"@totalScoreExpression\"", DbType.String, 50);
                //np1.NpgsqlValue = totalScoreExpression;
                //cmd.Parameters.Add(np1);

                //cmd.Parameters.Add(new NpgsqlParameter("\"@totalScoreExpression\"", totalScoreExpression));
                cmd.Parameters.Add(new NpgsqlParameter("\"@ignore\"", ignore));

                cmd.Parameters[1].DbType = DbType.String;
                cmd.Parameters[2].DbType = DbType.String;

            });
            StoredProcedureNonQuery("initialize_ex", addParameters);
            //UpdateIgnoreID();
            //initlializedList[subjectType] = true;
        }




        /// <summary>
        /// 返回竞赛班级的按名次进行的分段统计
        /// 字段列表:班级,任课教师,50,100,200,300,400,500
        /// 存储过程格式:getSectionByPosition(subjectType int,subject character varying,classList character varying)
        /// </summary>
        /// <param name="subjectType">学科类型:1-理科,2-文科,9-综合(未分科)</param>
        /// <param name="subject">学科名称</param>
        /// <param name="classList">竞赛班列表,用逗号分隔</param>
        /// <returns>包含返回的数据集的DataTable对象</returns>
        public static DataTable GetSectionByPosition(int subjectType, string subject, string classList)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                cmd.Parameters.Add(new NpgsqlParameter("\"@classList\"", classList));
            });

            return StoredProcedureQuery("\"getSectionByPosition\"", addParameters,true);
        }
        /// <summary>
        /// 计算竞赛班的各名次分段的累计人数
        /// </summary>
        /// <param name="subjectType">学科类型:1-理科,2-文科,9-综合(未分科)</param>
        /// <param name="subject">学科名称</param>
        /// <param name="classList">竞赛班列表,用逗号分隔</param>
        /// <param name="sectionList">分段列表</param>
        /// <param name="valid_entry">是否要求有效入围</param>
        /// <returns></returns>
        public static DataTable GetSectionByPosition(int subjectType, string subject, string classList,string sectionList,bool valid_entry)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                cmd.Parameters.Add(new NpgsqlParameter("\"@classList\"", classList));
                cmd.Parameters.Add(new NpgsqlParameter("\"@sectionList\"", sectionList));
                cmd.Parameters.Add(new NpgsqlParameter("\"@valid_entry\"", valid_entry));

            });

            return StoredProcedureQuery("\"getSectionByPosition\"", addParameters, true);
        }

 /// <summary>
 /// 计算全年级教师的超差排名情况
 /// </summary>
 /// <param name="difference_type">超差计算方法,0-超差绝对值,1-完成率</param>
 /// <param name="valid_entry">是否要求有效入围</param>
 /// <param name="contain_3th_section">是否包含三本指标</param>
 /// <returns></returns>
        public static DataTable GetGradeDifference(int difference_type,bool valid_entry,bool contain_3th_section)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Add(new NpgsqlParameter("\"@difference_type\"", difference_type));
                cmd.Parameters.Add(new NpgsqlParameter("\"@valid_entry\"", valid_entry));
                cmd.Parameters.Add(new NpgsqlParameter("\"@contain_3th_section\"", contain_3th_section));
                 });
            return StoredProcedureQuery("\"getGradeDifference\"",addParameters);
        }

        /// <summary>
        /// 计算所有科目的超差情况总表
        /// </summary>
        /// <param name="difference_type">超差计算方法,0-超差绝对值,1-完成率</param>
        /// <param name="valid_entry">是否要求有效入围</param>
        /// <param name="contain_3th_section">是否包含三本指标</param>
        /// <param name="contain_composite">是否包含文综和理综</param>
        /// <returns></returns>
       public static DataTable GetAllClassDifference(int difference_type, bool valid_entry, bool contain_3th_section, bool contain_composite)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Add(new NpgsqlParameter("\"@difference_type\"", difference_type));
                cmd.Parameters.Add(new NpgsqlParameter("\"@valid_entry\"", valid_entry));
                cmd.Parameters.Add(new NpgsqlParameter("\"@contain_3th_section\"", contain_3th_section));
                cmd.Parameters.Add(new NpgsqlParameter("\"@contain_composite\"", contain_composite));
            });
            return StoredProcedureQuery("\"getAllClassDifference\"", addParameters, true);
        }

       public static DataTable GetAllClassDifference(int subjectType, string subjectList, int difference_type, bool valid_entry, bool contain_3th_section)
       {
           Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
           {
               cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
               cmd.Parameters.Add(new NpgsqlParameter("\"@subjectList\"", subjectList));
               cmd.Parameters.Add(new NpgsqlParameter("\"@difference_type\"", difference_type));
               cmd.Parameters.Add(new NpgsqlParameter("\"@valid_entry\"", valid_entry));
               cmd.Parameters.Add(new NpgsqlParameter("\"@contain_3th_section\"", contain_3th_section));
           });
           return StoredProcedureQuery("\"getAllClassDifference\"", addParameters, true);
       }

       public static DataTable GetAllClassDifferenceEx(int difference_type, bool valid_entry, bool contain_3th_section, bool contain_composite)
       {
           Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
           {
               cmd.Parameters.Add(new NpgsqlParameter("\"@difference_type\"", difference_type));
               cmd.Parameters.Add(new NpgsqlParameter("\"@valid_entry\"", valid_entry));
               cmd.Parameters.Add(new NpgsqlParameter("\"@contain_3th_section\"", contain_3th_section));
               cmd.Parameters.Add(new NpgsqlParameter("\"@contain_composite\"", contain_composite));
           });
           return StoredProcedureQuery("\"getAllClassDifferenceEx\"", addParameters, true);
       }

       public static DataTable GetAllClassDifferenceEx(int subjectType,string subjectList,int difference_type, bool valid_entry, bool contain_3th_section)
       {
           Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
           {
               cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"",subjectType));
               cmd.Parameters.Add(new NpgsqlParameter("\"@subjectList\"",subjectList));
               cmd.Parameters.Add(new NpgsqlParameter("\"@difference_type\"", difference_type));
               cmd.Parameters.Add(new NpgsqlParameter("\"@valid_entry\"", valid_entry));
               cmd.Parameters.Add(new NpgsqlParameter("\"@contain_3th_section\"", contain_3th_section));
           });
           return StoredProcedureQuery("\"getAllClassDifferenceEx\"", addParameters, true);
       }

       /// <summary>
       /// 返回全年级某个学科的区分度
       /// </summary>
       /// <param name="subjectType">学科类别</param>
       /// <param name="subject">学科名称</param>
       /// <param name="totalScore">满分</param>
       /// <returns></returns>
       public static double GetDegreeOfDifferentiation(int subjectType, string subject, int totalScore)
       {
           Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                  (NpgsqlCommand cmd) =>
                  {
                      cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                      cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                      cmd.Parameters.Add(new NpgsqlParameter("\"@totalScore\"", totalScore));
                  }
            );

           return (double)StoredProcedureScalar("\"getDegreeOfDifferentiation\"", addParameters);
       }

       /// <summary>
       /// 返回全年级某个学科的难度系数
       /// </summary>
       /// <param name="subjectType">学科类别</param>
       /// <param name="subject">学科名称</param>
       /// <param name="totalScore">满分</param>
       /// <returns></returns>
       public static double GetDegreeOfDifficulty(int subjectType, string subject, int totalScore)
       {
           Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>(
                  (NpgsqlCommand cmd) =>
                  {
                      cmd.Parameters.Add(new NpgsqlParameter("\"@subjectType\"", subjectType));
                      cmd.Parameters.Add(new NpgsqlParameter("@subject", subject));
                      cmd.Parameters.Add(new NpgsqlParameter("\"@totalScore\"", totalScore));
                  }
            );

           return (double)StoredProcedureScalar("\"getDegreeOfDifficulty\"", addParameters);
       }




        /// <summary>
        /// 备份当前的学生成绩
        /// </summary>
        /// <param name="examName">考试名称</param>
        /// <param name="examDate">考试时间</param>
        /// <returns></returns>
        public static int BackupCurrentScore(string examName, DateTime examDate)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
                {
                    cmd.Parameters.Add(new NpgsqlParameter("exam_name", examName));
                    cmd.Parameters.Add(new NpgsqlParameter("exam_date", examDate));
                });
            return (int)StoredProcedureScalar("backup_current_score", addParameters);
        }

        /// <summary>
        /// 还原某个备份的成绩至当前库
        /// </summary>
        /// <param name="examID">exam_id</param>
        /// <returns>还原的记录数量</returns>
        public static int RestoreScore(int examID)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
                {
                    cmd.Parameters.Add(new NpgsqlParameter("exam_id", examID));
                }
            );
            return (int)StoredProcedureScalar("restore_score", addParameters);
        }


        /// <summary>
        /// 备份当前学生成绩
        /// </summary>
        /// <param name="examName">考试名称</param>
        /// <param name="examDate">考试时间</param>
        /// <returns>备份的记录数量</returns>
        public static int Backup(string examName, DateTime examDate)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
            {
                cmd.Parameters.Add(new NpgsqlParameter("\"@exam_name\"",examName));
                cmd.Parameters.Add(new NpgsqlParameter("\"@exam_date\"", examDate));
            });

            return (int)StoredProcedureScalar("\"backup_current_score\"", addParameters);
        }
        /// <summary>
        /// 删除备份的成绩
        /// </summary>
        /// <param name="examID">exam_id</param>
        /// <returns>删除的记录数量</returns>
        public static int DeleteBackup(int examID)
        {
            Action<NpgsqlCommand> addParameters = new Action<NpgsqlCommand>((NpgsqlCommand cmd) =>
                {
                    cmd.Parameters.Add(new NpgsqlParameter("exam_id", examID));
                });
            return (int)StoredProcedureScalar("delete_backup",addParameters);
        }

        #region 主要计算方法
        /// <summary>
        /// 执行一个返回一个数据集的存储过程
        /// </summary>
        /// <param name="spName">存储过程名字(如果名字有大写字母,使用双引号包围)</param>
        /// <param name="addParameters">添加参数委托,签名为 void XXX(NpgsqlCommand) ,可以为null</param>
        /// <param name="useTransaction">指示是否使用事务,默认值为false</param>
        /// <returns>包含返回的数据集的DataTable对象</returns>
        public static DataTable StoredProcedureQuery(string spName, Action<NpgsqlCommand> addParameters=null, bool useTransaction = false)
        {
            return _executeQuery(spName, CommandType.StoredProcedure, addParameters, useTransaction);
        }
        /// <summary>
        /// 执行一个返回一个数据集的sql 语句
        /// </summary>
        /// <param name="sql">sql语句,可以使用查询参数,格式为(:变量名,即以冒号为前缀).</param>
        /// <param name="addParameters">添加参数委托,签名为 void XXX(NpgsqlCommand) ,如果不需要添加参数,则置为null.默认值为null</param>
        /// <param name="useTransaction">指示是否使用事务,默认值为false</param>
        /// <returns>包含返回的数据集的DataTable对象</returns>
        public static DataTable ExecuteQuery(string sql, Action<NpgsqlCommand> addParameters=null, bool useTransaction = false)
        {
            return _executeQuery(sql, CommandType.Text, addParameters, useTransaction);
        }
        private static DataTable _executeQuery(string command, CommandType cmdType, Action<NpgsqlCommand> addParameters=null, bool useTransaction = false)
        {
            using (NpgsqlConnection cn = new NpgsqlConnection(cnstr))
            {
                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter())
                {
                    da.SelectCommand = cn.CreateCommand();
                    da.SelectCommand.CommandType = cmdType;
                    da.SelectCommand.CommandText = command;
                    if (addParameters != null)
                    {
                        addParameters(da.SelectCommand);
                    }
                    DataTable dt = new DataTable();

                        cn.Open();
                        if (useTransaction)
                        {
                            using (NpgsqlTransaction trans = cn.BeginTransaction())
                            {
                                da.SelectCommand.Transaction = trans;
                                da.Fill(dt);
                                trans.Commit();
                            }
                        }
                        else
                        {
                            da.Fill(dt);
                        }
                 
                    return dt;
                }
            }
        }
        /// <summary>
        /// 执行一个仅返回单个值的存储过程
        /// </summary>
        /// <param name="sql">sql语句,可以使用查询参数,格式为(:变量名,即以冒号为前缀).</param>
        /// <param name="addParameters">添加参数委托,签名为 void XXX(NpgsqlCommand) ,如果不需要添加参数,则置为null.默认值为null</param>
        /// <returns>返回的object对象</returns>
        public static object ExecuteScalar(string sql, Action<NpgsqlCommand> addParameters=null)
        {
            return _executeScalar(sql, CommandType.Text, addParameters);
        }
        /// <summary>
        /// 执行一个仅返回单个值的sql语句,通常用于执行单个聚合函数
        /// </summary>
        /// <param name="spName">存储过程名字(如果名字有大写字母,使用双引号包围)</param>
        /// <param name="addParameters">添加参数委托,签名为 void XXX(NpgsqlCommand) ,如果不需要添加参数,则置为null.默认值为null</param>
        /// <returns>返回的object对象</returns>
        public static object StoredProcedureScalar(string spName, Action<NpgsqlCommand> addParameters=null)
        {
            return _executeScalar(spName, CommandType.StoredProcedure, addParameters);
        }
        private static object _executeScalar(string command, CommandType cmdType, Action<NpgsqlCommand> addParameters=null)
        {
            using (NpgsqlConnection cn = new NpgsqlConnection(cnstr))
            {
                using (NpgsqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = command;
                    if (addParameters != null)
                    {
                        addParameters(cmd); //添加参数
                    }
                    cn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 执行不带返回值的存储过程
        /// </summary>
        /// <param name="spName">存储过程名字(如果名字有大写字母,使用双引号包围)</param>
        /// <param name="addParameters">添加参数委托,签名为 void XXX(NpgsqlCommand) ,如果不需要添加参数,则置为null.默认为null</param>
        /// <param name="useTransaction">指示是否使用事务,默认为false</param>
        /// <returns>受影响的行数</returns>
        public static int StoredProcedureNonQuery(string spName, Action<NpgsqlCommand> addParameters=null, bool useTransaction = false)
        {
            return _executeNonQuery(spName, addParameters, CommandType.StoredProcedure, useTransaction);
        }
        /// <summary>
        /// 执行不带返回值的sql语句
        /// </summary>
        /// <param name="sql">sql语句,可以使用查询参数,格式为(:变量名,即以冒号为前缀).</param>
        /// <param name="addParameters">添加参数委托,签名为 void XXX(NpgsqlCommand) ,如果不需要添加参数,则置为null.默认为null</param>
        /// <param name="useTransaction">指示是否使用事务,默认为false</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, Action<NpgsqlCommand> addParameters=null, bool useTransaction = false)
        {
            return _executeNonQuery(sql, addParameters, CommandType.Text, useTransaction);
        }
        private static int _executeNonQuery(string commmd, Action<NpgsqlCommand> addParameters, CommandType cmdType, bool useTransaction)
        {
            using (NpgsqlConnection cn = new NpgsqlConnection(cnstr))
            {
                using (NpgsqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commmd;
                    if (addParameters != null)
                    {
                        addParameters(cmd);
                    }
                    if (useTransaction)
                    {
                        using (NpgsqlTransaction trans = cn.BeginTransaction())
                        {
                            cmd.Transaction = trans;
                            cn.Open();
                            int effectedRows = cmd.ExecuteNonQuery();
                            trans.Commit();
                            return effectedRows;
                        }
                    }
                    else
                    {
                        cn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        #endregion



    }





}
