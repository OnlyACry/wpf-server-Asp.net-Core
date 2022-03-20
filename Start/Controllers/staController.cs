using Common.Models;
using IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class staController : ControllerBase
    {
        IfdecaypoolService _ifdecaypoolService;
        public staController(IfdecaypoolService ifdecaypoolService)
        {
            _ifdecaypoolService = ifdecaypoolService;
        }

        string connectStr = "Data Source=.;Initial Catalog=Medicine;Persist Security Info=True;User ID=lcac;Password=123456";
        DataTable dt = new DataTable();

        #region 衰变池 -> 总量
        [HttpPost]
        [Route("withPool")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult withPool([FromForm] string pool, [FromForm] string WorkMode)
        {
            
            try
            {
                using (SqlConnection myconn = new SqlConnection(connectStr))
                {
                    List<staSearch> tb_staSearch = new List<staSearch>();
                    myconn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select RecordNo, MAX(WaterTotal) as TotalWater, CONVERT(VARCHAR(12), DecayPoolTime, 111) as PoolTime from tb_DecayPool where WorkMode = '" + WorkMode + "' and DecayPoolName = '" + pool + "' GROUP BY RecordNo, CONVERT(VARCHAR(12), DecayPoolTime, 111)";
                    
                    cmd.Connection = myconn;

                    try
                    {
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            staSearch staSearch = new staSearch();
                            staSearch.RecordNo = (string)sqlDataReader["RecordNo"];
                            staSearch.TotalWater = Convert.ToDouble(sqlDataReader["TotalWater"]);
                            staSearch.PoolTime = Convert.ToDateTime(sqlDataReader["PoolTime"]);
                            tb_staSearch.Add(staSearch);
                        }
                        return Ok(tb_staSearch);
                    }
                    catch (Exception ee)
                    {
                        return Ok("");
                    }
                    finally
                    {
                        myconn.Close();
                    }
                }
            }
            catch (Exception e0)
            {
                return Ok("");
            }
        }
        #endregion

        #region 衰变池 -> 连续推流式，病人数
        [HttpPost]
        [Route("withPatient")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult withPatient([FromForm] string pool, [FromForm] string WorkMode)
        {
            
            try
            {
                using (SqlConnection myconn = new SqlConnection(connectStr))
                {
                    List<staSearch> tb_staSearch = new List<staSearch>();
                    myconn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select RecordNo, SUM(PatientNum) as TotalWater, CONVERT(VARCHAR(12), DecayPoolTime, 111) as PoolTime from tb_DecayPool where WorkMode = '" + WorkMode + "' and DecayPoolName = '" + pool + "' and State = '0' GROUP BY RecordNo, CONVERT(VARCHAR(12), DecayPoolTime, 111)";
                    
                    cmd.Connection = myconn;

                    try
                    {
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            staSearch staSearch = new staSearch();
                            staSearch.RecordNo = (string)sqlDataReader["RecordNo"];
                            staSearch.TotalWater = Convert.ToDouble(sqlDataReader["TotalWater"]);
                            staSearch.PoolTime = Convert.ToDateTime(sqlDataReader["PoolTime"]);
                            tb_staSearch.Add(staSearch);
                        }
                        return Ok(tb_staSearch);
                    }
                    catch (Exception ee)
                    {
                        return Ok("");
                    }
                    finally
                    {
                        myconn.Close();
                    }
                }
            }
            catch (Exception e0)
            {
                return Ok("");
            }
        }
        #endregion

        #region 污染物
        [HttpGet]
        [Route("Pollutant")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult Pollutant()
        {
            //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
            try
            {
                var all_ryzzs = _ifdecaypoolService.Query<tb_Pollutant>(a=>true);

                if (all_ryzzs?.Count() > 0)
                {
                    var userInfo = all_ryzzs.ToList();

                    //可以根据权限不同返回一个对应菜单
                    return Ok(userInfo);
                }
                else return Ok("");
            }
            catch (Exception e0)
            {
                return Ok("");
            }
        }
        #endregion
    }
}
