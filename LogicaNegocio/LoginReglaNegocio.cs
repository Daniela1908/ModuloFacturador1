﻿using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LoginReglaNegocio
    {
        public LoginEntidad IniciarSesion(LoginEntidad loginEntidad) {

            LoginAccesoDatos loginAccesoDatos = new LoginAccesoDatos();
            return loginAccesoDatos.IniciarSesion(loginEntidad);
        }

    }
}
