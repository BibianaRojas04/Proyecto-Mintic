using Microsoft.AspNetCore.Mvc;

using BOOLEANDATA2.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using NuGet.Packaging.Licenses;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Linq.Expressions;

namespace BOOLEANDATA2.Controllers
{
    public class AccesoController : Controller
    {
        static string cadena = "Data Source=DESKTOP-2PCMBJQ; Initial Catalog=BOOLEANDATA; integrated security=true";

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Acceso");
        }



        [HttpPost]
        public async Task<IActionResult> Index(Acudiente _acudiente, PersonalAdmin _admin, Usuario _user)
         
        {
            _user.Usuario1 = "";
            _user.Clave1 = "";
            _user.rol1 = "";

            _acudiente.Nombres = "";
            _acudiente.Usuario = "";
            _acudiente.Clave = "";
            _acudiente.Rol = "";

            _admin.Usuario= "";
            _admin.Nombre = "";
            _admin.Clave= "";
            _admin.Rol= "";

            using (SqlConnection con = new SqlConnection(cadena))
            {
                
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", con);
                    cmd.Parameters.AddWithValue("usuario", _acudiente.Usuario);
                    cmd.Parameters.AddWithValue("clave", _acudiente.Clave);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    _acudiente.IdAcudiente = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                catch (SqlException) { }

                if (_acudiente.IdAcudiente != 0)
                {
                    _user.Usuario1 = _acudiente.Usuario;
                    _user.Clave1 = _acudiente.Clave;
                    _user.rol1 = _acudiente.Rol;
                }
                else {

                    try
                    {
                        SqlCommand cmd1 = new SqlCommand("sp_ValidarUsuario", con);
                        cmd1.Parameters.AddWithValue("usuario", _admin.Usuario);
                        cmd1.Parameters.AddWithValue("clave", _admin.Clave);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        con.Open();
                       
                        _admin.IdPerAdm = Convert.ToInt32(cmd1.ExecuteScalar().ToString());
                    }catch (SqlException) { }

                    if (_admin.IdPerAdm != 0)
                    {

                        _user.Usuario1 = _admin.Usuario;
                        _user.Clave1 = _admin.Clave;
                        _user.rol1 = _admin.Rol;
                    }
                }

                if (_user.Equals(null)) {

                    return View();
                }
                else
                {
                    var Claims=new List<Claim>();

                    if (_user.rol1.Equals("Acudiente"))
                    {
                        Claims.Add(new Claim(ClaimTypes.Name, _acudiente.Nombres));
                        Claims.Add(new Claim("usuario", _acudiente.Usuario));
                        Claims.Add(new Claim(ClaimTypes.Role, _acudiente.Rol));
                    }
                    else if (_user.rol1.Equals("Administrativo"))
                    {
                        Claims.Add(new Claim(ClaimTypes.Name, _admin.Nombre));
                        Claims.Add(new Claim("usuario", _admin.Usuario));
                        Claims.Add(new Claim(ClaimTypes.Role, _admin.Rol));
                    }
                    else {
                        Claims.Add(new Claim(ClaimTypes.Name, ""));
                        Claims.Add(new Claim("usuario", ""));
                        Claims.Add(new Claim(ClaimTypes.Role,""));


                    }

                    var claimsIdentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");

                }

                  

                    

                  

                       
                }





            }
        }
    }

