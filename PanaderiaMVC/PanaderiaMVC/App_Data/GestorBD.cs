using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PanaderiaMVC.Models;
using System.Configuration;

namespace PanaderiaMVC.APP_Data
{
	public class GestorBD
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;


        public GestorBD()
        {
            cn = new SqlConnection();
            cmd = new SqlCommand();
            dr = null;

        }

        public List<Delivery> cargarComboDelivery()
        {

            List<Delivery> lista = new List<Delivery>();


            cn.ConnectionString = @"Data Source=DESKTOP-9MEAR48\SQLEXPRESS;Initial Catalog=Panaderia;Integrated Security=True";
            cn.Open();
            string sqlConsulta = "select * from TiposDelivery";
            
            cmd.Connection = cn;
            cmd.CommandText = sqlConsulta;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Delivery d = new Delivery();
                d.Id = (int)dr["Id"];
                d.Nombre = (string)dr["Nombre"];
                d.PrecioEntrega = (double)dr["PrecioEntrega"];
                lista.Add(d);
            }
            dr.Close();
            cn.Close();
            return lista;
        }

        public List<Desayuno> cargarComboDesayuno()
        {

            List<Desayuno> lista = new List<Desayuno>();


            cn.ConnectionString = @"Data Source=DESKTOP-9MEAR48\SQLEXPRESS;Initial Catalog=Panaderia;Integrated Security=True";
            cn.Open();
            string sqlConsulta = "select * from TiposDesayuno";

            cmd.Connection = cn;
            cmd.CommandText = sqlConsulta;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Desayuno d = new Desayuno();
                d.Id = (int)dr["Id"];
                d.Nombre = (string)dr["Nombre"];
                d.Precio = (double)dr["Precio"];
                lista.Add(d);
            }
            dr.Close();
            cn.Close();
            return lista;
        }


        public void insertarPedido(AltaPedido al)
        {
            string consulta = "insert into Pedidos values (@cliente, @tipoDesayuno, @tipoDelivery, @porcion)";

            cn.ConnectionString = @"Data Source=DESKTOP-9MEAR48\SQLEXPRESS;Initial Catalog=Panaderia;Integrated Security=True";
            cn.Open();

            
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@cliente", al.Cliente);
            cmd.Parameters.AddWithValue("@tipoDesayuno", al.Delivery);
            cmd.Parameters.AddWithValue("@tipoDelivery", al.Delivery);
            cmd.Parameters.AddWithValue("@porcion", al.Porciones);
            
            cmd.CommandText = consulta;
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public List<ListadoFacturacion> listaFacturacion()
        {
            List<ListadoFacturacion> lista = new List<ListadoFacturacion>();
            string consulta = @"select p.Cliente,de.Nombre as nombreDel,d.Nombre , ((p.Porciones *d.Precio)+de.PrecioEntrega) as Total
								from Pedidos p
								join TiposDelivery de on p.IdTipoDelivery = de.Id
								join TiposDesayuno d on p.IdTipoDesayuno = d.Id
                                ";
            cn.ConnectionString = @"Data Source=DESKTOP-9MEAR48\SQLEXPRESS;Initial Catalog=Panaderia;Integrated Security=True";
            cn.Open();

            
            cmd.Connection = cn;
            cmd.CommandText = consulta;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListadoFacturacion ad = new ListadoFacturacion();
                ad.Cliente = (string)dr["Cliente"];
                ad.TipoDelivery = (string)dr["nombreDel"];
                ad.TipoDesayuno = (string)dr["Nombre"];
                ad.PrecioTotal = (double)dr["Total"];
                

                lista.Add(ad);
            }
            dr.Close();
            cn.Close();
            return lista;
        }
        public List<ReporteDel> ReporteDelivery()
        {
            List<ReporteDel> lista = new List<ReporteDel>();
            var consulta = @"select d.Nombre,COUNT(*)as cantidad
						from TiposDelivery d
						join Pedidos p on p.IdTipoDelivery = d.Id
						group by d.Nombre";
            cn.ConnectionString = @"Data Source=DESKTOP-9MEAR48\SQLEXPRESS;Initial Catalog=Panaderia;Integrated Security=True";
            cn.Open();

            
            cmd.Connection = cn;
            cmd.CommandText = consulta;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ReporteDel vr = new ReporteDel();
                
                vr.Nombre = (string)dr["Nombre"];
                vr.Cantidad = (int)dr["cantidad"];
                
                

                lista.Add(vr);
            }
            dr.Close();
            cn.Close();
            return lista;

            
        }
    }
	
}
