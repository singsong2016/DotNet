 [Route("api/[controller]")]
[ApiController]
public class Test : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Peoples>> GetPeoples()
    {

        var sql = "select * from t_hr_crew t where t.c_name like '%张%'";
        var dt = await DB.GetData(sql);
        var result = DataConvert<Peoples>.ToList(dt);
        return result;
    }

    [HttpGet("{workno}")]
    public async Task<Peoples> GetPeoples(string workno)
    {
        var sql = $"select * from t_hr_crew t where t.work_no='JYH-{workno}'";
        var dt = await DB.GetData(sql);
        var result = DataConvert<Peoples>.ToEntity(dt.Rows[0]);
        return result;
    }
}
