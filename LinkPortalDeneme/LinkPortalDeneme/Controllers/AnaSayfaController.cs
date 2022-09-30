using Microsoft.AspNetCore.Mvc;
using LinkPortalDeneme.Models; //modeli dahil edip context sınıfından nesne türettim
using Microsoft.Data.SqlClient;
//using LinkPortalDenemee.Models;

namespace LinkPortalDeneme.Controllers
{
    public class AnaSayfaController : Controller
    {

        public IActionResult Index()
        {

            List<DbModal> List = new List<DbModal>();

            SqlConnection cnc = new SqlConnection("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");

            SqlCommand cmd = new SqlCommand("SELECT lk.AD , lk.Aciklama, lk.Url, l.* FROM Links l, LinkKategori lk WHERE l.KategoriID =lk.ID ", cnc);
            cnc.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    List.Add(new DbModal { LinkAd = dr["AD"].ToString(), LinkDesc = dr["Aciklama"].ToString(), LinkUrl = dr["Url"].ToString(), ProdUrl = dr["ProdUrl"].ToString(), PreProdUrl = dr["PreProdUrl"].ToString(), TestUrl = dr["TestUrl"].ToString() });
                }
            }


            
            dr.Close();
            cmd.Dispose();
            cnc.Close();


            return View(List);
        }

        public IActionResult ProdLink()
        {

            List<DbModal> List = new List<DbModal>();
            

            SqlConnection cnc = new SqlConnection("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");

            SqlCommand cmd = new SqlCommand("SELECT lk.AD , lk.Aciklama, lk.Url, l.* FROM Links l, LinkKategori lk WHERE l.KategoriID =lk.ID ", cnc);
            cnc.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    List.Add(new DbModal { LinkAd = dr["AD"].ToString(), ProdUrl = dr["ProdUrl"].ToString() });
                }
            }


            dr.Close();
            cmd.Dispose();
            cnc.Close();


            return View(List);
        }

        public IActionResult PreProdLink()
        {
            List<DbModal> List = new List<DbModal>();


            SqlConnection cnc = new SqlConnection("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");

            SqlCommand cmd = new SqlCommand("SELECT lk.AD , lk.Aciklama, lk.Url, l.* FROM Links l, LinkKategori lk WHERE l.KategoriID =lk.ID ", cnc);
            cnc.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    List.Add(new DbModal { LinkAd = dr["AD"].ToString(), PreProdUrl = dr["PreProdUrl"].ToString() });
                }
            }

            
            dr.Close();
            cmd.Dispose();
            cnc.Close();


            return View(List);
        }

        public IActionResult TestLink()
        {
            List<DbModal> List = new List<DbModal>();


            SqlConnection cnc = new SqlConnection("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");

            SqlCommand cmd = new SqlCommand("SELECT lk.AD , lk.Aciklama, lk.Url, l.* FROM Links l, LinkKategori lk WHERE l.KategoriID =lk.ID ", cnc);
            cnc.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    List.Add(new DbModal { LinkAd = dr["AD"].ToString(), TestUrl = dr["TestUrl"].ToString() });
                }
            }


            dr.Close();
            cmd.Dispose();
            cnc.Close();


            return View(List);
        }

        
        public IActionResult VeriAl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VeriAl(DbModal model)
        {

            DbModal ekle = new DbModal();
            SqlConnection cnc = new SqlConnection("Server=SQLTSTSRV02\\SQLGNLTST;Database=LinkPortalTest;User Id=linkportaltstuser;Password=NEBZ*x7wsjmAGp;");
            //SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Form (name,surname,subject,email,message) VALUES (@name,@surname,@subject,@email,@message)", cnc);

            ekle.name=model.name;
            ekle.surname=model.surname; 
            ekle.subject=model.subject; 
            ekle.email=model.email; 
            ekle.message=model.message;


            string query = "INSERT INTO dbo.Form (name,surname,subject,email,message) VALUES ('" + ekle.name + "','" + ekle.surname + "','" + ekle.subject + "','" + ekle.email + "','" + ekle.message + "')";
            SqlCommand cmd = new SqlCommand(query, cnc);



            try
            {
                //Bağlantımı açıyorum.
                cnc.Open();
                //Burada ExcuteNonQuery kullanıyorum, çünkü bana geriye herhangi bir veri listesi geri dönmeyecek.
                cmd.ExecuteNonQuery();
                //Komut çalışıp sonlandıktan sonra tekrar aynı sayfaya yönleneceğim.
                Response.Redirect("Index"); //bu satırı yazmasak da olur
            }
            
            finally
            {
                //Bağlantımı kapatıyorum.
                cnc.Close();
            }



            return RedirectToAction("Index");
        }


    }
}
