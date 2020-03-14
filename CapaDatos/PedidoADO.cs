///<author>Francisco José Ferrer Rodríguez<author>
using System;
using System.Collections.Generic;
using Capa_entidades;
using System.Net.Http;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;

namespace Capa_datos
{
    public class PedidoADO : ADO
    {

        // Leo todos los pedido de la BD
        public List<Pedido> LeerPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/pedidos").Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    listaPedidos = JsonConvert.DeserializeObject<List<Pedido>>(aux);
                    listaPedidos = ActualizarListaLinped(listaPedidos);
                }
                else
                {
                    throw new ExternalException(JsonConvert.SerializeObject(response));
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return listaPedidos;
        }
        public Pedido LeerPedido(long id)
        {
            Pedido pedido = new Pedido();
            string aux;

            try
            {
                HttpResponseMessage response = client.GetAsync("api/pedidos/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    aux = response.Content.ReadAsStringAsync().Result;

                    pedido = JsonConvert.DeserializeObject<Pedido>(aux);
                    LinpedADO linpedAdo = new LinpedADO();
                    pedido.ListLinped = linpedAdo.LeerLinped(pedido.PedidoID);
                }
                else
                {
                    throw new ExternalException(JsonConvert.SerializeObject(response));
                }
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }

            return pedido;
        }
        public List<Pedido> LeerPedidosByUsuarioEmail(string email)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            UsuarioADO usuarioAdo = new UsuarioADO();
            Usuario usuario = usuarioAdo.LeerUsuariosByEmail(email);
            if(usuario != null)
                foreach (Pedido pedido in LeerPedidos())
                    if (pedido.UsuarioID.Equals(usuario.UsuarioID))
                        listaPedidos.Add(pedido);
            return listaPedidos;
        }
        // Creo un nuevo pedido en la BD
        public Pedido InsertarPedido(Pedido pedido)
        {
            try
            {
                HttpResponseMessage response = client.PostAsync("api/pedidos",
                    new StringContent(new JavaScriptSerializer().Serialize(pedido), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<Pedido>(response.Content.ReadAsStringAsync().Result);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }
        public bool ActualizarPedido(Pedido pedido)
        {
            try
            {
                HttpResponseMessage response = client.PutAsync("api/pedidos/" + pedido.PedidoID,
                    new StringContent(new JavaScriptSerializer().Serialize(pedido), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }

        public bool BorrarPedido(long id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("api/pedidos/" + id).Result;

                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new ExternalException("Error:" + e);
            }
        }

        public List<Pedido> ActualizarListaLinped(List<Pedido> listaPedidos)
        {
            LinpedADO linpedAdo = new LinpedADO();
            List<Linped> listLipeds = linpedAdo.LeerLinpeds();
            foreach (Pedido pedido in listaPedidos)
                pedido.ListLinped = linpedAdo.LeerLinped(pedido.PedidoID);
            return listaPedidos;
        }

        public bool ExistePedido(Pedido pedido)
        {
            foreach (Pedido p in LeerPedidos())
                if (p.PedidoID.Equals(pedido.PedidoID))
                    return true;
            return false;
        }

        public List<Pedido> FiltrarPedidoPorUsuario(List<Pedido> listPedidos, long usuarioId)
        {
            List<Pedido> tmpListPedidos = new List<Pedido>();
            foreach (Pedido pedido in listPedidos)
                if (pedido.UsuarioID.Equals(usuarioId))
                    tmpListPedidos.Add(pedido);
            return tmpListPedidos;
        }

        public List<Pedido> FiltrarPedidoEntreFechas(List<Pedido> listPedidos, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Pedido> tmpListPedidos = new List<Pedido>();
            foreach (Pedido pedido in listPedidos)
                if (pedido.Fecha >= fechaInicio && pedido.Fecha <= fechaFin)
                    tmpListPedidos.Add(pedido);
            return tmpListPedidos;
        }

        public long Max()
        {
            List<Pedido> listPedidos = LeerPedidos();
            if(listPedidos.Count > 0)
                return listPedidos[listPedidos.Count - 1].PedidoID;
            return 0;
        }

    }

}