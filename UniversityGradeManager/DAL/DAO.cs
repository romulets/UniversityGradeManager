using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityGradeManager.DAL
{
    abstract public class DAO : IDisposable
    {

        private SqlConnection _conn;
        private SqlTransaction _trans;

        protected SqlConnection Conn
        {
            get
            {
                return _conn;
            }
        }

        protected SqlTransaction Trans
        {
            get
            {
                return _trans;
            }
        }

        public DAO()
        {
            string strConn = WebConfigurationManager.AppSettings["databaseStrConn"];
            _conn = new SqlConnection(strConn);
            _conn.Open();
        }

        protected void BeginTrans()
        {
            _trans = Conn.BeginTransaction();
        }

        protected void CommitTrans()
        {
            if (Trans != null)
            {
                _trans.Commit();
                _trans = null;
            }
        }

        protected void RollbackTrans()
        {
            if (Trans != null)
            {
                _trans.Rollback();
                _trans = null;
            }
        }

        public void Dispose()
        {
            Conn.Close();
        }
    }
}