using Microsoft.AspNetCore.Mvc;
using Osoft.SiparisOnay.Core.DTO;
using Osoft.SiparisOnay.Core.Models;
using Osoft.SiparisOnay.Repository.IRepositories;

namespace Osoft.SiparisOnay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _repository;

        public MenuController(IMenuRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenunew()
        {
            try
            {
                var modelData = await _repository.GetAllMenuNew();
                var groupedMenuItems = GroupMenuItemsYetkilendirme(modelData);
                return Ok(new { statusCode = 200, rowCount = groupedMenuItems.OrderBy(x => x.text).Count(), data = groupedMenuItems });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }


        //Yetkilendirme ekranı içindir...
        private IEnumerable<MenuItemDTO> GroupMenuItemsYetkilendirme(IEnumerable<MenuNew> data)
        {
            var groupedMenuItems = new List<MenuItemDTO>();
            int counter1 = 1, counter2 = 1, counter3 = 1;
            foreach (var item in data)
            {
                var group1 = groupedMenuItems.FirstOrDefault(x => x.text == item.mnew_kod1);
                if (group1 == null)
                {
                    group1 = new MenuItemDTO
                    {
                        id = $"{counter1}",
                        menuPrimNo = item.mnew_id.ToString(),
                        text = item.mnew_kod1,
                        expanded = false,
                        treeListNumber = counter1,
                        items = new List<MenuItemDTO>()
                    };
                    groupedMenuItems.Add(group1);
                    counter1++;
                    counter2 = 1;
                }

                var group2 = group1.items.FirstOrDefault(x => x.text == item.mnew_kod2);
                if (group2 == null)
                {
                    group2 = new MenuItemDTO
                    {
                        id = $"{group1.id}_{counter2++}",
                        menuPrimNo = item.mnew_id.ToString(),
                        text = item.mnew_kod2,
                        expanded = false,
                        treeListNumber = counter1,
                        items = new List<MenuItemDTO>()
                    };
                    group1.items.Add(group2);
                }

                var menuItem = new MenuItemDTO
                {
                    id = $"{group2.id}_{group2.items.Count + 1}",
                    menuPrimNo = item.mnew_id.ToString(),
                    text = item.mnew_kod3,
                    expanded = false,
                    treeListNumber = counter1,
                    items = new List<MenuItemDTO>()
                };

                group2.items.Add(menuItem);
            }

            return groupedMenuItems;
        }



        [HttpPost]
        public async Task<IActionResult> GetMenuNew(Filter? filter)
        {
            try
            {
                var modelData = await _repository.GetMenuNewYetki(filter);
                //var modelData = await _repository.GetMenuNew(filter);

                // Gruplama işlemi
                var groupedMenuItems = GroupMenuItems(modelData);

                return Ok(new { statusCode = 200, data = groupedMenuItems });
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = 400, error = ex.Message });
            }
        }

        private IEnumerable<MenuItemDTO> GroupMenuItems(IEnumerable<menu_new_yetki2> data)
        {

            var groupedMenuItems = new List<MenuItemDTO>();
            int counter1 = 1, counter2 = 1;
            foreach (var item in data)
            {
                var group1 = groupedMenuItems.FirstOrDefault(x => x.text == item.meny2_kod1);
                if (group1 == null)
                {
                    group1 = new MenuItemDTO
                    {
                        id = $"{counter1}",
                        menuPrimNo = item.meny2_mnew_id.ToString(),
                        text = item.meny2_kod1,
                        expanded = false,
                        items = new List<MenuItemDTO>()
                    };
                    groupedMenuItems.Add(group1);
                    counter1++;
                    counter2 = 1;
                }

                var group2 = group1.items.FirstOrDefault(x => x.text == item.meny2_kod2);
                if (group2 == null)
                {
                    group2 = new MenuItemDTO
                    {
                        id = $"{group1.id}_{counter2++}",
                        menuPrimNo = item.meny2_mnew_id.ToString(),
                        text = item.meny2_kod2,
                        expanded = false,
                        items = new List<MenuItemDTO>()
                    };
                    group1.items.Add(group2);
                }


                //string url = "", icon = "";
                ////burası silinecek
                //if (item.mnew_kod3 == "Döküm Sipariş Girişi")
                //{
                //    url = "siparis-girisi";
                //    icon = "fa-solid fa-cart-plus";
                //}
                //else if (item.mnew_kod3 == "Döküm Üretim Girişi")
                //{
                //    url = "rapor";
                //    icon = "fa-solid fa-hammer";
                //}
                //else if (item.mnew_kod3 == "Üretim Raporu")
                //{
                //    url = "dinamik-rapor";
                //    icon = "fas fa-chart-bar";
                //}
                //else if (item.mnew_kod3 == "Planlama Oluşturma")
                //{
                //    url = "dinamik-rapor";
                //    icon = "fa-solid fa-calendar-plus";
                //}
                //else if (item.mnew_kod3 == "İşemri Girişi")
                //{
                //    url = "dinamik-rapor";
                //    icon = "fa-solid fa-file-invoice";
                //}

                var menuItem = new MenuItemDTO
                {
                    id = $"{group2.id}_{group2.items.Count + 1}",
                    menuPrimNo = item.meny2_mnew_id.ToString(),
                    text = item.meny2_kod3,
                    expanded = false,
                    //mnew_resim1 = icon,
                    //mnew_url = url,
                    mnew_resim1 = item.menuNew.mnew_resim1,
                    mnew_url = item.menuNew.mnew_url,
                    items = new List<MenuItemDTO>()
                };

                group2.items.Add(menuItem);
            }

            return groupedMenuItems;
        }


        //private IEnumerable<MenuItemDTO> GroupMenuItems(IEnumerable<menu_new_yetki2> data)
        //{

        //    var groupedMenuItems = new List<MenuItemDTO>();
        //    int counter1 = 1, counter2 = 1;
        //    foreach (var item in data)
        //    {
        //        if (item.meny2_kod3 == "Döküm Sipariş Girişi" || item.meny2_kod3 == "Döküm Üretim Girişi" || item.meny2_kod3 == "Üretim Raporu")
        //        {
        //            var group1 = groupedMenuItems.FirstOrDefault(x => x.text == item.meny2_kod1);
        //            if (group1 == null)
        //            {
        //                group1 = new MenuItemDTO
        //                {
        //                    id = $"{counter1}",
        //                    menuPrimNo = item.meny2_mnew_id.ToString(),
        //                    text = item.meny2_kod1,
        //                    expanded = false,
        //                    items = new List<MenuItemDTO>()
        //                };
        //                groupedMenuItems.Add(group1);
        //                counter1++;
        //                counter2 = 1;
        //            }

        //            var group2 = group1.items.FirstOrDefault(x => x.text == item.meny2_kod2);
        //            if (group2 == null)
        //            {
        //                group2 = new MenuItemDTO
        //                {
        //                    id = $"{group1.id}_{counter2++}",
        //                    menuPrimNo = item.meny2_mnew_id.ToString(),
        //                    text = item.meny2_kod2,
        //                    expanded = false,
        //                    items = new List<MenuItemDTO>()
        //                };
        //                group1.items.Add(group2);
        //            }


        //            string url = "", icon = "";
        //            //burası silinecek
        //            if (item.meny2_kod3 == "Döküm Sipariş Girişi")
        //            {
        //                url = "siparis-girisi";
        //                icon = "fa-solid fa-cart-plus";
        //            }
        //            else if (item.meny2_kod3 == "Döküm Üretim Girişi")
        //            {
        //                url = "rapor";
        //                icon = "fa-solid fa-hammer";
        //            }
        //            else if (item.meny2_kod3 == "Üretim Raporu")
        //            {
        //                url = "dinamik-rapor";
        //                icon = "fas fa-chart-bar";
        //            }

        //            var menuItem = new MenuItemDTO
        //            {
        //                id = $"{group2.id}_{group2.items.Count + 1}",
        //                menuPrimNo = item.meny2_mnew_id.ToString(),
        //                text = item.meny2_kod3,
        //                expanded = false,
        //                mnew_resim1 = icon,
        //                mnew_url = url,
        //                //mnew_resim1 = item.menuNew.mnew_resim1,
        //                //mnew_url = item.menuNew.mnew_url,
        //                items = new List<MenuItemDTO>()
        //            };

        //            group2.items.Add(menuItem);
        //        }
        //    }

        //    return groupedMenuItems;
        //}
    }
}
