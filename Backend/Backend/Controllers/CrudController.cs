using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        /// <summary> //三個斜線用於快速生成說明
        /// 查詢
        /// </summary>
        /// <param name="number">數字</param>
        /// <param name="name">名稱</param>
        /// <returns></returns>
        [HttpGet]//讀取 比較沒有安全隱患 因此只有標頭沒有身體
        public async Task<IActionResult> Get( [FromQuery]int Number,[FromQuery]string? Name = "yoyo" )//Header是標頭 Body是身體 要通過標頭的權限認證才能讀取Body
        {
            return Ok(new { id = 1 });
        }
        [HttpPost]//新增 
        private async Task<IActionResult> Post([FromBody]bool IsNool)//private 用於私人資料 不公開 public 用於公開資料
        {
            return Ok(new { id = 1 });
        }
        [HttpDelete ("{id}")]//刪除
        public async Task<IActionResult> Delete([FromRoute]int Id)//非同步執行 會先做其他事 等到這件事情完成了再繼續下一步 Route會是空值 需要額外設定
        {
            return Ok(new { id = 1 });
        }
        [HttpPut]//更新
        public IActionResult Put()//同步執行 優先做這一件事情 如果遇到問題了會卡住 並停在這一步驟
        {
            return Ok(new { id = 1 });
        }
    }
}
